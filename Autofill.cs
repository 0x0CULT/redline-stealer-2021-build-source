using System;
using System.Runtime.Serialization;

// Token: 0x0200004F RID: 79
[DataContract(Name = "Autofill", Namespace = "BrowserExtension")]
public class Autofill
{
	// Token: 0x17000011 RID: 17
	// (get) Token: 0x0600018F RID: 399 RVA: 0x00003D07 File Offset: 0x00001F07
	// (set) Token: 0x06000190 RID: 400 RVA: 0x00003D0F File Offset: 0x00001F0F
	[DataMember(Name = "Name")]
	public string Name { get; set; }

	// Token: 0x17000012 RID: 18
	// (get) Token: 0x06000191 RID: 401 RVA: 0x00003D18 File Offset: 0x00001F18
	// (set) Token: 0x06000192 RID: 402 RVA: 0x00003D20 File Offset: 0x00001F20
	[DataMember(Name = "Value")]
	public string Value { get; set; }
}
