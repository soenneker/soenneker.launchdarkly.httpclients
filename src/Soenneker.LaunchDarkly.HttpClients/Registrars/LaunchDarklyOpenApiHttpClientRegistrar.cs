using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.LaunchDarkly.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.LaunchDarkly.HttpClients.Registrars;

/// <summary>
/// Registers the OpenAPI HttpClient wrapper for dependency injection.
/// </summary>
public static class LaunchDarklyOpenApiHttpClientRegistrar
{
    /// <summary>
    /// Adds <see cref="LaunchDarklyOpenApiHttpClient"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddLaunchDarklyOpenApiHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<ILaunchDarklyOpenApiHttpClient, LaunchDarklyOpenApiHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="LaunchDarklyOpenApiHttpClient"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddLaunchDarklyOpenApiHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<ILaunchDarklyOpenApiHttpClient, LaunchDarklyOpenApiHttpClient>();

        return services;
    }
}
