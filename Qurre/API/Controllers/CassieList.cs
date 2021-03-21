using System;
using System.Collections.Generic;
namespace Qurre.API.Controllers
{
    public class CassieList
    {
        public void Add(Cassie bc, bool instant = false);
        public bool Any(Func<Cassie, bool> func);
        public void Clear();
        public bool Contains(Cassie bc);
        public Cassie FirstOrDefault();
        public List<Cassie> List();
        public void Remove(Cassie bc);
    }
}