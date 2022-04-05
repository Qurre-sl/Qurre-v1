using UnityEngine;
using System;
using Mirror;
using Qurre.API.Controllers;
namespace Qurre.API.Addons.Models
{
    public class ModelBot
    {
        public readonly GameObject GameObject;
        public readonly Bot Bot;

        public ModelBot(Model model, RoleType type, Vector3 position, Vector3 rotation, Vector3 size = default, string name = "(null)", string role_text = "", string role_color = "")
        {
            try
            {
                Bot = Bot.Create(position, Quaternion.Euler(rotation), type, name, role_text, role_color);
                GameObject = Bot.GameObject;
                NetworkServer.UnSpawn(GameObject);
                GameObject.transform.parent = model?.GameObject?.transform;
                GameObject.transform.localPosition = position;
                GameObject.transform.localRotation = Quaternion.Euler(rotation);
                GameObject.transform.localScale = size;
                NetworkServer.Spawn(GameObject);
                Bot.Position = GameObject.transform.position;
                Bot.Rotation = GameObject.transform.rotation.eulerAngles;
                Bot.Scale = GameObject.transform.localScale;
            }
            catch (Exception ex)
            {
                Log.Warn($"{ex}\n{ex.StackTrace}");
            }
        }
    }
}