using Qurre.API.Controllers;
using Qurre.API.Objects;
using UnityEngine;
using System;
using Interactables.Interobjects.DoorUtils;
using Mirror;
namespace Qurre.API.Addons.Models
{
    public class ModelDoor
    {
        public readonly GameObject GameObject;
        public readonly Door Door;

        public ModelDoor(Model model, DoorPrefabs type, Vector3 position, Vector3 rotation, Vector3 size = default, DoorPermissions permissions = null)
        {
            try
            {
                Door = Door.Spawn(position, type, permissions: permissions);
                GameObject = Door.GameObject;
                NetworkServer.UnSpawn(GameObject);
                GameObject.transform.parent = model?.GameObject?.transform;
                GameObject.transform.localPosition = position;
                GameObject.transform.localRotation = Quaternion.Euler(rotation);
                GameObject.transform.localScale = size;
                NetworkServer.Spawn(GameObject);
                Door.DoorVariant.netIdentity.UpdateData();
            }
            catch (Exception ex)
            {
                Log.Warn($"{ex}\n{ex.StackTrace}");
            }
        }
    }
}