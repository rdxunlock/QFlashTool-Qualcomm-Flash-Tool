using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace MPPG
{
	public static class M3
	{
		public static bool SetFinish;

		private static bool ic;

		private static string port;

		public static string result { get; private set; }

		public static bool GetFinish => SetFinish;

		public static bool Ic => ic;

		internal static string Port => port;

		internal static string COM
		{
			get
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
				if (text.Contains("Qualcomm HS-USB QDLoader 9008"))
				{
					using StringReader stringReader = new StringReader(text);
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
				string text3 = port;
				text3 = text3.Substring(text3.IndexOf("(") + 1);
				text3 = text3.Substring(0, text3.Length - 1);
				if (text3.Contains(")"))
				{
					text3 = text3.Replace(")", "");
				}
				return text3;
			}
		}

		internal static string O
		{
			get
			{
				string empty = string.Empty;
				string text = string.Empty;
				string fileName = "cmd.exe";
				string arguments = "/C  " + DC.emmcdl + " -p " + COM + " -info";
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
				string s = process.StandardOutput.ReadToEnd();
				using (StringReader stringReader = new StringReader(s))
				{
					while (stringReader.Peek() != -1)
					{
						string text2 = stringReader.ReadLine();
						if (text2.Contains("OEM_PK_HASH"))
						{
							string[] array = text2.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
							switch (array[1])
							{
							case "0xcc3153a80293939b90d02d3bf8b23e0292e452fef662c74998421adad42a380f":
								text = "Huawei_Or_General_Qualcomm";
								break;
							case "0x99c8c13e374c34d8f9afb065ea4c733e6b1b21cbc5a78705f041eb24acdd5fe5":
								text = "Lenovo";
								break;
							case "0xDF989E3C2BE41617A8FF5019AD996BF706BBD5D3EEE0DC4B9A2F048F9224FA54":
								text = "OEM_Caterpillar";
								break;
							case "0xB155B8BF19297F47CAF69C342717B45FF0E0DBF25B070ED877BCC0AD2650F94B":
								text = "OEM_LeEco";
								break;
							case "0x0B010BCB83A7B520C240A358A00DB87675681FB9C7C703496692AC3154466053":
								text = "WINGTECH_Asus";
								break;
							case "0x8ECF3EAA03F772E28479FA2F0BBAE2141CCAD6F106B384D1C46263EDB5B02838":
								text = "General_Asus";
								break;
							case "0x18000EB7C3A236D5949FE2A82C02257D3EBEB8FEB9A0A57A181402ED19537206":
								text = "Qualcomm2016_Asus";
								break;
							case "0xAD38BEB6615BA7FBA38361DAE6BF2DF14AF5E7AC6AF8E78DB46C3ADD435E4174":
								text = "WINGTECH_Asus";
								break;
							case "0x7C24B3BEC0B604392D8F610D812998CF744D0B3E0572C7F2CC184DC3F7DCD46C":
								text = "OEM_LeEco";
								break;
							case "0xEA490EBB7AB54005092C70C2CEBC612979ED9C0D11F6DFFDC33ED0D7BE5C9A55":
								text = "OEM_LeEco";
								break;
							case "0x57158eaf1814d78fd2b3105ece4db18a817a08ac664a5782a925f3ff8403d39a":
								text = "Xiaomi_Specialized";
								break;
							case "0x625801C51EEE90D7F0E0EDB1606BB07E05871BD24F69F3FADFD17FDCE0D4B4F0":
								text = "Alcatel_TCL";
								break;
							case "0xf069a87f6d4364efcdfecfcd34bd5201f4126990d38424fcf7f21724f9ec0bf2":
								text = "Asus";
								break;
							}
						}
					}
					stringReader.Close();
				}
				return text;
			}
		}

		internal static string id
		{
			get
			{
				string empty = string.Empty;
				string text = string.Empty;
				string fileName = "cmd.exe";
				string arguments = "/C  " + DC.emmcdl + " -p " + COM + " -info";
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
				string s = process.StandardOutput.ReadToEnd();
				using (StringReader stringReader = new StringReader(s))
				{
					while (stringReader.Peek() != -1)
					{
						string text2 = stringReader.ReadLine();
						if (text2.Contains("MSM_HW_ID"))
						{
							string[] array = text2.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
							switch (array[1])
							{
							case "0x009690e1":
								text = "MSM8992";
								break;
							case "0x009600e1":
								text = "MSM8909";
								break;
							case "0x000460e1":
								text = "MSM8953";
								break;
							case "0x0091b0e1":
								text = "MSM8929";
								break;
							case "0x006220e1":
								text = "MSM7227A";
								break;
							case "0x009470e1":
								text = "MSM8996";
								break;
							case "0x009900e1":
								text = "MSM8976";
								break;
							case "0x009b00e1":
								text = "MSM8976";
								break;
							case "0X008A30E1":
								text = "MSM8930";
								break;
							case "0x0004f0e1":
								text = "MSM8937";
								break;
							case "0x0090b0e1":
								text = "MSM8936";
								break;
							case "0x009180e1":
								text = "MSM8928";
								break;
							case "0x008140e1":
								text = "MSM8x10";
								break;
							case "0x008050e2":
								text = "MSM8926";
								break;
							case "0x0005f0e1":
								text = "MSM8996";
								break;
							case "0x007B80E1":
								text = "MSM8974";
								break;
							case "0x009400e1":
								text = "MSM8994";
								break;
							case "0x008150e1":
								text = "MSM8x10";
								break;
							case "0x008050e1":
								text = "MSM8926";
								break;
							case "0x000560e1":
								text = "MSM8917";
								break;
							case "0x007050e1":
								text = "MSM8916";
								break;
							case "0x008110e1":
								text = "MSM8210";
								break;
							}
						}
					}
					stringReader.Close();
				}
				return text;
			}
		}

		internal static void D()
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
				ic = true;
			}
			else
			{
				ic = false;
			}
		}

		internal static List<string> getGPT(string string_0, string string_1)
		{
			List<string> list = new List<string>();
			Process process = new Process();
			process.StartInfo.FileName = DC.emmcdl;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.RedirectStandardError = true;
			process.EnableRaisingEvents = false;
			process.StartInfo.Arguments = " -p " + string_0 + " -f " + string_1 + " -gpt ";
			process.Start();
			string s = process.StandardOutput.ReadToEnd();
			using (StringReader stringReader = new StringReader(s))
			{
				while (stringReader.Peek() != -1)
				{
					string text = stringReader.ReadLine();
					if (text.Contains("Partition Name:") & text.Contains("Start LBA"))
					{
						list.Add(text);
					}
				}
			}
			return list;
		}

		internal static List<string> getPartitions(string string_0, string string_1)
		{
			List<string> list = new List<string>();
			Process process = new Process();
			process.StartInfo.FileName = DC.emmcdl;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.RedirectStandardError = true;
			process.EnableRaisingEvents = false;
			process.StartInfo.Arguments = " -p " + string_0 + " -f " + string_1 + " -gpt ";
			process.Start();
			string s = process.StandardOutput.ReadToEnd();
			using (StringReader stringReader = new StringReader(s))
			{
				while (stringReader.Peek() != -1)
				{
					string text = stringReader.ReadLine();
					if (text.Contains("Partition Name:") & text.Contains("Start LBA"))
					{
						string[] array = text.Split((string[])null, StringSplitOptions.RemoveEmptyEntries);
						list.Add(array[3]);
					}
				}
			}
			return list;
		}

		public static string flashFirehose(string string_0, string string_1)
		{
			string text = " -p " + string_0 + " -f " + string_1;
			Process process = new Process();
			ProcessStartInfo processStartInfo = new ProcessStartInfo();
			processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			processStartInfo.FileName = DC.emmcdl;
			processStartInfo.WorkingDirectory = Directory.GetCurrentDirectory();
			processStartInfo.Arguments = text;
			Console.WriteLine(text);
			processStartInfo.RedirectStandardOutput = true;
			processStartInfo.UseShellExecute = false;
			processStartInfo.CreateNoWindow = true;
			process.StartInfo = processStartInfo;
			process.Start();
			StreamReader standardOutput = process.StandardOutput;
			string text2 = standardOutput.ReadToEnd();
			process.WaitForExit();
			standardOutput.Close();
			if (text2.Contains("Status: 0 The operation completed successfully"))
			{
				return "OK";
			}
			return "Fail";
		}

		public static string flashPartition(string string_0, string string_1, string string_2, string string_3)
		{
			Process process = new Process();
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.RedirectStandardError = true;
			process.StartInfo.RedirectStandardInput = true;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.FileName = "cmd.exe";
			process.StartInfo.Arguments = "/c " + DC.emmcdl + " -p " + string_0 + " -f " + string_1 + " -b " + string_2 + " " + string_3 + " &&  exit";
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

		public static string BackupPartition(string string_0, string string_1, string string_2, string string_3)
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

		public static string ErasePartition(string string_0, string string_1, string string_2)
		{
			Process process = new Process();
			process.StartInfo.UseShellExecute = false;
			process.StartInfo.CreateNoWindow = true;
			process.StartInfo.RedirectStandardError = true;
			process.StartInfo.RedirectStandardInput = true;
			process.StartInfo.RedirectStandardOutput = true;
			process.StartInfo.FileName = "cmd.exe";
			process.StartInfo.Arguments = "/c " + DC.emmcdl + " -p " + string_0 + " -f " + string_1 + " -e " + string_2 + " &&  exit";
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

		static M3()
		{
			SetFinish = false;
			port = "()";
		}
	}
}
