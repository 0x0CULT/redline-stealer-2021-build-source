using System;
using System.Runtime.Serialization;

// Token: 0x02000063 RID: 99
[DataContract(Name = "IpSb")]
public class IpSb
{
	// Token: 0x1700006D RID: 109
	// (get) Token: 0x0600025B RID: 603 RVA: 0x00004356 File Offset: 0x00002556
	// (set) Token: 0x0600025C RID: 604 RVA: 0x0000435E File Offset: 0x0000255E
	[DataMember(Name = "postal_code")]
	public string postal_code { get; set; }

	// Token: 0x1700006E RID: 110
	// (get) Token: 0x0600025D RID: 605 RVA: 0x00004367 File Offset: 0x00002567
	// (set) Token: 0x0600025E RID: 606 RVA: 0x0000436F File Offset: 0x0000256F
	[DataMember(Name = "ip")]
	public string ip { get; set; }

	// Token: 0x1700006F RID: 111
	// (get) Token: 0x0600025F RID: 607 RVA: 0x00004378 File Offset: 0x00002578
	// (set) Token: 0x06000260 RID: 608 RVA: 0x00004380 File Offset: 0x00002580
	[DataMember(Name = "country_code")]
	public string country_code { get; set; }
}
