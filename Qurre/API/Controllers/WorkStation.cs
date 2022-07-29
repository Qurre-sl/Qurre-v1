using InventorySystem.Items.Firearms.Attachments;
using Mirror;
using Mirror.LiteNetLib4Mirror;
using Qurre.API.Objects;
using UnityEngine;
namespace Qurre.API.Controllers
{
    public class WorkStation
    {
        internal readonly WorkstationController workStation;
        internal WorkStation(WorkstationController station)
        {
            workStation = station;
        }
        public WorkStation(Vector3 position, Vector3 rotation, Vector3 scale)
        {
            workStation = Object.Instantiate(Addons.Prefabs.WorkStation, position, Quaternion.Euler(rotation));
            var bench = workStation.gameObject;
            bench.transform.localScale = scale;
            NetworkServer.Spawn(bench);
            Map.WorkStations.Add(this);
        }
        public GameObject GameObject => workStation.gameObject;
        public Transform Transform => GameObject.transform;
        public string Name => GameObject.name;
        public Vector3 Position
        {
            get => Transform.position;
            set
            {
                NetworkServer.UnSpawn(GameObject);
                Transform.position = value;
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
                NetworkServer.Spawn(GameObject);
            }
        }
        public Quaternion Rotation
        {
            get => Transform.rotation;
            set
            {
                NetworkServer.UnSpawn(GameObject);
                Transform.rotation = value;
                NetworkServer.Spawn(GameObject);
            }
        }
        public Player KnownUser
        {
            get => Player.Get(workStation._knownUser);
            set => workStation._knownUser = value.ReferenceHub;
        }
        public WorkstationStatus Status
        {
            get => (WorkstationStatus)workStation.Status;
            set => workStation.NetworkStatus = (byte)value;
        }
        public bool Activated
        {
            get => Status == WorkstationStatus.Online;
            set => Status = value ? WorkstationStatus.Online : WorkstationStatus.Offline;
        }
        public static WorkStation Create(Vector3 position, Vector3 rotation, Vector3 scale) => new(position, rotation, scale);
    }
}