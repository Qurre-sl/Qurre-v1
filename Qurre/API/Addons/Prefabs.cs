using Interactables.Interobjects;
using InventorySystem.Items.Firearms.Attachments;
using MapGeneration.Distributors;
using Mirror;
using Qurre.API.Objects;
using System;
using System.Collections.Generic;
using UnityEngine;
namespace Qurre.API.Addons
{
    public static class Prefabs
    {
        private static readonly Dictionary<DoorPrefabs, BreakableDoor> _doors = new();
        private static readonly Dictionary<LockerPrefabs, Locker> _lockers = new();
        private static readonly Dictionary<TargetPrefabs, GameObject> _targets = new();
        private static WorkstationController _work;
        private static Scp079Generator _generator;
        private static GameObject _primitive;
        private static GameObject _light;
        public static IReadOnlyDictionary<DoorPrefabs, BreakableDoor> Doors => _doors;
        public static IReadOnlyDictionary<LockerPrefabs, Locker> Lockers => _lockers;
        public static IReadOnlyDictionary<TargetPrefabs, GameObject> Targets => _targets;
        public static WorkstationController WorkStation => _work;
        public static Scp079Generator Generator => _generator;
        public static GameObject Primitive => _primitive;
        public static GameObject Light => _light;
    }
}