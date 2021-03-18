namespace Qurre.API.Controllers
{
    public class Scp096
    {
        public bool Is096 { get; }
        public float ShieldAmount { get; set; }
        public float CurMaxShield { get; set; }
        public float EnrageTimeLeft { get; set; }
        public global::PlayableScps.Scp096PlayerState RageState { get; set; }
        public List<Player> Targets { get; }
        public bool CanAttack { get; }
        public bool CanCharge { get; }

        public void AddTarget(Player player);
        public void ChargeDoor(Door door);
        public void RemoveTarget(Player player);
    }
}
