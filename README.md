[![](https://img.shields.io/nuget/v/soenneker.launchdarkly.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.launchdarkly.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.launchdarkly.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.launchdarkly.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.launchdarkly.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.launchdarkly.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.launchdarkly.httpclients/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.launchdarkly.httpclients/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.LaunchDarkly.HttpClients

Reuse an authenticated HTTP client for LaunchDarkly's management API.

## Install

```bash
dotnet add package Soenneker.LaunchDarkly.HttpClients
```

## Configure and register

```json
{ "LaunchDarkly": { "ApiKey": "<access token>" } }
```

The defaults target `https://app.launchdarkly.com/api/v2` and send the token directly in the `Authorization` header. You can override `ClientBaseUrl`, `AuthHeaderName`, and `AuthHeaderValueTemplate` under `LaunchDarkly`; use `{token}` in the template.

```csharp
services.AddLaunchDarklyOpenApiHttpClientAsSingleton();
```

Use the scoped registration only when each scope should own its transport. Provider instances use isolated cache keys, so disposing one scope removes only its own client.

```csharp
HttpClient client = await launchDarklyHttpClient.Get(cancellationToken);
HttpResponseMessage response = await client.GetAsync("projects", cancellationToken);
response.EnsureSuccessStatusCode();
```

The provider owns the cached client. Let the service container dispose the provider.
