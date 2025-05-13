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
    private readonly Stack<IRustAlarmEvent> _eventStack;
    private readonly ComponentRendererComponent _componentRenderer;
    private readonly InfoTextComponent _heading;
    private IRun _currentRun;
    private List<RustAlarmSegment> _segments;
    private int _skipStart;
    private int _segmentIndex;
    private int _rustCount;

    public RustAlarmComponent(LiveSplitState state)
    {
        _state = state;
        _settings = new();
        _eventStack = new();
        _componentRenderer = new();
        _heading = new("Rusty Segments", "-");
        SetRun(state.Run);
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
            SetRun(state.Run);
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

    // This method is invoked dynamically by LiveSplit to detect layout changes efficiently. Despite appearances, it's not unused --- don't delete it!
    public int GetSettingsHashCode()
    {
        return _settings.GetSettingsHashCode();
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
        _state.OnSkipSplit -= _state_OnSkipSplit;
        _state.OnSplit -= _state_OnSplit;
        _state.OnUndoSplit -= _state_OnUndoSplit;
        _state.RunManuallyModified -= _state_RunManuallyModified;
    }

    private void SetUpEventListeners()
    {
        _state.OnReset += _state_OnReset;
        _state.OnSkipSplit += _state_OnSkipSplit;
        _state.OnSplit += _state_OnSplit;
        _state.OnUndoSplit += _state_OnUndoSplit;
        _state.RunManuallyModified += _state_RunManuallyModified;
    }

    private void _state_OnReset(object sender, TimerPhase value)
    {
        if (value != TimerPhase.Ended)
        {
            bool newlyRusty = _segments[_segmentIndex].Reset();
            if (newlyRusty)
            {
                _rustCount++;
                SetHeadingText();
            }
        }
        for (int i = 0; i <= _segmentIndex; i++)
        {
            _segments[i].RunEnded();
        }
        _segmentIndex = 0;
        _skipStart = 0;
        _eventStack.Clear();
    }

    class SkipEvent(RustAlarmComponent component) : IRustAlarmEvent
    {
        public void Apply()
        {
            component._segmentIndex++;
        }

        public void Undo()
        {
            component._segmentIndex--;
        }
    }

    private void _state_OnSkipSplit(object sender, EventArgs e)
    {
        var skip = new SkipEvent(this);
        skip.Apply();
        _eventStack.Push(skip);
    }

    class SplitEvent(RustAlarmComponent component) : IRustAlarmEvent
    {
        private readonly int _skipStart = component._skipStart;
        private readonly int _segmentIndex = component._segmentIndex;
        private readonly int _rustCount = component._rustCount;

        public void Apply()
        {
            for (int i = _skipStart; i <= _segmentIndex; i++)
            {
                bool newlyClean = component._segments[i].Split();
                if (newlyClean)
                {
                    component._rustCount--;
                }
            }
            component.SetHeadingText();
            component._segmentIndex++;
            component._skipStart = component._segmentIndex;
        }

        public void Undo()
        {
            component._segmentIndex = _segmentIndex;
            component._skipStart = _skipStart;
            component._rustCount = _rustCount;

            for (int i = _skipStart; i <= _segmentIndex; i++)
            {
                component._segments[i].Undo();
            }
            component.SetHeadingText();
        }
    }

    private void _state_OnSplit(object sender, EventArgs e)
    {
        var split = new SplitEvent(this);
        split.Apply();
        _eventStack.Push(split);
    }

    private void _state_OnUndoSplit(object sender, EventArgs e)
    {
        // Undo won't fire if it's attempted on the first segment of the run, so we don't need to check count.
        _eventStack.Pop().Undo();
    }

    private void SetHeadingText()
    {
        _heading.ValueLabel.Text = _rustCount == 0 ? "-" : _rustCount.ToString();
    }

    private void _state_RunManuallyModified(object sender, EventArgs e)
    {
        if (_currentRun != _state.Run)
        {
            // User opened the splits editor and then cancelled.
            // Easier to wipe clean and rebuild than try to unwind whatever changes they might have made.
            SetRun(_state.Run);
        }
        else
        {
            FixSegments();
        }
    }

    private void FixSegments()
    {
        int i = 0;
        for (; i < _state.Run.Count && i < _segments.Count; i++)
        {
            ISegment segment = _state.Run[i];
            if (segment == _segments[i].Segment)
            {
                _settings.CheckForNameChange(_segments[i]);
                continue;
            }
            int newIndex = _segments.FindIndex(s => s.Segment == segment);
            if (newIndex == -1)
            {
                _segments.Insert(i, _settings.GetOrCreateSegment(segment));
            }
            else
            {
                (_segments[newIndex], _segments[i]) = (_segments[i], _segments[newIndex]);
            }
        }

        if (i < _state.Run.Count)
        {
            for (; i < _state.Run.Count; i++)
            {
                _segments.Add(_settings.GetOrCreateSegment(_state.Run[i]));
            }
        }
        else if (i < _segments.Count)
        {
            // Everything that corresponds to a segment currently contained in the run should have been swapped or inserted into its correct place at an index < i.
            // Leftover segments were deleted in the splits editor.
            _segments.RemoveRange(i, _segments.Count - i);
        }
        _rustCount = _segments.Where(segment => segment.IsRusty()).Count();
        SetHeadingText();
    }

    private void SetRun(IRun run)
    {
        _currentRun = run;
        _settings.SetRun(run);
        _segments = run
            .Select(_settings.GetOrCreateSegment)
            .ToList();
        _componentRenderer.VisibleComponents = _segments
            .Where(segment => segment.IsRusty())
            .Cast<IComponent>()
            .Prepend(_heading);
        _rustCount = _segments.Where(segment => segment.IsRusty()).Count();
        SetHeadingText();
    }
}
