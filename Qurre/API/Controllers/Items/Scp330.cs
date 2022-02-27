using InventorySystem.Items.Usables.Scp330;
using Mirror;
using System.Collections.Generic;
using UnityEngine;
namespace Qurre.API.Controllers.Items
{
    public class Scp330 : Item
    {
        public Scp330(Scp330Bag itemBase) : base(itemBase) => Base = itemBase;
        public new Scp330Bag Base { get; }
        public IReadOnlyCollection<CandyKindID> Candies => Base.Candies.AsReadOnly();
        public bool Add(CandyKindID type)
        {
            if (Base.TryAddSpecific(type))
            {
                Base.ServerRefreshBag();
                return true;
            }
            return false;
        }
        public int Remove(CandyKindID type, bool all = false)
        {
            int amount = 0;
            while (Base.Candies.Contains(type))
            {
                Base.TryRemove(Base.Candies.IndexOf(type));
                amount++;
                if (!all) break;
            }
            return amount;
        }
        public Pickup Spawn(Vector3 position, Quaternion rotation = default, CandyKindID candyModel = CandyKindID.None)
        {
            Base.PickupDropModel.Info.ItemId = Type;
            Base.PickupDropModel.Info.Position = position;
            Base.PickupDropModel.Info.Weight = Weight;
            Base.PickupDropModel.Info.Rotation = new LowPrecisionQuaternion(rotation);
            Base.PickupDropModel.NetworkInfo = Base.PickupDropModel.Info;
            Scp330Pickup ipb = (Scp330Pickup)Object.Instantiate(Base.PickupDropModel, position, rotation);
            if (candyModel != CandyKindID.None) ipb.NetworkExposedCandy = candyModel;
            NetworkServer.Spawn(ipb.gameObject);
            ipb.InfoReceived(default, Base.PickupDropModel.NetworkInfo);
            Pickup pickup = Pickup.Get(ipb);
            pickup.Scale = Scale;
            return pickup;
        }
    }
}