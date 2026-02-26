namespace Auth0.ManagementApi;

/// <summary>
/// Abstraction for supplying access tokens to the Management API client.
/// Implement this interface to support custom token strategies.
/// </summary>
public interface ITokenProvider
{
    /// <summary>
    /// Returns a valid access token, fetching or refreshing as needed.
    /// </summary>
    /// <param name="cancellationToken">A token to cancel the operation.</param>
    Task<string> GetTokenAsync(CancellationToken cancellationToken = default);
}
