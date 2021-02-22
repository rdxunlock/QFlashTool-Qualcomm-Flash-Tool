using System.Collections.Generic;
using System.Diagnostics;

namespace QFlashTool
{
	public static class BoardFirmwareFlasher
	{
		private static List<string> result;

		public static List<string> FlashResult => result;

		public static string DownloadFastbootImages(string string_0)
		{
			string fileName = "cmd.exe";
			string arguments = "/C   " + string_0;
			ProcessStartInfo startInfo = new ProcessStartInfo
			{
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
			if (text.Contains("fail"))
			{
				return "Fail";
			}
			return "OK";
		}

		public static string runCommand(string string_0)
		{
			Process process = new Process();
			process.StartInfo.FileName = "cmd.exe";
			process.StartInfo.Arguments = "/C  " + string_0;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.RedirectStandardError = true;
			process.ErrorDataReceived += OutputHandler;
			process.Start();
			process.BeginErrorReadLine();
			return process.StandardOutput.ReadToEnd();
		}

		public static void OutputHandler(object sender, DataReceivedEventArgs e)
		{
			result.Add(e.Data);
		}

		static BoardFirmwareFlasher()
		{
			result = new List<string> { "" };
		}
	}
}
