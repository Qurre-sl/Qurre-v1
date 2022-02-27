using Dissonance;
using Dissonance.Audio.Capture;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
namespace Qurre.API.Addons.Audio
{
	public class AudioMicrophone : MonoBehaviour, IMicrophone, IDisposable
	{
		internal static readonly List<AudioMicrophone> Cache = new();
		~AudioMicrophone() => Dispose(false);
		internal virtual IMicrophone Create(Stream stream, float volume, int frameSize, int rate, API.Audio audio)
		{
			Stream = stream ?? throw new ArgumentNullException("[Qurre Addons > Audio] Stream is null");
			Volume = Mathf.Clamp(volume, 0, 100);
			Duration = Stream.GetDuration();
			_audio = audio;
			FrameSize = frameSize;
			SampleRate = rate;
			format = new(SampleRate, 1);
			frame = new float[FrameSize];
			frameBytes = new byte[FrameSize * 4];
			Cache.Add(this);
			return this;
		}
		private API.Audio _audio;
		public Stream Stream { get; protected set; }
		public int FrameSize { get; protected set; }
		public int SampleRate { get; protected set; }
		private WaveFormat format = new(48000, 1);
		private float[] frame = new float[1920];
		private byte[] frameBytes = new byte[1920 * 4];
		private readonly List<IMicrophoneSubscriber> subscribers = new();
		private DissonanceComms dissonanceComms;
		private float elapsedTime;
		private bool CacheCleared;
		public DissonanceComms DissonanceComms
		{
			get
			{
				if (dissonanceComms == null) dissonanceComms = GetComponent<DissonanceComms>();
				return dissonanceComms;
			}
		}
		public virtual bool IsRecording { get; protected set; }
		public TimeSpan Latency { get; protected set; }
		public virtual float Volume { get; set; }
		public virtual RoomChannel RoomChannel { get; private set; }
		public TimeSpan Duration { get; protected set; }
		public TimeSpan Progression => Stream.Position.GetDuration();
		public virtual AudioStatusType Status { get; protected set; }

		public virtual string Name { get; protected set; } = "Audio Player";
		public virtual void ResetMicrophone(string name, bool Instant = true)
		{
			if (CacheCleared) throw new ObjectDisposedException(GetType().FullName);

			if (Instant) StopCapture();

			if (DissonanceComms._capture._network == null) DissonanceComms._capture._network = DissonanceComms._net;

			DissonanceComms._capture._micName = Name = string.IsNullOrEmpty(name) ? Name : name;
			DissonanceComms._capture._microphone = this;

			DissonanceComms.ResetMicrophoneCapture();
		}
		public virtual WaveFormat StartCapture(string name)
		{
			if (CacheCleared) throw new ObjectDisposedException(GetType().FullName);

			if (Stream == null)
			{
				Log.Error($"Stream is null. Microphone: '{name}'.");
				return format;
			}
			else if (!Stream.CanRead)
			{
				Log.Error($"Stream cannot be read. Microphone: '{name}'.");
				return format;
			}

			RoomChannel = DissonanceComms.RoomChannels.Open("Intercom", false, ChannelPriority.High, Volume / 100);

			elapsedTime = 0;

			DissonanceComms._capture._micName = Name = string.IsNullOrEmpty(name) ? Name : name;
			DissonanceComms._capture._microphone = this;

			IsRecording = true;
			Status = AudioStatusType.Playing;
			DissonanceComms.IsMuted = false;

			return format;
		}
		public virtual void StopCapture()
		{
			if (CacheCleared) throw new ObjectDisposedException(GetType().FullName);

			if (!EqualityComparer<RoomChannel>.Default.Equals(RoomChannel, default))
				DissonanceComms.RoomChannels.Close(RoomChannel);

			IsRecording = false;
			Status = AudioStatusType.Stopped;

			if (Stream?.CanSeek ?? false) Stream.Seek(0, SeekOrigin.Begin);

			if (API.Audio.Audios.Count == 0) return;
			if (API.Audio.Audios.Contains(_audio)) API.Audio.Audios.Remove(_audio);
			if (API.Audio.Audios.Count == 0) return;
			var _aud = API.Audio.Audios.First();
			_aud.Microphone.ResetMicrophone(_aud.Microphone.Name, true);
			Dispose();
		}
		public virtual void PauseCapture()
		{
			if (CacheCleared) throw new ObjectDisposedException(GetType().FullName);

			if (!EqualityComparer<RoomChannel>.Default.Equals(RoomChannel, default))
				DissonanceComms.RoomChannels.Close(RoomChannel);

			IsRecording = false;
			Status = AudioStatusType.Paused;
		}
		public void Subscribe(IMicrophoneSubscriber listener) => subscribers.Add(listener);
		public bool Unsubscribe(IMicrophoneSubscriber listener) => subscribers.Remove(listener);
		public virtual bool UpdateSubscribers()
		{
			if (Stream == null)
			{
				StopCapture();
				return true;
			}

			elapsedTime += Time.unscaledDeltaTime;

			while (elapsedTime > 0.04f)
			{
				elapsedTime -= 0.04f;

				var readLength = Stream.Read(frameBytes, 0, frameBytes.Length);

				Array.Clear(frame, 0, frame.Length);

				Buffer.BlockCopy(frameBytes, 0, frame, 0, readLength);

				foreach (var subscriber in subscribers)
					subscriber.ReceiveMicrophoneData(new ArraySegment<float>(frame), format);
			}

			if (Stream.Position == Stream.Length)
				StopCapture();

			return false;
		}
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		protected virtual void Dispose(bool shouldDisposeAllResources)
		{
			if (CacheCleared) throw new ObjectDisposedException(GetType().FullName);

			StopCapture();

			if (shouldDisposeAllResources)
			{
				Stream?.Dispose();
				Stream = null;
			}

			CacheCleared = true;

			Destroy(this);
		}
	}
}