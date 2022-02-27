using MEC;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Qurre.API.Controllers
{
    public class MapBroadcast
    {
        private string msg;
        private readonly List<Broadcast> broadcasts = new();
        public MapBroadcast(string message, ushort time, bool instant, bool adminBC)
        {
            msg = message;
            Time = time;
            Start();
            if (adminBC)
            {
                var list = Player.List.Where(x => PermissionsHandler.IsPermitted(x.Sender.Permissions, PlayerPermissions.AdminChat));
                foreach (Player pl in list)
                {
                    var bc = pl.Broadcast(message, time, instant);
                    broadcasts.Add(bc);
                }
            }
            else
            {
                foreach (Player pl in Player.List)
                {
                    var bc = pl.Broadcast(message, time, instant);
                    broadcasts.Add(bc);
                }
            }
        }
        public string Message
        {
            get => msg;
            set
            {
                if (value != msg)
                {
                    msg = value;
                    foreach (var bc in broadcasts) bc.Message = value;
                }
            }
        }
        public ushort Time { get; }
        public bool Active { get; private set; }
        public void Start()
        {
            if (Active) return;
            Active = true;
            Timing.CallDelayed(Time, () => End());
        }
        public void End()
        {
            if (!Active) return;
            Active = false;
            foreach (var bc in broadcasts) bc.End();
        }
    }
    public class Broadcast
    {
        private readonly Player pl;
        private string msg;
        public Broadcast(Player player, string message, ushort time)
        {
            Message = message;
            Time = time;
            pl = player;
        }
        public float DisplayTime { get; internal set; } = float.MinValue;
        public string Message
        {
            get => msg;
            set
            {
                if (value != msg)
                {
                    msg = value;
                    if (Active) Update();
                }
            }
        }
        public ushort Time { get; }
        public bool Active { get; private set; }
        public void Start()
        {
            if (pl.Broadcasts.FirstOrDefault() != this) return;
            if (Active) return;
            Active = true;
            DisplayTime = UnityEngine.Time.time;
            BC.BroadcastComponent.TargetAddElement(pl.Scp079PlayerScript.connectionToClient, Message, Time, global::Broadcast.BroadcastFlags.Normal);
            Timing.CallDelayed(Time, () => End());
        }
        public void Update()
        {
            var time = Time - (UnityEngine.Time.time - DisplayTime) + 1;
            BC.BroadcastComponent.TargetClearElements(pl.Scp079PlayerScript.connectionToClient);
            BC.BroadcastComponent.TargetAddElement(pl.Scp079PlayerScript.connectionToClient, Message, (ushort)time, global::Broadcast.BroadcastFlags.Normal);
        }
        public void End()
        {
            if (!Active) return;
            Active = false;
            pl.Broadcasts.Remove(this);
            BC.BroadcastComponent.TargetClearElements(pl.Scp079PlayerScript.connectionToClient);
            if (pl.Broadcasts.FirstOrDefault() != null) pl.Broadcasts.FirstOrDefault().Start();
        }
    }
    public class ListBroadcasts
    {
        private List<Broadcast> bcs = new();
        public void Add(Broadcast bc, bool instant = false)
        {
            if (bc == null) return;
            if (instant)
            {
                var currentbc = bcs.FirstOrDefault();
                List<Broadcast> list = new();
                list.Add(bc);
                list.AddRange(bcs);
                bcs = list;
                if (currentbc != null) currentbc.End();
                else bcs.First().Start();
            }
            else
            {
                bcs.Add(bc);
                if (!bcs.First().Active) bcs.First().Start();
            }
        }
        public void Remove(Broadcast bc)
        {
            if (bcs.Any(x => x == bc))
            {
                bcs.Remove(bc);
                if (bc.Active) bc.End();
            }
        }
        public void Clear()
        {
            if (bcs.Count < 1) return;
            var activebc = bcs.FirstOrDefault();
            bcs.Clear();
            activebc.End();
        }
        public List<Broadcast> List() => bcs;
        public bool Contains(Broadcast bc) => bcs.Contains(bc);
        public bool Any(Func<Broadcast, bool> func) => bcs.Any(func);
        public Broadcast First() => bcs.First();
        public Broadcast FirstOrDefault() => bcs.FirstOrDefault();
        public Broadcast FirstOrDefault(Func<Broadcast, bool> func) => bcs.FirstOrDefault(func);
    }
}