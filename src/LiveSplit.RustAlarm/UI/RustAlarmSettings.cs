using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using LiveSplit.Model;

namespace LiveSplit.RustAlarm.UI;

internal partial class RustAlarmSettings : UserControl
{
    private readonly Size _initialSize;
    private readonly RustAlarmIDMapper _idMapper;
    private readonly Dictionary<string, Dictionary<int, RustAlarmSegmentSettings>> _settings;
    private readonly Dictionary<string, Dictionary<int, RustAlarmSegment>> _segmentCache;
    private IRun _currentRun;

    internal RustAlarmSettings()
    {
        InitializeComponent();
        _initialSize = Size;

        _idMapper = new();
        _settings = [];
        _segmentCache = [];
    }

    internal XmlNode GetSettings(XmlDocument document)
    {
        var parent = document.CreateElement("Settings");
        BuildSettingsXML(document, parent);
        return parent;
    }

    internal int GetSettingsHashCode()
    {
        return BuildSettingsXML(null, null);
    }

    private int BuildSettingsXML(XmlDocument document, XmlNode parent)
    {
        int hashCode = 0;
        foreach (KeyValuePair<string, Dictionary<int, RustAlarmSegmentSettings>> run in _settings)
        {
            hashCode ^= run.Key.GetHashCode();
            XmlNode runParent = null;
            if (document != null)
            {
                runParent = document.CreateElement("Run");
                XmlAttribute runPath = document.CreateAttribute("Key");
                runPath.Value = run.Key;
                runParent.Attributes.Append(runPath);
                parent.AppendChild(runParent);
            }

            foreach (KeyValuePair<int, RustAlarmSegmentSettings> segment in run.Value)
            {
                hashCode ^= segment.Key.GetHashCode();
                XmlNode segmentParent = null;
                if (document != null)
                {
                    segmentParent = document.CreateElement("Segment");
                    XmlAttribute segmentName = document.CreateAttribute("Key");
                    segmentName.Value = segment.Key.ToString();
                    segmentParent.Attributes.Append(segmentName);
                    runParent.AppendChild(segmentParent);
                }

                hashCode ^= segment.Value.RustThreshold.GetHashCode();
                if (document != null)
                {
                    XmlNode rustThreshold = document.CreateElement("RustThreshold");
                    XmlAttribute rustThresholdValue = document.CreateAttribute("Value");
                    rustThresholdValue.Value = segment.Value.RustThreshold.ToString();
                    rustThreshold.Attributes.Append(rustThresholdValue);
                    segmentParent.AppendChild(rustThreshold);
                }
            }
        }
        return hashCode;
    }

    internal void SetSettings(XmlNode settings)
    {
        if (settings is not XmlElement element)
            return;

        foreach (XmlNode run in element.ChildNodes)
        {
            string runKey = run.Attributes["Key"].Value;
            Dictionary<int, RustAlarmSegmentSettings> runSettings = GetOrCreateSettingsMap(runKey);
            
            foreach (XmlNode segment in run.ChildNodes)
            {
                int segmentKey = int.Parse(segment.Attributes["Key"].Value);
                RustAlarmSegmentSettings segmentSettings = GetOrCreateSegmentSettings(segmentKey, runSettings);

                XmlNode rustThreshold = segment["RustThreshold"];
                if (int.TryParse(rustThreshold.Attributes["Value"].Value, out int threshold)) {
                    segmentSettings.RustThreshold = threshold;
                }
            }
        }
    }

    internal RustAlarmSegment GetOrCreateSegment(ISegment segment)
    {
        Dictionary<int, RustAlarmSegment> segmentCache = SegmentCache();
        int key = _idMapper.GetID(segment);
        if (!segmentCache.TryGetValue(key, out RustAlarmSegment alarmSegment))
        {
            alarmSegment = new RustAlarmSegment(segment, GetOrCreateSegmentSettings(key, CurrentSettings()));
            segmentCache[key] = alarmSegment;
        }
        return alarmSegment;
    }

    internal void CheckForNameChange(RustAlarmSegment segment)
    {
        string oldName = segment.UpdateName();
        string newName = segment.Segment.Name;
        if (oldName != newName)
        {
            _idMapper.Remap(oldName, newName);
        }
    }

    internal void SetRun(IRun run)
    {
        _currentRun = run;
        _idMapper.SetRun(run);

        Size = _initialSize;
        tableLayoutSegments.Controls.Clear();
        tableLayoutSegments.RowCount = _currentRun.Count;
        Dictionary<int, RustAlarmSegmentSettings> runSettings = CurrentSettings();
        int i = 0;
        foreach (ISegment segment in _currentRun)
        {
            RustAlarmSegmentSettings segmentSettings = GetOrCreateSegmentSettings(_idMapper.GetID(segment), runSettings);
            tableLayoutSegments.Controls.Add(segmentSettings, 0, i++);
            tableLayoutSegments.RowStyles.Add(new RowStyle(SizeType.AutoSize));
        }
    }

    private RustAlarmSegmentSettings GetOrCreateSegmentSettings(int segmentKey, Dictionary<int, RustAlarmSegmentSettings> runSettings)
    {
        if (!runSettings.TryGetValue(segmentKey, out RustAlarmSegmentSettings settings))
        {
            settings = new();
            runSettings[segmentKey] = settings;
        }
        return settings;
    }

    private string Key(IRun run)
    {
        return run.FilePath;
    }

    private Dictionary<int, RustAlarmSegment> SegmentCache()
    {
        string key = Key(_currentRun);
        if (!_segmentCache.TryGetValue(key, out Dictionary<int, RustAlarmSegment> segmentCache))
        {
            segmentCache = [];
            _segmentCache[key] = segmentCache;
        }
        return segmentCache;
    }

    private Dictionary<int, RustAlarmSegmentSettings> GetOrCreateSettingsMap(string runKey)
    {
        if (!_settings.TryGetValue(runKey, out Dictionary<int, RustAlarmSegmentSettings> runSettings))
        {
            runSettings = [];
            _settings[runKey] = runSettings;
        }
        return runSettings;
    }

    private Dictionary<int, RustAlarmSegmentSettings> CurrentSettings()
    {
        return GetOrCreateSettingsMap(Key(_currentRun));
    }
}
