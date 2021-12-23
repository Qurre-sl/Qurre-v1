using System;
namespace Qurre
{
    public abstract class Plugin
    {
        public static Config Config { get; set; }
        public ListConfigs CustomConfigs { get; }
        public virtual string Developer { get; }
        public virtual string Name { get; }
        public virtual Version Version { get; }
        public virtual Version NeededQurreVersion { get; }
        public virtual int Priority { get; }

        public abstract void Disable();
        public abstract void Enable();
        public virtual void RegisterCommands();
        public virtual void Reload();
        public virtual void UnregisterCommands();
    }
}