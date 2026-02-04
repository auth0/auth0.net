using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Jobs;

public partial interface IUsersImportsClient
{
    /// <summary>
    /// Import users from a <a href="https://auth0.com/docs/users/references/bulk-import-database-schema-examples">formatted file</a> into a connection via a long-running job. When importing users, with or without upsert, the `email_verified` is set to `false` when the email address is added or updated. Users must verify their email address. To avoid this behavior, set `email_verified` to `true` in the imported data.
    /// </summary>
    WithRawResponseTask<CreateImportUsersResponseContent> CreateAsync(
        CreateImportUsersRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
