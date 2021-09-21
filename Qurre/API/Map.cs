﻿using Qurre.API.Controllers;
using Qurre.API.Objects;
using System.Collections.Generic;
namespace Qurre.API
{
    public static class Map
    {
        public static CassieList Cassies { get; }
        public static List<Lift> Lifts { get; }
        public static List<Locker> Lockers { get; }
        public static List<Generator> Generators { get; }
        public static List<Ragdoll> Ragdolls { get; }
        public static List<Room> Rooms { get; }
        public static List<Camera> Cameras { get; }
        public static List<Tesla> Teslas { get; }
        public static List<Door> Doors { get; }
        public static List<WorkStation> WorkStations { get; }
        public static List<Pickup> Pickups { get; }
        public static float WalkSpeedMultiplier { get; set; }
        public static float SprintSpeedMultiplier { get; set; }
        public static bool DisabledLCZDecontamination { get; set; }
        public static global::UnityEngine.Vector3 Gravitation { get; set; }
        public static float ElevatorsMovingSpeed { get; set; }
        public static bool FemurBreakerState { get; set; }
        public static List<Bot> Bots { get; }
        public static float Seed { get; }
        public static float BreakableWindowHp { get; set; }

        public static void AnnounceNtfEntrance(int scpsLeft, int mtfNumber, char mtfLetter);
        public static void AnnounceScpKill(string scpNumber, Player killer = null);
        public static MapBroadcast Broadcast(string message, ushort duration, bool instant = false);
        public static void ClearBroadcasts();
        public static void ContainSCP106(Player executor);
        public static void DecontaminateLCZ();
        public static Room FindRoom(global::UnityEngine.GameObject objectInRoom);
        public static global::UnityEngine.Vector3 GetRandomSpawnPoint(RoleType roleType);
        public static void PlaceBlood(global::UnityEngine.Vector3 position, int type, float size);
        public static void PlayAmbientSound(int id);
        public static void PlayCIEntranceMusic();
        public static void PlayIntercomSound(bool start);
        public static void Remove(RemovableObject removable);
        public static void SetIntercomSpeaker(Player player);
        public static void ShakeScreen(float times);
        public static void ShowHint(string message, float duration);
        [Obsolete("Use Bot.Create")]
        public static global::UnityEngine.GameObject SpawnBot(RoleType role, string name, float health, global::UnityEngine.Vector3 position, global::UnityEngine.Vector3 rotation, global::UnityEngine.Vector3 scale);
        public static void SpawnGrenade(string grenadeType, global::UnityEngine.Vector3 position);
        [Obsolete("Use Bot.Create")]
        public static global::UnityEngine.GameObject SpawnPlayer(RoleType role, string name, string userSteamID, global::UnityEngine.Vector3 position, global::UnityEngine.Vector3 rotation, global::UnityEngine.Vector3 scale);
    }
}