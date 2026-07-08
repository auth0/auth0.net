using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Anomaly;

public partial interface IBlocksClient
{
    /// <summary>
    /// Check if the given IP address is blocked via the <see href="https://auth0.com/docs/configure/attack-protection/suspicious-ip-throttling">Suspicious IP Throttling</see> due to multiple suspicious attempts.
    /// </summary>
    WithRawResponseTask CheckIpAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Remove a block imposed by <see href="https://auth0.com/docs/configure/attack-protection/suspicious-ip-throttling">Suspicious IP Throttling</see> for the given IP address.
    /// </summary>
    WithRawResponseTask UnblockIpAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
