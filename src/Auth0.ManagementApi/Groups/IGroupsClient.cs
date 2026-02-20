using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

public partial interface IGroupsClient
{
    public Auth0.ManagementApi.Groups.IMembersClient Members { get; }

    /// <summary>
    /// List all groups in your tenant.
    /// </summary>
    Task<Pager<Group>> ListAsync(
        ListGroupsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a group by its ID.
    /// </summary>
    WithRawResponseTask<GetGroupResponseContent> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
