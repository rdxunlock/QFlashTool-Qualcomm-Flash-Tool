using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace QFlashTool
{
	public static class O1
	{
		private static BackgroundWorker bwWork;

		private static string ReceiveCommand;

		private static string RunDir;

		public static bool finish { get; private set; }

		internal static async void RUN(string string_0, string string_1)
		{
			finish = false;
			await Task.Delay(400);
			ReceiveCommand = string_0;
			string_1 = RunDir;
			if (string_1 == "")
			{
				string_1 = Directory.GetCurrentDirectory();
			}
			bwWork.WorkerSupportsCancellation = true;
			bwWork.DoWork += bwWork_DoWork;
			bwWork.RunWorkerCompleted += bwWork_RunCompleted;
			if (!bwWork.IsBusy)
			{
				bwWork.RunWorkerAsync();
			}
		}

		private static void bwWork_DoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker backgroundWorker = sender as BackgroundWorker;
			if (!backgroundWorker.CancellationPending)
			{
				try
				{
					string fileName = "cmd.exe";
					string arguments = "/c    " + ReceiveCommand;
					ProcessStartInfo startInfo = new ProcessStartInfo
					{
						WorkingDirectory = RunDir,
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

		private static void bwWork_RunCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			finish = true;
		}

		static O1()
		{
			bwWork = new BackgroundWorker();
			RunDir = string.Empty;
		}
	}
}
