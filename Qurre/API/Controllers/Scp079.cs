using Mirror;
using System.Collections.Generic;
using System.Linq;
namespace Qurre.API.Controllers
{
    public class Scp079
    {
        internal Scp079(Player player) => this.player = player;
        private readonly Player player;
        private Scp079PlayerScript script => player.ClassManager.Scp079;
        public bool Is079 => player.Role == RoleType.Scp079;
        public Scp079PlayerScript.Ability079[] Abilities { get => script.abilities; set => script.abilities = value; }
        public byte Lvl { get => (byte)(script.Lvl + 1); set => script.Lvl = (byte)(value - 1); }
        public Scp079PlayerScript.Level079[] Lvls { get => script.levels; set => script.levels = value; }
        public string Speaker { get => script.Speaker; set => script.Speaker = value; }
        public float Exp { get => script.Exp; set => script.Exp = value; }
        public float Energy { get => script.Mana; set => script.Mana = value; }
        public float MaxEnergy { get => script.maxMana; set => script.NetworkmaxMana = value; }
        public float LockdownDuration { get => script.LockdownDuration; set => script.LockdownDuration = value; }
        public Camera Camera { get => Map.Cameras.FirstOrDefault(x => x.cmr == script.currentCamera); set => script.RpcSwitchCamera(value.Id, false); }
        public Camera079 Camera079 { get => script.currentCamera; set => script.RpcSwitchCamera(value.cameraId, false); }
        public static Camera079[] Cameras => Scp079PlayerScript.allCameras;
        public static IEnumerable<Scp079Interactable> Speakers => UnityEngine.Object.FindObjectsOfType<Scp079Interactable>().Where(x => x.type == Scp079Interactable.InteractableType.Speaker);
        public SyncList<uint> LockedDoors { get => script.lockedDoors; set => script.lockedDoors = value; }
        public void GiveExp(float amount) => script.AddExperience(amount);
        public void ForceLevel(byte levelToForce, bool notifiyUser) => script.ForceLevel(levelToForce, notifiyUser);
        public void AddLockedDoor(uint doorID) { if (!script.lockedDoors.Contains(doorID)) script.lockedDoors.Add(doorID); }
        public void UnlockDoor(uint doorID) { if (script.lockedDoors.Contains(doorID)) script.lockedDoors.Remove(doorID); }
        public void UnlockDoors() => script.CmdResetDoors();
    }
}