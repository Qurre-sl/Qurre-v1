using Qurre.API.Controllers;
using UnityEngine;
using System;
namespace Qurre.API.Addons.Textures
{
    public class ModelPrimitive
    {
        public readonly GameObject GameObject;
        public readonly Primitive Primitive;

        public ModelPrimitive(Model model, PrimitiveType primitiveType, Color color, Vector3 position, Vector3 rotation, Vector3 size = default, bool collider = true)
        {
            try
            {
                Primitive = new Primitive(primitiveType, position, color);
                GameObject = Primitive.Base.gameObject;
                GameObject.transform.parent = model?.gameObject?.transform;
                GameObject.transform.localPosition = position;
                GameObject.transform.localRotation = Quaternion.Euler(rotation);
                GameObject.transform.localScale = size;
                Primitive.Collider = collider;
            }
            catch (Exception ex)
            {
                Log.Warn($"{ex}\n{ex.StackTrace}");
            }
        }
    }
}