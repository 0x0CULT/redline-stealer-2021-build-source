using System;

// Token: 0x02000016 RID: 22
public static class SenderFactory
{
	// Token: 0x06000096 RID: 150 RVA: 0x0000373C File Offset: 0x0000193C
	public static IdentitySenderBase Create(int version = 1)
	{
		if (version == 1)
		{
			return new ByPartSender();
		}
		if (version != 2)
		{
			return new ByPartSender();
		}
		return new FullInfoSender();
	}
}
