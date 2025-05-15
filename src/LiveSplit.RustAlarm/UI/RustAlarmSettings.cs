using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;
using LiveSplit.Model;

namespace LiveSplit.RustAlarm.UI;

internal partial class RustAlarmSettings : UserControl
{
    private readonly RustAlarmIDMapper _idMapper;
    private readonly Dictionary<string, Dictionary<int, RustAlarmSegment>> _segmentCache;
    private readonly BindingSource _segmentsGridData;
    private IRun _currentRun;

    internal RustAlarmSettings()
    {
        InitializeComponent();

        _idMapper = new();
        _segmentCache = [];
        _segmentsGridData = [];

        dataGridSegments.AutoGenerateColumns = false;
        dataGridSegments.DataSource = _segmentsGridData;
        dataGridSegments_Name.DataPropertyName = "Name";
        dataGridSegments_FailRate.DataPropertyName = "FailRate";
        dataGridSegments_MaxTimeLoss.DataPropertyName = "MaxTimeLossString";
        dataGridSegments_WarningThreshold.DataPropertyName = "WarningThreshold";
        dataGridSegments_DangerThreshold.DataPropertyName = "DangerThreshold";
        
        dataGridSegments.CellEndEdit += dataGridSegments_CellEndEdit;
        dataGridSegments.CellValidated += dataGridSegments_CellValidated;
        dataGridSegments.CellValidating += dataGridSegments_CellValidating;
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
        foreach (KeyValuePair<string, Dictionary<int, RustAlarmSegment>> run in _segmentCache)
        {
            //hashCode ^= run.Key.GetHashCode();
            //XmlNode runParent = null;
            //if (document != null)
            //{
            //    runParent = document.CreateElement("Run");
            //    XmlAttribute runPath = document.CreateAttribute("Key");
            //    runPath.Value = run.Key;
            //    runParent.Attributes.Append(runPath);
            //    parent.AppendChild(runParent);
            //}

            //foreach (KeyValuePair<int, RustAlarmSegment> segment in run.Value)
            //{
            //    hashCode ^= segment.Key.GetHashCode();
            //    XmlNode segmentParent = null;
            //    if (document != null)
            //    {
            //        segmentParent = document.CreateElement("Segment");
            //        XmlAttribute segmentName = document.CreateAttribute("Key");
            //        segmentName.Value = segment.Key.ToString();
            //        segmentParent.Attributes.Append(segmentName);
            //        runParent.AppendChild(segmentParent);
            //    }

            //    hashCode ^= segment.Value.WarningThreshold.GetHashCode();
            //    if (document != null)
            //    {
            //        XmlNode rustThreshold = document.CreateElement("RustThreshold");
            //        XmlAttribute rustThresholdValue = document.CreateAttribute("Value");
            //        rustThresholdValue.Value = segment.Value.WarningThreshold.ToString();
            //        rustThreshold.Attributes.Append(rustThresholdValue);
            //        segmentParent.AppendChild(rustThreshold);
            //    }
            //}
        }
        return hashCode;
    }

    internal void SetSettings(XmlNode settings)
    {
        if (settings is not XmlElement element)
            return;

        //foreach (XmlNode run in element.ChildNodes)
        //{
        //    string runKey = run.Attributes["Key"].Value;
        //    Dictionary<int, RustAlarmSegment> segmentCache = GetOrCreateSegmentCache(runKey);
            
        //    foreach (XmlNode segment in run.ChildNodes)
        //    {
        //        int segmentKey = int.Parse(segment.Attributes["Key"].Value);
        //        RustAlarmSegment alarmSegment = GetOrCreateSegment(segmentKey, segmentCache);

        //        XmlNode rustThreshold = segment["WarningThreshold"];
        //        if (int.TryParse(rustThreshold.Attributes["Value"].Value, out int threshold)) {
        //            alarmSegment.WarningThreshold = threshold;
        //        }
        //    }
        //}
    }

    private Dictionary<int, RustAlarmSegment> GetOrCreateSegmentCache(string runKey)
    {
        if (!_segmentCache.TryGetValue(runKey, out Dictionary<int, RustAlarmSegment> segmentCache))
        {
            segmentCache = [];
            _segmentCache[runKey] = segmentCache;
        }
        return segmentCache;
    }

    private RustAlarmSegment GetOrCreateSegment(int segmentKey, Dictionary<int, RustAlarmSegment> segmentCache)
    {
        if (!segmentCache.TryGetValue(segmentKey, out RustAlarmSegment alarmSegment))
        {
            alarmSegment = new RustAlarmSegment(this);
            segmentCache[segmentKey] = alarmSegment;
        }
        return alarmSegment;
    }

    internal RustAlarmSegment GetOrCreateSegment(ISegment segment)
    {
        RustAlarmSegment alarmSegment = GetOrCreateSegment(_idMapper.GetID(segment), SegmentCache());
        alarmSegment.Segment = segment;
        return alarmSegment;
    }

    internal void CheckForNameChange(RustAlarmSegment segment)
    {
        string oldName = segment.UpdateName();
        string newName = segment.Name;
        if (oldName != newName)
        {
            _idMapper.Remap(oldName, newName);
        }
    }

    internal void SetRun(IRun run)
    {
        _currentRun = run;
        _idMapper.SetRun(run);

        _segmentsGridData.Clear();
        foreach (ISegment segment in _currentRun)
        {
            _segmentsGridData.Add(GetOrCreateSegment(segment));
        }
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

    private void dataGridSegments_CellEndEdit(object sender, DataGridViewCellEventArgs e)
    {
        dataGridSegments.Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = String.Empty;
    }

    private void dataGridSegments_CellValidated(object sender, DataGridViewCellEventArgs e)
    {
        if (dataGridSegments_DangerThreshold.Index == e.ColumnIndex || dataGridSegments_WarningThreshold.Index == e.ColumnIndex)
        {
            RustAlarmSegment segment = _segmentsGridData[e.RowIndex] as RustAlarmSegment;
            if (segment.DangerThreshold <= segment.WarningThreshold)
            {
                segment.DangerThreshold = segment.WarningThreshold + 1;
            }
        }
    }

    private void dataGridSegments_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
    {
        DataGridViewCell cell = dataGridSegments.Rows[e.RowIndex].Cells[e.ColumnIndex];
        if (dataGridSegments_FailRate.Index == e.ColumnIndex && (!decimal.TryParse(e.FormattedValue.ToString(), out decimal failRate) || failRate <= 0m || failRate >= 100m))
        {
            e.Cancel = true;
        }
        else if (dataGridSegments_MaxTimeLoss.Index == e.ColumnIndex)
        {
            try
            {
                TimeSpanParser.ParseNullable(e.FormattedValue.ToString());
            } 
            catch
            {
                e.Cancel = true;
            }
        }
        else if (dataGridSegments_WarningThreshold.Index == e.ColumnIndex && (!int.TryParse(e.FormattedValue.ToString(), out int warningThreshold) || warningThreshold < 1))
        {
            e.Cancel = true;
        }
        else if (dataGridSegments_DangerThreshold.Index == e.ColumnIndex && (!int.TryParse(e.FormattedValue.ToString(), out int dangerThreshold) || dangerThreshold < 1))
        {
            e.Cancel = true;
        }
    }
}
