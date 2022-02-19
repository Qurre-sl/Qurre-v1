namespace Qurre.API.Objects
{
    public enum KeycardPermissions : ushort
    {
        None = 0,
        Checkpoints = 1,
        ExitGates = 2,
        Intercom = 4,
        AlphaWarhead = 8,
        /// <summary>
        /// Safe SCP.
        /// </summary>
        ContainmentLevelOne = 16,
        /// <summary>
        /// <see cref="ContainmentLevelOne"/>, <see cref="Checkpoints"/>.
        /// </summary>
        ContainmentLevelTwo = 32, // 0x0020
        /// <summary>
        /// <see cref="ContainmentLevelTwo"/>, <see cref="Intercom"/>, <see cref="AlphaWarhead"/>.
        /// </summary>
        ContainmentLevelThree = 64, // 0x0040
        /// <summary>
        /// <see cref="Checkpoints"/>, Opens Light Containment armory.
        /// </summary>
        ArmoryLevelOne = 128, // 0x0080
        /// <summary>
        /// <see cref="ArmoryLevelOne"/>, <see cref="ExitGates"/>, Opens Heavy Containment armories.
        /// </summary>
        ArmoryLevelTwo = 256, // 0x0100
        /// <summary>
        /// <see cref="ArmoryLevelTwo"/>, <see cref="Intercom"/>, Opens MicroHID room.
        /// </summary>
        ArmoryLevelThree = 512, // 0x0200
        /// <summary>
        /// <see cref="Checkpoints"/>.
        /// </summary>
        ScpOverride = 1024, // 0x0400
    }
}