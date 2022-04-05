using UnityEngine;
using System;
using Mirror;
using Object = UnityEngine.Object;
using InventorySystem.Items;
using InventorySystem.Items.Pickups;
namespace Qurre.API.Addons.Models
{
    public class ModelPickup
    {
        public readonly GameObject GameObject;
        public readonly ItemPickupBase Pickup;

        public ModelPickup(Model model, ItemType type, Vector3 position, Vector3 rotation, Vector3 size = default, bool kinematic = true)
        {
            try
            {
                var item = Server.InventoryHost.CreateItemInstance(type, false);
                ushort ser = ItemSerialGenerator.GenerateNext();
                item.PickupDropModel.Info.Serial = ser;
                item.PickupDropModel.Info.ItemId = type;
                item.PickupDropModel.Info.Position = model.GameObject.transform.position + position;
                item.PickupDropModel.Info.Weight = item.Weight;
                item.PickupDropModel.Info.Rotation = new LowPrecisionQuaternion(Quaternion.Euler(model.GameObject.transform.rotation.eulerAngles + rotation));
                item.PickupDropModel.NetworkInfo = item.PickupDropModel.Info;
                ItemPickupBase ipb = Object.Instantiate(item.PickupDropModel);
                var gameObject = ipb.gameObject;
                gameObject.GetComponent<Rigidbody>().isKinematic = kinematic;
                gameObject.transform.parent = model.GameObject.transform;
                gameObject.transform.localPosition = position;
                gameObject.transform.localRotation = Quaternion.Euler(rotation);
                gameObject.transform.localScale = size;
                NetworkServer.Spawn(gameObject);
                ipb.InfoReceived(default, item.PickupDropModel.NetworkInfo);
                Pickup = ipb;
            }
            catch (Exception ex)
            {
                Log.Warn($"{ex}\n{ex.StackTrace}");
            }
        }
    }
}