using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

public partial interface IRateLimitPoliciesClient
{
    Task<Pager<RateLimitPolicy>> ListAsync(
        ListRateLimitPoliciesRequestParameters request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<CreateRateLimitPolicyResponseContent> CreateAsync(
        CreateRateLimitPolicyRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<GetRateLimitPolicyResponseContent> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    Task DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<UpdateRateLimitPolicyResponseContent> UpdateAsync(
        string id,
        PatchRateLimitPolicyRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
