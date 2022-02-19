using Qurre.API.Addons.Audio;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Qurre.API
{
	public class Audio
	{
		public static List<Audio> Audios { get; private set; } = new();
		///<summary>
		///<para>Plays music from a file.</para>
		///<para>Example:</para>
		/// <example>
		/// <code>
		/// new Audio($"{PluginManager.PluginsDirectory}/Audio/OmegaWarhead.raw", 100, true);
		/// </code>
		/// </example>
		///</summary>
		public Audio(string path, byte volume, bool instant = false) : this(new FileStream(path, FileMode.Open), volume, instant) { }
		///<summary>
		///<para>Plays music from the stream.</para>
		///<para>Example:</para>
		/// <example>
		/// <code>
		/// new Audio(new MemoryStream(audio), 100, false);
		/// </code>
		/// </example>
		///</summary>
		public Audio(Stream stream, byte volume, bool instant = false)
		{
			Microphone = AudioExtensions.DissonanceComms.gameObject.AddComponent<AudioMicrophone>().Create(stream, volume, this);
            if (instant && Audios.Count > 0)
			{
				var _cur = Audios.FirstOrDefault();
				Audios.Remove(_cur);
				List<Audio> list = new();
				list.Add(this);
				list.AddRange(Audios);
				Audios = list;
				_cur.Microphone.StopCapture();
			}
            else
            {
				Audios.Add(this);
				if (Audios.FirstOrDefault() == this) Microphone.ResetMicrophone(Microphone.Name, true);
			}
		}
		public readonly IMicrophone Microphone;
		/*public static void PlayFromUrl(string url, float volume)
		{
			using var wc = new WebClient();
			byte[] byteData = wc.DownloadData(url);
			Play(new MemoryStream(byteData), volume);
		}*/
	}
}