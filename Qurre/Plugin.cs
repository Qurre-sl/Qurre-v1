using System;
namespace Qurre
{
    public abstract class Plugin
    {
        public static Config Config;
        public virtual string Developer { get; }
        public virtual string Name { get; }
        public virtual Version Version { get; }
        public virtual Version NeededQurreVersion { get; }
        public virtual int Priority { get; }

        public abstract void Disable();
        public abstract void Enable();
        public virtual void Reload();
    }
}