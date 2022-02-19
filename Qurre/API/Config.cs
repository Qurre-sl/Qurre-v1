using Qurre.API.Modules;
using Qurre.API.Objects;
namespace Qurre.API
{
    public class Config
    {
        internal ConfigManager ConfigManager { get; private set; }
        internal Config() => ConfigManager = new ConfigManager();
        public void Reload() => ConfigManager.Reload();
        public bool GetBool(string key, bool default_value, string comment = "") => ConfigManager.GetBool(key, default_value, comment);
        public byte GetByte(string key, byte default_value, string comment = "") => ConfigManager.GetByte(key, default_value, comment);
        public char GetChar(string key, char default_value, string comment = "") => ConfigManager.GetChar(key, default_value, comment);
        public decimal GetDecimal(string key, decimal default_value, string comment = "") => ConfigManager.GetDecimal(key, default_value, comment);
        public double GetDouble(string key, double default_value, string comment = "") => ConfigManager.GetDouble(key, default_value, comment);
        public float GetFloat(string key, float default_value, string comment = "") => ConfigManager.GetFloat(key, default_value, comment);
        public int GetInt(string key, int default_value, string comment = "") => ConfigManager.GetInt(key, default_value, comment);
        public long GetLong(string key, long default_value, string comment = "") => ConfigManager.GetLong(key, default_value, comment);
        public sbyte GetSByte(string key, sbyte default_value, string comment = "") => ConfigManager.GetSByte(key, default_value, comment);
        public short GetShort(string key, short default_value, string comment = "") => ConfigManager.GetShort(key, default_value, comment);
        public string GetString(string key, string default_value, string comment = "") => ConfigManager.GetString(key, default_value, comment);
        public uint GetUInt(string key, uint default_value, string comment = "") => ConfigManager.GetUInt(key, default_value, comment);
        public ulong GetULong(string key, ulong default_value, string comment = "") => ConfigManager.GetULong(key, default_value, comment);
        public ushort GetUShort(string key, ushort default_value, string comment = "") => ConfigManager.GetUShort(key, default_value, comment);
        public object Get(ConfigObjects obj, string key, object def, string comment = "")
        {
            string _key = key;
            if (obj == ConfigObjects.Bool) return ConfigManager.GetBool(_key, (bool)def, comment);
            else if (obj == ConfigObjects.Byte) return ConfigManager.GetByte(_key, (byte)def, comment);
            else if (obj == ConfigObjects.Char) return ConfigManager.GetChar(_key, (char)def, comment);
            else if (obj == ConfigObjects.Decimal) return ConfigManager.GetDecimal(_key, (decimal)def, comment);
            else if (obj == ConfigObjects.Double) return ConfigManager.GetDouble(_key, (double)def, comment);
            else if (obj == ConfigObjects.Float) return ConfigManager.GetFloat(_key, (float)def, comment);
            else if (obj == ConfigObjects.Int) return ConfigManager.GetInt(_key, (int)def, comment);
            else if (obj == ConfigObjects.Long) return ConfigManager.GetLong(_key, (long)def, comment);
            else if (obj == ConfigObjects.Sbyte) return ConfigManager.GetSByte(_key, (sbyte)def, comment);
            else if (obj == ConfigObjects.Short) return ConfigManager.GetShort(_key, (short)def, comment);
            else if (obj == ConfigObjects.String) return ConfigManager.GetString(_key, (string)def, comment);
            else if (obj == ConfigObjects.Uint) return ConfigManager.GetUInt(_key, (uint)def, comment);
            else if (obj == ConfigObjects.Ulong) return ConfigManager.GetULong(_key, (ulong)def, comment);
            else if (obj == ConfigObjects.Ushort) return ConfigManager.GetUShort(_key, (ushort)def, comment);
            else return def;
        }
    }
}