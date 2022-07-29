using MapGeneration;
using Mirror;
using Qurre.API.Objects;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Guid = System.Guid;
namespace Qurre.API.Controllers
{
    public class Room
    {
        internal Room(RoomIdentifier identifier)
        {
            Identifier = identifier;
            if (Identifier == null) return;
            RoomName = Identifier.Name;
            Shape = Identifier.Shape;
            GameObject = identifier.gameObject;
            Id = Identifier.UniqueId;

            LightController = GameObject.GetComponentInChildren<FlickerableLightController>();

            foreach (var cam in GameObject.GetComponentsInChildren<Camera079>())
                Cameras.Add(new Camera(cam, this));

            NetworkIdentity = GetNetworkIdentity(Identifier.Name);
        }
        internal FlickerableLightController LightController { get; set; }
        public void LightsOff(float duration) => LightController.ServerFlickerLights(duration);
        public float LightIntensity
        {
            get => LightController.LightIntensityMultiplier;
            set => LightController.UpdateLightsIntensity(LightController.LightIntensityMultiplier, value);
        }
        public Color LightColor
        {
            get => LightController.Network_warheadLightColor;
            set
            {
                LightController.Network_warheadLightColor = value;
                LightOverride = true;
            }
        }
        public bool LightOverride
        {
            get => LightController.WarheadLightOverride;
            set => LightController.WarheadLightOverride = value;
        }
        public GameObject GameObject { get; }
        public RoomIdentifier Identifier { get; }
#nullable enable
        public NetworkIdentity? NetworkIdentity { get; }
#nullable restore
        public Transform Transform => GameObject.transform;
        public Vector3 Position
        {
            get => Transform.position;
            set
            {
                if (NetworkIdentity is null) return;
                NetworkIdentity.transform.position = value;
                NetworkIdentity.UpdateData();
            }
        }
        public Quaternion Rotation
        {
            get => Transform.rotation;
            set
            {
                if (NetworkIdentity is null) return;
                NetworkIdentity.transform.rotation = value;
                NetworkIdentity.UpdateData();
            }
        }
        public Vector3 Scale
        {
            get => Transform.localScale;
            set
            {
                if (NetworkIdentity is null) return;
                NetworkIdentity.transform.localScale = value;
                NetworkIdentity.UpdateData();
            }
        }
        public string Name => GameObject.name;
        public List<Door> Doors { get; } = new List<Door>();
        public List<Camera> Cameras { get; } = new List<Camera>();
        public List<Player> Players => Player.List.Where(x => !x.IsHost && x.Room.Name == Name).ToList();
        public ZoneType Zone
        {
            get
            {
                if (zone != ZoneType.Unspecified)
                    return zone;
                zone = ZoneType.Unspecified;
                if (Position.y >= 0f && Position.y < 500f)
                    zone = ZoneType.Light;
                else if (Name.Contains("EZ") || Name.Contains("INTERCOM"))
                    zone = ZoneType.Office;
                else if (Position.y < -100 && Position.y > -1015f)
                    zone = ZoneType.Heavy;
                else if (Position.y >= 5)
                    zone = ZoneType.Surface;
                return zone;
            }
        }
        public RoomName RoomName { get; }
        public RoomShape Shape { get; }
        private ZoneType zone = ZoneType.Unspecified;
        public int Id { get; }
        public bool LightsDisabled => LightController && !LightController.NetworkLightsEnabled;
#nullable enable
        public Tesla? Tesla => GameObject.GetComponentInChildren<TeslaGate>()?.GetTesla();
#nullable restore
        public RoomType Type
        {
            get
            {
                var rawName = Name;
                var bracketStart = rawName.IndexOf('(') - 1;
                if (bracketStart > 0) rawName = rawName.Remove(bracketStart, rawName.Length - bracketStart);
                return rawName switch
                {
                    "LCZ_Armory" => RoomType.LczArmory,
                    "LCZ_Curve" => RoomType.LczCurve,
                    "LCZ_Straight" => RoomType.LczStraight,
                    "LCZ_330" => RoomType.Lcz330,
                    "LCZ_914" => RoomType.Lcz914,
                    "LCZ_Crossing" => RoomType.LczCrossing,
                    "LCZ_TCross" => RoomType.LczTCross,
                    "LCZ_Cafe" => RoomType.LczCafe,
                    "LCZ_Plants" => RoomType.LczPlants,
                    "LCZ_Toilets" => RoomType.LczToilets,
                    "LCZ_Airlock" => RoomType.LczAirlock,
                    "LCZ_173" => RoomType.Lcz173,
                    "LCZ_ClassDSpawn" => RoomType.LczClassDSpawn,
                    "LCZ_ChkpB" => RoomType.LczChkpB,
                    "LCZ_372" => RoomType.LczGr18,
                    "LCZ_ChkpA" => RoomType.LczChkpA,
                    "HCZ_079" => RoomType.Hcz079,
                    "HCZ_EZ_Checkpoint" => RoomType.HczEzCheckpoint,
                    "HCZ_Room3ar" => RoomType.HczArmory,
                    "HCZ_Testroom" => RoomType.Hcz939,
                    "HCZ_Hid" => RoomType.HczHid,
                    "HCZ_049" => RoomType.Hcz049,
                    "HCZ_ChkpA" => RoomType.HczChkpA,
                    "HCZ_Crossing" => RoomType.HczCrossing,
                    "HCZ_Straight" => RoomType.HczStraight,
                    "HCZ_106" => RoomType.Hcz106,
                    "HCZ_Nuke" => RoomType.HczNuke,
                    "HCZ_Tesla" => RoomType.HczTesla,
                    "HCZ_Servers" => RoomType.HczServers,
                    "HCZ_ChkpB" => RoomType.HczChkpB,
                    "HCZ_Room3" => RoomType.HczTCross,
                    "HCZ_457" => RoomType.Hcz096,
                    "HCZ_Curve" => RoomType.HczCurve,
                    "EZ_Endoof" => RoomType.EzVent,
                    "EZ_Intercom" => RoomType.EzIntercom,
                    "EZ_GateA" => RoomType.EzGateA,
                    "EZ_PCs_small" => RoomType.EzDownstairsPcs,
                    "EZ_Curve" => RoomType.EzCurve,
                    "EZ_PCs" => RoomType.EzPcs,
                    "EZ_Crossing" => RoomType.EzCrossing,
                    "EZ_ThreeWay" => RoomType.EzThreeWay,
                    "EZ_CollapsedTunnel" => RoomType.EzCollapsedTunnel,
                    "EZ_Smallrooms2" => RoomType.EzConference,
                    "EZ_Straight" => RoomType.EzStraight,
                    "EZ_Cafeteria" => RoomType.EzCafeteria,
                    "EZ_upstairs" => RoomType.EzUpstairsPcs,
                    "EZ_GateB" => RoomType.EzGateB,
                    "EZ_Shelter" => RoomType.EzShelter,
                    "PocketWorld" => RoomType.Pocket,
                    "Outside" => RoomType.Surface,
                    _ => RoomType.Unknown,
                };
            }
        }
        internal static readonly List<NetworkIdentity> NetworkIdentities = new();
        private static NetworkIdentity GetNetworkIdentity(RoomName room)
        {
            if (NetworkIdentities.Count == 0)
                NetworkIdentities.AddRange(Object.FindObjectsOfType<NetworkIdentity>().Where(x => x.name.Contains("All")));
            return room switch
            {
                MapGeneration.RoomName.Lcz330 => NetworkIdentities.FirstOrDefault(x => x.assetId == new Guid("17f38aa5-1bc8-8bc4-0ad1-fffcbe4214ae")),
                MapGeneration.RoomName.Hcz939 => NetworkIdentities.FirstOrDefault(x => x.assetId == new Guid("d1566564-d477-24c4-c953-c619898e4751")),
                MapGeneration.RoomName.Hcz106 => NetworkIdentities.FirstOrDefault(x => x.assetId == new Guid("c1ae9ee4-cc8e-0794-3b2c-358aa6e57565")),
                _ => null,
            };
        }
        /*
        private NetworkIdentity GetNetworkIdentity()
        {
            if (NetworkIdentities.Count == 0)
                NetworkIdentities.AddRange(Object.FindObjectsOfType<NetworkIdentity>().Where(x => x.name.Contains("All")));
            return NetworkIdentities.FirstOrDefault(x => Vector3.Distance(x.transform.position, Position) < 0.1f);
        }
        */
    }
}