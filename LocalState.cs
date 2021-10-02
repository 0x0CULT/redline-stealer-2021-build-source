using System;
using System.Runtime.Serialization;

// Token: 0x02000064 RID: 100
[DataContract(Name = "LocalState")]
public class LocalState
{
	// Token: 0x17000070 RID: 112
	// (get) Token: 0x06000262 RID: 610 RVA: 0x00004389 File Offset: 0x00002589
	// (set) Token: 0x06000263 RID: 611 RVA: 0x00004391 File Offset: 0x00002591
	[DataMember(Name = "os_crypt")]
	public OsCrypt os_crypt { get; set; }
}
