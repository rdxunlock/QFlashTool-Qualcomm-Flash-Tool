using System.IO;
using System.Media;
using QFlashTool.Properties;

namespace MPPG
{
	public static class MyFile
	{
		public static SoundPlayer error;

		public static void Delete(string string_0)
		{
			try
			{
				File.Delete(string_0);
			}
			catch
			{
				error.Play();
			}
		}

		static MyFile()
		{
			error = new SoundPlayer(Resources.erro);
		}
	}
}
