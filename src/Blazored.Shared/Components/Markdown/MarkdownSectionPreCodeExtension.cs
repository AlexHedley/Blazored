using Markdig.Renderers;
using Markdig;
using Markdig.Renderers.Html;

// https://github.com/microsoft/fluentui-blazor/blob/main/examples/Demo/Shared/Components/MarkdownSectionPreCodeExtension.cs
//namespace FluentUI.Demo.Shared.Components;

namespace Blazored.Shared.Components;

internal class MarkdownSectionPreCodeExtension : IMarkdownExtension
{
    public void Setup(MarkdownPipelineBuilder pipeline)
    {
    }

    public void Setup(MarkdownPipeline pipeline, IMarkdownRenderer renderer)
    {
        var htmlRenderer = renderer as TextRendererBase<HtmlRenderer>;
        if (htmlRenderer == null)
        {
            return;
        }

        var originalCodeBlockRenderer = htmlRenderer.ObjectRenderers.FindExact<CodeBlockRenderer>();
        if (originalCodeBlockRenderer != null)
        {
            htmlRenderer.ObjectRenderers.Remove(originalCodeBlockRenderer);
        }

        htmlRenderer.ObjectRenderers.AddIfNotAlready(new MarkdownSectionPreCodeRenderer(
                new MarkdownSectionPreCodeRendererOptions
                {
                    PreTagAttributes = "{.snippet .hljs-copy-wrapper}",
                })
            );
    }
}
