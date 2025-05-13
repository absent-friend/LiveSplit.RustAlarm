using LiveSplit.Model;
using System.Collections.Generic;

namespace LiveSplit.RustAlarm
{
    internal class RustAlarmIDMapper
    {
        private readonly Dictionary<string, RustAlarmIDMap> _idMaps = [];
        private RustAlarmIDMap _currentMap;

        internal void SetRun(IRun run)
        {
            if (!_idMaps.TryGetValue(run.FilePath, out _currentMap))
            {
                _currentMap = new RustAlarmIDMap(run);
                _idMaps[run.FilePath] = _currentMap;
            }
        }

        internal int GetID(ISegment segment)
        {
            return _currentMap.GetID(segment);
        }

        internal void Remap(string oldName, string newName)
        {
            _currentMap.Remap(oldName, newName);
        }
    }
}
