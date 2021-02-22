using System.Diagnostics;
using System.IO;

namespace MPPG
{
	public static class Devices
	{
		public static bool isInFastboot
		{
			get
			{
				Process process = new Process();
				process.StartInfo.FileName = DC.fastboot;
				process.StartInfo.CreateNoWindow = true;
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
				process.StartInfo.RedirectStandardOutput = true;
				process.StartInfo.RedirectStandardError = true;
				process.EnableRaisingEvents = false;
				process.StartInfo.Arguments = "devices";
				process.Start();
				string text = process.StandardOutput.ReadToEnd();
				process.WaitForExit();
				if (text != "")
				{
					return true;
				}
				return false;
			}
		}

		public static bool isInEDL
		{
			get
			{
				Process process = new Process();
				process.StartInfo.FileName = DC.emmcdl;
				process.StartInfo.CreateNoWindow = true;
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
				process.StartInfo.RedirectStandardOutput = true;
				process.StartInfo.RedirectStandardError = true;
				process.EnableRaisingEvents = false;
				process.StartInfo.Arguments = " -l ";
				process.Start();
				string text = process.StandardOutput.ReadToEnd();
				if (text.Contains("COM"))
				{
					return true;
				}
				return false;
			}
		}
	}
}
