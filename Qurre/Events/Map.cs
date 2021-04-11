using Qurre.API.Events;
using Qurre.Events.modules;
namespace Qurre.Events
{
    public static class Map
    {
        public static event main.AllEvents<LCZDeconEvent> LCZDecon;
        public static event main.AllEvents<AnnouncementDecontaminationEvent> AnnouncementDecontaminationZDecon;
        public static event main.AllEvents<MTFAnnouncementEvent> MTFAnnouncement;
        public static event main.AllEvents<NewBloodEvent> NewBlood;
        public static event main.AllEvents<NewDecalEvent> NewDecal;
        public static event main.AllEvents Generated;
        public static event main.AllEvents<GrenadeExplodeEvent> GrenadeExplode;
        public static event main.AllEvents<SetSeedEvent> SetSeed;

        public static void announcementdecontamination(AnnouncementDecontaminationEvent ev);
        public static void generated();
        public static void grenadeexplode(GrenadeExplodeEvent ev);
        public static void lczdecon(LCZDeconEvent ev);
        public static void mtfAnnouncement(MTFAnnouncementEvent ev);
        public static void newblood(NewBloodEvent ev);
        public static void newdecal(NewDecalEvent ev);
        public static void setSeed(SetSeedEvent ev);
    }
}