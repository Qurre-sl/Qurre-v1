using Qurre.API.Events;
using Qurre.Events.Modules;
using static Qurre.Events.Modules.Main;
namespace Qurre.Events
{
    public static class Map
    {
        public static event AllEvents<LczDeconEvent> LczDecon;
        public static event AllEvents<LczAnnounceEvent> LczAnnounce;
        public static event AllEvents<MTFAnnouncementEvent> MTFAnnouncement;
        public static event AllEvents<NewBloodEvent> NewBlood;
        public static event AllEvents<PlaceBulletHoleEvent> PlaceBulletHole;
        public static event AllEvents Generated;
        public static event AllEvents<SetSeedEvent> SetSeed;
        public static event AllEvents<DoorDamageEvent> DoorDamage;
        public static event AllEvents<DoorLockEvent> DoorLock;
        public static event AllEvents<DoorOpenEvent> DoorOpen;
        public static event AllEvents<UseLiftEvent> UseLift;
        public static event AllEvents<ScpDeadAnnouncementEvent> ScpDeadAnnouncement;
        public static event AllEvents<CreatePickupEvent> CreatePickup;
        public static event AllEvents<ConvertUnitNameEvent> ConvertUnitName;
        internal static void Invokes(LczDeconEvent ev) => LczDecon?.CustomInvoke(ev);
        internal static void Invokes(LczAnnounceEvent ev) => LczAnnounce?.CustomInvoke(ev);
        internal static void Invokes(MTFAnnouncementEvent ev) => MTFAnnouncement?.CustomInvoke(ev);
        internal static void Invokes(NewBloodEvent ev) => NewBlood?.CustomInvoke(ev);
        internal static void Invokes(PlaceBulletHoleEvent ev) => PlaceBulletHole?.CustomInvoke(ev);
        internal static void Invokes() => Generated.CustomInvoke();
        internal static void Invokes(SetSeedEvent ev) => SetSeed?.CustomInvoke(ev);
        internal static void Invokes(DoorDamageEvent ev) => DoorDamage?.CustomInvoke(ev);
        internal static void Invokes(DoorLockEvent ev) => DoorLock?.CustomInvoke(ev);
        internal static void Invokes(DoorOpenEvent ev) => DoorOpen?.CustomInvoke(ev);
        internal static void Invokes(UseLiftEvent ev) => UseLift?.CustomInvoke(ev);
        internal static void Invokes(ScpDeadAnnouncementEvent ev) => ScpDeadAnnouncement?.CustomInvoke(ev);
        internal static void Invokes(CreatePickupEvent ev) => CreatePickup?.CustomInvoke(ev);
        internal static void Invokes(ConvertUnitNameEvent ev) => ConvertUnitName?.CustomInvoke(ev);
    }
}