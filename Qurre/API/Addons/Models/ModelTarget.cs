using Qurre.API.Controllers;
using UnityEngine;
using System;
using Qurre.API.Objects;
namespace Qurre.API.Addons.Models
{
    public class ModelTarget
    {
        public readonly GameObject GameObject;
        public readonly ShootingTarget Target;

        public ModelTarget(Model model, TargetPrefabs prefab, Vector3 position, Vector3 rotation, Vector3 size)
        {
            try
            {
                Target = new(prefab, position);
                GameObject = Target.Base.gameObject;
                GameObject.transform.parent = model?.GameObject?.transform;
                GameObject.transform.localPosition = position;
                GameObject.transform.localRotation = Quaternion.Euler(rotation);
                GameObject.transform.localScale = size;
            }
            catch (Exception ex)
            {
                Log.Warn($"{ex}\n{ex.StackTrace}");
            }
        }
    }
}