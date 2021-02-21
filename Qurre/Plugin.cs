namespace Qurre
{
    public abstract class Plugin
    {
        public static YamlConfig Config;
        public abstract string Version { get; }
        public abstract string Developer { get; }
        public abstract string Name { get; }

        public abstract void Disable();
        public abstract void Enable();
        public abstract void Reload();
    }
}