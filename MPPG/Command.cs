using System;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace MPPG
{
	public static class Command
	{
		public const int DEFAULT_TIMEOUT = -1;

		[Obsolete("Method is deprecated, please use RunProcessNoReturn(string, string, int) instead.")]
		internal static void RunProcessNoReturn(string string_0, string string_1, bool bool_0 = true)
		{
			using Process process = new Process();
			process.StartInfo.FileName = string_0;
			process.StartInfo.Arguments = string_1;
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.UseShellExecute = true;
			process.Start();
			if (bool_0)
			{
				process.WaitForExit();
			}
		}

		internal static void RunProcessNoReturn(string string_0, string string_1, int int_0)
		{
			using Process process = new Process();
			process.StartInfo.FileName = string_0;
			process.StartInfo.Arguments = string_1;
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.UseShellExecute = true;
			process.Start();
			process.WaitForExit(int_0);
		}

		internal static string RunProcessReturnOutput(string string_0, string string_1, int int_0)
		{
			using Process process = new Process();
			process.StartInfo.FileName = string_0;
			process.StartInfo.Arguments = string_1;
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.RedirectStandardError = true;
			using AutoResetEvent autoResetEvent_ = new AutoResetEvent(initialState: false);
			using AutoResetEvent autoResetEvent_2 = new AutoResetEvent(initialState: false);
			return HandleOutput(process, autoResetEvent_, autoResetEvent_2, int_0, bool_0: false);
		}

		internal static string RunProcessReturnOutput(string string_0, string string_1, bool bool_0, int int_0)
		{
			using Process process = new Process();
			process.StartInfo.FileName = string_0;
			process.StartInfo.Arguments = string_1;
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.RedirectStandardError = true;
			using AutoResetEvent autoResetEvent_ = new AutoResetEvent(initialState: false);
			using AutoResetEvent autoResetEvent_2 = new AutoResetEvent(initialState: false);
			return HandleOutput(process, autoResetEvent_, autoResetEvent_2, int_0, bool_0);
		}

		private static string HandleOutput(Process process_0, AutoResetEvent autoResetEvent_0, AutoResetEvent autoResetEvent_1, int int_0, bool bool_0)
		{
			StringBuilder output = new StringBuilder();
			StringBuilder error = new StringBuilder();
			process_0.OutputDataReceived += delegate(object sender, DataReceivedEventArgs e)
			{
				if (e.Data == null)
				{
					autoResetEvent_0.Set();
				}
				else
				{
					output.AppendLine(e.Data);
				}
			};
			process_0.ErrorDataReceived += delegate(object sender, DataReceivedEventArgs e)
			{
				if (e.Data == null)
				{
					autoResetEvent_1.Set();
				}
				else
				{
					error.AppendLine(e.Data);
				}
			};
			process_0.Start();
			process_0.BeginOutputReadLine();
			process_0.BeginErrorReadLine();
			if (process_0.WaitForExit(int_0) && autoResetEvent_0.WaitOne(int_0) && autoResetEvent_1.WaitOne(int_0))
			{
				return (!(error.ToString().Trim().Length.Equals(0) || bool_0)) ? error.ToString().Trim() : output.ToString().Trim();
			}
			return "PROCESS TIMEOUT";
		}

		public static bool IsProcessRunning(string string_0)
		{
			bool result = false;
			Process[] processes = Process.GetProcesses();
			Process[] array = processes;
			foreach (Process process in array)
			{
				if (process.ProcessName.ToLower().Contains(string_0.ToLower()))
				{
					result = true;
				}
			}
			return result;
		}

		public static void KillProcess(string string_0)
		{
			Process[] processes = Process.GetProcesses();
			Process[] array = processes;
			int num = 0;
			Process process;
			while (true)
			{
				if (num < array.Length)
				{
					process = array[num];
					if (process.ProcessName.ToLower().Contains(string_0.ToLower()))
					{
						break;
					}
					num++;
					continue;
				}
				return;
			}
			process.Kill();
			process.WaitForExit();
		}
	}
}
