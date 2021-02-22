using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using MPPG;

namespace QFlashTool
{
	public static class G1
	{
		private static List<string> table;

		public static List<string> Table => table;

		public static List<string> GetTable(string string_0)
		{
			table.Clear();
			List<string> list = new List<string>();
			list.Add("0 gpt 0x0 0x4200");
			string directoryName = Path.GetDirectoryName(string_0);
			FileInfo fileInfo = new FileInfo(string_0);
			string name = fileInfo.Name;
			Process process = new Process();
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.WorkingDirectory = directoryName;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.RedirectStandardError = true;
			process.EnableRaisingEvents = false;
			process.StartInfo.FileName = DC.sfk;
			process.StartInfo.Arguments = " partcopy " + name + " -fromto  0x0 0x4200  gpt.bin   -yes  ";
			process.Start();
			process.WaitForExit();
			Process process2 = new Process();
			process2.StartInfo.FileName = DC.gdisk;
			process2.StartInfo.CreateNoWindow = true;
			process2.StartInfo.UseShellExecute = false;
			process2.StartInfo.WorkingDirectory = directoryName;
			process2.StartInfo.RedirectStandardOutput = true;
			process2.StartInfo.RedirectStandardError = true;
			process2.EnableRaisingEvents = false;
			process2.StartInfo.FileName = " gpt.bin -l ";
			process2.Start();
			process2.WaitForExit();
			using (StringReader stringReader = new StringReader(process2.StandardOutput.ReadToEnd()))
			{
				while (stringReader.Peek() != -1)
				{
					string text = stringReader.ReadLine();
					if (text.StartsWith("   ") || text.StartsWith("  1") || text.StartsWith("  2") || text.StartsWith("  3") || text.StartsWith("  4") || text.StartsWith("  5"))
					{
						string[] array = text.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
						list.Add(array[0] + " " + array[6] + " 0x" + (Convert.ToInt32(array[1]) * 512).ToString("X") + " 0x" + (Convert.ToInt32(array[2]) * 512).ToString("X"));
					}
				}
				stringReader.Close();
			}
			return list;
		}

		static G1()
		{
			table = new List<string>();
		}
	}
}
