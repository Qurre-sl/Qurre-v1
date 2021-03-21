namespace Qurre.API.Controllers
{
    public class Cassie
    {
        public string Message;
        public bool Hold;
        public bool Noise;

        public Cassie(string message, bool makeHold, bool makeNoise);

        public static bool Lock { get; set; }
        public bool Active { get; }

        public static void Send(string msg, bool makeHold = false, bool makeNoise = false);
        public void Send();
    }
}