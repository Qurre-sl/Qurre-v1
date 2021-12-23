namespace Qurre.API.Addons
{
    public class ListConfigs
    {
        public IConfig this[int index] { get; }

        public bool Add(IConfig cfg);
        public bool Destroy(IConfig cfg);
        public bool Remove(IConfig cfg);
    }
}