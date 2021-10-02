using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

// Token: 0x0200000A RID: 10
public static class CryptoHelper
{
	// Token: 0x06000032 RID: 50 RVA: 0x000032E0 File Offset: 0x000014E0
	public static string DecryptBlob(string EncryptedData, DataProtectionScope dataProtectionScope, byte[] entropy = null)
	{
		return Encoding.UTF8.GetString(CryptoHelper.DecryptBlob(Encoding.GetEncoding("windows-1251").GetBytes(EncryptedData), dataProtectionScope, entropy));
	}

	// Token: 0x06000033 RID: 51 RVA: 0x00005CF8 File Offset: 0x00003EF8
	public static byte[] DecryptBlob(byte[] EncryptedData, DataProtectionScope dataProtectionScope, byte[] entropy = null)
	{
		byte[] result;
		try
		{
			if (EncryptedData == null || EncryptedData.Length == 0)
			{
				result = null;
			}
			else
			{
				result = ProtectedData.Unprotect(EncryptedData, entropy, dataProtectionScope);
			}
		}
		catch (Exception)
		{
			result = null;
		}
		return result;
	}

	// Token: 0x06000034 RID: 52 RVA: 0x00005D34 File Offset: 0x00003F34
	public static string GetMd5Hash(string source)
	{
		HashAlgorithm hashAlgorithm = new MD5CryptoServiceProvider();
		byte[] bytes = Encoding.ASCII.GetBytes(source);
		return CryptoHelper.GetHexString(hashAlgorithm.ComputeHash(bytes)).Replace("-", string.Empty);
	}

	// Token: 0x06000035 RID: 53 RVA: 0x00005D6C File Offset: 0x00003F6C
	private static string GetHexString(IList<byte> bt)
	{
		string text = string.Empty;
		for (int i = 0; i < bt.Count; i++)
		{
			byte b = bt[i];
			int num = (int)(b & 15);
			int num2 = b >> 4 & 15;
			if (num2 > 9)
			{
				text += ((char)(num2 - 10 + 65)).ToString(CultureInfo.InvariantCulture);
			}
			else
			{
				text += num2.ToString(CultureInfo.InvariantCulture);
			}
			if (num > 9)
			{
				text += ((char)(num - 10 + 65)).ToString(CultureInfo.InvariantCulture);
			}
			else
			{
				text += num.ToString(CultureInfo.InvariantCulture);
			}
			if (i + 1 != bt.Count && (i + 1) % 2 == 0)
			{
				text += "-";
			}
		}
		return text;
	}
}
