using System;

// Token: 0x0200000F RID: 15
public class EntryPoint
{
	// Token: 0x0600005B RID: 91 RVA: 0x000033A0 File Offset: 0x000015A0
	public EntryPoint()
	{
		NativeHelper.Hide();
		this.IP = ""; // ip to panel
		this.ID = ""; // id for build
		this.Message = "Error. Try again later."; // messagebox at start
		this.Key = ""; //
		this.Version = 1;
	}

	// Token: 0x0400000C RID: 12
	public string IP;

	// Token: 0x0400000D RID: 13
	public string ID;

	// Token: 0x0400000E RID: 14
	public string Message;

	// Token: 0x0400000F RID: 15
	public string Key;

	// Token: 0x04000010 RID: 16
	public int Version;
}
