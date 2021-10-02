using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

// Token: 0x0200005A RID: 90
[DataContract(Name = "ScanningArgs", Namespace = "BrowserExtension")]
public class ScanningArgs
{
	// Token: 0x17000027 RID: 39
	// (get) Token: 0x060001C6 RID: 454 RVA: 0x00003EB0 File Offset: 0x000020B0
	// (set) Token: 0x060001C7 RID: 455 RVA: 0x00003EB8 File Offset: 0x000020B8
	[DataMember(Name = "ScanBrowsers")]
	public bool ScanBrowsers { get; set; }

	// Token: 0x17000028 RID: 40
	// (get) Token: 0x060001C8 RID: 456 RVA: 0x00003EC1 File Offset: 0x000020C1
	// (set) Token: 0x060001C9 RID: 457 RVA: 0x00003EC9 File Offset: 0x000020C9
	[DataMember(Name = "ScanFiles")]
	public bool ScanFiles { get; set; }

	// Token: 0x17000029 RID: 41
	// (get) Token: 0x060001CA RID: 458 RVA: 0x00003ED2 File Offset: 0x000020D2
	// (set) Token: 0x060001CB RID: 459 RVA: 0x00003EDA File Offset: 0x000020DA
	[DataMember(Name = "ScanFTP")]
	public bool ScanFTP { get; set; }

	// Token: 0x1700002A RID: 42
	// (get) Token: 0x060001CC RID: 460 RVA: 0x00003EE3 File Offset: 0x000020E3
	// (set) Token: 0x060001CD RID: 461 RVA: 0x00003EEB File Offset: 0x000020EB
	[DataMember(Name = "ScanWallets")]
	public bool ScanWallets { get; set; }

	// Token: 0x1700002B RID: 43
	// (get) Token: 0x060001CE RID: 462 RVA: 0x00003EF4 File Offset: 0x000020F4
	// (set) Token: 0x060001CF RID: 463 RVA: 0x00003EFC File Offset: 0x000020FC
	[DataMember(Name = "ScanScreen")]
	public bool ScanScreen { get; set; }

	// Token: 0x1700002C RID: 44
	// (get) Token: 0x060001D0 RID: 464 RVA: 0x00003F05 File Offset: 0x00002105
	// (set) Token: 0x060001D1 RID: 465 RVA: 0x00003F0D File Offset: 0x0000210D
	[DataMember(Name = "ScanTelegram")]
	public bool ScanTelegram { get; set; }

	// Token: 0x1700002D RID: 45
	// (get) Token: 0x060001D2 RID: 466 RVA: 0x00003F16 File Offset: 0x00002116
	// (set) Token: 0x060001D3 RID: 467 RVA: 0x00003F1E File Offset: 0x0000211E
	[DataMember(Name = "ScanVPN")]
	public bool ScanVPN { get; set; }

	// Token: 0x1700002E RID: 46
	// (get) Token: 0x060001D4 RID: 468 RVA: 0x00003F27 File Offset: 0x00002127
	// (set) Token: 0x060001D5 RID: 469 RVA: 0x00003F2F File Offset: 0x0000212F
	[DataMember(Name = "ScanSteam")]
	public bool ScanSteam { get; set; }

	// Token: 0x1700002F RID: 47
	// (get) Token: 0x060001D6 RID: 470 RVA: 0x00003F38 File Offset: 0x00002138
	// (set) Token: 0x060001D7 RID: 471 RVA: 0x00003F40 File Offset: 0x00002140
	[DataMember(Name = "ScanDiscord")]
	public bool ScanDiscord { get; set; }

	// Token: 0x17000030 RID: 48
	// (get) Token: 0x060001D8 RID: 472 RVA: 0x00003F49 File Offset: 0x00002149
	// (set) Token: 0x060001D9 RID: 473 RVA: 0x00003F51 File Offset: 0x00002151
	[DataMember(Name = "ScanFilesPaths")]
	public List<string> ScanFilesPaths { get; set; }

	// Token: 0x17000031 RID: 49
	// (get) Token: 0x060001DA RID: 474 RVA: 0x00003F5A File Offset: 0x0000215A
	// (set) Token: 0x060001DB RID: 475 RVA: 0x00003F62 File Offset: 0x00002162
	[DataMember(Name = "BlockedCountry")]
	public List<string> BlockedCountry { get; set; }

	// Token: 0x17000032 RID: 50
	// (get) Token: 0x060001DC RID: 476 RVA: 0x00003F6B File Offset: 0x0000216B
	// (set) Token: 0x060001DD RID: 477 RVA: 0x00003F73 File Offset: 0x00002173
	[DataMember(Name = "BlockedIP")]
	public List<string> BlockedIP { get; set; }

	// Token: 0x17000033 RID: 51
	// (get) Token: 0x060001DE RID: 478 RVA: 0x00003F7C File Offset: 0x0000217C
	// (set) Token: 0x060001DF RID: 479 RVA: 0x00003F84 File Offset: 0x00002184
	[DataMember(Name = "ScanChromeBrowsersPaths")]
	public List<string> ScanChromeBrowsersPaths { get; set; }

	// Token: 0x17000034 RID: 52
	// (get) Token: 0x060001E0 RID: 480 RVA: 0x00003F8D File Offset: 0x0000218D
	// (set) Token: 0x060001E1 RID: 481 RVA: 0x00003F95 File Offset: 0x00002195
	[DataMember(Name = "ScanGeckoBrowsersPaths")]
	public List<string> ScanGeckoBrowsersPaths { get; set; }
}
