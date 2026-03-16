using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

public partial class ManagementApiClient
{
    /// <summary>
    /// Replaces the Authorization header with a dynamic supplier that is evaluated per-request.
    /// Used by <see cref="ManagementClient"/> to wire in <see cref="ITokenProvider"/> support.
    /// </summary>
    internal void SetAuthorizationHeader(Func<Task<string>> supplier)
    {
        _client.Options.Headers["Authorization"] = supplier;
    }
}
