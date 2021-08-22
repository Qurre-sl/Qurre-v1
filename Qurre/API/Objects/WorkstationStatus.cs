namespace Qurre.API.Objects
{
    public enum WorkstationStatus : byte
    {
        Offline = 0,
        BootingUp = 1,
        ShuttingDown = 2,
        Online = 3
    }
}