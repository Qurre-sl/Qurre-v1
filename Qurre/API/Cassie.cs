namespace Qurre.API
{
    public static class Cassie
    {
        public static void DelayedSend(string msg, bool makeHold, bool makeNoise, float delay);
        public static void Send(string msg, bool makeHold, bool makeNoise);
    }
}