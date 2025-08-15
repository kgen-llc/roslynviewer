using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace roslynviewer;

internal static class OpenUrlExtension
{

    private static bool IsValidUrl(string url)
    {
        if (string.IsNullOrWhiteSpace(url)) return false;
        if (!Uri.IsWellFormedUriString(url, UriKind.Absolute)) return false;
        if (!Uri.TryCreate(url, UriKind.Absolute, out var tmp)) return false;
        return string.Equals(tmp.Scheme, Uri.UriSchemeHttp, StringComparison.OrdinalIgnoreCase) || string.Equals(tmp.Scheme, Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase);
    }

#pragma warning disable CA1054 // we want to keep it simple
    public static void OpenUrl(this string url)
#pragma warning restore CA1054
    {
        if (!IsValidUrl(url)) throw new InvalidUrlException("invalid url: " + url);
        if (OperatingSystem.IsWindows())
        {
            //https://stackoverflow.com/a/2796367/241446
            using var proc = new Process { StartInfo = { UseShellExecute = true, FileName = url } };
            proc.Start();

            return;
        }

        if (OperatingSystem.IsLinux())
        {
            Process.Start("x-www-browser", url);
            return;
        }

        if (!OperatingSystem.IsMacOS()) throw new InvalidUrlException("invalid url: " + url);
        Process.Start("open", url);
        return;
    }
}
