// --------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
// --------------------------------------------------------------

// https://github.com/microsoft/fluentui-blazor/blob/main/examples/Demo/Shared/Components/CodeSnippet.razor.cs
// namespace FluentUI.Demo.Shared.Components;
namespace Blazored.Shared.Components;

using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

/// <summary />
public partial class CodeSnippet
{
    private ElementReference codeElement;

    private IJSObjectReference _jsModule = default!;

    [Inject]
    protected IJSRuntime JSRuntime { get; set; } = default!;

    [Parameter]
    public RenderFragment ChildContent { get; set; } = default!;

    [Parameter]
    public string Language { get; set; } = "language-cshtml-razor";

    [Parameter]
    public string? Style { get; set; } = null;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {

            _jsModule = await JSRuntime.InvokeAsync<IJSObjectReference>("import",
                //"./_content/FluentUI.Demo.Shared/Components/CodeSnippet.razor.js");
                "./_content/Blazored.Shared/Components/CodeSnippet/CodeSnippet.razor.js");
            await _jsModule.InvokeVoidAsync("highlightElement", codeElement);
            await _jsModule.InvokeVoidAsync("addCopyButton");
        }
    }
}
