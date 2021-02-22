using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MPPG;
using QFlashTool.Properties;
using Telecom;

namespace QFlashTool
{
	public class M : Form
	{
		private string wkDir = "";

		private F4 fhloader = new F4();

		private _9006 _9006Class = new _9006();

		public static SoundPlayer error;

		public SoundPlayer click = new SoundPlayer(Resources.click);

		public SoundPlayer info = new SoundPlayer(Resources.info);

		private SoundPlayer shutter = new SoundPlayer(Resources.New_shutter);

		public static bool isFirmwareBackupConfirmed;

		public static string quote;

		private static string wkFile;

		private static string wkFirehose;

		private static string wkPartition;

		public string MAIN_THREAD;

		public string nline = Environment.NewLine;

		public string bootloaderimage;

		public string fastbootimage;

		public static M _F1;

		private static List<string> line;

		private static string llll;

		private string SendCommand;

		public static string EmmcForExtract;

		private static string model;

		private string flashCommand;

		private string ssss;

		private static string string_0;

		private IContainer components = null;

		private StatusStrip statusStrip1;

		private Button btnEmmcSelect;

		public TextBox txtEmmc;

		public BackgroundWorker bwDownload_eMMC;

		private GroupBox groupBoxBlock0Write;

		private Label label4;

		private ComboBox FirehoseSels;

		private Label label3;

		private GroupBox groupBoxBlock0Read;

		private Button btnDumpEmmc;

		public BackgroundWorker bwMain;

		public BackgroundWorker bwFlashDload;

		private Button btnDownloadBoardFirmware;

		private TextBox textBox1;

		private ListView listViewBackupRestore;

		private ColumnHeader columnHeader1;

		private ColumnHeader columnHeader2;

		private Button btnDoJobForBackupRestore;

		public BackgroundWorker bwFlashFile;

		public BackgroundWorker bwEmmcdl;

		private BackgroundWorker backgroundWorker1;

		private CheckBox checkBoxBackupAll;

		private MenuStrip menuStrip1;

		private ToolStripMenuItem mainToolStripMenuItem;

		private ToolStripMenuItem helpToolStripMenuItem;

		private ToolStripMenuItem guideToolStripMenuItem;

		private ToolStripMenuItem aboutMeToolStripMenuItem;

		private GroupBox groupBoxDloadFlasher;

		private GroupBox groupBoxBoardFirmware;

		private GroupBox groupBoxBootloaerUnlock;

		private Label label10;

		private Button btnBootloaderUnlock;

		private GroupBox groupBoxFirmwareWrite;

		private Button btnDownloadXML;

		private Button btnPath;

		private Button btnRawprogram0;

		private TextBox txt_patch0;

		private TextBox txt_rawprogram0;

		private Label label11;

		private Label label12;

		private GroupBox groupBoxFirmwareRead;

		private Button btnBackupFirmware;

		private System.Windows.Forms.Timer tmWait;

		private ListView listViewEmmc;

		private ColumnHeader columnHeader3;

		private ColumnHeader columnHeader4;

		private ColumnHeader columnHeader5;

		private ColumnHeader columnHeader6;

		private GroupBox groupBoxEmmc;

		private Button btnBrowseEmmc;

		private TextBox txtEmmcLoad;

		private StatusStrip statusStrip3;

		private ToolStripStatusLabel lblPartition;

		private ColumnHeader columnHeader7;

		private Button btnEmmcToFirmware;

		private BackgroundWorker bwFirmwareMaker;

		public ComboBox cbBootloaderUnlock;

		private GroupBox groupBox_0;

		private Button btnRepairOEM;

		private ComboBox comboBox_0;

		private Button btnFlashEmmcToDevice;

		private Button btnExtractFirmwareFromEmmc;

		private ToolStripMenuItem huaweiToolStripMenuItem;

		private ToolStripMenuItem boardFirmwareToolStripMenuItem;

		private ToolStripMenuItem boardFirmwareCreateToolStripMenuItem;

		private ToolStripMenuItem dloadFlasherToolStripMenuItem;

		private ToolStripMenuItem bootloaderUnlockToolStripMenuItem;

		private ToolStripMenuItem networkUnlockToolStripMenuItem;

		private ToolStripMenuItem qualcommToolStripMenuItem;

		private ToolStripMenuItem block0BackupToolStripMenuItem;

		private ToolStripMenuItem block0FlasherToolStripMenuItem;

		private ToolStripMenuItem firmwareToolStripMenuItem;

		private ToolStripMenuItem readToolStripMenuItem;

		private ToolStripMenuItem writeToolStripMenuItem;

		private ToolStripMenuItem eMMCToolStripMenuItem;

		private GroupBox groupBoxReboot;

		private GroupBox groupBoxN_Reboot;

		private Button btnNormalReboot;

		private GroupBox groupBox_1;

		private Button btnEDL;

		private GroupBox groupBox9006;

		private Label label13;

		private Button btn9008To9006;

		private ComboBox comboBox9008To9006;

		private BackgroundWorker bw_WriteFirmware;

		public ToolStripStatusLabel lbl1;

		private ColumnHeader columnHeader8;

		private ColumnHeader columnHeader9;

		private ImageList imageList1;

		private ImageList imageList2;

		private ToolStripMenuItem exitToolStripMenuItem;

		private ImageList imageList3;

		private Button btnDownloadDload;

		private Button button2;

		private Button btnEmmcDownloadFast;

		private ColumnHeader columnHeader10;

		private CheckBox cBoxAuto1;

		private RadioButton rbWrite;

		private RadioButton rbFormat;

		private RadioButton rbBackup;

		private RadioButton rbScan;

		private BackgroundWorker bw_WritePatch0;

		private TabControl tabControl5;

		private TabPage tabPage8;

		private TabPage tabPage9;

		private ImageList imageSmall;

		private RichTextBox help;

		private Button button1;

		private TextBox txtDload;

		private Label label7;

		public TextBox txtEmmcSaveLocation;

		private Button button3;

		private Button btnCreateBoard;

		private GroupBox groupBox_2;

		private Label label9;

		public TextBox textBox_0;

		private Button button4;

		private Button btnWrite9006;

		private Button button_0;

		private ComboBox comboBox_1;

		private RichTextBox richTextBoxMMC;

		private BackgroundWorker bw_Write9006;

		private Button btnAdbRead;

		private BackgroundWorker bwReadAdb;

		private ComboBox comboBox2;

		private Button btnSplit;

		private ToolStripMenuItem cleanerToolStripMenuItem;

		private ToolStripMenuItem cleanAdbToolStripMenuItem;

		private ToolStripMenuItem cleanQualcommServiceToolStripMenuItem;

		private ToolStripMenuItem cleanAllToolStripMenuItem;

		private ToolStripMenuItem deviceManagerToolStripMenuItem;

		private GroupBox groupBoxREBOOTER;

		private RadioButton rnormal;

		private RadioButton rbootloader;

		private RadioButton r9008;

		private RadioButton r9006;

		private Button buttonReboot;

		public RichTextBox LOG;

		public Label label1;

		public ProgressBar pBar;

		private Button button5;

		private RadioButton radioButton3;

		private RadioButton radioButton2;

		private RadioButton radioButton1;

		private CheckBox checkBox1;

		private Label label15;

		private ComboBox comboBox3;

		private GroupBox groupBox2;

		private Button button6;

		public Label lblActivated;

		private Label label18;

		private Label label17;
        private Label label6;
        private Button button7;
        private Panel q1;
        private Button button8;
        private Button button9;
        private Panel q2;
        private GroupBox groupBoxBackupRestore;
        private Label label5;
        private Panel q3;
        private Button button10;
        private ProgressBar pBarEmmcDump;
        private Panel panel1;
        private Panel q4;
        private Panel q5;
        private Button button12;
        private Label label19;

		public string Comport => Usb.COM;

		public string WorkingDir
		{
			get
			{
				if (wkDir == "")
				{
					wkDir = Directory.GetCurrentDirectory();
				}
				return wkDir;
			}
		}

		public string wkCommand { get; private set; }

		public string rawprogram0XML { get; private set; }

		public string String_0 { get; private set; }

		public bool isFound { get; private set; }

		public bool firehoseOK { get; private set; }

		public static string WorkingFile => wkFile;

		public static string WorkingFirehose => wkFirehose;

		public static string WorkingPartition => wkPartition;

		public static string time
		{
			get
			{
				DateTime now = DateTime.Now;
				return (" " + now.Hour + ":" + now.Minute + ":" + now.Second).ToString();
			}
		}

		public static string Setfastbootimage
		{
			get
			{
				M m = new M();
				return m.fastbootimage;
			}
		}

		public List<string> Bootloaderimage_fileslist
		{
			get
			{
				List<string> list = new List<string>();
				DirectoryInfo directoryInfo = new DirectoryInfo(bootloaderimage);
				FileInfo[] array = null;
				array = directoryInfo.GetFiles();
				FileInfo[] array2 = array;
				foreach (FileInfo fileInfo in array2)
				{
					list.Add(fileInfo.Name);
				}
				return list;
			}
		}

		public List<string> All_Pertitions
		{
			get
			{
				List<string> list = new List<string>();
				if (listViewBackupRestore.Items.Count > 0)
				{
					foreach (ListViewItem item in listViewBackupRestore.Items)
					{
						list.Add(item.SubItems[1].Text);
					}
					return list;
				}
				return list;
			}
		}

		public static string Model => model;

		public int SleepTimeForFlash
		{
			get
			{
				int sizeOfFlash = SizeOfFlash;
				return NewMethod(1000, sizeOfFlash);
			}
		}

		public int SizeOfFlash
		{
			get
			{
				FileInfo fileInfo = new FileInfo(WorkingFile);
				string value = (fileInfo.Length / 6291456L).ToString();
				return Convert.ToInt32(value);
			}
		}

		public int SizeOfDump
		{
			get
			{
				long num = Convert.ToInt64(MyClass.eMMC.Size) * 512L;
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
					return sizeOfDump * num2 / 130;
				}
				return 800;
			}
		}

		public static string SafeNameOf(string string_1)
		{
			if (!File.Exists(string_1))
			{
				return "";
			}
			new FileInfo(string_1);
			return Path.GetFileName(string_1);
		}

		private void listViewBackupRestore_SelectedIndexChanged(object sender, EventArgs e)
		{
			foreach (ListViewItem selectedItem in listViewBackupRestore.SelectedItems)
			{
				wkPartition = selectedItem.SubItems[1].Text;
				lbl1.Text = WorkingPartition;
				LOG.Clear();
				LOG.AppendText(" Имя раздела:\t\t", Color.White);
				LOG.AppendText(selectedItem.SubItems[1].Text + Environment.NewLine);
				LOG.AppendText(" Начало блока:\t\t", Color.White);
				LOG.AppendText(selectedItem.SubItems[2].Text + Environment.NewLine);
				LOG.AppendText(" Конец блока:\t\t\t", Color.White);
				LOG.AppendText(selectedItem.SubItems[3].Text + Environment.NewLine);
				LOG.AppendText(" Размер:\t\t", Color.White);
				LOG.AppendText(selectedItem.SubItems[4].Text + Environment.NewLine);
			}
		}

		private void comboBoxFirehose2_SelectedIndexChanged(object sender, EventArgs e)
		{
			wkFirehose = "data\\firehose\\" + FirehoseSels.Text;
		}

		private void listViewEmmc_SelectedIndexChanged(object sender, EventArgs e)
		{
			click.Play();
			foreach (ListViewItem selectedItem in listViewEmmc.SelectedItems)
			{
				lblPartition.Text = selectedItem.SubItems[1].Text + "   " + selectedItem.SubItems[2].Text + "   " + selectedItem.SubItems[3].Text;
				LOG.Clear();
				LOG.AppendText("\n Раздел\t\t", Color.White);
				LOG.AppendText(selectedItem.SubItems[1].Text + Environment.NewLine);
				LOG.AppendText(" Начало\t\t", Color.White);
				LOG.AppendText(selectedItem.SubItems[2].Text + Environment.NewLine);
				LOG.AppendText(" Размер\t\t", Color.White);
				LOG.AppendText(selectedItem.SubItems[3].Text + Environment.NewLine);
			}
		}

		private void comboBoxFirehose1_SelectedIndexChanged(object sender, EventArgs e)
		{
			info.Play();
			wkFirehose = "data\\firehose\\" + FirehoseSels.Text;
			LOG.Clear();
			LOG.AppendText("\n");
			LOG.AppendText(" Выбранный загрузчик :\t\t" + FirehoseSels.Text + Environment.NewLine);
		}

		private void comboBoxOEM_SelectedIndexChanged(object sender, EventArgs e)
		{
			info.Play();
		}

		private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
		{
			info.Play();
		}

		private void tabControl3_SelectedIndexChanged(object sender, EventArgs e)
		{
			info.Play();
		}

		private void FirehoseSels_SelectedIndexChanged(object sender, EventArgs e)
		{
			info.Play();
		}

		private void comboBox9008To9006_SelectedIndexChanged(object sender, EventArgs e)
		{
			info.Play();
		}

		public M()
		{
			InitializeComponent();
			_F1 = this;
		}

		public static void Rename(string string_1, string string_2)
		{
			if (File.Exists(string_1))
			{
				FileInfo fileInfo = new FileInfo(string_1);
				try
				{
					fileInfo.MoveTo(fileInfo.Directory.FullName + "\\" + string_2);
				}
				catch
				{
					error.Play();
				}
			}
		}

		private void Main_Load(object sender, EventArgs e)
		{
			MyClass.Start();
			St();
		}

		private void St()
		{
			MyClass.Firehose.List.ForEach(delegate(string string_1)
			{
				FirehoseSels.Items.Add(string_1);
			});
			if (Directory.Exists("data\\9006"))
			{
				DirectoryInfo directoryInfo = new DirectoryInfo("data\\9006");
				if (directoryInfo.Exists)
				{
					DirectoryInfo[] directories = directoryInfo.GetDirectories();
					DirectoryInfo[] array = directories;
					foreach (DirectoryInfo directoryInfo2 in array)
					{
						comboBox9008To9006.Items.Add(directoryInfo2.Name);
					}
					comboBox9008To9006.SelectedIndex = 0;
				}
			}
		}

