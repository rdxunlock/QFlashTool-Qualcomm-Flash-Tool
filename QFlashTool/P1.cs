using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using MPPG;
using QFlashTool.Properties;

namespace QFlashTool
{
	public static class P1
	{
		internal static bool CanRun
		{
			get
			{
				File.WriteAllBytes("run.py", Resources.run);
				Process process = new Process();
				process.StartInfo.FileName = "cmd.exe";
				process.StartInfo.CreateNoWindow = true;
				process.StartInfo.UseShellExecute = false;
				process.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
				process.StartInfo.RedirectStandardOutput = true;
				process.StartInfo.RedirectStandardError = true;
				process.EnableRaisingEvents = false;
				process.StartInfo.Arguments = "/C run.py";
				process.Start();
				process.WaitForExit();
				if (process.StandardOutput.ReadToEnd().Contains("2.7.13"))
				{
					try
					{
						MyFile.Delete("run.py");
					}
					catch
					{
					}
					return true;
				}
				return false;
			}
		}

		internal static async void partitionXML(string string_0)
		{
			if (File.Exists(string_0))
			{
				FileInfo info = new FileInfo(string_0);
				_ = info.Name;
				string Dir = Path.GetDirectoryName(string_0);
				if (Directory.Exists(Dir))
				{
					File.WriteAllBytes(Dir + "\\parse.py", Resources.parse);
					File.WriteAllBytes(Dir + "\\ptool.py", Resources.ptool);
					Process gpt_parser = new Process();
					gpt_parser.StartInfo.FileName = "cmd.exe";
					gpt_parser.StartInfo.CreateNoWindow = true;
					gpt_parser.StartInfo.UseShellExecute = false;
					gpt_parser.StartInfo.WorkingDirectory = Dir;
					gpt_parser.StartInfo.RedirectStandardOutput = true;
					gpt_parser.StartInfo.RedirectStandardError = true;
					gpt_parser.EnableRaisingEvents = false;
					gpt_parser.StartInfo.Arguments = "/c parse.py gpt > partition.xml  && exit";
					gpt_parser.Start();
					gpt_parser.WaitForExit(1000);
					string cmd = "ptool.py -x partition.xml > TEST.TXT";
					File.WriteAllText(Dir + "\\run.bat", cmd);
					Process ptool = new Process();
					ptool.StartInfo.FileName = Dir + "\\run.bat";
					ptool.StartInfo.CreateNoWindow = true;
					ptool.StartInfo.UseShellExecute = false;
					ptool.StartInfo.WorkingDirectory = Dir;
					ptool.StartInfo.RedirectStandardOutput = true;
					ptool.StartInfo.RedirectStandardError = true;
					ptool.EnableRaisingEvents = false;
					ptool.Start();
					ptool.WaitForExit(1000);
					await Task.Delay(1000);
					MyFile.Delete(Dir + "\\run.bat");
					MyFile.Delete(Dir + "\\parse.py");
					MyFile.Delete(Dir + "\\ptool.py");
					MyFile.Delete(Dir + "\\TEST.TXT");
					MyFile.Delete(Dir + "\\wipe_rawprogram_PHY0.xml");
					MyFile.Delete(Dir + "\\wipe_rawprogram_PHY1.xml");
					MyFile.Delete(Dir + "\\wipe_rawprogram_PHY2.xml");
					MyFile.Delete(Dir + "\\wipe_rawprogram_PHY4.xml");
					MyFile.Delete(Dir + "\\wipe_rawprogram_PHY5.xml");
					MyFile.Delete(Dir + "\\wipe_rawprogram_PHY6.xml");
					MyFile.Delete(Dir + "\\wipe_rawprogram_PHY7.xml");
					MyFile.Delete(Dir + "\\gpt");
				}
			}
		}
	}
}
