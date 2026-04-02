using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Hooks;

public partial interface ISecretsClient
{
    /// <summary>
    /// Retrieve a hook's secrets by the ID of the hook.
    /// </summary>
    WithRawResponseTask<Dictionary<string, string>> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Add one or more secrets to an existing hook. Accepts an object of key-value pairs, where the key is the name of the secret. A hook can have a maximum of 20 secrets.
    /// </summary>
    Task CreateAsync(
        string id,
        Dictionary<string, string> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete one or more existing secrets for a given hook. Accepts an array of secret names to delete.
    /// </summary>
    Task DeleteAsync(
        string id,
        IEnumerable<string> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update one or more existing secrets for an existing hook. Accepts an object of key-value pairs, where the key is the name of the existing secret.
    /// </summary>
    Task UpdateAsync(
        string id,
        Dictionary<string, string> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
