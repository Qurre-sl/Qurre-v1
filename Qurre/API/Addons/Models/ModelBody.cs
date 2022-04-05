using UnityEngine;
using System;
using Mirror;
using RD = Qurre.API.Controllers.Ragdoll;
using PlayerStatsSystem;
namespace Qurre.API.Addons.Models
{
    public class ModelBody
    {
        public readonly GameObject GameObject;
        public readonly RD Body;

        public ModelBody(Model model, RoleType type, Vector3 position, Vector3 rotation, Vector3 size = default, DamageHandlerBase handler = null, string nickname = "")
        {
            try
            {
                if (handler is null) handler = new CustomReasonDamageHandler("yes");
                Body = RD.Create(type, position, Quaternion.Euler(rotation), handler, nickname, 0);
                GameObject = Body.GameObject;
                NetworkServer.UnSpawn(GameObject);
                GameObject.transform.parent = model?.GameObject?.transform;
                GameObject.transform.localPosition = position;
                GameObject.transform.localRotation = Quaternion.Euler(rotation);
                GameObject.transform.localScale = size;
                NetworkServer.Spawn(GameObject);
                var info = Body.ragdoll.Info;
                Body.ragdoll.NetworkInfo = new RagdollInfo(info.OwnerHub, info.Handler, GameObject.transform.position, GameObject.transform.rotation);
            }
            catch (Exception ex)
            {
                Log.Warn($"{ex}\n{ex.StackTrace}");
            }
        }
    }
}