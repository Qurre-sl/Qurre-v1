using GameCore;
using Qurre.API.Addons;
using Qurre.API.Objects;
using Respawning;
using Respawning.NamingRules;
using RoundRestarting;
using System;
using System.Collections.Generic;
using UnityEngine;
namespace Qurre.API
{
    public static class Round
    {
        internal static bool BotSpawned { get; set; } = false;
        internal static bool ForceEnd { get; set; } = false;
        public static TimeSpan ElapsedTime => RoundStart.RoundLength;
        public static DateTime StartedTime => DateTime.Now - ElapsedTime;
        public static int CurrentRound { get; internal set; } = 0;
        public static int ActiveGenerators { get; internal set; } = 0;
        public static float NextRespawn
        {
            get => RespawnManager.Singleton._timeForNextSequence - (float)RespawnManager.Singleton._stopwatch.Elapsed.TotalSeconds;
            set => RespawnManager.Singleton._timeForNextSequence = value + (float)RespawnManager.Singleton._stopwatch.Elapsed.TotalSeconds;
        }
        public static bool Started => RoundSummary.RoundInProgress();
        public static bool Ended => RoundSummary.singleton is not null && RoundSummary.singleton.RoundEnded;
        public static bool Waiting => RoundStart.singleton is not null && !Started && !Ended;
        public static bool Lock
        {
            get => RoundSummary.RoundLock;
            set => RoundSummary.RoundLock = value;
        }
        public static bool LobbyLock
        {
            get => RoundStart.LobbyLock;
            set => RoundStart.LobbyLock = value;
        }
        public static int EscapedDPersonnel
        {
            get => RoundSummary.EscapedClassD;
            set => RoundSummary.EscapedClassD = value;
        }
        public static int EscapedScientists
        {
            get => RoundSummary.EscapedScientists;
            set => RoundSummary.EscapedScientists = value;
        }
        public static int ScpKills
        {
            get => RoundSummary.KilledBySCPs;
            set => RoundSummary.KilledBySCPs = value;
        }
        public static List<UnitGenerator> UnitsToGenerate { get; private set; } = new()
        {
            new(SpawnableTeamType.None, new()),
            new(SpawnableTeamType.ChaosInsurgency, new()),
            new(SpawnableTeamType.NineTailedFox, new()
            {
                "ALPHA",
                "BRAVO",
                "CHARLIE",
                "DELTA",
                "ECHO",
                "FOXTROT",
                "GOLF",
                "HOTEL",
                "INDIA",
                "JULIETT",
                "KILO",
                "LIMA",
                "MIKE",
                "NOVEMBER",
                "OSCAR",
                "PAPA",
                "QUEBEC",
                "ROMEO",
                "SIERRA",
                "TANGO",
                "UNIFORM",
                "VICTOR",
                "WHISKEY",
                "XRAY",
                "YANKEE",
                "ZULU"
            }),
            new(SpawnableTeamType.ClassD, new()),
            new(SpawnableTeamType.Scientist, new()),
            new(SpawnableTeamType.SCP, new()),
            new(SpawnableTeamType.Tutorial, new())
        };
        private static int _umc = 20;
        public static int UnitMaxCode
        {
            get => _umc;
            set => _umc = Mathf.Clamp(value, 0, 99);
        }
        public static void Restart() => RoundRestart.InitiateRoundRestart();
        public static void Start() => CharacterClassManager.ForceRoundStart();
        public static void End() => ForceEnd = true;
        public static void DimScreen() => RoundSummary.singleton.RpcDimScreen();
        public static void ShowRoundSummary(RoundSummary.SumInfo_ClassList remainingPlayers, LeadingTeam team) =>
            RoundSummary.singleton.RpcShowRoundSummary(RoundSummary.singleton.classlistStart, remainingPlayers, team,
                EscapedDPersonnel, EscapedScientists, ScpKills, Mathf.Clamp(ConfigFile.ServerConfig.GetInt("auto_round_restart_time", 10), 5, 1000));
        public static void AddUnit(TeamUnitType team, string unit)
        {
            if (!UnitNamingRules.AllNamingRules.TryGetValue((SpawnableTeamType)team, out var unitNamingRule)) return;
            unitNamingRule.AddCombination(unit, (SpawnableTeamType)team);
        }
        public static void RenameUnit(TeamUnitType team, int id, string newName) =>
            RespawnManager.Singleton.NamingManager.AllUnitNames[id] = new SyncUnit
            {
                SpawnableTeam = (byte)team,
                UnitName = newName
            };
        public static void RemoveUnit(int id) => RespawnManager.Singleton.NamingManager.AllUnitNames.RemoveAt(id);
        public static void ForceTeamRespawn(bool isCI) => RespawnManager.Singleton.ForceSpawnTeam(isCI ? SpawnableTeamType.ChaosInsurgency : SpawnableTeamType.NineTailedFox);
        public static void CallCICar() => RespawnEffectsController.ExecuteAllEffects(RespawnEffectsController.EffectType.Selection, SpawnableTeamType.ChaosInsurgency);
        public static void CallMTFHelicopter() => RespawnEffectsController.ExecuteAllEffects(RespawnEffectsController.EffectType.Selection, SpawnableTeamType.NineTailedFox);
    }
}