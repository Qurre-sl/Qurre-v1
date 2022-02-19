namespace Qurre.API.Controllers
{
    public static class Heavy
    {
        private static Recontainer079 Container => Server.GetObjectOf<Recontainer079>();
        public static byte ActiveGenerators { get => (byte)Container._prevEngaged; }
        public static bool Recontained079 => Container._alreadyRecontained && Container._delayStopwatch.Elapsed.TotalSeconds > Container._activationDelay;
        public static void Overcharge()
        {
            Container.TryKill079();
            Container.PlayAnnouncement(Container._announcementSuccess + " Unknown", 1f);
        }
    }
}