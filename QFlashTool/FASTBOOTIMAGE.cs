using System.Collections.Generic;
using System.IO;

namespace QFlashTool
{
	public static class FASTBOOTIMAGE
	{
		public static bool Folder
		{
			get
			{
				if (Directory.Exists("fastbootimage"))
				{
					return true;
				}
				return false;
			}
		}

		public static List<string> CommandList => new List<string>
		{
			" flash partition gpt_both0.bin ", " flash aboot emmc_appsboot.mbn ", " flash hyp hyp.mbn ", " flash rpm rpm.mbn ", " flash ddr ddr.mbn ", " flash sbl1 sbl1.mbn ", " flash ssd ssd.mbn ", " flash sbl2 sbl2.mbn ", " flash sdi sdi.mbn ", " flash tz tz.mbn ",
			" flash boot boot.img ", " flash recovery recovery.img ", " flash erecovery erecovery.img ", " flash cache cache.img ", " flash cust cust.img ", " flash oeminfo oeminfo.mbn ", " flash persist persist.img ", " flash logo logo.img ", " flash fsg fs_image.tar.gz.mbn ", " flash modem NON-HLOS.bin ",
			" flash modemst1 modem_st1.mbn ", " flash modemst2 modem_st2.mbn ", " flash system system.img ", " flash userdata userdata.img ", " flash log log.img ", " reboot "
		};

		public static List<string> FilesList(string string_0)
		{
			List<string> list = new List<string>();
			DirectoryInfo directoryInfo = new DirectoryInfo(string_0);
			FileInfo[] array = null;
			array = directoryInfo.GetFiles();
			FileInfo[] array2 = array;
			foreach (FileInfo fileInfo in array2)
			{
				list.Add(fileInfo.Name);
			}
			return list;
		}
	}
}
