using Mirror;
using System.Collections.Generic;
using UnityEngine;
namespace Qurre.API.Controllers
{
    public class Tesla
    {
        private readonly TeslaGate Gate;
        internal Tesla(TeslaGate gate) => Gate = gate;
        public GameObject GameObject => Gate.gameObject;
        public Transform Transform => GameObject.transform;
        private string name;
        public string Name
        {
            get
            {
                if (string.IsNullOrEmpty(name)) return GameObject.name;
                return name;
            }
            set => name = value;
        }
        public Vector3 Position
        {
            get => Transform.position;
            [System.Obsolete("Works every other time. Tesla moves successfully on the server. On the client, Tesla moves for about 10ms and then comes back.")]
            set
            {
                Gate.localPosition = value;
                NetworkServer.UnSpawn(GameObject);
                Gate.localPosition = value;
                Transform.localPosition = value;
                Transform.position = value;
                Gate.localPosition = value;
                Gate.transform.localPosition = value;
                Gate.transform.position = value;
                Gate.gameObject.transform.localPosition = value;
                Gate.gameObject.transform.position = value;
                NetworkServer.Spawn(GameObject);/*
                NetworkServer.UnSpawn(Gate.transform.gameObject);
                Gate.localPosition = value;
                Gate.transform.localPosition = value;
                Gate.transform.position = value;
                Gate.localPosition = value;
                NetworkServer.Spawn(Gate.transform.gameObject);*/
                Gate.localPosition = value;
            }
        }
        public Quaternion Rotation
        {
            get => Transform.localRotation;
            [System.Obsolete("Works every other time. Tesla moves successfully on the server. On the client, Tesla moves for about 10ms and then comes back.")]
            set
            {
                NetworkServer.UnSpawn(GameObject);
                Transform.localRotation = value;
                Gate.localRotation = value.eulerAngles;
                NetworkServer.Spawn(GameObject);
            }
        }
        public Vector3 Scale
        {
            get => Transform.localScale;
            set
            {
                NetworkServer.UnSpawn(GameObject);
                Transform.localScale = value;
                SizeOfKiller = value;
                NetworkServer.Spawn(GameObject);
            }
        }
        public Vector3 SizeOfKiller { get => Gate.sizeOfKiller; set => Gate.sizeOfKiller = value; }
        public bool InProgress { get => Gate.InProgress; set => Gate.InProgress = value; }
        public float SizeOfTrigger { get => Gate.sizeOfTrigger; set => Gate.sizeOfTrigger = value; }
        public bool Enable { get; set; } = true;
        public bool Allow079Interact { get; set; } = true;
        public readonly List<RoleType> ImmunityRoles = new();
        public readonly List<Player> ImmunityPlayers = new();
        public void Trigger(bool instant = false)
        {
            if (instant) Gate.RpcInstantBurst();
            else Gate.RpcPlayAnimation();
        }
        public void Destroy() => Object.Destroy(Gate.gameObject);
    }
}