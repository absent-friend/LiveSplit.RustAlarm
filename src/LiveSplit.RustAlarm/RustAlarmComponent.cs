using System;
using System.Collections.Generic;
using System.Drawing;
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

    public RustAlarmComponent(LiveSplitState state)
    {
        _state = state;
        _settings = new();
    }

    public string ComponentName => Name;

    public float HorizontalWidth => throw new NotImplementedException();

    public float MinimumHeight => throw new NotImplementedException();

    public float VerticalHeight => throw new NotImplementedException();

    public float MinimumWidth => throw new NotImplementedException();

    public float PaddingTop => throw new NotImplementedException();

    public float PaddingBottom => throw new NotImplementedException();

    public float PaddingLeft => throw new NotImplementedException();

    public float PaddingRight => throw new NotImplementedException();

    public IDictionary<string, Action> ContextMenuControls => null;

    public void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
    {
#warning TODO: figure out if this is actually where I should put my logic
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

    // Dispose is called when the component is removed from the layout or when the application is closed.
    // Clean up resources like file handles or event listeners here.
    public void Dispose()
    {

    }

    public void DrawHorizontal(Graphics g, LiveSplitState state, float height, Region clipRegion)
    {
        throw new NotImplementedException();
    }

    public void DrawVertical(Graphics g, LiveSplitState state, float width, Region clipRegion)
    {
        throw new NotImplementedException();
    }
}
