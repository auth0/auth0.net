namespace Auth0.ManagementApi;

public partial interface IPortalsClient
{
    WithRawResponseTask<ListPortalsResponseContent> ListAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<Portal> CreateAsync(
        CreatePortalRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<Portal> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<Portal> UpdateAsync(
        string id,
        UpdatePortalRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
