using System;
using System.Collections.Generic;
using System.IO;
using QFlashTool;

namespace MPPG
{
	public static class DC
	{
		internal static string dload => "dependencies\\dload.exe";

		internal static string adb => "dependencies\\adb.exe";

		internal static string fastboot => "dependencies\\fastboot.exe";

		internal static string emmcdl => "dependencies\\emmcdl.exe";

		internal static string QSaharaServer => "dependencies\\QSaharaServer.exe";

		internal static string fh_loader => "dependencies\\fh_loader.exe";

		internal static string busybox => "dependencies\\busybox.exe";

		internal static string pv => "dependencies\\pv.exe";

		internal static string usb => "dependencies\\usb.exe";

		internal static string _7z => "dependencies\\7z.exe";

		internal static string mmc => "dependencies\\mmc.exe";

		internal static string gdisk
		{
			get
			{
				if (Environment.Is64BitOperatingSystem)
				{
					return "dependencies\\gdisk64.exe";
				}
				return "dependencies\\gdisk32.exe";
			}
		}

		internal static string sfk => "dependencies\\sfk.exe";

		internal static bool CheckOk()
		{
			List<string> list = new List<string>
			{
				"7z.dll", "7z.exe", "adb.exe", "AdbWinApi.dll", "AdbWinUsbApi.dll", "busybox.exe", "cyggcc_s-1.dll", "cygwin1.dll", "cygz.dll", "dload.exe",
				"emmcdl.exe", "fastboot.exe", "fh_loader.exe", "gdisk32.exe", "gdisk64.exe", "libgcc_s_dw2-1.dll", "mmc.exe", "pv.exe", "QSaharaServer.exe", "sfk.exe",
				"sgs4ext4fs.exe", "simg2img.exe", "simg2simg.exe", "SparseConverter.exe", "unpackbootimg.exe", "usb.exe"
			};
			bool result = false;
			using (List<string>.Enumerator enumerator = list.GetEnumerator())
			{
				if (enumerator.MoveNext())
				{
					string current = enumerator.Current;
					if (!File.Exists("dependencies\\" + current))
					{
						result = false;
						M.error.Play();
						return false;
					}
					result = true;
					return true;
				}
			}
			return result;
		}
	}
}
