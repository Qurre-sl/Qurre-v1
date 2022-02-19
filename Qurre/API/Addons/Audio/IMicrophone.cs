using Dissonance;
using Dissonance.Audio.Capture;
using System.IO;
namespace Qurre.API.Addons.Audio
{
	public interface IMicrophone : IMicrophoneCapture
	{
		AudioStatusType Status { get; }
		DissonanceComms DissonanceComms { get; }
		Stream Stream { get; }
		float Volume { get; set; }
		RoomChannel RoomChannel { get; }
		string Name { get; }
		void PauseCapture();
		void ResetMicrophone(string name, bool Instant);
		void Dispose();
	}
}