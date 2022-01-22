using Qurre.API.Controllers;
namespace Qurre.API.Addons.Textures
{
    public class ModelLight
    {
        public readonly global::UnityEngine.GameObject GameObject;
        public readonly Light Light;

        public ModelLight(Model model, global::UnityEngine.Color color, global::UnityEngine.Vector3 position, float lightIntensivity = 1, float lightRange = 10);
    }
}