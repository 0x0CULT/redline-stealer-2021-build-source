using System;
using System.Runtime.Serialization;

// Token: 0x0200005D RID: 93
[DataContract(Name = "BrowserVersion", Namespace = "BrowserExtension")]
public class BrowserVersion
{
	// Token: 0x17000048 RID: 72
	// (get) Token: 0x0600020B RID: 523 RVA: 0x000040E1 File Offset: 0x000022E1
	// (set) Token: 0x0600020C RID: 524 RVA: 0x000040E9 File Offset: 0x000022E9
	[DataMember(Name = "NameOfBrowser")]
	public string NameOfBrowser { get; set; }

	// Token: 0x17000049 RID: 73
	// (get) Token: 0x0600020D RID: 525 RVA: 0x000040F2 File Offset: 0x000022F2
	// (set) Token: 0x0600020E RID: 526 RVA: 0x000040FA File Offset: 0x000022FA
	[DataMember(Name = "Version")]
	public string Version { get; set; }

	// Token: 0x1700004A RID: 74
	// (get) Token: 0x0600020F RID: 527 RVA: 0x00004103 File Offset: 0x00002303
	// (set) Token: 0x06000210 RID: 528 RVA: 0x0000410B File Offset: 0x0000230B
	[DataMember(Name = "PathOfFile")]
	public string PathOfFile { get; set; }
}
