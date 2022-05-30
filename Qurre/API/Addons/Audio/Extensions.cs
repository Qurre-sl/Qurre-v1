using System;
using System.IO;
namespace Qurre.API.Addons.Audio
{
	public static class Extensions
	{
		public static TimeSpan GetDuration(this long length, int frameBytes = 960 * 4, float interval = 0.02f)
		{
			if (frameBytes == 0) throw new DivideByZeroException("frameBytes cannot be 0");
			return TimeSpan.FromSeconds(length / (float)frameBytes * interval);
		}
		public static TimeSpan GetDuration(this Stream stream, int frameBytes = 960 * 4, float readInterval = 0.02f) => (stream?.Length ?? 0).GetDuration(frameBytes, readInterval);
	}
}