using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Management;
using System.Runtime.InteropServices;
using System.Threading;
using Microsoft.Win32.SafeHandles;
using MPPG;

namespace Telecom
{
	public static class M1
	{
		public static BackgroundWorker bgWriteImage;

		public static AutoResetEvent waitEvent;

		public static string emmcDrive;

		public static string writeFileName;

		public static string finalStatus;

		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern SafeFileHandle CreateFile(string string_0, FileAccess fileAccess_0, FileShare fileShare_0, uint uint_0, FileMode fileMode_0, uint uint_1, uint uint_2);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool DeviceIoControl(IntPtr intptr_0, uint uint_0, IntPtr intptr_1, uint uint_1, ref long long_0, uint uint_2, out uint uint_3, IntPtr intptr_2);

		public static List<string> getDriveList()
		{
			List<string> list = new List<string>();
			bool flag = false;
			WqlObjectQuery query = new WqlObjectQuery("SELECT * FROM Win32_DiskDrive");
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(query);
			int num = 0;
			foreach (ManagementObject item in managementObjectSearcher.Get())
			{
				if (item["MediaType"] != null && (item["MediaType"].ToString().Contains("Removable") || item["MediaType"].ToString().Contains("External")))
				{
					string text = item["DeviceID"].ToString().Replace("\\\\.\\PHYSICALDRIVE", "");
					string diskSize = getDiskSize(text);
					string text2 = item["Model"].ToString();
					string text3 = item["MediaType"].ToString();
					num++;
					if (text2.ToLower().Contains("qualcomm"))
					{
						list.Add(text2 + ";PHYSICALDRIVE " + text + "," + text3 + ":" + diskSize);
					}
					flag = true;
				}
			}
			if (flag)
			{
			}
			list.Sort();
			return list;
		}

		public static string getInformation(string string_0)
		{
			string result = string.Empty;
			bool flag = false;
			WqlObjectQuery query = new WqlObjectQuery("SELECT * FROM Win32_DiskDrive");
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(query);
			int num = 0;
			foreach (ManagementObject item in managementObjectSearcher.Get())
			{
				if (item["MediaType"] != null && (item["MediaType"].ToString().Contains("Removable") || item["MediaType"].ToString().Contains("External")))
				{
					string text = item["DeviceID"].ToString().Replace("\\\\.\\PHYSICALDRIVE", "");
					string text2 = item["Model"].ToString();
					string text3 = item["MediaType"].ToString();
					num++;
					if (text == string_0)
					{
						string diskSize = getDiskSize(text);
						result = text2 + ";PHYSICALDRIVE " + text + "," + text3 + ":" + diskSize;
					}
					flag = true;
				}
			}
			if (flag)
			{
			}
			return result;
		}

		public static List<string> ID()
		{
			List<string> list = new List<string>();
			bool flag = false;
			WqlObjectQuery query = new WqlObjectQuery("SELECT * FROM Win32_DiskDrive");
			ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher(query);
			int num = 0;
			foreach (ManagementObject item in managementObjectSearcher.Get())
			{
				if (item["MediaType"] != null && (item["MediaType"].ToString().Contains("Removable") || item["MediaType"].ToString().Contains("External")))
				{
					string text = item["DeviceID"].ToString().Replace("\\\\.\\PHYSICALDRIVE", "");
					num++;
					list.Add("PHYSICALDRIVE " + text);
					flag = true;
				}
			}
			if (flag)
			{
			}
			list.Sort();
			return list;
		}

		public static long sizeInLong(string string_0)
		{
			long result = 0L;
			SafeFileHandle safeFileHandle = CreateFile("\\\\.\\PHYSICALDRIVE" + string_0, FileAccess.ReadWrite, FileShare.None, 0u, FileMode.Open, 0u, 0u);
			if (safeFileHandle.IsInvalid)
			{
				Console.WriteLine("ERROR");
			}
			else
			{
				long long_ = 0L;
				result = ((!DeviceIoControl(safeFileHandle.DangerousGetHandle(), 475228u, IntPtr.Zero, 0u, ref long_, 8u, out var _, IntPtr.Zero)) ? 0L : long_);
			}
			return result;
		}

		public static string getDiskSize(string string_0)
		{
			string result = string.Empty;
			SafeFileHandle safeFileHandle = CreateFile("\\\\.\\PHYSICALDRIVE" + string_0, FileAccess.ReadWrite, FileShare.None, 0u, FileMode.Open, 0u, 0u);
			if (safeFileHandle.IsInvalid)
			{
				Console.WriteLine("ERROR");
			}
			else
			{
				long long_ = 0L;
				uint uint_;
				long long_2 = ((!DeviceIoControl(safeFileHandle.DangerousGetHandle(), 475228u, IntPtr.Zero, 0u, ref long_, 8u, out uint_, IntPtr.Zero)) ? 0L : long_);
				result = MyClass.Myfiles.SizeConvertor(long_2);
			}
			return result;
		}

		static M1()
		{
			bgWriteImage = new BackgroundWorker();
			waitEvent = new AutoResetEvent(initialState: false);
		}
	}
}
