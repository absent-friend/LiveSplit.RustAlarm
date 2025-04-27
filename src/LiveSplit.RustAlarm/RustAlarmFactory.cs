#warning TODO: Adjust this information to match your component.

using System;

using LiveSplit.Model;
using LiveSplit.UI.Components;

[assembly: ComponentFactory(typeof(LiveSplit.SampleSplitter.RustAlarmFactory))]

namespace LiveSplit.SampleSplitter;

public sealed class RustAlarmFactory : IComponentFactory
{
    // The name of the component that will be displayed in the layout editor.
    public string ComponentName => RustAlarmComponent.Name;

    // The tooltip shown when hovering over the component when adding it to the layout.
    public string Description => "Lets you know when a segment is probably getting rusty.";

    // Specifies the category of the component.
    // Determines under what category the component is listed when adding it to the layout.
    public ComponentCategory Category => ComponentCategory.Information;

    // A URL to the component's repository.
    public string UpdateURL => "https://github.com/absent-friend/LiveSplit.RustAlarm";

    // A URL to the component's update XML file.
    public string XMLURL => $"{UpdateURL}/Components/update.LiveSplit.RustAlarm.xml";

    // The current version of the component.
    public Version Version => Version.Parse("0.0.1");

    public IComponent Create(LiveSplitState state)
        => new RustAlarmComponent(state);

    // This property is unused.
    public string UpdateName => throw null;
}
