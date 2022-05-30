using NAudio.Wave;
using System;
using System.IO;
using UnityEngine;
namespace Qurre.API.Addons.Audio
{
    public struct AudioTask : IDisposable
    {
        internal AudioTask(Stream stream, byte volume, bool loop, int frameSize, int rate, string playerName = "Qurre Audio")
        {
            Stream = stream ?? throw new ArgumentNullException("[Qurre Addons > Audio] Stream is null");
            Volume = Mathf.Clamp(volume, 0, 100);
            Loop = loop;
            Duration = Stream.GetDuration();
            FrameSize = frameSize;
            SampleRate = rate;
            Format = new(SampleRate, 1);
            PlayerName = playerName;
        }
        public bool Alive { get; internal set; } = true;
        public bool Active { get; internal set; } = false;
        public string PlayerName { get; set; }
        public bool Loop { get; set; }
        public int Volume { get; set; }
        public Stream Stream { get; private set; }
        public TimeSpan Progression => Stream.Position.GetDuration();
        public readonly TimeSpan Duration;
        public readonly WaveFormat Format;
        public readonly int FrameSize;
        public readonly int SampleRate;

        private bool _clearedCache = false;
        private readonly DateTime _createdTime = DateTime.Now;


        public void Dispose()
        {
            if (_clearedCache) throw new ObjectDisposedException(GetType().FullName);

            if (API.Audio._micro is not null && API.Audio._micro._tasks.Contains(this))
                API.Audio._micro._tasks.Remove(this, false);

            Stream?.Dispose();
            Stream = null;

            _clearedCache = true;
            Alive = false;
            Active = false;

            GC.SuppressFinalize(this);
        }

        public override int GetHashCode() => Tuple.Create(Volume, FrameSize, SampleRate, Duration, _createdTime, _clearedCache).GetHashCode();
        public override string ToString()
            => $"Qurre Audio: Player Name: \"{PlayerName}\"; Volume: {Volume}; Duration: {Duration}; FrameSize: {FrameSize}; SampleRate: {SampleRate}";
    }
}