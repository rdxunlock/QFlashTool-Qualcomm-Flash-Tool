using System.Collections.Generic;
using System.IO;

namespace QFlashTool
{
	public static class S1
	{
		public static List<string> list(string string_0)
		{
			List<string> list = new List<string>();
			DirectoryInfo directoryInfo = new DirectoryInfo(string_0);
			FileInfo[] array = null;
			array = directoryInfo.GetFiles();
			FileInfo[] array2 = array;
			foreach (FileInfo fileInfo in array2)
			{
				string text = string_0 + "\\" + fileInfo.Name;
				if (text.Contains(" "))
				{
					text = "\"" + text + "\"";
				}
				list.Add(text);
			}
			return list;
		}
	}
}
