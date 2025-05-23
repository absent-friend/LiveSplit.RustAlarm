﻿using LiveSplit.Model;
using LiveSplit.RustAlarm.UI;
using LiveSplit.TimeFormatters;
using LiveSplit.UI;
using LiveSplit.UI.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace LiveSplit.RustAlarm
{
    internal class RustAlarmSegment : IComponent
    {
        // Parts of this class were adapted from LiveSplit.UI.Components.InfoTextComponent.
        // Especially the drawing of the text, which involves some rather magical nummbers.

        private static readonly ShortTimeFormatterMilliseconds TIME_FORMATTER = new()
        {
            AutomaticPrecision = true,
        };
        private static readonly Regex SUBSPLIT_REGEX = new(@"^{(?<parent>.+)}\s*(?<split>.+)$", RegexOptions.Compiled);

        private ISegment _segment;
        private decimal _failRate;
        private TimeSpan? _maxTimeLoss;
        private int _previousFailureStreak;
        private int _failureStreak;
        private readonly RustAlarmSettings _settings;
        private readonly SimpleLabel _nameLabel;
        private readonly GraphicsCache _cache;

        internal EventHandler OnThresholdChange;

        internal ISegment Segment {
            get => _segment;
            set
            {
                if (_segment == null)
                {
                    _segment = value;
                    UpdateName();
                }
            }
        }

        public float MinimumWidth => 20f;

        public float HorizontalWidth { get; private set; }

        public float MinimumHeight { get; private set; }

        public float VerticalHeight { get; private set; }

        public float PaddingTop { get; private set; }

        public float PaddingBottom { get; private set; }

        public float PaddingLeft => 7f;

        public float PaddingRight => 7f;

        public string Name { get; private set; }

        public string DisplayName => CleanName();

        public string FailRateString
        {
            get => _failRate > 0m ? _failRate.ToString() : "";
            set
            {
                if (!decimal.TryParse(value, out decimal failRate))
                {
                    _failRate = 0m;
                }
                else if (_failRate != failRate)
                {
                    _failRate = failRate;
                    int streak = 1;
                    decimal failOdds = _failRate / 100m;
                    decimal streakOdds = failOdds;
                    while (streakOdds >= .1m)
                    {
                        streakOdds *= failOdds;
                        streak++;
                    }
                    WarningThreshold = streak;
                    while (streakOdds >= .01m)
                    {
                        streakOdds *= failOdds;
                        streak++;
                    }
                    DangerThreshold = streak;
                }
            }
        }

        public string MaxTimeLossString
        {
            get
            {
                return _maxTimeLoss == null ? "" : TIME_FORMATTER.Format(_maxTimeLoss);
            }
            set
            {
                _maxTimeLoss = TimeSpanParser.ParseNullable(value);
            }
        }

        public int WarningThreshold { get; set; } = 2;

        public int DangerThreshold { get; set; } = 4;

        private Color RustColor {
            get
            {
                if (_failureStreak >= DangerThreshold)
                {
                    return _settings.DangerColor;
                }
                else if (_failureStreak > WarningThreshold)
                {
                    return Interpolate(_settings.WarningColor, WarningThreshold, _settings.DangerColor, DangerThreshold);
                }
                else if (_failureStreak == WarningThreshold)
                {
                    return _settings.WarningColor;
                }
                else if (_failureStreak > 0)
                {
                    return Interpolate(_settings.CleanColor, 0, _settings.WarningColor, WarningThreshold);
                }
                else
                {
                    return _settings.CleanColor;
                }
            }
        }

        private Color Interpolate(Color start, int startThreshold, Color end, int endThreshold)
        {
            decimal t = (_failureStreak - startThreshold) / (decimal)(endThreshold - startThreshold);
            return Color.FromArgb(
                (int)((1 - t) * start.A + t * end.A),
                (int)((1 - t) * start.R + t * end.R),
                (int)((1 - t) * start.G + t * end.G),
                (int)((1 - t) * start.B + t * end.B));
        }

        internal RustAlarmSegment(RustAlarmSettings settings)
        {
            _failureStreak = 0;
            _settings = settings;
            _nameLabel = new();
            _cache = new();
            
            MinimumHeight = 25;
        }

        internal void Reset()
        {
            _failureStreak++;
        }

        internal void Split()
        {
            Split(null);
        }

        internal void Split(TimeSpan? delta)
        {
            if (delta != null && _maxTimeLoss != null && delta > _maxTimeLoss)
            {
                _failureStreak++;
            }
            else if (_maxTimeLoss == null || delta <= _maxTimeLoss)
            {
                _failureStreak = 0;
            }
        }

        internal void Undo()
        {
            _failureStreak = _previousFailureStreak;
        }

        internal void RunEnded()
        {
            _previousFailureStreak = _failureStreak;
        }

        internal bool IsRusty()
        {
            return _failureStreak >= WarningThreshold;
        }

        internal void ClearRust()
        {
            _failureStreak = 0;
        }

        internal string UpdateName()
        {
            string oldName = Name;
            Name = Segment.Name;
            _nameLabel.Text = CleanName();
            return oldName;
        }

        internal void LabelForRun()
        {
            _nameLabel.Text = "Rust Level";
        }

        internal void LabelForList()
        {
            _nameLabel.Text = CleanName();
        }

        private string CleanName()
        {
            Match subsplitMatch = SUBSPLIT_REGEX.Match(Name);
            if (subsplitMatch.Success)
            {
                return subsplitMatch.Groups["split"].Value;
            }
            else if (Name.StartsWith("-"))
            {
                return Name[1..];
            }
            else
            {
                return Name;
            }
        }

        private void PrepareDraw(LiveSplitState state, LayoutMode mode)
        {
            _nameLabel.Font = _settings.OverrideSegmentsFont ? _settings.SegmentsFont : state.LayoutSettings.TextFont;
            _nameLabel.ForeColor = _settings.OverrideSegmentsColor ? _settings.SegmentsColor : state.LayoutSettings.TextColor;
            _nameLabel.OutlineColor = state.LayoutSettings.TextOutlineColor;
            _nameLabel.ShadowColor = state.LayoutSettings.ShadowsColor;

            _nameLabel.HorizontalAlignment = mode == LayoutMode.Vertical ? StringAlignment.Near : StringAlignment.Far;
            _nameLabel.VerticalAlignment = mode == LayoutMode.Vertical ? StringAlignment.Center : StringAlignment.Near;
        }

        public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion)
        {
            PrepareDraw(state, LayoutMode.Horizontal);

            float textHeight = g.MeasureString("A", _nameLabel.Font).Height * 0.75f;
            MinimumHeight = 0.85f * g.MeasureString("A", _nameLabel.Font).Height * 2;
            PaddingBottom = PaddingTop = 0;

            _nameLabel.SetActualWidth(g);
            HorizontalWidth = _nameLabel.ActualWidth + 10;

            _nameLabel.Width = _nameLabel.ActualWidth + 2;
            _nameLabel.Height = height;
            _nameLabel.X = 5;
            _nameLabel.Y = 0;
            _nameLabel.Draw(g);

            float warningSize = textHeight * 0.65f;
            g.FillRectangle(new SolidBrush(RustColor), HorizontalWidth - PaddingRight - warningSize, height - textHeight, warningSize, warningSize);
        }

        public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion)
        {
            PrepareDraw(state, LayoutMode.Vertical);

            HorizontalWidth = width;
            VerticalHeight = 31;

            float textHeight = 0.75f * g.MeasureString("A", _nameLabel.Font).Height;
            PaddingTop = Math.Max(0, (VerticalHeight - textHeight) / 2f);
            PaddingBottom = PaddingTop;

            _nameLabel.Width = width - textHeight - 10;
            _nameLabel.Height = VerticalHeight;
            _nameLabel.X = 5;
            _nameLabel.Y = 0;

            _nameLabel.Draw(g);
            g.FillRectangle(new SolidBrush(RustColor), width - PaddingRight - textHeight, VerticalHeight - PaddingBottom - textHeight, textHeight, textHeight);
        }

        public void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {
            _cache.Restart();
            _cache["NameLabel"] = _nameLabel.Text;
            _cache["RustColor"] = RustColor;
            if (invalidator != null && _cache.HasChanged)
            {
                invalidator.Invalidate(0, 0, width, height);
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public string ComponentName => throw new NotSupportedException();

        public IDictionary<string, Action> ContextMenuControls => null;

        public Control GetSettingsControl(LayoutMode mode)
        {
            throw new NotImplementedException();
        }

        public XmlNode GetSettings(XmlDocument document)
        {
            throw new NotImplementedException();
        }

        public void SetSettings(XmlNode settings)
        {
            throw new NotImplementedException();
        }
    }
}
