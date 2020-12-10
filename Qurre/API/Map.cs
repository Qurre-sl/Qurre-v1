using Qurre.API.Objects;
using System.Collections.Generic;
namespace Qurre.API
{
    public static class Map
    {
        public static int roundtime;

        public static List<Lift> Lifts { get; }
        public static List<Door> Doors { get; }
        public static List<Room> Rooms { get; }
        public static bool FriendlyFire { get; set; }
        public static Inventory InventoryHost { get; }
        public static ReferenceHub Host { get; }
        public static List<TeslaGate> TeslaGates { get; }
        public static int ActivatedGenerators { get; }

        public static void ActivateSCP914();
        public static void Broadcast(string message, ushort duration, Broadcast.BroadcastFlags flag = 0);
        public static void CallCICar();
        public static void CallMTFHelicopter();
        public static void ClearBroadcasts();
        public static void ContainSCP106(ReferenceHub executor);
        public static void CreateRoom(Room room, global::UnityEngine.Vector3 position, global::UnityEngine.Vector3 scale, global::UnityEngine.Quaternion rotation);
        public static global::UnityEngine.Vector3 GetRandomSpawnPoint(RoleType roleType);
        public static IEnumerable<Room> GetRooms();
        public static IEnumerable<ReferenceHub> HubsInRoom(this Room room);
        public static Pickup ItemSpawn(ItemType itemType, float durability, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation = null, int sight = 0, int barrel = 0, int other = 0);
        public static void PlayCIEntranceMusic();
        public static void RemoveDoors();
        public static void RemoveTeslaGates();
        public static void SetElevatorsMovingSpeed(float newSpeed);
        public static void SetFemurBreakerState(bool enabled);
        public static void SetIntercomSpeaker(ReferenceHub player);
        public static void ShakeScreen(float times);
        public static global::UnityEngine.GameObject SpawnBot(RoleType role, string name, float health, global::UnityEngine.Vector3 position, global::UnityEngine.Vector3 rotation, global::UnityEngine.Vector3 scale);
        public static global::UnityEngine.GameObject SpawnBrokenRagdoll(RoleType role, global::UnityEngine.Vector3 position, global::UnityEngine.Vector3 rotation, global::UnityEngine.Vector3 scale);
        public static void SpawnGrenade(string grenadeType, global::UnityEngine.Vector3 position);
        public static global::UnityEngine.GameObject SpawnItem(ItemType itemType, global::UnityEngine.Vector3 position, global::UnityEngine.Vector3 rotation, global::UnityEngine.Vector3 scale);
        public static global::UnityEngine.GameObject SpawnPlayer(RoleType role, string name, string userSteamID, global::UnityEngine.Vector3 position, global::UnityEngine.Vector3 rotation, global::UnityEngine.Vector3 scale);
        public static void SpawnRagdoll(RoleType role, string name, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, string ownerID, string ownerNickname, int playerID);
        public static global::UnityEngine.GameObject SpawnWorkstation(bool isTabletConnected, global::UnityEngine.Vector3 position, global::UnityEngine.Vector3 rotation, global::UnityEngine.Vector3 scale);
        public static void TurnOffLights(float duration, bool onlyHeavy = false);
    }
}