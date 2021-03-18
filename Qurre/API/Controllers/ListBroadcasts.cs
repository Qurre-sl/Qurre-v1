namespace Qurre.API.Controllers
{
    public class ListBroadcasts
    {
        public ListBroadcasts(Player player);

        public void Add(Broadcast bc, bool instant = false);
        public bool Any(Func<Broadcast, bool> func);
        public void Clear();
        public bool Contains(Broadcast bc);
        public Broadcast FirstOrDefault();
        public Broadcast FirstOrDefault(Func<Broadcast, bool> func);
        public List<Broadcast> List();
        public void Remove(Broadcast bc);
    }
}
