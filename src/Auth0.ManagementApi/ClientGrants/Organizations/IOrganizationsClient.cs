using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.ClientGrants;

public partial interface IOrganizationsClient
{
    Task<Pager<Organization>> ListAsync(
        string id,
        ListClientGrantOrganizationsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
