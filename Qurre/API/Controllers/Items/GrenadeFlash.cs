using Footprinting;
using InventorySystem.Items.ThrowableProjectiles;
using Mirror;
using UnityEngine;
namespace Qurre.API.Controllers.Items
{
    public class GrenadeFlash : Throwable
    {
        public GrenadeFlash(ThrowableItem itemBase) : base(itemBase)
        {
            FlashbangGrenade grenade = (FlashbangGrenade)Base.Projectile;
            BlindAnimation = grenade._blindingOverDistance;
            SurfaceDistanceIntensifier = grenade._surfaceZoneDistanceIntensifier;
            DeafenAnimation = grenade._deafenDurationOverDistance;
            FuseTime = grenade._fuseTime;
            Player = Player.Get(itemBase.Owner);
        }
        public GrenadeFlash(ItemType type, Player player = null)
            : base(player == null ? (ThrowableItem)Server.Host.Inventory.CreateItemInstance(type, false) : (ThrowableItem)player.Inventory.CreateItemInstance(type, true))
        {
            FlashbangGrenade grenade = (FlashbangGrenade)Base.Projectile;
            BlindAnimation = grenade._blindingOverDistance;
            SurfaceDistanceIntensifier = grenade._surfaceZoneDistanceIntensifier;
            DeafenAnimation = grenade._deafenDurationOverDistance;
            FuseTime = grenade._fuseTime;
            Player = player;
        }
        private Player _pl;
        public Player Player
        {
            get => _pl is null ? Server.Host : _pl;
            set => _pl = value;
        }
        public AnimationCurve BlindAnimation { get; set; }
        public float SurfaceDistanceIntensifier { get; set; }
        public AnimationCurve DeafenAnimation { get; set; }
        public float FuseTime { get; set; }
        public void Spawn(Vector3 position, Vector3 rotation = default, Vector3 scale = default)
        {
            FlashbangGrenade grenade = (FlashbangGrenade)Object.Instantiate(Base.Projectile, position, Quaternion.Euler(rotation));
            grenade.PreviousOwner = new Footprint(Player.ReferenceHub);
            grenade._blindingOverDistance = BlindAnimation;
            grenade._surfaceZoneDistanceIntensifier = SurfaceDistanceIntensifier;
            grenade._deafenDurationOverDistance = DeafenAnimation;
            grenade._fuseTime = FuseTime;
            if (scale != Vector3.zero) grenade.transform.localScale = scale;
            NetworkServer.Spawn(grenade.gameObject);
            grenade.ServerActivate();
        }
    }
}