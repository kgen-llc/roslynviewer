using System.Collections.Generic;

namespace roslynviewer;

public interface ILocationProvider {
    Microsoft.CodeAnalysis.Location GetLocation();
}

public interface ITreeNodeViewModel : ILocationProvider {
    IReadOnlyList<ITreeNodeViewModel> Children {get;}
}
