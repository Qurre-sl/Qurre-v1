namespace Qurre.API.Controllers.Items
{
    public class Armor : Item
    {
        public Armor(global::InventorySystem.Items.Armor.BodyArmor itemBase);
        public Armor(ItemType type);

        public global::InventorySystem.Items.Armor.BodyArmor Base { get; }
        public bool Equippable { get; }
        public bool Holsterable { get; }
        public bool Worn { get; }
        public float Weight { get; set; }
        public bool RemoveExcessOnDrop { get; set; }
        public int HelmetEfficacy { get; set; }
        public int VestEfficacy { get; set; }
        public float StaminaUseMultiplier { get; set; }
        public float MovementSpeedMultiplier { get; set; }
        public float CivilianDownsideMultiplier { get; set; }
        public System.Collections.Generic.List<global::InventorySystem.Items.Armor.BodyArmor.ArmorAmmoLimit> AmmoLimits { get; set; }
    }
}