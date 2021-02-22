using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using MPPG;

namespace QFlashTool
{
	public static class CMD
	{
		public static bool SetFinish;

		public static string result { get; private set; }

		public static bool GetFinish => SetFinish;

		public static string flashEdl(string string_0, string string_1, string string_2, string string_3)
		{
			Process process = new Process();
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.RedirectStandardError = true;
			process.StartInfo.RedirectStandardInput = true;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.FileName = "cmd.exe";
			process.StartInfo.Arguments = "/c " + DC.emmcdl + "  -p " + string_0 + " -f " + string_1 + " -b " + string_2 + " " + string_3 + " &&  exit";
			process.Start();
			_ = process.StandardOutput;
			string s = process.StandardOutput.ReadToEnd();
			process.StandardError.ReadToEnd();
			List<string> list = new List<string>();
			using (StringReader stringReader = new StringReader(s))
			{
				while (stringReader.Peek() != -1)
				{
					string text = stringReader.ReadLine();
					if (text != "")
					{
						list.Add(text);
					}
				}
			}
			result = list.Last();
			SetFinish = true;
			return result;
		}

		public static string BackupEdl(string string_0, string string_1, string string_2, string string_3)
		{
			Process process = new Process();
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.RedirectStandardError = true;
			process.StartInfo.RedirectStandardInput = true;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.FileName = "cmd.exe";
			process.StartInfo.Arguments = "/c " + DC.emmcdl + " -p " + string_0 + " -f " + string_1 + " -d " + string_2 + " -o " + string_3 + " &&  exit";
			process.Start();
			_ = process.StandardOutput;
			string s = process.StandardOutput.ReadToEnd();
			process.StandardError.ReadToEnd();
			List<string> list = new List<string>();
			using (StringReader stringReader = new StringReader(s))
			{
				while (stringReader.Peek() != -1)
				{
					string text = stringReader.ReadLine();
					if (text != "")
					{
						list.Add(text);
					}
				}
			}
			result = list.Last();
			SetFinish = true;
			return result;
		}

		public static string General(string string_0, string string_1)
		{
			if (string_1 == "")
			{
				string_1 = Directory.GetCurrentDirectory();
			}
			SetFinish = false;
			Process process = new Process();
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.RedirectStandardError = true;
			process.StartInfo.WorkingDirectory = string_1;
			process.StartInfo.RedirectStandardInput = true;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.FileName = "cmd.exe";
			process.StartInfo.Arguments = "/c " + string_0 + " &&  exit";
			process.Start();
			_ = process.StandardOutput;
			string text = process.StandardOutput.ReadToEnd();
			process.StandardError.ReadToEnd();
			SetFinish = true;
			return text;
		}

		internal static string Command(string string_0, string string_1)
		{
			SetFinish = false;
			string fileName = "cmd.exe";
			string arguments = "/c  " + string_0;
			ProcessStartInfo startInfo = new ProcessStartInfo
			{
				WorkingDirectory = string_1,
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
			try
			{
				process.Start();
			}
			catch
			{
				Environment.Exit(0);
			}
			string text = process.StandardOutput.ReadToEnd();
			SetFinish = true;
			return text;
		}

		static CMD()
		{
			SetFinish = false;
		}
	}
}
