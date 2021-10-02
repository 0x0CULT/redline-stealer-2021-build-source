using System;

// Token: 0x02000047 RID: 71
public class FileScannerArg
{
	// Token: 0x1700000A RID: 10
	// (get) Token: 0x0600015F RID: 351 RVA: 0x00003C94 File Offset: 0x00001E94
	// (set) Token: 0x06000160 RID: 352 RVA: 0x00003C9C File Offset: 0x00001E9C
	public string Tag { get; set; }

	// Token: 0x1700000B RID: 11
	// (get) Token: 0x06000161 RID: 353 RVA: 0x00003CA5 File Offset: 0x00001EA5
	// (set) Token: 0x06000162 RID: 354 RVA: 0x00003CAD File Offset: 0x00001EAD
	public string Directory { get; set; }

	// Token: 0x1700000C RID: 12
	// (get) Token: 0x06000163 RID: 355 RVA: 0x00003CB6 File Offset: 0x00001EB6
	// (set) Token: 0x06000164 RID: 356 RVA: 0x00003CBE File Offset: 0x00001EBE
	public string Pattern { get; set; }

	// Token: 0x1700000D RID: 13
	// (get) Token: 0x06000165 RID: 357 RVA: 0x00003CC7 File Offset: 0x00001EC7
	// (set) Token: 0x06000166 RID: 358 RVA: 0x00003CCF File Offset: 0x00001ECF
	public bool Recoursive { get; set; }
}
