using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using QFlashTool.Properties;

namespace MPPG
{
	public static class Qualcomm
	{
		public static class EMMCDL
		{
			internal static BackgroundWorker bwWork;

			public static string SetCommand;

			internal static string SetDir;

			internal static string RUN_Command => SetCommand;

			internal static string RunDir => SetDir;

			internal static void RUN()
			{
				bwWork.WorkerSupportsCancellation = true;
				bwWork.DoWork += bwWork_DoWork;
				bwWork.RunWorkerCompleted += bwWork_RunCompleted;
				if (!bwWork.IsBusy)
				{
					bwWork.RunWorkerAsync();
				}
			}

			internal static void bwWork_DoWork(object sender, DoWorkEventArgs e)
			{
				BackgroundWorker backgroundWorker = sender as BackgroundWorker;
				if (!backgroundWorker.CancellationPending)
				{
					try
					{
						string fileName = "cmd.exe";
						string arguments = "/C   emmcdl  " + SetCommand;
						ProcessStartInfo startInfo = new ProcessStartInfo
						{
							WorkingDirectory = SetDir,
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
						process.StandardOutput.ReadToEnd();
					}
					catch
					{
						Environment.Exit(0);
					}
				}
			}

			internal static void bwWork_RunCompleted(object sender, RunWorkerCompletedEventArgs e)
			{
			}

			static EMMCDL()
			{
				bwWork = new BackgroundWorker();
				SetCommand = "";
			}
		}

		public static class FH_LOADER
		{
			public static string DOC;

			public static string trace;

			private static BackgroundWorker bw;

			internal static void flash(string string_0)
			{
			}

			static FH_LOADER()
			{
				DOC = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
				trace = DOC + "\\port_trace.txt";
				bw = new BackgroundWorker();
			}
		}

		public static class QSaharaServer
		{
			public static string DOC;

			public static string trace;

			private static bool finish;

			public static bool isFinished => finish;

			internal static void RUN(string string_0)
			{
				finish = false;
				Process process = new Process();
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.CreateNoWindow = true;
				process.StartInfo.RedirectStandardError = true;
				process.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
				process.StartInfo.RedirectStandardInput = true;
				process.StartInfo.RedirectStandardOutput = true;
				process.StartInfo.FileName = "cmd.exe";
				process.StartInfo.Arguments = "/c " + string_0 + " &&  exit";
				process.Start();
				_ = process.StandardOutput;
				string contents = process.StandardOutput.ReadToEnd();
				process.StandardError.ReadToEnd();
				File.WriteAllText("tack1.txt", contents);
				finish = true;
			}

			static QSaharaServer()
			{
				DOC = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
				trace = DOC + "\\port_trace.txt";
				finish = false;
			}
		}

		public static class Device
		{
			internal static List<string> gpt(string string_0, string string_1)
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
				process.WaitForExit(2000);
				string s = process.StandardOutput.ReadToEnd();
				using (StringReader stringReader = new StringReader(s))
				{
					while (stringReader.Peek() != -1)
					{
						string text = stringReader.ReadLine();
						if (text.Contains("Partition Name:") & text.Contains("Start LBA"))
						{
							list.Add(text);
						}
					}
				}
				return list;
			}
		}

		public static void SetDefault()
		{
			EMMCDL.SetCommand = "";
		}

		public static string partition(string string_0)
		{
			string result = string_0 + ".mbn";
			switch (string_0)
			{
			case "recovery":
				result = "recovery.img";
				break;
			case "cache":
				result = "cache.img";
				break;
			case "modemst1":
				result = "modem_st1.mbn";
				break;
			case "gpt":
				result = "gpt_both0.bin";
				break;
			case "log":
				result = "log.img";
				break;
			case "cust":
				result = "cust.img";
				break;
			case "system":
				result = "system.img";
				break;
			case "aboot":
				result = "emmc_appsboot.mbn";
				break;
			case "splash":
				result = "splash.img";
				break;
			case "boot":
				result = "boot.img";
				break;
			case "modem":
				result = "NON-HLOS.bin";
				break;
			case "userdata":
				result = "userdata.img";
				break;
			case "fsg":
				result = "fs_image.tar.gz.mbn.img";
				break;
			case "modemst2":
				result = "modem_st2.mbn";
				break;
			case "logo":
				result = "logo.img";
				break;
			}
			return result;
		}

		public static void Create_rawprogram(string string_0, string string_1)
		{
			string path = string_1 + "\\rawprogram0.xml";
			string text = string_1 + "\\selparts.txt";
			string text2 = string_1 + "\\parttable.txt";
			string text3 = string_1 + "\\make.cmd";
			try
			{
				if (File.Exists(string_1 + "\\rawprogram0.xml"))
				{
					MyFile.Delete(string_1 + "\\rawprogram0.xml");
				}
				if (File.Exists(string_1 + "\\selparts.txt"))
				{
					MyFile.Delete(string_1 + "\\selparts.txt");
				}
				if (File.Exists(string_1 + "\\parttable.txt"))
				{
					MyFile.Delete(string_1 + "\\parttable.txt");
				}
			}
			catch
			{
			}
			Process process = new Process();
			process.StartInfo.FileName = DC.gdisk;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.WorkingDirectory = string_1;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.RedirectStandardError = true;
			process.EnableRaisingEvents = false;
			process.StartInfo.Arguments = string_0 + "  -l";
			process.Start();
			process.WaitForExit();
			string text4 = process.StandardOutput.ReadToEnd();
			if (text4.Contains("GPT: not present"))
			{
				File.WriteAllText(path, "GPT: not present");
				return;
			}
			using StringReader stringReader = new StringReader(text4);
			while (stringReader.Peek() != -1)
			{
				string text5 = stringReader.ReadLine();
				if (text5.StartsWith("   ") || text5.StartsWith("  1") || text5.StartsWith("  2") || text5.StartsWith("  3") || text5.StartsWith("  4") || text5.StartsWith("  5"))
				{
					string[] array = text5.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
					string text6 = (Convert.ToInt32(array[2]) - Convert.ToInt32(array[1])).ToString();
					using (StreamWriter streamWriter = new StreamWriter(text2, append: true))
					{
						streamWriter.Write(array[0] + "    " + array[6] + "  " + array[1] + "   " + text6 + Environment.NewLine);
						streamWriter.Flush();
						streamWriter.Close();
					}
					array[1] = (Convert.ToInt32(array[1]) * 512).ToString("X");
					array[2] = (Convert.ToInt32(array[2]) * 512).ToString("X");
					using StreamWriter streamWriter2 = new StreamWriter(text, append: true);
					streamWriter2.Write(array[6] + Environment.NewLine);
					streamWriter2.Flush();
					streamWriter2.Close();
				}
			}
			stringReader.Close();
			File.WriteAllText(text3, Resources.emmc2Firmware);
			Process process2 = new Process();
			process2.StartInfo.FileName = text3;
			process2.StartInfo.CreateNoWindow = true;
			process2.StartInfo.UseShellExecute = false;
			process2.StartInfo.WorkingDirectory = string_1;
			process2.StartInfo.RedirectStandardOutput = true;
			process2.StartInfo.RedirectStandardError = true;
			process2.EnableRaisingEvents = false;
			process2.Start();
			process2.WaitForExit();
			MyFile.Delete(text3);
			MyFile.Delete(text);
			MyFile.Delete(text2);
		}
	}
}
