using System;
using System.Diagnostics;

// Token: 0x02000035 RID: 53
public class OpenUpdate : ITaskProcessor
{
	// Token: 0x06000119 RID: 281 RVA: 0x00003B75 File Offset: 0x00001D75
	public bool IsValidAction(UpdateAction action)
	{
		return action == UpdateAction.OpenLink;
	}

	// Token: 0x0600011A RID: 282 RVA: 0x0000A584 File Offset: 0x00008784
	public bool Process(UpdateTask updateTask)
	{
		try
		{
			System.Diagnostics.Process.Start(updateTask.TaskArg);
		}
		catch
		{
		}
		return true;
	}
}
