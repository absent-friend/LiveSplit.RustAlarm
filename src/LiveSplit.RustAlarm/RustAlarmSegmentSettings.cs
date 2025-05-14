using System;
using System.Windows.Forms;

namespace LiveSplit.RustAlarm
{
    public class RustAlarmSegmentSettings : IRustAlarmSegmentSettings
    {
        private string _name;
        
        // 4 = shortest coinflip failure streak w/ < 10% odds
        public int RustThreshold { get; set; } = 4;

        public string SetName(string name)
        {
            string oldName = _name;
            _name = name;
            return oldName;
        }
    }
}
