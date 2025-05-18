using System;

using LiveSplit.Model;
using LiveSplit.RustAlarm.UI;
using LiveSplit.UI.Components;

[assembly: ComponentFactory(typeof(LiveSplit.RustAlarm.RustAlarmFactory))]

namespace LiveSplit.RustAlarm;

public sealed class RustAlarmFactory : IComponentFactory
{
    // The name of the component that will be displayed in the layout editor.
    public string ComponentName => RustAlarmComponent.Name;

    // The tooltip shown when hovering over the component when adding it to the layout.
    public string Description => "Lets you know when a segment is probably getting rusty.";

    // Specifies the category of the component.
    // Determines under what category the component is listed when adding it to the layout.
    public ComponentCategory Category => ComponentCategory.Information;

    // A URL to the component's release downloads.
    public string UpdateURL => "https://github.com/absent-friend/LiveSplit.RustAlarm/releases/download";

    // A URL to the component's update XML file.
    public string XMLURL => "https://raw.githubusercontent.com/absent-friend/LiveSplit.RustAlarm/main/Components/update.LiveSplit.RustAlarm.xml";

    // The current version of the component.
    public Version Version => RustAlarmSettings.VERSION;

    public IComponent Create(LiveSplitState state) => new RustAlarmComponent(state);

    // This property is unused.
    public string UpdateName => throw null;
}
