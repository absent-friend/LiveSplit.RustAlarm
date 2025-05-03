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
    private IRun _currentRun;
    private readonly RustAlarmSettings _settings;
    private readonly ComponentRendererComponent _componentRenderer;
    private readonly InfoTextComponent _heading;
    private List<RustAlarmSegment> _segments;
    private int _skipStart;
    private int _segmentIndex;
    private int _rustCount;

    public RustAlarmComponent(LiveSplitState state)
    {
        _state = state;
        _currentRun = state.Run;
        _settings = new();
        _componentRenderer = new();
        _heading = new("Rusty Segments", "-");
        BuildSegments();
        SetUpEventListeners();
    }

    public string ComponentName => Name;

    public float HorizontalWidth => _componentRenderer.HorizontalWidth;

    public float MinimumHeight => _componentRenderer.MinimumHeight;

    public float VerticalHeight => _componentRenderer.VerticalHeight;

    public float MinimumWidth => _componentRenderer.MinimumWidth;

    public float PaddingTop => _componentRenderer.PaddingTop;

    public float PaddingBottom => _componentRenderer.PaddingBottom;

    public float PaddingLeft => _componentRenderer.PaddingLeft;

    public float PaddingRight => _componentRenderer.PaddingRight;

    public IDictionary<string, Action> ContextMenuControls => null;

    public void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
    {
        if (_currentRun != state.Run)
        {
            _currentRun = state.Run;
            BuildSegments();
        }

        if (invalidator != null)
        {
            _componentRenderer.Update(invalidator, state, width, height, mode);
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
        _heading.NameLabel.Font = state.LayoutSettings.TextFont;
        _heading.NameLabel.ForeColor = state.LayoutSettings.TextColor;
        _heading.NameLabel.OutlineColor = state.LayoutSettings.TextOutlineColor;
        _heading.NameLabel.ShadowColor = state.LayoutSettings.ShadowsColor;
        _heading.ValueLabel.Font = state.LayoutSettings.TextFont;
        _heading.ValueLabel.ForeColor = state.LayoutSettings.TextColor;
        _heading.ValueLabel.OutlineColor = state.LayoutSettings.TextOutlineColor;
        _heading.ValueLabel.ShadowColor = state.LayoutSettings.ShadowsColor;
    }

    public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion)
    {
        PrepareDraw(state);
        _componentRenderer.DrawHorizontal(g, state, height, clipRegion);
    }

    public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion)
    {
        PrepareDraw(state);
        _componentRenderer.DrawVertical(g, state, width, clipRegion);
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
            bool wasClean = !_segments[_segmentIndex].IsRusty();
            _segments[_segmentIndex].rustCounter++;
            if (wasClean && _segments[_segmentIndex].IsRusty())
            {
                _rustCount++;
                _heading.ValueLabel.Text = _rustCount.ToString();
            }
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
            bool wasRusty = _segments[i].IsRusty();
            _segments[i].rustCounter = 0;
            if (wasRusty)
            {
                _rustCount--;
            }
        }
        _heading.ValueLabel.Text = _rustCount == 0 ? "-" : _rustCount.ToString();
        _segmentIndex++;
        _skipStart = _segmentIndex;
    }

    private void _state_RunManuallyModified(object sender, EventArgs e)
    {
        BuildSegments();
    }

    private void BuildSegments()
    {
        _segments = _state.Run
            .Select((ISegment segment) => new RustAlarmSegment(segment.Name))
            .ToList();
        _componentRenderer.VisibleComponents = _segments
            .Where(segment => segment.IsRusty())
            .Cast<IComponent>()
            .Prepend(_heading);
        _rustCount = 0;
        _heading.ValueLabel.Text = "-";
    }
}
