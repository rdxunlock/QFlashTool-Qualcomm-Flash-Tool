using System.IO;
using QFlashTool;
using QFlashTool.Properties;

namespace MPPG
{
	public static class Python
	{
		public static bool isInstalled
		{
			get
			{
				File.WriteAllBytes("run.py", Resources.run);
				string text = CMD.General("run.py", "");
				MyFile.Delete("run.py");
				if (text.Contains("2.7.13"))
				{
					return true;
				}
				return false;
			}
		}
	}
}
