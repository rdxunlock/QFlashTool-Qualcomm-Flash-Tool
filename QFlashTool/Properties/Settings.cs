using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace QFlashTool.Properties
{
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
	[CompilerGenerated]
	internal sealed class Settings : ApplicationSettingsBase
	{
		private static Settings defaultInstance;

		public static Settings Default => defaultInstance;

		[UserScopedSetting]
		[DefaultSettingValue("")]
		[DebuggerNonUserCode]
		public string MyeMMC
		{
			get
			{
				return (string)this["MyeMMC"];
			}
			set
			{
				this["MyeMMC"] = value;
			}
		}

		static Settings()
		{
			defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
		}
	}
}
