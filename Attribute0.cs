using System;
using System.Runtime.InteropServices;

[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Interface | AttributeTargets.Parameter | AttributeTargets.Delegate, AllowMultiple = true, Inherited = false)]
[Attribute0(Exclude = true, ApplyToMembers = true, StripAfterObfuscation = true)]
[ComVisible(true)]
internal sealed class Attribute0 : Attribute
{
	private bool applyToMembers = true;

	private bool exclude = true;

	private bool strip = true;

	private string feature = "";

	public bool ApplyToMembers
	{
		get
		{
			return applyToMembers;
		}
		set
		{
			applyToMembers = value;
		}
	}

	public bool Exclude
	{
		get
		{
			return exclude;
		}
		set
		{
			exclude = value;
		}
	}

	public string Feature
	{
		get
		{
			return feature;
		}
		set
		{
			feature = value;
		}
	}

	public bool StripAfterObfuscation
	{
		get
		{
			return strip;
		}
		set
		{
			strip = value;
		}
	}
}
