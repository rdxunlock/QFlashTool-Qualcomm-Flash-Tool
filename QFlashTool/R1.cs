using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MPPG;

namespace QFlashTool
{
	public static class R1
	{
		public static string rst;

		public static bool ok;

		private static bool inFastboot;

		private static bool inAdb;

		private static bool in9008;

		private static bool in9006;

		private static bool not;

		public static bool IsinFastboot => inFastboot;

		public static bool IsinAdb => inAdb;

		public static bool Isin9008 => in9008;

		public static bool Isin9006 => in9006;

		public static bool notConnected => not;

		internal static string _9006(string string_0, string string_1)
		{
			string rst = "Error";
			string mprg = string.Empty;
			string msimage = string.Empty;
			DirectoryInfo directoryInfo = new DirectoryInfo(string_1);
			FileInfo[] array = null;
			array = directoryInfo.GetFiles();
			FileInfo[] array2 = array;
			foreach (FileInfo fileInfo in array2)
			{
				if (fileInfo.Name.StartsWith("MPRG"))
				{
					mprg = string_1 + "\\" + fileInfo.Name;
				}
				if (fileInfo.Name.Contains("msimage"))
				{
					msimage = string_1 + "\\" + fileInfo.Name;
				}
			}
			if (mprg != string.Empty && msimage != string.Empty)
			{
				Thread thread = new Thread((ThreadStart)delegate
				{
					Process process = new Process();
					process.StartInfo.FileName = DC.emmcdl;
					process.StartInfo.CreateNoWindow = true;
					process.StartInfo.UseShellExecute = false;
					process.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
					process.StartInfo.RedirectStandardOutput = true;
					process.StartInfo.RedirectStandardError = true;
					process.EnableRaisingEvents = false;
					process.StartInfo.Arguments = " -p " + string_0 + " -f " + mprg + " -i " + msimage;
					process.Start();
					process.WaitForExit(3000);
					string text = process.StandardOutput.ReadToEnd();
					process.StartInfo.Arguments = " -p " + string_0 + " -f " + mprg + " -r ";
					process.Start();
					process.WaitForExit(1000);
					if (text.Contains("Status: 0 The operation completed successfully"))
					{
						rst = "OK";
					}
				});
				thread.IsBackground = true;
				thread.Start();
				while (thread.IsAlive)
				{
					Application.DoEvents();
				}
			}
			return rst;
		}

		internal static string Edl()
		{
			string result = "Error";
			Thread thread = new Thread((ThreadStart)delegate
			{
				D2.Detect();
			});
			thread.IsBackground = true;
			thread.Start();
			while (thread.IsAlive)
			{
				Application.DoEvents();
			}
			if (D2.IsinAdb)
			{
				try
				{
					CMD.General(" adb reboot edl ", "");
					result = "OK";
				}
				catch
				{
				}
			}
			else if (D2.IsinFastboot)
			{
				try
				{
					CMD.General(" fastboot_edl reboot-edl ", "");
					result = "OK";
				}
				catch
				{
				}
			}
			return result;
		}

		public static async void Normal()
		{
			int i = 20;
			while (i >= 0)
			{
				D2.Detect();
				await Task.Delay(1000);
				rst = "Waitng " + i;
				if (!IsinAdb)
				{
					if (i == 0)
					{
						rst = "waiting timeout";
					}
					i--;
					continue;
				}
				Adb.reboot();
				rst = "Device reboot to normal successfully";
				ok = true;
				break;
			}
		}

		public static void Detect()
		{
			in9006 = false;
			in9008 = false;
			inAdb = false;
			inFastboot = false;
			not = false;
			try
			{
				string Runner;
				string command;
				Thread thread = new Thread((ThreadStart)delegate
				{
					Process process = new Process
					{
						StartInfo = 
						{
							CreateNoWindow = true,
							UseShellExecute = false,
							WorkingDirectory = Directory.GetCurrentDirectory(),
							RedirectStandardOutput = true,
							RedirectStandardError = true
						},
						EnableRaisingEvents = false
					};
					Runner = DC.adb;
					command = " get-state";
					process.StartInfo.FileName = Runner;
					process.StartInfo.Arguments = command;
					process.Start();
					string text = process.StandardOutput.ReadToEnd();
					if (text.Trim().Equals("device"))
					{
						inAdb = true;
					}
					else if (text.Contains("recovery"))
					{
						inAdb = true;
					}
					else
					{
						process.WaitForExit();
						Runner = DC.fastboot;
						command = " devices ";
						process.StartInfo.FileName = Runner;
						process.StartInfo.Arguments = command;
						process.Start();
						if (process.StandardOutput.ReadToEnd() != "")
						{
							inFastboot = true;
						}
						else
						{
							process.WaitForExit();
							Runner = DC.emmcdl;
							command = " -l ";
							process.StartInfo.FileName = Runner;
							process.StartInfo.Arguments = command;
							process.Start();
							if (process.StandardOutput.ReadToEnd().Contains("COM"))
							{
								in9008 = true;
							}
							else
							{
								process.WaitForExit();
								Runner = DC.usb;
								command = "";
								process.StartInfo.FileName = Runner;
								process.StartInfo.Arguments = command;
								process.Start();
								if (process.StandardOutput.ReadToEnd().Contains("9006"))
								{
									in9006 = true;
								}
								else
								{
									process.WaitForExit();
								}
							}
						}
					}
				});
				thread.IsBackground = true;
				thread.Start();
				while (thread.IsAlive)
				{
					Application.DoEvents();
				}
			}
			catch (Exception)
			{
				throw;
			}
		}

		static R1()
		{
			rst = "";
			ok = false;
		}
	}
}
