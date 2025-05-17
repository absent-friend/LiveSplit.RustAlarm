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
    internal static readonly Version VERSION = new(0, 5);
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
        lblSegmentsFont.DataBindings.Add(nameof(lblSegmentsFont.Enabled), this, nameof(OverrideSegmentsFont), true, DataSourceUpdateMode.OnPropertyChanged);
        btnSegmentsFont.DataBindings.Add(nameof(btnSegmentsFont.Enabled), this, nameof(OverrideSegmentsFont), false, DataSourceUpdateMode.OnPropertyChanged);
        chkSegmentsColor.DataBindings.Add(nameof(chkSegmentsColor.Checked), this, nameof(OverrideSegmentsColor), false, DataSourceUpdateMode.OnPropertyChanged);
        btnSegmentsColor.DataBindings.Add(nameof(btnSegmentsColor.BackColor), this, nameof(SegmentsColor), false, DataSourceUpdateMode.OnPropertyChanged);
        btnSegmentsColor.DataBindings.Add(nameof(btnSegmentsColor.Enabled), this, nameof(OverrideSegmentsColor), false, DataSourceUpdateMode.OnPropertyChanged);
        btnWarningColor.DataBindings.Add(nameof(btnWarningColor.BackColor), this, nameof(WarningColor), false, DataSourceUpdateMode.OnPropertyChanged);
        btnDangerColor.DataBindings.Add(nameof(btnDangerColor.BackColor), this, nameof(DangerColor), false, DataSourceUpdateMode.OnPropertyChanged);
        chkTitleFont.DataBindings.Add(nameof(chkTitleFont.Checked), this, nameof(OverrideTitleFont), false, DataSourceUpdateMode.OnPropertyChanged);
        lblTitleFont.DataBindings.Add(nameof(lblTitleFont.Text), this, nameof(TitleFontString), false, DataSourceUpdateMode.OnPropertyChanged);
        lblTitleFont.DataBindings.Add(nameof(lblTitleFont.Enabled), this, nameof(OverrideTitleFont), false, DataSourceUpdateMode.OnPropertyChanged);
        btnTitleFont.DataBindings.Add(nameof(btnTitleFont.Enabled), this, nameof(OverrideTitleFont), false, DataSourceUpdateMode.OnPropertyChanged);
        chkTitleColor.DataBindings.Add(nameof(chkTitleColor.Checked), this, nameof(OverrideTitleColor), false, DataSourceUpdateMode.OnPropertyChanged);
        btnTitleColor.DataBindings.Add(nameof(btnTitleColor.BackColor), this, nameof(TitleColor), false, DataSourceUpdateMode.OnPropertyChanged);
        btnTitleColor.DataBindings.Add(nameof(btnTitleColor.Enabled), this, nameof(OverrideTitleColor), false, DataSourceUpdateMode.OnPropertyChanged);
        chkCountFont.DataBindings.Add(nameof(chkCountFont.Checked), this, nameof(OverrideCountFont), false, DataSourceUpdateMode.OnPropertyChanged);
        lblCountFont.DataBindings.Add(nameof(lblCountFont.Text), this, nameof(CountFontString), false, DataSourceUpdateMode.OnPropertyChanged);
        lblCountFont.DataBindings.Add(nameof(lblCountFont.Enabled), this, nameof(OverrideCountFont), false, DataSourceUpdateMode.OnPropertyChanged);
        btnCountFont.DataBindings.Add(nameof(btnCountFont.Enabled), this, nameof(OverrideCountFont), false, DataSourceUpdateMode.OnPropertyChanged);
        chkCountColor.DataBindings.Add(nameof(chkCountColor.Checked), this, nameof(OverrideCountColor), false, DataSourceUpdateMode.OnPropertyChanged);
        btnCountColor.DataBindings.Add(nameof(btnCountColor.BackColor), this, nameof(CountColor), false, DataSourceUpdateMode.OnPropertyChanged);
        btnCountColor.DataBindings.Add(nameof(btnCountColor.Enabled), this, nameof(OverrideCountColor), false, DataSourceUpdateMode.OnPropertyChanged);
        btnBackgroundColor1.DataBindings.Add(nameof(btnBackgroundColor1.BackColor), this, nameof(BackgroundColor1), false, DataSourceUpdateMode.OnPropertyChanged);
        btnBackgroundColor2.DataBindings.Add(nameof(btnBackgroundColor2.BackColor), this, nameof(BackgroundColor2), false, DataSourceUpdateMode.OnPropertyChanged);
        cmbBackgroundGradientType.DataBindings.Add(nameof(cmbBackgroundGradientType.SelectedItem), this, nameof(BackgroundGradientString), false, DataSourceUpdateMode.OnPropertyChanged);

        dataGridSegments.AutoGenerateColumns = false;
        dataGridSegments.DataSource = _segmentsGridData;
        dataGridSegments_Name.DataPropertyName = "DisplayName";
        dataGridSegments_FailRate.DataPropertyName = "FailRateString";
        dataGridSegments_MaxTimeLoss.DataPropertyName = "MaxTimeLossString";
        dataGridSegments_WarningThreshold.DataPropertyName = "WarningThreshold";
        dataGridSegments_DangerThreshold.DataPropertyName = "DangerThreshold";
        
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

    private int BuildSettingsXML(XmlDocument document, XmlElement parent)
    {
        int hashCode = SettingsHelper.CreateSetting(document, parent, "Version", VERSION) 
                ^ SettingsHelper.CreateSetting(document, parent, "OverrideSegmentsFont", OverrideSegmentsFont)
                ^ SettingsHelper.CreateSetting(document, parent, "SegmentsFont", SegmentsFont)
                ^ SettingsHelper.CreateSetting(document, parent, "OverrideSegmentsColor", OverrideSegmentsColor)
                ^ SettingsHelper.CreateSetting(document, parent, "SegmentsColor", SegmentsColor)
                ^ SettingsHelper.CreateSetting(document, parent, "WarningColor", WarningColor)
                ^ SettingsHelper.CreateSetting(document, parent, "DangerColor", DangerColor)
                ^ SettingsHelper.CreateSetting(document, parent, "OverrideTitleFont", OverrideTitleFont)
                ^ SettingsHelper.CreateSetting(document, parent, "TitleFont", TitleFont)
                ^ SettingsHelper.CreateSetting(document, parent, "OverrideTitleColor", OverrideTitleColor)
                ^ SettingsHelper.CreateSetting(document, parent, "TitleColor", TitleColor)
                ^ SettingsHelper.CreateSetting(document, parent, "OverrideCountFont", OverrideCountFont)
                ^ SettingsHelper.CreateSetting(document, parent, "CountFont", CountFont)
                ^ SettingsHelper.CreateSetting(document, parent, "OverrideCountColor", OverrideCountColor)
                ^ SettingsHelper.CreateSetting(document, parent, "CountColor", CountColor)
                ^ SettingsHelper.CreateSetting(document, parent, "BackgroundColor1", BackgroundColor1)
                ^ SettingsHelper.CreateSetting(document, parent, "BackgroundColor2", BackgroundColor2)
                ^ SettingsHelper.CreateSetting(document, parent, "BackgroundGradient", BackgroundGradient);

        foreach (KeyValuePair<string, Dictionary<int, RustAlarmSegment>> run in _segmentCache)
        {
            XmlElement runParent = document?.CreateElement("Run");
            parent?.AppendChild(runParent);
            hashCode ^= SettingsHelper.CreateSetting(document, runParent, "Key", run.Key);

            foreach (KeyValuePair<int, RustAlarmSegment> segment in run.Value)
            {
                XmlElement segmentParent = document?.CreateElement("Segment");
                runParent?.AppendChild(segmentParent);
                hashCode ^= SettingsHelper.CreateSetting(document, segmentParent, "Key", segment.Key)
                    ^ SettingsHelper.CreateSetting(document, segmentParent, "FailRate", segment.Value.FailRateString)
                    ^ SettingsHelper.CreateSetting(document, segmentParent, "WarningThreshold", segment.Value.WarningThreshold)
                    ^ SettingsHelper.CreateSetting(document, segmentParent, "DangerThreshold", segment.Value.DangerThreshold)
                    ^ SettingsHelper.CreateSetting(document, segmentParent, "MaxTimeLoss", segment.Value.MaxTimeLossString);
            }
        }
        return hashCode;
    }

    internal void SetSettings(XmlNode settings)
    {
        if (settings is not XmlElement element)
            return;

        OverrideSegmentsFont = SettingsHelper.ParseBool(element["OverrideSegmentsFont"]);
        SegmentsFont = SettingsHelper.GetFontFromElement(element["SegmentsFont"]);
        OverrideSegmentsColor = SettingsHelper.ParseBool(element["OverrideSegmentsColor"]);
        SegmentsColor = SettingsHelper.ParseColor(element["SegmentsColor"]);
        WarningColor = SettingsHelper.ParseColor(element["WarningColor"]);
        DangerColor = SettingsHelper.ParseColor(element["DangerColor"]);
        OverrideTitleFont = SettingsHelper.ParseBool(element["OverrideTitleFont"]);
        TitleFont = SettingsHelper.GetFontFromElement(element["TitleFont"]);
        OverrideTitleColor = SettingsHelper.ParseBool(element["OverrideTitleColor"]);
        TitleColor = SettingsHelper.ParseColor(element["TitleColor"]);
        OverrideCountFont = SettingsHelper.ParseBool(element["OverrideCountFont"]);
        CountFont = SettingsHelper.GetFontFromElement(element["CountFont"]);
        OverrideCountColor = SettingsHelper.ParseBool(element["OverrideCountColor"]);
        CountColor = SettingsHelper.ParseColor(element["CountColor"]);
        BackgroundColor1 = SettingsHelper.ParseColor(element["BackgroundColor1"]);
        BackgroundColor2 = SettingsHelper.ParseColor(element["BackgroundColor2"]);
        BackgroundGradient = SettingsHelper.ParseEnum<GradientType>(element["BackgroundGradient"]);

        XmlNode run = element["Run"];
        while (run != null)
        {
            string runKey = SettingsHelper.ParseString(run["Key"]);
            Dictionary<int, RustAlarmSegment> segmentCache = GetOrCreateSegmentCache(runKey);

            XmlNode segment = run["Segment"];
            while (segment != null)
            {
                int segmentKey = SettingsHelper.ParseInt(segment["Key"]);
                RustAlarmSegment alarmSegment = GetOrCreateSegment(segmentKey, segmentCache);
                alarmSegment.FailRateString = SettingsHelper.ParseString(segment["FailRate"]);
                alarmSegment.WarningThreshold = SettingsHelper.ParseInt(segment["WarningThreshold"]);
                alarmSegment.DangerThreshold = SettingsHelper.ParseInt(segment["DangerThreshold"]);
                alarmSegment.MaxTimeLossString = SettingsHelper.ParseString(segment["MaxTimeLoss"]);

                segment = segment.NextSibling;
            }

            run = run.NextSibling;
        }
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
        RebuildSegmentsGrid();
    }

    internal void RebuildSegmentsGrid()
    {
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
        if (dataGridSegments_FailRate.Index == e.ColumnIndex
            && !string.IsNullOrWhiteSpace(e.FormattedValue.ToString())
            && (!decimal.TryParse(e.FormattedValue.ToString(), out decimal failRate) || failRate <= 0m || failRate >= 100m))
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

    private void FontOrColorBoxChecked(object sender, EventArgs e)
    {
        CheckBox checkBox = (CheckBox)sender;
        checkBox.ForeColor = checkBox.Checked ? SystemColors.ControlText : SystemColors.GrayText;
    }

    private void linkSettingsGuide_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
        System.Diagnostics.Process.Start("https://github.com/absent-friend/LiveSplit.RustAlarm/wiki/Settings-Guide");
    }
}
