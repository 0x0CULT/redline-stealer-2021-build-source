using System;
using System.Runtime.InteropServices;

// Token: 0x02000054 RID: 84
public struct BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO : IDisposable
{
	// Token: 0x060001C1 RID: 449 RVA: 0x0000C094 File Offset: 0x0000A294
	public BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO(byte[] iv, byte[] aad, byte[] tag)
	{
		this = default(BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO);
		this.dwInfoVersion = BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO.BCRYPT_INIT_AUTH_MODE_INFO_VERSION;
		this.cbSize = Marshal.SizeOf(typeof(BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO));
		if (iv != null)
		{
			this.cbNonce = iv.Length;
			this.pbNonce = Marshal.AllocHGlobal(this.cbNonce);
			Marshal.Copy(iv, 0, this.pbNonce, this.cbNonce);
		}
		if (aad != null)
		{
			this.cbAuthData = aad.Length;
			this.pbAuthData = Marshal.AllocHGlobal(this.cbAuthData);
			Marshal.Copy(aad, 0, this.pbAuthData, this.cbAuthData);
		}
		if (tag != null)
		{
			this.cbTag = tag.Length;
			this.pbTag = Marshal.AllocHGlobal(this.cbTag);
			Marshal.Copy(tag, 0, this.pbTag, this.cbTag);
			this.cbMacContext = tag.Length;
			this.pbMacContext = Marshal.AllocHGlobal(this.cbMacContext);
		}
	}

	// Token: 0x060001C2 RID: 450 RVA: 0x0000C174 File Offset: 0x0000A374
	public void Dispose()
	{
		if (this.pbNonce != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(this.pbNonce);
		}
		if (this.pbTag != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(this.pbTag);
		}
		if (this.pbAuthData != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(this.pbAuthData);
		}
		if (this.pbMacContext != IntPtr.Zero)
		{
			Marshal.FreeHGlobal(this.pbMacContext);
		}
	}

	// Token: 0x0400006A RID: 106
	public static readonly int BCRYPT_INIT_AUTH_MODE_INFO_VERSION = 1;

	// Token: 0x0400006B RID: 107
	public int cbSize;

	// Token: 0x0400006C RID: 108
	public int dwInfoVersion;

	// Token: 0x0400006D RID: 109
	public IntPtr pbNonce;

	// Token: 0x0400006E RID: 110
	public int cbNonce;

	// Token: 0x0400006F RID: 111
	public IntPtr pbAuthData;

	// Token: 0x04000070 RID: 112
	public int cbAuthData;

	// Token: 0x04000071 RID: 113
	public IntPtr pbTag;

	// Token: 0x04000072 RID: 114
	public int cbTag;

	// Token: 0x04000073 RID: 115
	public IntPtr pbMacContext;

	// Token: 0x04000074 RID: 116
	public int cbMacContext;

	// Token: 0x04000075 RID: 117
	public int cbAAD;

	// Token: 0x04000076 RID: 118
	public long cbData;

	// Token: 0x04000077 RID: 119
	public int dwFlags;
}
