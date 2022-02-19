using InventorySystem;
using InventorySystem.Items;
using InventorySystem.Items.Pickups;
using Mirror;
using System.Collections.Generic;
using UnityEngine;
namespace Qurre.API.Controllers.Items
{
    public class Pickup
    {
        internal static readonly Dictionary<ItemPickupBase, Pickup> BaseToItem = new();
        private ushort id;
        public Pickup(ItemPickupBase pickupBase)
        {
            Base = pickupBase;
            Serial = pickupBase.NetworkInfo.Serial;
            BaseToItem.Add(pickupBase, this);
        }
        public Pickup(ItemType type)
        {
            if (!InventoryItemLoader.AvailableItems.TryGetValue(type, out ItemBase itemBase))
                return;

            Base = itemBase.PickupDropModel;
            Serial = itemBase.PickupDropModel.NetworkInfo.Serial;
            BaseToItem.Add(itemBase.PickupDropModel, this);
        }
        private string _tag = "";
        public string Tag
        {
            get => _tag;
            set
            {
                if (value is null) return;
                _tag = value;
            }
        }
        public ushort Serial
        {
            get
            {
                if (id is 0)
                {
                    id = ItemSerialGenerator.GenerateNext();
                    Base.Info.Serial = id;
                    Base.NetworkInfo = Base.Info;
                }
                return id;
            }
            internal set
            {
                if (value is 0) value = ItemSerialGenerator.GenerateNext();
                if (Base is null) return;
                Base.Info.Serial = value;
                Base.NetworkInfo = Base.Info;
                id = value;
            }
        }
        public Vector3 Scale
        {
            get => Base.gameObject.transform.localScale;
            set
            {
                GameObject gameObject = Base.gameObject;
                NetworkServer.UnSpawn(gameObject);
                gameObject.transform.localScale = value;
                NetworkServer.Spawn(gameObject);
            }
        }
        public float Weight
        {
            get => Base.NetworkInfo.Weight;
            set
            {
                Base.Info.Weight = value;
                Base.NetworkInfo = Base.Info;
            }
        }
        public ItemPickupBase Base { get; }
        public ItemType Type => Base.NetworkInfo.ItemId;
        private ItemCategory category = ItemCategory.None;
        public ItemCategory Category
        {
            get
            {
                if (category == ItemCategory.None) category = Get();
                return category;
                ItemCategory Get()
                {
                    return Type switch
                    {
                        ItemType.KeycardChaosInsurgency or ItemType.KeycardContainmentEngineer or ItemType.KeycardFacilityManager or ItemType.KeycardGuard or ItemType.KeycardJanitor or ItemType.KeycardNTFCommander or ItemType.KeycardNTFLieutenant or ItemType.KeycardNTFOfficer or ItemType.KeycardO5 or ItemType.KeycardResearchCoordinator or ItemType.KeycardScientist or ItemType.KeycardZoneManager => ItemCategory.Keycard,
                        ItemType.Medkit or ItemType.Adrenaline or ItemType.Painkillers => ItemCategory.Medical,
                        ItemType.Radio => ItemCategory.Radio,
                        ItemType.GunAK or ItemType.GunCOM15 or ItemType.GunCOM18 or ItemType.GunCrossvec or ItemType.GunE11SR or ItemType.GunFSP9 or ItemType.GunLogicer or ItemType.GunRevolver or ItemType.GunShotgun => ItemCategory.Firearm,
                        ItemType.GrenadeFlash or ItemType.GrenadeHE => ItemCategory.Grenade,
                        ItemType.SCP018 or ItemType.SCP207 or ItemType.SCP268 or ItemType.SCP500 or ItemType.SCP244a or ItemType.SCP244b or ItemType.SCP330 or ItemType.SCP2176 => ItemCategory.SCPItem,
                        ItemType.MicroHID => ItemCategory.MicroHID,
                        ItemType.Ammo12gauge or ItemType.Ammo44cal or ItemType.Ammo556x45 or ItemType.Ammo762x39 or ItemType.Ammo9x19 => ItemCategory.Ammo,
                        ItemType.ArmorCombat or ItemType.ArmorHeavy or ItemType.ArmorLight => ItemCategory.Armor,
                        _ => ItemCategory.None,
                    };
                }
            }
        }
        public bool Locked
        {
            get => Base.NetworkInfo.Locked;
            set
            {
                PickupSyncInfo info = Base.Info;
                info.Locked = value;
                Base.NetworkInfo = info;
            }
        }
        public bool InUse
        {
            get => Base.NetworkInfo.InUse;
            set
            {
                PickupSyncInfo info = Base.Info;
                info.InUse = value;
                Base.NetworkInfo = info;
            }
        }
        public Vector3 Position
        {
            get => Base.NetworkInfo.Position;
            set
            {
                Base.Rb.position = value;
                Base.transform.position = value;
                NetworkServer.UnSpawn(Base.gameObject);
                NetworkServer.Spawn(Base.gameObject);

                Base.RefreshPositionAndRotation();
            }
        }
        public Quaternion Rotation
        {
            get => Base.NetworkInfo.Rotation.Value;
            set
            {
                Base.Rb.rotation = value;
                Base.transform.rotation = value;
                NetworkServer.UnSpawn(Base.gameObject);
                NetworkServer.Spawn(Base.gameObject);

                Base.RefreshPositionAndRotation();
            }
        }
        public static Pickup Get(ItemPickupBase pickupBase) =>
            pickupBase == null ? null :
            BaseToItem.ContainsKey(pickupBase) ? BaseToItem[pickupBase] :
            new Pickup(pickupBase);
        public void Destroy()
        {
            Base.DestroySelf();
            BaseToItem.Remove(Base);
        }
    }
}