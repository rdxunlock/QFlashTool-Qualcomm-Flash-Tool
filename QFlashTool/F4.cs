using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using MPPG;

namespace QFlashTool
{
	public class F4
	{
		private static string result;

		private static string Command;

		public static bool isFinished;

		private static string XML;

		private static string wkDir;

		public static string Result => result;

		private void Sendxml(string string_0, string string_1)
		{
			if (File.Exists(string_1))
			{
				wkDir = Path.GetDirectoryName(string_1);
				FileInfo fileInfo = new FileInfo(string_1);
				XML = fileInfo.Name;
				isFinished = false;
				if (File.Exists(string_1))
				{
					string text = "  --port=\\\\.\\" + Usb.COM + "     --sendxml=" + XML + "  --convertprogram2read --loglevel=0  --noprompt --showpercentagecomplete  --zlpawarehost=1 --memoryname=eMMC ";
					Process process = new Process();
					ProcessStartInfo processStartInfo = new ProcessStartInfo();
					processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
					processStartInfo.FileName = DC.fh_loader;
					processStartInfo.WorkingDirectory = wkDir;
					processStartInfo.Arguments = text;
					Console.WriteLine(text);
					processStartInfo.RedirectStandardOutput = true;
					processStartInfo.UseShellExecute = false;
					processStartInfo.CreateNoWindow = true;
					process.StartInfo = processStartInfo;
					process.OutputDataReceived += Receiver;
					process.Start();
					process.BeginOutputReadLine();
					process.WaitForExit();
				}
			}
		}

		public void convertprogram2read(string string_0)
		{
			if (File.Exists(string_0))
			{
				wkDir = Path.GetDirectoryName(string_0);
				FileInfo fileInfo = new FileInfo(string_0);
				XML = fileInfo.Name;
				Command = "  --port=\\\\.\\" + Usb.COM + "     --sendxml=" + XML + "  --convertprogram2read --loglevel=0  --noprompt --showpercentagecomplete  --zlpawarehost=1 --memoryname=eMMC ";
				new Thread(SampleFunction).Start();
			}
		}

		public void SendXml(string string_0)
		{
			if (File.Exists(string_0))
			{
				wkDir = Path.GetDirectoryName(string_0);
				FileInfo fileInfo = new FileInfo(string_0);
				XML = fileInfo.Name;
				Command = "  --port=\\\\.\\" + Usb.COM + "     --sendxml=" + XML + "   --loglevel=0  --noprompt --showpercentagecomplete  --zlpawarehost=1 --memoryname=eMMC ";
				new Thread(SampleFunction).Start();
			}
		}

		public void SendImage(string string_0)
		{
			if (File.Exists(string_0))
			{
				wkDir = Path.GetDirectoryName(string_0);
				FileInfo fileInfo = new FileInfo(string_0);
				string name = fileInfo.Name;
				Command = "  --port=\\\\.\\" + Usb.COM + "     --sendimage=" + name + "   --loglevel=0  --noprompt --showpercentagecomplete  --zlpawarehost=1 --memoryname=eMMC ";
				new Thread(SampleFunction).Start();
			}
		}

		private void SampleFunction()
		{
			isFinished = false;
			Process process = new Process();
			ProcessStartInfo processStartInfo = new ProcessStartInfo();
			processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			processStartInfo.FileName = DC.fh_loader;
			processStartInfo.WorkingDirectory = wkDir;
			processStartInfo.Arguments = Command;
			Console.WriteLine(Command);
			processStartInfo.RedirectStandardOutput = true;
			processStartInfo.UseShellExecute = false;
			processStartInfo.CreateNoWindow = true;
			process.StartInfo = processStartInfo;
			process.OutputDataReceived += Receiver;
			process.Start();
			process.BeginOutputReadLine();
			process.WaitForExit();
			isFinished = true;
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

		public static void Sendimage(string string_0, string string_1)
		{
			if (File.Exists(string_1))
			{
				FileInfo fileInfo = new FileInfo(string_1);
				string directoryName = Path.GetDirectoryName(string_1);
				string name = fileInfo.Name;
				string text = "/C " + DC.fh_loader + "  --port=\\\\.\\" + string_0 + "     --sendimage=\"" + name + "\" --loglevel=0  --noprompt --showpercentagecomplete  --zlpawarehost=1 --memoryname=eMMC --reset";
				Process process = new Process();
				ProcessStartInfo processStartInfo = new ProcessStartInfo();
				processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				processStartInfo.FileName = "cmd.exe";
				processStartInfo.WorkingDirectory = directoryName;
				processStartInfo.Arguments = text;
				Console.WriteLine(text);
				processStartInfo.RedirectStandardOutput = true;
				processStartInfo.UseShellExecute = false;
				processStartInfo.CreateNoWindow = true;
				process.StartInfo = processStartInfo;
				process.OutputDataReceived += Receiver;
				process.Start();
				process.BeginOutputReadLine();
				process.WaitForExit();
			}
		}

		static F4()
		{
			result = string.Empty;
			isFinished = false;
			XML = "";
			wkDir = string.Empty;
		}
	}
}
