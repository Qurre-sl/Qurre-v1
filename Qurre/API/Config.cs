namespace Qurre.API
{
    public class Config
    {
        public object Get(ConfigObjects obj, string key, object def, string comment = "");
        public bool GetBool(string key, bool default_value, string comment = "");
        public byte GetByte(string key, byte default_value, string comment = "");
        public char GetChar(string key, char default_value, string comment = "");
        public decimal GetDecimal(string key, decimal default_value, string comment = "");
        public double GetDouble(string key, double default_value, string comment = "");
        public float GetFloat(string key, float default_value, string comment = "");
        public int GetInt(string key, int default_value, string comment = "");
        public long GetLong(string key, long default_value, string comment = "");
        public sbyte GetSByte(string key, sbyte default_value, string comment = "");
        public short GetShort(string key, short default_value, string comment = "");
        public string GetString(string key, string default_value, string comment = "");
        public uint GetUInt(string key, uint default_value, string comment = "");
        public ulong GetULong(string key, ulong default_value, string comment = "");
        public ushort GetUShort(string key, ushort default_value, string comment = "");
        public void Reload();
    }
}