using System;
using System.Runtime.Serialization;

// Token: 0x02000065 RID: 101
[DataContract(Name = "OsCrypt")]
public class OsCrypt
{
	// Token: 0x17000071 RID: 113
	// (get) Token: 0x06000265 RID: 613 RVA: 0x0000439A File Offset: 0x0000259A
	// (set) Token: 0x06000266 RID: 614 RVA: 0x000043A2 File Offset: 0x000025A2
	[DataMember(Name = "encrypted_key")]
	public string encrypted_key { get; set; }
}
