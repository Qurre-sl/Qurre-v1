using InventorySystem.Items.Radio;
using Qurre.API.Objects;
namespace Qurre.API.Controllers.Items
{
    public class Radio : Item
    {
        public Radio(RadioItem itemBase) : base(itemBase) => Base = itemBase;
        public Radio(ItemType type) : this((RadioItem)Server.Host.Inventory.CreateItemInstance(type, false)) { }
        public new RadioItem Base { get; }
        public byte Battery
        {
            get => Base.BatteryPercent;
            set => Base.BatteryPercent = value;
        }
        public RadioStatus Status
        {
            get => (RadioStatus)Base.CurRange;
            set => Base.CurRange = (int)value;
        }
        public RadioStatusSettings StatusSettings
        {
            get =>
                new()
                {
                    IdleUsage = Base.Ranges[(int)Status].MinuteCostWhenIdle,
                    TalkingUsage = Base.Ranges[(int)Status].MinuteCostWhenTalking,
                    MaxRange = Base.Ranges[(int)Status].MaximumRange,
                };
            set =>
                Base.Ranges[(int)Status] = new()
                {
                    MaximumRange = value.MaxRange,
                    MinuteCostWhenIdle = value.IdleUsage,
                    MinuteCostWhenTalking = value.TalkingUsage,
                };
        }
        public void Disable() => Base._radio.ForceDisableRadio();
    }
}