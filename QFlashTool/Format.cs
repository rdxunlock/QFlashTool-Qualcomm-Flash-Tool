using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MPPG;

namespace QFlashTool
{
	public class Format : Form
	{
		private IContainer components = null;

		private RichTextBox LOG;

		private Label label1;

		private ComboBox comboBox1;

		private Button button1;

		private ComboBox comboBox2;

		private Label label2;

		private StatusStrip statusStrip1;

		private ToolStripStatusLabel lbl1;

		private System.Windows.Forms.Timer timer1;

		private BackgroundWorker bwConnect;

		private BackgroundWorker bwFormat;

		public string wkFirehose { get; private set; }

		public string wkSize { get; private set; }

		public bool firehoseOK { get; private set; }

		public Format()
		{
			InitializeComponent();
		}

		private void Format_Load(object sender, EventArgs e)
		{
			MyClass.Firehose.List.ForEach(delegate(string string_0)
			{
				comboBox1.Items.Add(string_0);
				comboBox1.Items.Add(string_0);
			});
			comboBox1.SelectedIndex = 0;
			comboBox2.SelectedIndex = 0;
		}

		private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
			wkSize = comboBox2.Text;
			wkSize = S3.LBA(wkSize);
		}

		private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			wkFirehose = comboBox1.Text;
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (button1.Text == "format")
			{
				LOG.Clear();
				LOG.AppendText("\n");
				LOG.AppendText(" Используем загрузчик:\t\t- ", Color.White);
				LOG.AppendText(comboBox1.Text + "\n", Color.Yellow);
				LOG.AppendText(" Размер раздела:\t\t- ", Color.White);
				LOG.AppendText(comboBox2.Text + "\n", Color.Yellow);
				LOG.AppendText(" Подключение к загрузчику:\t\t- ", Color.White);
				comboBox1.Enabled = false;
				comboBox2.Enabled = false;
				button1.Text = "cancel";
				timer1.Enabled = true;
			}
		}

		private void bwConnect_DoWork(object sender, DoWorkEventArgs e)
		{
			Usb.Detect();
		}

		private void bwConnect_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
		}

		private async void bwConnect_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (Usb.IsConnected)
			{
				timer1.Enabled = false;
				LOG.AppendText("Найден " + Usb.COM, Color.Yellow);
				lbl1.Text = Usb.Port;
				await Task.Delay(500);
				if (!bwFormat.IsBusy)
				{
					bwFormat.RunWorkerAsync();
				}
			}
		}

		private void FlashFirehose()
		{
			Thread thread = new Thread((ThreadStart)delegate
			{
				Process process = new Process();
				process.StartInfo.FileName = DC.emmcdl;
				process.StartInfo.CreateNoWindow = true;
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
				process.StartInfo.RedirectStandardOutput = true;
				process.StartInfo.RedirectStandardError = true;
				process.EnableRaisingEvents = false;
				process.StartInfo.Arguments = " -p " + Usb.COM + " -f data\\firehose\\" + wkFirehose;
				process.Start();
				process.WaitForExit(2000);
				string text = process.StandardOutput.ReadToEnd();
				if (text.Contains("Status: 0 The operation completed successfully"))
				{
					firehoseOK = true;
				}
				else
				{
					firehoseOK = false;
				}
			});
			thread.IsBackground = true;
			thread.Start();
			while (thread.IsAlive)
			{
				Application.DoEvents();
			}
		}

		public void formatMe(string string_0)
		{
			Process process = new Process();
			ProcessStartInfo processStartInfo = new ProcessStartInfo();
			processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			processStartInfo.FileName = DC.emmcdl;
			processStartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
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

		public void update2(string string_0)
		{
			if (base.InvokeRequired)
			{
				Invoke(new Action<string>(update2), string_0);
			}
			else
			{
				LOG.Focus();
				LOG.AppendText(string_0 + Environment.NewLine);
			}
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (!bwConnect.IsBusy)
			{
				bwConnect.RunWorkerAsync();
			}
		}

		private void bwFormat_DoWork(object sender, DoWorkEventArgs e)
		{
			formatMe(" -p " + Usb.COM + " -f data\\firehose\\" + wkFirehose + " -e 0 " + wkSize);
		}

		private void bwFormat_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
		}

		private void bwFormat_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			comboBox1.Enabled = true;
			comboBox2.Enabled = true;
			button1.Text = "format";
			LOG.Focus();
			LOG.AppendText(" Успешно форматирован от 0 до " + wkSize + " LBA", Color.White);
		}

		private void Format_FormClosing(object sender, FormClosingEventArgs e)
		{
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Format));
            this.LOG = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbl1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bwConnect = new System.ComponentModel.BackgroundWorker();
            this.bwFormat = new System.ComponentModel.BackgroundWorker();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LOG
            // 
            this.LOG.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LOG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.LOG.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LOG.ForeColor = System.Drawing.Color.LightSteelBlue;
            this.LOG.Location = new System.Drawing.Point(12, 12);
            this.LOG.Name = "LOG";
            this.LOG.Size = new System.Drawing.Size(421, 224);
            this.LOG.TabIndex = 0;
            this.LOG.Text = "ааа";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Загрузчик";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 260);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comboBox1.Size = new System.Drawing.Size(187, 21);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(162, 290);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 34);
            this.button1.TabIndex = 3;
            this.button1.Text = "Форматировать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "512MB",
            "1GB",
            "1.5GB",
            "2GB",
            "3GB",
            "4GB",
            "5GB",
            "6GB",
            "7GB",
            "8GB"});
            this.comboBox2.Location = new System.Drawing.Point(257, 260);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.comboBox2.Size = new System.Drawing.Size(176, 21);
            this.comboBox2.TabIndex = 4;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(349, 239);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(84, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "eMMC Size";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 327);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(446, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbl1
            // 
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(0, 17);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bwConnect
            // 
            this.bwConnect.WorkerReportsProgress = true;
            this.bwConnect.WorkerSupportsCancellation = true;
            this.bwConnect.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwConnect_DoWork);
            this.bwConnect.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwConnect_ProgressChanged);
            this.bwConnect.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwConnect_RunWorkerCompleted);
            // 
            // bwFormat
            // 
            this.bwFormat.WorkerReportsProgress = true;
            this.bwFormat.WorkerSupportsCancellation = true;
            this.bwFormat.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwFormat_DoWork);
            this.bwFormat.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwFormat_ProgressChanged);
            this.bwFormat.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwFormat_RunWorkerCompleted);
            // 
            // Format
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(446, 349);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LOG);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Format";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "eMMC Format";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Format_FormClosing);
            this.Load += new System.EventHandler(this.Format_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
    }
}
