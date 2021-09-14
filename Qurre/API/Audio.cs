using System;
using System.IO;
namespace Qurre.API
{
    [Obsolete("Сurrently unavailable")]
    public static class Audio
    {
        public static global::Dissonance.Integrations.MirrorIgnorance.MirrorIgnoranceClient client;
        public static global::Dissonance.Networking.ClientInfo<global::Dissonance.Integrations.MirrorIgnorance.MirrorConn> СlientInfo;

        public static void Play(Stream stream, float volume);
        public static void PlayFromFile(string path, float volume);
        public static void PlayFromUrl(string url, float volume);

        public class MicrophoneModule : global::UnityEngine.MonoBehaviour, global::Dissonance.Audio.Capture.IMicrophoneCapture
        {
            public Stream _file;

            public MicrophoneModule();

            public bool IsRecording { get; }
            public TimeSpan Latency { get; }

            public global::NAudio.Wave.WaveFormat StartCapture(string name);
            public void StopCapture();
            public void Subscribe(global::Dissonance.Audio.Capture.IMicrophoneSubscriber listener);
            public bool Unsubscribe(global::Dissonance.Audio.Capture.IMicrophoneSubscriber listener);
            public bool UpdateSubscribers();
        }
    }
}