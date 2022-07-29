using NAudio.Wave;
using System;
namespace Qurre.API.Addons.Audio
{
	public interface IAudioStream
	{
		int Read(byte[] buffer, int offset, int count);
		bool CheckEnd();
		long Length { get; }
		long Position { get; internal set; }
		TimeSpan Duration { get; }
		TimeSpan Progression { get; }
		WaveFormat Format { get; }
		int FrameSize { get; }
		int SampleRate { get; }

		bool Destroyed();

		void Dispose();
	}
}