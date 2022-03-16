using AdminToys;
using UnityEngine;
using Mirror;
using System;
using System.Linq;
namespace Qurre.API.Controllers
{
    public class Light
    {
        public Light(Vector3 position, Color lightColor = default, float lightIntensivity = 1, float lightRange = 10, bool shadows = true)
        {
            try
            {
                var mod = Addons.Prefabs.Light;
                if (!mod.TryGetComponent<LightSourceToy>(out var lightToyBase)) return;
                Base = UnityEngine.Object.Instantiate(lightToyBase);
                Base.transform.position = position;
                Base.transform.localScale = Vector3.one;
                NetworkServer.Spawn(Base.gameObject);
                if (lightColor == default) lightColor = Color.white;
                if (lightColor.r < 0.1f && lightColor.g < 0.1f && lightColor.b < 0.1f)
                    lightColor = Color.white;
                Color = lightColor;
                Intensivity = lightIntensivity;
                Range = lightRange;
                EnableShadows = shadows;
                Map.Lights.Add(this);
            }
            catch (Exception e)
            {
                Log.Error($"{e}\n{e.StackTrace}");
            }
        }
        public Vector3 Position
        {
            get => Base.transform.position;
            set
            {
                NetworkServer.UnSpawn(Base.gameObject);
                Base.transform.position = value;
                NetworkServer.Spawn(Base.gameObject);
            }
        }
        public Vector3 Scale
        {
            get => Base.transform.localScale;
            set
            {
                NetworkServer.UnSpawn(Base.gameObject);
                Base.transform.localScale = value;
                NetworkServer.Spawn(Base.gameObject);
            }
        }
        public Quaternion Rotation
        {
            get => Base.transform.localRotation;
            set
            {
                NetworkServer.UnSpawn(Base.gameObject);
                Base.transform.localRotation = value;
                NetworkServer.Spawn(Base.gameObject);
            }
        }
        public Color Color
        {
            get => Base.LightColor;
            set => Base.NetworkLightColor = value;
        }
        public float Intensivity
        {
            get => Base.LightIntensity;
            set => Base.NetworkLightIntensity = value;
        }
        public float Range
        {
            get => Base.LightRange;
            set => Base.NetworkLightRange = value;
        }
        public bool EnableShadows
        {
            get => Base.LightShadows;
            set => Base.NetworkLightShadows = value;
        }
        public void Destroy()
        {
            NetworkServer.Destroy(Base.gameObject);
            Map.Lights.Remove(this);
        }
        public LightSourceToy Base { get; }
    }
}