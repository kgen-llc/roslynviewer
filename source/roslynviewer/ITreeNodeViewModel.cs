using System.Collections.Generic;

namespace roslynviewer;

internal interface ITreeNodeViewModel : ILocationProvider {
    IReadOnlyList<ITreeNodeViewModel> Children {get;}

    bool IsExpanded {get; set;}

    IReadOnlyList<PropertyInfo> Properties {get;}

}
