using System.Diagnostics;
using System.IO;
using MPPG;

namespace QFlashTool
{
	public static class _7zip
	{
		internal static void Extract(string string_0, string string_1)
		{
			Path.GetDirectoryName(string_0);
			Process process = new Process();
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.RedirectStandardError = true;
			process.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
			process.StartInfo.RedirectStandardInput = true;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.FileName = DC._7z;
			process.StartInfo.Arguments = " x " + string_0 + " " + string_1 + "  -y ";
			process.Start();
			_ = process.StandardOutput;
			process.StandardOutput.ReadToEnd();
			process.StandardError.ReadToEnd();
		}
	}
}
