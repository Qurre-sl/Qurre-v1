using Qurre.API.Events;
using Qurre.Events.modules;
namespace Qurre.Events
{
    public static class Map
    {
        public static event Main.AllEvents<LCZDeconEvent> LCZDecon;
        public static event Main.AllEvents<AnnouncementDecontaminationEvent> AnnouncementDecontaminationZDecon;
        public static event Main.AllEvents<MTFAnnouncementEvent> MTFAnnouncement;
        public static event Main.AllEvents<NewBloodEvent> NewBlood;
        public static event Main.AllEvents<NewDecalEvent> NewDecal;
        public static event Main.AllEvents Generated;
        public static event Main.AllEvents<GrenadeExplodeEvent> GrenadeExplode;
        public static event Main.AllEvents<SetSeedEvent> SetSeed;
        public static event Main.AllEvents<DoorDamageEvent> DoorDamage;
        public static event Main.AllEvents<DoorLockEvent> DoorLock;
        public static event Main.AllEvents<DoorOpenEvent> DoorOpen;
        public static event Main.AllEvents<UseLiftEvent> UseLift;
    }
}