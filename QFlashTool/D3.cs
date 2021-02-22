using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using MPPG;

namespace QFlashTool
{
	public static class D3
	{
		public static class Extractor
		{
			private static BackgroundWorker bwWork;

			private static string dloadFile;

			private static string WkDir;

			public static bool finish { get; private set; }

			internal static async void Run(string string_0)
			{
				finish = false;
				await Task.Delay(400);
				if (File.Exists(string_0))
				{
					WkDir = Path.GetDirectoryName(string_0);
					FileInfo f = new FileInfo(string_0);
					dloadFile = f.Name;
					bwWork.WorkerSupportsCancellation = true;
					bwWork.DoWork += bwWork_DoWork;
					bwWork.RunWorkerCompleted += bwWork_RunCompleted;
					if (!bwWork.IsBusy)
					{
						bwWork.RunWorkerAsync();
					}
				}
			}

			private static void bwWork_DoWork(object sender, DoWorkEventArgs e)
			{
				BackgroundWorker backgroundWorker = sender as BackgroundWorker;
				if (!backgroundWorker.CancellationPending)
				{
					try
					{
						string dload = DC.dload;
						string arguments = " " + dloadFile;
						ProcessStartInfo startInfo = new ProcessStartInfo
						{
							WorkingDirectory = WkDir,
							Arguments = arguments,
							CreateNoWindow = true,
							FileName = dload,
							RedirectStandardOutput = true,
							UseShellExecute = false
						};
						Process process = new Process
						{
							StartInfo = startInfo
						};
						process.Start();
						process.WaitForExit(6000);
					}
					catch
					{
						Environment.Exit(0);
					}
				}
			}

			private static void bwWork_RunCompleted(object sender, RunWorkerCompletedEventArgs e)
			{
				finish = true;
			}

			static Extractor()
			{
				bwWork = new BackgroundWorker();
			}
		}

		public static void DirClean(string string_0)
		{
			if (!File.Exists(string_0))
			{
				return;
			}
			FileInfo fileInfo = new FileInfo(string_0);
			string directoryName = fileInfo.DirectoryName;
			DirectoryInfo directoryInfo = new DirectoryInfo(directoryName);
			FileInfo[] files = directoryInfo.GetFiles();
			FileInfo[] array = files;
			foreach (FileInfo fileInfo2 in array)
			{
				if (fileInfo2.Name.EndsWith(".img"))
				{
					MyFile.Delete(fileInfo2.FullName);
				}
			}
		}

		public static void RemoveUnwantedFiles(string string_0)
		{
			string dloadDir = Path.GetDirectoryName(string_0);
			List<string> list = new List<string>
			{
				"crc.img", "fsg.img", "fsc.img", "hyp.img", "sdi.img", "ssd.img", "rpm.img", "amss_verlist.img", "md5rsa.img", "oemsbl_ver.img",
				"oemsbl_verlist.img"
			};
			list.ForEach(delegate(string string_0)
			{
				MyFile.Delete(dloadDir + "\\" + string_0);
			});
		}

		public static string model(string string_0)
		{
			string result = "UNKNOWN";
			if (!File.Exists(string_0))
			{
				return "Error";
			}
			string directoryName = Path.GetDirectoryName(string_0);
			if (File.Exists(directoryName + "\\amss_ver.img"))
			{
				byte[] bytes = File.ReadAllBytes(directoryName + "\\amss_ver.img");
				result = Encoding.ASCII.GetString(bytes);
			}
			return result;
		}

		public static List<string> DownloadList(string string_0)
		{
			string directoryName = Path.GetDirectoryName(string_0);
			DirectoryInfo directoryInfo = new DirectoryInfo(directoryName);
			FileInfo[] files = directoryInfo.GetFiles();
			List<string> list = new List<string>();
			FileInfo[] array = files;
			foreach (FileInfo fileInfo in array)
			{
				if (fileInfo.Name.EndsWith(".img"))
				{
					list.Add(fileInfo.Name);
				}
			}
			return list;
		}
	}
}
