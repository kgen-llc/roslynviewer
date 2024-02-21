using System.Collections.Generic;

namespace roslynviewer;

public interface ILocationProvider {
    Microsoft.CodeAnalysis.Location GetLocation();
}

public interface ITreeNodeViewModel : ILocationProvider {
    IReadOnlyList<ITreeNodeViewModel> Children {get;}

    bool IsExpanded {get; set;}

    IReadOnlyList<PropertyInfo> Properties {get;}

}
    public record PropertyInfo (string Name, string Value);
