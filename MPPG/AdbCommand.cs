using System;

namespace MPPG
{
	public class AdbCommand
	{
		private string command;

		private int timeout;

		private string nline = Environment.NewLine;

		internal string Command => command;

		internal int Timeout => timeout;

		internal AdbCommand(string string_0)
		{
			command = string_0;
			timeout = -1;
		}

		public AdbCommand WithTimeout(int int_0)
		{
			timeout = int_0;
			return this;
		}
	}
}
