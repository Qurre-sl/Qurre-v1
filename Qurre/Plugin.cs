using System;
namespace Qurre
{
    public abstract class Plugin
    {
        public static YamlConfig Config;
        public virtual string Developer { get; }
        public virtual string Name { get; }
        public virtual Version Version { get; }
        public virtual Version NeededQurreVersion { get; }

        public abstract void Disable();
        public abstract void Enable();
        public abstract void Reload();
    }
}