using Soenneker.LaunchDarkly.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.LaunchDarkly.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class LaunchDarklyOpenApiHttpClientTests : HostedUnitTest
{
    private readonly ILaunchDarklyOpenApiHttpClient _httpclient;

    public LaunchDarklyOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<ILaunchDarklyOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
