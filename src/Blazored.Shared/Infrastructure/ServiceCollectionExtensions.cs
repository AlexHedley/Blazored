// ------------------------------------------------------------------------
// MIT License - Copyright (c) Microsoft Corporation. All rights reserved.
// ------------------------------------------------------------------------

//using FluentUI.Demo.Shared.Infrastructure;
using Blazored.Shared.Infrastructure;
using Microsoft.Extensions.DependencyInjection;


// https://github.com/microsoft/fluentui-blazor/blob/main/examples/Demo/Shared/Infrastructure/ServiceCollectionExtensions.cs
//namespace FluentUI.Demo.Shared;

namespace Blazored.Shared;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add common client services required by the Fluent UI Web Components for Blazor library
    /// </summary>
    /// <param name="services">Service collection</param>
    public static IServiceCollection AddFluentUIClientServices(this IServiceCollection services)
    {
        services.AddSingleton<IAppVersionService, AppVersionService>();
        services.AddSingleton<CacheStorageAccessor>();
        services.AddHttpClient<IStaticAssetService, HttpBasedStaticAssetService>();
        //services.AddSingleton<DemoNavProvider>();

        return services;
    }

    /// <summary>
    /// Add common server services required by the Fluent UI Web Components for Blazor library
    /// </summary>
    /// <param name="services">Service collection</param>
    public static IServiceCollection AddFluentUIServerServices(this IServiceCollection services)
    {
        services.AddScoped<IAppVersionService, AppVersionService>();
        services.AddScoped<CacheStorageAccessor>();
        services.AddHttpClient<IStaticAssetService, ServerStaticAssetService>();
        //services.AddSingleton<DemoNavProvider>();

        return services;
    }
}
