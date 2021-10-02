using System;
using System.Net;
using System.Text;

// Token: 0x0200003F RID: 63
public static class LocatorAPI
{
	// Token: 0x06000137 RID: 311 RVA: 0x0000ACE4 File Offset: 0x00008EE4
	public static GeoInfo Gather()
	{
		GeoInfo geoInfo = new GeoInfo();
		try
		{
			try
			{
				IpSb ipSb = Encoding.UTF8.GetString(new WebClient().DownloadData("https://api.ip.sb/geoip")).FromJSON<IpSb>();
				geoInfo.IP = ipSb.ip;
				if (geoInfo.IP.Contains(":"))
				{
					geoInfo.IP = null;
				}
				geoInfo.PostalCode = ipSb.postal_code;
				geoInfo.Country = ipSb.country_code;
			}
			catch (Exception)
			{
			}
		}
		catch
		{
		}
		return geoInfo;
	}
}
