using Qurre.API.Controllers;
using UnityEngine;
using System;
using Mirror;
namespace Qurre.API.Addons.Models
{
    public class ModelGenerator
    {
        public readonly GameObject GameObject;
        public readonly Generator Generator;

        public ModelGenerator(Model model, Vector3 position, Vector3 rotation, Vector3 size = default)
        {
            try
            {
                Generator = Generator.Create(position);
                GameObject = Generator.GameObject;
                NetworkServer.UnSpawn(GameObject);
                GameObject.transform.parent = model?.GameObject?.transform;
                GameObject.transform.localPosition = position;
                GameObject.transform.localRotation = Quaternion.Euler(rotation);
                GameObject.transform.localScale = size;
                NetworkServer.Spawn(GameObject);
            }
            catch (Exception ex)
            {
                Log.Warn($"{ex}\n{ex.StackTrace}");
            }
        }
    }
}