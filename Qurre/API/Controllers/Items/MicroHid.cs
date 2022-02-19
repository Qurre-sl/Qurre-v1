using InventorySystem.Items.MicroHID;
namespace Qurre.API.Controllers.Items
{
    public class MicroHid : Item
    {
        public MicroHid(MicroHIDItem itemBase)
            : base(itemBase)
        {
            Base = itemBase;
        }
        public MicroHid(ItemType type)
            : this((MicroHIDItem)Server.Host.Inventory.CreateItemInstance(type, false))
        {
        }
        public float Energy
        {
            get => Base.RemainingEnergy;
            set => Base.RemainingEnergy = value;
        }
        public new MicroHIDItem Base { get; }
        public HidState State
        {
            get => Base.State;
            set => Base.State = value;
        }
        public void Fire()
        {
            Base.UserInput = HidUserInput.Fire;
            State = HidState.Firing;
        }
    }
}