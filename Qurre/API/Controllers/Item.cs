using Mirror;
using System.Linq;
using UnityEngine;
using System.Collections.Generic;
using InventorySystem.Items;
using InventorySystem.Items.Pickups;
using InventorySystem.Items.Firearms;
using InventorySystem.Items.Keycards;
using InventorySystem.Items.Usables;
using InventorySystem.Items.Radio;
using InventorySystem.Items.MicroHID;
using InventorySystem.Items.Armor;
using InventorySystem.Items.Firearms.Ammo;
using InventorySystem.Items.Flashlight;
using InventorySystem.Items.ThrowableProjectiles;
using InventorySystem.Items.Usables.Scp330;
using Qurre.API.Controllers.Items;
namespace Qurre.API.Controllers
{
    public class Item
    {
        internal static readonly Dictionary<ItemBase, Item> BaseToItem = new();
        private ushort id;
        public Item(ItemBase itemBase)
        {
            Base = itemBase;
            Type = itemBase.ItemTypeId;
            Category = itemBase.Category;
            Serial = Base.OwnerInventory.UserInventory.Items.FirstOrDefault(i => i.Value == Base).Key;
            if (Serial == 0) Serial = ItemSerialGenerator.GenerateNext();
            BaseToItem.Add(itemBase, this);
        }
        public Item(ItemType type) : this(Server.InventoryHost.CreateItemInstance(type, false)) { }
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
                id = Base.OwnerInventory.UserInventory.Items.FirstOrDefault(i => i.Value == Base).Key;
                return id;
            }
            internal set
            {
                if (value == 0) value = ItemSerialGenerator.GenerateNext();
                if (Base == null || Base.PickupDropModel == null)
                    return;
                Base.PickupDropModel.Info.Serial = value;
                Base.PickupDropModel.NetworkInfo = Base.PickupDropModel.Info;
                id = value;
            }
        }
        public Vector3 Scale { get; set; } = Vector3.one;
        public ItemBase Base { get; }
        public ItemType Type { get; internal set; }
        public ItemCategory Category { get; internal set; }
        public float Weight => Base.Weight;
        public Player Owner
        {
            get
            {
                if (Base != null) return Player.Get(Base.Owner);
                return Server.Host;
            }
        }
        public static Item Get(ItemBase itemBase)
        {
            if (itemBase == null) return null;
            if (BaseToItem.ContainsKey(itemBase))
                return BaseToItem[itemBase];
            switch (itemBase)
            {
                case Firearm gun:
                    return new Gun(gun);
                case KeycardItem card:
                    return new Keycard(card);
                case UsableItem usable:
                    {
                        if (usable is Scp330Bag bag)
                            return new Scp330(bag);
                        return new Usable(usable);
                    }
                case RadioItem radio:
                    return new Items.Radio(radio);
                case MicroHIDItem hid:
                    return new MicroHid(hid);
                case BodyArmor armor:
                    return new Armor(armor);
                case AmmoItem ammo:
                    return new Ammo(ammo);
                case FlashlightItem flashlight:
                    return new Flashlight(flashlight);
                case ThrowableItem throwable:
                    return throwable.Projectile switch
                    {
                        FlashbangGrenade _ => new GrenadeFlash(throwable),
                        ExplosionGrenade _ => new GrenadeFrag(throwable),
                        _ => new Throwable(throwable),
                    };
                default:
                    return new Item(itemBase);
            }
        }
        public static Item Get(ushort serial)
        {
            if (Object.FindObjectsOfType<ItemBase>().TryFind(out ItemBase _bs, x => x.ItemSerial == serial)) return Get(_bs);
            return null;
        }
        public void Give(Player player) => player.AddItem(Base);
        public virtual Pickup Spawn(Vector3 position, Quaternion rotation = default)
        {
            Base.PickupDropModel.Info.ItemId = Type;
            Base.PickupDropModel.Info.Position = position;
            Base.PickupDropModel.Info.Weight = Weight;
            Base.PickupDropModel.Info.Rotation = new LowPrecisionQuaternion(rotation);
            Base.PickupDropModel.NetworkInfo = Base.PickupDropModel.Info;

            ItemPickupBase ipb = Object.Instantiate(Base.PickupDropModel, position, rotation);
            if (ipb is FirearmPickup firearmPickup)
            {
                if (this is Gun gun)
                {
                    firearmPickup.Status = new FirearmStatus(gun.Ammo, FirearmStatusFlags.MagazineInserted, firearmPickup.Status.Attachments);
                }
                else
                {
                    byte ammo = Base switch
                    {
                        AutomaticFirearm auto => auto._baseMaxAmmo,
                        Shotgun shotgun => shotgun._ammoCapacity,
                        Revolver _ => 6,
                        _ => 0,
                    };
                    firearmPickup.Status = new FirearmStatus(ammo, FirearmStatusFlags.MagazineInserted, firearmPickup.Status.Attachments);
                }

                firearmPickup.NetworkStatus = firearmPickup.Status;
            }

            NetworkServer.Spawn(ipb.gameObject);
            ipb.InfoReceived(default, Base.PickupDropModel.NetworkInfo);
            Pickup pickup = Pickup.Get(ipb);
            pickup.Scale = Scale;
            return pickup;
        }
    }
}