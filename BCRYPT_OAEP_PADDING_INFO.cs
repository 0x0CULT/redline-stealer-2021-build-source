using System;
using System.Runtime.InteropServices;

// Token: 0x02000056 RID: 86
public struct BCRYPT_OAEP_PADDING_INFO
{
	// Token: 0x060001C4 RID: 452 RVA: 0x00003E85 File Offset: 0x00002085
	public BCRYPT_OAEP_PADDING_INFO(string alg)
	{
		this.pszAlgId = alg;
		this.pbLabel = IntPtr.Zero;
		this.cbLabel = 0;
	}

	// Token: 0x0400007B RID: 123
	[MarshalAs(UnmanagedType.LPWStr)]
	public string pszAlgId;

	// Token: 0x0400007C RID: 124
	public IntPtr pbLabel;

	// Token: 0x0400007D RID: 125
	public int cbLabel;
}
