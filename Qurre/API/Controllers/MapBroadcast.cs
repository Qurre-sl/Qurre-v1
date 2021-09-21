using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Qurre.API.Controllers
{
    public class MapBroadcast
    {
        public MapBroadcast(string message, ushort time, bool instant);

        public string Message { get; set; }
        public ushort Time { get; }
        public bool Active { get; }

        public void End();
        public void Start();
    }
}
