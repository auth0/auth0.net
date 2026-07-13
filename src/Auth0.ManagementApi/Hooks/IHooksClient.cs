using Auth0.ManagementApi.Core;
using Auth0.ManagementApi.Hooks;

namespace Auth0.ManagementApi;

public partial interface IHooksClient
{
    public ISecretsClient Secrets { get; }

    /// <summary>
    /// Retrieve all [hooks](https://auth0.com/docs/hooks). Accepts a list of fields to include or exclude in the result.
    /// </summary>
    Task<Pager<Hook>> ListAsync(
        ListHooksRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a new hook.
    /// </summary>
    WithRawResponseTask<CreateHookResponseContent> CreateAsync(
        CreateHookRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve [a hook](https://auth0.com/docs/hooks) by its ID. Accepts a list of fields to include in the result.
    /// </summary>
    WithRawResponseTask<GetHookResponseContent> GetAsync(
        string id,
        GetHookRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a hook.
    /// </summary>
    WithRawResponseTask DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update an existing hook.
    /// </summary>
    WithRawResponseTask<UpdateHookResponseContent> UpdateAsync(
        string id,
        UpdateHookRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
