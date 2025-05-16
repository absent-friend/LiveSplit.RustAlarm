using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using LiveSplit.Model;
using LiveSplit.UI;

namespace LiveSplit.RustAlarm.UI;

internal partial class RustAlarmSettings : UserControl
{
    private static readonly Font DEFAULT_CUSTOM_FONT = new("Segoe UI", 16, FontStyle.Regular, GraphicsUnit.Pixel);

    private readonly RustAlarmIDMapper _idMapper;
    private readonly Dictionary<string, Dictionary<int, RustAlarmSegment>> _segmentCache;
    private readonly BindingSource _segmentsGridData;
    private IRun _currentRun;

    public bool OverrideSegmentsFont { get; set; }

    public Font SegmentsFont { get; set; } = DEFAULT_CUSTOM_FONT;

    public string SegmentsFontString => SettingsHelper.FormatFont(SegmentsFont);

    public bool OverrideSegmentsColor { get; set; }

    public Color SegmentsColor { get; set; } = Color.White;

    public Color WarningColor { get; set; } = Color.Yellow;

    public Color DangerColor { get; set; } = Color.Red;

    public bool OverrideTitleFont { get; set; }

    public Font TitleFont { get; set; } = DEFAULT_CUSTOM_FONT;

    public string TitleFontString => SettingsHelper.FormatFont(TitleFont);

    public bool OverrideTitleColor { get; set; }

    public Color TitleColor { get; set; } = Color.White;

    public bool OverrideCountFont { get; set; }

    public Font CountFont { get; set; } = DEFAULT_CUSTOM_FONT;

    public string CountFontString => SettingsHelper.FormatFont(CountFont);

    public bool OverrideCountColor { get; set; }

    public Color CountColor { get; set; } = Color.White;

    public Color BackgroundColor1 { get; set; } = Color.Transparent;

    public Color BackgroundColor2 { get; set; } = Color.Transparent;

    public GradientType BackgroundGradient { get; set; } = GradientType.Plain;

    public string BackgroundGradientString
    {
        get => BackgroundGradient.ToString();
        set
        {
            BackgroundGradient = (GradientType)Enum.Parse(typeof(GradientType), value);
        }
    }

