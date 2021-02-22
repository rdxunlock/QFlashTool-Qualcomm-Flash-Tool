using System.Diagnostics;
using System.IO;
using System.Threading;

namespace MPPG
{
	public static class Usb
	{
		private static bool isConnected;

		private static string port;

		public static bool IsConnected => isConnected;

		internal static string Port => port;

		internal static string COM
		{
			get
			{
				string fileName = "cmd.exe";
				string arguments = "/C  " + DC.emmcdl + " -l";
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
				Thread.Sleep(100);
				if (text.Contains("Qualcomm HS-USB QDLoader 9008"))
				{
					using (StringReader stringReader = new StringReader(text))
					{
						while (stringReader.Peek() != -1)
						{
							string text2 = stringReader.ReadLine();
							if (text2.Contains("Qualcomm HS-USB QDLoader 9008"))
							{
								port = text2;
							}
						}
						stringReader.Close();
					}
					isConnected = true;
				}
				else
				{
					isConnected = false;
				}
				string text3 = port;
				try
				{
					text3 = text3.Substring(text3.IndexOf("(") + 1);
					text3 = text3.Substring(0, text3.Length - 1);
				}
				catch
				{
				}
				if (text3.Contains(")"))
				{
					text3 = text3.Replace(")", "");
				}
				return text3;
			}
		}

		internal static void Detect()
		{
			string fileName = "cmd.exe";
			string arguments = "/C   " + DC.emmcdl + " -l";
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
			Thread.Sleep(100);
			if (text.Contains("Qualcomm HS-USB QDLoader 9008"))
			{
				using (StringReader stringReader = new StringReader(text))
				{
					while (stringReader.Peek() != -1)
					{
						string text2 = stringReader.ReadLine();
						if (text2.Contains("Qualcomm HS-USB QDLoader 9008"))
						{
							port = text2;
						}
					}
					stringReader.Close();
				}
				isConnected = true;
			}
			else
			{
				isConnected = false;
			}
		}

		static Usb()
		{
			port = "()";
		}
	}
}
