using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Actions;

public partial interface IVersionsClient
{
    /// <summary>
    /// Retrieve all of an action's versions. An action version is created whenever an action is deployed. An action version is immutable, once created.
    /// </summary>
    Task<Pager<ActionVersion>> ListAsync(
        string actionId,
        ListActionVersionsRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a specific version of an action. An action version is created whenever an action is deployed. An action version is immutable, once created.
    /// </summary>
    WithRawResponseTask<GetActionVersionResponseContent> GetAsync(
        string actionId,
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Performs the equivalent of a roll-back of an action to an earlier, specified version. Creates a new, deployed action version that is identical to the specified version. If this action is currently bound to a trigger, the system will begin executing the newly-created version immediately.
    /// </summary>
    WithRawResponseTask<DeployActionVersionResponseContent> DeployAsync(
        string actionId,
        string id,
        Optional<DeployActionVersionRequestContent?> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
