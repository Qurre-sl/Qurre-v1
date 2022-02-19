using UnityEngine;
using System;
using Light = Qurre.API.Controllers.Light;
namespace Qurre.API.Addons.Textures
{
    public class ModelLight
    {
        public readonly GameObject GameObject;
        public readonly Light Light;

        public ModelLight(Model model, Color color, Vector3 position, float lightIntensivity = 1, float lightRange = 10, bool shadows = true)
        {
            try
            {
                Light = new Light(position, color, lightIntensivity, lightRange, shadows);
                GameObject = Light.Base.gameObject;
                GameObject.transform.parent = model?.gameObject?.transform;
                GameObject.transform.localPosition = position;
            }
            catch (Exception ex)
            {
                Log.Warn($"{ex}\n{ex.StackTrace}");
            }
        }
    }
}