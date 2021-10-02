using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Microsoft.CSharp.RuntimeBinder;

// Token: 0x0200003C RID: 60
public static class Resolution
{
	// Token: 0x06000132 RID: 306
	[DllImport("gdi32.dll", CharSet = CharSet.Auto, ExactSpelling = true, SetLastError = true)]
	private static extern int GetDeviceCaps(IntPtr hDC, int nIndex);

	// Token: 0x06000133 RID: 307 RVA: 0x0000A9BC File Offset: 0x00008BBC
	public static double GetWindowsScreenScalingFactor(bool percentage = true)
	{
		Graphics graphics = Graphics.FromHwnd(IntPtr.Zero);
		IntPtr hdc = graphics.GetHdc();
		int deviceCaps = Resolution.GetDeviceCaps(hdc, 10);
		double num = Math.Round((double)Resolution.GetDeviceCaps(hdc, 117) / (double)deviceCaps, 2);
		if (percentage)
		{
			num *= 100.0;
		}
		graphics.ReleaseHdc(hdc);
		graphics.Dispose();
		return num;
	}

	// Token: 0x06000134 RID: 308 RVA: 0x0000AA14 File Offset: 0x00008C14
	[return: Dynamic]
	public static dynamic MonitorSize()
	{
		object result;
		try
		{
			double windowsScreenScalingFactor = Resolution.GetWindowsScreenScalingFactor(false);
			int num = (int)((double)Screen.PrimaryScreen.Bounds.Width * windowsScreenScalingFactor);
			double num2 = (double)Screen.PrimaryScreen.Bounds.Height * windowsScreenScalingFactor;
			result = new Size(num, (int)num2);
		}
		catch
		{
			result = Screen.PrimaryScreen.Bounds.Size;
		}
		return result;
	}

	// Token: 0x06000135 RID: 309 RVA: 0x0000AA90 File Offset: 0x00008C90
	public static byte[] Print()
	{
		byte[] result;
		try
		{
			object obj = Resolution.MonitorSize();
			if (Resolution.<>o__4.<>p__2 == null)
			{
				Resolution.<>o__4.<>p__2 = CallSite<Func<CallSite, Type, object, object, Bitmap>>.Create(Binder.InvokeConstructor(CSharpBinderFlags.None, typeof(Resolution), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Func<CallSite, Type, object, object, Bitmap> target = Resolution.<>o__4.<>p__2.Target;
			CallSite <>p__ = Resolution.<>o__4.<>p__2;
			Type typeFromHandle = typeof(Bitmap);
			if (Resolution.<>o__4.<>p__0 == null)
			{
				Resolution.<>o__4.<>p__0 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Width", typeof(Resolution), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			object arg = Resolution.<>o__4.<>p__0.Target(Resolution.<>o__4.<>p__0, obj);
			if (Resolution.<>o__4.<>p__1 == null)
			{
				Resolution.<>o__4.<>p__1 = CallSite<Func<CallSite, object, object>>.Create(Binder.GetMember(CSharpBinderFlags.None, "Height", typeof(Resolution), new CSharpArgumentInfo[]
				{
					CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
				}));
			}
			Bitmap bitmap = target(<>p__, typeFromHandle, arg, Resolution.<>o__4.<>p__1.Target(Resolution.<>o__4.<>p__1, obj));
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				graphics.InterpolationMode = InterpolationMode.Bicubic;
				graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
				graphics.SmoothingMode = SmoothingMode.HighSpeed;
				if (Resolution.<>o__4.<>p__3 == null)
				{
					Resolution.<>o__4.<>p__3 = CallSite<Action<CallSite, Graphics, Point, Point, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "CopyFromScreen", null, typeof(Resolution), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
					}));
				}
				Resolution.<>o__4.<>p__3.Target(Resolution.<>o__4.<>p__3, graphics, new Point(0, 0), new Point(0, 0), obj);
			}
			result = Resolution.ConvertToBytes(bitmap);
		}
		catch (Exception)
		{
			result = null;
		}
		return result;
	}

	// Token: 0x06000136 RID: 310 RVA: 0x0000AC88 File Offset: 0x00008E88
	private static byte[] ConvertToBytes(Image img)
	{
		byte[] result;
		try
		{
			if (img == null)
			{
				result = null;
			}
			else
			{
				using (MemoryStream memoryStream = new MemoryStream())
				{
					img.Save(memoryStream, ImageFormat.Png);
					result = memoryStream.ToArray();
				}
			}
		}
		catch (Exception)
		{
			result = null;
		}
		return result;
	}

	// Token: 0x0200003D RID: 61
	public enum DeviceCap
	{
		// Token: 0x04000037 RID: 55
		VERTRES = 10,
		// Token: 0x04000038 RID: 56
		DESKTOPVERTRES = 117
	}
}
