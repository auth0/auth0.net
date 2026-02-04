using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

public partial interface ITokenExchangeProfilesClient
{
    /// <summary>
    /// Retrieve a list of all Token Exchange Profiles available in your tenant.
    ///
    /// By using this feature, you agree to the applicable Free Trial terms in <a href="https://www.okta.com/legal/">Okta’s Master Subscription Agreement</a>. It is your responsibility to securely validate the user’s subject_token. See <a href="https://auth0.com/docs/authenticate/custom-token-exchange">User Guide</a> for more details.
    ///
    /// This endpoint supports Checkpoint pagination. To search by checkpoint, use the following parameters:
    /// <ul>
    /// <li><code>from</code>: Optional id from which to start selection.</li>
    /// <li><code>take</code>: The total amount of entries to retrieve when using the from parameter. Defaults to 50.</li>
    /// </ul>
    ///
    /// <b>Note</b>: The first time you call this endpoint using checkpoint pagination, omit the <code>from</code> parameter. If there are more results, a <code>next</code> value is included in the response. You can use this for subsequent API calls. When <code>next</code> is no longer included in the response, no pages are remaining.
    /// </summary>
    Task<Pager<TokenExchangeProfileResponseContent>> ListAsync(
        TokenExchangeProfilesListRequest request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a new Token Exchange Profile within your tenant.
    ///
    /// By using this feature, you agree to the applicable Free Trial terms in <a href="https://www.okta.com/legal/">Okta’s Master Subscription Agreement</a>. It is your responsibility to securely validate the user’s subject_token. See <a href="https://auth0.com/docs/authenticate/custom-token-exchange">User Guide</a> for more details.
    /// </summary>
    WithRawResponseTask<CreateTokenExchangeProfileResponseContent> CreateAsync(
        CreateTokenExchangeProfileRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve details about a single Token Exchange Profile specified by ID.
    ///
    /// By using this feature, you agree to the applicable Free Trial terms in <a href="https://www.okta.com/legal/">Okta’s Master Subscription Agreement</a>. It is your responsibility to securely validate the user’s subject_token. See <a href="https://auth0.com/docs/authenticate/custom-token-exchange">User Guide</a> for more details.
    /// </summary>
    WithRawResponseTask<GetTokenExchangeProfileResponseContent> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a Token Exchange Profile within your tenant.
    ///
    /// By using this feature, you agree to the applicable Free Trial terms in <a href="https://www.okta.com/legal/">Okta's Master Subscription Agreement</a>. It is your responsibility to securely validate the user's subject_token. See <a href="https://auth0.com/docs/authenticate/custom-token-exchange">User Guide</a> for more details.
    /// </summary>
    Task DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a Token Exchange Profile within your tenant.
    ///
    /// By using this feature, you agree to the applicable Free Trial terms in <a href="https://www.okta.com/legal/">Okta's Master Subscription Agreement</a>. It is your responsibility to securely validate the user's subject_token. See <a href="https://auth0.com/docs/authenticate/custom-token-exchange">User Guide</a> for more details.
    /// </summary>
    Task UpdateAsync(
        string id,
        UpdateTokenExchangeProfileRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
