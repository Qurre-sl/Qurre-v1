using Qurre.API.Controllers;
namespace Qurre.API.Addons.Textures
{
    public class ModelPrimitive
    {
        public readonly global::UnityEngine.GameObject GameObject;
        public readonly Primitive Primitive;

        public ModelPrimitive(Model model, global::UnityEngine.PrimitiveType primitiveType, global::UnityEngine.Color color, global::UnityEngine.Vector3 position, global::UnityEngine.Vector3 rotation, global::UnityEngine.Vector3 size = null);
    }
}