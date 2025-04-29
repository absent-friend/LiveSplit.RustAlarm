using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

using LiveSplit.Model;
using LiveSplit.RustAlarm.UI;
using LiveSplit.UI;
using LiveSplit.UI.Components;

namespace LiveSplit.RustAlarm;

public sealed class RustAlarmComponent : IComponent
{
    public const string Name = "Rust Alarm";

    private readonly LiveSplitState _state;
    private readonly RustAlarmSettings _settings;
    private List<RustAlarmSegment> _segments;
    private readonly InfoTextComponent _heading;
    private readonly ComponentRendererComponent _internalComponent;
    private int _skipStart;
    private int _segmentIndex;

    public RustAlarmComponent(LiveSplitState state)
    {
        _state = state;
        _settings = new();
        _segments = BuildSegments();
        _heading = new("Rusty Segments", "");
        _heading.NameLabel.HorizontalAlignment = StringAlignment.Center;
        _internalComponent = new()
        {
            VisibleComponents = _segments
                .Where(segment => segment.IsRusty())
                .Select(segment => segment.infoText)
                .Prepend(_heading)
        };

        SetUpEventListeners();
    }

    public string ComponentName => Name;

    public float HorizontalWidth => _internalComponent.HorizontalWidth;

    public float MinimumHeight => _internalComponent.MinimumHeight;

    public float VerticalHeight => _internalComponent.VerticalHeight;

    public float MinimumWidth => _internalComponent.MinimumWidth;

    public float PaddingTop => _internalComponent.PaddingTop;

    public float PaddingBottom => _internalComponent.PaddingBottom;

    public float PaddingLeft => _internalComponent.PaddingLeft;

    public float PaddingRight => _internalComponent.PaddingRight;

    public IDictionary<string, Action> ContextMenuControls => null;

    public void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
    {
        if (invalidator != null)
        {
            _internalComponent.Update(invalidator, state, width, height, mode);
        }
    }

    public XmlNode GetSettings(XmlDocument document)
    {
        return _settings.GetSettings(document);
    }

    public void SetSettings(XmlNode settings)
    {
        _settings.SetSettings(settings);
    }

    public Control GetSettingsControl(LayoutMode mode)
    {
        return _settings;
    }

    private void PrepareDraw(LiveSplitState state)
    {
        _heading.NameLabel.ForeColor = state.LayoutSettings.TextColor;
        foreach (RustAlarmSegment segment in _segments)
        {
            segment.infoText.NameLabel.ForeColor = state.LayoutSettings.TextColor;
        }
    }

    public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion)
    {
        PrepareDraw(state);
        _internalComponent.DrawHorizontal(g, state, height, clipRegion);
    }

    public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion)
    {
        PrepareDraw(state);
        _internalComponent.DrawVertical(g, state, width, clipRegion);
    }

    // Dispose is called when the component is removed from the layout or when the application is closed.
    // Clean up resources like file handles or event listeners here.
    public void Dispose()
    {
        _state.OnReset -= _state_OnReset;
        _state.OnSplit -= _state_OnSplit;
        _state.OnSkipSplit -= _state_OnSkipSplit;
        _state.RunManuallyModified -= _state_RunManuallyModified;
    }

    private void SetUpEventListeners()
    {
        _state.OnReset += _state_OnReset;
        _state.OnSkipSplit += _state_OnSkipSplit;
        _state.OnSplit += _state_OnSplit;
        _state.RunManuallyModified += _state_RunManuallyModified;
    }

    private void _state_OnReset(object sender, TimerPhase value)
    {
        if (value != TimerPhase.Ended)
        {
            _segments[_segmentIndex].rustCounter++;
        }
        _segmentIndex = 0;
        _skipStart = 0;
    }

    private void _state_OnSkipSplit(object sender, EventArgs e)
    {
        _segmentIndex++;
    }

    private void _state_OnSplit(object sender, EventArgs e)
    {
        for (int i = _skipStart; i <= _segmentIndex; i++)
        {
            _segments[i].rustCounter = 0;
        }
        _segmentIndex++;
        _skipStart = _segmentIndex;
    }

    private void _state_RunManuallyModified(object sender, EventArgs e)
    {
        _segments = BuildSegments();
    }

    private List<RustAlarmSegment> BuildSegments()
    {
        return _state.Run
            .Select((ISegment segment) => new RustAlarmSegment(segment.Name))
            .ToList();
    }
}
