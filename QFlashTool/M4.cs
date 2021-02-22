using System.Collections.Generic;
using System.IO;

namespace QFlashTool
{
	public static class M4
	{
		public static List<string> list => new List<string> { "8626_msimage.mbn", "8916_msimage.mbn", "8930_msimage.mbn", "8936_msimage.mbn", "8x10_msimage.mbn", "huawei_msimage.mbn" };

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
					if (string_0.Trim().Equals(f.Name))
					{
						mFile = f.Name;
					}
				});
			}
			return mFile;
		}
	}
}
