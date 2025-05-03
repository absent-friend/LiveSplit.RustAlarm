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

        internal int rustCounter;
        internal int rustThreshold;
        private readonly SimpleLabel _nameLabel;
        private readonly GraphicsCache _cache;

        public float HorizontalWidth { get; set; }

        public float MinimumHeight { get; set; }

        public float VerticalHeight { get; set; }

        public float MinimumWidth => 20f;

        public float PaddingTop { get; set; }

        public float PaddingBottom { get; set; }

        public float PaddingLeft => 7f;

        public float PaddingRight => 7f;

        internal bool DisplayTwoRows => false;

        public IDictionary<string, Action> ContextMenuControls => null;

        internal RustAlarmSegment(string segmentName)
        {
            rustCounter = 0;
            rustThreshold = 3;
            _nameLabel = new(segmentName);
            _cache = new();
            MinimumHeight = 25;
        }

        internal bool IsRusty()
        {
            return rustCounter >= rustThreshold;
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
