using Qurre.API.Objects;
using System.Collections.Generic;

namespace Qurre.API
{
    public class Map
    {
        public static int roundtime;
        public static List<Tesla> Teslas { get; }
        public static List<Room> Rooms { get; }
        public static List<Ragdoll> Ragdolls { get; }
        public static List<Generator> Generators { get; }
        public static List<Lift> Lifts { get; }
        public static List<Door> Doors { get; }
        public static Scp914 Scp914 { get; }
        public static CassieList Cassies { get; }
        public static MapListBroadcasts Broadcasts { get; }
        public static Heavy Heavy { get; }
        public static Decontamination DecontaminationLCZ { get; }
        public static Alpha Alpha { get; }
        public static List<WorkStation> WorkStations { get; }
        public static List<Pickup> Pickups { get; }

        public static MapBroadcast Broadcast(string message, ushort duration, bool instant = false);
        public static void ClearBroadcasts();
        public static void ContainSCP106(ReferenceHub executor);
        public static void Explode(global::UnityEngine.Vector3 position, GrenadeType grenadeType = GrenadeType.Grenade, Player player = null);
        public static global::UnityEngine.Vector3 GetRandomSpawnPoint(RoleType roleType);
        public static void PlaceBlood(global::UnityEngine.Vector3 position, int type, float size);
        public static void PlayAmbientSound(int id);
        public static void PlayCIEntranceMusic();
        public static void PlayIntercomSound(bool start);
        public static void RemoveDoors();
        public static void RemoveTeslaGates();
        public static void SetElevatorsMovingSpeed(float newSpeed);
        public static void SetFemurBreakerState(bool enabled);
        public static void SetIntercomSpeaker(Player player);
        public static void ShakeScreen(float times);
        public static global::UnityEngine.GameObject SpawnBot(RoleType role, string name, float health, global::UnityEngine.Vector3 position, global::UnityEngine.Vector3 rotation, global::UnityEngine.Vector3 scale);
        public static void SpawnGrenade(string grenadeType, global::UnityEngine.Vector3 position);
        public static global::UnityEngine.GameObject SpawnPlayer(RoleType role, string name, string userSteamID, global::UnityEngine.Vector3 position, global::UnityEngine.Vector3 rotation, global::UnityEngine.Vector3 scale);
        public static void TurnOffLights(float duration, bool onlyHeavy = false);
    }
}