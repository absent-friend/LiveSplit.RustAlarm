#warning TODO: Allow configuration of thresholds, font + text color overrides

using System.Windows.Forms;
using System.Xml;
using LiveSplit.UI;

namespace LiveSplit.RustAlarm.UI;

public partial class RustAlarmSettings : UserControl
{
    public RustAlarmSettings()
    {
        InitializeComponent();

        // _sampleCheckBox.DataBindings.Add(nameof(CheckBox.Checked), this, nameof(SampleValue1), false, DataSourceUpdateMode.OnPropertyChanged);
    }

    // public bool SampleValue1 { get; private set; }
    // public string SampleValue2 { get; private set; }

    public XmlNode GetSettings(XmlDocument document)
    {
        var parent = document.CreateElement("Settings");
        return parent;
    }

    public void SetSettings(XmlNode settings)
    {
        if (settings is not XmlElement element)
            return;

        // SampleValue1 = SettingsHelper.ParseBool(element[nameof(SampleValue1)]);
        // SampleValue2 = SettingsHelper.ParseString(element[nameof(SampleValue2)]);
    }

    private int CreateSettingsNodes(XmlDocument document, XmlElement parent)
    {
        // return SettingsHelper.CreateSetting(document, parent, nameof(SampleValue1), SampleValue1)
        //     ^ SettingsHelper.CreateSetting(document, parent, nameof(SampleValue2), SampleValue2);
        return 0;
    }
}
