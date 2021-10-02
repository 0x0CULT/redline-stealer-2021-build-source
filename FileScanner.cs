using System;
using System.Collections.Generic;
using System.IO;

// Token: 0x02000048 RID: 72
public abstract class FileScanner
{
	// Token: 0x1700000E RID: 14
	// (get) Token: 0x06000168 RID: 360 RVA: 0x00003CD8 File Offset: 0x00001ED8
	// (set) Token: 0x06000169 RID: 361 RVA: 0x00003CE0 File Offset: 0x00001EE0
	public string Name { get; set; }

	// Token: 0x0600016A RID: 362
	public abstract string GetFolder(FileScannerArg scannerArg, FileInfo filePath);

	// Token: 0x0600016B RID: 363
	public abstract IEnumerable<FileScannerArg> GetScanArgs();
}
