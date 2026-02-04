using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Anomaly;

public partial interface IBlocksClient
{
    /// <summary>
    /// Check if the given IP address is blocked via the <a href="https://auth0.com/docs/configure/attack-protection/suspicious-ip-throttling">Suspicious IP Throttling</a> due to multiple suspicious attempts.
    /// </summary>
    Task CheckIpAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove a block imposed by <a href="https://auth0.com/docs/configure/attack-protection/suspicious-ip-throttling">Suspicious IP Throttling</a> for the given IP address.
    /// </summary>
    Task UnblockIpAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
