using System;
namespace Qurre.API.Events
{
    public class LCZDeconEvent : EventArgs
    {
        public LCZDeconEvent(bool isAllowed = true);

        public bool IsAllowed { get; set; }
    }
    public class AnnouncementDecontaminationEvent : EventArgs
    {
        public AnnouncementDecontaminationEvent(int announcementId, bool isGlobal, bool isAllowed = true);

        public int Id { get; set; }
        public bool IsGlobal { get; set; }
        public bool IsAllowed { get; set; }
    }
    public class MTFAnnouncementEvent : EventArgs
    {
        public MTFAnnouncementEvent(int scpsLeft, string unitName, int unitNumber, bool isAllowed = true);

        public int ScpsLeft { get; }
        public string UnitName { get; set; }
        public int UnitNumber { get; set; }
        public bool IsAllowed { get; set; }
    }
    public class NewBloodEvent : EventArgs
    {
        public NewBloodEvent(ReferenceHub player, global::UnityEngine.Vector3 position, int type, float multiplier, bool isAllowed = true);

        public ReferenceHub Player { get; }
        public global::UnityEngine.Vector3 Position { get; set; }
        public int Type { get; set; }
        public float Multiplier { get; set; }
        public bool IsAllowed { get; set; }
    }
    public class NewDecalEvent : EventArgs
    {
        public NewDecalEvent(ReferenceHub owner, global::UnityEngine.Vector3 position, global::UnityEngine.Quaternion rotation, int type, bool isAllowed = true);

        public ReferenceHub Owner { get; }
        public global::UnityEngine.Vector3 Position { get; set; }
        public global::UnityEngine.Quaternion Rotation { get; set; }
        public int Type { get; set; }
        public bool IsAllowed { get; set; }
    }
    public class Grenade
    {
        public Grenade();

        public class ExplodeEvent : EventArgs
        {
            public ExplodeEvent(ReferenceHub thrower, System.Collections.Generic.Dictionary<ReferenceHub, float> targetToDamages, bool isFrag, global::UnityEngine.GameObject grenade, bool isAllowed = true);

            public ReferenceHub Thrower { get; }
            public System.Collections.Generic.Dictionary<ReferenceHub, float> TargetToDamages { get; }
            public System.Collections.Generic.List<ReferenceHub> Targets { get; }
            public bool IsFrag { get; }
            public global::UnityEngine.GameObject Grenade { get; }
            public bool IsAllowed { get; set; }
        }
    }
}