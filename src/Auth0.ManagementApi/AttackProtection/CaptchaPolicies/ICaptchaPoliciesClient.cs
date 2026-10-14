using Auth0.ManagementApi;

namespace Auth0.ManagementApi.AttackProtection;

public partial interface ICaptchaPoliciesClient
{
    /// <summary>
    /// Retrieve all CAPTCHA attack protection policies for the tenant, sorted by priority ascending.
    /// </summary>
    WithRawResponseTask<IEnumerable<AttackProtectionCaptchaPolicy>> ListAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a new CAPTCHA attack protection policy for the tenant. The maximum number of policies per tenant is determined by the tenant's subscription.
    /// </summary>
    WithRawResponseTask<AttackProtectionCaptchaPolicy> CreateAsync(
        CreateAttackProtectionCaptchaPolicyRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve a single CAPTCHA attack protection policy for the tenant by ID.
    /// </summary>
    WithRawResponseTask<AttackProtectionCaptchaPolicy> GetAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete a CAPTCHA attack protection policy for the tenant.
    /// </summary>
    WithRawResponseTask DeleteAsync(
        string id,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Partially update a CAPTCHA attack protection policy. Only the provided fields are modified. A provided match or action replaces the stored value in full rather than merging with it; within action, a provider secret or API key that is omitted from a provided provider block keeps its stored value.
    /// </summary>
    WithRawResponseTask<AttackProtectionCaptchaPolicy> UpdateAsync(
        string id,
        UpdateAttackProtectionCaptchaPolicyRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
