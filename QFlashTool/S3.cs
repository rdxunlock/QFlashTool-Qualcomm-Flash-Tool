namespace QFlashTool
{
	public static class S3
	{
		public static string LBA(string string_0)
		{
			return string_0 switch
			{
				"3GB" => "6291456", 
				"4GB" => "8388608", 
				"1.5GB" => "3145728", 
				"2GB" => "4194304", 
				"7GB" => "14680064", 
				"5GB" => "10485760", 
				"6GB" => "12582912", 
				"1GB" => "2097152", 
				"512MB" => "1048576", 
				"8GB" => "16777216", 
				_ => "", 
			};
		}
	}
}
