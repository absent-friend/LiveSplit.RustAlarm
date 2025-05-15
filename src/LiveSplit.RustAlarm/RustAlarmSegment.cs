using LiveSplit.Model;
using LiveSplit.RustAlarm.UI;
using LiveSplit.TimeFormatters;
using LiveSplit.UI;
using LiveSplit.UI.Components;
using System;
using System.Collections.Generic;
using System.Drawing;
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
        private static readonly Brush WARNING_COLOR = new SolidBrush(Color.Yellow);

        private ISegment _segment;
        private string _name;
        private decimal _failRate;
        private TimeSpan? _maxTimeLoss;
        private int _previousFailureCount;
        private int _failureCount;
        private bool _newlyRusty;
        private readonly RustAlarmSettings _settings;
        private readonly SimpleLabel _nameLabel;
        private readonly GraphicsCache _cache;

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
        
        public string Name {
            get => _name;
            private set
            {
                _name = value;
            }
        }

        public decimal FailRate {
            get => _failRate; 
            set
            {
                if (_failRate != value)
                {
                    _failRate = value;
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

        public int WarningThreshold { get; set; } = 4;

        public int DangerThreshold { get; set; } = 7;

        internal RustAlarmSegment(RustAlarmSettings settings)
        {
            _failRate = 50m;
            _failureCount = 0;
            _newlyRusty = false;
            _settings = settings;
            _nameLabel = new();
            _cache = new();
            
            MinimumHeight = 25;
        }

        internal bool Reset()
        {
            bool wasClean = !IsRusty();
            _failureCount++;
            bool isRusty = IsRusty();
            _newlyRusty = wasClean && isRusty;
            return _newlyRusty;
        }

        internal bool Split()
        {
            bool wasRusty = IsRusty();
            _failureCount = 0;
            bool isClean = !IsRusty();
            return wasRusty && isClean;
        }

        internal void Undo()
        {
            bool wasClean = !IsRusty();
            _failureCount = _previousFailureCount;
            bool isRusty = IsRusty();
            _newlyRusty = wasClean && isRusty;
        }

        internal void RunEnded()
        {
            _previousFailureCount = _failureCount;
        }

        internal bool IsRusty()
        {
            return _failureCount >= WarningThreshold;
        }

        internal string UpdateName()
        {
            string oldName = _name;
            _name = Segment.Name;
            _nameLabel.Text = Name;
            return oldName;
        }

        private void PrepareDraw(LiveSplitState state, LayoutMode mode)
        {
            _nameLabel.Font = state.LayoutSettings.TextFont;
            _nameLabel.ForeColor = state.LayoutSettings.TextColor;
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
            g.FillRectangle(WARNING_COLOR, HorizontalWidth - PaddingRight - warningSize, height - textHeight, warningSize, warningSize);
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
            g.FillRectangle(WARNING_COLOR, width - PaddingRight - textHeight, VerticalHeight - PaddingBottom - textHeight, textHeight, textHeight);
        }

        public void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
        {
            _cache.Restart();
            _cache["NameText"] = _nameLabel.Text;
            if (invalidator != null && (_cache.HasChanged || _newlyRusty))
            {
                invalidator.Invalidate(0, 0, width, height);
                _newlyRusty = false;
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
