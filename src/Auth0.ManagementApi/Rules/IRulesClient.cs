using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

public partial interface IRulesClient
{
    /// <summary>
    /// Retrieve a filtered list of <a href="https://auth0.com/docs/rules">rules</a>. Accepts a list of fields to include or exclude.
    /// </summary>
    Task<Pager<Rule>> ListAsync(
        ListRulesRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a <a href="https://auth0.com/docs/rules#create-a-new-rule-using-the-management-api">new rule</a>.
    ///
    /// Note: Changing a rule's stage of execution from the default <code>login_success</code> can change the rule's function signature to have user omitted.
    /// </summary>
    WithRawResponseTask<CreateRuleResponseContent> CreateAsync(
        CreateRuleRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve <a href="https://auth0.com/docs/rules">rule</a> details. Accepts a list of fields to include or exclude in the result.
    /// </summary>
    WithRawResponseTask<GetRuleResponseContent> GetAsync(
        string id,
        GetRuleRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a rule.
    /// </summary>
    Task DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update an existing rule.
    /// </summary>
    WithRawResponseTask<UpdateRuleResponseContent> UpdateAsync(
        string id,
        UpdateRuleRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
