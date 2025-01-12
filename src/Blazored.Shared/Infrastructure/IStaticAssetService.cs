// namespace FluentUI.Demo.Shared;
// https://github.com/microsoft/fluentui-blazor/blob/main/examples/Demo/Shared/Infrastructure/IStaticAssetService.cs

namespace Blazored.Shared;

public interface IStaticAssetService
{
    public Task<string?> GetAsync(string assetUrl, bool useCache = true);
}
