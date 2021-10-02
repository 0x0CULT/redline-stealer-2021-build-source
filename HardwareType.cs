using System;
using System.Runtime.Serialization;

// Token: 0x02000058 RID: 88
[DataContract(Name = "HardwareType")]
public enum HardwareType
{
	// Token: 0x04000081 RID: 129
	[EnumMember]
	Processor,
	// Token: 0x04000082 RID: 130
	[EnumMember]
	Graphic
}
