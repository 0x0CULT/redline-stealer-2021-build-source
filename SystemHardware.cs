using System;
using System.Runtime.Serialization;

// Token: 0x0200005C RID: 92
[DataContract(Name = "SystemHardware", Namespace = "BrowserExtension")]
public class SystemHardware
{
	// Token: 0x17000045 RID: 69
	// (get) Token: 0x06000204 RID: 516 RVA: 0x000040AE File Offset: 0x000022AE
	// (set) Token: 0x06000205 RID: 517 RVA: 0x000040B6 File Offset: 0x000022B6
	[DataMember(Name = "Name")]
	public string Name { get; set; }

	// Token: 0x17000046 RID: 70
	// (get) Token: 0x06000206 RID: 518 RVA: 0x000040BF File Offset: 0x000022BF
	// (set) Token: 0x06000207 RID: 519 RVA: 0x000040C7 File Offset: 0x000022C7
	[DataMember(Name = "Counter")]
	public string Counter { get; set; }

	// Token: 0x17000047 RID: 71
	// (get) Token: 0x06000208 RID: 520 RVA: 0x000040D0 File Offset: 0x000022D0
	// (set) Token: 0x06000209 RID: 521 RVA: 0x000040D8 File Offset: 0x000022D8
	[DataMember(Name = "HardType")]
	public HardwareType HardType { get; set; }
}
