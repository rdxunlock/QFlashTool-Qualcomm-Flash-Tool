using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace MPPG
{
	internal class Fastboot
	{
		public static string Flash(string string_0, string string_1)
		{
			Process process = new Process();
			ProcessStartInfo processStartInfo = new ProcessStartInfo();
			processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			processStartInfo.FileName = DC.fastboot;
			processStartInfo.WorkingDirectory = string_1;
			processStartInfo.Arguments = string_0;
			Console.WriteLine(string_0);
			processStartInfo.RedirectStandardOutput = true;
			processStartInfo.UseShellExecute = false;
			processStartInfo.CreateNoWindow = true;
			process.StartInfo = processStartInfo;
			process.Start();
			StreamReader standardOutput = process.StandardOutput;
			string result = standardOutput.ReadToEnd();
			process.WaitForExit();
			standardOutput.Close();
			return result;
		}

		public static void RedirectProcess(string string_0, string string_1)
		{
			Process process = new Process();
			ProcessStartInfo processStartInfo = new ProcessStartInfo();
			processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			processStartInfo.FileName = "cmd.exe";
			processStartInfo.WorkingDirectory = string_1;
			processStartInfo.Arguments = string_0;
			Console.WriteLine(string_0);
			processStartInfo.RedirectStandardOutput = true;
			processStartInfo.UseShellExecute = false;
			processStartInfo.CreateNoWindow = true;
			ProcessStartInfo processStartInfo3 = (process.StartInfo = processStartInfo);
			DataReceivedEventHandler value = p_OutputDataReceived;
			process.OutputDataReceived += value;
			process.Start();
			process.BeginOutputReadLine();
			process.WaitForExit();
		}

		private static void p_OutputDataReceived(object sender, DataReceivedEventArgs e)
		{
			Console.WriteLine(e.Data);
			MessageBox.Show(e.Data);
			Console.WriteLine(e.Data);
		}
	}
}
