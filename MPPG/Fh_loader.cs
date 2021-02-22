using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using QFlashTool;

namespace MPPG
{
	public static class Fh_loader
	{
		public static string DOC;

		public static string trace;

		public static List<string> local;

		public static string RESULT;

		public static bool finish;

		public static bool isRunnung
		{
			get
			{
				bool result = false;
				Process[] processes = Process.GetProcesses();
				Process[] array = processes;
				foreach (Process process in array)
				{
					result = (process.ProcessName.ToLower().Contains("fh_loader") ? true : false);
				}
				return result;
			}
		}

		public static bool DownloadFinish => finish;

		public static string Result(string string_0)
		{
			new M();
			return string_0;
		}

		internal static string Flash(string string_0)
		{
			finish = false;
			local.Clear();
			string text = "";
			string fileName = "cmd.exe";
			string arguments = "/C  " + DC.fh_loader + "  " + string_0;
			ProcessStartInfo startInfo = new ProcessStartInfo
			{
				WorkingDirectory = DOC,
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
			string text2 = process.StandardOutput.ReadToEnd();
			File.WriteAllText(Path.GetTempPath() + "\\Fuck.txt", text2);
			using (StringReader stringReader = new StringReader(text2))
			{
				while (stringReader.Peek() != -1)
				{
					string text3 = stringReader.ReadLine();
					if (text3 != "")
					{
						if (text3.Contains("ERROR"))
						{
							local.Add(text3);
						}
						else
						{
							text = ((!text3.Contains("All Finished Successfully")) ? "" : text3);
						}
					}
				}
				stringReader.Close();
			}
			MyFile.Delete(trace);
			process.WaitForExit();
			RESULT = text;
			return text;
		}

		public static void Download_eMMC(string string_0, string string_1)
		{
			string string_2 = "  --port=\\\\.\\" + string_0 + "   --sendimage=\"" + string_1 + "\"  --noprompt  --zlpawarehost=1 --memoryname=eMMC --reset";
			Flash(string_2);
		}

		private static void Download_Now(string string_0)
		{
			local.Clear();
			Process process = new Process();
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.RedirectStandardError = true;
			process.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
			process.StartInfo.RedirectStandardInput = true;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.FileName = "cmd.exe";
			process.StartInfo.Arguments = "/c " + string_0 + " &&  exit";
			process.Start();
			_ = process.StandardOutput;
			string text = process.StandardOutput.ReadToEnd();
			process.StandardError.ReadToEnd();
			using (StringReader stringReader = new StringReader(text))
			{
				while (stringReader.Peek() != -1)
				{
					string text2 = stringReader.ReadLine();
					if (text2 != "" && text2.Contains("ERROR"))
					{
						local.Add(text2);
					}
				}
			}
			File.WriteAllText("tack1.txt", text);
		}

		static Fh_loader()
		{
			DOC = MyClass._WorkingDir;
			trace = DOC + "\\port_trace.txt";
			local = new List<string>();
			RESULT = "";
			finish = false;
		}
	}
}
