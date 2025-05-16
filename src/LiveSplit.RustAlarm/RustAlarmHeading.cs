using LiveSplit.Model;
using LiveSplit.RustAlarm.UI;
using LiveSplit.TimeFormatters;
using LiveSplit.UI;
using LiveSplit.UI.Components;

namespace LiveSplit.RustAlarm
{
    internal class RustAlarmHeading(string informationName, string informationValue, RustAlarmSettings settings) : InfoTextComponent(informationName, informationValue)
    {
        private readonly RustAlarmSettings _settings = settings;
        private int _rustCount;

        public override void PrepareDraw(LiveSplitState state, LayoutMode mode)
        {
            base.PrepareDraw(state, mode);
            
            NameMeasureLabel.Font = _settings.OverrideTitleFont ? _settings.TitleFont : state.LayoutSettings.TextFont;
            NameLabel.Font = _settings.OverrideTitleFont ? _settings.TitleFont : state.LayoutSettings.TextFont;
            NameLabel.ForeColor = _settings.OverrideTitleColor ? _settings.TitleColor : state.LayoutSettings.TextColor;
            NameLabel.OutlineColor = state.LayoutSettings.TextOutlineColor;
            NameLabel.ShadowColor = state.LayoutSettings.ShadowsColor;
            ValueLabel.Font = _settings.OverrideCountFont ? _settings.CountFont : state.LayoutSettings.TextFont;
            ValueLabel.ForeColor = _settings.OverrideCountColor ? _settings.CountColor : state.LayoutSettings.TextColor;
            ValueLabel.OutlineColor = state.LayoutSettings.TextOutlineColor;
            ValueLabel.ShadowColor = state.LayoutSettings.ShadowsColor;
        }

        internal int RustCount
        {
            get => _rustCount;
            set
            {
                _rustCount = value;
                ValueLabel.Text = _rustCount == 0 ? TimeFormatConstants.DASH : _rustCount.ToString();
            }
        }
    }
}
