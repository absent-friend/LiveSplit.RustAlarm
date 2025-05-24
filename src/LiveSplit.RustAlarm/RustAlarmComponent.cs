using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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

    private readonly GraphicsCache _cache;
    private readonly LiveSplitState _state;
    private readonly RustAlarmSettings _settings;
    private readonly Stack<IRustAlarmEvent> _eventStack;
    private readonly ComponentRendererComponent _listRenderer;
    private readonly RustAlarmHeading _heading;
    private IRun _currentRun;
    private List<RustAlarmSegment> _segments;
    private int _skipStart;
    private int _segmentIndex;

    public RustAlarmComponent(LiveSplitState state)
    {
        _cache = new();
        _state = state;
        _settings = new();
        _eventStack = new();
        _listRenderer = new();
        _heading = new(_settings);
        SetRun(state.Run);
        SetUpEventListeners();
    }

    public string ComponentName => Name;

    public float HorizontalWidth => DisplayComponent.HorizontalWidth;

    public float MinimumHeight => DisplayComponent.MinimumHeight;

    public float VerticalHeight => DisplayComponent.VerticalHeight;

    public float MinimumWidth => DisplayComponent.MinimumWidth;

    public float PaddingTop => DisplayComponent.PaddingTop;

    public float PaddingBottom => DisplayComponent.PaddingBottom;

    public float PaddingLeft => DisplayComponent.PaddingLeft;

    public float PaddingRight => DisplayComponent.PaddingRight;

    private IComponent DisplayComponent => SegmentIndex >= 0 ? _segments[SegmentIndex] : _listRenderer;

    private int SegmentIndex
    {
        get => Math.Min(_segmentIndex, _segments.Count - 1);
        set {
            _segmentIndex = value;
            if (value == -1)
            {
                DisplayRustySegmentList();
            }
            else if (value < _segments.Count)
            {
                DisplayRustLevel(value);
            }
        }
    }

    public void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
    {
        if (_currentRun != state.Run)
        {
            SetRun(state.Run);
        }

        _cache.Restart();
        _cache["SegmentIndex"] = SegmentIndex;
        if (invalidator != null && _cache.HasChanged)
        {
            invalidator.Invalidate(0, 0, width, height);
        }

        if (invalidator != null)
        {
            DisplayComponent.Update(invalidator, state, width, height, mode);
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

    private void DrawBackground(Graphics g, float width, float height)
    {
        // ripped from LiveSplit.Text's TextComponent
        if (_settings.BackgroundColor1.A > 0 || (_settings.BackgroundGradient != GradientType.Plain && _settings.BackgroundColor2.A > 0))
        {
            var gradientBrush = new LinearGradientBrush(
                        new PointF(0, 0),
                        _settings.BackgroundGradient == GradientType.Horizontal
                        ? new PointF(width, 0)
                        : new PointF(0, height),
                        _settings.BackgroundColor1,
                        _settings.BackgroundGradient == GradientType.Plain
                        ? _settings.BackgroundColor1
                        : _settings.BackgroundColor2);
            g.FillRectangle(gradientBrush, 0, 0, width, height);
        }
    }

    public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion)
    {
        DrawBackground(g, HorizontalWidth, height);
        DisplayComponent.DrawHorizontal(g, state, height, clipRegion);
    }

    public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion)
    {
        DrawBackground(g, width, VerticalHeight);
        DisplayComponent.DrawVertical(g, state, width, clipRegion);
    }

    // Dispose is called when the component is removed from the layout or when the application is closed.
    // Clean up resources like file handles or event listeners here.
    public void Dispose()
    {
        _state.OnReset -= _state_OnReset;
        _state.OnSkipSplit -= _state_OnSkipSplit;
        _state.OnSplit -= _state_OnSplit;
        _state.OnStart -= _state_OnStart;
        _state.OnUndoSplit -= _state_OnUndoSplit;
        _state.RunManuallyModified -= _state_RunManuallyModified;
    }

    private void SetUpEventListeners()
    {
        _state.OnReset += _state_OnReset;
        _state.OnSkipSplit += _state_OnSkipSplit;
        _state.OnSplit += _state_OnSplit;
        _state.OnStart += _state_OnStart;
        _state.OnUndoSplit += _state_OnUndoSplit;
        _state.RunManuallyModified += _state_RunManuallyModified;
    }

    private void _state_OnReset(object sender, TimerPhase value)
    {
        if (value != TimerPhase.Ended)
        {
            bool newlyRusty = _segments[SegmentIndex].Reset();
            if (newlyRusty)
            {
                _heading.RustCount++;
            }
        }
        for (int i = 0; i <= SegmentIndex; i++)
        {
            _segments[i].RunEnded();
        }
        SegmentIndex = -1;
        _skipStart = 0;
        _eventStack.Clear();
    }

    class SkipEvent(RustAlarmComponent component) : IRustAlarmEvent
    {
        public void Apply()
        {
            component.SegmentIndex++;
        }

        public void Undo()
        {
            component.SegmentIndex--;
        }
    }

    private void _state_OnSkipSplit(object sender, EventArgs e)
    {
        var skip = new SkipEvent(this);
        skip.Apply();
        _eventStack.Push(skip);
    }

    private TimeSpan? TimeLostOrGainedToBest()
    {
        // It's assumed that both the previous split and the current one were not skipped. Don't call this in a situation that would violate those assumptions.
        TimeSpan? segment;
        if (SegmentIndex == 0)
        {
            segment = _currentRun[SegmentIndex].SplitTime[_state.CurrentTimingMethod];
        }
        else
        {
            TimeSpan? split = _currentRun[SegmentIndex].SplitTime[_state.CurrentTimingMethod];
            TimeSpan? previousSplit = _currentRun[SegmentIndex - 1].SplitTime[_state.CurrentTimingMethod];
            segment = split - previousSplit;
        }

        TimeSpan? bestSegment = _currentRun[SegmentIndex].BestSegmentTime[_state.CurrentTimingMethod];
        return segment - bestSegment;
    }

    class SplitEvent(RustAlarmComponent component) : IRustAlarmEvent
    {
        private readonly int _segmentIndex = component.SegmentIndex;
        private readonly int _skipStart = component._skipStart;
        private readonly int _rustCount = component._heading.RustCount;

        public void Apply()
        {
            if (_skipStart == _segmentIndex)
            {
                TimeSpan? deltaGold = component.TimeLostOrGainedToBest();
                (bool wasRusty, bool isRusty) = component._segments[_segmentIndex].Split(deltaGold);
                if (wasRusty && !isRusty)
                {
                    component._heading.RustCount--;
                }
                else if (!wasRusty && isRusty)
                {
                    component._heading.RustCount++;
                }
            }
            else
            {
                int noLongerRusty = 0;
                for (int i = _skipStart; i <= _segmentIndex; i++)
                {
                    bool newlyClean = component._segments[i].Split();
                    if (newlyClean)
                    {
                        noLongerRusty++;
                    }
                }
                component._heading.RustCount -= noLongerRusty;
            }
            component.SegmentIndex++;
            component._skipStart = component.SegmentIndex;
        }

        public void Undo()
        {
            component.SegmentIndex = _segmentIndex;
            component._skipStart = _skipStart;
            component._heading.RustCount = _rustCount;

            for (int i = _skipStart; i <= _segmentIndex; i++)
            {
                component._segments[i].Undo();
            }
        }
    }

    private void _state_OnSplit(object sender, EventArgs e)
    {
        var split = new SplitEvent(this);
        split.Apply();
        _eventStack.Push(split);
    }

    private void _state_OnStart(object sender, EventArgs e)
    {
        SegmentIndex = 0;
    }

    private void _state_OnUndoSplit(object sender, EventArgs e)
    {
        // Undo won't fire if it's attempted on the first segment of the run, so we don't need to check count.
        _eventStack.Pop().Undo();
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
        SetUpSegmentListeners();
        RefreshRustCount();
        _settings.RebuildSegmentsGrid();
    }

    private void SetRun(IRun run)
    {
        _currentRun = run;
        _settings.SetRun(run);
        _segments = run
            .Select(_settings.GetOrCreateSegment)
            .ToList();
        SegmentIndex = -1;
        _listRenderer.VisibleComponents = _segments
            .Where(segment => segment.IsRusty())
            .Cast<IComponent>()
            .Prepend(_heading);
        SetUpSegmentListeners();
        RefreshRustCount();
    }

    private void SetUpSegmentListeners()
    {
        foreach (RustAlarmSegment segment in _segments)
        {
            segment.OnThresholdChange -= OnThresholdChange;
            segment.OnThresholdChange += OnThresholdChange;
        }
    }

    private void OnThresholdChange(object sender, EventArgs e)
    {
        RefreshRustCount();
    }

    private void RefreshRustCount()
    {
        _heading.RustCount = _segments.Where(segment => segment.IsRusty()).Count();
    }

    private void DisplayRustySegmentList()
    {
        foreach (RustAlarmSegment segment in _segments)
        {
            segment.LabelForList();
        }
    }

    private void DisplayRustLevel(int index)
    {
        _segments[index].LabelForRun();
    }

    public IDictionary<string, Action> ContextMenuControls
    {
        get
        {
            Dictionary<string, Action> contextControls = [];
            contextControls["Clear All Rusty Segments"] = ClearRustySegments;
            foreach (RustAlarmSegment segment in _segments.Where(s => s.IsRusty()))
            {
                contextControls["Clear Rust for " + segment.DisplayName] = () => ClearRust(segment);
            }
            return contextControls;
        }
    }

    private void ClearRustySegments()
    {
        foreach (RustAlarmSegment segment in _segments.Where(s => s.IsRusty()))
        {
            segment.ClearRust();
        }
        _heading.RustCount = 0;
    }

    private void ClearRust(RustAlarmSegment segment)
    {
        segment.ClearRust();
        _heading.RustCount--;
    }
}
