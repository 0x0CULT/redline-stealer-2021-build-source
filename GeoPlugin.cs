using System;
using System.Runtime.Serialization;

// Token: 0x02000062 RID: 98
[DataContract(Name = "GeoPlugin")]
public class GeoPlugin
{
	// Token: 0x17000067 RID: 103
	// (get) Token: 0x0600024E RID: 590 RVA: 0x000042F0 File Offset: 0x000024F0
	// (set) Token: 0x0600024F RID: 591 RVA: 0x000042F8 File Offset: 0x000024F8
	[DataMember(Name = "geoplugin_request")]
	public string geoplugin_request { get; set; }

	// Token: 0x17000068 RID: 104
	// (get) Token: 0x06000250 RID: 592 RVA: 0x00004301 File Offset: 0x00002501
	// (set) Token: 0x06000251 RID: 593 RVA: 0x00004309 File Offset: 0x00002509
	[DataMember(Name = "geoplugin_city")]
	public string geoplugin_city { get; set; }

	// Token: 0x17000069 RID: 105
	// (get) Token: 0x06000252 RID: 594 RVA: 0x00004312 File Offset: 0x00002512
	// (set) Token: 0x06000253 RID: 595 RVA: 0x0000431A File Offset: 0x0000251A
	[DataMember(Name = "geoplugin_region")]
	public string geoplugin_region { get; set; }

	// Token: 0x1700006A RID: 106
	// (get) Token: 0x06000254 RID: 596 RVA: 0x00004323 File Offset: 0x00002523
	// (set) Token: 0x06000255 RID: 597 RVA: 0x0000432B File Offset: 0x0000252B
	[DataMember(Name = "geoplugin_countryCode")]
	public string geoplugin_countryCode { get; set; }

	// Token: 0x1700006B RID: 107
	// (get) Token: 0x06000256 RID: 598 RVA: 0x00004334 File Offset: 0x00002534
	// (set) Token: 0x06000257 RID: 599 RVA: 0x0000433C File Offset: 0x0000253C
	[DataMember(Name = "geoplugin_latitude")]
	public string geoplugin_latitude { get; set; }

	// Token: 0x1700006C RID: 108
	// (get) Token: 0x06000258 RID: 600 RVA: 0x00004345 File Offset: 0x00002545
	// (set) Token: 0x06000259 RID: 601 RVA: 0x0000434D File Offset: 0x0000254D
	[DataMember(Name = "geoplugin_longitude")]
	public string geoplugin_longitude { get; set; }
}
