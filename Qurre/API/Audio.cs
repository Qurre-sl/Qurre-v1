using NLayer;
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
		public static AudioTask PlayFromFile(string path, byte volume, bool instant = false, bool loop = false, int frameSize = 1920, int sampleRate = 48000,
			string playerName = "Qurre Audio") => Play(new AudioStream(new FileStream(path, FileMode.Open), frameSize, sampleRate), volume, instant, loop, playerName);
		///<summary>
		///<para>Plays music from a url.</para>
		///<para>Example:</para>
		/// <example>
		/// <code>
		/// Audio.PlayFromUrl("https://cdn.scpsl.store/qurre/audio/OmegaWarhead.raw", 100, instant: true, loop: false, frameSize: 1920, sampleRate: 48000);
		/// </code>
		/// </example>
		///</summary>
		public static AudioTask PlayFromUrl(string url, byte volume, bool instant = false, bool loop = false, int frameSize = 1920, int sampleRate = 48000,
			string playerName = "Qurre Audio")
		{
			using System.Net.WebClient _web = new();
			byte[] byteData = _web.DownloadData(url);
			return Play(new AudioStream(new MemoryStream(byteData), frameSize, sampleRate), volume, instant, loop, playerName);
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
		public static AudioTask Play(Stream stream, byte volume, bool instant = false, bool loop = false, int frameSize = 1920, int sampleRate = 48000,
			string playerName = "Qurre Audio") => Play(new AudioStream(stream, frameSize, sampleRate), volume, instant, loop, playerName);


		///<summary>
		///<para>Plays MP3 music from a file.</para>
		///<para>Example:</para>
		/// <example>
		/// <code>
		/// Audio.PlayFromFileMP3($"{PluginManager.PluginsDirectory}/Audio/OmegaWarhead.raw", 100, instant: true, loop: false);
		/// </code>
		/// </example>
		///</summary>
		public static AudioTask PlayFromFileMP3(string path, byte volume, bool instant = false, bool loop = false, string playerName = "Qurre Audio")
			=> Play(new AudioStream(new MpegFile(path)), volume, instant, loop, playerName);
		///<summary>
		///<para>Plays MP3 music from a url.</para>
		///<para>Example:</para>
		/// <example>
		/// <code>
		/// Audio.PlayFromUrlMP3("https://cdn.scpsl.store/qurre/audio/OmegaWarhead.mp3", 100, instant: true, loop: false, frameSize: 1920);
		/// </code>
		/// </example>
		///</summary>
		public static AudioTask PlayFromUrlMP3(string url, byte volume, bool instant = false, bool loop = false, string playerName = "Qurre Audio")
		{
			using System.Net.WebClient _web = new();
			byte[] byteData = _web.DownloadData(url);
			return Play(new AudioStream(new MpegFile(new MemoryStream(byteData))), volume, instant, loop, playerName);
		}
		///<summary>
		///<para>Plays MP3 music from the stream.</para>
		///<para>Example:</para>
		/// <example>
		/// <code>
		/// Audio.PlayMP3(new MemoryStream(audio), 100, instant: true, loop: false, frameSize: 1920);
		/// </code>
		/// </example>
		///</summary>
		public static AudioTask PlayMP3(Stream stream, byte volume, bool instant = false, bool loop = false, string playerName = "Qurre Audio")
			=> Play(new AudioStream(new MpegFile(stream)), volume, instant, loop, playerName);


		///<summary>
		///<para>Plays music from the stream.</para>
		///<para>Example:</para>
		/// <example>
		/// <code>
		/// Audio.Play(new AudioStream(audio), 100, instant: true, loop: false, frameSize: 1920, sampleRate: 48000);
		/// </code>
		/// </example>
		///</summary>
		public static AudioTask Play(AudioStream stream, byte volume, bool instant = false, bool loop = false, string playerName = "Qurre Audio")
		{
			if (_micro is null) _micro = Radio.comms.gameObject.AddComponent<Microphone>();
			AudioTask task = new(stream, volume, loop, playerName);
			if (instant && _micro._tasks.Count > 0)
			{
				_micro._tasks.Insert(1, task);
				_micro.StopCapture();
			}
			else
			{
				_micro._tasks.Add(task);
				if (_micro._tasks.Count == 1) _micro.ResetMicrophone();
			}
			return task;
		}
		internal static Microphone _micro;
		public static IMicrophone Microphone => _micro;
	}
}