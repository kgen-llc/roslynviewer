namespace roslynviewer;

public interface ILocationProvider {
    Microsoft.CodeAnalysis.Location GetLocation();
}
