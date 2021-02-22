using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using MPPG;

namespace QFlashTool
{
	public static class D2
	{
		private static string quote;

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

		public static bool isRooted
		{
			get
			{
				Process process = new Process();
				process.StartInfo.CreateNoWindow = true;
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
				process.StartInfo.RedirectStandardOutput = true;
				process.StartInfo.RedirectStandardError = true;
				process.EnableRaisingEvents = false;
				string adb = DC.adb;
				string arguments = " shell   su -c " + quote + " echo hello \"";
				process.StartInfo.FileName = adb;
				process.StartInfo.Arguments = arguments;
				process.Start();
				string text = process.StandardOutput.ReadToEnd();
				if (text.Trim().Equals("hello"))
				{
					return true;
				}
				return false;
			}
		}

		public static bool isBusyboxInstalled
		{
			get
			{
				Process process = new Process();
				process.StartInfo.CreateNoWindow = true;
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
				process.StartInfo.RedirectStandardOutput = true;
				process.StartInfo.RedirectStandardError = true;
				process.EnableRaisingEvents = false;
				string adb = DC.adb;
				string arguments = " shell \" su -c busybox echo hello \"";
				process.StartInfo.FileName = adb;
				process.StartInfo.Arguments = arguments;
				process.Start();
				string text = process.StandardOutput.ReadToEnd();
				if (text.Trim().Equals("hello"))
				{
					return true;
				}
				return false;
			}
		}

		public static string String_0
		{
			get
			{
				Process process = new Process();
				process.StartInfo.CreateNoWindow = true;
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
				process.StartInfo.RedirectStandardOutput = true;
				process.StartInfo.RedirectStandardError = true;
				process.EnableRaisingEvents = false;
				string adb = DC.adb;
				string arguments = " shell su -c " + quote + " busybox blockdev --getsize64 /dev/block/mmcblk0 " + quote;
				process.StartInfo.FileName = adb;
				process.StartInfo.Arguments = arguments;
				process.Start();
				process.WaitForExit();
				string value = process.StandardOutput.ReadToEnd();
				return MyClass.Myfiles.SizeConvertor(Convert.ToInt64(value));
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

		public static string BusyboxInstall()
		{
			if (!File.Exists("data\\busybox"))
			{
				MessageBox.Show(" busybox missing form PC", "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				return "error";
			}
			Process process = new Process();
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.RedirectStandardError = true;
			process.EnableRaisingEvents = false;
			process.StartInfo.FileName = DC.adb;
			process.StartInfo.Arguments = " push data\\busybox /data/local/tmp/busybox";
			process.Start();
			process.WaitForExit();
			process.StartInfo.Arguments = " shell  su -c " + quote + " mount -o remount,rw -t auto /system" + quote;
			process.Start();
			process.WaitForExit();
			process.StartInfo.Arguments = " shell  su -c " + quote + "  dd if=/data/local/tmp/busybox of=/system/xbin/busybox" + quote;
			process.Start();
			process.WaitForExit();
			process.StartInfo.Arguments = " shell  su -c " + quote + "  chmod 755 /system/xbin/busybox" + quote;
			process.Start();
			process.WaitForExit();
			process.StartInfo.Arguments = " shell  su -c " + quote + "  ./system/xbin/busybox --install -s /system/bin" + quote;
			process.Start();
			process.WaitForExit();
			process.StartInfo.Arguments = " shell " + quote + "su -c ./system/xbin/busybox echo hello" + quote;
			process.Start();
			process.WaitForExit();
			if (process.StandardOutput.ReadToEnd().Trim().Equals("hello"))
			{
				return "OK";
			}
			return "ERROR";
		}

		private static void Receiver(object sender, DataReceivedEventArgs e)
		{
			Console.WriteLine(e.Data);
			if (e.Data != null && (!e.Data.StartsWith("Writing log") & !e.Data.StartsWith("Log") & !e.Data.Contains("fh_loader.exe")))
			{
				M._F1.update(e.Data);
				Console.WriteLine(e.Data);
			}
		}

		static D2()
		{
			quote = "\"";
		}
	}
}
