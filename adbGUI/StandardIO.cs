using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace adbGUI
{
	public static class StandardIO
	{
		public static string AdbCMDBackground(string string_0, string string_1, string string_2 = "")
		{
			string fileName = "cmd.exe";
			string arguments = "/C " + string_0 + " tools\\adb " + string_2 + " " + string_1;
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
			return process.StandardOutput.ReadToEnd();
		}

		public static void AdbCMDBackgroundNoReturn(string string_0, string string_1, string string_2 = "")
		{
			string fileName = "cmd.exe";
			string arguments = "/C " + string_0 + " tools\\adb " + string_2 + " " + string_1;
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
		}

		public static void AdbCMD(string string_0, string string_1 = "")
		{
			string arguments = "/C prompt $G & tools\\adb" + string_1 + " " + string_0 + " & echo. & echo. & pause";
			ProcessStartInfo startInfo = new ProcessStartInfo
			{
				Arguments = arguments,
				FileName = "cmd.exe",
				WindowStyle = ProcessWindowStyle.Normal
			};
			Process process = new Process
			{
				StartInfo = startInfo
			};
			process.Start();
		}

		public static List<string> GetDevices()
		{
			List<string> list = new List<string>();
			string text = AdbCMDBackground("", "devices -l");
			if (text.Length > 29)
			{
				using StringReader stringReader = new StringReader(text);
				while (stringReader.Peek() != -1)
				{
					string text2 = stringReader.ReadLine();
					if (!text2.StartsWith("List") && !text2.StartsWith("\r\n") && !(text2.Trim() == "") && !text2.StartsWith("*") && text2.IndexOf(' ') != -1)
					{
						text2 = text2.Substring(0, text2.IndexOf(' '));
						list.Add(text2);
					}
				}
				stringReader.Close();
			}
			return list;
		}

		public static void KillServer()
		{
			Process[] processesByName = Process.GetProcessesByName("adb");
			foreach (Process process in processesByName)
			{
				process.Kill();
			}
		}

		public static void NoDeviceConnected()
		{
			MessageBox.Show("No device connected. Please connect a device and select it.\t", "Error - No device connected", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}
	}
}
