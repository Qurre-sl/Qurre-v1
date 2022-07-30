using Qurre.API.Addons.Audio;
using System.IO;
using System.Linq;
namespace Qurre.API
{
	public static class Audio
	{
		///<summary>
		///<para>Plays music from a file.</para>
		///<para>Example:</para>
		/// <example>
		/// <code>
		/// Audio.PlayFromFile($"{PluginManager.PluginsDirectory}/Audio/OmegaWarhead.raw", 100, instant: true, loop: false, frameSize: 1920, sampleRate: 48000);
		/// </code>
		/// </example>
		///</summary>
		public static void PlayFromFile(string path, byte volume, bool instant = false, bool loop = false, int frameSize = 1920, int sampleRate = 48000,
			string playerName = "Qurre Audio") => Play(new FileStream(path, FileMode.Open), volume, instant, loop, frameSize, sampleRate, playerName);
		///<summary>
		///<para>Plays music from a url.</para>
		///<para>Example:</para>
		/// <example>
		/// <code>
		/// Audio.PlayFromUrl("https://cdn.scpsl.store/qurre/audio/OmegaWarhead.raw", 100, instant: true, loop: false, frameSize: 1920, sampleRate: 48000);
		/// </code>
		/// </example>
		///</summary>
		public static void PlayFromUrl(string url, byte volume, bool instant = false, bool loop = false, int frameSize = 1920, int sampleRate = 48000,
			string playerName = "Qurre Audio")
		{
			using System.Net.WebClient _web = new();
			byte[] byteData = _web.DownloadData(url);
			Play(new MemoryStream(byteData), volume, instant, loop, frameSize, sampleRate, playerName);
		}
		///<summary>
		///<para>Plays music from the stream.</para>
		///<para>Example:</para>
		/// <example>
		/// <code>
		/// Audio.Play(new MemoryStream(audio), 100, instant: true, loop: false, frameSize: 1920, sampleRate: 48000);
		/// </code>
		/// </example>
		///</summary>
		public static void Play(Stream stream, byte volume, bool instant = false, bool loop = false, int frameSize = 1920, int sampleRate = 48000,
			string playerName = "Qurre Audio")
		{
			if (stream is null) throw new System.NullReferenceException("Qurre.API.Audio.Play: Stream is null");
			if (_micro is null)
				_micro = Radio.comms.gameObject.AddComponent<Microphone>();
			AudioTask task = new(stream, volume, loop, frameSize, sampleRate, playerName);
			if (instant && _micro._tasks.Count > 0)
			{
				var _oldTask = _micro._tasks[0];
				_micro._tasks[0] = task;
				_micro.UpdateFrames(task);
				_oldTask.Dispose();
			}
			else
			{
				_micro._tasks.Add(task);
				if (_micro._tasks.Count == 1) _micro.ResetMicrophone();
			}
		}
		internal static Microphone _micro;
		public static IMicrophone Microphone => _micro;
	}
}