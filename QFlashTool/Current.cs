using System.IO;

namespace QFlashTool
{
	public static class Current
	{
		public static string data
		{
			get
			{
				string text = "data";
				if (!Directory.Exists(text))
				{
					Directory.CreateDirectory(text);
				}
				return text;
			}
		}

		public static string temp
		{
			get
			{
				string path = "data";
				if (!Directory.Exists(path))
				{
					Directory.CreateDirectory(path);
				}
				string text = "data\\temp";
				if (!Directory.Exists(text))
				{
					Directory.CreateDirectory(text);
				}
				return text;
			}
		}
	}
}
