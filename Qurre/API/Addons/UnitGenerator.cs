using Respawning;
using System.Collections.Generic;
namespace Qurre.API.Addons
{
    public struct UnitGenerator
    {
        public readonly SpawnableTeamType Team;
        public readonly List<string> Units;
        public int MaxCode
        {
            get
            {
                if (_maxCode < 0) return Round.UnitMaxCode;
                return _maxCode;
            }
            set
            {
                if (value < 0) value = -1;
                _maxCode = value;
            }
        }
        private int _maxCode = -1;
        internal UnitGenerator(SpawnableTeamType team, List<string> units, int maxCode = -1)
        {
            Team = team;
            Units = units;
            MaxCode = maxCode;
        }
    }
}