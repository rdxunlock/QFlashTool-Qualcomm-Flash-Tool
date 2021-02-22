using System.Collections.Generic;
using System.IO;

namespace QFlashTool
{
	public static class M2
	{
		public static List<string> list => new List<string> { "MPRG8916.mbn", "MPRG8926.mbn", "MPRG8936.mbn", "MPRG8x10.mbn" };

		public static string Name(string string_0)
		{
			string mFile = "";
			DirectoryInfo directoryInfo = new DirectoryInfo(string_0);
			FileInfo[] array = null;
			array = directoryInfo.GetFiles();
			FileInfo[] array2 = array;
			foreach (FileInfo f in array2)
			{
				list.ForEach(delegate(string string_0)
				{
					if (string_0 == f.Name)
					{
						mFile = f.Name;
					}
				});
			}
			return mFile;
		}
	}
}
