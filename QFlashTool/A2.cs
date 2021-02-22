using System;
using System.IO;

namespace QFlashTool
{
	public static class A2
	{
		public static string setFile;

		private static string getFile => setFile;

		public static string Brand
		{
			get
			{
				if (!File.Exists(getFile))
				{
					return "";
				}
				try
				{
					foreach (string item in File.ReadLines(getFile))
					{
						if (item.StartsWith("ro.product.brand"))
						{
							return item.Substring(item.IndexOf("=") + 1).ToUpper();
						}
					}
				}
				catch (Exception)
				{
					return "";
				}
				return "";
			}
		}

		public static string Model
		{
			get
			{
				if (!File.Exists(getFile))
				{
					return "";
				}
				try
				{
					foreach (string item in File.ReadLines(getFile))
					{
						if (item.StartsWith("ro.product.brand"))
						{
							return item.Substring(item.IndexOf("=") + 1).ToUpper();
						}
					}
				}
				catch (Exception)
				{
					return "";
				}
				return "";
			}
		}

		public static string Version
		{
			get
			{
				if (!File.Exists(getFile))
				{
					return "";
				}
				try
				{
					foreach (string item in File.ReadLines(getFile))
					{
						if (item.StartsWith("ro.product.brand"))
						{
							return item.Substring(item.IndexOf("=") + 1).ToUpper();
						}
					}
				}
				catch (Exception)
				{
					return "";
				}
				return "";
			}
		}

		public static string BuildNumber
		{
			get
			{
				if (!File.Exists(getFile))
				{
					return "";
				}
				try
				{
					foreach (string item in File.ReadLines(getFile))
					{
						if (item.StartsWith("ro.product.brand"))
						{
							return item.Substring(item.IndexOf("=") + 1).ToUpper();
						}
					}
				}
				catch (Exception)
				{
					return "";
				}
				return "";
			}
		}

		public static string ChipID
		{
			get
			{
				if (!File.Exists(getFile))
				{
					return "";
				}
				try
				{
					foreach (string item in File.ReadLines(getFile))
					{
						if (item.StartsWith("ro.product.brand"))
						{
							return item.Substring(item.IndexOf("=") + 1).ToUpper();
						}
					}
				}
				catch (Exception)
				{
					return "";
				}
				return "";
			}
		}
	}
}
