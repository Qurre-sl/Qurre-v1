namespace Qurre.API.Addons
{
    public class ListConfigs
    {
        public IConfig this[int index] { get; }
        public bool Add(IConfig cfg);
        public void Clear();
        public bool Destroy(IConfig cfg);
        public IEnumerator GetEnumerator();
        public bool Remove(IConfig cfg);
    }
}