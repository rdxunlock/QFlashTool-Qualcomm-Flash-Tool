using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MPPG;
using QFlashTool.Properties;

namespace QFlashTool
{
	public class Form2 : Form
	{
		private string partition = "";

		private string startLBA = "";

		private string sizeLBA = "";

		private string sizeByte = "";

		private string TotalSize = "";

		private string needToBK = "";

		private string flashCommand = "";

		private string port;

		private string firehose;

		private bool dumpFinished;

		public static Form2 _Form2;

		private static string wkDir;

		private IContainer components = null;

		private StatusStrip statusStrip1;

		private ToolStripStatusLabel lbl1;

		private GroupBox groupBox1;

		private ListView listView1;

		private ColumnHeader columnHeader1;

		private ColumnHeader columnHeader2;

		private ColumnHeader columnHeader3;

		private ColumnHeader columnHeader4;

		private Button btnBackup;

		private Label label1;

		private BackgroundWorker bwDumpEmmc;

		private RichTextBox logEmmc;

		private ToolStripStatusLabel lbl2;

		private System.Windows.Forms.Timer timer1;

		public string SIZE => needToBK;

		private static string WorkingDir => wkDir;

		public int SizeOfDump
		{
			get
			{
				long num = Convert.ToInt64(SIZE) * 512L;
				string value = (num / 6291456L).ToString();
				return Convert.ToInt32(value);
			}
		}

		public int SleepTimeForDump
		{
			get
			{
				int num2 = 1000;
				int sizeOfDump = SizeOfDump;
				if (sizeOfDump < 100)
				{
					return sizeOfDump * num2 / 100;
				}
				if (sizeOfDump > 100)
				{
					return sizeOfDump * num2 / 220;
				}
				return 800;
			}
		}

		public Form2()
		{
			InitializeComponent();
			M m = new M();
			port = m.Comport;
			firehose = M.WorkingFirehose;
			_Form2 = this;
		}

		public static void Rename(string string_0, string string_1)
		{
			FileInfo fileInfo = new FileInfo(string_0);
			fileInfo.MoveTo(fileInfo.Directory.FullName + "\\" + string_1);
		}

		private void Form2_Load(object sender, EventArgs e)
		{
			if (MyClass.eMMC.GPT.Count < 2)
			{
				lbl1.Text = " разделы пустые ";
			}
			MyClass.eMMC.GPT.ForEach(delegate(string string_0)
			{
				string[] array = string_0.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
				partition = array[3];
				startLBA = array[6];
				sizeLBA = array[10];
				long long_ = Convert.ToInt64(sizeLBA) * 512L;
				sizeByte = MyClass.Myfiles.SizeConvertor(long_);
				ListViewItem value = new ListViewItem(array[3])
				{
					SubItems = { startLBA, sizeLBA, sizeByte }
				};
				listView1.Items.Add(value);
				TotalSize = (Convert.ToInt64(startLBA) + Convert.ToInt64(sizeLBA)).ToString();
			});
			timer1.Enabled = true;
		}

		private void btnBackup_Click(object sender, EventArgs e)
		{
			if (listView1.Items.Count < 1)
			{
				MessageBox.Show("Ошибка");
				return;
			}
			if (listView1.SelectedItems.Count < 1)
			{
				MessageBox.Show("Ошибка");
				return;
			}
			using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
			{
				DialogResult dialogResult = folderBrowserDialog.ShowDialog();
				if (dialogResult != DialogResult.OK || string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
				{
					return;
				}
				wkDir = folderBrowserDialog.SelectedPath;
			}
			dumpFinished = false;
			needToBK = (Convert.ToInt64(startLBA) + Convert.ToInt64(sizeLBA)).ToString();
			long long_ = Convert.ToInt64(needToBK) * 512L;
			sizeByte = MyClass.Myfiles.SizeConvertor(long_);
			TryToDump();
		}

		private void TryToDump()
		{
			flashCommand = " -p " + port + " -f " + firehose + " -d 0 " + SIZE + " -o backup" + partition + "_eMMC.bin";
			if (!bwDumpEmmc.IsBusy)
			{
				btnBackup.Enabled = false;
				groupBox1.Enabled = false;
				timer1.Enabled = false;
				bwDumpEmmc.RunWorkerAsync();
			}
			WaitForDumpEmmc();
		}

		private void listView1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listView1.SelectedItems.Count != 0)
			{
				ListViewItem listViewItem = listView1.SelectedItems[0];
				partition = listViewItem.Text;
				startLBA = listViewItem.SubItems[1].Text;
				sizeLBA = listViewItem.SubItems[2].Text;
				sizeByte = listViewItem.SubItems[3].Text;
				logEmmc.Clear();
				logEmmc.AppendText("\n");
				logEmmc.AppendText("\n");
				logEmmc.AppendText("\n");
				logEmmc.AppendText(" Выбран раздел:\t\t- ", Color.White);
				logEmmc.AppendText(partition + "\n", Color.Yellow);
				logEmmc.AppendText(" Начало блока:\t\t- ", Color.White);
				logEmmc.AppendText("0x0\n", Color.Yellow);
				logEmmc.AppendText(" Конец блока:\t\t- ", Color.White);
				needToBK = (Convert.ToInt64(startLBA) + Convert.ToInt64(sizeLBA)).ToString();
				logEmmc.AppendText(needToBK + "\n", Color.Yellow);
				logEmmc.AppendText(" Размер раздела:\t\t -", Color.White);
				long long_ = Convert.ToInt64(needToBK) * 512L;
				sizeByte = MyClass.Myfiles.SizeConvertor(long_);
				logEmmc.AppendText(sizeByte, Color.Yellow);
			}
		}

