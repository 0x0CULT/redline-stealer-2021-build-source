using System;
using System.Web.Script.Serialization;

// Token: 0x0200003B RID: 59
public static class Json
{
	// Token: 0x17000009 RID: 9
	// (get) Token: 0x0600012F RID: 303 RVA: 0x00003C23 File Offset: 0x00001E23
	public static JavaScriptSerializer JSON
	{
		get
		{
			JavaScriptSerializer result;
			if ((result = Json.json) == null)
			{
				JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
				javaScriptSerializer.MaxJsonLength = int.MaxValue;
				javaScriptSerializer.RecursionLimit = int.MaxValue;
				result = javaScriptSerializer;
				Json.json = javaScriptSerializer;
			}
			return result;
		}
	}

	// Token: 0x06000130 RID: 304 RVA: 0x0000A97C File Offset: 0x00008B7C
	public static T FromJSON<T>(this string @this)
	{
		T result;
		try
		{
			result = Json.JSON.Deserialize<T>(@this.Trim());
		}
		catch (Exception)
		{
			result = default(T);
		}
		return result;
	}

	// Token: 0x06000131 RID: 305 RVA: 0x00003C4F File Offset: 0x00001E4F
	public static string ToJSON(this object @this)
	{
		return Json.JSON.Serialize(@this);
	}

	// Token: 0x04000035 RID: 53
	private static JavaScriptSerializer json;
}
