using System;
using System.Text;

// Token: 0x0200000B RID: 11
public static class StringDecrypt
{
	// Token: 0x06000036 RID: 54 RVA: 0x00005E38 File Offset: 0x00004038
	private static string Xor(string input, string stringKey)
	{
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < input.Length; i++)
		{
			stringBuilder.Append(input[i] ^ stringKey[i % stringKey.Length]);
		}
		return stringBuilder.ToString();
	}

	// Token: 0x06000037 RID: 55 RVA: 0x00003308 File Offset: 0x00001508
	private static string FromBase64(string base64str)
	{
		return StringDecrypt.BytesToStringConverted(Convert.FromBase64String(base64str));
	}

	// Token: 0x06000038 RID: 56 RVA: 0x00003315 File Offset: 0x00001515
	private static string BytesToStringConverted(byte[] bytes)
	{
		return Encoding.UTF8.GetString(bytes);
	}

	// Token: 0x06000039 RID: 57 RVA: 0x00005E80 File Offset: 0x00004080
	public static string Decrypt(string b64, string stringKey)
	{
		try
		{
			if (string.IsNullOrWhiteSpace(b64))
			{
				string text = string.Empty;
			}
			else
			{
				string text = StringDecrypt.FromBase64(StringDecrypt.Xor(StringDecrypt.FromBase64(b64), stringKey));
			}
		}
		catch
		{
		}
		return b64;
	}
}
