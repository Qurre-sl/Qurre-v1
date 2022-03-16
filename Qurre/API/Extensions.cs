using CustomPlayerEffects;
using Interactables.Interobjects;
using Interactables.Interobjects.DoorUtils;
using InventorySystem.Items.Firearms.Attachments;
using MapGeneration;
using MapGeneration.Distributors;
using Mirror;
using PlayerStatsSystem;
using Qurre.API.Addons;
using Qurre.API.Controllers;
using Qurre.API.Modules;
using Qurre.API.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using UnityEngine;
using _lift = Qurre.API.Controllers.Lift;
using _locker = Qurre.API.Controllers.Locker;
using _workStation = Qurre.API.Controllers.WorkStation;
using Camera = Qurre.API.Controllers.Camera;
namespace Qurre.API
{
	public static class Extensions
	{
		public static BreakableDoor GetPrefab(this DoorPrefabs prefab)
		{
			if (Prefabs.Doors.TryGetValue(prefab, out var door)) return door;
			return Prefabs.Doors.First().Value;
		}
		public static GameObject GetPrefab(this TargetPrefabs prefab)
		{
			if (Prefabs.Targets.TryGetValue(prefab, out var target)) return target;
			return Prefabs.Targets.First().Value;
		}
		public static MapGeneration.Distributors.Locker GetPrefab(this LockerPrefabs prefab)
		{
			if (prefab == LockerPrefabs.Pedestal)
			{
				int rand = UnityEngine.Random.Range(0, 100);
				if (rand > 80) prefab = LockerPrefabs.Pedestal268;
				else if (rand > 60) prefab = LockerPrefabs.Pedestal207;
				else if (rand > 40) prefab = LockerPrefabs.Pedestal500;
				else if (rand > 20) prefab = LockerPrefabs.Pedestal018;
				else prefab = LockerPrefabs.Pedestal2176;
			}
			if (Prefabs.Lockers.TryGetValue(prefab, out var locker)) return locker;
			return Prefabs.Lockers.First().Value;
		}
		public static Room GetRoom(this RoomName type) => Map.Rooms.FirstOrDefault(x => x.RoomName == type);
		public static Room GetRoom(this RoomType type) => Map.Rooms.FirstOrDefault(x => x.Type == type);
		public static Room GetRoom(this RoomIdentifier identifier) => Map.Rooms.FirstOrDefault(x => x.Identifier == identifier);
		public static Door GetDoor(this DoorType type) => Map.Doors.FirstOrDefault(x => x.Type == type);
		public static Door GetDoor(this GameObject gameObject) => Map.Doors.FirstOrDefault(x => x.GameObject == gameObject);
		public static Camera GetCamera(this Camera079 cam) => Map.Cameras.FirstOrDefault(x => x.GameObject == cam.gameObject && x.Id == cam.cameraId);
		public static Camera GetCamera(this GameObject obj) => Map.Cameras.FirstOrDefault(x => x.GameObject == obj);
		public static Camera GetCamera(this ushort id) => Map.Cameras.FirstOrDefault(x => x.Id == id);
		public static _lift GetLift(this LiftType type) => Map.Lifts.FirstOrDefault(x => x.Type == type);
		public static Door GetDoor(this DoorVariant door) => Map.Doors.FirstOrDefault(x => x.GameObject == door.gameObject);
		public static Generator GetGenerator(this GameObject gameObject) => Map.Generators.FirstOrDefault(x => x.GameObject == gameObject);
		public static Generator GetGenerator(this Scp079Generator generator079) => Map.Generators.FirstOrDefault(x => x.GameObject == generator079.gameObject);
		public static Tesla GetTesla(this TeslaGate teslaGate) => Map.Teslas.FirstOrDefault(x => x.GameObject == teslaGate.gameObject);
		public static Tesla GetTesla(this GameObject gameObject) => Map.Teslas.FirstOrDefault(x => x.GameObject == gameObject);
		public static Primitive GetPrimitive(this GameObject gameObject) => Map.Primitives.FirstOrDefault(x => x.Base.gameObject == gameObject);
		public static Controllers.Light GetLight(this GameObject gameObject) => Map.Lights.FirstOrDefault(x => x.Base.gameObject == gameObject);
		public static _lift GetLift(this Lift lift) => Map.Lifts.FirstOrDefault(x => x.GameObject == lift.gameObject);
		public static _locker GetLocker(this MapGeneration.Distributors.Locker locker) => Map.Lockers.FirstOrDefault(x => x.Transform == locker.gameObject);
		public static _workStation GetWorkStation(this WorkstationController station) => Map.WorkStations.FirstOrDefault(x => x.GameObject == station.gameObject);
		public static Window GetWindow(this BreakableWindow station) => Map.Windows.FirstOrDefault(x => x.Breakable == station);
		public static Window GetWindow(this GameObject go) => Map.Windows.FirstOrDefault(x => x.GameObject == go);
		public static Sinkhole GetSinkhole(this SinkholeEnvironmentalHazard hole) => Map.Sinkholes.FirstOrDefault(x => x.EnvironmentalHazard == hole);
		public static bool TryFind<TSource>(this IEnumerable<TSource> source, out TSource found, Func<TSource, bool> predicate)
		{
			var list = source.Where(predicate);
			if (list.Count() == 0)
			{
				found = default;
				return false;
			}
			found = list.First();
			return true;
		}
		public static void UpdateData(this NetworkIdentity identity) => NetworkServer.SendToAll(identity.SpawnMsg());
		public static SpawnMessage SpawnMsg(this NetworkIdentity identity)
		{
			var writer = NetworkWriterPool.GetWriter();
			var writer2 = NetworkWriterPool.GetWriter();
			var payload = NetworkServer.CreateSpawnMessagePayload(false, identity, writer, writer2);
			return new SpawnMessage
			{
				netId = identity.netId,
				isLocalPlayer = false,
				isOwner = false,
				sceneId = identity.sceneId,
				assetId = identity.assetId,
				position = identity.gameObject.transform.position,
				rotation = identity.gameObject.transform.rotation,
				scale = identity.gameObject.transform.localScale,
				payload = payload
			};
		}
		public static Team GetTeam(this RoleType roleType)
		{
			return roleType switch
			{
				RoleType.ChaosConscript or RoleType.ChaosMarauder or RoleType.ChaosRepressor or RoleType.ChaosRifleman => Team.CHI,
				RoleType.Scientist => Team.RSC,
				RoleType.ClassD => Team.CDP,
				RoleType.Scp049 or RoleType.Scp93953 or RoleType.Scp93989 or RoleType.Scp0492 or RoleType.Scp079 or RoleType.Scp096 or RoleType.Scp106 or RoleType.Scp173 => Team.SCP,
				RoleType.Spectator => Team.RIP,
				RoleType.FacilityGuard or RoleType.NtfCaptain or RoleType.NtfPrivate or RoleType.NtfSergeant or RoleType.NtfSpecialist => Team.MTF,
				RoleType.Tutorial => Team.TUT,
				_ => Team.RIP,
			};
		}
		public static Player GetAttacker(this DamageHandlerBase handler)
		{
			var plz = GetAttackerPLZ(handler);
			if (plz == null) return null;
			return Player.Get(plz.Attacker.Hub);
		}
		public static AttackerDamageHandler GetAttackerPLZ(DamageHandlerBase handler)
		{
			return handler switch
			{
				AttackerDamageHandler adh2 => adh2,
				_ => null,
			};
		}
		public static DamageTypesPrimitive GetDamageTypesPrimitive(this DamageHandlerBase handler)
		{
			return handler switch
			{
				CustomReasonDamageHandler _ => DamageTypesPrimitive.Custom,
				ExplosionDamageHandler _ => DamageTypesPrimitive.Explosion,
				FirearmDamageHandler _ => DamageTypesPrimitive.Firearm,
				MicroHidDamageHandler _ => DamageTypesPrimitive.MicroHid,
				RecontainmentDamageHandler _ => DamageTypesPrimitive.Recontainment,
				Scp018DamageHandler _ => DamageTypesPrimitive.Scp018,
				Scp096DamageHandler _ => DamageTypesPrimitive.Scp096,
				ScpDamageHandler _ => DamageTypesPrimitive.ScpDamage,
				UniversalDamageHandler _ => DamageTypesPrimitive.Universal,
				WarheadDamageHandler _ => DamageTypesPrimitive.Warhead,
				_ => DamageTypesPrimitive.Unknow,
			};
		}
		public static DamageTypes GetDamageType(this DamageHandlerBase handler)
		{
			switch (handler)
			{
				case UniversalDamageHandler tr:
					{
						if (tr.TranslationId == 0) return DamageTypes.Recontainment;
						if (tr.TranslationId == 1) return DamageTypes.Nuke;
						if (tr.TranslationId == 2) return DamageTypes.Scp049;
						if (tr.TranslationId == 4) return DamageTypes.Asphyxiation;
						if (tr.TranslationId == 5) return DamageTypes.Bleeding;
						if (tr.TranslationId == 6) return DamageTypes.Falldown;
						if (tr.TranslationId == 7) return DamageTypes.Pocket;
						if (tr.TranslationId == 8) return DamageTypes.Decont;
						if (tr.TranslationId == 9) return DamageTypes.Poison;
						if (tr.TranslationId == 10) return DamageTypes.Scp207;
						if (tr.TranslationId == 11) return DamageTypes.SeveredHands;
						if (tr.TranslationId == 12) return DamageTypes.MicroHid;
						if (tr.TranslationId == 13) return DamageTypes.Tesla;
						if (tr.TranslationId == 14) return DamageTypes.Explosion;
						if (tr.TranslationId == 15) return DamageTypes.Scp096;
						if (tr.TranslationId == 16) return DamageTypes.Scp173;
						if (tr.TranslationId == 17) return DamageTypes.Scp939;
						if (tr.TranslationId == 18) return DamageTypes.Scp0492;
						if (tr.TranslationId == 20) return DamageTypes.Wall;
						if (tr.TranslationId == 21) return DamageTypes.Contain;
						if (tr.TranslationId == 22) return DamageTypes.FriendlyFireDetector;
					}
					break;
				case FirearmDamageHandler fr:
					{
						if (fr.WeaponType == ItemType.GunAK) return DamageTypes.AK;
						if (fr.WeaponType == ItemType.GunCOM15) return DamageTypes.Com15;
						if (fr.WeaponType == ItemType.GunCOM18) return DamageTypes.Com18;
						if (fr.WeaponType == ItemType.GunCrossvec) return DamageTypes.CrossVec;
						if (fr.WeaponType == ItemType.GunE11SR) return DamageTypes.E11SR;
						if (fr.WeaponType == ItemType.GunFSP9) return DamageTypes.FSP9;
						if (fr.WeaponType == ItemType.GunLogicer) return DamageTypes.Logicer;
						if (fr.WeaponType == ItemType.GunRevolver) return DamageTypes.Revolver;
						if (fr.WeaponType == ItemType.GunShotgun) return DamageTypes.Shotgun;
					}
					break;
				case ScpDamageHandler sr:
					{
						if (sr._translationId == 0) return DamageTypes.Recontainment;
						if (sr._translationId == 1) return DamageTypes.Nuke;
						if (sr._translationId == 2) return DamageTypes.Scp049;
						if (sr._translationId == 4) return DamageTypes.Asphyxiation;
						if (sr._translationId == 5) return DamageTypes.Bleeding;
						if (sr._translationId == 6) return DamageTypes.Falldown;
						if (sr._translationId == 7) return DamageTypes.Pocket;
						if (sr._translationId == 8) return DamageTypes.Decont;
						if (sr._translationId == 9) return DamageTypes.Poison;
						if (sr._translationId == 10) return DamageTypes.Scp207;
						if (sr._translationId == 11) return DamageTypes.SeveredHands;
						if (sr._translationId == 12) return DamageTypes.MicroHid;
						if (sr._translationId == 13) return DamageTypes.Tesla;
						if (sr._translationId == 14) return DamageTypes.Explosion;
						if (sr._translationId == 15) return DamageTypes.Scp096;
						if (sr._translationId == 16) return DamageTypes.Scp173;
						if (sr._translationId == 17) return DamageTypes.Scp939;
						if (sr._translationId == 18) return DamageTypes.Scp0492;
						if (sr._translationId == 20) return DamageTypes.Wall;
						if (sr._translationId == 21) return DamageTypes.Contain;
						if (sr._translationId == 22) return DamageTypes.FriendlyFireDetector;
					}
					break;
				case WarheadDamageHandler _: return DamageTypes.Nuke;
				case Scp096DamageHandler _: return DamageTypes.Scp096;
				case Scp018DamageHandler _: return DamageTypes.Scp018;
				case RecontainmentDamageHandler _: return DamageTypes.Recontainment;
				case MicroHidDamageHandler _: return DamageTypes.MicroHid;
				case ExplosionDamageHandler _: return DamageTypes.Explosion;
				default: return DamageTypes.None;
			}
			return DamageTypes.None;
		}
		public static ItemType GetItemType(this AmmoType type)
		{
			return type switch
			{
				AmmoType.Ammo556 => ItemType.Ammo556x45,
				AmmoType.Ammo762 => ItemType.Ammo762x39,
				AmmoType.Ammo9 => ItemType.Ammo9x19,
				AmmoType.Ammo12Gauge => ItemType.Ammo12gauge,
				AmmoType.Ammo44Cal => ItemType.Ammo44cal,
				_ => ItemType.None,
			};
		}
		public static AmmoType GetAmmoType(this ItemType type)
		{
			return type switch
			{
				ItemType.Ammo9x19 => AmmoType.Ammo9,
				ItemType.Ammo556x45 => AmmoType.Ammo556,
				ItemType.Ammo762x39 => AmmoType.Ammo762,
				ItemType.Ammo12gauge => AmmoType.Ammo12Gauge,
				ItemType.Ammo44cal => AmmoType.Ammo44Cal,
				_ => AmmoType.None,
			};
		}
		public static Type Type(this EffectType effect)
		{
			return effect switch
			{
				EffectType.Amnesia => typeof(Amnesia),
				EffectType.Asphyxiated => typeof(Asphyxiated),
				EffectType.Bleeding => typeof(Bleeding),
				EffectType.Blinded => typeof(Blinded),
				EffectType.BodyshotReduction => typeof(BodyshotReduction),
				EffectType.Burned => typeof(Burned),
				EffectType.Concussed => typeof(Concussed),
				EffectType.Corroding => typeof(Corroding),
				EffectType.DamageReduction => typeof(DamageReduction),
				EffectType.Deafened => typeof(Deafened),
				EffectType.Decontaminating => typeof(Decontaminating),
				EffectType.Disabled => typeof(Disabled),
				EffectType.Ensnared => typeof(Ensnared),
				EffectType.Exhausted => typeof(Exhausted),
				EffectType.Flashed => typeof(Flashed),
				EffectType.Hemorrhage => typeof(Hemorrhage),
				EffectType.Hypothermia => typeof(Hypothermia),
				EffectType.Invigorated => typeof(Invigorated),
				EffectType.Invisible => typeof(Invisible),
				EffectType.MovementBoost => typeof(MovementBoost),
				EffectType.Poisoned => typeof(Poisoned),
				EffectType.RainbowTaste => typeof(RainbowTaste),
				EffectType.Scp207 => typeof(Scp207),
				EffectType.SeveredHands => typeof(SeveredHands),
				EffectType.SinkHole => typeof(SinkHole),
				EffectType.Stained => typeof(Stained),
				EffectType.Visuals939 => typeof(Visuals939),
				EffectType.Vitality => typeof(Vitality),
				_ => throw new InvalidOperationException("Invalid effect enum provided"),
			};
		}
		public static EffectType GetEffectType(this PlayerEffect ef)
		{
			return ef switch
			{
				Amnesia _ => EffectType.Amnesia,
				Asphyxiated _ => EffectType.Asphyxiated,
				Bleeding _ => EffectType.Bleeding,
				Blinded _ => EffectType.Blinded,
				BodyshotReduction _ => EffectType.BodyshotReduction,
				Burned _ => EffectType.Burned,
				Concussed _ => EffectType.Concussed,
				Corroding _ => EffectType.Corroding,
				DamageReduction _ => EffectType.DamageReduction,
				Deafened _ => EffectType.Deafened,
				Decontaminating _ => EffectType.Decontaminating,
				Disabled _ => EffectType.Disabled,
				Ensnared _ => EffectType.Ensnared,
				Exhausted _ => EffectType.Exhausted,
				Flashed _ => EffectType.Flashed,
				Hemorrhage _ => EffectType.Hemorrhage,
				Hypothermia _ => EffectType.Hypothermia,
				Invigorated _ => EffectType.Invigorated,
				Invisible _ => EffectType.Invisible,
				MovementBoost _ => EffectType.MovementBoost,
				Poisoned _ => EffectType.Poisoned,
				RainbowTaste _ => EffectType.RainbowTaste,
				Scp207 _ => EffectType.Scp207,
				SeveredHands _ => EffectType.SeveredHands,
				SinkHole _ => EffectType.SinkHole,
				Stained _ => EffectType.Stained,
				Visuals939 _ => EffectType.Visuals939,
				Vitality _ => EffectType.Vitality,
				_ => EffectType.None,
			};
		}
		public static System.Random Random { get; } = new System.Random();
		public static void Shuffle<T>(this IList<T> list)
		{
			RNGCryptoServiceProvider provider = new();
			int n = list.Count;
			while (n > 1)
			{
				byte[] box = new byte[1];
				do provider.GetBytes(box);
				while (!(box[0] < n * (byte.MaxValue / n)));
				int k = (box[0] % n);
				n--;
				(list[n], list[k]) = (list[k], list[n]);
			}
		}
		public static void CopyProperties(this object target, object source)
		{
			Type type = target.GetType();
			if (type != source.GetType()) return;
			foreach (PropertyInfo sourceProperty in type.GetProperties())
				type.GetProperty(sourceProperty.Name)?.SetValue(target, sourceProperty.GetValue(source, null), null);
		}
		public static void Reload(this IConfig cfg) => CustomConfigsManager.Load(cfg);
	}
}