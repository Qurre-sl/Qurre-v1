namespace Qurre.API.Objects
{
    public enum AmmoType : byte
    {
        None,
        /// <summary>
        /// Used by <see cref="ItemType.GunE11SR"/>
        /// </summary>
        Ammo556,
        /// <summary>
        /// Used by and <see cref="ItemType.GunLogicer"/>
        /// </summary>
        Ammo762,
        /// <summary>
        /// Used by <see cref="ItemType.GunCOM15"/>
        /// </summary>
        Ammo9,
        /// <summary>
        /// Used by <see cref="ItemType.GunShotgun"/>
        /// </summary>
        Ammo12Gauge,
        /// <summary>
        /// 44 caliber.
        /// </summary>
        Ammo44Cal,
    }
}