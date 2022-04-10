using Qurre.API.Controllers;
using UnityEngine;
using System;
namespace Qurre.API.Addons.Models
{
    public class ModelPrimitive
    {
        public readonly GameObject GameObject;
        public readonly Primitive Primitive;

        public ModelPrimitive(Model model, PrimitiveType primitiveType, Color color, Vector3 position, Vector3 rotation, Vector3 size = default, bool collider = true, bool _static = false)
        {
            try
            {
                Primitive = new(primitiveType, position, color);
                GameObject = Primitive.Base.gameObject;
                GameObject.transform.parent = model?.GameObject?.transform;
                GameObject.transform.localPosition = position;
                GameObject.transform.localRotation = Quaternion.Euler(rotation);
                GameObject.transform.localScale = size;
                Primitive.Collider = collider;
                if (_static)
                {
                    Primitive.Position = GameObject.transform.position;
                    Primitive.Rotation = GameObject.transform.rotation;
                    Primitive.Scale = GameObject.transform.localScale;
                    MEC.Timing.CallDelayed(0.2f, () => Primitive.Break());
                }
            }
            catch (Exception ex)
            {
                Log.Warn($"{ex}\n{ex.StackTrace}");
            }
        }
    }
}