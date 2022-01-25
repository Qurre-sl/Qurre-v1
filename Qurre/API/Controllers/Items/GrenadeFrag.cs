namespace Qurre.API.Controllers.Items
{
    public class GrenadeFrag : Throwable
    {
        public GrenadeFrag(global::InventorySystem.Items.ThrowableProjectiles.ThrowableItem itemBase);

        public Player Player { get; set; }
        public float MaxRadius { get; set; }
        public float ScpMultiplier { get; set; }
        public float BurnDuration { get; set; }
        public float DeafenDuration { get; set; }
        public float ConcussDuration { get; set; }
        public float FuseTime { get; set; }

        public void Spawn(global::UnityEngine.Vector3 position, global::UnityEngine.Vector3 rotation = null, global::UnityEngine.Vector3 scale = null);
    }
}