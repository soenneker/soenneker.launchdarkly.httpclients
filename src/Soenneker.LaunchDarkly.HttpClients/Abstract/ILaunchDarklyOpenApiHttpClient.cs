using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace Soenneker.LaunchDarkly.HttpClients.Abstract;

/// <summary>
/// Provides a cached HTTP client authenticated for LaunchDarkly's API.
/// </summary>
public interface ILaunchDarklyOpenApiHttpClient: IDisposable, IAsyncDisposable
{
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
