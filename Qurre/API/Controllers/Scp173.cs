using Mirror;
using PlayableScps.ScriptableObjects;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
namespace Qurre.API.Controllers
{
    public class Scp173
    {
        internal Scp173(Player player) => _player = player;
        private readonly Player _player;
        private PlayableScps.Scp173 Scp => _player.CurrentScp as PlayableScps.Scp173;
        public HashSet<Player> IgnoredPlayers { get; internal set; } = new HashSet<Player>();
        public bool IsObserved { get => Scp._isObserved; set => Scp._isObserved = value; }
        public IReadOnlyCollection<Player> ObservingPlayers => Scp._observingPlayers.Select(hub => Player.Get(hub)).ToList().AsReadOnly();
        public float MoveSpeed => Scp.GetMoveSpeed();
        public bool BlinkReady { get => Scp.BlinkReady; set => Scp.BlinkReady = value; }
        public float BlinkCooldown
        {
            get => Scp._blinkCooldownRemaining;
            set => Scp._blinkCooldownRemaining = value;
        }
        public float BlinkDistance => Scp.EffectiveBlinkDistance();
        public bool BreakneckActive { get => Scp.BreakneckSpeedsActive; set => Scp.BreakneckSpeedsActive = value; }
        public float BreakneckCooldown { get => Scp._breakneckSpeedsCooldownRemaining; set => Scp._breakneckSpeedsCooldownRemaining = value; }
        public float TantrumCooldown { get => Scp._tantrumCooldownRemaining; set => Scp._tantrumCooldownRemaining = value; }
        public static void PlaceTantrum(Vector3 pos)
        {

            GameObject gameObject = Object.Instantiate(ScpScriptableObjects.Instance.Scp173Data.TantrumPrefab);
            gameObject.transform.position = pos;
            NetworkServer.Spawn(gameObject);
        }
    }
}