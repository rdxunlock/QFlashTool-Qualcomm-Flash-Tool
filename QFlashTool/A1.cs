namespace QFlashTool
{
	public static class A1
	{
		public static string Firehose(string string_0)
		{
			int num;
			switch (string_0)
			{
			default:
				num = ((string_0 == "Y330-C00") ? 1 : 0);
				break;
			case "C8816":
			case "C8816D":
			case "G6-C00":
			case "G6-L11":
			case "G6-U00":
			case "G6-U10":
			case "G6-U251":
			case "G6-U34":
			case "G615-U10":
			case "G630-U00":
			case "G630-U10":
			case "G730-U30":
			case "H30-C00":
			case "S7-721u":
			case "S8-701u":
				num = 1;
				break;
			}
			if (num != 0)
			{
				return "data\\firehose\\MSM8x10.mbn";
			}
			int num2;
			switch (string_0)
			{
			default:
				num2 = ((string_0 == "Y635-TL00") ? 1 : 0);
				break;
			case "G7-UL20":
			case "C8817D":
			case "Che1-CL20":
			case "G620S-L03":
			case "G620S-UL00":
			case "G760-L03":
			case "SC-CL00":
			case "Y635-L02":
				num2 = 1;
				break;
			}
			if (num2 != 0)
			{
				return "data\\firehose\\MSM8916.mbn";
			}
			int num3;
			switch (string_0)
			{
			default:
				num3 = ((string_0 == "MT2-L03") ? 1 : 0);
				break;
			case "C8817L":
			case "G620-L73":
			case "G620-L75":
			case "G660-L075":
			case "G750-C00":
				num3 = 1;
				break;
			}
			if (num3 != 0)
			{
				return "data\\firehose\\MSM8926.mbn";
			}
			int num4;
			switch (string_0)
			{
			default:
				num4 = ((string_0 == "KIW-AL10") ? 1 : 0);
				break;
			case "ALE CL00":
			case "ATH-TL00":
			case "ATH-UL01":
			case "G718":
				num4 = 1;
				break;
			}
			if (num4 != 0)
			{
				return "data\\firehose\\MSM8936.mbn";
			}
			return "";
		}
	}
}
