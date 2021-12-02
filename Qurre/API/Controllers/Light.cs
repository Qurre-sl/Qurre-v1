namespace Qurre.API.Controllers
{
    public class Light
    {
        public Light(global::UnityEngine.Vector3 position, global::UnityEngine.Color lightColor = null, float lightIntensivity = 1, float lightRange = 10);

        public global::UnityEngine.Vector3 Position { get; set; }
        public global::UnityEngine.Vector3 Scale { get; set; }
        public global::UnityEngine.Quaternion Rotation { get; set; }
        public global::UnityEngine.Color Color { get; set; }
        public float Intensivity { get; set; }
        public float Range { get; set; }
        public bool EnableShadows { get; set; }
        public global::AdminToys.LightSourceToy Base { get; }

        public void Destroy();
    }
}