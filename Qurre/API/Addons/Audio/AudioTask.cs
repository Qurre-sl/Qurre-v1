using System;
namespace Qurre.API.Addons.Audio
{
    public struct AudioTask : IDisposable
    {
        internal AudioTask(IAudioStream stream, byte volume, bool loop, string playerName = "Qurre Audio")
        {
            Stream = stream;
            _volume = volume.Clamp(0, 100);
            Loop = loop;
            Duration = Stream.Duration;
            PlayerName = playerName;
        }
        public bool Alive { get; internal set; } = true;
        public bool Active { get; internal set; } = false;
        public string PlayerName { get; set; }
        public bool Loop { get; set; }
        public byte Volume
        {
            get => _volume;
            set
            {
                _volume = value;
                API.Audio._micro.UpdateListeners(this);
            }
        }
        public IAudioStream Stream { get; private set; }
        public readonly TimeSpan Duration;

        private bool _clearedCache = false;
        private readonly DateTime _createdTime = DateTime.Now;
        private readonly string uid = Guid.NewGuid().ToString("N");
        private byte _volume;


        public void Dispose()
        {
            if (_clearedCache) throw new ObjectDisposedException(GetType().FullName);

            if (API.Audio._micro is not null && API.Audio._micro._tasks.Contains(this))
                API.Audio._micro._tasks.Remove(this, false);

            Stream.Dispose();

            _clearedCache = true;
            Alive = false;
            Active = false;

            GC.SuppressFinalize(this);
        }

        public override bool Equals(object obj)
        {
            if (obj is not AudioTask other)
                return false;

            return this == other;
        }
        public static bool operator ==(AudioTask a, AudioTask b) => a.uid == b.uid;
        public static bool operator !=(AudioTask a, AudioTask b) => !(a == b);
        public override int GetHashCode() => Tuple.Create(uid, Volume, Stream, Duration, _createdTime, _clearedCache).GetHashCode();
        public override string ToString()
            => $"Qurre Audio: Player Name: \"{PlayerName}\"; Volume: {Volume}; Duration: {Duration}; {Stream}";
    }
}