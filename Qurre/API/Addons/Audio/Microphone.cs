using Dissonance.Audio.Capture;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using UnityEngine;
namespace Qurre.API.Addons.Audio
{
    internal class Microphone : MonoBehaviour, IMicrophone
    {
        public IReadOnlyCollection<AudioTask> Tasks => _tasks.ReadOnly;
        public virtual bool IsRecording { get; protected set; }
        public virtual TimeSpan Latency { get; protected set; }
        public virtual StatusType Status { get; protected set; }

        internal readonly TasksList _tasks = new();
        private readonly List<IMicrophoneSubscriber> _subs = new();

        private float _elapsedTime;
        private float[] _frame = new float[1920];
        private byte[] _frameBytes = new byte[1920 * 4];

        internal void UpdateFrames(AudioTask task)
        {
            _frame = new float[task.FrameSize];
            _frameBytes = new byte[task.FrameSize * 4];
        }

        public virtual void Subscribe(IMicrophoneSubscriber listener) => _subs.Add(listener);
        public virtual bool Unsubscribe(IMicrophoneSubscriber listener) => _subs.Remove(listener);
        public virtual bool UpdateSubscribers()
        {
            if (_tasks.Count == 0)
            {
                StopCapture();
                return true;
            }
            if (Status != StatusType.Playing)
                return true;

            AudioTask task = _tasks[0];

            _elapsedTime += Time.unscaledDeltaTime;

            while (_elapsedTime > 0.04f)
            {
                _elapsedTime -= 0.04f;

                var readLength = task.Stream.Read(_frameBytes, 0, _frameBytes.Length);

                Array.Clear(_frame, 0, _frame.Length);

                Buffer.BlockCopy(_frameBytes, 0, _frame, 0, readLength);

                foreach (var subscriber in _subs)
                    subscriber.ReceiveMicrophoneData(new ArraySegment<float>(_frame), task.Format);
            }

            if (task.Stream.Position != task.Stream.Length)
                return false;

            if (task.Loop) task.Stream.Position = 0;
            else StopCapture();

            return false;
        }

        public virtual void ResetMicrophone()
        {
            if (Radio.comms._capture._network is null) Radio.comms._capture._network = Radio.comms._net;
            Radio.comms._capture._microphone = this;
            Radio.comms.ResetMicrophoneCapture();
        }
        public virtual WaveFormat StartCapture(string name)
        {
            if (_tasks.Count == 0) throw new NullReferenceException(GetType().FullName);
            try
            {
                foreach (var channel in Radio.comms.PlayerChannels._openChannelsBySubId.Values)
                {
                    Radio.comms.PlayerChannels.Close(channel);
                    Radio.comms.PlayerChannels.Open(channel.TargetId);
                }
            }
            catch { }
            Server.Host.Radio.Network_syncPrimaryVoicechatButton = true;
            AudioTask task = _tasks[0];

            if (task.Stream is null)
            {
                Log.Error($"Stream is null. Microphone: '{name}'; Task Player Name: '{task.PlayerName}'");
                return task.Format;
            }
            else if (!task.Stream.CanRead)
            {
                Log.Error($"Stream cannot be read. Microphone: '{name}'; Task Player Name: '{task.PlayerName}'");
                return task.Format;
            }

            Radio.comms._capture._micName = task.PlayerName;
            Radio.comms._capture._microphone = this;
            Radio.comms._capture._network = Radio.comms._net;
            Radio.comms.IsMuted = false;
            try { Server.Host.ReferenceHub.nicknameSync.Network_displayName = task.PlayerName; } catch { }

            IsRecording = true;
            Latency = TimeSpan.Zero;
            Status = StatusType.Playing;

            UpdateFrames(task);

            task.Active = true;

            return task.Format;
        }
        public virtual void StopCapture()
        {
            if (_tasks.Count == 0) return;
            Server.Host.Radio.Network_syncPrimaryVoicechatButton = false;

            IsRecording = false;
            Status = StatusType.Stopped;

            AudioTask task = _tasks[0];
            _tasks.Remove(task);
            task.Alive = false;
            task.Active = false;

            if (_tasks.Count > 0) ResetMicrophone();
        }
        public virtual void Pause()
        {
            if (Status is not StatusType.Playing) return;
            Server.Host.Radio.Network_syncPrimaryVoicechatButton = false;
            IsRecording = false;
            Status = StatusType.Paused;
        }
        public virtual void Resume()
        {
            if (Status is not StatusType.Paused) return;
            Server.Host.Radio.Network_syncPrimaryVoicechatButton = true;
            IsRecording = true;
            Status = StatusType.Playing;
        }
        public virtual void Skip()
        {
            StopCapture();
            Radio.comms.ResetMicrophoneCapture();
        }
    }
}