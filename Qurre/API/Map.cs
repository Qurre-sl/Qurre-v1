using Qurre.API.Objects;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;
using Mirror;
using Respawning;
using Interactables.Interobjects.DoorUtils;
using _lift = Qurre.API.Controllers.Lift;
using _locker = Qurre.API.Controllers.Locker;
using _ragdoll = Qurre.API.Controllers.Ragdoll;
using _workStation = Qurre.API.Controllers.WorkStation;
using Qurre.API.Controllers;
using LightContainmentZoneDecontamination;
using MapGeneration;
using InventorySystem.Items.Firearms.Attachments;
using Scp914;
using Qurre.API.Controllers.Items;
using InventorySystem.Items.Pickups;
using System;
using PlayerStatsSystem;
using Light = Qurre.API.Controllers.Light;
using Qurre.API.Addons.Audio;
using Camera = Qurre.API.Controllers.Camera;
namespace Qurre.API
{
	public static class Map
	{
		public static CassieList Cassies { get; private set; } = new CassieList();
		public static List<Door> Doors { get; } = new();
		public static List<_lift> Lifts { get; } = new();
		public static List<_locker> Lockers { get; } = new();
		public static List<Generator> Generators { get; } = new();
		public static List<_ragdoll> Ragdolls { get; } = new();
		public static List<Sinkhole> Sinkholes { get; } = new();
		public static List<Room> Rooms { get; } = new();
		public static List<Camera> Cameras { get; } = new();
		public static List<Tesla> Teslas { get; } = new();
		public static List<_workStation> WorkStations { get; } = new();
		public static List<Bot> Bots { get; } = new();
		public static List<Window> Windows { get; } = new();
		public static List<Light> Lights { get; } = new();
		public static List<Primitive> Primitives { get; } = new();
		public static List<ShootingTarget> ShootingTargets { get; } = new();
		public static List<Pickup> Pickups
		{
			get
			{
				List<Pickup> pickups = new();
				foreach (ItemPickupBase itemPickupBase in Object.FindObjectsOfType<ItemPickupBase>())
				{
					if (Pickup.Get(itemPickupBase) is Pickup pickup)
						pickups.Add(pickup);
				}
				return pickups;
			}
		}
		public static float WalkSpeedMultiplier
		{
			get => ServerConfigSynchronizer.Singleton.NetworkHumanWalkSpeedMultiplier;
			set => ServerConfigSynchronizer.Singleton.NetworkHumanWalkSpeedMultiplier = value;
		}
		public static float SprintSpeedMultiplier
		{
			get => ServerConfigSynchronizer.Singleton.NetworkHumanSprintSpeedMultiplier;
			set => ServerConfigSynchronizer.Singleton.NetworkHumanSprintSpeedMultiplier = value;
		}
		public static bool DisabledLCZDecontamination
		{
			get => DecontaminationController.Singleton.disableDecontamination;
			set => DecontaminationController.Singleton.disableDecontamination = value;
		}
		public static Vector3 Gravitation
		{
			get => Physics.gravity;
			set => Physics.gravity = value;
		}
		public static float ElevatorsMovingSpeed
		{
			get => Object.FindObjectsOfType<Lift>()[0].movingSpeed;
			set
			{
				foreach (Lift lift in Object.FindObjectsOfType<Lift>()) lift.movingSpeed = value;
			}
		}
		public static bool FemurBreakerState
		{
			get => Object.FindObjectOfType<LureSubjectContainer>().allowContain;
			set => Object.FindObjectOfType<LureSubjectContainer>().SetState(FemurBreakerState, value);
		}
		public static float Seed => SeedSynchronizer.Seed;
		public static float BreakableWindowHp
		{
			get => Object.FindObjectsOfType<BreakableWindow>()[0].health;
			set
			{
				foreach (BreakableWindow window in Object.FindObjectsOfType<BreakableWindow>()) window.health = value;
			}
		}
		public static MapBroadcast Broadcast(string message, ushort duration, bool instant = false)
		{
			var bc = new MapBroadcast(message, duration, instant);
			return bc;
		}
		public static void ClearBroadcasts() => Server.Host.Broadcasts.Clear();
		public static Vector3 GetRandomSpawnPoint(RoleType roleType)
		{
			GameObject randomPosition = SpawnpointManager.GetRandomPosition(roleType);
			return randomPosition == null ? Vector3.zero : randomPosition.transform.position;
		}
		public static Transform GetRandomSpawnTransform(RoleType roleType)
		{
			GameObject randomPosition = SpawnpointManager.GetRandomPosition(roleType);
			return randomPosition?.transform;
		}
		public static void ContainSCP106(Player executor) => PlayerManager.localPlayer.GetComponent<PlayerInteract>().UserCode_RpcContain106(executor.GameObject);
		public static void ShakeScreen(float times) => ExplosionCameraShake.singleton.Shake(times);
		public static void SetIntercomSpeaker(Player player)
		{
			if (player != null)
			{
				GameObject gameObject = player.GameObject;
				gameObject.GetComponent<CharacterClassManager>().IntercomMuted = false;
				Intercom.host.RequestTransmission(gameObject);
				return;
			}
			foreach (CharacterClassManager ccm in Object.FindObjectsOfType<CharacterClassManager>())
			{
				if (ccm.IntercomMuted) ccm.IntercomMuted = false;
			}
		}
		public static void PlayCIEntranceMusic() => RespawnEffectsController.ExecuteAllEffects(RespawnEffectsController.EffectType.UponRespawn, SpawnableTeamType.ChaosInsurgency);
		public static void PlayIntercomSound(bool start) => PlayerManager.localPlayer.GetComponent<Intercom>().RpcPlaySound(start, 0);
		public static void PlaceBlood(Vector3 position, int type, float size) => PlayerManager.localPlayer.GetComponent<CharacterClassManager>().RpcPlaceBlood(position, type, size);
		public static AmbientSoundPlayer AmbientSoundPlayer { get; private set; }
		public static void PlayAmbientSound() => AmbientSoundPlayer.GenerateRandom();
		public static void PlayAmbientSound(int id)
		{
			if (id >= AmbientSoundPlayer.clips.Length)
				throw new IndexOutOfRangeException($"[Qurre.API.Map.PlayAmbientSound] no, no, no, no more than {AmbientSoundPlayer.clips.Length} sounds.");
			AmbientSoundPlayer.RpcPlaySound(AmbientSoundPlayer.clips[id].index);
		}
		public static void ShowHint(string message, float duration)
		{
			foreach (Player player in Player.List) player.ShowHint(message, duration);
		}
		public static void AnnounceNtfEntrance(int scpsLeft, int mtfNumber, char mtfLetter)
		{
			if (scpsLeft == 0) Cassie.Send($"MTFUnit epsilon 11 designated NATO_{mtfLetter} {mtfNumber} HasEntered AllRemaining NoSCPsLeft", true, true, true);
			else Cassie.Send($"MTFUnit epsilon 11 designated NATO_{mtfLetter} {mtfNumber} HasEntered AllRemaining AwaitingRecontainment {scpsLeft} scpsubjects", true, true, true);
		}
		public static void AnnounceScpKill(string scpNumber, Player killer = null)
		{
			GameObject gameObject = GameObject.Find("Host");
			var rt = ("SCP-" + scpNumber) switch
			{
				"49" or "049" => RoleType.Scp049,
				"79" or "079" => RoleType.Scp079,
				"96" or "096" => RoleType.Scp096,
				"106" => RoleType.Scp106,
				"173" => RoleType.Scp173,
				"939-53" or "939_53" or "93953" => RoleType.Scp93953,
				"939-89" or "939_89" or "93989" => RoleType.Scp93989,
				_ => RoleType.None,
			};
			CharacterClassManager component2 = gameObject.GetComponent<CharacterClassManager>();
			var _cassie = new ScpDamageHandler(killer.ReferenceHub, DeathTranslations.Unknown).CassieDeathAnnouncement;
			NineTailedFoxAnnouncer.scpDeaths.Add(new NineTailedFoxAnnouncer.ScpDeath
			{
				scpSubjects = new List<Role>(new Role[1]
				{
				component2.Classes.SafeGet(rt)
				}),
				announcement = _cassie.Announcement,
				subtitleParts = _cassie.SubtitleParts
			});
		}
		public static void DecontaminateLCZ()
		{
			DecontaminationController.Singleton.FinishDecontamination();
			DecontaminationController.Singleton.NetworkRoundStartTime = -1.0;
		}
		public static void Remove(RemovableObject removable)
		{
			switch (removable)
			{
				case RemovableObject.Doors:
					foreach (Door door in Doors) Object.Destroy(door.GameObject);
					break;
				case RemovableObject.Generators:
					foreach (Generator generator in Generators) Object.Destroy(generator.GameObject);
					break;
				case RemovableObject.Lockers:
					foreach (_locker locker in Lockers) Object.Destroy(locker.GameObject);
					break;
				case RemovableObject.Teslagates:
					foreach (Tesla teslaGate in Teslas) Object.Destroy(teslaGate.GameObject);
					break;
				case RemovableObject.Windows:
					foreach (BreakableWindow window in Object.FindObjectsOfType<BreakableWindow>()) Object.Destroy(window.gameObject);
					break;
				case RemovableObject.Workstations:
					foreach (_workStation workStation in WorkStations) Object.Destroy(workStation.GameObject);
					break;
				case RemovableObject.Rooms:
					foreach (NetworkIdentity netId in Object.FindObjectsOfType<NetworkIdentity>()) if (netId.name.Contains("All")) Object.Destroy(netId);
					break;
			}
		}
		internal static void AddObjects()
		{
			AmbientSoundPlayer = PlayerManager.localPlayer.GetComponent<AmbientSoundPlayer>();
			Cassies = new CassieList();
			foreach (var room in RoomIdentifier.AllRoomIdentifiers)
			{
				var _room = new Room(room);
				Rooms.Add(_room);
				Cameras.AddRange(_room.Cameras);
			}
			foreach (var tesla in Server.GetObjectsOf<TeslaGate>()) Teslas.Add(new Tesla(tesla));
			foreach (var station in WorkstationController.AllWorkstations) WorkStations.Add(new _workStation(station));
			foreach (var door in Server.GetObjectsOf<DoorVariant>()) Doors.Add(new Door(door));
			foreach (var window in Server.GetObjectsOf<BreakableWindow>()) Windows.Add(new Window(window));
			foreach (var hole in Server.GetObjectsOf<SinkholeEnvironmentalHazard>()) Sinkholes.Add(new Sinkhole(hole));
			foreach (var pair in Scp079Interactable.InteractablesByRoomId)
			{
				foreach (var interactable in pair.Value)
				{
					try
					{
						var room = Rooms.FirstOrDefault(x => x.Id == pair.Key);
						var door = interactable.GetComponentInParent<DoorVariant>();
						if (room == null || door == null) continue;
						var sdoor = door.GetDoor();
						sdoor.Rooms.Add(room);
						room.Doors.Add(sdoor);
					}
					catch { }
				}
			}
			Controllers.Scp914.Scp914Controller = Object.FindObjectOfType<Scp914Controller>();
			Item.BaseToItem.Clear();
			Pickup.BaseToItem.Clear();
		}
		internal static void ClearObjects()
		{
			try { Teslas.ForEach(x => x.ImmunityRoles.Clear()); } catch { }
			try { Teslas.ForEach(x => x.ImmunityPlayers.Clear()); } catch { }
			Teslas.Clear();
			Doors.Clear();
			Lifts.Clear();
			Lockers.Clear();
			Rooms.Clear();
			Generators.Clear();
			WorkStations.Clear();
			Ragdolls.Clear();
			Windows.Clear();
			Sinkholes.Clear();
			Lights.Clear();
			Primitives.Clear();
			ShootingTargets.Clear();
			Cameras.Clear();
			Patches.Events.player.Banned.Cached.Clear();
			try
			{
				foreach (var m in AudioMicrophone.Cache) m.Dispose();
				AudioMicrophone.Cache.Clear();
			}
			catch { }
			try
			{
				foreach (var a in Audio.Audios) try { a.Microphone.Dispose(); } catch { }
				Audio.Audios.Clear();
			}
			catch { }
		}
	}
}