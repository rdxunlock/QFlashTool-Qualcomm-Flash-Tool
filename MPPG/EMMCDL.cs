using System.Diagnostics;
using System.IO;

namespace MPPG
{
	public static class EMMCDL
	{
		public static string FlashProgram(string string_0, string string_1)
		{
			Process process = new Process();
			process.StartInfo.FileName = DC.emmcdl;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.RedirectStandardError = true;
			process.EnableRaisingEvents = false;
			process.StartInfo.Arguments = " -p " + string_0 + " -f " + string_1;
			process.Start();
			process.WaitForExit(3000);
			string text = process.StandardOutput.ReadToEnd();
			if (text.Contains("Status: 0 The operation completed successfully"))
			{
				return "OK";
			}
			return "Fail";
		}
	}
}
