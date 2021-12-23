using System.Collections.Generic;
namespace Qurre
{
    public static class PluginManager
    {
        public static readonly List<Plugin> plugins;
        public static string LogsDirectory { get; }
        public static string CustomConfigsDirectory { get; }
        public static string ConfigsDirectory { get; }
        public static string LoadedDependenciesDirectory { get; }
        public static string PluginsDirectory { get; }
        public static string QurreDirectory { get; }
        public static string AppDataDirectory { get; }
        public static Version Version { get; }
        public static string ManagedAssembliesDirectory { get; }
        public static string ConfigsPath { get; }

        public static void Disable();
        public static void Enable();
        public static void LoadPlugin(Assembly assembly);
        public static void Reload();
        public static void ReloadPlugins();
    }
}