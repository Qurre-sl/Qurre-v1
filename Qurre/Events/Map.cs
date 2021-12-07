using Qurre.API.Events;
using Qurre.Events.Modules;
namespace Qurre.Events
{
    public static class Map
    {
        public static event Main.AllEvents<LczDeconEvent> LczDecon;
        public static event Main.AllEvents<LczAnnounceEvent> LczAnnounce;
        public static event Main.AllEvents<MTFAnnouncementEvent> MTFAnnouncement;
        public static event Main.AllEvents<NewBloodEvent> NewBlood;
        public static event Main.AllEvents<PlaceBulletHoleEvent> PlaceBulletHole;
        public static event Main.AllEvents Generated;
        public static event Main.AllEvents<SetSeedEvent> SetSeed;
        public static event Main.AllEvents<DoorDamageEvent> DoorDamage;
        public static event Main.AllEvents<DoorLockEvent> DoorLock;
        public static event Main.AllEvents<DoorOpenEvent> DoorOpen;
        public static event Main.AllEvents<UseLiftEvent> UseLift;
        public static event Main.AllEvents<ScpDeadAnnouncementEvent> ScpDeadAnnouncement;
        public static event Main.AllEvents<CreatePickupEvent> CreatePickup;
        public static event Main.AllEvents<ConvertUnitNameEvent> ConvertUnitName;
    }
}