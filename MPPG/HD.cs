using System.Management;
using System.Text.RegularExpressions;

namespace MPPG
{
	public static class HD
	{
		public static string SerialNo
		{
			get
			{
				try
				{
					using ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("ASSOCIATORS OF {Win32_LogicalDisk.DeviceID='C:'} WHERE ResultClass=Win32_DiskPartition");
					foreach (ManagementBaseObject item in managementObjectSearcher.Get())
					{
						using ManagementObjectSearcher managementObjectSearcher2 = new ManagementObjectSearcher(string.Concat("ASSOCIATORS OF {Win32_DiskPartition.DeviceID='", item["DeviceID"], "'} WHERE ResultClass=Win32_DiskDrive"));
						using ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator2 = managementObjectSearcher2.Get().GetEnumerator();
						if (!managementObjectEnumerator2.MoveNext())
						{
							continue;
						}
						ManagementBaseObject current2 = managementObjectEnumerator2.Current;
						string input = (string)current2["SerialNumber"];
						return Regex.Replace(input, "\\s", "");
					}
				}
				catch
				{
					return "<unknown>";
				}
				return "<unknown>";
			}
		}
	}
}
