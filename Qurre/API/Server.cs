using System.Collections.Generic;
namespace Qurre.API
{
    public static class Server
    {
        public static ServerConsole ServerConsole { get; }
        public static DataBase.DataBase DataBase { get; }
        public static ushort Port { get; }
        public static string Ip { get; }
        public static bool RealEscape { get; set; }
        public static string Name { get; set; }
        public static int Slots { get; set; }
        public static bool FriendlyFire { get; set; }
        public static Player Host { get; }
        public static global::InventorySystem.Inventory InventoryHost { get; }
        public static int MaxConnections { get; set; }

        public static TObject GetObjectOf<TObject>() where TObject : global::UnityEngine.Object;
        public static List<TObject> GetObjectsOf<TObject>() where TObject : global::UnityEngine.Object;
        public static void InvokeStaticMethod(this Type type, string methodName, object[] param);
        public static void Restart();
    }
}