    internal RustAlarmSettings()
    {
        InitializeComponent();

        _idMapper = new();
        _segmentCache = [];
        _segmentsGridData = [];

        cmbBackgroundGradientType.Items.Add(GradientType.Plain.ToString());
        cmbBackgroundGradientType.Items.Add(GradientType.Horizontal.ToString());
        cmbBackgroundGradientType.Items.Add(GradientType.Vertical.ToString());

        chkSegmentsFont.DataBindings.Add(nameof(chkSegmentsFont.Checked), this, nameof(OverrideSegmentsFont), false, DataSourceUpdateMode.OnPropertyChanged);
        lblSegmentsFont.DataBindings.Add(nameof(lblSegmentsFont.Text), this, nameof(SegmentsFontString), false, DataSourceUpdateMode.OnPropertyChanged);
        lblSegmentsFont.DataBindings.Add(nameof(lblSegmentsFont.Visible), this, nameof(OverrideSegmentsFont), true, DataSourceUpdateMode.OnPropertyChanged);
        btnSegmentsFont.DataBindings.Add(nameof(btnSegmentsFont.Enabled), this, nameof(OverrideSegmentsFont), false, DataSourceUpdateMode.OnPropertyChanged);
        chkSegmentsColor.DataBindings.Add(nameof(chkSegmentsColor.Checked), this, nameof(OverrideSegmentsColor), false, DataSourceUpdateMode.OnPropertyChanged);
        btnSegmentsColor.DataBindings.Add(nameof(btnSegmentsColor.BackColor), this, nameof(SegmentsColor), false, DataSourceUpdateMode.OnPropertyChanged);
        btnSegmentsColor.DataBindings.Add(nameof(btnSegmentsColor.Visible), this, nameof(OverrideSegmentsColor), false, DataSourceUpdateMode.OnPropertyChanged);
        btnWarningColor.DataBindings.Add(nameof(btnWarningColor.BackColor), this, nameof(WarningColor), false, DataSourceUpdateMode.OnPropertyChanged);
        btnDangerColor.DataBindings.Add(nameof(btnDangerColor.BackColor), this, nameof(DangerColor), false, DataSourceUpdateMode.OnPropertyChanged);
        chkTitleFont.DataBindings.Add(nameof(chkTitleFont.Checked), this, nameof(OverrideTitleFont), false, DataSourceUpdateMode.OnPropertyChanged);
        lblTitleFont.DataBindings.Add(nameof(lblTitleFont.Text), this, nameof(TitleFontString), false, DataSourceUpdateMode.OnPropertyChanged);
        lblTitleFont.DataBindings.Add(nameof(lblTitleFont.Visible), this, nameof(OverrideTitleFont), false, DataSourceUpdateMode.OnPropertyChanged);
        btnTitleFont.DataBindings.Add(nameof(btnTitleFont.Enabled), this, nameof(OverrideTitleFont), false, DataSourceUpdateMode.OnPropertyChanged);
        chkTitleColor.DataBindings.Add(nameof(chkTitleColor.Checked), this, nameof(OverrideTitleColor), false, DataSourceUpdateMode.OnPropertyChanged);
        btnTitleColor.DataBindings.Add(nameof(btnTitleColor.BackColor), this, nameof(TitleColor), false, DataSourceUpdateMode.OnPropertyChanged);
        btnTitleColor.DataBindings.Add(nameof(btnTitleColor.Visible), this, nameof(OverrideTitleColor), false, DataSourceUpdateMode.OnPropertyChanged);
        chkCountFont.DataBindings.Add(nameof(chkCountFont.Checked), this, nameof(OverrideCountFont), false, DataSourceUpdateMode.OnPropertyChanged);
        lblCountFont.DataBindings.Add(nameof(lblCountFont.Text), this, nameof(CountFontString), false, DataSourceUpdateMode.OnPropertyChanged);
        lblCountFont.DataBindings.Add(nameof(lblCountFont.Visible), this, nameof(OverrideCountFont), false, DataSourceUpdateMode.OnPropertyChanged);
        btnCountFont.DataBindings.Add(nameof(btnCountFont.Enabled), this, nameof(OverrideCountFont), false, DataSourceUpdateMode.OnPropertyChanged);
        chkCountColor.DataBindings.Add(nameof(chkCountColor.Checked), this, nameof(OverrideCountColor), false, DataSourceUpdateMode.OnPropertyChanged);
        btnCountColor.DataBindings.Add(nameof(btnCountColor.BackColor), this, nameof(CountColor), false, DataSourceUpdateMode.OnPropertyChanged);
        btnCountColor.DataBindings.Add(nameof(btnCountColor.Visible), this, nameof(OverrideCountColor), false, DataSourceUpdateMode.OnPropertyChanged);
        btnBackgroundColor1.DataBindings.Add(nameof(btnBackgroundColor1.BackColor), this, nameof(BackgroundColor1), false, DataSourceUpdateMode.OnPropertyChanged);
        btnBackgroundColor2.DataBindings.Add(nameof(btnBackgroundColor2.BackColor), this, nameof(BackgroundColor2), false, DataSourceUpdateMode.OnPropertyChanged);
        cmbBackgroundGradientType.DataBindings.Add(nameof(cmbBackgroundGradientType.SelectedItem), this, nameof(BackgroundGradientString), false, DataSourceUpdateMode.OnPropertyChanged);

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
            segment.OnThresholdChange.Invoke(null, null);
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

    private void btnSegmentsFont_Click(object sender, EventArgs e)
    {
        CustomFontDialog.FontDialog dialog = SettingsHelper.GetFontDialog(SegmentsFont, 11, 26);
        dialog.FontChanged += (s, ev) => SegmentsFont = ((CustomFontDialog.FontChangedEventArgs)ev).NewFont;
        dialog.ShowDialog(this);
        lblSegmentsFont.Text = SegmentsFontString;
    }

    private void btnTitleFont_Click(object sender, EventArgs e)
    {
        CustomFontDialog.FontDialog dialog = SettingsHelper.GetFontDialog(TitleFont, 11, 26);
        dialog.FontChanged += (s, ev) => TitleFont = ((CustomFontDialog.FontChangedEventArgs)ev).NewFont;
        dialog.ShowDialog(this);
        lblTitleFont.Text = TitleFontString;
    }

    private void btnCountFont_Click(object sender, EventArgs e)
    {
        CustomFontDialog.FontDialog dialog = SettingsHelper.GetFontDialog(CountFont, 11, 26);
        dialog.FontChanged += (s, ev) => CountFont = ((CustomFontDialog.FontChangedEventArgs)ev).NewFont;
        dialog.ShowDialog(this);
        lblCountFont.Text = CountFontString;
    }

    private void ColorButtonClick(object sender, EventArgs e)
    {
        SettingsHelper.ColorButtonClick((Button)sender, this);
    }

    private void cmbBackgroundGradientType_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnBackgroundColor1.Visible = cmbBackgroundGradientType.SelectedItem.ToString() != GradientType.Plain.ToString();
        btnBackgroundColor2.DataBindings.Clear();
        string backColorBindProperty = btnBackgroundColor1.Visible ? nameof(BackgroundColor2) : nameof(BackgroundColor1);
        btnBackgroundColor2.DataBindings.Add(nameof(btnBackgroundColor2.BackColor), this, backColorBindProperty, false, DataSourceUpdateMode.OnPropertyChanged);
    }
}
