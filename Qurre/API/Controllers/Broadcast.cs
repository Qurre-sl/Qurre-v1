namespace Qurre.API.Controllers
{
    public class Broadcast
    {
        public Broadcast(Player player, string message, ushort time);

        public float DisplayTime { get; }
        public string Message { get; set; }
        public ushort Time { get; }
        public bool Active { get; }

        public void End();
        public void Start(Player player);
        public void Update();
    }
}
