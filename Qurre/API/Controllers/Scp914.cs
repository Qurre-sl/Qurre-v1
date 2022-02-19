using Scp914;
using UnityEngine;
using Utils.ConfigHandler;
namespace Qurre.API.Controllers
{
	public static class Scp914
	{
		public static Scp914Controller Scp914Controller { get; internal set; }
		public static GameObject GameObject => Scp914Controller.gameObject;
		public static bool Working => Scp914Controller._isUpgrading;
		public static Scp914KnobSetting KnobState
		{
			get => Scp914Controller._knobSetting;
			set => Scp914Controller.Network_knobSetting = value;
		}
		public static ConfigEntry<Scp914Mode> Config
		{
			get => Scp914Controller._configMode;
			set => Scp914Controller._configMode = value;
		}
		public static Transform Intake
		{
			get => Scp914Controller._intakeChamber;
			set => Scp914Controller._intakeChamber = value;
		}

		public static Transform Output
		{
			get => Scp914Controller._outputChamber;
			set => Scp914Controller._outputChamber = value;
		}
		public static void Activate() => Scp914Controller.ServerInteract(Server.Host.ReferenceHub, 0);
	}
}