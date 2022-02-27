using InventorySystem.Items.Armor;
using NorthwoodLib.Pools;
using System.Collections.Generic;
using static InventorySystem.Items.Armor.BodyArmor;
namespace Qurre.API.Controllers.Items
{
    public class Armor : Item
    {
        public Armor(BodyArmor itemBase) : base(itemBase) => Base = itemBase;
        public Armor(ItemType type) : this((BodyArmor)Server.Host.Inventory.CreateItemInstance(type, false)) { }
        public new BodyArmor Base { get; }
        public bool Equippable => Base.AllowEquip;
        public bool Holsterable => Base.AllowHolster;
        public bool Worn => Base.IsWorn;
        public new float Weight
        {
            get => Base.Weight;
            set => Base._weight = value;
        }
        public bool RemoveExcessOnDrop
        {
            get => !Base.DontRemoveExcessOnDrop;
            set => Base.DontRemoveExcessOnDrop = !value;
        }
        public int HelmetEfficacy
        {
            get => Base.HelmetEfficacy;
            set
            {
                if (value > 100) value = 100;
                if (value < 0) value = 0;
                Base.HelmetEfficacy = value;
            }
        }
        public int VestEfficacy
        {
            get => Base.VestEfficacy;
            set
            {
                if (value > 100) value = 100;
                if (value < 0) value = 0;
                Base.VestEfficacy = value;
            }
        }
        public float StaminaUseMultiplier
        {
            get => Base.StaminaUseMultiplier;
            set
            {
                if (value > 2) value = 2;
                if (value < 1) value = 1;
                Base.StaminaUseMultiplier = value;
            }
        }
        public float MovementSpeedMultiplier
        {
            get => Base.MovementSpeedMultiplier;
            set
            {
                if (value > 1) value = 1;
                if (value < 0) value = 0;
                Base.MovementSpeedMultiplier = value;
            }
        }
        public float CivilianDownsideMultiplier
        {
            get => Base.CivilianClassDownsidesMultiplier;
            set => Base.CivilianClassDownsidesMultiplier = value;
        }
        public List<ArmorAmmoLimit> AmmoLimits
        {
            get
            {
                List<ArmorAmmoLimit> limits = new();
                for (int i = 0; i < Base.AmmoLimits.Length; i++)
                {
                    var _ = new ArmorAmmoLimit() { AmmoType = Base.AmmoLimits[i].AmmoType, Limit = Base.AmmoLimits[i].Limit };
                    limits.Add(_);
                }

                return limits;
            }

            set
            {
                List<ArmorAmmoLimit> limits = ListPool<ArmorAmmoLimit>.Shared.Rent();
                for (int i = 0; i < value.Count; i++)
                {
                    ArmorAmmoLimit limit = value[i];
                    limits.Add(new ArmorAmmoLimit
                    {
                        AmmoType = limit.AmmoType,
                        Limit = limit.Limit,
                    });
                }

                Base.AmmoLimits = limits.ToArray();
                ListPool<ArmorAmmoLimit>.Shared.Return(limits);
            }
        }
    }
}