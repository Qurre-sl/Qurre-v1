using InventorySystem;
using Mirror;
using Qurre.API.Objects;
using RemoteAdmin;
using System.Collections.Generic;
using UnityEngine;
namespace Qurre.API.Controllers
{
    public class Bot
    {
        private ItemType itemInHand;
        public GameObject GameObject { get; internal set; }
        public Player Player { get; internal set; }
        public RoleType Role
        {
            get => GameObject.GetComponent<CharacterClassManager>().CurClass;
            set
            {
                Despawn();
                GameObject.GetComponent<CharacterClassManager>().CurClass = value;
                Spawn();
            }
        }
        public string Name
        {
            get => Player.Nickname;
            set => Player.Nickname = value;
        }
        public Vector3 Position
        {
            get => Player.Position;
            set => Player.Position = value;
        }
        public Vector2 Rotation
        {
            get => Player.Rotation;
            set
            {
                Player.Rotation = value;
                Player.CameraTransform.rotation = Quaternion.Euler(new Vector3(value.x, value.y, 90f));
            }
        }
        public Vector3 Scale
        {
            get => Player.Scale;
            set => Player.Scale = value;
        }
        public ItemType ItemInHand
        {
            get => itemInHand;
            set
            {
                GameObject.GetComponent<Inventory>().NetworkCurItem = new InventorySystem.Items.ItemIdentifier(value, 0);
                itemInHand = value;
            }
        }
        public string RoleName
        {
            get => GameObject.GetComponent<ServerRoles>().MyText;
            set => GameObject.GetComponent<ServerRoles>().SetText(value);
        }
        public string RoleColor
        {
            get => GameObject.GetComponent<ServerRoles>().MyColor;
            set => GameObject.GetComponent<ServerRoles>().SetColor(value);
        }
        public PlayerMovementState Movement
        {
            get => Player.AnimationController.MoveState;
            set => Player.AnimationController.UserCode_CmdChangeSpeedState((byte)value);
        }
        public MovementDirection Direction { get; set; }
        public float SneakSpeed { get; set; } = 1.8f;
        public float WalkSpeed { get; set; }
        public float RunSpeed { get; set; }
        private IEnumerator<float> Update()
        {
            for (; ; )
            {
                yield return MEC.Timing.WaitForSeconds(0.1f);
                if (GameObject == null) yield break;
                if (Direction == MovementDirection.Stop) continue;
                var wall = false;
                var speed = 0f;
                switch (Movement)
                {
                    case PlayerMovementState.Sneaking:
                        speed = SneakSpeed;
                        break;
                    case PlayerMovementState.Sprinting:
                        speed = RunSpeed;
                        break;
                    case PlayerMovementState.Walking:
                        speed = WalkSpeed;
                        break;
                }
                switch (Direction)
                {
                    case MovementDirection.Forward:
                        var pos = Position + Player.CameraTransform.forward / 10 * speed;
                        if (!Physics.Linecast(Position, pos, Player.Movement.CollidableSurfaces))
                            Player.Movement.OverridePosition(pos, 0f, true);
                        else wall = true;
                        break;
                    case MovementDirection.BackWards:
                        pos = Position - Player.CameraTransform.forward / 10 * speed;
                        if (!Physics.Linecast(Position, pos, Player.Movement.CollidableSurfaces))
                            Player.Movement.OverridePosition(pos, 0f, true);
                        else wall = true;
                        break;
                    case MovementDirection.Right:
                        pos = Position + Quaternion.AngleAxis(90, Vector3.up) * Player.CameraTransform.forward / 10 * speed;
                        if (!Physics.Linecast(Position, pos, Player.Movement.CollidableSurfaces))
                            Player.Movement.OverridePosition(pos, 0f, true);
                        else wall = true;
                        break;
                    case MovementDirection.Left:
                        pos = Position - Quaternion.AngleAxis(90, Vector3.up) * Player.CameraTransform.forward / 10 * speed;
                        if (!Physics.Linecast(Position, pos, Player.Movement.CollidableSurfaces))
                            Player.Movement.OverridePosition(pos, 0f, true);
                        else wall = true;
                        break;
                }
                if (wall) Direction = MovementDirection.Stop;
            }
        }
        public Bot(Vector3 pos, Quaternion rot, RoleType role = RoleType.ClassD, string name = "(null)", string role_text = "", string role_color = "") :
            this(pos, new Vector2(rot.eulerAngles.x, rot.eulerAngles.y), role, name, role_text, role_color)
        { }
        public Bot(Vector3 pos, Vector2 rot, RoleType role = RoleType.ClassD, string name = "(null)", string role_text = "", string role_color = "")
        {
            if (!Round.BotSpawned) Patches.Controllers.Bot.Initialize();
            Round.BotSpawned = true;
            GameObject obj = Object.Instantiate(NetworkManager.singleton.playerPrefab);
            GameObject = obj;
            var rh = ReferenceHub.GetHub(GameObject);
            try { rh.Awake(); } catch { }
            Player = new Player(rh) { Bot = true };
            Player.Dictionary.Add(obj, Player);
            rh.transform.localScale = Vector3.one;
            rh.transform.position = pos;
            Player.Movement.RealModelPosition = pos;
            Rotation = rot;
            Player.QueryProcessor.NetworkPlayerId = QueryProcessor._idIterator;
            Player.QueryProcessor._ipAddress = Server.Ip;
            Player.ClassManager.CurClass = role;
            Player.MaxHp = Player.ClassManager.Classes.SafeGet((int)Player.Role).maxHP;
            Player.Hp = Player.MaxHp;
            Player.ReferenceHub.nicknameSync = Player.ReferenceHub.GetComponent<NicknameSync>();
            Player.Nickname = name;
            Player.RoleName = role_text;
            Player.RoleColor = role_color;
            Player.GodMode = true;
            Player.Movement.NetworkGrounded = true;
            RunSpeed = CharacterClassManager._staticClasses[(int)role].runSpeed;
            WalkSpeed = CharacterClassManager._staticClasses[(int)role].walkSpeed;
            Player.ClassManager.Scp106 = Player.ClassManager.GetComponent<Scp106PlayerScript>();
            Player.ClassManager.Awake();
            MEC.Timing.RunCoroutine(Update());
            NetworkServer.Spawn(GameObject);
            Map.Bots.Add(this);
        }
        public void RotateToPosition(Vector3 pos)
        {
            var rot = Quaternion.LookRotation((pos - GameObject.transform.position).normalized);
            Rotation = new Vector2(rot.eulerAngles.x, rot.eulerAngles.y);
        }
        public void Despawn()
        {
            NetworkServer.UnSpawn(GameObject);
            Map.Bots.Remove(this);
        }
        public void Spawn()
        {
            NetworkServer.Spawn(GameObject);
            Map.Bots.Add(this);
        }
        public void Destroy()
        {
            Object.Destroy(GameObject);
            Map.Bots.Remove(this);
        }
        public static Bot Create(Vector3 pos, Quaternion rot, RoleType role = RoleType.ClassD, string name = "(null)", string role_text = "", string role_color = "")
            => new(pos, rot, role, name, role_text, role_color);
        public static Bot Create(Vector3 pos, Vector2 rot, RoleType role = RoleType.ClassD, string name = "(null)", string role_text = "", string role_color = "")
            => new(pos, rot, role, name, role_text, role_color);
    }
}