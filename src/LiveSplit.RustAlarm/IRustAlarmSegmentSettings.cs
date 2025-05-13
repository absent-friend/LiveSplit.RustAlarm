namespace LiveSplit.RustAlarm
{
    public interface IRustAlarmSegmentSettings
    {
        int RustThreshold { get; }
        string SetName(string name);
    }
}
