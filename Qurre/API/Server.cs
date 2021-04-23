using System.Collections.Generic;
namespace Qurre.API
{
    public static class Server
    {
        public static ServerConsole ServerConsole { get; }
        public static ushort Port { get; }
        public static string Ip { get; }
        public static string Name { get; set; }
        public static int Slots { get; set; }
        public static bool FriendlyFire { get; set; }
        public static Player Host { get; }
        public static Inventory InventoryHost { get; }

        public static TObject GetObjectOf<TObject>() where TObject : global::UnityEngine.Object;
        public static List<TObject> GetObjectsOf<TObject>() where TObject : global::UnityEngine.Object;
        public static int MaxPlayers();
        public static void MaxPlayers(int amount);
        public static void Restart();
    }
}
