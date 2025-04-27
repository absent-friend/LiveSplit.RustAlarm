#warning TODO: Adjust this information to match your component.

using System.Windows.Forms;
using System.Xml;

using LiveSplit.Model;
using LiveSplit.SampleSplitter.UI;
using LiveSplit.UI;
using LiveSplit.UI.Components;

namespace LiveSplit.SampleSplitter;

public sealed class SampleSplitterComponent : LogicComponent
{
    public const string Name = "Sample Autosplitter";

    private readonly LiveSplitState _state;
    private readonly SampleSplitterSettings _settings;

    public SampleSplitterComponent(LiveSplitState state)
    {
        _state = state;
        _settings = new();
    }

    public override string ComponentName => Name;

    public override void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode)
    {
#warning TODO: Splitter logic goes here.
    }

    public override XmlNode GetSettings(XmlDocument document)
    {
        return _settings.GetSettings(document);
    }

    public override void SetSettings(XmlNode settings)
    {
        _settings.SetSettings(settings);
    }

    public override Control GetSettingsControl(LayoutMode mode)
    {
        return _settings;
    }

    // Dispose is called when the component is removed from the layout or when the application is closed.
    // Clean up resources like file handles or event listeners here.
    public override void Dispose()
    {

    }
}
