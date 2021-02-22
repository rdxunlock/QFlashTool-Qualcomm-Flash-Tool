using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace QFlashTool
{
	public static class ExtendedMethod
	{
		public static void Rename(this FileInfo fileInfo_0, string string_0)
		{
			fileInfo_0.MoveTo(fileInfo_0.Directory.FullName + "\\" + string_0);
		}

		public static void DeleteAll(this DirectoryInfo directoryInfo_0)
		{
			FileInfo[] files = directoryInfo_0.GetFiles();
			foreach (FileInfo fileInfo in files)
			{
				fileInfo.Delete();
			}
			DirectoryInfo[] directories = directoryInfo_0.GetDirectories();
			foreach (DirectoryInfo directoryInfo_ in directories)
			{
				directoryInfo_.DeleteAll();
			}
		}

		public static void AppendText(this RichTextBox richTextBox_0, string string_0, Color color_0)
		{
			richTextBox_0.SelectionStart = richTextBox_0.TextLength;
			richTextBox_0.SelectionLength = 0;
			richTextBox_0.SelectionColor = color_0;
			richTextBox_0.AppendText(string_0);
			richTextBox_0.SelectionColor = richTextBox_0.ForeColor;
		}

		public static void Error(this string string_0)
		{
			MessageBox.Show(string_0, "error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
		}

		public static void Info(this string string_0)
		{
			MessageBox.Show(string_0, "Information", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}

		public static string size(this string string_0)
		{
			FileInfo fileInfo = new FileInfo(string_0);
			long length = fileInfo.Length;
			if (length < 1024L)
			{
				return length.ToString("F0") + " bytes";
			}
			if ((double)length < Math.Pow(1024.0, 2.0))
			{
				return (length / 1024L).ToString("F0") + "KB";
			}
			if ((double)length < Math.Pow(1024.0, 3.0))
			{
				return ((double)length / Math.Pow(1024.0, 2.0)).ToString("F0") + "MB";
			}
			if ((double)length < Math.Pow(1024.0, 4.0))
			{
				return ((double)length / Math.Pow(1024.0, 3.0)).ToString("F0") + "GB";
			}
			if ((double)length < Math.Pow(1024.0, 5.0))
			{
				return ((double)length / Math.Pow(1024.0, 4.0)).ToString("F0") + "TB";
			}
			if ((double)length < Math.Pow(1024.0, 6.0))
			{
				return ((double)length / Math.Pow(1024.0, 5.0)).ToString("F0") + "PB";
			}
			return ((double)length / Math.Pow(1024.0, 6.0)).ToString("F0") + "EB";
		}

		public static string RemoveLastCharacter(this string string_0)
		{
			return string_0.Substring(0, string_0.Length - 1);
		}

		public static string RemoveLast(this string string_0, int int_0)
		{
			return string_0.Substring(0, string_0.Length - int_0);
		}

		public static string RemoveFirstCharacter(this string string_0)
		{
			return string_0.Substring(1);
		}

		public static string RemoveFirst(this string string_0, int int_0)
		{
			return string_0.Substring(int_0);
		}
	}
}
