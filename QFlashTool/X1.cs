using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using MPPG;

namespace QFlashTool
{
	public static class X1
	{
		private static string Model;

		public static void Unlock(string string_0)
		{
			Model = string_0;
			new Thread(GO).Start();
			_7zip.Extract("data\\xiaomi\\ulfiles.zip", string_0);
		}

		private static void GO()
		{
			Process process = new Process();
			ProcessStartInfo processStartInfo = new ProcessStartInfo();
			processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			processStartInfo.FileName = DC.adb;
			processStartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
			processStartInfo.Arguments = "devices";
			Console.WriteLine("devices");
			processStartInfo.RedirectStandardOutput = true;
			processStartInfo.UseShellExecute = false;
			processStartInfo.CreateNoWindow = true;
			process.StartInfo = processStartInfo;
			process.OutputDataReceived += receiver;
			process.ErrorDataReceived += receiver;
			process.Start();
			process.BeginOutputReadLine();
			process.WaitForExit();
		}

		private static void receiver(object sender, DataReceivedEventArgs e)
		{
			Console.WriteLine(e.Data);
			if (e.Data != null)
			{
				M._F1.update(e.Data);
				Console.WriteLine(e.Data);
			}
		}

		static X1()
		{
			Model = string.Empty;
		}
	}
}
