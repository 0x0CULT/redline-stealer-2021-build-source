using System;
using System.Runtime.Serialization;

// Token: 0x02000053 RID: 83
[DataContract(Name = "Account", Namespace = "BrowserExtension")]
public class Account
{
	// Token: 0x17000024 RID: 36
	// (get) Token: 0x060001BA RID: 442 RVA: 0x00003E4A File Offset: 0x0000204A
	// (set) Token: 0x060001BB RID: 443 RVA: 0x00003E52 File Offset: 0x00002052
	[DataMember(Name = "URL")]
	public string URL { get; set; }

	// Token: 0x17000025 RID: 37
	// (get) Token: 0x060001BC RID: 444 RVA: 0x00003E5B File Offset: 0x0000205B
	// (set) Token: 0x060001BD RID: 445 RVA: 0x00003E63 File Offset: 0x00002063
	[DataMember(Name = "Username")]
	public string Username { get; set; }

	// Token: 0x17000026 RID: 38
	// (get) Token: 0x060001BE RID: 446 RVA: 0x00003E6C File Offset: 0x0000206C
	// (set) Token: 0x060001BF RID: 447 RVA: 0x00003E74 File Offset: 0x00002074
	[DataMember(Name = "Password")]
	public string Password { get; set; }
}
