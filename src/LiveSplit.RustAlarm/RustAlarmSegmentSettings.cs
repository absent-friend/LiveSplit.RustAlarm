using System;
using System.Windows.Forms;

namespace LiveSplit.RustAlarm
{
    public partial class RustAlarmSegmentSettings : UserControl, IRustAlarmSegmentSettings
    {
        private string _name;

        public RustAlarmSegmentSettings()
        {
            InitializeComponent();
            textRustThreshold.DataBindings.Add(nameof(textRustThreshold.Text), this, nameof(RustThreshold), false, DataSourceUpdateMode.OnPropertyChanged);
        }
        
        // 4 = shortest coinflip failure streak w/ < 10% odds
        public int RustThreshold { get; set; } = 4;

        public string SetName(string name)
        {
            string oldName = _name;
            _name = name;
            groupBox.Text = $"Segment: {name}";
            return oldName;
        }
    }
}
