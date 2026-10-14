using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

public partial interface IClientProfilesClient
{
    /// <summary>
    /// Retrieve a paginated list of client profiles for the tenant. Uses checkpoint pagination: pass the <c>next</c> cursor from a previous response as the <c>from</c> query parameter to retrieve the following page.
    /// </summary>
    Task<Pager<ClientProfile>> ListAsync(
        ListClientProfilesRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a client profile. At most one profile is allowed per tenant in this release; attempting to create a second returns <c>409 Conflict</c>. The profile governs Dynamic CIMD clients matched by its <c>apply_policy</c> at runtime.
    /// </summary>
    WithRawResponseTask<ClientProfile> CreateAsync(
        CreateClientProfileRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a single client profile by its identifier. Returns <c>404</c> if no profile with the given ID exists for the tenant.
    /// </summary>
    WithRawResponseTask<ClientProfile> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a client profile. Idempotent: returns <c>204 No Content</c> whether or not a profile with the given ID existed. Deleting the profile removes fleet governance for matched clients immediately.
    /// </summary>
    WithRawResponseTask DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update a client profile. Supports partial updates at the top level (JSON Merge Patch); omitted top-level fields remain unchanged. Nested objects such as <c>client_configuration</c> must be supplied in full.
    /// </summary>
    WithRawResponseTask<ClientProfile> UpdateAsync(
        string id,
        UpdateClientProfileRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
