using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace MPPG
{
	public static class Adb
	{
		private static object _lock;

		internal static string ADB;

		internal static string ADB_EXE;

		internal const string ADB_VERSION = "1.0.32";

		internal static BackgroundWorker bwWork;

		public static AdbCommand FormAdbCommand(string string_0, params object[] args)
		{
			string text = ((args.Length != 0) ? (string_0 + " ") : string_0);
			for (int i = 0; i < args.Length; i++)
			{
				text = string.Concat(text, args[i], " ");
			}
			return new AdbCommand(text);
		}

		public static string ExecuteAdbCommand(AdbCommand adbCommand_0, bool bool_0 = false)
		{
			string result = "";
			lock (_lock)
			{
				result = Command.RunProcessReturnOutput(ADB_EXE, adbCommand_0.Command, bool_0, adbCommand_0.Timeout);
			}
			return result;
		}

		public static void ExecuteAdbCommandNoReturn(AdbCommand adbCommand_0)
		{
			lock (_lock)
			{
				Command.RunProcessNoReturn(ADB_EXE, adbCommand_0.Command, adbCommand_0.Timeout);
			}
		}

		internal static void reboot()
		{
			cmd("reboot");
		}

		public static void uninstall(string string_0)
		{
			ExecuteAdbCommand(FormAdbCommand("shell \" pm uninstall  " + string_0 + " \""));
		}

		public static string runasRoot(string string_0)
		{
			return ExecuteAdbCommand(FormAdbCommand("shell su -c \"" + string_0 + "\""));
		}

		public static void cleanTemp()
		{
			runasRoot("rm -R /data/local/tmp/*");
			runasRoot("rm -R /data/local/tmp/.*");
		}

		public static void removeAsRoot(string string_0)
		{
			ExecuteAdbCommandNoReturn(FormAdbCommand(" shell su -c \" rm -R " + string_0 + "\""));
		}

		public static string runasShell(string string_0)
		{
			return ExecuteAdbCommand(FormAdbCommand("shell \" " + string_0 + " \""));
		}

		internal static void cmd(string string_0)
		{
			ExecuteAdbCommandNoReturn(FormAdbCommand(string_0));
		}

		internal static void StartServer()
		{
			Thread thread = new Thread((ThreadStart)delegate
			{
				ExecuteAdbCommandNoReturn(FormAdbCommand("start-server"));
			});
			thread.IsBackground = true;
			thread.Start();
			while (thread.IsAlive)
			{
				Application.DoEvents();
			}
		}

		internal static void KillServer()
		{
			ExecuteAdbCommandNoReturn(FormAdbCommand("kill-server"));
		}

		public static string RUN(string string_0)
		{
			return ExecuteAdbCommand(FormAdbCommand(string_0));
		}

		internal static void binaryDelete()
		{
			try
			{
				if (File.Exists("files\\\\APK"))
				{
					MyFile.Delete("files\\\\APK");
				}
				if (File.Exists("files\\\\binary"))
				{
					MyFile.Delete("files\\\\binary");
				}
				if (File.Exists("files\\\\binary"))
				{
					MyFile.Delete("files\\\\bin");
				}
				if (File.Exists("files\\\\Scanner"))
				{
					MyFile.Delete("files\\\\Scanner");
				}
				if (File.Exists("files\\\\Check"))
				{
					MyFile.Delete("files\\\\Check");
				}
				if (File.Exists("files\\\\remover"))
				{
					MyFile.Delete("files\\\\remover");
				}
				if (File.Exists("files\\\\packages"))
				{
					MyFile.Delete("files\\\\packages");
				}
				if (File.Exists("files\\\\hosts"))
				{
					MyFile.Delete("files\\\\hosts");
				}
				if (File.Exists("files\\\\sdcard_File"))
				{
					MyFile.Delete("files\\\\sdcard_File");
				}
				if (File.Exists("files\\\\sdcard_Folder"))
				{
					MyFile.Delete("files\\\\sdcard_Folder");
				}
				if (File.Exists("files\\\\manual"))
				{
					MyFile.Delete("files\\\\manual");
				}
				if (File.Exists("files\\\\system_Remover"))
				{
					MyFile.Delete("files\\\\system_Remover");
				}
				if (File.Exists("files\\\\delete.txt"))
				{
					MyFile.Delete("files\\\\delete.txt");
				}
				if (File.Exists("files\\\\install-recovery.sh"))
				{
					MyFile.Delete("files\\\\install-recovery.sh");
				}
			}
			catch
			{
			}
		}

		static Adb()
		{
			_lock = new object();
			ADB = DC.adb;
			ADB_EXE = DC.adb;
			bwWork = new BackgroundWorker();
		}
	}
}
