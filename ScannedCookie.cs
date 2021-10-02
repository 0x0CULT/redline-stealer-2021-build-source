using System;
using System.Runtime.Serialization;

// Token: 0x02000051 RID: 81
[DataContract(Name = "ScannedCookie", Namespace = "BrowserExtension")]
public class ScannedCookie
{
	// Token: 0x17000019 RID: 25
	// (get) Token: 0x060001A2 RID: 418 RVA: 0x00003D8F File Offset: 0x00001F8F
	// (set) Token: 0x060001A3 RID: 419 RVA: 0x00003D97 File Offset: 0x00001F97
	[DataMember(Name = "Host")]
	public string Host { get; set; }

	// Token: 0x1700001A RID: 26
	// (get) Token: 0x060001A4 RID: 420 RVA: 0x00003DA0 File Offset: 0x00001FA0
	// (set) Token: 0x060001A5 RID: 421 RVA: 0x00003DA8 File Offset: 0x00001FA8
	[DataMember(Name = "Http")]
	public bool Http { get; set; }

	// Token: 0x1700001B RID: 27
	// (get) Token: 0x060001A6 RID: 422 RVA: 0x00003DB1 File Offset: 0x00001FB1
	// (set) Token: 0x060001A7 RID: 423 RVA: 0x00003DB9 File Offset: 0x00001FB9
	[DataMember(Name = "Path")]
	public string Path { get; set; }

	// Token: 0x1700001C RID: 28
	// (get) Token: 0x060001A8 RID: 424 RVA: 0x00003DC2 File Offset: 0x00001FC2
	// (set) Token: 0x060001A9 RID: 425 RVA: 0x00003DCA File Offset: 0x00001FCA
	[DataMember(Name = "Secure")]
	public bool Secure { get; set; }

	// Token: 0x1700001D RID: 29
	// (get) Token: 0x060001AA RID: 426 RVA: 0x00003DD3 File Offset: 0x00001FD3
	// (set) Token: 0x060001AB RID: 427 RVA: 0x00003DDB File Offset: 0x00001FDB
	[DataMember(Name = "Expires")]
	public long Expires { get; set; }

	// Token: 0x1700001E RID: 30
	// (get) Token: 0x060001AC RID: 428 RVA: 0x00003DE4 File Offset: 0x00001FE4
	// (set) Token: 0x060001AD RID: 429 RVA: 0x00003DEC File Offset: 0x00001FEC
	[DataMember(Name = "Name")]
	public string Name { get; set; }

	// Token: 0x1700001F RID: 31
	// (get) Token: 0x060001AE RID: 430 RVA: 0x00003DF5 File Offset: 0x00001FF5
	// (set) Token: 0x060001AF RID: 431 RVA: 0x00003DFD File Offset: 0x00001FFD
	[DataMember(Name = "Value")]
	public string Value { get; set; }
}
