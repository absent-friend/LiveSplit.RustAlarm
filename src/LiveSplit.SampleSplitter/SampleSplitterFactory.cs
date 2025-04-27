#warning TODO: Adjust this information to match your component.

using System;

using LiveSplit.Model;
using LiveSplit.UI.Components;

[assembly: ComponentFactory(typeof(LiveSplit.SampleSplitter.SampleSplitterFactory))]

namespace LiveSplit.SampleSplitter;

public sealed class SampleSplitterFactory : IComponentFactory
{
    // The name of the component that will be displayed in the layout editor.
    public string ComponentName => SampleSplitterComponent.Name;

    // The tooltip shown when hovering over the component when adding it to the layout.
    public string Description => "A sample autosplitter component for LiveSplit.";

    // Specifies the category of the component.
    // Determines under what category the component is listed when adding it to the layout.
    public ComponentCategory Category => ComponentCategory.Control;

    // A URL to the component's repository.
    public string UpdateURL => "https://github.com/<author>/LiveSplit.SampleSplitter";

    // A URL to the component's update XML file.
    public string XMLURL => $"{UpdateURL}/Components/update.LiveSplit.SampleSplitter.xml";

    // The current version of the component.
    public Version Version => Version.Parse("0.0.1");

    public IComponent Create(LiveSplitState state)
        => new SampleSplitterComponent(state);

    // This property is unused.
    public string UpdateName => throw null;
}
