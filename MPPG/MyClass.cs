using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MPPG
{
	public static class MyClass
	{
		public static class Firehose
		{
			public static string path;

			internal static List<string> List
			{
				get
				{
					List<string> list = new List<string>();
					string text = "data\\\\firehose";
					if (Directory.Exists(text))
					{
						DirectoryInfo directoryInfo = new DirectoryInfo(text);
						FileInfo[] array = null;
						array = directoryInfo.GetFiles();
						FileInfo[] array2 = array;
						foreach (FileInfo fileInfo in array2)
						{
							if (fileInfo.Name.ToLower().EndsWith(".mbn"))
							{
								try
								{
									list.Add(fileInfo.Name);
								}
								catch
								{
								}
							}
						}
						return list;
					}
					return list;
				}
			}

			static Firehose()
			{
				path = Path.GetTempPath() + "miscrossoft";
			}
		}

		public static class Permission
		{
			private static bool enEmmcDump;

			private static bool enEmmcDownload;

			private static bool enBackupRestore;

			private static bool enDloadFlasher;

			private static bool enBoardFirmwareFlasher;

			private static bool enBootloaderUnlock;

			private static bool enNetworkUnlock;

			public static bool EnabledEmmcDump => enEmmcDump;

			public static bool EnabledEmmcDownload => enEmmcDownload;

			public static bool EnabledBackupRestore => enBackupRestore;

			public static bool EnableDloadFlasher => enDloadFlasher;

			public static bool EnabledBoardFirmwareFlasher => enBoardFirmwareFlasher;

			public static bool EnabledBootloaderUnlock => enBootloaderUnlock;

			public static bool EnabledNetworkUnlock => enNetworkUnlock;

			public static void checkFunction()
			{
				string path = "C:\\Windows\\KEY.me";
				if (!OK)
				{
					return;
				}
				foreach (string item in File.ReadLines(path))
				{
					string text = item;
					if (text.Contains("=") && !text.Contains("MAC") && !text.Contains("CPUID"))
					{
						string text2 = text;
						text = text.Substring(0, text.IndexOf("="));
						text2 = text2.Substring(text2.IndexOf("="), text2.Length - text2.IndexOf("="));
						text2 = text2.Remove(0, 1);
						if (text == "BoardFirmwareFlasher" && text2 == "YES")
						{
							enBoardFirmwareFlasher = true;
						}
						if (text == "DloadFlasher" && text2 == "YES")
						{
							enDloadFlasher = true;
						}
						if (text == "eMMC_Backup" && text2 == "YES")
						{
							enEmmcDump = true;
						}
						if (text == "eMMC_Restore" && text2 == "YES")
						{
							enEmmcDownload = true;
						}
						if (text == "Backup_Restore" && text2 == "YES")
						{
							enBackupRestore = true;
						}
						if (text == "BootloaderUnlock" && text2 == "YES")
						{
							enBootloaderUnlock = true;
						}
						if (text == "NetworkUnlock" && text2 == "YES")
						{
							enNetworkUnlock = true;
						}
					}
				}
			}
		}

		public static class Count
		{
			private static Stopwatch watch;

			internal static void Start()
			{
				watch.Start();
			}

			internal static void ShowinSecond()
			{
				watch.Stop();
				string text = watch.Elapsed.TotalSeconds.ToString();
				_ = " Time : " + text + " seconds";
				watch.Reset();
			}

			internal static void ShowinMinute()
			{
				watch.Stop();
				string text = (watch.Elapsed.TotalSeconds / 60.0).ToString();
				_ = " Time : " + text + " minute";
				watch.Reset();
			}

			static Count()
			{
				watch = new Stopwatch();
			}
		}

		public static class Check
		{
			private static bool meOK;

			public static string MAC
			{
				get
				{
					string result = "";
					NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
					int num = 0;
					if (0 < allNetworkInterfaces.Length)
					{
						NetworkInterface networkInterface = allNetworkInterfaces[num];
						result = networkInterface.GetPhysicalAddress().ToString();
					}
					return result;
				}
			}

			public static string CPUID
			{
				get
				{
					string result = null;
					try
					{
						ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("select * from Win32_Processor");
						foreach (ManagementBaseObject item in managementObjectSearcher.Get())
						{
							result = item["ProcessorId"].ToString();
						}
						return result;
					}
					catch
					{
						return "NONE_CPU";
					}
				}
			}

			public static string total => "KEY_FOR_QUALCOMM_PREMIUM_" + MAC + "=" + CPUID;

			private static int Numer1
			{
				get
				{
					int num = 0;
					string cPUID = CPUID;
					char[] array = cPUID.ToCharArray();
					char[] array2 = array;
					foreach (char value in array2)
					{
						int num2 = Convert.ToInt32(value);
						num += num2;
					}
					return num;
				}
			}

			private static int Numer2
			{
				get
				{
					int num = 0;
					string cPUID = CPUID;
					char[] array = cPUID.ToCharArray();
					char[] array2 = array;
					foreach (char value in array2)
					{
						int num2 = Convert.ToInt32(value);
						num += num2;
					}
					return num;
				}
			}

			private static int MAC_AND_CPU
			{
				get
				{
					int num = Numer1 + Numer2;
					return num * 7000;
				}
			}

			internal static string Value => "KEY_FOR_QUALCOMM_PREMIUM_" + MAC;

			public static bool Meok => meOK;

			internal static string KEY
			{
				get
				{
					string text = Path.GetTempPath() + "\\tmp.ok.mbn";
					if (File.Exists(text))
					{
						MyFile.Delete(text);
					}
					helper.DecryptFile("files\\\\Premium.KEY", text);
					try
					{
						List<string> source = File.ReadAllLines(text).ToList();
						MyFile.Delete(text);
						return source.Last().ToString();
					}
					catch
					{
						if (File.Exists(text))
						{
							MyFile.Delete(text);
						}
						return "error";
					}
				}
			}

			public static void CheckMe(string string_0)
			{
				bool flag = false;
				bool flag2 = false;
				string text = "data\\tmp\\check";
				if (File.Exists(text))
				{
					MyFile.Delete(text);
				}
				helper.DecryptFile(string_0, text);
				try
				{
					List<string> list = File.ReadAllLines(text).ToList();
					MyFile.Delete(text);
					list.Last().ToString();
					string text2 = list.First().ToString();
					if (text2 != "KEY_FOR_QUALCOMM_PREMIUM")
					{
						MessageBox.Show("This is not key ", "Error -", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return;
					}
					foreach (string item in list)
					{
						string text3 = item;
						if (!text3.Contains("="))
						{
							continue;
						}
						string text4 = text3;
						text3 = text3.Substring(0, text3.IndexOf("="));
						text4 = text4.Substring(text4.IndexOf("="), text4.Length - text4.IndexOf("="));
						text4 = text4.Remove(0, 1);
						if (text3 == "MAC")
						{
							if (text4 == MAC)
							{
								flag = true;
							}
							else
							{
								MessageBox.Show("ID1 wrong");
							}
						}
						if (text3 == "CPUID")
						{
							if (text4 == CPUID)
							{
								flag2 = true;
							}
							else
							{
								MessageBox.Show("ID2 wrong");
							}
						}
						if (flag && flag2)
						{
							meOK = true;
						}
						else
						{
							meOK = false;
						}
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message);
					Application.Exit();
				}
			}
		}

		public static class helper
		{
			internal static void DecryptFile(string string_0, string string_1)
			{
				try
				{
					string s = "myKey123";
					UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
					byte[] bytes = unicodeEncoding.GetBytes(s);
					FileStream fileStream = new FileStream(string_0, FileMode.Open);
					RijndaelManaged rijndaelManaged = new RijndaelManaged();
					CryptoStream cryptoStream = new CryptoStream(fileStream, rijndaelManaged.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
					FileStream fileStream2 = new FileStream(string_1, FileMode.Create, FileAccess.ReadWrite);
					int num;
					while ((num = cryptoStream.ReadByte()) != -1)
					{
						fileStream2.WriteByte((byte)num);
					}
					fileStream2.Close();
					cryptoStream.Close();
					fileStream.Close();
				}
				catch
				{
				}
			}
		}

		public static class K
		{
			internal static bool F
			{
				get
				{
					if (File.Exists("files\\\\Premium.KEY"))
					{
						return true;
					}
					return false;
				}
			}
		}

		public static class Task
		{
			internal static void KillAll()
			{
				Kill("adb");
				Kill("fastboot");
				Kill("fh_loader");
				Kill("mmc");
				Kill("dload");
				Kill("emmcdl");
				Kill("QSaharaServer");
				Kill("QPST");
			}

			internal static void Kill(string string_0)
			{
				Process[] processesByName = Process.GetProcessesByName(string_0);
				for (int i = 0; i < processesByName.Length; i = checked(i + 1))
				{
					processesByName[i].Kill();
				}
			}
		}

		internal static class eMMC
		{
			private static List<string> gpt;

			private static bool dumpFinished;

			private static BackgroundWorker bw;

			public static List<string> GPT => gpt;

			internal static string Size
			{
				get
				{
					if (GPT.Count == 0)
					{
						return "UNKNOWN";
					}
					string text = GPT.Last().ToString();
					text = text.Substring(text.IndexOf("LBA"));
					text = text.Substring(text.IndexOf(" ") + 1);
					string text2 = text;
					text = text.Substring(0, text.IndexOf(" "));
					text2 = text2.Substring(text2.IndexOf("LBA"));
					text2 = text2.Substring(text2.IndexOf(" ") + 1);
					return (Convert.ToInt64(text) + Convert.ToInt64(text2)).ToString();
				}
			}

			public static bool DumpFinish => dumpFinished;

			internal static List<string> getGPT(string string_0, string string_1)
			{
				List<string> list = new List<string>();
				Process process = new Process();
				process.StartInfo.FileName = DC.emmcdl;
				process.StartInfo.CreateNoWindow = true;
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
				process.StartInfo.RedirectStandardOutput = true;
				process.StartInfo.RedirectStandardError = true;
				process.EnableRaisingEvents = false;
				process.StartInfo.Arguments = " -p " + string_0 + " -f " + string_1 + " -gpt ";
				process.Start();
				string s = process.StandardOutput.ReadToEnd();
				using (StringReader stringReader = new StringReader(s))
				{
					while (stringReader.Peek() != -1)
					{
						string text = stringReader.ReadLine();
						if (text.Contains("Partition Name:") & text.Contains("Start LBA"))
						{
							gpt.Add(text);
							list.Add(text);
						}
					}
				}
				return list;
			}

			public static string Dump(string string_0, string string_1)
			{
				bw.WorkerSupportsCancellation = true;
				bw.WorkerReportsProgress = true;
				bw.DoWork += bw_DoWork;
				string fileName = "cmd.exe";
				string arguments = "/C  " + DC.emmcdl + " " + string_0;
				ProcessStartInfo startInfo = new ProcessStartInfo
				{
					WorkingDirectory = string_1,
					Arguments = arguments,
					CreateNoWindow = true,
					FileName = fileName,
					RedirectStandardOutput = true,
					UseShellExecute = false
				};
				Process process = new Process
				{
					StartInfo = startInfo
				};
				process.Start();
				string text = process.StandardOutput.ReadToEnd();
				dumpFinished = true;
				if (!text.Contains("Status: 0"))
				{
					return "Process Fail";
				}
				return "Process Pass";
			}

			private static void bw_DoWork(object sender, DoWorkEventArgs e)
			{
				BackgroundWorker backgroundWorker = sender as BackgroundWorker;
				int num = 1;
				while (true)
				{
					if (num <= 10)
					{
						if (backgroundWorker.CancellationPending)
						{
							break;
						}
						Thread.Sleep(500);
						backgroundWorker.ReportProgress(num * 10);
						num++;
						continue;
					}
					return;
				}
				e.Cancel = true;
			}

			static eMMC()
			{
				gpt = new List<string>();
				dumpFinished = false;
				bw = new BackgroundWorker();
			}
		}

		public static class EMMCDL
		{
			public static bool downloadPass;

			public static bool flashFirehoseFinish;

			public static bool DownloadOK => downloadPass;

			public static bool FlashFirehoseFinish => flashFirehoseFinish;

			public static string result { get; private set; }

			public static void flashFirehose(string string_0)
			{
				List<string> list = new List<string>();
				string fileName = "cmd.exe";
				string arguments = "/C  " + DC.emmcdl + " " + string_0;
				ProcessStartInfo startInfo = new ProcessStartInfo
				{
					WorkingDirectory = Directory.GetCurrentDirectory(),
					Arguments = arguments,
					CreateNoWindow = true,
					FileName = fileName,
					RedirectStandardOutput = true,
					UseShellExecute = false
				};
				Process process = new Process
				{
					StartInfo = startInfo
				};
				process.Start();
				string text = process.StandardOutput.ReadToEnd();
				using (StringReader stringReader = new StringReader(text))
				{
					while (stringReader.Peek() != -1)
					{
						string text2 = stringReader.ReadLine();
						if (text2 != "")
						{
							list.Add(text2);
						}
					}
				}
				result = list.Last();
				Thread.Sleep(500);
				if (!text.Contains("Status: 0"))
				{
					downloadPass = false;
				}
				else
				{
					downloadPass = true;
				}
				flashFirehoseFinish = true;
			}

			public static string Command(string string_0, int int_0)
			{
				string fileName = "cmd.exe";
				string arguments = "/C  " + DC.emmcdl + " " + string_0;
				ProcessStartInfo startInfo = new ProcessStartInfo
				{
					WorkingDirectory = Directory.GetCurrentDirectory(),
					Arguments = arguments,
					CreateNoWindow = true,
					FileName = fileName,
					RedirectStandardOutput = true,
					UseShellExecute = false
				};
				Process process = new Process
				{
					StartInfo = startInfo
				};
				process.Start();
				if (int_0 != 0)
				{
					process.WaitForExit(int_0);
				}
				string s = process.StandardOutput.ReadToEnd();
				List<string> list = new List<string>();
				using (StringReader stringReader = new StringReader(s))
				{
					while (stringReader.Peek() != -1)
					{
						string text = stringReader.ReadLine();
						if (text != "")
						{
							list.Add(text);
						}
					}
				}
				result = list.Last();
				return result;
			}

			static EMMCDL()
			{
				flashFirehoseFinish = false;
			}
		}

		public static class Myfiles
		{
			private static string nline;

			private static readonly string[] SizeSuffixes;

			internal static string SizeConvertor(long long_0)
			{
				if (long_0 < 0L)
				{
					return "-" + SizeConvertor(-long_0);
				}
				if (long_0 == 0L)
				{
					return "0.0 bytes";
				}
				int num = (int)Math.Log(long_0, 1024.0);
				decimal num2 = (decimal)long_0 / (decimal)(1L << num * 10);
				return $"{num2:n1} {SizeSuffixes[num]}";
			}

			internal static long ConvertTolong(string string_0)
			{
				return Convert.ToInt64(string_0);
			}

			static Myfiles()
			{
				nline = Environment.NewLine;
				SizeSuffixes = new string[9] { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
			}
		}

		public static string Dir;

		private static bool ok;

		public static string _WorkingDir
		{
			get
			{
				if (!Directory.Exists(Dir))
				{
					Directory.CreateDirectory(Dir);
				}
				if (!Directory.Exists(Dir + "\\_WorkingDir"))
				{
					Directory.CreateDirectory(Dir + "\\_WorkingDir");
				}
				return Dir + "\\_WorkingDir";
			}
		}

		public static string _Firmware
		{
			get
			{
				if (!Directory.Exists(Dir))
				{
					Directory.CreateDirectory(Dir);
				}
				if (!Directory.Exists(Dir + "\\_Firmware"))
				{
					Directory.CreateDirectory(Dir + "\\_Firmware");
				}
				return Dir + "\\_Firmware";
			}
		}

		public static string _TEMP
		{
			get
			{
				if (!Directory.Exists(Dir))
				{
					Directory.CreateDirectory(Dir);
				}
				if (!Directory.Exists(Dir + "\\_TEMP"))
				{
					Directory.CreateDirectory(Dir + "\\_TEMP");
				}
				return Dir + "\\_Firmware";
			}
		}

		public static string _FILES
		{
			get
			{
				if (!Directory.Exists("files"))
				{
					Directory.CreateDirectory("files");
				}
				return "files";
			}
		}

		public static string _DATA
		{
			get
			{
				if (!Directory.Exists("data"))
				{
					Directory.CreateDirectory("data");
				}
				return "data";
			}
		}

		public static string _DATA_TMP
		{
			get
			{
				if (!Directory.Exists(_DATA + "\\tmp"))
				{
					Directory.CreateDirectory(_DATA + "\\tmp");
				}
				return _DATA + "\\tmp";
			}
		}

		public static bool OK => ok;

		public static void CreateDir()
		{
			if (!Directory.Exists(Dir))
			{
				Directory.CreateDirectory(Dir);
			}
			if (!Directory.Exists("data"))
			{
				Directory.CreateDirectory("data");
			}
			if (!Directory.Exists("data\\tmp"))
			{
				Directory.CreateDirectory("data\\tmp");
			}
		}

		internal static void Start()
		{
			if (!Directory.Exists("data"))
			{
				Directory.CreateDirectory("data");
				Directory.CreateDirectory("data\\firehose");
				Directory.CreateDirectory("data\\tmp");
			}
			if (!Directory.Exists("data\\tmp"))
			{
				Directory.CreateDirectory("data\\tmp");
			}
			if (!Directory.Exists("data\\firehose"))
			{
				Directory.CreateDirectory("data\\firehose");
			}
			if (!Directory.Exists("files"))
			{
				Directory.CreateDirectory("files");
			}
			ASDF();
		}

		public static void ASDF()
		{
			string path = "C:\\Windows\\KEY.me";
			if (File.Exists(path))
			{
				ok = true;
			}
		}

		public static string[] smethod_0(string string_0)
		{
			return string_0.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
		}

		static MyClass()
		{
			Dir = "C:\\MPPG_QualcommTool";
		}
	}
}
