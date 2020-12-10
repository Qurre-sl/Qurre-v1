namespace Qurre
{
    public abstract class Plugin
    {
        public static YamlConfig Config;
        public abstract string name { get; }
        public abstract void Disable();
        public abstract void Enable();
        public abstract void Reload();
    }
}