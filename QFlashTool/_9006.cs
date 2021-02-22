using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using MPPG;

namespace QFlashTool
{
	internal class _9006
	{
		private string drive = "";

		private string block0 = "";

		private string workingDir = "";

		private int count = 0;

		public static string time
		{
			get
			{
				DateTime now = DateTime.Now;
				return (" " + now.Hour + ":" + now.Minute + ":" + now.Second).ToString();
			}
		}

		public bool WriteFinish { get; private set; }

		public void Write(string string_0, string string_1)
		{
			if (!File.Exists(string_1))
			{
				M._F1.update("error eMMC file not found");
			}
			drive = string_0;
			FileInfo fileInfo = new FileInfo(string_1);
			block0 = fileInfo.Name;
			workingDir = Path.GetDirectoryName(string_1);
			Start();
		}

		private void Start()
		{
			new Thread(method_0).Start();
		}

		private void method_0()
		{
			WriteFinish = false;
			string text = " w " + drive + " " + block0;
			Process process = new Process();
			ProcessStartInfo processStartInfo = new ProcessStartInfo();
			processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			processStartInfo.FileName = DC.mmc;
			processStartInfo.WorkingDirectory = workingDir;
			processStartInfo.Arguments = text;
			Console.WriteLine(text);
			processStartInfo.RedirectStandardOutput = true;
			processStartInfo.UseShellExecute = false;
			processStartInfo.CreateNoWindow = true;
			process.StartInfo = processStartInfo;
			process.ErrorDataReceived += _9006Receiver;
			process.OutputDataReceived += _9006Receiver;
			count++;
			process.Start();
			process.BeginOutputReadLine();
			process.WaitForExit();
			WriteFinish = true;
		}

		private void _9006Receiver(object sender, DataReceivedEventArgs e)
		{
			Console.WriteLine(e.Data);
			if (e.Data != null)
			{
				if (!e.Data.StartsWith("Writing log") & !e.Data.StartsWith("Log") & !e.Data.Contains("fh_loader.exe"))
				{
					M._F1.update("====================================\n  " + time + " " + e.Data + "\r\n====================================\n");
					Console.WriteLine(e.Data);
				}
				if (e.Data.Contains("Error") && count < 5)
				{
					Start();
				}
			}
		}
	}
}
