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
        public static event main.AllEvents<API.Events.GrenadeExplodeEvent> GrenadeExplode;

        public static void announcementdecontamination(AnnouncementDecontaminationEvent ev);
        public static void lczdecon(LCZDeconEvent ev);
        public static void mtfAnnouncement(MTFAnnouncementEvent ev);
        public static void newblood(NewBloodEvent ev);
        public static void newdecal(NewDecalEvent ev);
        public static void OnGenerated();
        public static void grenadeexplode(API.Events.GrenadeExplodeEvent ev);
    }
}