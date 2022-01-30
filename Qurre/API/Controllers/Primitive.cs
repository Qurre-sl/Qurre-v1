namespace Qurre.API.Controllers
{
    public class Primitive
    {
        public Primitive(PrimitiveType type);
        public Primitive(global::UnityEngine.PrimitiveType type, global::UnityEngine.Vector3 position, global::UnityEngine.Color color = null, global::UnityEngine.Quaternion rotation = null, global::UnityEngine.Vector3 size = null);

        public global::UnityEngine.Vector3 Position { get; set; }
        public global::UnityEngine.Vector3 Scale { get; set; }
        public global::UnityEngine.Quaternion Rotation { get; set; }
        public global::UnityEngine.Color Color { get; set; }
        public global::UnityEngine.PrimitiveType Type { get; set; }
        public global::AdminToys.PrimitiveObjectToy Base { get; }

        public void Destroy();
    }
}