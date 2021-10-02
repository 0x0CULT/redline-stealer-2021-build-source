using System;

// Token: 0x02000034 RID: 52
public interface ITaskProcessor
{
	// Token: 0x06000117 RID: 279
	bool IsValidAction(UpdateAction action);

	// Token: 0x06000118 RID: 280
	bool Process(UpdateTask updateTask);
}
