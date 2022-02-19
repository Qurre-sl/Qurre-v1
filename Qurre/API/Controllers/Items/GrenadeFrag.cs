using Footprinting;
using InventorySystem.Items.ThrowableProjectiles;
using Mirror;
using UnityEngine;
using Object = UnityEngine.Object;
namespace Qurre.API.Controllers.Items
{
    public class GrenadeFrag : Throwable
    {
        public GrenadeFrag(ThrowableItem itemBase) : base(itemBase)
        {
            ExplosionGrenade grenade = (ExplosionGrenade)Base.Projectile;
            MaxRadius = grenade._maxRadius;
            ScpMultiplier = grenade._scpDamageMultiplier;
            BurnDuration = grenade._burnedDuration;
            DeafenDuration = grenade._deafenedDuration;
            ConcussDuration = grenade._concussedDuration;
            FuseTime = grenade._fuseTime;
            Player = Player.Get(itemBase.Owner);
        }
        public GrenadeFrag(ItemType type, Player player = null)
            : base(player == null ? (ThrowableItem)Server.Host.Inventory.CreateItemInstance(type, false) : (ThrowableItem)player.Inventory.CreateItemInstance(type, true))
        {
            ExplosionGrenade grenade = (ExplosionGrenade)Base.Projectile;
            MaxRadius = grenade._maxRadius;
            ScpMultiplier = grenade._scpDamageMultiplier;
            BurnDuration = grenade._burnedDuration;
            DeafenDuration = grenade._deafenedDuration;
            ConcussDuration = grenade._concussedDuration;
            FuseTime = grenade._fuseTime;
            Player = player;
        }
        private Player _pl;
        public Player Player
        {
            get => _pl is null ? Server.Host : _pl;
            set => _pl = value;
        }
        public float MaxRadius { get; set; }
        public float ScpMultiplier { get; set; }
        public float BurnDuration { get; set; }
        public float DeafenDuration { get; set; }
        public float ConcussDuration { get; set; }
        public float FuseTime { get; set; }
        public void Spawn(Vector3 position, Vector3 rotation = default, Vector3 scale = default)
        {
            ExplosionGrenade grenade = (ExplosionGrenade)Object.Instantiate(Base.Projectile, position, Quaternion.Euler(rotation));
            grenade._maxRadius = MaxRadius;
            grenade._scpDamageMultiplier = ScpMultiplier;
            grenade._burnedDuration = BurnDuration;
            grenade._deafenedDuration = DeafenDuration;
            grenade._concussedDuration = ConcussDuration;
            grenade._fuseTime = FuseTime;
            grenade.PreviousOwner = new Footprint(Player.ReferenceHub);
            if (scale != Vector3.zero) grenade.transform.localScale = scale;
            NetworkServer.Spawn(grenade.gameObject);
            grenade.ServerActivate();
        }
    }
}