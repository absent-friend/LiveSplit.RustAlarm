using LiveSplit.Model;
using LiveSplit.UI.Components;

namespace LiveSplit.RustAlarm
{
    internal class RustAlarmSegment
    {
        private static readonly System.Drawing.Brush WARNING_COLOR = new System.Drawing.SolidBrush(System.Drawing.Color.Yellow);

        internal int rustCounter;
        internal int rustThreshold;
        internal readonly InfoTextComponent infoText;

        internal RustAlarmSegment(string segmentName)
        {
            rustCounter = 0;
            rustThreshold = 3;
            infoText = new InfoTextComponent(segmentName, "⚠");
            infoText.ValueLabel.Brush = WARNING_COLOR;
        }

        internal bool IsRusty()
        {
            return rustCounter >= rustThreshold;
        }
    }
}
