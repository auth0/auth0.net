namespace Auth0.ManagementApi;

public partial interface IRulesConfigsClient
{
    /// <summary>
    /// Retrieve rules config variable keys.
    ///
    ///     Note: For security, config variable values cannot be retrieved outside rule execution.
    /// </summary>
    WithRawResponseTask<IEnumerable<RulesConfig>> ListAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Sets a rules config variable.
    /// </summary>
    WithRawResponseTask<SetRulesConfigResponseContent> SetAsync(
        string key,
        SetRulesConfigRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a rules config variable identified by its key.
    /// </summary>
    Task DeleteAsync(
        string key,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
