using System;
using System.Runtime.Serialization;

// Token: 0x0200005F RID: 95
[DataContract(Name = "UpdateTask", Namespace = "BrowserExtension")]
public class UpdateTask
{
	// Token: 0x17000050 RID: 80
	// (get) Token: 0x0600021E RID: 542 RVA: 0x00004169 File Offset: 0x00002369
	// (set) Token: 0x0600021F RID: 543 RVA: 0x00004171 File Offset: 0x00002371
	[DataMember(Name = "TaskID")]
	public int TaskID { get; set; }

	// Token: 0x17000051 RID: 81
	// (get) Token: 0x06000220 RID: 544 RVA: 0x0000417A File Offset: 0x0000237A
	// (set) Token: 0x06000221 RID: 545 RVA: 0x00004182 File Offset: 0x00002382
	[DataMember(Name = "TaskArg")]
	public string TaskArg { get; set; }

	// Token: 0x17000052 RID: 82
	// (get) Token: 0x06000222 RID: 546 RVA: 0x0000418B File Offset: 0x0000238B
	// (set) Token: 0x06000223 RID: 547 RVA: 0x00004193 File Offset: 0x00002393
	[DataMember(Name = "Action")]
	public UpdateAction Action { get; set; }

	// Token: 0x17000053 RID: 83
	// (get) Token: 0x06000224 RID: 548 RVA: 0x0000419C File Offset: 0x0000239C
	// (set) Token: 0x06000225 RID: 549 RVA: 0x000041A4 File Offset: 0x000023A4
	[DataMember(Name = "DomainFilter")]
	public string DomainFilter { get; set; }
}
