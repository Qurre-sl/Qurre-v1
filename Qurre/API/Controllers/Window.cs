using Footprinting;
using Mirror;
using UnityEngine;
namespace Qurre.API.Controllers
{
    public class Window
    {
        internal Window(BreakableWindow window) => bw = window;
        private readonly BreakableWindow bw;
        public BreakableWindow Breakable => bw;
        private string name;
        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(name)) name = "Window";
                return name;
            }
            set => name = value;
        }
        public GameObject GameObject => bw.gameObject;
        public Transform Transform => bw.transform;
        public bool AllowBreak { get; set; } = true;
        public Vector3 Position
        {
            get => Status.position;
            set
            {
                var __ = Status;
                __.position = value;
                Status = __;
                NetworkServer.UnSpawn(GameObject);
                bw.parent.position = value;
                Transform.position = value;
                bw.template.transform.position = value;
                GameObject.transform.position = value;
                NetworkServer.Spawn(GameObject);
            }
        }
        public Quaternion Rotation
        {
            get => Status.rotation;
            set
            {
                var __ = Status;
                __.rotation = value;
                Status = __;
                NetworkServer.UnSpawn(GameObject);
                bw.parent.rotation = value;
                Transform.rotation = value;
                bw.template.transform.rotation = value;
                GameObject.transform.rotation = value;
                NetworkServer.Spawn(GameObject);
            }
        }
        public Vector3 Scale
        {
            get => Transform.localScale;
            set
            {
                NetworkServer.UnSpawn(GameObject);
                bw.parent.localScale = value;
                Transform.localScale = value;
                bw.template.transform.localScale = value;
                GameObject.transform.localScale = value;
                bw.size = value;
                NetworkServer.Spawn(GameObject);
            }
        }
        public Vector3 Size => bw.size;
        public Footprint LastAttacker => bw.LastAttacker;
        public bool Destroyed => bw.isBroken;
        public float Hp
        {
            get => bw.health;
            set => bw.health = value;
        }
        public BreakableWindow.BreakableWindowStatus Status
        {
            get => bw.NetworksyncStatus;
            set => bw.UpdateStatus(value);
        }
    }
}