using UnityEngine;
namespace Qurre.API.Controllers
{
	public static class Alpha
	{
		private static AlphaWarheadController awc;
		private static AlphaWarheadNukesitePanel awnp;
		public static AlphaWarheadController AlphaWarheadController
		{
			get
			{
				if (awc == null) awc = PlayerManager.localPlayer.GetComponent<AlphaWarheadController>();
				return awc;
			}
		}
		internal static AlphaWarheadNukesitePanel AlphaWarheadNukesitePanel
		{
			get
			{
				if (awnp == null) awnp = Object.FindObjectOfType<AlphaWarheadNukesitePanel>();
				return awnp;
			}
		}
		public static void Start()
		{
			AlphaWarheadController.InstantPrepare();
			AlphaWarheadController.StartDetonation();
		}
		public static void InstantPrepare() => AlphaWarheadController.InstantPrepare();
		public static void CancelDetonation() => AlphaWarheadController.CancelDetonation();
		public static void Stop() => AlphaWarheadController.CancelDetonation();
		public static void Detonate() => AlphaWarheadController.Detonate();
		public static bool Enabled
		{
			get => AlphaWarheadNukesitePanel.Networkenabled;
			set => AlphaWarheadNukesitePanel.Networkenabled = value;
		}
		public static bool Detonated => AlphaWarheadController.detonated;
		public static bool CanDetoante => AlphaWarheadController.CanDetonate;
		public static bool Active => AlphaWarheadController.NetworkinProgress;
		public static float TimeToDetonation
		{
			get => AlphaWarheadController.NetworktimeToDetonation;
			set => AlphaWarheadController.NetworktimeToDetonation = value;
		}
		public static bool Locked
		{
			get => AlphaWarheadController._isLocked;
			set => AlphaWarheadController._isLocked = value;
		}
		public static int Cooldown
		{
			get => AlphaWarheadController.cooldown;
			set => AlphaWarheadController.cooldown = value;
		}
		public static class InsidePanel
		{
			private static AlphaWarheadNukesitePanel Panel => AlphaWarheadOutsitePanel.nukeside;
			public static bool Enabled
			{
				get => Panel.Networkenabled;
				set => Panel.Networkenabled = value;
			}
			public static float LeverStatus
			{
				get => Panel._leverStatus;
				set => Panel._leverStatus = value;
			}
			public static bool Locked { get; set; } = false;
			public static Transform Lever => Panel.lever;
		}
		public static class OutsidePanel
		{
			private static AlphaWarheadOutsitePanel Panel => PlayerManager.localPlayer.GetComponent<AlphaWarheadOutsitePanel>();
			public static bool KeyCardEntered
			{
				get => Panel.NetworkkeycardEntered;
				set => Panel.NetworkkeycardEntered = value;
			}
		}
	}
}