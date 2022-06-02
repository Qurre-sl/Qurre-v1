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
            _frame = new float[task.Stream.FrameSize];
            _frameBytes = new byte[task.Stream.FrameSize * 4];
        }
        internal void UpdateListeners(AudioTask task)
        {
            foreach (var channel in Radio.comms.PlayerChannels._openChannelsBySubId.Values)
            {
                Radio.comms.PlayerChannels.Close(channel);
                Radio.comms.PlayerChannels.Open(channel.TargetId, amplitudeMultiplier: (float)task.Volume / 100);
            }
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
            if (Status is not StatusType.Playing)
                return false;

            AudioStream stream = _tasks[0].Stream;

            _elapsedTime += Time.unscaledDeltaTime;

            while (_elapsedTime > stream.UpdateInterval)
            {
                _elapsedTime -= stream.UpdateInterval;

                var readLength = stream.Read(_frameBytes, 0, _frameBytes.Length);

                Array.Clear(_frame, 0, _frame.Length);

                Buffer.BlockCopy(_frameBytes, 0, _frame, 0, readLength);

                foreach (var subscriber in _subs)
                    subscriber.ReceiveMicrophoneData(new ArraySegment<float>(_frame), stream.Format);
            }

            if (!stream.CheckEnd())
                return false;

            if (_tasks[0].Loop) stream.Position = 0;
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
            AudioTask task = _tasks[0];
            try { UpdateListeners(task); } catch { }
            Server.Host.Radio.Network_syncPrimaryVoicechatButton = true;

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

            return task.Stream.Format;
        }
        public virtual void StopCapture()
        {
            if (_tasks.Count == 0) return;
            Server.Host.Radio.Network_syncPrimaryVoicechatButton = false;

            IsRecording = false;
            Status = StatusType.Stopped;

            AudioTask task = _tasks[0];
            _tasks.Remove(task);

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
            ResetMicrophone();
        }
    }
}