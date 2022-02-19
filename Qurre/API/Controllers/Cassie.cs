using Respawning;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Qurre.API.Controllers
{
    public class Cassie
    {
        public Cassie(string message, bool makeHold, bool makeNoise)
        {
            Message = message;
            Hold = makeHold;
            Noise = makeNoise;
        }
        public string Message = "";
        public bool Hold = false;
        public bool Noise = false;
        public bool Active { get; private set; }
        public void Send()
        {
            if (Active) return;
            Active = true;
            RespawnEffectsController.PlayCassieAnnouncement(Message, Hold, Noise);
        }
        internal static void End()
        {
            if (Map.Cassies.FirstOrDefault() != null) Map.Cassies.FirstOrDefault().Send();
        }
        public static bool Lock { get; set; }
        public static void Send(string msg, bool makeHold = false, bool makeNoise = false, bool instant = false) =>
            Map.Cassies.Add(new Cassie(msg, makeHold, makeNoise), instant);
    }
    public class CassieList
    {
        private List<Cassie> Cassies = new();
        public void Add(Cassie bc, bool instant = false)
        {
            if (bc == null) return;
            if (instant)
            {
                List<Cassie> list = new();
                list.Add(bc);
                list.AddRange(Cassies);
                Cassies = list;
                Cassies.First().Send();
            }
            else
            {
                Cassies.Add(bc);
                if (!Cassies.First().Active) Cassies.First().Send();
            }
        }
        public void Remove(Cassie bc)
        {
            if (Cassies.Any(x => x == bc))
                Cassies.Remove(bc);
        }
        public void Clear()
        {
            if (Cassies.Count < 1) return;
            Cassies.Clear();
        }
        public List<Cassie> List() => Cassies;
        public bool Contains(Cassie bc) => Cassies.Contains(bc);
        public bool Any(Func<Cassie, bool> func) => Cassies.Any(func);
        public Cassie FirstOrDefault() => Cassies.FirstOrDefault();
    }
}