using System;
using System.Runtime.InteropServices;

// Token: 0x02000057 RID: 87
public struct BCRYPT_PSS_PADDING_INFO
{
	// Token: 0x060001C5 RID: 453 RVA: 0x00003EA0 File Offset: 0x000020A0
	public BCRYPT_PSS_PADDING_INFO(string pszAlgId, int cbSalt)
	{
		this.pszAlgId = pszAlgId;
		this.cbSalt = cbSalt;
	}

	// Token: 0x0400007E RID: 126
	[MarshalAs(UnmanagedType.LPWStr)]
	public string pszAlgId;

	// Token: 0x0400007F RID: 127
	public int cbSalt;
}
