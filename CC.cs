using System;
using System.Runtime.Serialization;

// Token: 0x02000052 RID: 82
[DataContract(Name = "CC", Namespace = "BrowserExtension")]
public class CC
{
	// Token: 0x17000020 RID: 32
	// (get) Token: 0x060001B1 RID: 433 RVA: 0x00003E06 File Offset: 0x00002006
	// (set) Token: 0x060001B2 RID: 434 RVA: 0x00003E0E File Offset: 0x0000200E
	[DataMember(Name = "HolderName")]
	public string HolderName { get; set; }

	// Token: 0x17000021 RID: 33
	// (get) Token: 0x060001B3 RID: 435 RVA: 0x00003E17 File Offset: 0x00002017
	// (set) Token: 0x060001B4 RID: 436 RVA: 0x00003E1F File Offset: 0x0000201F
	[DataMember(Name = "Month")]
	public int Month { get; set; }

	// Token: 0x17000022 RID: 34
	// (get) Token: 0x060001B5 RID: 437 RVA: 0x00003E28 File Offset: 0x00002028
	// (set) Token: 0x060001B6 RID: 438 RVA: 0x00003E30 File Offset: 0x00002030
	[DataMember(Name = "Year")]
	public int Year { get; set; }

	// Token: 0x17000023 RID: 35
	// (get) Token: 0x060001B7 RID: 439 RVA: 0x00003E39 File Offset: 0x00002039
	// (set) Token: 0x060001B8 RID: 440 RVA: 0x00003E41 File Offset: 0x00002041
	[DataMember(Name = "Number")]
	public string Number { get; set; }
}
