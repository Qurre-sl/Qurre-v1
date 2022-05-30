using Dissonance.Audio.Capture;
using System.Collections.Generic;
namespace Qurre.API.Addons.Audio
{
	public interface IMicrophone : IMicrophoneCapture
	{
		StatusType Status { get; }
		IReadOnlyCollection<AudioTask> Tasks { get; }
		void Pause();
		void Resume();
		void Skip();
	}
}