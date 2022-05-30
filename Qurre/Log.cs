using System;
using System.IO;
using System.Reflection;
namespace Qurre
{
	public static class Log
	{
		internal static bool Debugging => Plugin.Config.GetBool("Qurre_Debug", false, "Are Debug logs enabled?");
		internal static bool Logging => Plugin.Config.GetBool("Qurre_Logging", true, "Are errors saved to the log file?");
		internal static bool AllLogging => Plugin.Config.GetBool("Qurre_All_Logging", false, "Are all console output being saved to a log file?");
		public static void Info(object message) =>
			ServerConsole.AddLog($"[INFO] [{Assembly.GetCallingAssembly().GetName().Name}] {message}", ConsoleColor.Yellow);
		public static void Debug(object message)
		{
			if (Debugging)
				ServerConsole.AddLog($"[DEBUG] [{Assembly.GetCallingAssembly().GetName().Name}] {message}", ConsoleColor.DarkGreen);
		}
		public static void Warn(object message)
		{
			string text = $"[WARN] [{Assembly.GetCallingAssembly().GetName().Name}] {message}";
			ServerConsole.AddLog(text, ConsoleColor.DarkYellow);
			LogTxt(text);
		}
		public static void Error(object message)
		{
			string text = $"[ERROR] [{Assembly.GetCallingAssembly().GetName().Name}] {message}";
			ServerConsole.AddLog(text, ConsoleColor.Red);
			LogTxt(text);
		}
		public static void Custom(object message, string prefix = "Custom", ConsoleColor color = ConsoleColor.Gray) =>
			ServerConsole.AddLog($"[{prefix}] [{Assembly.GetCallingAssembly().GetName().Name}] {message}", color);
		internal static void LogTxt(object message)
		{
			if (!Logging) return;
			if (!Directory.Exists(PluginManager.LogsDirectory))
			{
				Directory.CreateDirectory(PluginManager.LogsDirectory);
				Custom($"Logs directory not found - creating: {PluginManager.LogsDirectory}", "WARN", ConsoleColor.DarkYellow);
			}
			File.AppendAllText(Path.Combine(PluginManager.LogsDirectory, $"{Loader.Port}-log.txt"), $"[{DateTime.Now:dd.MM.yyyy HH:mm:ss}] {message}\n");
		}
		internal static void AllLogsTxt(object message)
		{
			if (!AllLogging) return;
			if (!Directory.Exists(PluginManager.LogsDirectory))
			{
				Directory.CreateDirectory(PluginManager.LogsDirectory);
				Custom($"Logs directory not found - creating: {PluginManager.LogsDirectory}", "WARN", ConsoleColor.DarkYellow);
			}
			File.AppendAllText(Path.Combine(PluginManager.LogsDirectory, $"{Loader.Port}-all-logs.txt"), $"[{DateTime.Now:dd.MM.yyyy HH:mm:ss}] {message}\n");
		}
	}
}