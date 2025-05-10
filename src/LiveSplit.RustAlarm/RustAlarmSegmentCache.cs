using LiveSplit.Model;
using System.Collections.Generic;

namespace LiveSplit.RustAlarm
{
    internal class RustAlarmSegmentCache
    {
        private readonly Dictionary<string, RustAlarmSegment> _segments = [];
        private string _prefix = "";

        public RustAlarmSegment GetOrCreate(ISegment segment)
        {
            if (!_segments.TryGetValue(_prefix + segment.Name, out RustAlarmSegment alarmSegment))
            {
                alarmSegment = new RustAlarmSegment(segment);
                _segments[_prefix + segment.Name] = alarmSegment;
            }
            return alarmSegment;
        }

        public void Set(ISegment segment, RustAlarmSegment alarmSegment)
        {
            _segments[_prefix + segment.Name] = alarmSegment;
        }

        public void SetRun(IRun run)
        {
            _prefix = run.FilePath + "#";
        }
    }
}
