using System.Diagnostics;
using System.IO;

namespace MPPG
{
	public static class SFK
	{
		public static string PartCopy(string string_0, string string_1, string string_2, string string_3)
		{
			if (!File.Exists(string_0))
			{
				return "error";
			}
			string directoryName = Path.GetDirectoryName(string_0);
			FileInfo fileInfo = new FileInfo(string_0);
			string_0 = fileInfo.Name;
			Process process = new Process();
			process.StartInfo.FileName = DC.sfk;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.WorkingDirectory = directoryName;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.RedirectStandardError = true;
			process.EnableRaisingEvents = false;
			string arguments = " partcopy \"" + string_0 + "\" -fromto " + string_1 + " " + string_2 + " " + string_3 + " -yes ";
			process.StartInfo.Arguments = arguments;
			try
			{
				process.Start();
				process.WaitForExit();
			}
			catch
			{
			}
			return process.StandardOutput.ReadToEnd();
		}
	}
}
