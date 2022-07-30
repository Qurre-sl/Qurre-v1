using System.Collections;
using System.Collections.Generic;
namespace Qurre.API.Addons.Audio
{
    internal class TasksList
    {
        internal IReadOnlyCollection<AudioTask> ReadOnly => Cache.AsReadOnly();
        internal bool Contains(AudioTask task) => Cache.Contains(task);
        internal int Count => Cache.Count;
        internal AudioTask this[int index]
        {
            get => Cache[index];
            set => Cache[index] = value;
        }
        private readonly List<AudioTask> Cache = new();
        public IEnumerator GetEnumerator() => Cache.GetEnumerator();
        internal bool Add(AudioTask task)
        {
            if (Cache.Contains(task)) return false;
            Cache.Add(task);
            return true;
        }
        internal bool Remove(AudioTask task, bool disponse = true)
        {
            if (!Cache.Contains(task)) return false;
            Cache.Remove(task);
            if (disponse) task.Dispose();
            return true;
        }
        internal void Clear()
        {
            for (int i = 0; i < Cache.Count; i++)
                Cache[i].Dispose();
            Cache.Clear();
        }
    }
}