using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

// Token: 0x02000050 RID: 80
[DataContract(Name = "ScannedBrowser", Namespace = "BrowserExtension")]
public class Browser
{
	// Token: 0x17000013 RID: 19
	// (get) Token: 0x06000194 RID: 404 RVA: 0x00003D29 File Offset: 0x00001F29
	// (set) Token: 0x06000195 RID: 405 RVA: 0x00003D31 File Offset: 0x00001F31
	[DataMember(Name = "BrowserName")]
	public string BrowserName { get; set; }

	// Token: 0x17000014 RID: 20
	// (get) Token: 0x06000196 RID: 406 RVA: 0x00003D3A File Offset: 0x00001F3A
	// (set) Token: 0x06000197 RID: 407 RVA: 0x00003D42 File Offset: 0x00001F42
	[DataMember(Name = "BrowserProfile")]
	public string BrowserProfile { get; set; }

	// Token: 0x17000015 RID: 21
	// (get) Token: 0x06000198 RID: 408 RVA: 0x00003D4B File Offset: 0x00001F4B
	// (set) Token: 0x06000199 RID: 409 RVA: 0x00003D53 File Offset: 0x00001F53
	[DataMember(Name = "Logins")]
	public IList<Account> Logins { get; set; }

	// Token: 0x17000016 RID: 22
	// (get) Token: 0x0600019A RID: 410 RVA: 0x00003D5C File Offset: 0x00001F5C
	// (set) Token: 0x0600019B RID: 411 RVA: 0x00003D64 File Offset: 0x00001F64
	[DataMember(Name = "Autofills")]
	public IList<Autofill> Autofills { get; set; }

	// Token: 0x17000017 RID: 23
	// (get) Token: 0x0600019C RID: 412 RVA: 0x00003D6D File Offset: 0x00001F6D
	// (set) Token: 0x0600019D RID: 413 RVA: 0x00003D75 File Offset: 0x00001F75
	[DataMember(Name = "CC")]
	public IList<CC> CC { get; set; }

	// Token: 0x17000018 RID: 24
	// (get) Token: 0x0600019E RID: 414 RVA: 0x00003D7E File Offset: 0x00001F7E
	// (set) Token: 0x0600019F RID: 415 RVA: 0x00003D86 File Offset: 0x00001F86
	[DataMember(Name = "Cookies")]
	public IList<ScannedCookie> Cookies { get; set; }

	// Token: 0x060001A0 RID: 416 RVA: 0x0000C020 File Offset: 0x0000A220
	public bool IsEmpty()
	{
		bool result = true;
		IList<Autofill> autofills = this.Autofills;
		if (autofills != null && autofills.Count > 0)
		{
			result = false;
		}
		IList<ScannedCookie> cookies = this.Cookies;
		if (cookies != null && cookies.Count > 0)
		{
			result = false;
		}
		IList<CC> cc = this.CC;
		if (cc != null && cc.Count > 0)
		{
			result = false;
		}
		IList<Account> logins = this.Logins;
		if (logins != null && logins.Count > 0)
		{
			result = false;
		}
		return result;
	}
}