		private void Main_FormClosing(object sender, FormClosingEventArgs e)
		{
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
				process.StartInfo.Arguments = " -p " + Usb.COM + " -f " + WorkingFirehose;
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

		private void textBox1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			using FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			DialogResult dialogResult = folderBrowserDialog.ShowDialog();
			if (dialogResult != DialogResult.OK || string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
			{
				return;
			}
			LOG.Clear();
			string selectedPath = folderBrowserDialog.SelectedPath;
			textBox1.Text = selectedPath;
			string[] directories = Directory.GetDirectories(folderBrowserDialog.SelectedPath);
			if (directories.Count() == 0)
			{
				LOG.AppendText("");
				LOG.AppendText("   \u1031ရ\u103c\u1038ခ\u103aယ\u1039ထ\u102c\u1038တ\u1032႔ ဖ\u102d\u102fဒ\u102bထ\u1032မ\u103d\u102c ဘ\u102cဖ\u102d\u102fဒ\u102bမ\u103d မ\u1031တ\u103c႕ရပ\u102b");
				return;
			}
			string[] array = directories;
			foreach (string text in array)
			{
				if (text.Contains("bootloaderimage"))
				{
					bootloaderimage = text;
				}
				if (text.Contains("fastbootimage"))
				{
					fastbootimage = text;
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			click.Play();
			using FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			DialogResult dialogResult = folderBrowserDialog.ShowDialog();
			if (dialogResult != DialogResult.OK || string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
			{
				return;
			}
			LOG.Clear();
			string selectedPath = folderBrowserDialog.SelectedPath;
			textBox1.Text = selectedPath;
			string[] directories = Directory.GetDirectories(folderBrowserDialog.SelectedPath);
			if (directories.Count() == 0)
			{
				LOG.AppendText("");
				LOG.AppendText("   \u1031ရ\u103c\u1038ခ\u103aယ\u1039ထ\u102c\u1038တ\u1032႔ ဖ\u102d\u102fဒ\u102bထ\u1032မ\u103d\u102c ဘ\u102cဖ\u102d\u102fဒ\u102bမ\u103d မ\u1031တ\u103c႕ရပ\u102b");
				return;
			}
			string[] array = directories;
			foreach (string text in array)
			{
				if (text.Contains("bootloaderimage"))
				{
					bootloaderimage = text;
				}
				if (text.Contains("fastbootimage"))
				{
					fastbootimage = text;
				}
			}
		}

		private void btnDownloadBoardFirmware_Click(object sender, EventArgs e)
		{
			click.Play();
			LOG.Clear();
			if (!DC.CheckOk())
			{
				LOG.Clear();
				LOG.AppendText("\n Дополнение не найдено \n Установите Python 2.7+\n");
			}
			else
			{
				W_Bord();
			}
		}

		private async void W_Bord()
		{
			if (!Directory.Exists(textBox1.Text))
			{
				LOG.AppendText("Выберите правильную сервисную прошивку Huawei\t\t", Color.White);
				LOG.AppendText("Ошибка (FileInCor)\n", Color.Red);
				return;
			}
			LOG.Clear();
			if (bootloaderimage == null || fastbootimage == null)
			{
				return;
			}
			string mMPRG = M2.Name(bootloaderimage);
			string mMSIMAGE = M4.Name(bootloaderimage);
			LOG.AppendText(" Папка загрузчиков : \t\t", Color.White);
			await Task.Delay(500);
			LOG.AppendText(bootloaderimage + nline, Color.Yellow);
			await Task.Delay(500);
			LOG.AppendText(" Выбран MPRG : \t\t\t", Color.White);
			await Task.Delay(500);
			LOG.AppendText(mMPRG + nline, Color.Yellow);
			await Task.Delay(500);
			LOG.AppendText(" Выбрано Msi образ : \t\t", Color.White);
			await Task.Delay(500);
			LOG.AppendText(mMSIMAGE + nline, Color.Yellow);
			await Task.Delay(500);
			D2.Detect();
			if (D2.IsinFastboot)
			{
				LOG.AppendText("Устройство в fastboot режиме\n");
				TryToFlashFastbootImages();
				return;
			}
			LOG.AppendText(" Поиск устройств:\t\t- ", Color.White);
			isFound = false;
			DisableAll();
			ConnectEdl();
			if (!isFound)
			{
				Enableall();
				return;
			}
			LOG.AppendText("Устройство найдено:\n");
			wkFirehose = Calculate.firehose();
			LOG.AppendText(" Процессор:\t\t", Color.White);
			LOG.AppendText(M3.id + Environment.NewLine);
			LOG.AppendText(" Порт обноружения:\t\t", Color.White);
			LOG.AppendText(" Шаг 1 : Загрузка загрузчика " + nline);
			wkDir = bootloaderimage;
			string s1 = "emmcdl   -p " + Comport + " -f " + mMPRG + " -i " + mMSIMAGE;
			string s2 = "emmcdl    -p " + Comport + " -f " + mMPRG + " -r ";
			SendCommand = s1 + " && " + s2;
			wkDir = bootloaderimage;
			if (!bwMain.IsBusy)
			{
				bwMain.RunWorkerAsync();
			}
			int i = 1;
			do
			{
				await Task.Delay(245);
				if (!CMD.GetFinish)
				{
					lbl1.Text = " downloading bootloader " + i++ + " % ";
					lbl1.Image = Resources.loading;
				}
			}
			while (!CMD.GetFinish);
			LOG.AppendText(" Поиск устройства (Fastboot):\t");
			lbl1.Text = " download bootloader Finish";
			TryToFlashFastbootImages();
			info.Play();
		}

		private async void TryToFlashFastbootImages()
		{
			Thread wait = new Thread((ThreadStart)delegate
			{
				int num = 20;
				while (true)
				{
					if (num < 0)
					{
						return;
					}
					D2.Detect();
					Thread.Sleep(1000);
					if (D2.IsinFastboot)
					{
						this.info.Play();
						return;
					}
					if (num == 0)
					{
						break;
					}
					num--;
				}
				update(" timout" + nline);
			});
			wait.IsBackground = true;
			wait.Start();
			while (wait.IsAlive)
			{
				Application.DoEvents();
			}
			LOG.AppendText("Устройство найдено: " + nline);
			LOG.AppendText(" (Fastboot) образ::\t\t-", Color.White);
			await Task.Delay(500);
			LOG.AppendText(fastbootimage + nline);
			wkDir = fastbootimage;
			DirectoryInfo di = new DirectoryInfo(WorkingDir);
			WriteFastboot(" flash partition  gpt_both0.bin");
			LOG.AppendText(" Прошивка раздела:" + nline);
			lbl1.Text = "flashing gpt";
			lbl1.Image = Resources.loading;
			llll = "";
			FileInfo[] fi = di.GetFiles();
			List<string> local = new List<string>();
			FileInfo[] array = fi;
			foreach (FileInfo info in array)
			{
				if (!(info.Extension == ".img") && !(info.Extension == ".mbn") && !(info.Extension == ".bin"))
				{
					continue;
				}
				string file = info.Name;
				string partition = Path.GetFileNameWithoutExtension(info.Name);
				if (partition == "emmc_appsboot")
				{
					partition = "aboot";
				}
				if (partition == "NON-HLOS")
				{
					partition = "modem";
				}
				if (partition == "modem_st1")
				{
					partition = "modemst1";
				}
				if (partition == "modem_st2")
				{
					partition = "modemst2";
				}
				if (partition == "gpt_both0")
				{
					partition = "partition";
				}
				if (partition == "fs_image.tar.gz.mbn")
				{
					partition = "fsg";
				}
				local.Add(partition);
				if ((partition != "partition") & (partition != "log"))
				{
					LOG.Focus();
					LOG.AppendText(" Прошивка: : ", Color.Red);
					LOG.AppendText(partition + Environment.NewLine, Color.WhiteSmoke);
					lbl1.Text = " flash " + partition;
					Thread thr = new Thread((ThreadStart)delegate
					{
						WriteFastboot("   erase   " + partition);
						WriteFastboot("   flash   " + partition + " " + file);
					});
					thr.IsBackground = true;
					thr.Start();
					while (thr.IsAlive)
					{
						Application.DoEvents();
					}
					LOG.Focus();
					LOG.AppendText(llll + Environment.NewLine);
					llll = "";
				}
			}
			WriteFastboot(" flash log   log.img");
			LOG.AppendText(llll + Environment.NewLine);
			llll = "";
			WriteFastboot("reboot");
			LOG.AppendText(llll + Environment.NewLine);
			llll = "";
			lbl1.Text = " All Done";
			lbl1.Image = Resources.blocked_usb;
			btnDownloadBoardFirmware.Enabled = true;
			Enableall();
		}

		public void WriteFastboot(string string_1)
		{
			Process process = new Process();
			process.StartInfo.FileName = DC.fastboot;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.WorkingDirectory = WorkingDir;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.RedirectStandardError = true;
			process.ErrorDataReceived += WriteFastbootDataReceiver;
			process.StartInfo.Arguments = string_1;
			process.Start();
			process.BeginErrorReadLine();
			string value = process.StandardOutput.ReadToEnd();
			process.WaitForExit();
			Console.WriteLine(value);
		}

		private void WriteFastbootDataReceiver(object sender, DataReceivedEventArgs e)
		{
			Console.WriteLine(e.Data);
			if (e.Data != null)
			{
				llll = llll + e.Data + Environment.NewLine;
				Console.WriteLine(e.Data);
			}
		}

		private void WriteFastboot0updater(string string_1)
		{
			if (string_1 != "")
			{
				try
				{
					llll = string_1;
					List<string> list = new List<string>();
					list.Add(string_1);
					LOG.AppendText(list[0] + "\r\n");
				}
				catch
				{
					Enableall();
				}
			}
		}

		private void aboutPremiumToolToolStripMenuItem_Click(object sender, EventArgs e)
		{
			click.Play();

		}

		private void bwMain_DoWork(object sender, DoWorkEventArgs e)
		{
			CMD.General(SendCommand, WorkingDir);
		}

		private void bwMain_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
		}

		private void bwMain_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
		}

		private void btnDoJobForBackupRestore_Click(object sender, EventArgs e)
		{
			click.Play();
			if (checkBox1.Checked)
			{
				Format format = new Format();
				format.ShowDialog();
			}
			if (!DC.CheckOk())
			{
				LOG.Clear();
				LOG.AppendText("\n Дополнение не найдено \n Установите Python 2.7+\n");
				return;
			}
			LOG.Clear();
			if (rbScan.Checked)
			{
				PartitionsScan();
			}
			else if (rbBackup.Checked)
			{
			DoJobBackup();
			}
			else if (rbFormat.Checked)
			{
			DoJobFormat();
			} else {
			DoJobRestore();
			}
		}

		private async void PartitionsScan()
		{
			LOG.Clear();
			LOG.AppendText(" Поиск устройств:\t\t- ", Color.White);
			isFound = false;
			ConnectEdl();
			if (!isFound)
			{
				Enableall();
				Process.Start("taskkill", "/F /IM dload.exe");
				return;
			}
			LOG.AppendText("Устройство найдено:\n");
			wkFirehose = Calculate.firehose();
			LOG.AppendText(" Процессор:\t\t", Color.White);
			LOG.AppendText(M3.id + Environment.NewLine);
			LOG.AppendText(" Порт обноружения:\t\t", Color.White);
			LOG.AppendText(Usb.Port + Environment.NewLine);
			LOG.AppendText(" Процессор :\t" + M3.id + Environment.NewLine);
			LOG.AppendText(" Информация :\t\t" + M3.O + Environment.NewLine);
			await Task.Delay(500);
			listViewBackupRestore.Items.Clear();
			if (cBoxAuto1.Checked)
			{
				wkFirehose = Calculate.firehose();
			}
			else
			{
				if (FirehoseSels.Text == "")
				{
					LOG.AppendText(" Выберите загрузчик\n");
					Enableall();
					return;
				}
				wkFirehose = "data\\firehose\\" + FirehoseSels.Text;
			}
			LOG.AppendText(" Подключение к загрузчику: \t\t", Color.White);
			lbl1.Image = Resources.loading;
			firehoseOK = false;
			FlashFirehose();
			if (!firehoseOK)
			{
				LOG.AppendText("Ошибка (ConnectDeviceError or DeviceRefusedConnection)\n Возможно вы выбрали неверный загрузчик.\nУстройство не может загрузиться с него\t\t", Color.Yellow);
				Process.Start("taskkill", "/F /IM dload.exe");
				LOG.AppendText("Ошибка (NotFoundDevice)\n", Color.Red);
				LOG.AppendText("Связь с загрузчиком устройством потеряна, переустановите соеденение\t\t", Color.White);
				LOG.AppendText("Ошибка (NoInitState)\n", Color.Red);
				Enableall();
				return;
			}
			LOG.AppendText("Успешно\n");
			LOG.AppendText("Завершенно:" + nline);
			lbl1.Text = "process pass";
			lbl1.Image = Resources.allowed_usb;
			List<string> local = M3.getGPT(Usb.COM, WorkingFirehose);
			if (local != null)
			{
				foreach (string line in local)
				{
					if (line != "")
					{
						string[] partitions = line.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
						string number = partitions[0];
						string par = partitions[3];
						string start = partitions[6];
						string size = partitions[10];
						string end = (Convert.ToInt32(start) + Convert.ToInt32(size)).ToString();
						long sizeInlong = Convert.ToInt64(size) * 512L;
						string sizeByte = MyClass.Myfiles.SizeConvertor(sizeInlong);
						ListViewItem lvi = new ListViewItem(number)
						{
							SubItems = { par, start, end, sizeByte }
						};
						listViewBackupRestore.Items.Add(lvi);
					}
				}
			}
			while (true)
			{
				label5.Text = "Click on  partition which you want to Do Job";
				await Task.Delay(2000);
				label5.Text = "";
			}
		}

		private void DoJobRestore()
		{
			if (listViewBackupRestore.Items.Count == 0)
			{
				LOG.AppendText("Список разделов пуст, загрузите список раздела с телефона\t\t");
				LOG.AppendText("Ошибка (PartListNotLoaded)\n", Color.Red);
				return;
			}
			if (listViewBackupRestore.SelectedItems.Count == 0)
			{
				LOG.AppendText("Выберите раздел\t\t");
				LOG.AppendText("Ошибка (PartNotSel)\n", Color.Red);
				return;
			}
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Select your " + WorkingPartition + " file..";
			openFileDialog.Filter = "image files (*.img)|*.img|All files (*.*)|*.*";
			openFileDialog.CheckFileExists = true;
			openFileDialog.RestoreDirectory = true;
			openFileDialog.CheckPathExists = true;
			openFileDialog.FilterIndex = 2;
			openFileDialog.RestoreDirectory = true;
			if (openFileDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			wkFirehose = "data\\firehose\\" + FirehoseSels.Text;
			try
			{
				if (openFileDialog.OpenFile() != null)
				{
					LOG.Clear();
					_ = openFileDialog.FileName;
					wkFile = "\"" + openFileDialog.SafeFileName + "\"";
					wkDir = Path.GetDirectoryName(openFileDialog.FileName);
					if (!(WorkingFirehose != ""))
					{
						wkFirehose = "data\\firehose\\" + FirehoseSels.Text;
					}
					LOG.AppendText(" Прошивка::\t\t" + WorkingPartition);
					lbl1.Image = Resources.loading;
					Thread thread = new Thread((ThreadStart)delegate
					{
						string text = " -p " + Usb.COM + " -f " + WorkingFirehose + " -b " + WorkingPartition + " " + WorkingFile;
						Process process = new Process();
						ProcessStartInfo processStartInfo = new ProcessStartInfo
						{
							WindowStyle = ProcessWindowStyle.Hidden,
							FileName = DC.emmcdl,
							WorkingDirectory = WorkingDir,
							Arguments = text
						};
						Console.WriteLine(text);
						processStartInfo.RedirectStandardOutput = true;
						processStartInfo.UseShellExecute = false;
						processStartInfo.CreateNoWindow = true;
						process.StartInfo = processStartInfo;
						process.Start();
						StreamReader standardOutput = process.StandardOutput;
						standardOutput.ReadToEnd();
						process.WaitForExit();
						standardOutput.Close();
					});
					thread.IsBackground = true;
					thread.Start();
					while (thread.IsAlive)
					{
						groupBoxBackupRestore.Enabled = false;
						Application.DoEvents();
					}
					LOG.AppendText("\nЗавершено\n", Color.White);
					lbl1.Text = " flash finished";
					lbl1.Image = Resources.allowed_usb;
					groupBoxBackupRestore.Enabled = true;
				}
			}
			catch
			{
				Enableall();
				LOG.AppendText("Не удаётся прочитать файл (FileInCorData or FileNotFoun) ");
			}
		}

		private async void DoJobFormat()
		{
			if (listViewBackupRestore.Items.Count == 0)
			{
				LOG.AppendText("Список разделов пуст, загрузите список раздела с телефона\t\t");
				LOG.AppendText("Ошибка (PartNotLoaded)\n", Color.Red);
				return;
			}
			if (listViewBackupRestore.SelectedItems.Count == 0)
			{
				LOG.AppendText("Выберите раздел\t\t");
				LOG.AppendText("Ошибка (PartNotSel)\n", Color.Red);
				return;
			}
			groupBoxBackupRestore.Enabled = false;
			LOG.AppendText(" Formating " + WorkingPartition + Environment.NewLine);
			SendCommand = DC.emmcdl + "  -p " + Comport + " -f " + WorkingFirehose + " -e " + WorkingPartition;
			lbl1.Text = " formating " + WorkingPartition;
			if (!bwEmmcdl.IsBusy)
			{
				bwEmmcdl.RunWorkerAsync();
			}
			do
			{
				await Task.Delay(500);
			}
			while (!CMD.GetFinish);
			LOG.AppendText("Завершенно:" + Environment.NewLine);
			lbl1.Text = "DONE";
			lbl1.Image = Resources.allowed_usb;
			groupBoxBackupRestore.Enabled = true;
			info.Play();
		}
		private string fullsize = "null";
		private async void DoJobBackup()
		{
			if (listViewBackupRestore.Items.Count == 0)
			{
				LOG.AppendText("Список разделов пуст, загрузите список раздела с телефона\n", Color.White);
				LOG.AppendText("Ошибка (PartNotLoaded)\n", Color.Red);
				return;
			}
			using (FolderBrowserDialog fbd = new FolderBrowserDialog())
			{
				DialogResult result = fbd.ShowDialog();
				if (result != DialogResult.OK || string.IsNullOrWhiteSpace(fbd.SelectedPath))
				{
					return;
				}
				LOG.Clear();
				wkDir = fbd.SelectedPath;
				Qualcomm.EMMCDL.SetDir = WorkingDir;
			}
			if (checkBoxBackupAll.Checked && All_Pertitions.Count > 0)
			{
				string local_port = Usb.COM;
				foreach (string str in All_Pertitions)
				{
					string backup_file2 = str;
					backup_file2 = Qualcomm.partition(backup_file2);
					fullsize = MyClass.Myfiles.SizeConvertor(backup_file2.Length);
					lbl1.Text = " Backing up : " + str;
					lbl1.Image = Resources.loading;
					SendCommand = "dependencies\\emmcdl  -p " + local_port + " -f " + WorkingFirehose + " -d " + str + " -o \"" + WorkingDir + "\\" + backup_file2 + "\"";
					CMD.SetFinish = false;
					LOG.Focus();
					if (!bwEmmcdl.IsBusy)
					{
						bwEmmcdl.RunWorkerAsync();
					}
					while (true)
					{
						await Task.Delay(1000);
						if (!CMD.GetFinish)
						{
							if (File.Exists(WorkingDir + "\\" + backup_file2))
							{
								FileInfo backup_fileInfo = new FileInfo(WorkingDir + "\\" + backup_file2);
								string size2 = MyClass.Myfiles.SizeConvertor(backup_fileInfo.Length);
								lbl1.Text = " " + size2 + " completed ";
							}
							continue;
						}
						break;
					}
					lbl1.Text = " Backup finished";
					lbl1.Image = Resources.allowed_usb;
					Qualcomm.SetDefault();
					info.Play();
				}
				groupBoxBackupRestore.Enabled = true;
				Enableall();
				return;
			}
			foreach (ListViewItem lvi in listViewBackupRestore.SelectedItems)
			{
				wkPartition = lvi.SubItems[1].Text;
			}
			wkFile = wkPartition;
			if (wkFile == "aboot")
			{
				wkFile = "emmc_appsboot.mbn";
			}
			else if (wkFile == "hyp")
			{
				wkFile = "hyp.mbn";
			}
			else if (wkFile == "tz")
			{
				wkFile = "tz.mbn";
			}
			else if (wkFile == "oeminfo")
			{
				wkFile = "oeminfo.mbn";
			}
			else if (wkFile == "sbl1")
			{
				wkFile = "sbl1.mbn";
			}
			else if (wkFile == "sdi")
			{
				wkFile = "sdi.mbn";
			}
			else if (wkFile == "rpm")
			{
				wkFile = "rpm.mbn";
			}
			else if (wkFile == "misc")
			{
				wkFile = "misc.mbn";
			}
			else if (wkFile == "sec")
			{
				wkFile = "sec.mbn";
			}
			else if (wkFile == "modem")
			{
				wkFile = "NON-HLOS.bin";
			}
			lbl1.Text = " Backing up : " + WorkingPartition;
			lbl1.Image = Resources.loading;
			SendCommand = "dependencies\\emmcdl  -p " + Comport + " -f " + WorkingFirehose + " -d " + WorkingPartition + " -o \"" + WorkingDir + "\\" + WorkingFile + "\"";
			CMD.SetFinish = false;
			if (!bwEmmcdl.IsBusy)
			{
				bwEmmcdl.RunWorkerAsync();
			}
			while (true)
			{
				await Task.Delay(500);
				if (CMD.GetFinish)
				{
					break;
				}
				if (File.Exists(WorkingDir + "\\" + WorkingFile))
				{
					FileInfo fInfo = new FileInfo(WorkingDir + "\\" + WorkingFile);
					string size = MyClass.Myfiles.SizeConvertor(fInfo.Length);
					string backup_file2 = WorkingPartition;
					lbl1.Text = " " + size + " completed ";
					LOG.Clear();
					LOG.AppendText(" Копирование раздела : " + WorkingPartition + "\t "+size+" | "+ fullsize, Color.White);
				}
			}
			lbl1.Text = CMD.result;
			groupBoxBackupRestore.Enabled = true;
			info.Play();
			LOG.AppendText(" Завершенно\n");
			lbl1.Image = Resources.allowed_usb;
		}

		private void bwEmmcdl_DoWork(object sender, DoWorkEventArgs e)
		{
			CMD.Command(SendCommand, "");
		}

		private void bwEmmcdl_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
		}

		private void bwEmmcdl_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			lbl1.Image = Resources.allowed_usb;
		}

		private void btnEmmcToFirmware_Click(object sender, EventArgs e)
		{
			click.Play();
			DisableAll();
			foreach (ListViewItem item in listViewEmmc.CheckedItems)
			{
				Thread thread = new Thread((ThreadStart)delegate
				{
					lbl1.Text = "extracting:    " + item.SubItems[1].Text;
					lbl1.Image = Resources.loading;
					SFK.PartCopy(EmmcForExtract, item.SubItems[2].Text, item.SubItems[3].Text, Qualcomm.partition(item.SubItems[1].Text));
				});
				thread.IsBackground = true;
				thread.Start();
				while (thread.IsAlive)
				{
					Application.DoEvents();
				}
				lbl1.Text = "Done";
				lbl1.Image = Resources.blocked_usb;
			}
			Enableall();
		}

		private void listViewEmmc_MouseClick(object sender, MouseEventArgs e)
		{
			ListViewHitTestInfo listViewHitTestInfo = listViewEmmc.HitTest(e.Location);
			if (listViewHitTestInfo.Location == ListViewHitTestLocations.Label)
			{
				listViewHitTestInfo.Item.Checked = true;
			}
		}

		private async void btnBrowseEmmc_Click(object sender, EventArgs e)
		{
			click.Play();
			if (!DC.CheckOk())
			{
				LOG.Clear();
				LOG.AppendText("\n Дополнение не найдено \n Установите Python 2.7+\n");
				return;
			}
			LOG.Clear();
			MyFile.Delete(Path.GetTempPath() + "\\build.prop");
			MyFile.Delete(Path.GetTempPath() + "\\system.img");
			listViewEmmc.Items.Clear();
			MyFile.Delete(MyClass._WorkingDir + "\\ok.txt");
			OpenFileDialog open = new OpenFileDialog();
			open.Title = "Select your eMMC file..";
			open.Filter = " All files (*.*)|*.*";
			open.CheckFileExists = true;
			open.CheckPathExists = true;
			open.FilterIndex = 1;
			open.RestoreDirectory = true;
			if (open.ShowDialog() == DialogResult.OK)
			{
				try
				{
					if (open.OpenFile() != null)
					{
						int count2 = 0;
						wkFile = open.FileName;
						wkDir = Path.GetDirectoryName(WorkingFile);
						LOG.AppendText(" Расположение файла:\t\t\t-  ", Color.White);
						LOG.AppendText(WorkingDir + "\n");
						txtEmmcLoad.Text = WorkingFile;
						EmmcForExtract = WorkingFile;
						LOG.AppendText(" Имя файла:\t\t\t-  ", Color.White);
						LOG.AppendText(open.SafeFileName + "\n");
						LOG.AppendText(" Размер файла:\t\t\t\t- ", Color.White);
						LOG.AppendText(WorkingFile.size() + "\n");
						Process sk = new Process();
						sk.StartInfo.CreateNoWindow = true;
						sk.StartInfo.UseShellExecute = false;
						sk.StartInfo.WorkingDirectory = WorkingDir;
						sk.StartInfo.RedirectStandardOutput = true;
						sk.StartInfo.RedirectStandardError = true;
						sk.EnableRaisingEvents = false;
						sk.StartInfo.FileName = DC.sfk;
						sk.StartInfo.Arguments = " partcopy \"" + open.SafeFileName + "\" 0 17408  gpt_main0.bin   -yes  ";
						sk.Start();
						sk.WaitForExit();
						Process process = new Process();
						process.StartInfo.FileName = DC.gdisk;
						process.StartInfo.CreateNoWindow = true;
						process.StartInfo.UseShellExecute = false;
						process.StartInfo.WorkingDirectory = WorkingDir;
						process.StartInfo.RedirectStandardOutput = true;
						process.StartInfo.RedirectStandardError = true;
						process.EnableRaisingEvents = false;
						process.StartInfo.Arguments = " gpt_main0.bin -l";
						process.Start();
						process.WaitForExit(1000);
						string RESULT = process.StandardOutput.ReadToEnd();
						if (RESULT.Contains("GPT: not present"))
						{
							LOG.AppendText("GPT: не получен\t\t\t", Color.White);
							LOG.AppendText("Ошибка (PermissionDenied or DeviceRefuseCommand)\n", Color.Red);
							
							Enableall();
							return;
						}
						ListViewItem lvi2 = new ListViewItem("1")
						{
							SubItems = { "gpt", "0x0", "0x4200", "17kB" }
						};
						listViewEmmc.Items.Add(lvi2);
						count2++;
						using (StringReader Reader = new StringReader(RESULT))
						{
							while (Reader.Peek() != -1)
							{
								string line2 = Reader.ReadLine();
								if (!line2.StartsWith("   ") && !line2.StartsWith("  1") && !line2.StartsWith("  2") && !line2.StartsWith("  3") && !line2.StartsWith("  4") && !line2.StartsWith("  5"))
								{
									continue;
								}
								string[] raw = line2.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
								raw[1] = (Convert.ToInt32(raw[1]) * 512).ToString("X");
								raw[2] = (Convert.ToInt32(raw[2]) * 512).ToString("X");
								ListViewItem lvi = new ListViewItem
								{
									Text = raw[0],
									SubItems = 
									{
										raw[6],
										"0x" + raw[1],
										"0x" + raw[2],
										raw[3] + raw[4]
									}
								};
								listViewEmmc.Items.Add(lvi);
								count2++;
								if (raw[6] == "system")
								{
									Thread thr = new Thread((ThreadStart)delegate
									{
										sk.StartInfo.Arguments = " partcopy \"" + open.SafeFileName + "\" -fromto  0x" + raw[1] + " 0x" + raw[2] + " \"" + Path.GetTempPath() + "\\system.img \"  -yes  ";
										sk.Start();
										sk.WaitForExit();
									});
									thr.IsBackground = true;
									thr.Start();
									while (thr.IsAlive)
									{
										Application.DoEvents();
									}
								}
							}
							Reader.Close();
						}
						listViewEmmc.Columns[0].Width = 40;
						LOG.AppendText(" total Partitions:\t\t\t-  ", Color.White);
						LOG.AppendText(count2 + "\n");
						if (!File.Exists(Path.GetTempPath() + "\\system.img"))
						{
							return;
						}
						LOG.AppendText("\n ROM Information:\n", Color.White);
						sk.StartInfo.WorkingDirectory = Path.GetTempPath();
						sk.StartInfo.FileName = "dependencies\\7z.exe";
						sk.StartInfo.Arguments = " e  system.img build.prop -y ";
						sk.Start();
						sk.WaitForExit();
						comboBox2.SelectedIndex = 1;
					}
					Enableall();
				}
				catch
				{
					Enableall();
					LOG.AppendText("Не удаётся прочитать файл (FileInCorData or FileNotFoun) \n");
					"Can not open as eMMC file".Error();
					return;
				}
			}
			await Task.Delay(500);
			Enableall();
			if (!File.Exists(Path.GetTempPath() + "\\build.prop"))
			{
				return;
			}
			string[] array = File.ReadAllLines(Path.GetTempPath() + "\\build.prop");
			foreach (string line in array)
			{
				if (line.Contains("ro.product.brand"))
				{
					LOG.AppendText(" Имя устройства:\t\t\t- ", Color.White);
					LOG.AppendText(line.Substring(line.IndexOf("=") + 1).ToUpper() + Environment.NewLine);
				}
				else if (line.StartsWith("ro.product.model"))
				{
					LOG.AppendText(" Тип:\t\t\t- ", Color.White);
					LOG.AppendText(line.Substring(line.IndexOf("=") + 1).ToUpper() + Environment.NewLine);
				}
				else if (line.StartsWith("ro.board.platform"))
				{
					LOG.AppendText(" Процессор:\t\t\t- ", Color.White);
					LOG.AppendText(line.Substring(line.IndexOf("=") + 1).ToUpper() + Environment.NewLine);
				}
				else if (line.StartsWith("ro.build.version.release"))
				{
					LOG.AppendText(" Версия:\t\t\t- ", Color.White);
					LOG.AppendText(line.Substring(line.IndexOf("=") + 1).ToUpper() + Environment.NewLine);
				}
				else if (line.StartsWith("ro.build.display.id"))
				{
					LOG.AppendText(" Номер сборки:\t\t- ", Color.White);
					LOG.AppendText(line.Substring(line.IndexOf("=") + 1).ToUpper() + Environment.NewLine);
				}
			}
			MyFile.Delete(WorkingDir + "\\gpt_main0.bin");
		}

		private void btnFlashEmmcToDevice_Click_1(object sender, EventArgs e)
		{
			if (listViewEmmc.Items.Count < 1)
			{
				LOG.Clear();
				LOG.AppendText("\n Ошибка загрузки резевной копии eMMC (FileNoData)\n", Color.Red);
				Enableall();
				return;
			}
			if (listViewEmmc.SelectedItems.Count < 1)
			{
				LOG.Clear();
				LOG.AppendText("\n Ошибка, не выбран раздел (NoPartSel)\n", Color.Red);
				Enableall();
				return;
			}
			foreach (ListViewItem item in listViewEmmc.CheckedItems)
			{
				LOG.AppendText("Распаковка:\t\t-  ", Color.White);
				LOG.AppendText(item.SubItems[1].Text + Environment.NewLine);
				Thread thread = new Thread((ThreadStart)delegate
				{
					lblPartition.Text = "extracting:    " + item.SubItems[1].Text + "\t";
					lbl1.Image = Resources.loading;
					SFK.PartCopy(EmmcForExtract, item.SubItems[2].Text, item.SubItems[3].Text, item.SubItems[1].Text);
					lbl1.Text = "File extracted";
					Thread.Sleep(1000);
					wkDir = Path.GetDirectoryName(EmmcForExtract);
					lbl1.Text = "Waiting device";
					isFound = false;
					Thread thread2 = new Thread((ThreadStart)delegate
					{
						int num = 20;
						while (true)
						{
							if (num < 0)
							{
								return;
							}
							Usb.Detect();
							Thread.Sleep(1000);
							if (Usb.IsConnected)
							{
								wkFirehose = M3.O;
								isFound = true;
								return;
							}
							if (num == 0)
							{
								break;
							}
							num--;
						}
						lbl1.Text = "Device not connected";
						lbl1.Image = Resources.blocked_usb;
						isFound = false;
					});
					thread2.IsBackground = true;
					thread2.Start();
					while (thread2.IsAlive)
					{
						Application.DoEvents();
					}
					if (!isFound)
					{
						Enableall();
					}
					else
					{
						LOG.AppendText("Устройство найдено:\n");
						if (!File.Exists(WorkingFirehose))
						{
							lbl1.Text = "Error device can not detect";
							lbl1.Image = Resources.blocked_usb;
							Enableall();
						}
						else
						{
							string text = " -p " + Usb.COM + " -f " + WorkingFirehose + " -b " + item.SubItems[1].Text + " " + item.SubItems[1].Text;
							Process process = new Process();
							ProcessStartInfo processStartInfo = new ProcessStartInfo
							{
								WindowStyle = ProcessWindowStyle.Hidden,
								FileName = DC.emmcdl,
								WorkingDirectory = WorkingDir,
								Arguments = text
							};
							Console.WriteLine(text);
							processStartInfo.RedirectStandardOutput = true;
							processStartInfo.UseShellExecute = false;
							processStartInfo.CreateNoWindow = true;
							process.StartInfo = processStartInfo;
							process.Start();
							StreamReader standardOutput = process.StandardOutput;
							standardOutput.ReadToEnd();
							process.WaitForExit();
							standardOutput.Close();
						}
					}
				});
				thread.IsBackground = true;
				thread.Start();
				while (thread.IsAlive)
				{
					Application.DoEvents();
				}
				LOG.AppendText("Завершенно:\n");
				lblPartition.Text = "Done";
				lbl1.Image = Resources.blocked_usb;
			}
		}

		private void ConnectEdl()
		{
			lbl1.Image = Resources.loading;
			Thread thread = new Thread((ThreadStart)delegate
			{
				int num = 30;
				while (true)
				{
					if (num < 0)
					{
						return;
					}
					lbl1.Text = "Waiting " + num;
					Usb.Detect();
					Thread.Sleep(1000);
					if (Usb.IsConnected)
					{
						lbl1.Image = Resources.allowed_usb;
						lbl1.Text = Usb.Port;
						isFound = true;
						info.Play();
						return;
					}
					if (num == 0)
					{
						break;
					}
					num--;
				}
				update(" timeout");
				lbl1.Image = Resources.blocked_usb;
				isFound = false;
				lbl1.Text = "";
				Enableall();
			});
			thread.IsBackground = true;
			thread.Start();
			while (thread.IsAlive)
			{
				Application.DoEvents();
			}
		}

		private void btnCreateBoard_Click(object sender, EventArgs e)
		{
			click.Play();
			if (!DC.CheckOk())
			{
				LOG.Clear();
				LOG.AppendText("\n Дополнение не найдено \n Установите Python 2.7+\n");
			}
			else
			{
				CreateBoard();
			}
		}

		private async void CreateBoard()
		{
			if (!File.Exists(txtDload.Text))
			{
				LOG.AppendText(" Выберите UPDATE.APP\t\t\t\t", Color.White);
				LOG.AppendText("Ошибка (FileNotSel)\n", Color.Red);
				return;
			}
			string UPDATE_PP = txtDload.Text;
			FileInfo update = new FileInfo(UPDATE_PP);
			if (!update.Name.ToLower().EndsWith(".app"))
			{
				LOG.AppendText(" Принимается только .APP файл\t\t", Color.White);
				LOG.AppendText("Ошибка (FileIncorrect)\n", Color.Red);
				return;
			}
			string DloadDir = update.DirectoryName;
			LOG.Clear();
			LOG.AppendText("\n Распаковка файла:\t- ", Color.White);
			if (UPDATE_PP.Contains(" "))
			{
				UPDATE_PP = "\"" + UPDATE_PP + "\"";
			}
			O1.RUN(" dependencies\\dload.exe " + UPDATE_PP, "");
			do
			{
				await Task.Delay(500);
			}
			while (!O1.finish);
			LOG.AppendText("Завершенно:" + nline);
			List<string> local = new List<string> { "crc.img", "amss_verlist.img", "md5rsa.img", "oemsbl_ver.img", "oemsbl_verlist.img" };
			local.ForEach(delegate(string string_0)
			{
				MyFile.Delete(DloadDir + "\\" + string_0);
			});
			string Ver = "";
			if (File.Exists(DloadDir + "\\amss_ver.img"))
			{
				byte[] version = File.ReadAllBytes(DloadDir + "\\amss_ver.img");
				Ver = Encoding.ASCII.GetString(version);
				MyFile.Delete(DloadDir + "\\amss_ver.img");
			}
			string BoardFirmwareDir = DloadDir + "\\" + Ver;
			string fImage = BoardFirmwareDir + "\\fastbootimage";
			DirectoryInfo di = new DirectoryInfo(BoardFirmwareDir);
			if (di.Exists)
			{
				FileInfo[] files3 = di.GetFiles();
				foreach (FileInfo file3 in files3)
				{
					try
					{
						file3.Delete();
					}
					catch
					{
						Enableall();
					}
				}
				DirectoryInfo[] directories = di.GetDirectories();
				foreach (DirectoryInfo dir in directories)
				{
					dir.Delete(recursive: true);
				}
			}
			Directory.CreateDirectory(BoardFirmwareDir);
			Directory.CreateDirectory(fImage);
			DirectoryInfo dload = new DirectoryInfo(DloadDir);
			FileInfo[] imagesFiles = dload.GetFiles();
			FileInfo[] array = imagesFiles;
			foreach (FileInfo file in array)
			{
				_ = file.Name;
				if (file.Name.EndsWith(".img"))
				{
					File.Move(DloadDir + "\\" + file.Name, fImage + "\\" + file.Name);
				}
			}
			DirectoryInfo dirInfo2 = new DirectoryInfo(fImage);
			FileInfo[] files2 = dirInfo2.GetFiles();
			FileInfo[] array2 = files2;
			foreach (FileInfo file2 in array2)
			{
				string image = file2.Name;
				if (image == "gpt.img")
				{
					Rename(file2.FullName, "gpt_both0.bin");
				}
				if (image == "aboot.img")
				{
					Rename(file2.FullName, "emmc_appsboot.mbn");
				}
				if (image == "tz.img")
				{
					Rename(file2.FullName, "tz.mbn");
				}
				if (image == "sbl1.img")
				{
					Rename(file2.FullName, "sbl1.mbn");
				}
				if (image == "hyp.img")
				{
					Rename(file2.FullName, "hyp.mbn");
				}
				if (image == "rpm.img")
				{
					Rename(file2.FullName, "rpm.mbn");
				}
				if (image == "fsg.img")
				{
					Rename(file2.FullName, "fs_image.tar.gz.mbn.img");
				}
				if (image == "modem.img")
				{
					Rename(file2.FullName, "NON-HLOS.bin");
				}
				if (image == "modemst1.img")
				{
					Rename(file2.FullName, "modem_st1.mbn");
				}
				if (image == "modemst2.img")
				{
					Rename(file2.FullName, "modem_st2.mbn");
				}
			}
			try
			{
				File.Copy("data\\\\huawei\\\\misc.mbn", fImage + "\\misc.mbn");
			}
			catch
			{
				Enableall();
			}
			LOG.AppendText("\n");
			LOG.AppendText("\t\t\tneed to Add oeminfo.mbn\n");
			LOG.AppendText("\t\t\tneed to Add bootloaderimage folder\n");
			LOG.AppendText("\t\t\tneed to Add log.img folder\n");
			await Task.Delay(2000);
			try
			{
				Process.Start("explorer.exe", DloadDir);
			}
			catch
			{
				Enableall();
			}
			info.Play();
		}
		public int q11 = 0;
		public int q22 = 0;
		public int q33 = 0;
		public int q44 = 0;
		public int q55 = 0;
		private void DisableAll()
		{
			q1.Enabled = false;
			q2.Enabled = false;
			q3.Enabled = false;
			q4.Enabled = false;
			q5.Enabled = false;
			if (q11 == 0) {
			q1.Visible = false;
			}
			if (q22 == 0) {
			q2.Visible = false;
			}
			if (q44 == 0) {
			q4.Visible = false;
			}
			if (q33 == 0) {
			q3.Visible = false;
			}
			if (q55 == 0) {
			q5.Visible = false;
			}
		}

		private void Enableall()
		{
			if (q11 == 1) {
			q1.Visible = true;
			q1.Enabled = true;
			} else if (q22 == 1) {
			q2.Visible = true;
			q2.Enabled = true;
			} else if (q33 == 1) {
			q3.Visible = true;
			q3.Enabled = true;
			} else if (q44 == 1) {
			q4.Visible = true;
			q4.Enabled = true;
			}
			else if (q55 == 1) {
			q5.Visible = true;
			q5.Enabled = true;
			}
		}

		private static int NewMethod(int int_0, int int_1)
		{
			if (int_1 < 100)
			{
				return int_1 * int_0 / 120;
			}
			if (int_1 > 100)
			{
				return int_1 * int_0 / 80;
			}
			return 1000;
		}

		private void btnEmmcSelect_Click(object sender, EventArgs e)
		{
			click.Play();
			string text = null;
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Select your eMMC file..";
			openFileDialog.Filter = " All files (*.*)|*.*";
			openFileDialog.CheckFileExists = true;
			openFileDialog.CheckPathExists = true;
			openFileDialog.FilterIndex = 1;
			openFileDialog.RestoreDirectory = true;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					if (openFileDialog.OpenFile() != null)
					{
						text = openFileDialog.FileName;
						wkFile = openFileDialog.FileName;
						wkDir = Path.GetDirectoryName(openFileDialog.FileName);
						if (openFileDialog.SafeFileName.Contains(" "))
						{
							LOG.AppendText("Пожалуйста переименуйте копию разделов без проблеов\t\t", Color.White);
							LOG.AppendText("Ошибка (FileNameError)\n", Color.Red);
							btnEmmcDownloadFast.Enabled = false;
							return;
						}
						btnEmmcDownloadFast.Enabled = true;
					}
				}
				catch
				{
					LOG.AppendText("Ошибка, неполучается прочесть файл\t\t", Color.White);
					LOG.AppendText("(FileCorrupted Or FileNotFound)\n", Color.Red);
					Enableall();
					return;
				}
			}
			if (File.Exists(text))
			{
				FileInfo fileInfo = new FileInfo(text);
				txtEmmc.Text = text;
				LOG.Clear();
				LOG.AppendText("");
				LOG.AppendText(" Размещение:\t", Color.White);
				LOG.AppendText(WorkingDir + nline);
				LOG.AppendText(" Название:\t\t", Color.White);
				LOG.AppendText(fileInfo.Name + nline);
				LOG.AppendText(" Размер:\t\t", Color.White);
				string text2 = MyClass.Myfiles.SizeConvertor(fileInfo.Length);
				LOG.AppendText(text2 + nline);
				LOG.AppendText(nline);
				tmWait.Enabled = true;
			}
		}

		private void mMove(string string_1, string string_2)
		{
		}

		private void btnEmmcDownloadFast_Click(object sender, EventArgs e)
		{
			click.Play();
			if (!DC.CheckOk())
			{
				LOG.Clear();
				LOG.AppendText("\n Дополнение не найдено \n Установите Python 2.7+\n");
				return;
			}
			if (txtEmmc.Text == "")
			{
				LOG.AppendText("Выберите eMMC резервную копию\t\t", Color.White);
				LOG.AppendText("Ошибка (eMMC imageNotSel)\n", Color.Red);
				return;
			}
			if (!File.Exists(txtEmmc.Text))
			{
				LOG.AppendText("Данный раздел не найден\t\t", Color.White);
				LOG.AppendText("Ошибка (PartNotFound)\n", Color.Red);
				return;
			}
			wkDir = Path.GetDirectoryName(txtEmmc.Text);
			LOG.AppendText(" Поиск устройств:\t\t- ", Color.White);
			DisableAll();
			isFound = false;
			ConnectEdl();
			if (!isFound)
			{
				Enableall();
				return;
			}
			LOG.AppendText("Устройство найдено:" + Environment.NewLine);
			if (cBoxAuto1.Checked)
			{
				wkFirehose = Calculate.firehose();
			}
			else
			{
				wkFirehose = "data\\firehose\\" + FirehoseSels.Text;
			}
			if (!File.Exists(WorkingFirehose))
			{
				LOG.AppendText(" Ошибка (LoaderIsMoved)", Color.Red);
				Enableall();
				return;
			}
			LOG.AppendText(" " + Usb.Port + nline);
			lbl1.Text = " Downloading firehose ";
			lbl1.Image = Resources.loading;
			LOG.AppendText(" Порт обноружения:\t", Color.White);
			firehoseOK = false;
			FlashFirehose();
			if (!firehoseOK)
			{
				LOG.AppendText("Ошибка\n", Color.Yellow);
				Enableall();
				return;
			}
			LOG.AppendText("Успешно\n");
			LOG.AppendText(" Запись eMMC резервной копии" + nline);
			lbl1.Text = "Downloading....";
			lbl1.Image = Resources.loading;
			if (!bwDownload_eMMC.IsBusy)
			{
				bwDownload_eMMC.RunWorkerAsync();
			}
		}

		private void bwDownload_eMMC_DoWork(object sender, DoWorkEventArgs e)
		{
			string fileName = Path.GetFileName(WorkingFile);
			string string_ = "   --port=\\\\.\\" + Comport + "     --sendimage=" + fileName + "   --noprompt --showpercentagecomplete  --zlpawarehost=1 --memoryname=eMMC ";
			WriteEmmc(string_, WorkingDir);
		}

		private void bwDownload_eMMC_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			string text = (string)e.UserState;
			try
			{
				text = text.Substring(text.LastIndexOf(" "));
				text = text.Substring(0, text.IndexOf("."));
				pBar.Value = Convert.ToInt32(text);
			}
			catch
			{
			}
			LOG.Focus();
			LOG.AppendText((string)e.UserState + nline);
			LOG.Refresh();
		}

		private void bwDownload_eMMC_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			pBar.Value = 0;
			MyFile.Delete(WorkingDir + "\\port_trace.txt");
			LOG.AppendText(" Завершенно " + nline);
			groupBoxBlock0Write.Enabled = true;
			Enableall();
		}

		public void WriteEmmc(string string_1, string string_2)
		{
			Process process = new Process();
			ProcessStartInfo processStartInfo = new ProcessStartInfo();
			processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			processStartInfo.FileName = DC.fh_loader;
			processStartInfo.WorkingDirectory = string_2;
			processStartInfo.Arguments = string_1;
			Console.WriteLine(string_1);
			processStartInfo.RedirectStandardOutput = true;
			processStartInfo.UseShellExecute = false;
			processStartInfo.CreateNoWindow = true;
			process.StartInfo = processStartInfo;
			process.OutputDataReceived += WriteEmmcDataReceiver;
			process.Start();
			process.BeginOutputReadLine();
			process.WaitForExit();
		}

		private void WriteEmmcDataReceiver(object sender, DataReceivedEventArgs e)
		{
			Console.WriteLine(e.Data);
			if (e.Data != null)
			{
				WriteEmmcupdater(e.Data);
				Console.WriteLine(e.Data);
			}
		}

		private void WriteEmmcupdater(string string_1)
		{
			if (string_1.Contains("percent files transferred"))
			{
				try
				{
					bwDownload_eMMC.ReportProgress(0, string_1);
					lbl1.Text = string_1;
					lbl1.Image = Resources.loading;
				}
				catch
				{
					Enableall();
				}
			}
		}

		public void RedirectProcess2(string string_1, string string_2)
		{
			Process process = new Process();
			ProcessStartInfo processStartInfo = new ProcessStartInfo();
			processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			processStartInfo.FileName = DC.fh_loader;
			processStartInfo.WorkingDirectory = string_2;
			processStartInfo.Arguments = string_1;
			Console.WriteLine(string_1);
			processStartInfo.RedirectStandardOutput = true;
			processStartInfo.UseShellExecute = false;
			processStartInfo.CreateNoWindow = true;
			process.StartInfo = processStartInfo;
			process.Start();
			process.BeginOutputReadLine();
			process.WaitForExit();
		}

		private void p_OutputDataReceived2(object sender, DataReceivedEventArgs e)
		{
			Console.WriteLine(e.Data);
			if (e.Data != null)
			{
				update2(e.Data);
				bwDownload_eMMC.ReportProgress(0, e.Data);
				Console.WriteLine(e.Data);
			}
		}

		private void update2(string string_1)
		{
			try
			{
				lbl1.Text = string_1;
			}
			catch
			{
				Enableall();
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			click.Play();
			using FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
			DialogResult dialogResult = folderBrowserDialog.ShowDialog();
			if (dialogResult == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
			{
				LOG.Clear();
				wkDir = folderBrowserDialog.SelectedPath;
				Qualcomm.EMMCDL.SetDir = WorkingDir;
				txtEmmcSaveLocation.Text = WorkingDir;
			}
		}

		public static void EnableTab(TabPage tabPage_0, bool bool_0)
		{
			foreach (Control control in tabPage_0.Controls)
			{
				control.Enabled = bool_0;
			}
		}

		private async void btnDumpEmmc_Click(object sender, EventArgs e)
		{
			LOG.Clear();
			click.Play();
			CleanQualcomm();
			if (!DC.CheckOk())
			{
				LOG.Clear();
				LOG.AppendText("\n Дополнение не найдено \n Установите Python 2.7+\n");
				return;
			}
			if (!cBoxAuto1.Checked)
			{
				if (FirehoseSels.Text == "")
				{
					LOG.AppendText(" Выберите загрузчик\t\t", Color.White);
					LOG.AppendText("Ошибка (LoaderNotSel)\n", Color.Red);
					groupBoxBlock0Read.Enabled = true;
					Enableall();
					return;
				}
				wkFirehose = "data\\firehose\\" + FirehoseSels.Text;
			}
			else
			{
				wkFirehose = Calculate.firehose();
			}
			LOG.AppendText("\n");
			LOG.AppendText(" Поиск устройств:\t\t- ", Color.White);
			DisableAll();
			isFound = false;
			ConnectEdl();
			if (!isFound)
			{
				Enableall();
				return;
			}
			LOG.AppendText("Устройство найдено\n");
			await Task.Delay(100);
			LOG.AppendText(Usb.Port + nline);
			if (!File.Exists(WorkingFirehose))
			{
				LOG.AppendText("Ошибка, используйте ручной метод", Color.White);
				groupBoxBlock0Read.Enabled = true;
				Enableall();
				return;
			}
			flashCommand = " -p " + Comport + " -f  " + WorkingFirehose;
			LOG.AppendText("Прошивка загрузчика\t", Color.White);
			firehoseOK = false;
			FlashFirehose();
			if (!firehoseOK)
			{
				LOG.AppendText("Ошибка\n", Color.Red);
				Enableall();
				return;
			}
			Enableall();
			LOG.AppendText("Успешно\n", Color.Yellow);
			MyClass.eMMC.getGPT(Comport, WorkingFirehose);
			btnDumpEmmc.Enabled = true;
			Form2 f2 = new Form2();
			f2.ShowDialog();
		}

		private async void WaitForDumpEmmc()
		{
			if (!MyClass.eMMC.DumpFinish)
			{
				pBarEmmcDump.Show();
				await Task.Delay(SleepTimeForDump);
				try
				{
					pBarEmmcDump.Value++;
				}
				catch
				{
					pBarEmmcDump.Value = 0;
				}
				if (File.Exists(WorkingDir + "\\eMMC.bin"))
				{
					FileInfo fInfo = new FileInfo(WorkingDir + "\\eMMC.bin");
					string s = MyClass.Myfiles.SizeConvertor(fInfo.Length);
					lbl1.Text = " Finished " + s;
					groupBoxBlock0Read.Enabled = true;
				}
				WaitForDumpEmmc();
			}
			else
			{
				lbl1.Text = " Dump Block0 finish ";
				lbl1.Image = Resources.blocked_usb;
				pBarEmmcDump.Value = 0;
				pBarEmmcDump.Hide();
				btnDumpEmmc.Enabled = true;
				groupBoxBlock0Read.Enabled = true;
			}
		}

		private async void btnAdbRead_Click(object sender, EventArgs e)
		{
			click.Play();
			if (!DC.CheckOk())
			{
				LOG.Clear();
				LOG.AppendText("\n Дополнение не найдено \n Установите Python 2.7+\n");
				return;
			}
			LOG.Clear();
			if (!Directory.Exists(txtEmmcSaveLocation.Text))
			{
				LOG.AppendText("Путь сохранения не найден\t\t", Color.White);
				LOG.AppendText("Ошибка (PathNotSel)\n", Color.Red);
				return;
			}
			LOG.AppendText(" Путь сохранения:\t", Color.White);
			LOG.AppendText(txtEmmcSaveLocation.Text + "\n");
			await Task.Delay(200);
			LOG.AppendText(" Adb перезапускается\t\t", Color.White);
			Adb.KillServer();
			LOG.AppendText("Завершенно:\n");
			await Task.Delay(200);
			LOG.AppendText(" Adb запускается\t", Color.White);
			Adb.StartServer();
			LOG.AppendText("Завершенно:\n");
			await Task.Delay(200);
			LOG.AppendText(" Поиск устройств:\t\t- ", Color.White);
			isFound = false;
			lbl1.Image = Resources.loading;
			Thread thr = new Thread((ThreadStart)delegate
			{
				int num = 20;
				while (true)
				{
					if (num < 0)
					{
						return;
					}
					D2.Detect();
					Thread.Sleep(1000);
					if (D2.IsinAdb)
					{
						break;
					}
					lbl1.Text = " Waiting  " + num;
					if (num == 0)
					{
						isFound = false;
						lbl1.Text = " Waiting timeout";
						lbl1.Image = Resources.blocked_usb;
						update("Timeout\n");
						Enableall();
						return;
					}
					num--;
				}
				update("Connected\n");
				lbl1.Text = " Device is in Adb mode";
				lbl1.Image = Resources.allowed_usb;
				info.Play();
				isFound = true;
			});
			thr.IsBackground = true;
			thr.Start();
			while (thr.IsAlive)
			{
				Application.DoEvents();
			}
			if (!isFound)
			{
				return;
			}
			LOG.AppendText("");
			LOG.AppendText(" Устройство подключено\n");
			LOG.AppendText(" Проверка рут доступа:\t", Color.White);
			if (!D2.isRooted)
			{
				LOG.AppendText("Ошибка (RootNotFound)\n", Color.Yellow);
				return;
			}
			LOG.AppendText("Завершенно:\n");
			LOG.AppendText(" Установка busybox:\t", Color.White);
			if (D2.BusyboxInstall() != "OK")
			{
				LOG.AppendText("Ошибка (PermisDenied or FileNotFound)\n", Color.Red);
				return;
			}
			LOG.AppendText("Завершенно:\n");
			LOG.AppendText(" Block0 Size:\t\t", Color.White);
			LOG.AppendText(D2.String_0 + Environment.NewLine);
			File.WriteAllText("bat1.bat", Resources.bat1);
			File.WriteAllText("bat2.bat", Resources.bat2);
			string bat3 = File.ReadAllText("bat2.bat");
			bat3 = bat3.Replace("mmcblk0", txtEmmcSaveLocation.Text + "\\Block0.bin");
			File.WriteAllText("bat2.bat", bat3);
			wkDir = txtEmmcSaveLocation.Text;
			if (!File.Exists(DC.busybox))
			{
				LOG.AppendText(" busybox.exe отсутствует...\n");
				return;
			}
			if (!File.Exists(DC.pv))
			{
				LOG.AppendText(" pv.exe отсутствует...\n");
				return;
			}
			LOG.AppendText(" Резервное копирование началось...\n");
			lbl1.Text = " Start now";
			lbl1.Image = Resources.loading;
			pBar.Style = ProgressBarStyle.Marquee;
			if (!bwReadAdb.IsBusy)
			{
				bwReadAdb.RunWorkerAsync();
			}
			while (Command.IsProcessRunning("adb"))
			{
				await Task.Delay(1000);
				if (File.Exists(txtEmmcSaveLocation.Text + "\\Block0.bin"))
				{
					DateTime time = DateTime.Now;
					string Time2 = time.Hour + ":" + time.Minute + ":" + time.Second;
					FileInfo f = new FileInfo(txtEmmcSaveLocation.Text + "\\Block0.bin");
					Time2 = Time2 + " Saved " + MyClass.Myfiles.SizeConvertor(f.Length);
					lbl1.Text = Time2;
				}
			}
			lbl1.Text = "Finished";
			lbl1.Image = Resources.allowed_usb;
			MyFile.Delete("bat1.bat");
			MyFile.Delete("bat2.bat");
			pBar.Style = ProgressBarStyle.Blocks;
			FileInfo f2 = new FileInfo(txtEmmcSaveLocation.Text + "\\Block0.bin");
			LOG.AppendText(" Резервная копия успешна\n");
			LOG.AppendText(" Расположение файла:\t\t", Color.White);
			LOG.AppendText(WorkingDir + "\n");
			LOG.AppendText(" Имя файла:\t\t", Color.White);
			LOG.AppendText("Block0.bin\n");
			LOG.AppendText(" Размер файла:\t\t\t", Color.White);
			LOG.AppendText(MyClass.Myfiles.SizeConvertor(f2.Length) + "\n");
		}

		private async void bwReadAdb_DoWork(object sender, DoWorkEventArgs e)
		{
			Process ptool = new Process();
			ptool.StartInfo.FileName = "bat1.bat";
			ptool.StartInfo.CreateNoWindow = true;
			ptool.StartInfo.UseShellExecute = false;
			ptool.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
			ptool.StartInfo.RedirectStandardOutput = true;
			ptool.StartInfo.RedirectStandardError = true;
			ptool.EnableRaisingEvents = false;
			ptool.Start();
			await Task.Delay(1000);
			string SendCommand = " ";
			Process process = new Process();
			ProcessStartInfo processStartInfo = new ProcessStartInfo
			{
				WindowStyle = ProcessWindowStyle.Hidden,
				FileName = "bat2.bat",
				WorkingDirectory = Directory.GetCurrentDirectory()
			};
			Console.WriteLine(SendCommand);
			processStartInfo.RedirectStandardOutput = true;
			processStartInfo.UseShellExecute = false;
			processStartInfo.CreateNoWindow = true;
			process.StartInfo = processStartInfo;
			process.ErrorDataReceived += _9006Receiver;
			process.OutputDataReceived += _9006Receiver;
			process.Start();
			process.BeginOutputReadLine();
			process.WaitForExit();
		}

		private void btnMakeRawprogram_Click(object sender, EventArgs e)
		{
		}

		private async void btnBackupFirmware_Click(object sender, EventArgs e)
		{
			click.Play();
			if (!DC.CheckOk())
			{
				LOG.Clear();
				LOG.AppendText("\n Дополнение не найдено \n Установите Python 2.7+\n");
				return;
			}
			if (!P1.CanRun)
			{
				LOG.AppendText("Установите Python 2.7+\t\t"+"Information\n");
				Py p = new Py();
				p.ShowDialog();
				return;
			}
			if (!cBoxAuto1.Checked && FirehoseSels.Text == "")
			{
				LOG.Clear();
				LOG.AppendText(" Выберите загрузчик\t\t"+"Ошибка (LoaderNotSel)\n", Color.White);
				LOG.AppendText("Ошибка (LoaderNotSel)\n", Color.Red);
				return;
			}
			using (FolderBrowserDialog fbd = new FolderBrowserDialog())
			{
				DialogResult result = fbd.ShowDialog();
				if (result != DialogResult.OK || string.IsNullOrWhiteSpace(fbd.SelectedPath))
				{
					return;
				}
				wkDir = fbd.SelectedPath;
			}
			LOG.Clear();
			LOG.AppendText(" Поиск устройств:\t\t- ", Color.White);
			isFound = false;
			DisableAll();
			ConnectEdl();
			if (!isFound)
			{
				Enableall();
				return;
			}
			LOG.AppendText("Устройство найдено:\n");
			if (cBoxAuto1.Checked & File.Exists(Calculate.firehose()))
			{
				string fhose2 = M3.id;
				fhose2 = "prog_emmc_firehose_" + fhose2.Replace("MSM", "") + ".mbn";
				File.Copy(Calculate.firehose(), WorkingDir + "\\" + fhose2, overwrite: true);
				wkFirehose = Calculate.firehose();
			}
			else
			{
				if (!(FirehoseSels.Text != ""))
				{
					LOG.AppendText("Не удаётся определить загрузчик для данного устройства\t\t", Color.White);
					LOG.AppendText("Ошибка (DeviceNotIndent)\n", Color.Red);
					btnBackupFirmware.Enabled = true;
					Enableall();
					return;
				}
				_ = M3.id;
				if (!File.Exists("data\\firehose\\" + FirehoseSels.Text))
				{
					LOG.AppendText("Не удаётся найти загрузчик\t\t", Color.White);
					LOG.AppendText("Ошибка (LoaderIsMoved)\n", Color.Red);
					return;
				}
				File.Copy("data\\firehose\\" + FirehoseSels.Text, WorkingDir + "\\prog_emmc_firehose.mbn", overwrite: true);
				FileInfo file = new FileInfo(WorkingDir + "\\prog_emmc_firehose.mbn");
				file.Rename("prog_emmc_firehose_" + M3.id.Replace("MSM", "") + ".mbn");
				wkFirehose = "data\\firehose\\" + FirehoseSels.Text;
			}
			LOG.Clear();
			LOG.AppendText(" COM:\t\t- ", Color.White);
			LOG.AppendText(Usb.Port + nline);
			LOG.AppendText(" Процессор :\t-", Color.White);
			LOG.AppendText(M3.id + Environment.NewLine);
			LOG.AppendText(" Информация :\t\t-", Color.White);
			LOG.AppendText(M3.O + Environment.NewLine);
			LOG.AppendText("Прошивка загрузчика\t", Color.White);
			firehoseOK = false;
			FlashFirehose();
			if (!firehoseOK)
			{
				LOG.AppendText("Ошибка\n", Color.Red);
				Enableall();
				return;
			}
			LOG.AppendText("Завершенно:\n" + nline);
			lbl1.Text = "pass";
			lbl1.Image = Resources.loading;
			isFirmwareBackupConfirmed = true;
			LOG.AppendText("\n");
			LOG.AppendText(" создание прошивки....\n");
			Process gpt = new Process();
			gpt.StartInfo.FileName = DC.emmcdl;
			gpt.StartInfo.CreateNoWindow = true;
			gpt.StartInfo.UseShellExecute = false;
			gpt.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
			gpt.StartInfo.RedirectStandardOutput = true;
			gpt.StartInfo.RedirectStandardError = true;
			gpt.EnableRaisingEvents = false;
			string s = " -p " + Usb.COM + " -f " + WorkingFirehose + " -d 0 33 -o " + quote + WorkingDir + "\\gpt" + quote;
			gpt.StartInfo.Arguments = s;
			LOG.AppendText(" read gpt from device....\t");
			gpt.Start();
			gpt.WaitForExit(1000);
			MyFile.Delete(WorkingDir + "\\port_trace.txt");
			await Task.Delay(1000);
			if (!File.Exists(WorkingDir + "\\gpt"))
			{
				LOG.AppendText("Fail\n");
				LOG.AppendText("can not dump gpt\n");
				Enableall();
				return;
			}
			LOG.AppendText("Завершенно:\n");
			File.WriteAllBytes(WorkingDir + "\\gpt_parser.py", Resources.parse);
			await Task.Delay(200);
			LOG.AppendText(" Create partition.xml :\t-", Color.White);
			Process gpt_parser = new Process();
			gpt_parser.StartInfo.FileName = "cmd.exe";
			gpt_parser.StartInfo.CreateNoWindow = true;
			gpt_parser.StartInfo.UseShellExecute = false;
			gpt_parser.StartInfo.WorkingDirectory = WorkingDir;
			gpt_parser.StartInfo.RedirectStandardOutput = true;
			gpt_parser.StartInfo.RedirectStandardError = true;
			gpt_parser.EnableRaisingEvents = false;
			gpt_parser.StartInfo.Arguments = "/c gpt_parser.py gpt > partition.xml  && exit";
			gpt_parser.Start();
			gpt_parser.WaitForExit(1000);
			if (!File.Exists(WorkingDir + "\\partition.xml"))
			{
				LOG.AppendText("Ошибка\n", Color.Red);
				MyFile.Delete(WorkingDir + "\\gpt_parser.py");
				Enableall();
				return;
			}
			LOG.AppendText("Завершенно:\n");
			MyFile.Delete(WorkingDir + "\\gpt_parser.py");
			LOG.AppendText(" Create rawprogram0.xml :\t]", Color.White);
			File.WriteAllBytes(WorkingDir + "\\ptool.py", Resources.ptool);
			string cmd = "ptool.py -x partition.xml > TEST.TXT";
			File.WriteAllText(WorkingDir + "\\run.bat", cmd);
			await Task.Delay(500);
			Process ptool = new Process();
			ptool.StartInfo.FileName = WorkingDir + "\\run.bat";
			ptool.StartInfo.CreateNoWindow = true;
			ptool.StartInfo.UseShellExecute = false;
			ptool.StartInfo.WorkingDirectory = WorkingDir;
			ptool.StartInfo.RedirectStandardOutput = true;
			ptool.StartInfo.RedirectStandardError = true;
			ptool.EnableRaisingEvents = false;
			ptool.Start();
			ptool.WaitForExit(3000);
			MyFile.Delete(WorkingDir + "\\TEST.TXT");
			MyFile.Delete(WorkingDir + "\\run.bat");
			MyFile.Delete(WorkingDir + "\\gpt_parser.py");
			MyFile.Delete(WorkingDir + "\\ptool.py");
			MyFile.Delete(WorkingDir + "\\port_trace.txt");
			MyFile.Delete(WorkingDir + "\\wipe_rawprogram_PHY0.xml");
			MyFile.Delete(WorkingDir + "\\wipe_rawprogram_PHY1.xml");
			MyFile.Delete(WorkingDir + "\\wipe_rawprogram_PHY2.xml");
			MyFile.Delete(WorkingDir + "\\wipe_rawprogram_PHY4.xml");
			MyFile.Delete(WorkingDir + "\\wipe_rawprogram_PHY5.xml");
			MyFile.Delete(WorkingDir + "\\wipe_rawprogram_PHY6.xml");
			MyFile.Delete(WorkingDir + "\\wipe_rawprogram_PHY7.xml");
			await Task.Delay(3000);
			if (!File.Exists(WorkingDir + "\\rawprogram0.xml"))
			{
				LOG.AppendText("Ошибка\n", Color.Red);
				MyFile.Delete(WorkingDir + "\\ptool.py");
				Enableall();
				return;
			}
			LOG.AppendText("Завершенно:\n");
			foreach (string line in File.ReadLines(WorkingDir + "\\rawprogram0.xml"))
			{
				LOG.Focus();
				LOG.AppendText(line + "\n");
				await Task.Delay(100);
			}
			if (!File.Exists(WorkingDir + "\\rawprogram0.xml"))
			{
				Enableall();
				LOG.AppendText(" Error\t\t-", Color.White);
				LOG.AppendText("can not create xml\n");
				Enableall();
			}
			LOG.AppendText("\n");
			LOG.AppendText("Reading firmware\n");
			fhloader.convertprogram2read(WorkingDir + "\\rawprogram0.xml");
			do
			{
				await Task.Delay(1000);
			}
			while (!F4.isFinished);
			Enableall();
			MyFile.Delete(WorkingDir + "\\port_trace.txt");
		}

		public void update(string string_1)
		{
			if (base.InvokeRequired)
			{
				Invoke(new Action<string>(update), string_1);
			}
			else
			{
				LOG.Focus();
				LOG.AppendText(string_1 + Environment.NewLine);
			}
		}

		private void tmWait_Tick(object sender, EventArgs e)
		{
			string comport = Comport;
			if (comport != "UNKNOWN")
			{
				tmWait.Enabled = false;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			click.Play();
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Select your UPDATE.APP ";
			openFileDialog.Filter = "app files (*.app)|*.app|All files (*.*)|*.*";
			openFileDialog.CheckFileExists = true;
			openFileDialog.CheckPathExists = true;
			openFileDialog.FilterIndex = 1;
			openFileDialog.RestoreDirectory = true;
			if (openFileDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			try
			{
				if (openFileDialog.OpenFile() != null)
				{
					txtDload.Text = openFileDialog.FileName;
					wkFile = openFileDialog.FileName;
				}
			}
			catch
			{
				Enableall();
				LOG.AppendText("Не удаётся прочитать файл (FileInCorData or FileNotFoun) ");
			}
		}

		public void Edl_Command(string string_1, string string_2)
		{
			Process process = new Process();
			ProcessStartInfo processStartInfo = new ProcessStartInfo();
			processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			processStartInfo.FileName = DC.emmcdl;
			processStartInfo.WorkingDirectory = string_2;
			processStartInfo.Arguments = string_1;
			Console.WriteLine(string_1);
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
				updateOK(e.Data);
				Console.WriteLine(e.Data);
			}
		}

		private void updateOK(string string_1)
		{
			if (string_1.Contains("Sectors remaining"))
			{
				lbl1.Text = string_1;
				return;
			}
			if (string_1.Contains("Status: 0 The operation completed successfully"))
			{
				lbl1.Text = "";
				lbl1.Image = Resources.blocked_usb;
				ssss = "OK";
				Thread.Sleep(1000);
			}
			Console.WriteLine(string_1);
		}

		private async void btnDownloadDload_Click(object sender, EventArgs e)
		{
			click.Play();
			if (!DC.CheckOk())
			{
				LOG.Clear();
				LOG.AppendText("\n Дополнение не найдено \n Установите Python 2.7+\n");
				return;
			}
			if (!File.Exists(txtDload.Text))
			{ 
				LOG.AppendText(" Выберите UPDATE.APP\t\t", Color.White);
				LOG.AppendText("Ошибка (UpdNotSel)\n", Color.Red);
				return;
			}
			wkFile = txtDload.Text;
			FileInfo updateFile = new FileInfo(WorkingFile);
			if (!updateFile.Name.ToLower().EndsWith(".app"))
			{
				LOG.AppendText(" Принимается только .APP file\t\t", Color.White);
				LOG.AppendText("Ошибка (FileIncorrect)\n", Color.Red);
				return;
			}
			wkDir = updateFile.DirectoryName;
			DisableAll();
			LOG.Clear();
			LOG.AppendText("\n распаковка файла:\t- ", Color.White);
			O1.RUN(DC.dload + " " + quote + WorkingFile + quote, "");
			int i0 = 1;
			while (true)
			{
				await Task.Delay(1000);
				i0++;
				if (!O1.finish)
				{
					if (i0 == 20 && !File.Exists(WorkingDir + "\\system.img"))
					{
						LOG.AppendText(" Ошибка (UnknownError)" + nline, Color.Red);
						btnDownloadDload.Enabled = true;
						Enableall();
						return;
					}
					continue;
				}
				info.Play();
				await Task.Delay(100);
				MyFile.Delete(WorkingDir + "\\gpt.img");
				LOG.AppendText("Завершенно:" + nline);
				await Task.Delay(500);
				D3.RemoveUnwantedFiles(WorkingFile);
				await Task.Delay(100);
				LOG.AppendText(" Номер сборки:\t\t- ", Color.White);
				LOG.AppendText(D3.model(WorkingFile) + nline);
				await Task.Delay(100);
				MyFile.Delete(WorkingDir + "\\amss_ver.img");
				LOG.AppendText(" Поиск устройств:\t\t- ", Color.White);
				isFound = false;
				ConnectEdl();
				if (!isFound)
				{
					Enableall();
				}
				break;
			}
			LOG.AppendText("Устройство найдено:\n");
			lbl1.Text = " flash dload to device";
			lbl1.Image = Resources.loading;
			LOG.AppendText(" Загрузка в режиме dload " + nline);
			wkFirehose = Calculate.firehose();
			await Task.Delay(100);
			if (!bwFlashDload.IsBusy)
			{
				bwFlashDload.RunWorkerAsync();
			}
			pBar.Style = ProgressBarStyle.Marquee;
		}

		private void bwFlashDload_DoWork(object sender, DoWorkEventArgs e)
		{
			bwFlashDload.ReportProgress(1, " flash firehose");
			int i = 1;
			flashCommand = " -p " + Comport + " -f " + WorkingFirehose;
			string text = MyClass.EMMCDL.Command(flashCommand, 2000);
			bwFlashDload.ReportProgress(1, text + nline);
			List<string> list = new List<string>();
			DirectoryInfo directoryInfo = new DirectoryInfo(WorkingDir);
			FileInfo[] array = null;
			array = directoryInfo.GetFiles();
			FileInfo[] array2 = array;
			foreach (FileInfo fileInfo in array2)
			{
				if (fileInfo.Name.EndsWith(".img"))
				{
					list.Add(fileInfo.Name);
				}
			}
			list.ForEach(delegate(string string_0)
			{
				string text3 = string_0;
				text3 = text3.Replace(".img", "");
				if (text3 != "persist")
				{
					bwFlashDload.ReportProgress(i++, " flash " + text3);
					flashCommand = " -p " + Comport + " -f " + WorkingFirehose + " -b " + text3 + " \"" + WorkingDir + "\\" + string_0 + "\"";
					Edl_Command(flashCommand, Directory.GetCurrentDirectory());
					bwFlashDload.ReportProgress(1, ssss + nline);
				}
			});
			bwFlashDload.ReportProgress(1, " flash persist : ");
			flashCommand = " -p " + Comport + " -f " + WorkingFirehose + " -b  persist  " + quote + WorkingDir + "\\persist.img" + quote;
			string text2 = MyClass.EMMCDL.Command(flashCommand, 0);
			bwFlashDload.ReportProgress(1, text2 + nline);
		}

		private void bwFlashDload_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			string text = (string)e.UserState;
			if (text.Contains("flash"))
			{
				LOG.AppendText(text + "\t\t", Color.White);
			}
			else
			{
				LOG.AppendText(text + Environment.NewLine);
			}
			lbl1.Text = text;
		}

		private void bwFlashDload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			Enableall();
			LOG.AppendText(" Загрузка завершенна " + nline);
			LOG.AppendText(" Перезагрузите устройство  " + nline, Color.Black);
			lbl1.Text = " passed ...";
			pBar.Style = ProgressBarStyle.Blocks;
			btnDownloadDload.Enabled = true;
		}

		private void btnNormalReboot_Click_1(object sender, EventArgs e)
		{
			click.Play();
			if (!DC.CheckOk())
			{
				LOG.Clear();
				LOG.AppendText("\n Дополнение не найдено \n Установите Python 2.7+\n");
				return;
			}
			lbl1.Text = " Waiting device";
			lbl1.Image = Resources.loading;
			DisableAll();
			Thread thread = new Thread((ThreadStart)delegate
			{
				int num = 30;
				while (true)
				{
					if (num < 0)
					{
						return;
					}
					D2.Detect();
					Thread.Sleep(1000);
					lbl1.Text = "Waiting " + num;
					if (D2.IsinAdb)
					{
						lbl1.Image = Resources.allowed_usb;
						try
						{
							CMD.General(DC.adb + "  reboot ", "");
							lbl1.Text = " adb reboot";
							info.Play();
						}
						catch
						{
							Enableall();
						}
						return;
					}
					if (D2.IsinFastboot)
					{
						try
						{
							CMD.General(DC.fastboot + "  reboot", "");
							info.Play();
							lbl1.Text = "fastboot reboot";
						}
						catch
						{
							Enableall();
						}
						return;
					}
					if (num == 0)
					{
						break;
					}
					num--;
				}
				Enableall();
				lbl1.Text = "waiting timeout";
				lbl1.Image = Resources.blocked_usb;
			});
			thread.IsBackground = true;
			thread.Start();
			while (thread.IsAlive)
			{
				Application.DoEvents();
			}
			Enableall();
			lbl1.Image = Resources.blocked_usb;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
		}

		private void activateToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void removeOldKEYToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void btnBootloaderUnlock_Click(object sender, EventArgs e)
		{
			click.Play();
			if (!DC.CheckOk())
			{
				LOG.Clear();
				LOG.AppendText("\n Дополнение не найдено \n Установите Python 2.7+\n");
			}
			else if (cbBootloaderUnlock.Text == "")
			{
				LOG.AppendText("Выберите модель\t\t", Color.White);
				LOG.AppendText("Ошибка (ModelNotSel)\n", Color.Red);
			}
			else
			{
				StartUnlock();
			}
		}

		private void cbBootloaderUnlock_SelectedIndexChanged(object sender, EventArgs e)
		{
			model = cbBootloaderUnlock.Text;
			info.Play();
		}

		private async void StartUnlock()
		{
			LOG.Clear();
			string localModel = cbBootloaderUnlock.Text;
			if (!File.Exists("data\\huawei\\bootloaderimage\\" + localModel))
			{
				LOG.AppendText(" Файл не найден \t\t", Color.White);
				LOG.AppendText("Ошибка (FileNotFound)\n", Color.Red);
				return;
			}
			LOG.AppendText("\n");
			LOG.AppendText("\n");
			LOG.AppendText(" Выбрана модель:\t");
			LOG.AppendText(localModel + Environment.NewLine);
			await Task.Delay(500);
			LOG.AppendText(" Поиск устройств:\t\t- ", Color.White);
			await Task.Delay(100);
			isFound = false;
			DisableAll();
			ConnectEdl();
			if (!isFound)
			{
				Enableall();
				Enableall();
				return;
			}
			LOG.AppendText("Устройство найдено:\n");
			await Task.Delay(100);
			LOG.AppendText(" Проверка загрузчика:\t");
			await Task.Delay(100);
			string_0 = "data\\huawei\\bootloaderimage\\" + localModel;
			if (!File.Exists(string_0))
			{
				LOG.AppendText("msimage missingError -", Color.Yellow);
				Enableall();
			}
			else
			{
				LOG.AppendText("Завершенно:\n", Color.WhiteSmoke);
				await Task.Delay(100);
				unlock();
			}
		}

		private async void unlock()
		{
			await Task.Delay(100);
			LOG.AppendText(" Копирование загрузчика:\t\t");
			await Task.Delay(100);
			MyClass.helper.DecryptFile(string_0, Current.temp + "\\image");
			await Task.Delay(100);
			if (!File.Exists(Current.temp + "\\image"))
			{
				LOG.AppendText(" Ошибка -", Color.Red);
				Enableall();
				return;
			}
			await Task.Delay(100);
			LOG.AppendText("Завершенно:\n");
			await Task.Delay(100);
			LOG.AppendText("Прошивка загрузчика:\t\t");
			wkFirehose = Calculate.firehose();
			Process edl = new Process();
			edl.StartInfo.FileName = DC.emmcdl;
			edl.StartInfo.CreateNoWindow = true;
			edl.StartInfo.UseShellExecute = false;
			edl.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
			edl.StartInfo.RedirectStandardOutput = true;
			edl.StartInfo.RedirectStandardError = true;
			edl.EnableRaisingEvents = false;
			edl.StartInfo.Arguments = " -p " + Comport + " -f  " + WorkingFirehose;
			edl.Start();
			edl.WaitForExit(2000);
			if (edl.StandardOutput.ReadToEnd().Contains("Status: 0 The operation completed successfully"))
			{
				await Task.Delay(100);
				LOG.AppendText("Завершенно:\n");
				await Task.Delay(100);
				LOG.AppendText(" Создание карты разделов:\t\t");
				Process process = new Process();
				process.StartInfo.FileName = DC.gdisk;
				process.StartInfo.CreateNoWindow = true;
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.WorkingDirectory = Current.temp;
				process.StartInfo.RedirectStandardOutput = true;
				process.StartInfo.RedirectStandardError = true;
				process.EnableRaisingEvents = false;
				process.StartInfo.Arguments = "   image   -l  ";
				process.Start();
				process.WaitForExit();
				string RESULT = process.StandardOutput.ReadToEnd();
				if (RESULT.Contains("GPT: not present"))
				{
					LOG.AppendText("GPT: Ошибка (BlockMapError or LoadRefusedCommand)\n", Color.Red);
					return;
				}
				await Task.Delay(100);
				LOG.AppendText("Завершенно:\n", Color.WhiteSmoke);
				int i = 1;
				using (StringReader Reader = new StringReader(RESULT))
				{
					while (Reader.Peek() != -1)
					{
						string line = Reader.ReadLine();
						if ((!line.StartsWith("   ") && !line.StartsWith("  1") && !line.StartsWith("  2") && !line.StartsWith("  3") && !line.StartsWith("  4") && !line.StartsWith("  5")) || (!line.ToLower().Contains("sbl") && !line.Contains("aboot")))
						{
							continue;
						}
						string[] raw = line.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
						raw[1] = "0x" + (Convert.ToInt32(raw[1]) * 512).ToString("X");
						raw[2] = "0x" + (Convert.ToInt32(raw[2]) * 512).ToString("X");
						string flashfile = raw[6].ToLower() + ".mbn";
						string partition = raw[6].ToLower();
						string backupfile = partition + ".bak";
						Process sfk = new Process();
						sfk.StartInfo.CreateNoWindow = true;
						sfk.StartInfo.UseShellExecute = false;
						sfk.StartInfo.WorkingDirectory = Current.temp;
						sfk.StartInfo.RedirectStandardOutput = true;
						sfk.StartInfo.RedirectStandardError = true;
						sfk.EnableRaisingEvents = false;
						sfk.StartInfo.FileName = DC.sfk;
						sfk.StartInfo.Arguments = " partcopy image -fromto  " + raw[1] + " " + raw[2] + " " + flashfile + "  -yes  ";
						sfk.Start();
						sfk.WaitForExit();
						LOG.AppendText(" раздел :" + i++ + "\n");
						edl.StartInfo.Arguments = " -p " + Comport + " -f data\\temp\\firehose.mbn -d " + partition + " -o data\\" + backupfile;
						await Task.Delay(100);
						LOG.AppendText(" Получение файла:\t\t");
						edl.Start();
						edl.WaitForExit(2000);
						if (edl.StandardOutput.ReadToEnd().Contains("Status: 0 The operation completed successfully"))
						{
							await Task.Delay(100);
							LOG.AppendText("Завершенно:\n", Color.WhiteSmoke);
						}
						else
						{
							await Task.Delay(100);
							LOG.AppendText(" Ошибка\n", Color.Red);
							await Task.Delay(100);
							LOG.AppendText(" что-то не так\n", Color.WhiteSmoke);
							LOG.AppendText(" Вы пробуете на угад? Модель не подходит ?\n", Color.WhiteSmoke);
							if (Directory.Exists(Current.temp))
							{
								DirectoryInfo di4 = new DirectoryInfo(Current.temp);
								di4.DeleteAll();
							}
						}
						edl.StartInfo.Arguments = " -p " + Comport + " -f data\\temp\\firehose.mbn -b " + partition + "  data\\temp\\" + flashfile;
						await Task.Delay(100);
						LOG.AppendText(" разблокировка:\t\t\t");
						edl.Start();
						edl.WaitForExit(2000);
						if (edl.StandardOutput.ReadToEnd().Contains("Status: 0 The operation completed successfully"))
						{
							await Task.Delay(100);
							LOG.AppendText("Завершенно:\n", Color.WhiteSmoke);
							continue;
						}
						await Task.Delay(100);
						LOG.AppendText(" Ошибка\n", Color.Red);
						await Task.Delay(100);
						LOG.AppendText(" Что-то не так\n", Color.Red);
						LOG.AppendText(" Вы пробуете на угад? Модель не подходит ?\n", Color.Red);
						if (Directory.Exists(Current.temp))
						{
							DirectoryInfo di3 = new DirectoryInfo(Current.temp);
							di3.DeleteAll();
						}
					}
					Reader.Close();
				}
				try
				{
					MyFile.Delete(Current.temp + "\\image");
				}
				catch
				{
					Enableall();
				}
				await Task.Delay(200);
				LOG.AppendText(" Разблокировано :\tУспешно\n", Color.WhiteSmoke);
				LOG.AppendText(" Перезагрузите устройство , устройство теперь должно быть разблокированно", Color.WhiteSmoke);
				if (Directory.Exists(Current.temp))
				{
					DirectoryInfo di2 = new DirectoryInfo(Current.temp);
					di2.DeleteAll();
				}
			}
			else
			{
				await Task.Delay(100);
				LOG.AppendText(" Ошибка\n", Color.Red);
				await Task.Delay(100);
				LOG.AppendText(" Что-то не так\n", Color.WhiteSmoke);
				LOG.AppendText(" Вы пробуете на угад? Модель не подходит ?\n", Color.WhiteSmoke);
				if (Directory.Exists(Current.temp))
				{
					DirectoryInfo di = new DirectoryInfo(Current.temp);
					di.DeleteAll();
				}
			}
		}

		private async void btnRepairOEM_Click(object sender, EventArgs e)
		{
			click.Play();
			if (!DC.CheckOk())
			{
				Enableall();
				LOG.Clear();
				LOG.AppendText("\n Дополнение не найдено \n Установите Python 2.7+\n");
				return;
			}
			LOG.Clear();
			string zip = "data\\huawei\\OEM.zip";
			string local_model = comboBox_0.Text;
			if (local_model == "")
			{
				LOG.AppendText(Environment.NewLine);
				LOG.AppendText(" Выберана модель" + local_model + Environment.NewLine);
				Enableall();
				return;
			}
			if (radioButton2.Checked)
			{
				LOG.AppendText("1- flash dload first\n2- fix Noti and Animation error");
			}
			_7zip.Extract(zip, local_model);
			try
			{
				File.Move(local_model, "data\\huawei\\" + local_model);
			}
			catch
			{
			}
			if (!File.Exists("data\\huawei\\" + local_model))
			{
				LOG.AppendText(Environment.NewLine);
				LOG.AppendText(" oem не найден " + local_model + Environment.NewLine);
				return;
			}
			LOG.AppendText(" Выбрана модель:\t\t", Color.White);
			LOG.AppendText(local_model + Environment.NewLine);
			LOG.AppendText(" Поиск устройств:\t\t", Color.White);
			await Task.Delay(100);
			isFound = false;
			DisableAll();
			ConnectEdl();
			if (!isFound)
			{
				Enableall();
				Enableall();
				MyFile.Delete("data\\huawei\\" + local_model);
				return;
			}
			if (M3.id == "")
			{
				LOG.AppendText(" Что-то не так переподключите устройство" + Environment.NewLine, Color.Red);
				Enableall();
				return;
			}
			LOG.AppendText("Устройство найдено:\n");
			lbl1.Image = Resources.allowed_usb;
			wkFirehose = Calculate.firehose();
			LOG.AppendText(" Процессор:\t\t", Color.White);
			LOG.AppendText(M3.id + Environment.NewLine);
			LOG.AppendText(" Порт обноружения:\t\t", Color.White);
			await Task.Delay(500);
			lbl1.Image = Resources.loading;
			string str = string.Empty;
			firehoseOK = false;
			FlashFirehose();
			if (!firehoseOK)
			{
				LOG.AppendText("Ошибка\n", Color.Red);
				Enableall();
				return;
			}
			LOG.AppendText("Завершенно:\n");
			LOG.AppendText(" ремонт\t\t\t");
			Thread thr2 = new Thread((ThreadStart)delegate
			{
				Process process = new Process();
				process.StartInfo.FileName = DC.emmcdl;
				process.StartInfo.CreateNoWindow = true;
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
				process.StartInfo.RedirectStandardOutput = true;
				process.StartInfo.RedirectStandardError = true;
				process.EnableRaisingEvents = false;
				process.StartInfo.Arguments = " -p " + Usb.COM + " -f " + WorkingFirehose + " -b oeminfo  data\\huawei\\" + local_model;
				process.Start();
				process.WaitForExit(4000);
				str = process.StandardOutput.ReadToEnd();
			});
			thr2.IsBackground = true;
			thr2.Start();
			while (thr2.IsAlive)
			{
				Application.DoEvents();
			}
			if (!str.Contains("Status: 0 The operation completed successfully"))
			{
				LOG.AppendText(" Ошибка\n", Color.Red);
				Enableall();
				MyFile.Delete("data\\huawei\\" + local_model);
				Enableall();
			}
			else
			{
				Enableall();
				MyFile.Delete("data\\huawei\\" + local_model);
				LOG.AppendText(" ремонт завершенн\n");
				lbl1.Text = "done";
				lbl1.Image = Resources.allowed_usb;
			}
		}

		private void LogMe(string string_1)
		{
			File.WriteAllText(Directory.GetCurrentDirectory() + "\\log_.txt", string_1, Encoding.Unicode);
		}

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (cBoxAuto1.Checked)
			{
				FirehoseSels.Enabled = false;
			}
			else
			{
				FirehoseSels.Enabled = true;
			}
		}

		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			info.Play();
			if (cBoxAuto1.Checked)
			{
				FirehoseSels.Enabled = false;
			}
			else
			{
				FirehoseSels.Enabled = true;
			}
		}

		private void cBoxAuto1_CheckedChanged(object sender, EventArgs e)
		{
			info.Play();
			if (cBoxAuto1.Checked)
			{
				FirehoseSels.Enabled = false;
			}
			else
			{
				FirehoseSels.Enabled = true;
			}
		}

		private void checkBoxBackupAll_CheckedChanged(object sender, EventArgs e)
		{
			click.Play();
		}

		private async void btnExtractFirmwareFromEmmc_Click(object sender, EventArgs e)
		{
			click.Play();
			DisableAll();
			string str = EmmcForExtract;
			if (!File.Exists(str))
			{
				Enableall();
				return;
			}
			FileInfo info = new FileInfo(str);
			if (info == null)
			{
				Enableall();
				return;
			}
			string location = info.DirectoryName;
			_ = info.Name;
			_ = string.Empty;
			foreach (ListViewItem item in listViewEmmc.Items)
			{
				Thread thr = new Thread((ThreadStart)delegate
				{
					lbl1.Text = "extracting:    " + item.SubItems[1].Text;
					SFK.PartCopy(EmmcForExtract, item.SubItems[2].Text, item.SubItems[3].Text, item.SubItems[1].Text);
				});
				thr.IsBackground = true;
				thr.Start();
				while (thr.IsAlive)
				{
					Application.DoEvents();
				}
			}
			lblPartition.Text = "files extract finish";
			await Task.Delay(500);
			string gpt = location + "\\gpt";
			if (File.Exists(gpt))
			{
				P1.partitionXML(gpt);
			}
			await Task.Delay(100);
			Enableall();
			LOG.AppendText("Прошивка создана\t\t"+"Успешно\n");
		}

		private void btnRawprogram0_Click(object sender, EventArgs e)
		{
			click.Play();
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Select your rawprogram0.xml ";
			openFileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
			openFileDialog.CheckFileExists = true;
			openFileDialog.CheckPathExists = true;
			openFileDialog.FilterIndex = 1;
			openFileDialog.RestoreDirectory = true;
			if (openFileDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			try
			{
				if (openFileDialog.OpenFile() != null)
				{
					txt_rawprogram0.Text = openFileDialog.FileName;
					rawprogram0XML = openFileDialog.FileName;
				}
			}
			catch
			{
				Enableall();
				LOG.AppendText("Не удаётся прочитать файл (FileInCorData or FileNotFoun) ");
			}
		}

		private void btnPath_Click(object sender, EventArgs e)
		{
			click.Play();
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Select your patch0.xml ";
			openFileDialog.Filter = "xml files (*.xml)|*.xml|All files (*.*)|*.*";
			openFileDialog.CheckFileExists = true;
			openFileDialog.CheckPathExists = true;
			openFileDialog.FilterIndex = 1;
			openFileDialog.RestoreDirectory = true;
			if (openFileDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			try
			{
				if (openFileDialog.OpenFile() != null)
				{
					txt_patch0.Text = openFileDialog.FileName;
					String_0 = openFileDialog.FileName;
				}
			}
			catch
			{
				Enableall();
				LOG.AppendText("Не удаётся прочитать файл (FileInCorData or FileNotFoun) ");
			}
		}

		private void btnFirehose_Click(object sender, EventArgs e)
		{
			click.Play();
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Select your programmer file ";
			openFileDialog.Filter = "mbn files (*.mbn)|*.mbn|All files (*.*)|*.*";
			openFileDialog.CheckFileExists = true;
			openFileDialog.CheckPathExists = true;
			openFileDialog.FilterIndex = 1;
			openFileDialog.RestoreDirectory = true;
			if (openFileDialog.ShowDialog() != DialogResult.OK)
			{
				return;
			}
			try
			{
				if (openFileDialog.OpenFile() != null)
				{
					FirehoseSels.Text = openFileDialog.FileName;
					wkFirehose = openFileDialog.FileName;
				}
			}
			catch
			{
				Enableall();
				LOG.AppendText("Не удаётся прочитать файл (FileInCorData or FileNotFoun) ");
			}
		}

		private void btnDownloadXML_Click(object sender, EventArgs e)
		{
			click.Play();
			if (!DC.CheckOk())
			{
				LOG.Clear();
				LOG.AppendText("\n Дополнение не найдено \n Установите Python 2.7+\n");
				return;
			}
			if (!File.Exists(txt_rawprogram0.Text))
			{
				LOG.AppendText("Выберите rawprogram0.xml\t\t", Color.White);
				LOG.AppendText("Ошибка (RawPrgNotSel)\n", Color.Red);
				return;
			}
			if (!File.Exists(txt_patch0.Text))
			{
				LOG.AppendText("Выберите patch0.xml\t\t", Color.White);
				LOG.AppendText("Hе критическая Ошибка (PatchNotSel)\n", Color.Red);
			}
			if (!File.Exists(FirehoseSels.Text))
			{
				LOG.AppendText("Выберите загрузчик\t\t", Color.White);
				LOG.AppendText("Ошибка (LoaderNotSel)\n", Color.Red);
				return;
			}
			btnDownloadXML.Enabled = false;
			LOG.AppendText(" Поиск устройств:\t\t", Color.White);
			isFound = false;
			DisableAll();
			ConnectEdl();
			if (!isFound)
			{
				Enableall();
				return;
			}
			LOG.AppendText("Устройство найдено:\n");
			wkFirehose = Calculate.firehose();
			LOG.AppendText(" Процессор:\t\t", Color.White);
			LOG.AppendText(M3.id + Environment.NewLine);
			LOG.AppendText(" Порт обноружения:\t\t", Color.White);
			LOG.AppendText(" Порт обноружения :\t", Color.White);
			wkFirehose = FirehoseSels.Text;
			firehoseOK = false;
			FlashFirehose();
			if (!firehoseOK)
			{
				LOG.AppendText("Ошибка\n", Color.Red);
				Enableall();
				return;
			}
			LOG.AppendText("Завершенно:\n");
			FileInfo fileInfo = new FileInfo(rawprogram0XML);
			wkFile = fileInfo.Name;
			wkDir = fileInfo.DirectoryName;
			SendCommand = " --port=\\\\.\\" + Usb.COM + " --sendxml=" + WorkingFile + " --loglevel=0 --noreset --noprompt --showpercentagecomplete --memoryname=eMMC ";
			pBar.Style = ProgressBarStyle.Marquee;
			if (!bw_WriteFirmware.IsBusy)
			{
				bw_WriteFirmware.RunWorkerAsync();
			}
		}

		public void WriteRawprogram0(string string_1, string string_2)
		{
			Process process = new Process();
			ProcessStartInfo processStartInfo = new ProcessStartInfo();
			processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			processStartInfo.FileName = DC.fh_loader;
			processStartInfo.WorkingDirectory = string_2;
			processStartInfo.Arguments = string_1;
			Console.WriteLine(string_1);
			processStartInfo.RedirectStandardOutput = true;
			processStartInfo.UseShellExecute = false;
			processStartInfo.CreateNoWindow = true;
			process.StartInfo = processStartInfo;
			process.OutputDataReceived += WriteRawprogram0DataReceiver;
			process.Start();
			process.BeginOutputReadLine();
			process.WaitForExit();
		}

		private void WriteRawprogram0DataReceiver(object sender, DataReceivedEventArgs e)
		{
			Console.WriteLine(e.Data);
			if (e.Data != null)
			{
				WriteRawprogram0updater(e.Data);
				Console.WriteLine(e.Data);
			}
		}

		private void WriteRawprogram0updater(string string_1)
		{
			if (!string_1.StartsWith("Writing log") & !string_1.StartsWith("Log") & !string_1.Contains("fh_loader.exe"))
			{
				try
				{
					bw_WriteFirmware.ReportProgress(0, string_1);
				}
				catch
				{
					Enableall();
				}
			}
		}

		private void bw_WriteFirmware_DoWork(object sender, DoWorkEventArgs e)
		{
			WriteRawprogram0(SendCommand, WorkingDir);
		}

		private void bw_WriteFirmware_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			LOG.Focus();
			LOG.AppendText((string)e.UserState + Environment.NewLine);
		}

		private void bw_WriteFirmware_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			if (txt_patch0.Text != "")
			{
				FileInfo fileInfo = new FileInfo(txt_patch0.Text);
				wkFile = fileInfo.Name;
				wkDir = fileInfo.DirectoryName;
				SendCommand = " --port=\\\\.\\" + Usb.COM + " --sendxml=" + wkFile + " --loglevel=0 --noreset --noprompt --showpercentagecomplete --memoryname=eMMC ";
				bw_WritePatch0.RunWorkerAsync();
			}
			else
			{
				LOG.AppendText(" Завершенно All" + Environment.NewLine);
				btnDownloadXML.Enabled = true;
				pBar.Style = ProgressBarStyle.Blocks;
				MyFile.Delete(WorkingDir + "\\port_trace.txt");
			}
		}

		public void WritePatch(string string_1, string string_2)
		{
			Process process = new Process();
			ProcessStartInfo processStartInfo = new ProcessStartInfo();
			processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			processStartInfo.FileName = DC.fh_loader;
			processStartInfo.WorkingDirectory = string_2;
			processStartInfo.Arguments = string_1;
			Console.WriteLine(string_1);
			processStartInfo.RedirectStandardOutput = true;
			processStartInfo.UseShellExecute = false;
			processStartInfo.CreateNoWindow = true;
			process.StartInfo = processStartInfo;
			process.OutputDataReceived += WritePatch0DataReceiver;
			process.Start();
			process.BeginOutputReadLine();
			process.WaitForExit();
		}

		private void WritePatch0DataReceiver(object sender, DataReceivedEventArgs e)
		{
			Console.WriteLine(e.Data);
			if (e.Data != null)
			{
				WritePatch0updater(e.Data);
				Console.WriteLine(e.Data);
			}
		}

		private void WritePatch0updater(string string_1)
		{
			if (!string_1.StartsWith("Writing log") & !string_1.StartsWith("Log") & !string_1.Contains("fh_loader.exe"))
			{
				try
				{
					bw_WritePatch0.ReportProgress(0, string_1);
				}
				catch
				{
					Enableall();
				}
			}
		}

		private void bw_WritePatch0_DoWork(object sender, DoWorkEventArgs e)
		{
			WritePatch(SendCommand, WorkingDir);
		}

		private void bw_WritePatch0_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			LOG.AppendText((string)e.UserState + Environment.NewLine);
		}

		private void bw_WritePatch0_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			LOG.AppendText(" Завершенно All" + Environment.NewLine);
			btnDownloadXML.Enabled = true;
			pBar.Style = ProgressBarStyle.Blocks;
			MyFile.Delete(WorkingDir + "\\port_trace.txt");
		}

		private void btnCheckMMC_Click(object sender, EventArgs e)
		{
			click.Play();
			richTextBoxMMC.Clear();
			comboBox_1.Items.Clear();
			foreach (string drive in M1.getDriveList())
			{
				if (drive.ToLower().Contains("qualcomm"))
				{
					string[] array = drive.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
					array[1].ToString();
					string text = drive;
					text = text.Substring(0, text.IndexOf(";"));
					string text2 = drive;
					text2 = text2.Substring(text2.IndexOf(";") + 1);
					text2 = text2.Substring(0, text2.IndexOf(","));
					comboBox_1.Items.Add(text2);
					string text3 = drive;
					text3 = text3.Substring(text3.IndexOf(",") + 1);
					text3 = text3.Substring(0, text3.IndexOf(":"));
					string text4 = drive;
					text4 = text4.Substring(text4.IndexOf(":") + 1);
					richTextBoxMMC.AppendText(" ID:\t- ", Color.White);
					richTextBoxMMC.AppendText(text2 + Environment.NewLine, Color.Yellow);
					richTextBoxMMC.AppendText(" MODEL:\t- ", Color.White);
					richTextBoxMMC.AppendText(text + Environment.NewLine);
					richTextBoxMMC.AppendText(" TYPE:\t- ", Color.White);
					richTextBoxMMC.AppendText(text3 + Environment.NewLine);
					richTextBoxMMC.AppendText(" SIZE:\t- ", Color.White);
					richTextBoxMMC.AppendText(text4 + Environment.NewLine);
					richTextBoxMMC.AppendText("\n");
				}
			}
			try
			{
				comboBox_1.SelectedIndex = 0;
			}
			catch
			{
				Enableall();
			}
		}

		private void comboBoxMMC_SelectedIndexChanged(object sender, EventArgs e)
		{
			info.Play();
		}

		private void button4_Click(object sender, EventArgs e)
		{
			click.Play();
			LOG.Clear();
			string text = null;
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Title = "Select your eMMC file..";
			openFileDialog.Filter = " All files (*.*)|*.*";
			openFileDialog.CheckFileExists = true;
			openFileDialog.CheckPathExists = true;
			openFileDialog.FilterIndex = 1;
			openFileDialog.RestoreDirectory = true;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				try
				{
					if (openFileDialog.OpenFile() != null)
					{
						text = openFileDialog.FileName;
						wkFile = openFileDialog.FileName;
						wkDir = Path.GetDirectoryName(openFileDialog.FileName);
						if (openFileDialog.SafeFileName.Contains(" "))
						{
							LOG.AppendText("Пожалуйста переименуйте копию разделов без проблеов\t\t", Color.White);
							LOG.AppendText("Ошибка (FileNameError)\n", Color.Red);
							btnEmmcDownloadFast.Enabled = false;
							Enableall();
							return;
						}
						btnEmmcDownloadFast.Enabled = true;
					}
				}
				catch
				{
					LOG.AppendText("Не удаётся прочитать файл (FileInCorData or FileNotFoun) \n");
					Enableall();
					Enableall();
					return;
				}
			}
			if (!File.Exists(text))
			{
				Enableall();
				return;
			}
			FileInfo fileInfo = new FileInfo(text);
			textBox_0.Text = text;
			LOG.AppendText("");
			LOG.AppendText(" Location:\t", Color.White);
			LOG.AppendText(WorkingDir + nline);
			LOG.AppendText(" Name:\t\t", Color.White);
			LOG.AppendText(fileInfo.Name + nline);
			LOG.AppendText(" Size:\t\t", Color.White);
			string text2 = MyClass.Myfiles.SizeConvertor(fileInfo.Length);
			LOG.AppendText(text2 + nline);
			LOG.AppendText(nline);
			tmWait.Enabled = true;
		}

		private void btnWrite9006_Click(object sender, EventArgs e)
		{
			click.Play();
			if (!DC.CheckOk())
			{
				LOG.Clear();
				LOG.AppendText("\n Дополнение не найдено \n Установите Python 2.7+\n");
			}
			else if (!(comboBox_1.Text == ""))
			{
				string[] array = comboBox_1.Text.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
				string text = array[1].ToString();
				FileInfo fileInfo = new FileInfo(WorkingFile);
				string name = fileInfo.Name;
				SendCommand = " w " + text + " " + name;
				_9006Class.Write(text, textBox_0.Text);
			}
		}

		private void method_0()
		{
			try
			{
				Process process = new Process();
				ProcessStartInfo processStartInfo = new ProcessStartInfo();
				processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				processStartInfo.FileName = DC.mmc;
				processStartInfo.WorkingDirectory = WorkingDir;
				processStartInfo.Arguments = SendCommand;
				Console.WriteLine(SendCommand);
				processStartInfo.RedirectStandardOutput = true;
				processStartInfo.UseShellExecute = false;
				processStartInfo.CreateNoWindow = true;
				process.StartInfo = processStartInfo;
				process.ErrorDataReceived += _9006Receiver;
				process.OutputDataReceived += _9006Receiver;
				process.Start();
				process.BeginOutputReadLine();
				process.WaitForExit();
			}
			catch
			{
				Enableall();
			}
		}

		private void _9006Receiver(object sender, DataReceivedEventArgs e)
		{
			Console.WriteLine(e.Data);
			if (e.Data != null && (!e.Data.StartsWith("Writing log") & !e.Data.StartsWith("Log") & !e.Data.Contains("fh_loader.exe")))
			{
				update("====================================\n  " + time + " " + e.Data + "\r\n====================================\n");
				Console.WriteLine(e.Data);
			}
		}

		private void facebookProfileToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				Process.Start("https://web.facebook.com/kyawkyarnyu");
			}
			catch
			{
				Enableall();
			}
		}

		private void facebookPageToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				Process.Start("https://web.facebook.com/mppgmdy");
			}
			catch
			{
				Enableall();
			}
		}

		private void weblinkToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				Process.Start("http://www.mppgmyanmar.com/");
			}
			catch
			{
				Enableall();
			}
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			try
			{
				Environment.Exit(0);
				Application.Exit();
			}
			catch
			{
				Enableall();
			}
		}

		private void btnSplit_Click(object sender, EventArgs e)
		{
			click.Play();
			if (File.Exists(txtEmmcLoad.Text) && !(comboBox2.Text == ""))
			{
				groupBoxEmmc.Enabled = false;
				LOG.AppendText("\n Spliting eMMC file:\t\t\t", Color.Red);
				Process sfk = new Process();
				sfk.StartInfo.CreateNoWindow = true;
				sfk.StartInfo.UseShellExecute = false;
				sfk.StartInfo.WorkingDirectory = WorkingDir;
				sfk.StartInfo.RedirectStandardOutput = true;
				sfk.StartInfo.RedirectStandardError = true;
				sfk.EnableRaisingEvents = false;
				sfk.StartInfo.FileName = DC.sfk;
				string arguments = " partcopy " + SafeNameOf(WorkingFile) + " 0 " + comboBox2.Text + " " + comboBox2.Text + ".bin   -yes  ";
				sfk.StartInfo.Arguments = arguments;
				string rst = "";
				Thread thread = new Thread((ThreadStart)delegate
				{
					sfk.Start();
					sfk.WaitForExit();
					rst = sfk.StandardOutput.ReadToEnd();
				});
				thread.IsBackground = true;
				thread.Start();
				while (thread.IsAlive)
				{
					groupBoxEmmc.Enabled = false;
					Application.DoEvents();
				}
				groupBoxEmmc.Enabled = true;
				LOG.AppendText(rst + Environment.NewLine);
				LOG.AppendText(" Расположение файла:\t\t\t\t-  ", Color.White);
				LOG.AppendText(WorkingDir + "\n");
				txtEmmcLoad.Text = WorkingFile;
				EmmcForExtract = WorkingFile;
				LOG.AppendText(" Имя файла:\t\t\t\t-  ", Color.White);
				LOG.AppendText(comboBox2.Text + ".bin\n");
				LOG.AppendText(" Размер файла:\t\t\t\t\t- ", Color.White);
				LOG.AppendText((WorkingDir + "\\" + comboBox2.Text + ".bin").size() + "\n");
			}
		}

		private void cleanAdbToolStripMenuItem_Click(object sender, EventArgs e)
		{
			click.Play();
			CleanADB();
		}

		private void CleanADB()
		{
			lbl1.Text = "Cleaning Adb Service";
			Adb.KillServer();
			List<string> list = new List<string>
			{
				"fastboot", "fastboot_edl", "adb", "root", "romaster_daemon", "ShuameDaemon", "shuame_helper", "AndroidInterface", "MzwInstaller", "MzwDownload",
				"Shuame", "MoboroboDeviceService", "HiSuite", "RomasterPC", "FileTransfer", "Kies", "KiesUpdate", "KiesTrayAgent", "MobileGo", "MobileGoService",
				"Moborobo", "MoboRoboDeviceService", "MobileGoService", "WSHelper", "RomasterPC", "RomasterConnection", "SRS-One-Click-Root", "RescueTool", "UnlockTool", "MiPhoneHelper",
				"MiPhoneManager", "SuperFlash", "KingRoot"
			};
			foreach (string item in list)
			{
				Process[] processesByName = Process.GetProcessesByName(item);
				int index = 0;
				if (processesByName.Length == 0)
				{
					continue;
				}
				Thread thread = new Thread((ThreadStart)checked(delegate
				{
					try
					{
						processesByName[index].Kill();
						index++;
					}
					catch
					{
						Enableall();
					}
				}));
				thread.IsBackground = true;
				thread.Start();
				while (thread.IsAlive)
				{
					Application.DoEvents();
				}
			}
			lbl1.Text = "Done";
			lbl1.Image = Resources.blocked_usb;
		}

		private void cleanQualcommServiceToolStripMenuItem_Click(object sender, EventArgs e)
		{
			click.Play();
			CleanQualcomm();
		}

		private void CleanQualcomm()
		{
			lbl1.Text = "Cleaning Qualcomm Service";
			List<string> list = new List<string> { "emmcdl.exe", "fh_loader", "QPST.exe", "QSaharaServer.exe" };
			foreach (string item in list)
			{
				Process[] processesByName = Process.GetProcessesByName(item);
				int index = 0;
				if (processesByName.Length == 0)
				{
					continue;
				}
				Thread thread = new Thread((ThreadStart)checked(delegate
				{
					try
					{
						processesByName[index].Kill();
						index++;
					}
					catch
					{
						Enableall();
					}
				}));
				thread.IsBackground = true;
				thread.Start();
				while (thread.IsAlive)
				{
					Application.DoEvents();
				}
			}
			lbl1.Text = "Done";
			lbl1.Image = Resources.blocked_usb;
		}

		private void cleanAllToolStripMenuItem_Click(object sender, EventArgs e)
		{
			click.Play();
			CleanQualcomm();
			CleanADB();
		}

		private void deviceManagerToolStripMenuItem_Click(object sender, EventArgs e)
		{
			click.Play();
			O1.RUN("devmgmt.msc", "");
		}

		private void rbScan_CheckedChanged(object sender, EventArgs e)
		{
			click.Play();
			rbBackup.Checked = false;
			rbFormat.Checked = false;
			rbWrite.Checked = false;
		}

		private void rbBackup_CheckedChanged(object sender, EventArgs e)
		{
			click.Play();
			rbWrite.Checked = false;
			rbFormat.Checked = false;
			rbScan.Checked = false;
		}

		private void rbFormat_CheckedChanged(object sender, EventArgs e)
		{
			click.Play();
			rbBackup.Checked = false;
			rbWrite.Checked = false;
			rbScan.Checked = false;
		}

		private void rbWrite_CheckedChanged(object sender, EventArgs e)
		{
			click.Play();
			rbBackup.Checked = false;
			rbFormat.Checked = false;
			rbScan.Checked = false;
		}

		private async void buttonReboot_Click(object sender, EventArgs e)
		{
			if (rnormal.Checked)
			{
				LOG.Clear();
				LOG.AppendText("\n Перезагрузка в систему\n");
				LOG.AppendText("\n Закрытие/открытие Adb службы\n");
				CleanADB();
				LOG.AppendText("\n Обноружение устройства\t");
				R1.Normal();
				while (!R1.ok)
				{
					await Task.Delay(1000);
					lbl1.Text = R1.rst;
				}
			}
			else if (rbootloader.Checked)
			{
				LOG.Clear();
				LOG.AppendText("\n Перезагрузка в Загрузчик\n");
				LOG.AppendText("\n Закрытие/открытие Adb службы\n");
				CleanADB();
			}
			else if (r9006.Checked)
			{
				LOG.Clear();
				LOG.AppendText("\n user selected option to boot 9006\n");
				LOG.AppendText("\n Cleaning Qualcomm Services\n");
				CleanQualcomm();
			}
			else if (r9008.Checked)
			{
				LOG.Clear();
				LOG.AppendText("\n user selected option to boot 9008\n");
				LOG.AppendText("\n Cleaning Qualcomm Services\n");
				CleanQualcomm();
			}
			else
			{
				LOG.Clear();
				LOG.AppendText("\n Please Select Any Option\n");
				Enableall();
			}
		}

		private async void btn9008To9006_Click_1(object sender, EventArgs e)
		{
			click.Play();
			if (!DC.CheckOk())
			{
				LOG.Clear();
				LOG.AppendText("\n Дополнение не найдено \n Установите Python 2.7+\n");
				return;
			}
			DisableAll();
			LOG.Clear();
			_ = string.Empty;
			string dir = "data\\9006\\" + comboBox9008To9006.Text;
			LOG.AppendText(" Selected Chipset:\t\t", Color.White);
			LOG.AppendText(comboBox9008To9006.Text + Environment.NewLine, Color.Yellow);
			LOG.AppendText(" Поиск устройств:\t\t", Color.White);
			isFound = false;
			ConnectEdl();
			if (!isFound)
			{
				Enableall();
				return;
			}
			LOG.AppendText(" Открытый порт:\t\t" + Usb.Port + Environment.NewLine);
			wkFirehose = Calculate.firehose();
			LOG.AppendText(" Процессор:\t\t", Color.White);
			LOG.AppendText(M3.id + Environment.NewLine);
			LOG.AppendText(" Порт обноружения:\t\t", Color.White);
			LOG.AppendText(" Downloading bootloader...\t", Color.White);
			lbl1.Text = " bootloader downloading";
			string s = R1._9006(Usb.COM, dir);
			LOG.AppendText(s + "\n");
			lbl1.Text = "";
			if (s.Contains("error"))
			{
				Enableall();
			}
			int i = 10;
			while (i >= 0)
			{
				D2.Detect();
				await Task.Delay(1000);
				if (!D2.Isin9006)
				{
					i--;
					continue;
				}
				Enableall();
				LOG.AppendText(" Device connected in 9006 mode\n", Color.White);
				info.Play();
				break;
			}
			Enableall();
		}

		private void btnEDL_Click_1(object sender, EventArgs e)
		{
			click.Play();
			if (!DC.CheckOk())
			{
				LOG.Clear();
				LOG.AppendText("\n Дополнение не найдено \n Установите Python 2.7+\n");
				return;
			}
			DisableAll();
			lbl1.Text = " Waiting device";
			lbl1.Image = Resources.loading;
			Thread thread = new Thread((ThreadStart)delegate
			{
				int num = 20;
				while (true)
				{
					if (num < 0)
					{
						return;
					}
					Thread.Sleep(1000);
					if (R1.Edl() == "OK")
					{
						lbl1.Text = " Done";
						lbl1.Image = Resources.blocked_usb;
						info.Play();
						return;
					}
					if (num == 0)
					{
						break;
					}
					lbl1.Text = " Waiting " + num;
					num--;
				}
				Enableall();
				lbl1.Text = " Waiting timeout";
				lbl1.Image = Resources.blocked_usb;
			});
			thread.IsBackground = true;
			thread.Start();
			while (thread.IsAlive)
			{
				Application.DoEvents();
			}
			Enableall();
		}

		private void button5_Click(object sender, EventArgs e)
		{
			Usb.Detect();
			if (!Usb.IsConnected)
			{
				LOG.AppendText("Проверьте драйвера или usb кабель.\nУстройство не найдено\t\t", Color.White);
				LOG.AppendText("Ошибка (NoFoundDevice)\n", Color.Red);
			}
			else if (M3.id != "")
			{
				LOG.AppendText("Устройство определенно как: \t\t"+M3.O+M3.id);
			}
			else
			{
				LOG.AppendText("Неудаётся определить тип процессора");
			}
		}

		private void button6_Click(object sender, EventArgs e)
		{
			X1.Unlock(comboBox3.SelectedText);
		}

		private void registrationToolStripMenuItem_Click(object sender, EventArgs e)
		{
		}

		private void removeOldKeyToolStripMenuItem1_Click(object sender, EventArgs e)
		{

		}

		private void activateNowToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}

		private void removeOldKeyToolStripMenuItem_Click_1(object sender, EventArgs e)
		{

		}

		private void youtubeToolStripMenuItem_Click(object sender, EventArgs e)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(M));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lbl1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBoxEmmc = new System.Windows.Forms.GroupBox();
            this.btnSplit = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.btnFlashEmmcToDevice = new System.Windows.Forms.Button();
            this.btnExtractFirmwareFromEmmc = new System.Windows.Forms.Button();
            this.btnEmmcToFirmware = new System.Windows.Forms.Button();
            this.statusStrip3 = new System.Windows.Forms.StatusStrip();
            this.lblPartition = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnBrowseEmmc = new System.Windows.Forms.Button();
            this.txtEmmcLoad = new System.Windows.Forms.TextBox();
            this.listViewEmmc = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBoxREBOOTER = new System.Windows.Forms.GroupBox();
            this.buttonReboot = new System.Windows.Forms.Button();
            this.rnormal = new System.Windows.Forms.RadioButton();
            this.rbootloader = new System.Windows.Forms.RadioButton();
            this.r9008 = new System.Windows.Forms.RadioButton();
            this.r9006 = new System.Windows.Forms.RadioButton();
            this.groupBoxReboot = new System.Windows.Forms.GroupBox();
            this.groupBoxN_Reboot = new System.Windows.Forms.GroupBox();
            this.btnNormalReboot = new System.Windows.Forms.Button();
            this.groupBox_1 = new System.Windows.Forms.GroupBox();
            this.btnEDL = new System.Windows.Forms.Button();
            this.groupBox9006 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btn9008To9006 = new System.Windows.Forms.Button();
            this.comboBox9008To9006 = new System.Windows.Forms.ComboBox();
            this.groupBoxFirmwareRead = new System.Windows.Forms.GroupBox();
            this.btnBackupFirmware = new System.Windows.Forms.Button();
            this.groupBoxFirmwareWrite = new System.Windows.Forms.GroupBox();
            this.btnDownloadXML = new System.Windows.Forms.Button();
            this.btnPath = new System.Windows.Forms.Button();
            this.btnRawprogram0 = new System.Windows.Forms.Button();
            this.txt_patch0 = new System.Windows.Forms.TextBox();
            this.txt_rawprogram0 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnRepairOEM = new System.Windows.Forms.Button();
            this.groupBox_0 = new System.Windows.Forms.GroupBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox_0 = new System.Windows.Forms.ComboBox();
            this.groupBoxDloadFlasher = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.btnCreateBoard = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtDload = new System.Windows.Forms.TextBox();
            this.btnDownloadDload = new System.Windows.Forms.Button();
            this.groupBoxBootloaerUnlock = new System.Windows.Forms.GroupBox();
            this.btnBootloaderUnlock = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.cbBootloaderUnlock = new System.Windows.Forms.ComboBox();
            this.groupBoxBoardFirmware = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnDownloadBoardFirmware = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox_2 = new System.Windows.Forms.GroupBox();
            this.pBarEmmcDump = new System.Windows.Forms.ProgressBar();
            this.label19 = new System.Windows.Forms.Label();
            this.richTextBoxMMC = new System.Windows.Forms.RichTextBox();
            this.comboBox_1 = new System.Windows.Forms.ComboBox();
            this.button_0 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_0 = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.btnWrite9006 = new System.Windows.Forms.Button();
            this.cBoxAuto1 = new System.Windows.Forms.CheckBox();
            this.groupBoxBlock0Write = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnEmmcDownloadFast = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtEmmc = new System.Windows.Forms.TextBox();
            this.btnEmmcSelect = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBoxBlock0Read = new System.Windows.Forms.GroupBox();
            this.btnAdbRead = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtEmmcSaveLocation = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.btnDumpEmmc = new System.Windows.Forms.Button();
            this.FirehoseSels = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.rbWrite = new System.Windows.Forms.RadioButton();
            this.rbFormat = new System.Windows.Forms.RadioButton();
            this.rbBackup = new System.Windows.Forms.RadioButton();
            this.rbScan = new System.Windows.Forms.RadioButton();
            this.checkBoxBackupAll = new System.Windows.Forms.CheckBox();
            this.btnDoJobForBackupRestore = new System.Windows.Forms.Button();
            this.listViewBackupRestore = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageSmall = new System.Windows.Forms.ImageList(this.components);
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.imageList3 = new System.Windows.Forms.ImageList(this.components);
            this.LOG = new System.Windows.Forms.RichTextBox();
            this.bwDownload_eMMC = new System.ComponentModel.BackgroundWorker();
            this.bwMain = new System.ComponentModel.BackgroundWorker();
            this.bwFlashDload = new System.ComponentModel.BackgroundWorker();
            this.bwFlashFile = new System.ComponentModel.BackgroundWorker();
            this.bwEmmcdl = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblActivated = new System.Windows.Forms.Label();
            this.tmWait = new System.Windows.Forms.Timer(this.components);
            this.bwFirmwareMaker = new System.ComponentModel.BackgroundWorker();
            this.bw_WriteFirmware = new System.ComponentModel.BackgroundWorker();
            this.bw_WritePatch0 = new System.ComponentModel.BackgroundWorker();
            this.tabControl5 = new System.Windows.Forms.TabControl();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.tabPage9 = new System.Windows.Forms.TabPage();
            this.help = new System.Windows.Forms.RichTextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.bw_Write9006 = new System.ComponentModel.BackgroundWorker();
            this.bwReadAdb = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cleanerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cleanAdbToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cleanQualcommServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cleanAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guideToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.huaweiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boardFirmwareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.boardFirmwareCreateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dloadFlasherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bootloaderUnlockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.networkUnlockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.qualcommToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.block0BackupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.block0FlasherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.firmwareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.writeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eMMCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deviceManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button7 = new System.Windows.Forms.Button();
            this.q1 = new System.Windows.Forms.Panel();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.q2 = new System.Windows.Forms.Panel();
            this.groupBoxBackupRestore = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.q3 = new System.Windows.Forms.Panel();
            this.button10 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.q4 = new System.Windows.Forms.Panel();
            this.q5 = new System.Windows.Forms.Panel();
            this.button12 = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.groupBoxEmmc.SuspendLayout();
            this.statusStrip3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBoxREBOOTER.SuspendLayout();
            this.groupBoxReboot.SuspendLayout();
            this.groupBoxN_Reboot.SuspendLayout();
            this.groupBox_1.SuspendLayout();
            this.groupBox9006.SuspendLayout();
            this.groupBoxFirmwareRead.SuspendLayout();
            this.groupBoxFirmwareWrite.SuspendLayout();
            this.groupBox_0.SuspendLayout();
            this.groupBoxDloadFlasher.SuspendLayout();
            this.groupBoxBootloaerUnlock.SuspendLayout();
            this.groupBoxBoardFirmware.SuspendLayout();
            this.groupBox_2.SuspendLayout();
            this.groupBoxBlock0Write.SuspendLayout();
            this.groupBoxBlock0Read.SuspendLayout();
            this.tabControl5.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.tabPage9.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.q1.SuspendLayout();
            this.q2.SuspendLayout();
            this.groupBoxBackupRestore.SuspendLayout();
            this.q3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.q4.SuspendLayout();
            this.q5.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbl1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 564);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1134, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lbl1
            // 
            this.lbl1.BackColor = System.Drawing.SystemColors.Control;
            this.lbl1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl1.Image = global::QFlashTool.Properties.Resources.blocked_usb;
            this.lbl1.Name = "lbl1";
            this.lbl1.Size = new System.Drawing.Size(16, 17);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icon-settings.png");
            this.imageList1.Images.SetKeyName(1, "download.png");
            this.imageList1.Images.SetKeyName(2, "openFolder.png");
            this.imageList1.Images.SetKeyName(3, "refresh-32.png");
            this.imageList1.Images.SetKeyName(4, "hu.png");
            this.imageList1.Images.SetKeyName(5, "Qcom.png");
            this.imageList1.Images.SetKeyName(6, "eMMC.png");
            this.imageList1.Images.SetKeyName(7, "698925-icon-92-inbox-download-512.png");
            this.imageList1.Images.SetKeyName(8, "upload-2-xxl.png");
            this.imageList1.Images.SetKeyName(9, "backup-restore.png");
            this.imageList1.Images.SetKeyName(10, "android-icon17.png");
            this.imageList1.Images.SetKeyName(11, "Xiaomi_logo_Mi.png");
            // 
            // groupBoxEmmc
            // 
            this.groupBoxEmmc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxEmmc.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxEmmc.Controls.Add(this.btnSplit);
            this.groupBoxEmmc.Controls.Add(this.comboBox2);
            this.groupBoxEmmc.Controls.Add(this.btnFlashEmmcToDevice);
            this.groupBoxEmmc.Controls.Add(this.btnExtractFirmwareFromEmmc);
            this.groupBoxEmmc.Controls.Add(this.btnEmmcToFirmware);
            this.groupBoxEmmc.Controls.Add(this.statusStrip3);
            this.groupBoxEmmc.Controls.Add(this.btnBrowseEmmc);
            this.groupBoxEmmc.Controls.Add(this.txtEmmcLoad);
            this.groupBoxEmmc.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxEmmc.ForeColor = System.Drawing.Color.White;
            this.groupBoxEmmc.Location = new System.Drawing.Point(10, 354);
            this.groupBoxEmmc.Name = "groupBoxEmmc";
            this.groupBoxEmmc.Size = new System.Drawing.Size(652, 105);
            this.groupBoxEmmc.TabIndex = 2;
            this.groupBoxEmmc.TabStop = false;
            this.groupBoxEmmc.Text = "eMMC Распаковка";
            // 
            // btnSplit
            // 
            this.btnSplit.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnSplit.BackgroundImage")));
            this.btnSplit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSplit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSplit.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSplit.ForeColor = System.Drawing.Color.Black;
            this.btnSplit.Location = new System.Drawing.Point(235, 51);
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(120, 26);
            this.btnSplit.TabIndex = 10;
            this.btnSplit.Text = "Объединить";
            this.btnSplit.UseVisualStyleBackColor = true;
            this.btnSplit.Click += new System.EventHandler(this.btnSplit_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "512M",
            "1G",
            "2G",
            "3G",
            "4G"});
            this.comboBox2.Location = new System.Drawing.Point(6, 52);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(223, 26);
            this.comboBox2.TabIndex = 9;
            // 
            // btnFlashEmmcToDevice
            // 
            this.btnFlashEmmcToDevice.BackColor = System.Drawing.Color.White;
            this.btnFlashEmmcToDevice.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnFlashEmmcToDevice.BackgroundImage")));
            this.btnFlashEmmcToDevice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFlashEmmcToDevice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFlashEmmcToDevice.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnFlashEmmcToDevice.ForeColor = System.Drawing.Color.Black;
            this.btnFlashEmmcToDevice.Location = new System.Drawing.Point(552, 18);
            this.btnFlashEmmcToDevice.Name = "btnFlashEmmcToDevice";
            this.btnFlashEmmcToDevice.Size = new System.Drawing.Size(96, 60);
            this.btnFlashEmmcToDevice.TabIndex = 8;
            this.btnFlashEmmcToDevice.Text = "Прошить выбранное";
            this.btnFlashEmmcToDevice.UseVisualStyleBackColor = true;
            this.btnFlashEmmcToDevice.Click += new System.EventHandler(this.btnFlashEmmcToDevice_Click_1);
            // 
            // btnExtractFirmwareFromEmmc
            // 
            this.btnExtractFirmwareFromEmmc.BackColor = System.Drawing.Color.White;
            this.btnExtractFirmwareFromEmmc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnExtractFirmwareFromEmmc.BackgroundImage")));
            this.btnExtractFirmwareFromEmmc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExtractFirmwareFromEmmc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExtractFirmwareFromEmmc.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnExtractFirmwareFromEmmc.ForeColor = System.Drawing.Color.Black;
            this.btnExtractFirmwareFromEmmc.Location = new System.Drawing.Point(361, 51);
            this.btnExtractFirmwareFromEmmc.Name = "btnExtractFirmwareFromEmmc";
            this.btnExtractFirmwareFromEmmc.Size = new System.Drawing.Size(188, 26);
            this.btnExtractFirmwareFromEmmc.TabIndex = 7;
            this.btnExtractFirmwareFromEmmc.Text = "Распаковать прошивку";
            this.btnExtractFirmwareFromEmmc.UseVisualStyleBackColor = true;
            this.btnExtractFirmwareFromEmmc.Click += new System.EventHandler(this.btnExtractFirmwareFromEmmc_Click);
            // 
            // btnEmmcToFirmware
            // 
            this.btnEmmcToFirmware.BackColor = System.Drawing.Color.White;
            this.btnEmmcToFirmware.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEmmcToFirmware.BackgroundImage")));
            this.btnEmmcToFirmware.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmmcToFirmware.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmmcToFirmware.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEmmcToFirmware.ForeColor = System.Drawing.Color.Black;
            this.btnEmmcToFirmware.Location = new System.Drawing.Point(361, 18);
            this.btnEmmcToFirmware.Name = "btnEmmcToFirmware";
            this.btnEmmcToFirmware.Size = new System.Drawing.Size(188, 27);
            this.btnEmmcToFirmware.TabIndex = 6;
            this.btnEmmcToFirmware.Text = "Распаковать разделы";
            this.btnEmmcToFirmware.UseVisualStyleBackColor = true;
            this.btnEmmcToFirmware.Click += new System.EventHandler(this.btnEmmcToFirmware_Click);
            // 
            // statusStrip3
            // 
            this.statusStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblPartition});
            this.statusStrip3.Location = new System.Drawing.Point(3, 80);
            this.statusStrip3.Name = "statusStrip3";
            this.statusStrip3.Size = new System.Drawing.Size(646, 22);
            this.statusStrip3.TabIndex = 5;
            this.statusStrip3.Text = "statusStrip3";
            // 
            // lblPartition
            // 
            this.lblPartition.BackColor = System.Drawing.Color.Transparent;
            this.lblPartition.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPartition.ForeColor = System.Drawing.Color.Black;
            this.lblPartition.Name = "lblPartition";
            this.lblPartition.Size = new System.Drawing.Size(52, 17);
            this.lblPartition.Text = "partition";
            // 
            // btnBrowseEmmc
            // 
            this.btnBrowseEmmc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBrowseEmmc.BackgroundImage")));
            this.btnBrowseEmmc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBrowseEmmc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBrowseEmmc.Font = new System.Drawing.Font("Arial Black", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBrowseEmmc.ForeColor = System.Drawing.Color.Black;
            this.btnBrowseEmmc.Location = new System.Drawing.Point(235, 18);
            this.btnBrowseEmmc.Name = "btnBrowseEmmc";
            this.btnBrowseEmmc.Size = new System.Drawing.Size(120, 27);
            this.btnBrowseEmmc.TabIndex = 3;
            this.btnBrowseEmmc.Text = "Открыть";
            this.btnBrowseEmmc.UseVisualStyleBackColor = true;
            this.btnBrowseEmmc.Click += new System.EventHandler(this.btnBrowseEmmc_Click);
            // 
            // txtEmmcLoad
            // 
            this.txtEmmcLoad.BackColor = System.Drawing.Color.White;
            this.txtEmmcLoad.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmmcLoad.Location = new System.Drawing.Point(6, 19);
            this.txtEmmcLoad.Multiline = true;
            this.txtEmmcLoad.Name = "txtEmmcLoad";
            this.txtEmmcLoad.ReadOnly = true;
            this.txtEmmcLoad.Size = new System.Drawing.Size(224, 22);
            this.txtEmmcLoad.TabIndex = 2;
            // 
            // listViewEmmc
            // 
            this.listViewEmmc.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewEmmc.BackColor = System.Drawing.Color.Teal;
            this.listViewEmmc.CheckBoxes = true;
            this.listViewEmmc.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listViewEmmc.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listViewEmmc.ForeColor = System.Drawing.Color.White;
            this.listViewEmmc.FullRowSelect = true;
            this.listViewEmmc.HideSelection = false;
            this.listViewEmmc.Location = new System.Drawing.Point(10, 9);
            this.listViewEmmc.Name = "listViewEmmc";
            this.listViewEmmc.Size = new System.Drawing.Size(652, 346);
            this.listViewEmmc.TabIndex = 0;
            this.listViewEmmc.UseCompatibleStateImageBehavior = false;
            this.listViewEmmc.View = System.Windows.Forms.View.Details;
            this.listViewEmmc.SelectedIndexChanged += new System.EventHandler(this.listViewEmmc_SelectedIndexChanged);
            this.listViewEmmc.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewEmmc_MouseClick);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "№";
            this.columnHeader3.Width = 0;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Раздел";
            this.columnHeader4.Width = 114;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Начало раздела";
            this.columnHeader5.Width = 197;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Конец раздела";
            this.columnHeader6.Width = 191;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Размер";
            this.columnHeader7.Width = 145;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox3);
            this.groupBox2.Controls.Add(this.button6);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(10, 209);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(308, 100);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Удаленние аккаунта XIAOMI";
            this.groupBox2.Visible = false;
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Mi 4C",
            "Mi 4S",
            "Mi 5",
            "Mi Max 32 GB",
            "Mi Max 64 128 GB",
            "Mi Note",
            "Mi Note Pro",
            "Redmi 3",
            "Redmi 3 Pro",
            "Redmi 3S",
            "Redmi 3X",
            "Redmi Note 3 Pro"});
            this.comboBox3.Location = new System.Drawing.Point(22, 40);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(171, 26);
            this.comboBox3.TabIndex = 3;
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button6.BackgroundImage = global::Properties.Resources._11;
            this.button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button6.ForeColor = System.Drawing.Color.Black;
            this.button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button6.Location = new System.Drawing.Point(210, 40);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(82, 26);
            this.button6.TabIndex = 21;
            this.button6.Text = "Удалить";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label15.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label15.Location = new System.Drawing.Point(19, 19);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(93, 18);
            this.label15.TabIndex = 7;
            this.label15.Text = "Устройство";
            // 
            // groupBoxREBOOTER
            // 
            this.groupBoxREBOOTER.Controls.Add(this.buttonReboot);
            this.groupBoxREBOOTER.Controls.Add(this.rnormal);
            this.groupBoxREBOOTER.Controls.Add(this.rbootloader);
            this.groupBoxREBOOTER.Controls.Add(this.r9008);
            this.groupBoxREBOOTER.Controls.Add(this.r9006);
            this.groupBoxREBOOTER.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxREBOOTER.ForeColor = System.Drawing.Color.White;
            this.groupBoxREBOOTER.Location = new System.Drawing.Point(10, 315);
            this.groupBoxREBOOTER.Name = "groupBoxREBOOTER";
            this.groupBoxREBOOTER.Size = new System.Drawing.Size(308, 100);
            this.groupBoxREBOOTER.TabIndex = 6;
            this.groupBoxREBOOTER.TabStop = false;
            this.groupBoxREBOOTER.Text = "Перезагрузить";
            // 
            // buttonReboot
            // 
            this.buttonReboot.BackgroundImage = global::Properties.Resources._11;
            this.buttonReboot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonReboot.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonReboot.ForeColor = System.Drawing.Color.Black;
            this.buttonReboot.Location = new System.Drawing.Point(39, 46);
            this.buttonReboot.Name = "buttonReboot";
            this.buttonReboot.Size = new System.Drawing.Size(214, 42);
            this.buttonReboot.TabIndex = 4;
            this.buttonReboot.Text = "Перезагрузить";
            this.buttonReboot.UseVisualStyleBackColor = true;
            this.buttonReboot.Click += new System.EventHandler(this.buttonReboot_Click);
            // 
            // rnormal
            // 
            this.rnormal.AutoSize = true;
            this.rnormal.Location = new System.Drawing.Point(63, 19);
            this.rnormal.Name = "rnormal";
            this.rnormal.Size = new System.Drawing.Size(69, 17);
            this.rnormal.TabIndex = 3;
            this.rnormal.TabStop = true;
            this.rnormal.Text = "Система";
            this.rnormal.UseVisualStyleBackColor = true;
            // 
            // rbootloader
            // 
            this.rbootloader.AutoSize = true;
            this.rbootloader.Location = new System.Drawing.Point(158, 19);
            this.rbootloader.Name = "rbootloader";
            this.rbootloader.Size = new System.Drawing.Size(71, 17);
            this.rbootloader.TabIndex = 2;
            this.rbootloader.TabStop = true;
            this.rbootloader.Text = "Fastboot";
            this.rbootloader.UseVisualStyleBackColor = true;
            // 
            // r9008
            // 
            this.r9008.AutoSize = true;
            this.r9008.Location = new System.Drawing.Point(247, 19);
            this.r9008.Name = "r9008";
            this.r9008.Size = new System.Drawing.Size(49, 17);
            this.r9008.TabIndex = 1;
            this.r9008.TabStop = true;
            this.r9008.Text = "9008";
            this.r9008.UseVisualStyleBackColor = true;
            // 
            // r9006
            // 
            this.r9006.AutoSize = true;
            this.r9006.Location = new System.Drawing.Point(8, 19);
            this.r9006.Name = "r9006";
            this.r9006.Size = new System.Drawing.Size(49, 17);
            this.r9006.TabIndex = 0;
            this.r9006.TabStop = true;
            this.r9006.Text = "9006";
            this.r9006.UseVisualStyleBackColor = true;
            // 
            // groupBoxReboot
            // 
            this.groupBoxReboot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBoxReboot.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxReboot.Controls.Add(this.groupBoxN_Reboot);
            this.groupBoxReboot.Controls.Add(this.groupBox_1);
            this.groupBoxReboot.Controls.Add(this.groupBox9006);
            this.groupBoxReboot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxReboot.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxReboot.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBoxReboot.Location = new System.Drawing.Point(327, 210);
            this.groupBoxReboot.Name = "groupBoxReboot";
            this.groupBoxReboot.Size = new System.Drawing.Size(336, 249);
            this.groupBoxReboot.TabIndex = 3;
            this.groupBoxReboot.TabStop = false;
            this.groupBoxReboot.Text = "Перезагрузка";
            // 
            // groupBoxN_Reboot
            // 
            this.groupBoxN_Reboot.Controls.Add(this.btnNormalReboot);
            this.groupBoxN_Reboot.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxN_Reboot.ForeColor = System.Drawing.Color.White;
            this.groupBoxN_Reboot.Location = new System.Drawing.Point(13, 190);
            this.groupBoxN_Reboot.Name = "groupBoxN_Reboot";
            this.groupBoxN_Reboot.Size = new System.Drawing.Size(314, 48);
            this.groupBoxN_Reboot.TabIndex = 3;
            this.groupBoxN_Reboot.TabStop = false;
            this.groupBoxN_Reboot.Text = "Система";
            // 
            // btnNormalReboot
            // 
            this.btnNormalReboot.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnNormalReboot.BackgroundImage")));
            this.btnNormalReboot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNormalReboot.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnNormalReboot.ForeColor = System.Drawing.Color.Black;
            this.btnNormalReboot.Location = new System.Drawing.Point(6, 17);
            this.btnNormalReboot.Name = "btnNormalReboot";
            this.btnNormalReboot.Size = new System.Drawing.Size(296, 26);
            this.btnNormalReboot.TabIndex = 2;
            this.btnNormalReboot.Text = "Выполнить";
            this.btnNormalReboot.UseVisualStyleBackColor = true;
            this.btnNormalReboot.Click += new System.EventHandler(this.btnNormalReboot_Click_1);
            // 
            // groupBox_1
            // 
            this.groupBox_1.Controls.Add(this.btnEDL);
            this.groupBox_1.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox_1.ForeColor = System.Drawing.Color.White;
            this.groupBox_1.Location = new System.Drawing.Point(13, 130);
            this.groupBox_1.Name = "groupBox_1";
            this.groupBox_1.Size = new System.Drawing.Size(314, 54);
            this.groupBox_1.TabIndex = 1;
            this.groupBox_1.TabStop = false;
            this.groupBox_1.Text = "EDL";
            // 
            // btnEDL
            // 
            this.btnEDL.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEDL.BackgroundImage")));
            this.btnEDL.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEDL.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEDL.ForeColor = System.Drawing.Color.Black;
            this.btnEDL.Location = new System.Drawing.Point(6, 22);
            this.btnEDL.Name = "btnEDL";
            this.btnEDL.Size = new System.Drawing.Size(296, 26);
            this.btnEDL.TabIndex = 2;
            this.btnEDL.Text = "Выполнить";
            this.btnEDL.UseVisualStyleBackColor = true;
            this.btnEDL.Click += new System.EventHandler(this.btnEDL_Click_1);
            // 
            // groupBox9006
            // 
            this.groupBox9006.Controls.Add(this.label13);
            this.groupBox9006.Controls.Add(this.btn9008To9006);
            this.groupBox9006.Controls.Add(this.comboBox9008To9006);
            this.groupBox9006.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox9006.ForeColor = System.Drawing.Color.White;
            this.groupBox9006.Location = new System.Drawing.Point(13, 19);
            this.groupBox9006.Name = "groupBox9006";
            this.groupBox9006.Size = new System.Drawing.Size(314, 108);
            this.groupBox9006.TabIndex = 0;
            this.groupBox9006.TabStop = false;
            this.groupBox9006.Text = "9008 to 9006";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label13.Location = new System.Drawing.Point(6, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(167, 18);
            this.label13.TabIndex = 14;
            this.label13.Text = "Выберите процессор";
            // 
            // btn9008To9006
            // 
            this.btn9008To9006.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn9008To9006.BackgroundImage")));
            this.btn9008To9006.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn9008To9006.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn9008To9006.ForeColor = System.Drawing.Color.Black;
            this.btn9008To9006.Location = new System.Drawing.Point(6, 70);
            this.btn9008To9006.Name = "btn9008To9006";
            this.btn9008To9006.Size = new System.Drawing.Size(296, 28);
            this.btn9008To9006.TabIndex = 1;
            this.btn9008To9006.Text = "Выполнить";
            this.btn9008To9006.UseVisualStyleBackColor = true;
            this.btn9008To9006.Click += new System.EventHandler(this.btn9008To9006_Click_1);
            // 
            // comboBox9008To9006
            // 
            this.comboBox9008To9006.BackColor = System.Drawing.Color.White;
            this.comboBox9008To9006.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox9008To9006.ForeColor = System.Drawing.Color.Red;
            this.comboBox9008To9006.FormattingEnabled = true;
            this.comboBox9008To9006.Location = new System.Drawing.Point(6, 37);
            this.comboBox9008To9006.Name = "comboBox9008To9006";
            this.comboBox9008To9006.Size = new System.Drawing.Size(296, 26);
            this.comboBox9008To9006.Sorted = true;
            this.comboBox9008To9006.TabIndex = 0;
            this.comboBox9008To9006.SelectedIndexChanged += new System.EventHandler(this.comboBox9008To9006_SelectedIndexChanged);
            // 
            // groupBoxFirmwareRead
            // 
            this.groupBoxFirmwareRead.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxFirmwareRead.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxFirmwareRead.Controls.Add(this.btnBackupFirmware);
            this.groupBoxFirmwareRead.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxFirmwareRead.ForeColor = System.Drawing.Color.White;
            this.groupBoxFirmwareRead.Location = new System.Drawing.Point(10, 139);
            this.groupBoxFirmwareRead.Name = "groupBoxFirmwareRead";
            this.groupBoxFirmwareRead.Size = new System.Drawing.Size(653, 65);
            this.groupBoxFirmwareRead.TabIndex = 1;
            this.groupBoxFirmwareRead.TabStop = false;
            this.groupBoxFirmwareRead.Text = "Резервное копирование";
            // 
            // btnBackupFirmware
            // 
            this.btnBackupFirmware.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnBackupFirmware.BackgroundImage")));
            this.btnBackupFirmware.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBackupFirmware.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBackupFirmware.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackupFirmware.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBackupFirmware.ForeColor = System.Drawing.Color.Black;
            this.btnBackupFirmware.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnBackupFirmware.Location = new System.Drawing.Point(9, 21);
            this.btnBackupFirmware.Name = "btnBackupFirmware";
            this.btnBackupFirmware.Size = new System.Drawing.Size(452, 33);
            this.btnBackupFirmware.TabIndex = 2;
            this.btnBackupFirmware.Text = "Скачать всю прошивку с устройства";
            this.btnBackupFirmware.UseVisualStyleBackColor = true;
            this.btnBackupFirmware.Click += new System.EventHandler(this.btnBackupFirmware_Click);
            // 
            // groupBoxFirmwareWrite
            // 
            this.groupBoxFirmwareWrite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxFirmwareWrite.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxFirmwareWrite.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBoxFirmwareWrite.Controls.Add(this.btnDownloadXML);
            this.groupBoxFirmwareWrite.Controls.Add(this.btnPath);
            this.groupBoxFirmwareWrite.Controls.Add(this.btnRawprogram0);
            this.groupBoxFirmwareWrite.Controls.Add(this.txt_patch0);
            this.groupBoxFirmwareWrite.Controls.Add(this.txt_rawprogram0);
            this.groupBoxFirmwareWrite.Controls.Add(this.label11);
            this.groupBoxFirmwareWrite.Controls.Add(this.label12);
            this.groupBoxFirmwareWrite.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxFirmwareWrite.ForeColor = System.Drawing.Color.White;
            this.groupBoxFirmwareWrite.Location = new System.Drawing.Point(10, 9);
            this.groupBoxFirmwareWrite.Name = "groupBoxFirmwareWrite";
            this.groupBoxFirmwareWrite.Size = new System.Drawing.Size(653, 124);
            this.groupBoxFirmwareWrite.TabIndex = 2;
            this.groupBoxFirmwareWrite.TabStop = false;
            this.groupBoxFirmwareWrite.Text = "Прошивка";
            // 
            // btnDownloadXML
            // 
            this.btnDownloadXML.BackColor = System.Drawing.Color.Transparent;
            this.btnDownloadXML.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDownloadXML.BackgroundImage")));
            this.btnDownloadXML.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDownloadXML.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDownloadXML.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownloadXML.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDownloadXML.ForeColor = System.Drawing.Color.Black;
            this.btnDownloadXML.Location = new System.Drawing.Point(19, 74);
            this.btnDownloadXML.Name = "btnDownloadXML";
            this.btnDownloadXML.Size = new System.Drawing.Size(452, 35);
            this.btnDownloadXML.TabIndex = 6;
            this.btnDownloadXML.Text = "Прошить устройство";
            this.btnDownloadXML.UseVisualStyleBackColor = false;
            this.btnDownloadXML.Click += new System.EventHandler(this.btnDownloadXML_Click);
            // 
            // btnPath
            // 
            this.btnPath.BackColor = System.Drawing.Color.White;
            this.btnPath.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPath.BackgroundImage")));
            this.btnPath.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnPath.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPath.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPath.ForeColor = System.Drawing.Color.Black;
            this.btnPath.ImageIndex = 2;
            this.btnPath.ImageList = this.imageList1;
            this.btnPath.Location = new System.Drawing.Point(441, 43);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(30, 26);
            this.btnPath.TabIndex = 5;
            this.btnPath.UseVisualStyleBackColor = false;
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // btnRawprogram0
            // 
            this.btnRawprogram0.BackColor = System.Drawing.Color.White;
            this.btnRawprogram0.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRawprogram0.BackgroundImage")));
            this.btnRawprogram0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRawprogram0.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRawprogram0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRawprogram0.ForeColor = System.Drawing.Color.Black;
            this.btnRawprogram0.ImageIndex = 2;
            this.btnRawprogram0.ImageList = this.imageList1;
            this.btnRawprogram0.Location = new System.Drawing.Point(194, 43);
            this.btnRawprogram0.Name = "btnRawprogram0";
            this.btnRawprogram0.Size = new System.Drawing.Size(30, 26);
            this.btnRawprogram0.TabIndex = 4;
            this.btnRawprogram0.UseVisualStyleBackColor = false;
            this.btnRawprogram0.Click += new System.EventHandler(this.btnRawprogram0_Click);
            // 
            // txt_patch0
            // 
            this.txt_patch0.Location = new System.Drawing.Point(266, 43);
            this.txt_patch0.Name = "txt_patch0";
            this.txt_patch0.Size = new System.Drawing.Size(169, 26);
            this.txt_patch0.TabIndex = 3;
            // 
            // txt_rawprogram0
            // 
            this.txt_rawprogram0.Location = new System.Drawing.Point(19, 42);
            this.txt_rawprogram0.Name = "txt_rawprogram0";
            this.txt_rawprogram0.Size = new System.Drawing.Size(169, 26);
            this.txt_rawprogram0.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(16, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(135, 18);
            this.label11.TabIndex = 0;
            this.label11.Text = "rawprogram0.xml";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(263, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 18);
            this.label12.TabIndex = 1;
            this.label12.Text = "patch0.xml";
            // 
            // btnRepairOEM
            // 
            this.btnRepairOEM.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRepairOEM.BackgroundImage")));
            this.btnRepairOEM.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRepairOEM.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnRepairOEM.ForeColor = System.Drawing.Color.Black;
            this.btnRepairOEM.Location = new System.Drawing.Point(15, 129);
            this.btnRepairOEM.Name = "btnRepairOEM";
            this.btnRepairOEM.Size = new System.Drawing.Size(267, 31);
            this.btnRepairOEM.TabIndex = 3;
            this.btnRepairOEM.Text = "Починить";
            this.btnRepairOEM.UseVisualStyleBackColor = true;
            this.btnRepairOEM.Click += new System.EventHandler(this.btnRepairOEM_Click);
            // 
            // groupBox_0
            // 
            this.groupBox_0.Controls.Add(this.btnRepairOEM);
            this.groupBox_0.Controls.Add(this.radioButton3);
            this.groupBox_0.Controls.Add(this.radioButton2);
            this.groupBox_0.Controls.Add(this.radioButton1);
            this.groupBox_0.Controls.Add(this.label7);
            this.groupBox_0.Controls.Add(this.comboBox_0);
            this.groupBox_0.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox_0.ForeColor = System.Drawing.Color.White;
            this.groupBox_0.Location = new System.Drawing.Point(312, 155);
            this.groupBox_0.Name = "groupBox_0";
            this.groupBox_0.Size = new System.Drawing.Size(300, 172);
            this.groupBox_0.TabIndex = 0;
            this.groupBox_0.TabStop = false;
            this.groupBox_0.Text = "OEM :";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(15, 25);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(144, 22);
            this.radioButton3.TabIndex = 7;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "NetWork Unlock";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(173, 25);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(109, 22);
            this.radioButton2.TabIndex = 6;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Noti/Theme";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(15, 52);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(58, 22);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "OEM";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(12, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(121, 17);
            this.label7.TabIndex = 4;
            this.label7.Text = "Выберите модель";
            // 
            // comboBox_0
            // 
            this.comboBox_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.comboBox_0.FormattingEnabled = true;
            this.comboBox_0.Items.AddRange(new object[] {
            "C8816",
            "C8816D",
            "G6-C00",
            "G6-U00",
            "G6-U10",
            "G615-U10",
            "G620-L72",
            "G620-L73",
            "G620-L75",
            "G620-UL01",
            "G620S-UL00",
            "G630-U00",
            "G630-U10",
            "G7-UL20",
            "G730-U30",
            "G740-L00",
            "H30-C00",
            "SCC-U21",
            "SCL-U31"});
            this.comboBox_0.Location = new System.Drawing.Point(15, 97);
            this.comboBox_0.Name = "comboBox_0";
            this.comboBox_0.Size = new System.Drawing.Size(267, 26);
            this.comboBox_0.TabIndex = 0;
            this.comboBox_0.SelectedIndexChanged += new System.EventHandler(this.comboBoxOEM_SelectedIndexChanged);
            // 
            // groupBoxDloadFlasher
            // 
            this.groupBoxDloadFlasher.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxDloadFlasher.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBoxDloadFlasher.Controls.Add(this.label18);
            this.groupBoxDloadFlasher.Controls.Add(this.btnCreateBoard);
            this.groupBoxDloadFlasher.Controls.Add(this.button1);
            this.groupBoxDloadFlasher.Controls.Add(this.txtDload);
            this.groupBoxDloadFlasher.Controls.Add(this.btnDownloadDload);
            this.groupBoxDloadFlasher.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxDloadFlasher.ForeColor = System.Drawing.Color.White;
            this.groupBoxDloadFlasher.Location = new System.Drawing.Point(312, 3);
            this.groupBoxDloadFlasher.Name = "groupBoxDloadFlasher";
            this.groupBoxDloadFlasher.Size = new System.Drawing.Size(300, 146);
            this.groupBoxDloadFlasher.TabIndex = 15;
            this.groupBoxDloadFlasher.TabStop = false;
            this.groupBoxDloadFlasher.Text = "update.app";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(12, 22);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(174, 18);
            this.label18.TabIndex = 20;
            this.label18.Text = "Выберите UPDATE.APP";
            // 
            // btnCreateBoard
            // 
            this.btnCreateBoard.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCreateBoard.BackgroundImage")));
            this.btnCreateBoard.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCreateBoard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateBoard.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCreateBoard.ForeColor = System.Drawing.Color.Black;
            this.btnCreateBoard.Location = new System.Drawing.Point(15, 110);
            this.btnCreateBoard.Name = "btnCreateBoard";
            this.btnCreateBoard.Size = new System.Drawing.Size(267, 28);
            this.btnCreateBoard.TabIndex = 19;
            this.btnCreateBoard.Text = "Создать сервисную прошивку";
            this.btnCreateBoard.UseVisualStyleBackColor = true;
            this.btnCreateBoard.Click += new System.EventHandler(this.btnCreateBoard_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gray;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.ForeColor = System.Drawing.Color.Blue;
            this.button1.Image = global::Properties.Resources._11;
            this.button1.Location = new System.Drawing.Point(250, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(32, 27);
            this.button1.TabIndex = 18;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtDload
            // 
            this.txtDload.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDload.Location = new System.Drawing.Point(15, 43);
            this.txtDload.Name = "txtDload";
            this.txtDload.ReadOnly = true;
            this.txtDload.Size = new System.Drawing.Size(229, 25);
            this.txtDload.TabIndex = 17;
            // 
            // btnDownloadDload
            // 
            this.btnDownloadDload.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDownloadDload.BackgroundImage")));
            this.btnDownloadDload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDownloadDload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownloadDload.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDownloadDload.ForeColor = System.Drawing.Color.Black;
            this.btnDownloadDload.Location = new System.Drawing.Point(15, 76);
            this.btnDownloadDload.Name = "btnDownloadDload";
            this.btnDownloadDload.Size = new System.Drawing.Size(267, 28);
            this.btnDownloadDload.TabIndex = 16;
            this.btnDownloadDload.Text = "Записать";
            this.btnDownloadDload.UseVisualStyleBackColor = true;
            this.btnDownloadDload.Click += new System.EventHandler(this.btnDownloadDload_Click);
            // 
            // groupBoxBootloaerUnlock
            // 
            this.groupBoxBootloaerUnlock.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxBootloaerUnlock.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBoxBootloaerUnlock.Controls.Add(this.btnBootloaderUnlock);
            this.groupBoxBootloaerUnlock.Controls.Add(this.label10);
            this.groupBoxBootloaerUnlock.Controls.Add(this.cbBootloaderUnlock);
            this.groupBoxBootloaerUnlock.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBoxBootloaerUnlock.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxBootloaerUnlock.ForeColor = System.Drawing.Color.White;
            this.groupBoxBootloaerUnlock.Location = new System.Drawing.Point(6, 155);
            this.groupBoxBootloaerUnlock.Name = "groupBoxBootloaerUnlock";
            this.groupBoxBootloaerUnlock.Size = new System.Drawing.Size(300, 172);
            this.groupBoxBootloaerUnlock.TabIndex = 0;
            this.groupBoxBootloaerUnlock.TabStop = false;
            this.groupBoxBootloaerUnlock.Text = "Huawei Разблокировка";
            // 
            // btnBootloaderUnlock
            // 
            this.btnBootloaderUnlock.BackColor = System.Drawing.Color.Transparent;
            this.btnBootloaderUnlock.BackgroundImage = global::Properties.Resources._11;
            this.btnBootloaderUnlock.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBootloaderUnlock.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBootloaderUnlock.ForeColor = System.Drawing.Color.Black;
            this.btnBootloaderUnlock.Location = new System.Drawing.Point(19, 85);
            this.btnBootloaderUnlock.Name = "btnBootloaderUnlock";
            this.btnBootloaderUnlock.Size = new System.Drawing.Size(263, 34);
            this.btnBootloaderUnlock.TabIndex = 4;
            this.btnBootloaderUnlock.Text = "Разблокировать";
            this.btnBootloaderUnlock.UseVisualStyleBackColor = false;
            this.btnBootloaderUnlock.Click += new System.EventHandler(this.btnBootloaderUnlock_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(16, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(144, 17);
            this.label10.TabIndex = 2;
            this.label10.Text = "Выберите устройство";
            // 
            // cbBootloaderUnlock
            // 
            this.cbBootloaderUnlock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBootloaderUnlock.FormattingEnabled = true;
            this.cbBootloaderUnlock.Items.AddRange(new object[] {
            "ALE-CL00",
            "ATH-TL00",
            "ATH-UL01",
            "C8816",
            "C8816D",
            "C8817D",
            "C8817L",
            "Che1-CL20",
            "G6-C00",
            "G6-L11",
            "G6-U00",
            "G6-U10",
            "G6-U34",
            "G615-U10",
            "G620-L73",
            "G620-L75",
            "G620S-L01",
            "G620S-L03",
            "G620S-UL00",
            "G630-U00",
            "G660-L075",
            "G718",
            "G730-U30",
            "G750-C00",
            "G760-L03",
            "H30-C00",
            "KIW-AL10",
            "MT2-L03",
            "S7-721u",
            "S8-701u",
            "SC-CL00",
            "Y330-C00",
            "Y635-L02",
            "Y635-TL00"});
            this.cbBootloaderUnlock.Location = new System.Drawing.Point(19, 53);
            this.cbBootloaderUnlock.Name = "cbBootloaderUnlock";
            this.cbBootloaderUnlock.Size = new System.Drawing.Size(263, 26);
            this.cbBootloaderUnlock.TabIndex = 0;
            this.cbBootloaderUnlock.SelectedIndexChanged += new System.EventHandler(this.cbBootloaderUnlock_SelectedIndexChanged);
            // 
            // groupBoxBoardFirmware
            // 
            this.groupBoxBoardFirmware.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxBoardFirmware.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBoxBoardFirmware.Controls.Add(this.label17);
            this.groupBoxBoardFirmware.Controls.Add(this.button2);
            this.groupBoxBoardFirmware.Controls.Add(this.btnDownloadBoardFirmware);
            this.groupBoxBoardFirmware.Controls.Add(this.textBox1);
            this.groupBoxBoardFirmware.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxBoardFirmware.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxBoardFirmware.ForeColor = System.Drawing.Color.White;
            this.groupBoxBoardFirmware.Location = new System.Drawing.Point(6, 3);
            this.groupBoxBoardFirmware.Name = "groupBoxBoardFirmware";
            this.groupBoxBoardFirmware.Size = new System.Drawing.Size(300, 146);
            this.groupBoxBoardFirmware.TabIndex = 4;
            this.groupBoxBoardFirmware.TabStop = false;
            this.groupBoxBoardFirmware.Text = "Сервисная прошивка";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 22);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(245, 18);
            this.label17.TabIndex = 9;
            this.label17.Text = "Выберите сервисную прошивку";
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.Gray;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.ForeColor = System.Drawing.Color.Blue;
            this.button2.Image = global::Properties.Resources._11;
            this.button2.Location = new System.Drawing.Point(250, 113);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(32, 27);
            this.button2.TabIndex = 8;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnDownloadBoardFirmware
            // 
            this.btnDownloadBoardFirmware.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDownloadBoardFirmware.BackgroundImage")));
            this.btnDownloadBoardFirmware.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDownloadBoardFirmware.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDownloadBoardFirmware.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDownloadBoardFirmware.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDownloadBoardFirmware.ForeColor = System.Drawing.Color.Black;
            this.btnDownloadBoardFirmware.Location = new System.Drawing.Point(16, 81);
            this.btnDownloadBoardFirmware.Name = "btnDownloadBoardFirmware";
            this.btnDownloadBoardFirmware.Size = new System.Drawing.Size(267, 28);
            this.btnDownloadBoardFirmware.TabIndex = 3;
            this.btnDownloadBoardFirmware.Text = "Прошить";
            this.btnDownloadBoardFirmware.UseVisualStyleBackColor = true;
            this.btnDownloadBoardFirmware.Click += new System.EventHandler(this.btnDownloadBoardFirmware_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(15, 115);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(229, 25);
            this.textBox1.TabIndex = 2;
            this.textBox1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseDoubleClick);
            // 
            // groupBox_2
            // 
            this.groupBox_2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox_2.Controls.Add(this.pBarEmmcDump);
            this.groupBox_2.Controls.Add(this.label19);
            this.groupBox_2.Controls.Add(this.richTextBoxMMC);
            this.groupBox_2.Controls.Add(this.comboBox_1);
            this.groupBox_2.Controls.Add(this.button_0);
            this.groupBox_2.Controls.Add(this.label9);
            this.groupBox_2.Controls.Add(this.textBox_0);
            this.groupBox_2.Controls.Add(this.button4);
            this.groupBox_2.Controls.Add(this.btnWrite9006);
            this.groupBox_2.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox_2.ForeColor = System.Drawing.Color.White;
            this.groupBox_2.Location = new System.Drawing.Point(3, 3);
            this.groupBox_2.Name = "groupBox_2";
            this.groupBox_2.Size = new System.Drawing.Size(661, 176);
            this.groupBox_2.TabIndex = 17;
            this.groupBox_2.TabStop = false;
            this.groupBox_2.Text = "Запись раздела в QCOM 9006";
            // 
            // pBarEmmcDump
            // 
            this.pBarEmmcDump.Location = new System.Drawing.Point(509, 16);
            this.pBarEmmcDump.Name = "pBarEmmcDump";
            this.pBarEmmcDump.Size = new System.Drawing.Size(100, 23);
            this.pBarEmmcDump.TabIndex = 21;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(240, 28);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(173, 18);
            this.label19.TabIndex = 20;
            this.label19.Text = "Qualcomm eMMC Drive";
            // 
            // richTextBoxMMC
            // 
            this.richTextBoxMMC.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.richTextBoxMMC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.richTextBoxMMC.ForeColor = System.Drawing.Color.LawnGreen;
            this.richTextBoxMMC.Location = new System.Drawing.Point(268, 77);
            this.richTextBoxMMC.Name = "richTextBoxMMC";
            this.richTextBoxMMC.ReadOnly = true;
            this.richTextBoxMMC.Size = new System.Drawing.Size(358, 94);
            this.richTextBoxMMC.TabIndex = 19;
            this.richTextBoxMMC.Text = "Выберите eMMC диск";
            // 
            // comboBox_1
            // 
            this.comboBox_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_1.FormattingEnabled = true;
            this.comboBox_1.Location = new System.Drawing.Point(243, 45);
            this.comboBox_1.Name = "comboBox_1";
            this.comboBox_1.Size = new System.Drawing.Size(263, 26);
            this.comboBox_1.TabIndex = 18;
            this.comboBox_1.SelectedIndexChanged += new System.EventHandler(this.comboBoxMMC_SelectedIndexChanged);
            // 
            // button_0
            // 
            this.button_0.BackgroundImage = global::Properties.Resources._11;
            this.button_0.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_0.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_0.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_0.ForeColor = System.Drawing.Color.Black;
            this.button_0.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_0.Location = new System.Drawing.Point(511, 45);
            this.button_0.Name = "button_0";
            this.button_0.Size = new System.Drawing.Size(89, 26);
            this.button_0.TabIndex = 17;
            this.button_0.Text = "Обновить";
            this.button_0.UseVisualStyleBackColor = true;
            this.button_0.Click += new System.EventHandler(this.btnCheckMMC_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 61);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(216, 36);
            this.label9.TabIndex = 16;
            this.label9.Text = "Выберите eMMC резервную\r\nкопию";
            // 
            // textBox_0
            // 
            this.textBox_0.Location = new System.Drawing.Point(6, 100);
            this.textBox_0.Name = "textBox_0";
            this.textBox_0.ReadOnly = true;
            this.textBox_0.Size = new System.Drawing.Size(194, 26);
            this.textBox_0.TabIndex = 14;
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::Properties.Resources._11;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.Black;
            this.button4.ImageIndex = 2;
            this.button4.ImageList = this.imageList1;
            this.button4.Location = new System.Drawing.Point(206, 100);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(33, 26);
            this.button4.TabIndex = 15;
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btnWrite9006
            // 
            this.btnWrite9006.BackgroundImage = global::Properties.Resources._11;
            this.btnWrite9006.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnWrite9006.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnWrite9006.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWrite9006.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnWrite9006.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnWrite9006.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWrite9006.Location = new System.Drawing.Point(6, 132);
            this.btnWrite9006.Name = "btnWrite9006";
            this.btnWrite9006.Size = new System.Drawing.Size(233, 39);
            this.btnWrite9006.TabIndex = 13;
            this.btnWrite9006.Text = "Запись";
            this.btnWrite9006.UseVisualStyleBackColor = true;
            this.btnWrite9006.Click += new System.EventHandler(this.btnWrite9006_Click);
            // 
            // cBoxAuto1
            // 
            this.cBoxAuto1.AutoSize = true;
            this.cBoxAuto1.BackColor = System.Drawing.Color.Transparent;
            this.cBoxAuto1.Checked = true;
            this.cBoxAuto1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxAuto1.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cBoxAuto1.ForeColor = System.Drawing.Color.Yellow;
            this.cBoxAuto1.Location = new System.Drawing.Point(144, 3);
            this.cBoxAuto1.Name = "cBoxAuto1";
            this.cBoxAuto1.Size = new System.Drawing.Size(141, 22);
            this.cBoxAuto1.TabIndex = 16;
            this.cBoxAuto1.Text = "Автоматически";
            this.cBoxAuto1.UseVisualStyleBackColor = false;
            this.cBoxAuto1.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // groupBoxBlock0Write
            // 
            this.groupBoxBlock0Write.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBoxBlock0Write.Controls.Add(this.label6);
            this.groupBoxBlock0Write.Controls.Add(this.btnEmmcDownloadFast);
            this.groupBoxBlock0Write.Controls.Add(this.label3);
            this.groupBoxBlock0Write.Controls.Add(this.txtEmmc);
            this.groupBoxBlock0Write.Controls.Add(this.btnEmmcSelect);
            this.groupBoxBlock0Write.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxBlock0Write.ForeColor = System.Drawing.Color.White;
            this.groupBoxBlock0Write.Location = new System.Drawing.Point(3, 185);
            this.groupBoxBlock0Write.Name = "groupBoxBlock0Write";
            this.groupBoxBlock0Write.Size = new System.Drawing.Size(318, 180);
            this.groupBoxBlock0Write.TabIndex = 9;
            this.groupBoxBlock0Write.TabStop = false;
            this.groupBoxBlock0Write.Text = "Запись разделов в режиме 9008";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 18);
            this.label6.TabIndex = 16;
            // 
            // btnEmmcDownloadFast
            // 
            this.btnEmmcDownloadFast.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEmmcDownloadFast.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEmmcDownloadFast.BackgroundImage")));
            this.btnEmmcDownloadFast.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEmmcDownloadFast.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmmcDownloadFast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmmcDownloadFast.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnEmmcDownloadFast.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnEmmcDownloadFast.Location = new System.Drawing.Point(13, 138);
            this.btnEmmcDownloadFast.Name = "btnEmmcDownloadFast";
            this.btnEmmcDownloadFast.Size = new System.Drawing.Size(282, 32);
            this.btnEmmcDownloadFast.TabIndex = 15;
            this.btnEmmcDownloadFast.Text = "Запись";
            this.btnEmmcDownloadFast.UseVisualStyleBackColor = true;
            this.btnEmmcDownloadFast.Click += new System.EventHandler(this.btnEmmcDownloadFast_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(300, 72);
            this.label3.TabIndex = 11;
            this.label3.Text = "Выберите копию. Пример\r\n--->file.bin\\\r\n---------------->|system.img | --->|CUST.i" +
    "mg\r\n---------------->|Vendor.img | --->|Recovery.img";
            // 
            // txtEmmc
            // 
            this.txtEmmc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmmc.Location = new System.Drawing.Point(13, 104);
            this.txtEmmc.Name = "txtEmmc";
            this.txtEmmc.ReadOnly = true;
            this.txtEmmc.Size = new System.Drawing.Size(242, 26);
            this.txtEmmc.TabIndex = 3;
            // 
            // btnEmmcSelect
            // 
            this.btnEmmcSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEmmcSelect.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEmmcSelect.BackgroundImage")));
            this.btnEmmcSelect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEmmcSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEmmcSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEmmcSelect.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEmmcSelect.ForeColor = System.Drawing.Color.Black;
            this.btnEmmcSelect.ImageIndex = 2;
            this.btnEmmcSelect.ImageList = this.imageList1;
            this.btnEmmcSelect.Location = new System.Drawing.Point(261, 104);
            this.btnEmmcSelect.Name = "btnEmmcSelect";
            this.btnEmmcSelect.Size = new System.Drawing.Size(36, 27);
            this.btnEmmcSelect.TabIndex = 4;
            this.btnEmmcSelect.UseVisualStyleBackColor = true;
            this.btnEmmcSelect.Click += new System.EventHandler(this.btnEmmcSelect_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.SeaGreen;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(17, 7);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 18);
            this.label4.TabIndex = 13;
            this.label4.Text = "Загрузчик";
            // 
            // groupBoxBlock0Read
            // 
            this.groupBoxBlock0Read.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBoxBlock0Read.Controls.Add(this.btnAdbRead);
            this.groupBoxBlock0Read.Controls.Add(this.label1);
            this.groupBoxBlock0Read.Controls.Add(this.txtEmmcSaveLocation);
            this.groupBoxBlock0Read.Controls.Add(this.button3);
            this.groupBoxBlock0Read.Controls.Add(this.btnDumpEmmc);
            this.groupBoxBlock0Read.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxBlock0Read.ForeColor = System.Drawing.Color.White;
            this.groupBoxBlock0Read.Location = new System.Drawing.Point(340, 185);
            this.groupBoxBlock0Read.Name = "groupBoxBlock0Read";
            this.groupBoxBlock0Read.Size = new System.Drawing.Size(324, 180);
            this.groupBoxBlock0Read.TabIndex = 10;
            this.groupBoxBlock0Read.TabStop = false;
            this.groupBoxBlock0Read.Text = "Чтение всех разделов";
            // 
            // btnAdbRead
            // 
            this.btnAdbRead.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAdbRead.BackgroundImage")));
            this.btnAdbRead.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAdbRead.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdbRead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdbRead.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAdbRead.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAdbRead.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAdbRead.Location = new System.Drawing.Point(12, 130);
            this.btnAdbRead.Name = "btnAdbRead";
            this.btnAdbRead.Size = new System.Drawing.Size(282, 32);
            this.btnAdbRead.TabIndex = 17;
            this.btnAdbRead.Text = "Чтение ( ADB )";
            this.btnAdbRead.UseVisualStyleBackColor = true;
            this.btnAdbRead.Click += new System.EventHandler(this.btnAdbRead_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(196, 18);
            this.label1.TabIndex = 16;
            this.label1.Text = "Путь сохранения для adb";
            // 
            // txtEmmcSaveLocation
            // 
            this.txtEmmcSaveLocation.Location = new System.Drawing.Point(12, 61);
            this.txtEmmcSaveLocation.Name = "txtEmmcSaveLocation";
            this.txtEmmcSaveLocation.ReadOnly = true;
            this.txtEmmcSaveLocation.Size = new System.Drawing.Size(239, 26);
            this.txtEmmcSaveLocation.TabIndex = 14;
            // 
            // button3
            // 
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.ImageIndex = 2;
            this.button3.ImageList = this.imageList1;
            this.button3.Location = new System.Drawing.Point(257, 60);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(37, 27);
            this.button3.TabIndex = 15;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnDumpEmmc
            // 
            this.btnDumpEmmc.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDumpEmmc.BackgroundImage")));
            this.btnDumpEmmc.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDumpEmmc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDumpEmmc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDumpEmmc.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDumpEmmc.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDumpEmmc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDumpEmmc.Location = new System.Drawing.Point(12, 92);
            this.btnDumpEmmc.Name = "btnDumpEmmc";
            this.btnDumpEmmc.Size = new System.Drawing.Size(282, 32);
            this.btnDumpEmmc.TabIndex = 13;
            this.btnDumpEmmc.Text = "Чтение ( QCOM 9008 )";
            this.btnDumpEmmc.UseVisualStyleBackColor = true;
            this.btnDumpEmmc.Click += new System.EventHandler(this.btnDumpEmmc_Click);
            // 
            // FirehoseSels
            // 
            this.FirehoseSels.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FirehoseSels.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.FirehoseSels.Enabled = false;
            this.FirehoseSels.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FirehoseSels.FormattingEnabled = true;
            this.FirehoseSels.Location = new System.Drawing.Point(13, 27);
            this.FirehoseSels.Name = "FirehoseSels";
            this.FirehoseSels.Size = new System.Drawing.Size(271, 26);
            this.FirehoseSels.TabIndex = 12;
            this.FirehoseSels.SelectedIndexChanged += new System.EventHandler(this.comboBoxFirehose1_SelectedIndexChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(503, 78);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(143, 40);
            this.checkBox1.TabIndex = 26;
            this.checkBox1.Text = "Форматировать\r\nвсё";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // rbWrite
            // 
            this.rbWrite.AutoSize = true;
            this.rbWrite.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbWrite.ForeColor = System.Drawing.Color.White;
            this.rbWrite.Location = new System.Drawing.Point(492, 45);
            this.rbWrite.Name = "rbWrite";
            this.rbWrite.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbWrite.Size = new System.Drawing.Size(153, 22);
            this.rbWrite.TabIndex = 24;
            this.rbWrite.Text = "Записать раздел";
            this.rbWrite.UseVisualStyleBackColor = true;
            this.rbWrite.CheckedChanged += new System.EventHandler(this.rbWrite_CheckedChanged);
            // 
            // rbFormat
            // 
            this.rbFormat.AutoSize = true;
            this.rbFormat.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbFormat.ForeColor = System.Drawing.Color.White;
            this.rbFormat.Location = new System.Drawing.Point(37, 351);
            this.rbFormat.Name = "rbFormat";
            this.rbFormat.Size = new System.Drawing.Size(142, 40);
            this.rbFormat.TabIndex = 23;
            this.rbFormat.Text = "Форматировать\r\nраздел";
            this.rbFormat.UseVisualStyleBackColor = true;
            this.rbFormat.CheckedChanged += new System.EventHandler(this.rbFormat_CheckedChanged);
            // 
            // rbBackup
            // 
            this.rbBackup.AutoSize = true;
            this.rbBackup.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbBackup.ForeColor = System.Drawing.Color.White;
            this.rbBackup.Location = new System.Drawing.Point(524, 17);
            this.rbBackup.Name = "rbBackup";
            this.rbBackup.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rbBackup.Size = new System.Drawing.Size(121, 22);
            this.rbBackup.TabIndex = 22;
            this.rbBackup.Text = "Скопировать";
            this.rbBackup.UseVisualStyleBackColor = true;
            this.rbBackup.CheckedChanged += new System.EventHandler(this.rbBackup_CheckedChanged);
            // 
            // rbScan
            // 
            this.rbScan.AutoSize = true;
            this.rbScan.Checked = true;
            this.rbScan.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rbScan.ForeColor = System.Drawing.Color.White;
            this.rbScan.Location = new System.Drawing.Point(208, 48);
            this.rbScan.Name = "rbScan";
            this.rbScan.Size = new System.Drawing.Size(229, 22);
            this.rbScan.TabIndex = 21;
            this.rbScan.TabStop = true;
            this.rbScan.Text = "Подключение к устройству";
            this.rbScan.UseVisualStyleBackColor = true;
            this.rbScan.CheckedChanged += new System.EventHandler(this.rbScan_CheckedChanged);
            // 
            // checkBoxBackupAll
            // 
            this.checkBoxBackupAll.AutoSize = true;
            this.checkBoxBackupAll.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.checkBoxBackupAll.ForeColor = System.Drawing.Color.White;
            this.checkBoxBackupAll.Location = new System.Drawing.Point(25, 78);
            this.checkBoxBackupAll.Name = "checkBoxBackupAll";
            this.checkBoxBackupAll.Size = new System.Drawing.Size(122, 40);
            this.checkBoxBackupAll.TabIndex = 20;
            this.checkBoxBackupAll.Text = "Скопировать\r\nвсё";
            this.checkBoxBackupAll.UseVisualStyleBackColor = true;
            this.checkBoxBackupAll.CheckedChanged += new System.EventHandler(this.checkBoxBackupAll_CheckedChanged);
            // 
            // btnDoJobForBackupRestore
            // 
            this.btnDoJobForBackupRestore.BackColor = System.Drawing.Color.Turquoise;
            this.btnDoJobForBackupRestore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDoJobForBackupRestore.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDoJobForBackupRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoJobForBackupRestore.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnDoJobForBackupRestore.ForeColor = System.Drawing.Color.Black;
            this.btnDoJobForBackupRestore.Location = new System.Drawing.Point(173, 14);
            this.btnDoJobForBackupRestore.Name = "btnDoJobForBackupRestore";
            this.btnDoJobForBackupRestore.Size = new System.Drawing.Size(313, 34);
            this.btnDoJobForBackupRestore.TabIndex = 16;
            this.btnDoJobForBackupRestore.Text = "Выполнить";
            this.btnDoJobForBackupRestore.UseVisualStyleBackColor = false;
            this.btnDoJobForBackupRestore.Click += new System.EventHandler(this.btnDoJobForBackupRestore_Click);
            // 
            // listViewBackupRestore
            // 
            this.listViewBackupRestore.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewBackupRestore.BackColor = System.Drawing.Color.DarkSlateGray;
            this.listViewBackupRestore.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewBackupRestore.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.listViewBackupRestore.ForeColor = System.Drawing.Color.White;
            this.listViewBackupRestore.FullRowSelect = true;
            this.listViewBackupRestore.HideSelection = false;
            this.listViewBackupRestore.Location = new System.Drawing.Point(12, 4);
            this.listViewBackupRestore.Name = "listViewBackupRestore";
            this.listViewBackupRestore.Size = new System.Drawing.Size(651, 325);
            this.listViewBackupRestore.TabIndex = 0;
            this.listViewBackupRestore.UseCompatibleStateImageBehavior = false;
            this.listViewBackupRestore.View = System.Windows.Forms.View.Details;
            this.listViewBackupRestore.SelectedIndexChanged += new System.EventHandler(this.listViewBackupRestore_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "№";
            this.columnHeader1.Width = 2;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Раздел";
            this.columnHeader2.Width = 145;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Начало блока :";
            this.columnHeader8.Width = 197;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Конец блока:";
            this.columnHeader9.Width = 149;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Размер :";
            this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader10.Width = 151;
            // 
            // imageSmall
            // 
            this.imageSmall.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageSmall.ImageStream")));
            this.imageSmall.TransparentColor = System.Drawing.Color.Transparent;
            this.imageSmall.Images.SetKeyName(0, "Component.png");
            this.imageSmall.Images.SetKeyName(1, "accessories-text-editor.png");
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "y.png");
            // 
            // imageList3
            // 
            this.imageList3.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList3.ImageSize = new System.Drawing.Size(20, 20);
            this.imageList3.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // LOG
            // 
            this.LOG.BackColor = System.Drawing.Color.Black;
            this.LOG.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LOG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LOG.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LOG.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.LOG.Location = new System.Drawing.Point(3, 3);
            this.LOG.Name = "LOG";
            this.LOG.ReadOnly = true;
            this.LOG.Size = new System.Drawing.Size(427, 468);
            this.LOG.TabIndex = 0;
            this.LOG.Text = "Ожидания действия\n";
            // 
            // bwDownload_eMMC
            // 
            this.bwDownload_eMMC.WorkerReportsProgress = true;
            this.bwDownload_eMMC.WorkerSupportsCancellation = true;
            this.bwDownload_eMMC.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwDownload_eMMC_DoWork);
            this.bwDownload_eMMC.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwDownload_eMMC_ProgressChanged);
            this.bwDownload_eMMC.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwDownload_eMMC_RunWorkerCompleted);
            // 
            // bwMain
            // 
            this.bwMain.WorkerReportsProgress = true;
            this.bwMain.WorkerSupportsCancellation = true;
            this.bwMain.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwMain_DoWork);
            this.bwMain.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwMain_ProgressChanged);
            this.bwMain.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwMain_RunWorkerCompleted);
            // 
            // bwFlashDload
            // 
            this.bwFlashDload.WorkerReportsProgress = true;
            this.bwFlashDload.WorkerSupportsCancellation = true;
            this.bwFlashDload.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwFlashDload_DoWork);
            this.bwFlashDload.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwFlashDload_ProgressChanged);
            this.bwFlashDload.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwFlashDload_RunWorkerCompleted);
            // 
            // bwEmmcdl
            // 
            this.bwEmmcdl.WorkerReportsProgress = true;
            this.bwEmmcdl.WorkerSupportsCancellation = true;
            this.bwEmmcdl.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwEmmcdl_DoWork);
            this.bwEmmcdl.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwEmmcdl_ProgressChanged);
            this.bwEmmcdl.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwEmmcdl_RunWorkerCompleted);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            // 
            // lblActivated
            // 
            this.lblActivated.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblActivated.AutoSize = true;
            this.lblActivated.BackColor = System.Drawing.SystemColors.Control;
            this.lblActivated.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblActivated.ForeColor = System.Drawing.Color.Black;
            this.lblActivated.Location = new System.Drawing.Point(1017, 567);
            this.lblActivated.Name = "lblActivated";
            this.lblActivated.Size = new System.Drawing.Size(88, 18);
            this.lblActivated.TabIndex = 4;
            this.lblActivated.Text = "07.02.2021";
            // 
            // tmWait
            // 
            this.tmWait.Tick += new System.EventHandler(this.tmWait_Tick);
            // 
            // bw_WriteFirmware
            // 
            this.bw_WriteFirmware.WorkerReportsProgress = true;
            this.bw_WriteFirmware.WorkerSupportsCancellation = true;
            this.bw_WriteFirmware.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_WriteFirmware_DoWork);
            this.bw_WriteFirmware.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bw_WriteFirmware_ProgressChanged);
            this.bw_WriteFirmware.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_WriteFirmware_RunWorkerCompleted);
            // 
            // bw_WritePatch0
            // 
            this.bw_WritePatch0.WorkerReportsProgress = true;
            this.bw_WritePatch0.WorkerSupportsCancellation = true;
            this.bw_WritePatch0.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bw_WritePatch0_DoWork);
            this.bw_WritePatch0.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bw_WritePatch0_ProgressChanged);
            this.bw_WritePatch0.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bw_WritePatch0_RunWorkerCompleted);
            // 
            // tabControl5
            // 
            this.tabControl5.Controls.Add(this.tabPage8);
            this.tabControl5.Controls.Add(this.tabPage9);
            this.tabControl5.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tabControl5.ImageList = this.imageSmall;
            this.tabControl5.Location = new System.Drawing.Point(0, 31);
            this.tabControl5.Name = "tabControl5";
            this.tabControl5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl5.SelectedIndex = 0;
            this.tabControl5.Size = new System.Drawing.Size(441, 505);
            this.tabControl5.TabIndex = 5;
            // 
            // tabPage8
            // 
            this.tabPage8.BackColor = System.Drawing.Color.Lime;
            this.tabPage8.BackgroundImage = global::Properties.Resources._11;
            this.tabPage8.Controls.Add(this.LOG);
            this.tabPage8.ImageIndex = 1;
            this.tabPage8.Location = new System.Drawing.Point(4, 27);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(433, 474);
            this.tabPage8.TabIndex = 0;
            this.tabPage8.Text = "Консоль:";
            // 
            // tabPage9
            // 
            this.tabPage9.BackColor = System.Drawing.Color.Lime;
            this.tabPage9.BackgroundImage = global::Properties.Resources._11;
            this.tabPage9.Controls.Add(this.help);
            this.tabPage9.ImageIndex = 0;
            this.tabPage9.Location = new System.Drawing.Point(4, 27);
            this.tabPage9.Name = "tabPage9";
            this.tabPage9.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage9.Size = new System.Drawing.Size(433, 474);
            this.tabPage9.TabIndex = 1;
            this.tabPage9.Text = "Справка:";
            // 
            // help
            // 
            this.help.BackColor = System.Drawing.Color.Black;
            this.help.Dock = System.Windows.Forms.DockStyle.Fill;
            this.help.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.help.ForeColor = System.Drawing.Color.DodgerBlue;
            this.help.Location = new System.Drawing.Point(3, 3);
            this.help.Name = "help";
            this.help.ReadOnly = true;
            this.help.Size = new System.Drawing.Size(427, 468);
            this.help.TabIndex = 0;
            this.help.Text = resources.GetString("help.Text");
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.BackgroundImage = global::Properties.Resources._11;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button5.ForeColor = System.Drawing.Color.Black;
            this.button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button5.Location = new System.Drawing.Point(317, 28);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(124, 28);
            this.button5.TabIndex = 20;
            this.button5.Text = "Обноружить";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // pBar
            // 
            this.pBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pBar.Location = new System.Drawing.Point(1, 538);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(440, 23);
            this.pBar.TabIndex = 7;
            // 
            // bwReadAdb
            // 
            this.bwReadAdb.WorkerReportsProgress = true;
            this.bwReadAdb.WorkerSupportsCancellation = true;
            this.bwReadAdb.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwReadAdb_DoWork);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackgroundImage = global::Properties.Resources._11;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.menuStrip1.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainToolStripMenuItem,
            this.cleanerToolStripMenuItem,
            this.aboutMeToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.ShowItemToolTips = true;
            this.menuStrip1.Size = new System.Drawing.Size(1134, 28);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mainToolStripMenuItem
            // 
            this.mainToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.mainToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            this.mainToolStripMenuItem.Size = new System.Drawing.Size(54, 24);
            this.mainToolStripMenuItem.Text = "Main";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Image = global::QFlashTool.Properties.Resources.exit;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(108, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // cleanerToolStripMenuItem
            // 
            this.cleanerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cleanAdbToolStripMenuItem,
            this.cleanQualcommServiceToolStripMenuItem,
            this.cleanAllToolStripMenuItem});
            this.cleanerToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cleanerToolStripMenuItem.Image = global::QFlashTool.Properties.Resources.standardbutton;
            this.cleanerToolStripMenuItem.Name = "cleanerToolStripMenuItem";
            this.cleanerToolStripMenuItem.Size = new System.Drawing.Size(102, 24);
            this.cleanerToolStripMenuItem.Text = "Очистка";
            // 
            // cleanAdbToolStripMenuItem
            // 
            this.cleanAdbToolStripMenuItem.Image = global::QFlashTool.Properties.Resources.delete_1;
            this.cleanAdbToolStripMenuItem.Name = "cleanAdbToolStripMenuItem";
            this.cleanAdbToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.cleanAdbToolStripMenuItem.Text = "Очистить лог ADB";
            this.cleanAdbToolStripMenuItem.Click += new System.EventHandler(this.cleanAdbToolStripMenuItem_Click);
            // 
            // cleanQualcommServiceToolStripMenuItem
            // 
            this.cleanQualcommServiceToolStripMenuItem.Image = global::QFlashTool.Properties.Resources.delete_1;
            this.cleanQualcommServiceToolStripMenuItem.Name = "cleanQualcommServiceToolStripMenuItem";
            this.cleanQualcommServiceToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.cleanQualcommServiceToolStripMenuItem.Text = "Очистить лог QCOM";
            this.cleanQualcommServiceToolStripMenuItem.Click += new System.EventHandler(this.cleanQualcommServiceToolStripMenuItem_Click);
            // 
            // cleanAllToolStripMenuItem
            // 
            this.cleanAllToolStripMenuItem.Image = global::QFlashTool.Properties.Resources.delete_1;
            this.cleanAllToolStripMenuItem.Name = "cleanAllToolStripMenuItem";
            this.cleanAllToolStripMenuItem.Size = new System.Drawing.Size(226, 26);
            this.cleanAllToolStripMenuItem.Text = "Очистить весь лог";
            this.cleanAllToolStripMenuItem.Click += new System.EventHandler(this.cleanAllToolStripMenuItem_Click);
            // 
            // aboutMeToolStripMenuItem
            // 
            this.aboutMeToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.aboutMeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("aboutMeToolStripMenuItem.Image")));
            this.aboutMeToolStripMenuItem.Name = "aboutMeToolStripMenuItem";
            this.aboutMeToolStripMenuItem.Size = new System.Drawing.Size(137, 24);
            this.aboutMeToolStripMenuItem.Text = "Информация";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.guideToolStripMenuItem,
            this.deviceManagerToolStripMenuItem});
            this.helpToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.helpToolStripMenuItem.Image = global::QFlashTool.Properties.Resources.btn_help_d;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(102, 24);
            this.helpToolStripMenuItem.Text = "Справка";
            // 
            // guideToolStripMenuItem
            // 
            this.guideToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.guideToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.huaweiToolStripMenuItem,
            this.qualcommToolStripMenuItem});
            this.guideToolStripMenuItem.Image = global::QFlashTool.Properties.Resources.y;
            this.guideToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.guideToolStripMenuItem.Name = "guideToolStripMenuItem";
            this.guideToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.guideToolStripMenuItem.Text = "Инструкции";
            // 
            // huaweiToolStripMenuItem
            // 
            this.huaweiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.boardFirmwareToolStripMenuItem,
            this.boardFirmwareCreateToolStripMenuItem,
            this.dloadFlasherToolStripMenuItem,
            this.bootloaderUnlockToolStripMenuItem,
            this.networkUnlockToolStripMenuItem});
            this.huaweiToolStripMenuItem.Name = "huaweiToolStripMenuItem";
            this.huaweiToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.huaweiToolStripMenuItem.Text = "Huawei";
            // 
            // boardFirmwareToolStripMenuItem
            // 
            this.boardFirmwareToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.boardFirmwareToolStripMenuItem.Name = "boardFirmwareToolStripMenuItem";
            this.boardFirmwareToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.boardFirmwareToolStripMenuItem.Text = "Board Firmware Download";
            // 
            // boardFirmwareCreateToolStripMenuItem
            // 
            this.boardFirmwareCreateToolStripMenuItem.Name = "boardFirmwareCreateToolStripMenuItem";
            this.boardFirmwareCreateToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.boardFirmwareCreateToolStripMenuItem.Text = "Board Firmware Create";
            // 
            // dloadFlasherToolStripMenuItem
            // 
            this.dloadFlasherToolStripMenuItem.Name = "dloadFlasherToolStripMenuItem";
            this.dloadFlasherToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.dloadFlasherToolStripMenuItem.Text = "9008 Dload Flasher";
            // 
            // bootloaderUnlockToolStripMenuItem
            // 
            this.bootloaderUnlockToolStripMenuItem.Name = "bootloaderUnlockToolStripMenuItem";
            this.bootloaderUnlockToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.bootloaderUnlockToolStripMenuItem.Text = "Bootloader Unlock";
            // 
            // networkUnlockToolStripMenuItem
            // 
            this.networkUnlockToolStripMenuItem.Name = "networkUnlockToolStripMenuItem";
            this.networkUnlockToolStripMenuItem.Size = new System.Drawing.Size(267, 22);
            this.networkUnlockToolStripMenuItem.Text = "Network unlock";
            // 
            // qualcommToolStripMenuItem
            // 
            this.qualcommToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.block0BackupToolStripMenuItem,
            this.block0FlasherToolStripMenuItem,
            this.firmwareToolStripMenuItem,
            this.eMMCToolStripMenuItem});
            this.qualcommToolStripMenuItem.Name = "qualcommToolStripMenuItem";
            this.qualcommToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.qualcommToolStripMenuItem.Text = "Qualcomm";
            // 
            // block0BackupToolStripMenuItem
            // 
            this.block0BackupToolStripMenuItem.Name = "block0BackupToolStripMenuItem";
            this.block0BackupToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.block0BackupToolStripMenuItem.Text = "Копия раздела";
            // 
            // block0FlasherToolStripMenuItem
            // 
            this.block0FlasherToolStripMenuItem.Name = "block0FlasherToolStripMenuItem";
            this.block0FlasherToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.block0FlasherToolStripMenuItem.Text = "Прошивка раздела";
            // 
            // firmwareToolStripMenuItem
            // 
            this.firmwareToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readToolStripMenuItem,
            this.writeToolStripMenuItem});
            this.firmwareToolStripMenuItem.Name = "firmwareToolStripMenuItem";
            this.firmwareToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.firmwareToolStripMenuItem.Text = "Прошивка";
            // 
            // readToolStripMenuItem
            // 
            this.readToolStripMenuItem.Name = "readToolStripMenuItem";
            this.readToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.readToolStripMenuItem.Text = "Чтение";
            // 
            // writeToolStripMenuItem
            // 
            this.writeToolStripMenuItem.Name = "writeToolStripMenuItem";
            this.writeToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.writeToolStripMenuItem.Text = "Запись";
            // 
            // eMMCToolStripMenuItem
            // 
            this.eMMCToolStripMenuItem.Name = "eMMCToolStripMenuItem";
            this.eMMCToolStripMenuItem.Size = new System.Drawing.Size(218, 22);
            this.eMMCToolStripMenuItem.Text = "EMMC";
            // 
            // deviceManagerToolStripMenuItem
            // 
            this.deviceManagerToolStripMenuItem.Image = global::QFlashTool.Properties.Resources.dm;
            this.deviceManagerToolStripMenuItem.Name = "deviceManagerToolStripMenuItem";
            this.deviceManagerToolStripMenuItem.Size = new System.Drawing.Size(231, 26);
            this.deviceManagerToolStripMenuItem.Text = "Дисетчер устройств";
            this.deviceManagerToolStripMenuItem.Click += new System.EventHandler(this.deviceManagerToolStripMenuItem_Click);
            // 
            // button7
            // 
            this.button7.BackgroundImage = global::Properties.Resources._11;
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button7.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button7.ForeColor = System.Drawing.Color.Black;
            this.button7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.ImageKey = "hu.png";
            this.button7.ImageList = this.imageList1;
            this.button7.Location = new System.Drawing.Point(447, 34);
            this.button7.Name = "button7";
            this.button7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button7.Size = new System.Drawing.Size(120, 27);
            this.button7.TabIndex = 8;
            this.button7.Text = "Huawei";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // q1
            // 
            this.q1.Controls.Add(this.groupBoxBoardFirmware);
            this.q1.Controls.Add(this.groupBox_0);
            this.q1.Controls.Add(this.groupBoxDloadFlasher);
            this.q1.Controls.Add(this.groupBoxBootloaerUnlock);
            this.q1.Location = new System.Drawing.Point(447, 92);
            this.q1.Name = "q1";
            this.q1.Size = new System.Drawing.Size(675, 468);
            this.q1.TabIndex = 9;
            this.q1.Visible = false;
            // 
            // button8
            // 
            this.button8.BackgroundImage = global::Properties.Resources._11;
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button8.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button8.ForeColor = System.Drawing.Color.Black;
            this.button8.Image = global::Properties.Resources.Webp_net_resizeimage;
            this.button8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button8.Location = new System.Drawing.Point(573, 34);
            this.button8.Name = "button8";
            this.button8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button8.Size = new System.Drawing.Size(120, 27);
            this.button8.TabIndex = 10;
            this.button8.Text = "     Qcom9008";
            this.button8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.BackgroundImage = global::Properties.Resources._11;
            this.button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button9.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button9.ForeColor = System.Drawing.Color.Black;
            this.button9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button9.ImageKey = "eMMC.png";
            this.button9.Location = new System.Drawing.Point(699, 34);
            this.button9.Name = "button9";
            this.button9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button9.Size = new System.Drawing.Size(120, 27);
            this.button9.TabIndex = 11;
            this.button9.Text = "eMMC";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // q2
            // 
            this.q2.Controls.Add(this.listViewBackupRestore);
            this.q2.Controls.Add(this.rbFormat);
            this.q2.Controls.Add(this.groupBoxBackupRestore);
            this.q2.Location = new System.Drawing.Point(447, 92);
            this.q2.Name = "q2";
            this.q2.Size = new System.Drawing.Size(675, 468);
            this.q2.TabIndex = 12;
            this.q2.Visible = false;
            // 
            // groupBoxBackupRestore
            // 
            this.groupBoxBackupRestore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxBackupRestore.BackColor = System.Drawing.Color.Transparent;
            this.groupBoxBackupRestore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBoxBackupRestore.Controls.Add(this.label5);
            this.groupBoxBackupRestore.Controls.Add(this.rbScan);
            this.groupBoxBackupRestore.Controls.Add(this.btnDoJobForBackupRestore);
            this.groupBoxBackupRestore.Controls.Add(this.checkBoxBackupAll);
            this.groupBoxBackupRestore.Controls.Add(this.checkBox1);
            this.groupBoxBackupRestore.Controls.Add(this.rbBackup);
            this.groupBoxBackupRestore.Controls.Add(this.rbWrite);
            this.groupBoxBackupRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxBackupRestore.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxBackupRestore.ForeColor = System.Drawing.Color.White;
            this.groupBoxBackupRestore.Location = new System.Drawing.Point(12, 326);
            this.groupBoxBackupRestore.Name = "groupBoxBackupRestore";
            this.groupBoxBackupRestore.Size = new System.Drawing.Size(651, 134);
            this.groupBoxBackupRestore.TabIndex = 11;
            this.groupBoxBackupRestore.TabStop = false;
            this.groupBoxBackupRestore.Text = "Настройки";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(34, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(0, 13);
            this.label5.TabIndex = 13;
            this.label5.Visible = false;
            // 
            // q3
            // 
            this.q3.Controls.Add(this.groupBox_2);
            this.q3.Controls.Add(this.groupBoxBlock0Write);
            this.q3.Controls.Add(this.groupBoxBlock0Read);
            this.q3.Location = new System.Drawing.Point(447, 92);
            this.q3.Name = "q3";
            this.q3.Size = new System.Drawing.Size(672, 468);
            this.q3.TabIndex = 13;
            this.q3.Visible = false;
            // 
            // button10
            // 
            this.button10.BackgroundImage = global::Properties.Resources._11;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button10.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button10.ForeColor = System.Drawing.Color.Black;
            this.button10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button10.ImageIndex = 1;
            this.button10.ImageList = this.imageList1;
            this.button10.Location = new System.Drawing.Point(447, 63);
            this.button10.Name = "button10";
            this.button10.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button10.Size = new System.Drawing.Size(120, 27);
            this.button10.TabIndex = 13;
            this.button10.Text = "Прошивка ";
            this.button10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cBoxAuto1);
            this.panel1.Controls.Add(this.FirehoseSels);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(826, 31);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(296, 60);
            this.panel1.TabIndex = 17;
            // 
            // q4
            // 
            this.q4.Controls.Add(this.groupBoxREBOOTER);
            this.q4.Controls.Add(this.groupBox2);
            this.q4.Controls.Add(this.groupBoxReboot);
            this.q4.Controls.Add(this.groupBoxFirmwareRead);
            this.q4.Controls.Add(this.groupBoxFirmwareWrite);
            this.q4.Location = new System.Drawing.Point(447, 92);
            this.q4.Name = "q4";
            this.q4.Size = new System.Drawing.Size(675, 468);
            this.q4.TabIndex = 18;
            this.q4.Visible = false;
            // 
            // q5
            // 
            this.q5.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.q5.Controls.Add(this.groupBoxEmmc);
            this.q5.Controls.Add(this.listViewEmmc);
            this.q5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.q5.Location = new System.Drawing.Point(447, 92);
            this.q5.Name = "q5";
            this.q5.Size = new System.Drawing.Size(675, 468);
            this.q5.TabIndex = 20;
            this.q5.Visible = false;
            // 
            // button12
            // 
            this.button12.BackgroundImage = global::Properties.Resources._11;
            this.button12.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button12.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button12.ForeColor = System.Drawing.Color.Black;
            this.button12.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button12.ImageIndex = 3;
            this.button12.ImageList = this.imageList1;
            this.button12.Location = new System.Drawing.Point(573, 64);
            this.button12.Name = "button12";
            this.button12.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.button12.Size = new System.Drawing.Size(120, 27);
            this.button12.TabIndex = 21;
            this.button12.Text = "IMG edit";
            this.button12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // M
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1134, 586);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button12);
            this.Controls.Add(this.pBar);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.tabControl5);
            this.Controls.Add(this.lblActivated);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.q2);
            this.Controls.Add(this.q4);
            this.Controls.Add(this.q3);
            this.Controls.Add(this.q1);
            this.Controls.Add(this.q5);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "M";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QFlashTool 4.0";
            this.TransparencyKey = System.Drawing.Color.Green;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBoxEmmc.ResumeLayout(false);
            this.groupBoxEmmc.PerformLayout();
            this.statusStrip3.ResumeLayout(false);
            this.statusStrip3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBoxREBOOTER.ResumeLayout(false);
            this.groupBoxREBOOTER.PerformLayout();
            this.groupBoxReboot.ResumeLayout(false);
            this.groupBoxN_Reboot.ResumeLayout(false);
            this.groupBox_1.ResumeLayout(false);
            this.groupBox9006.ResumeLayout(false);
            this.groupBox9006.PerformLayout();
            this.groupBoxFirmwareRead.ResumeLayout(false);
            this.groupBoxFirmwareWrite.ResumeLayout(false);
            this.groupBoxFirmwareWrite.PerformLayout();
            this.groupBox_0.ResumeLayout(false);
            this.groupBox_0.PerformLayout();
            this.groupBoxDloadFlasher.ResumeLayout(false);
            this.groupBoxDloadFlasher.PerformLayout();
            this.groupBoxBootloaerUnlock.ResumeLayout(false);
            this.groupBoxBootloaerUnlock.PerformLayout();
            this.groupBoxBoardFirmware.ResumeLayout(false);
            this.groupBoxBoardFirmware.PerformLayout();
            this.groupBox_2.ResumeLayout(false);
            this.groupBox_2.PerformLayout();
            this.groupBoxBlock0Write.ResumeLayout(false);
            this.groupBoxBlock0Write.PerformLayout();
            this.groupBoxBlock0Read.ResumeLayout(false);
            this.groupBoxBlock0Read.PerformLayout();
            this.tabControl5.ResumeLayout(false);
            this.tabPage8.ResumeLayout(false);
            this.tabPage9.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.q1.ResumeLayout(false);
            this.q2.ResumeLayout(false);
            this.q2.PerformLayout();
            this.groupBoxBackupRestore.ResumeLayout(false);
            this.groupBoxBackupRestore.PerformLayout();
            this.q3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.q4.ResumeLayout(false);
            this.q5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		static M()
		{
			error = new SoundPlayer(Resources.erro);
			quote = "\"";
			wkFile = Directory.GetCurrentDirectory();
			line = new List<string>();
			llll = "";
			model = string.Empty;
		}

        private void button7_Click(object sender, EventArgs e)
        {
			q1.Visible = true;
			q2.Visible = false;
			q4.Visible = false;
			q3.Visible = false;
			q5.Visible = false;
			q11 = 1;
			q22 = 0;
			q33 = 0;
			q44 = 0;
			q55 = 0;
		}

        private void button8_Click(object sender, EventArgs e)
        {
			q2.Visible = true;
			q3.Visible = false;
			q4.Visible = false;
			q1.Visible = false;
			q5.Visible = false;
			q11 = 0;
			q22 = 1;
			q33 = 0;
			q44 = 0;
			q55 = 0;
		}

        private void button9_Click(object sender, EventArgs e)
        {
			q3.Visible = true;
			q2.Visible = false;
			q5.Visible = false;
			q4.Visible = false;
			q1.Visible = false;
			q11 = 0;
			q22 = 0;
			q33 = 1;
			q44 = 0;
			q55 = 0;
		}

        private void button10_Click(object sender, EventArgs e)
        {
			q4.Visible = true;
			q5.Visible = false;
			q2.Visible = false;
			q3.Visible = false;
			q1.Visible = false;
			q11 = 0;
			q22 = 0;
			q33 = 0;
			q44 = 1;
			q55 = 0;
		}

        private void button12_Click(object sender, EventArgs e)
        {
			q5.Visible = true;
			q4.Visible = false;
			q2.Visible = false;
			q3.Visible = false;
			q1.Visible = false;
			q11 = 0;
			q22 = 0;
			q33 = 0;
			q44 = 0;
			q55 = 1;
		}
    }
}
