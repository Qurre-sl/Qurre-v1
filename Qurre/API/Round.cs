using GameCore;
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
        private static RespawnManager rm => RespawnManager.Singleton;
        private static RoundSummary rs => RoundSummary.singleton;
        internal static bool ForceEnd { get; set; } = false;
        public static TimeSpan ElapsedTime => RoundStart.RoundLength;
        public static DateTime StartedTime => DateTime.Now - ElapsedTime;
        public static int CurrentRound { get; internal set; } = 0;
        public static int ActiveGenerators { get; internal set; } = 0;
        public static float NextRespawn
        {
            get => rm._timeForNextSequence - (float)rm._stopwatch.Elapsed.TotalSeconds;
            set => rm._timeForNextSequence = value + (float)rm._stopwatch.Elapsed.TotalSeconds;
        }
        public static bool Started => RoundSummary.RoundInProgress();
        public static bool Ended => rs is not null && rs.RoundEnded;
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
        public static Dictionary<SpawnableTeamType, List<string>> UnitsToGenerate { get; private set; } = new()
        {
            { SpawnableTeamType.ChaosInsurgency, new() { } },
            { SpawnableTeamType.ClassD, new() { } },
            {
                SpawnableTeamType.NineTailedFox,
                new()
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
                }
            },
            { SpawnableTeamType.Scientist, new() },
            { SpawnableTeamType.SCP, new() },
            { SpawnableTeamType.Tutorial, new() },
            { SpawnableTeamType.None, new() }
        };
        private static int _umc = 20;
        public static int UnitMaxCode
        {
            get => _umc;
            set
            {
                if (value < 0) value = 0;
                else if (value > 99) value = 99;
                _umc = value;
            }
        }
        public static void Restart() => RoundRestart.InitiateRoundRestart();
        public static void Start() => CharacterClassManager.ForceRoundStart();
        public static void End() => ForceEnd = true;
        public static void DimScreen() => rs.RpcDimScreen();
        public static void ShowRoundSummary(RoundSummary.SumInfo_ClassList remainingPlayers, LeadingTeam team)
        {
            var timeToRoundRestart = Mathf.Clamp(ConfigFile.ServerConfig.GetInt("auto_round_restart_time", 10), 5, 1000);
            rs.RpcShowRoundSummary(rs.classlistStart, remainingPlayers, team, EscapedDPersonnel, EscapedScientists, ScpKills, timeToRoundRestart);
        }
        public static void AddUnit(TeamUnitType team, string unit)
        {
            UnitNamingRule unitNamingRule;
            if (!UnitNamingRules.AllNamingRules.TryGetValue((SpawnableTeamType)team, out unitNamingRule)) return;
            unitNamingRule.AddCombination(unit, (SpawnableTeamType)team);
        }
        public static void RenameUnit(TeamUnitType team, int id, string newName)
        {
            RespawnManager.Singleton.NamingManager.AllUnitNames[id] = new SyncUnit
            {
                SpawnableTeam = (byte)team,
                UnitName = newName
            };
        }
        public static void RemoveUnit(int id)
        {
            RespawnManager.Singleton.NamingManager.AllUnitNames.RemoveAt(id);
        }
        public static void ForceTeamRespawn(bool isCI) => RespawnManager.Singleton.ForceSpawnTeam(isCI ? SpawnableTeamType.ChaosInsurgency : SpawnableTeamType.NineTailedFox);
        public static void CallCICar() => RespawnEffectsController.ExecuteAllEffects(RespawnEffectsController.EffectType.Selection, SpawnableTeamType.ChaosInsurgency);
        public static void CallMTFHelicopter() => RespawnEffectsController.ExecuteAllEffects(RespawnEffectsController.EffectType.Selection, SpawnableTeamType.NineTailedFox);
    }
}