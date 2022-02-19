using Mirror;
using PlayableScps.ScriptableObjects;
using System.Collections.Generic;
using UnityEngine;
namespace Qurre.API.Controllers
{
    public class Scp173
    {
        public HashSet<Player> IgnoredPlayers { get; internal set; } = new HashSet<Player>();
        public static void PlaceTantrum(Vector3 pos)
        {
            GameObject gameObject = Object.Instantiate(ScpScriptableObjects.Instance.Scp173Data.TantrumPrefab);
            gameObject.transform.position = pos;
            NetworkServer.Spawn(gameObject);
        }
    }
}