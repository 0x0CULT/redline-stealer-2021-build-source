using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

// Token: 0x02000040 RID: 64
public static class NativeHelper
{
	// Token: 0x06000138 RID: 312
	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern IntPtr LoadLibrary(string fileName);

	// Token: 0x06000139 RID: 313
	[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
	[DllImport("kernel32.dll", SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	private static extern bool FreeLibrary(IntPtr hModule);

	// Token: 0x0600013A RID: 314
	[DllImport("kernel32.dll", CharSet = CharSet.Ansi, ExactSpelling = true, SetLastError = true)]
	private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

	// Token: 0x0600013B RID: 315 RVA: 0x0000AD80 File Offset: 0x00008F80
	public static void Hide()
	{
		try
		{
			IntPtr hModule = NativeHelper.LoadLibrary("kernel32");
			IntPtr hModule2 = NativeHelper.LoadLibrary("user32.dll");
			IntPtr procAddress = NativeHelper.GetProcAddress(hModule, "GetConsoleWindow");
			IntPtr procAddress2 = NativeHelper.GetProcAddress(hModule2, "ShowWindow");
			IntPtr hWnd = NativeHelper.GetDelegate<NativeHelper.GetConsoleWindow>(procAddress)();
			NativeHelper.GetDelegate<NativeHelper.SetConsole>(procAddress2)(hWnd, 0);
		}
		catch
		{
		}
	}

	// Token: 0x0600013C RID: 316 RVA: 0x00003C5C File Offset: 0x00001E5C
	private static T GetDelegate<T>(IntPtr arg1) where T : class
	{
		return Marshal.GetDelegateForFunctionPointer(arg1, typeof(T)) as T;
	}

	// Token: 0x02000041 RID: 65
	// (Invoke) Token: 0x0600013E RID: 318
	private delegate IntPtr GetConsoleWindow();

	// Token: 0x02000042 RID: 66
	// (Invoke) Token: 0x06000142 RID: 322
	private delegate bool SetConsole(IntPtr hWnd, int nCmdShow);
}