		private async void WaitForDumpEmmc()
		{
			if (dumpFinished)
			{
				lbl1.Text = " Dump Block0 finish ";
				timer1.Enabled = true;
				groupBox1.Enabled = true;
				btnBackup.Enabled = true;
				return;
			}
			await Task.Delay(SleepTimeForDump);
			string emmc = WorkingDir + "\\backup" + partition + "_eMMC.bin";
			if (File.Exists(emmc))
			{
				try
				{
					FileInfo fInfo = new FileInfo(emmc);
					string s = MyClass.Myfiles.SizeConvertor(fInfo.Length);
					lbl1.Text = " Finished " + s;
				}
				catch
				{
				}
			}
			WaitForDumpEmmc();
		}

		public void RedirectProcess(string string_0, string string_1)
		{
			Process process = new Process();
			ProcessStartInfo processStartInfo = new ProcessStartInfo();
			processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			processStartInfo.FileName = DC.emmcdl;
			processStartInfo.WorkingDirectory = string_1;
			processStartInfo.Arguments = string_0;
			Console.WriteLine(string_0);
			processStartInfo.RedirectStandardOutput = true;
			processStartInfo.UseShellExecute = false;
			processStartInfo.CreateNoWindow = true;
			process.StartInfo = processStartInfo;
			process.OutputDataReceived += p_OutputDataReceived;
			process.Start();
			process.BeginOutputReadLine();
			process.WaitForExit();
		}

		private void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
		{
			Console.WriteLine(e.Data);
			if (e.Data != null)
			{
				update2(e.Data);
				Console.WriteLine(e.Data);
			}
		}

		private void update(string string_0)
		{
			if (string_0.Contains("Sectors remaining"))
			{
				try
				{
					lbl2.Text = string_0;
				}
				catch
				{
				}
				return;
			}
			if (string_0.Contains("Status: 0 The operation completed successfully"))
			{
				lbl2.Text = "";
				btnBackup.Enabled = true;
				Thread.Sleep(1000);
			}
			Console.WriteLine(string_0);
		}

		private void bwDumpEmmc_DoWork(object sender, DoWorkEventArgs e)
		{
			dumpFinished = false;
			RedirectProcess(flashCommand, WorkingDir);
			dumpFinished = true;
		}

		private void bwDumpEmmc_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
		}

		private void bwDumpEmmc_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			btnBackup.Enabled = true;
		}

		private void txtStart_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
		}

		private void txtSize_KeyPress(object sender, KeyPressEventArgs e)
		{
			e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
		}

		public void update2(string string_0)
		{
			if (base.InvokeRequired)
			{
				Invoke(new Action<string>(update2), string_0);
			}
			else
			{
				logEmmc.Focus();
				logEmmc.AppendText(string_0 + Environment.NewLine);
			}
		}

		private async void timer1_Tick(object sender, EventArgs e)
		{
			await Task.Delay(200);
			label1.Show();
			await Task.Delay(800);
			label1.Hide();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbl1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnBackup = new System.Windows.Forms.Button();
            this.bwDumpEmmc = new System.ComponentModel.BackgroundWorker();
            this.logEmmc = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackgroundImage = global::QFlashTool.Properties.Resources.RadialGradient_horizontalOffset1;
            this.statusStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl1,
            this.lbl2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 431);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(814, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbl1
            // 
            this.lbl1.BackColor = System.Drawing.Color.Transparent;
            this.lbl1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(42, 17);
            this.lbl1.Text = "Status";
            // 
            // lbl2
            // 
            this.lbl2.Name = "lbl2";
            this.lbl2.Size = new System.Drawing.Size(0, 17);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.listView1);
            this.groupBox1.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.ForeColor = System.Drawing.Color.LawnGreen;
            this.groupBox1.Location = new System.Drawing.Point(19, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(436, 368);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Разделы";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(3, 342);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(429, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Нажмите на раздел, до которого вы хотите скопировать";
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.Gray;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView1.ForeColor = System.Drawing.Color.White;
            this.listView1.FullRowSelect = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(6, 24);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(422, 315);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Раздел";
            this.columnHeader1.Width = 90;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Начало блока";
            this.columnHeader2.Width = 97;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Конец блока";
            this.columnHeader3.Width = 142;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Размер";
            this.columnHeader4.Width = 155;
            // 
            // btnBackup
            // 
            this.btnBackup.BackColor = System.Drawing.Color.DimGray;
            this.btnBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackup.ForeColor = System.Drawing.Color.Lime;
            this.btnBackup.Location = new System.Drawing.Point(19, 386);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(436, 33);
            this.btnBackup.TabIndex = 3;
            this.btnBackup.Text = "Копировать всё";
            this.btnBackup.UseVisualStyleBackColor = false;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // bwDumpEmmc
            // 
            this.bwDumpEmmc.WorkerReportsProgress = true;
            this.bwDumpEmmc.WorkerSupportsCancellation = true;
            this.bwDumpEmmc.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwDumpEmmc_DoWork);
            this.bwDumpEmmc.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwDumpEmmc_ProgressChanged);
            this.bwDumpEmmc.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwDumpEmmc_RunWorkerCompleted);
            // 
            // logEmmc
            // 
            this.logEmmc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.logEmmc.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.logEmmc.ForeColor = System.Drawing.Color.Lime;
            this.logEmmc.Location = new System.Drawing.Point(472, 12);
            this.logEmmc.Name = "logEmmc";
            this.logEmmc.Size = new System.Drawing.Size(330, 407);
            this.logEmmc.TabIndex = 4;
            this.logEmmc.Text = "Ожидание команды";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(814, 453);
            this.Controls.Add(this.logEmmc);
            this.Controls.Add(this.btnBackup);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "eMMC Structure";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
	}
}
