using System;
using System.IO;
using NAudio.Wave;
using NLayer;
namespace Qurre.API.Addons.Audio
{
    public struct AudioStream : IDisposable
    {
        internal readonly bool _def;
        private MpegFile _mpeg;
        private Stream _stream;
        private readonly string uid = Guid.NewGuid().ToString("N");

        internal int Read(byte[] buffer, int offset, int count) => _def ? _stream.Read(buffer, offset, count) : _mpeg.ReadSamples(buffer, offset, count);
        internal bool CheckEnd()
        {
            if (_def) return _stream.Position == _stream.Length;
            return _mpeg.Position * _mpeg.Channels >= _mpeg.Length - 9216;
        }

        public AudioStream(MpegFile stream)
        {
            if (stream is null) throw new ArgumentNullException("Qurre Audio: Mpeg is null");
            _mpeg = stream;
            _mpeg.StereoMode = StereoMode.DownmixToMono;
            _stream = null;
            _def = false;
            Destroyed = false;
            FrameSize = 1920;
            SampleRate = _mpeg.SampleRate;
            Format = new(_mpeg.SampleRate, 1);
        }
        public AudioStream(Stream stream, int frameSize = 1920, int sampleRate = 48000)
        {
            if (stream is null) throw new ArgumentNullException("Qurre Audio: Stream is null");
            if (!stream.CanRead)
            {
                Log.Error("Audio: Stream cannot be read stream");
                throw new ArgumentException("Qurre Audio: Stream cannot be read stream");
            }
            _mpeg = null;
            _stream = stream;
            _def = true;
            Destroyed = false;
            FrameSize = frameSize;
            SampleRate = sampleRate;
            Format = new(SampleRate, 1);
        }

        public readonly WaveFormat Format;
        public readonly int FrameSize;
        public readonly int SampleRate;

        public long Length => _def ? _stream.Length : _mpeg.Length;
        public long Position
        {
            get => _def ? _stream.Position : _mpeg.Position * 4;
            internal set
            {
                if (_def) _stream.Position = value;
                else _mpeg.Position = value;
            }
        }
        public TimeSpan Duration => _def ? TimeSpan.FromSeconds(_stream.Length / FrameSize * 4 * 0.04f) : _mpeg.Duration;
        public TimeSpan Progression => _def ? TimeSpan.FromSeconds(_stream.Position / FrameSize * 4 * 0.04f) :
            TimeSpan.FromSeconds(_mpeg.Position / 4.0 / _mpeg.SampleRate);

        public bool Destroyed { get; private set; }
        public void Dispose()
        {
            if (Destroyed) return;

            if (_stream is not null)
            {
                _stream.Dispose();
                _stream = null;
            }
            if (_mpeg is not null)
            {
                _mpeg.Dispose();
                _mpeg = null;
            }

            Destroyed = true;

            GC.SuppressFinalize(this);
        }

        public override bool Equals(object obj)
        {
            if (obj is not AudioStream other)
                return false;

            return this == other;
        }
        public static bool operator ==(AudioStream a, AudioStream b) => a.uid == b.uid;
        public static bool operator !=(AudioStream a, AudioStream b) => !(a == b);
        public override int GetHashCode() => Tuple.Create(uid, _def).GetHashCode();
        public override string ToString()
            => $"Audio Stream: Length: \"{Length}\"; FrameSize: {FrameSize}; SampleRate: {SampleRate}; Format: {Format}";
    }
}