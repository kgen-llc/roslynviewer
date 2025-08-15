namespace roslynviewer;

internal interface ILocationProvider {
    Microsoft.CodeAnalysis.Location GetLocation();
}
