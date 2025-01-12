// https://github.com/microsoft/fluentui-blazor/blob/main/examples/Demo/Shared/Components/MarkdownSectionPreCodeRendererOptions.cs
//namespace FluentUI.Demo.Shared.Components;

namespace Blazored.Shared.Components;

/// <summary>
/// Options for MarkdownSectionPreCodeRenderer
/// </summary>
internal class MarkdownSectionPreCodeRendererOptions
{
    /// <summary>
    /// html attributes for Tag element in markdig generic attributes format
    /// </summary>
    public string? PreTagAttributes;
    /// <summary>
    /// html attributes for Code element in markdig generic attributes format
    /// </summary>
    public string? CodeTagAttributes;
}
