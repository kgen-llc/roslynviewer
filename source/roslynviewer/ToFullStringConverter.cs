namespace roslynviewer;

using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Microsoft.CodeAnalysis;

public class ToFullStringConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        switch (value)
        {
            case SyntaxNode syntaxNode:
                return syntaxNode.ToFullString();
            case SyntaxTrivia syntaxTrivia:
                return syntaxTrivia.ToFullString();
            case SyntaxToken syntaxToken:
                return syntaxToken.ToFullString();
            default:
                return $"[{value?.GetType().Name}]{value?.ToString()}";
        }
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotSupportedException();
    }
}
