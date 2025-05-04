using LiveSplit.Model;
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

        private static readonly Brush WARNING_COLOR = new SolidBrush(Color.Yellow);

        private int _resetCounter;
        private int _resetThreshold;
        private bool _forceDraw;
        private readonly SimpleLabel _nameLabel;
        private readonly GraphicsCache _cache;

        internal ISegment Segment { get; set; }

        public float MinimumWidth => 20f;

        public float HorizontalWidth { get; private set; }

        public float MinimumHeight { get; private set; }

        public float VerticalHeight { get; private set; }

        public float PaddingTop { get; private set; }

        public float PaddingBottom { get; private set; }

        public float PaddingLeft => 7f;

        public float PaddingRight => 7f;

        internal RustAlarmSegment(ISegment segment)
        {
            _resetCounter = 0;
            _resetThreshold = 3;
            _forceDraw = false;
            Segment = segment;
            _nameLabel = new(segment.Name);
            _cache = new();
            MinimumHeight = 25;
        }

        internal (bool, bool) AddReset()
        {
            bool wasClean = !IsRusty();
            _resetCounter++;
            bool isRusty = IsRusty();
            if (wasClean && isRusty)
            {
                _forceDraw = true;
            }
            return (wasClean, isRusty);
        }

        internal (bool, bool) Split()
        {
            bool wasRusty = IsRusty();
            _resetCounter = 0;
            bool isClean = !IsRusty();
            return (wasRusty, isClean);
        }

        internal bool IsRusty()
        {
            return _resetCounter >= _resetThreshold;
        }

        private void PrepareDraw(LiveSplitState state, LayoutMode mode)
        {
            _nameLabel.Text = Segment.Name;
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
            _cache["NameText"] = Segment.Name;
            if (invalidator != null && (_cache.HasChanged || _forceDraw))
            {
                invalidator.Invalidate(0, 0, width, height);
                _forceDraw = false;
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
