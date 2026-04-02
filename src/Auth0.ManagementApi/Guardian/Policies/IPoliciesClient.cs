using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Guardian;

public partial interface IPoliciesClient
{
    /// <summary>
    /// Retrieve the <see href="https://auth0.com/docs/secure/multi-factor-authentication/enable-mfa">multi-factor authentication (MFA) policies</see> configured for your tenant.
    ///
    /// The following policies are supported:
    /// <list type="bullet">
    /// <item><description><c>all-applications</c> policy prompts with MFA for all logins.</description></item>
    /// <item><description><c>confidence-score</c> policy prompts with MFA only for low confidence logins.</description></item>
    /// </list>
    ///
    /// <b>Note</b>: The <c>confidence-score</c> policy is part of the <see href="https://auth0.com/docs/secure/multi-factor-authentication/adaptive-mfa">Adaptive MFA feature</see>. Adaptive MFA requires an add-on for the Enterprise plan; review <see href="https://auth0.com/pricing">Auth0 Pricing</see> for more details.
    /// </summary>
    WithRawResponseTask<IEnumerable<MfaPolicyEnum>> ListAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Set <see href="https://auth0.com/docs/secure/multi-factor-authentication/enable-mfa">multi-factor authentication (MFA) policies</see> for your tenant.
    ///
    /// The following policies are supported:
    /// <list type="bullet">
    /// <item><description><c>all-applications</c> policy prompts with MFA for all logins.</description></item>
    /// <item><description><c>confidence-score</c> policy prompts with MFA only for low confidence logins.</description></item>
    /// </list>
    ///
    /// <b>Note</b>: The <c>confidence-score</c> policy is part of the <see href="https://auth0.com/docs/secure/multi-factor-authentication/adaptive-mfa">Adaptive MFA feature</see>. Adaptive MFA requires an add-on for the Enterprise plan; review <see href="https://auth0.com/pricing">Auth0 Pricing</see> for more details.
    /// </summary>
    WithRawResponseTask<IEnumerable<MfaPolicyEnum>> SetAsync(
        IEnumerable<MfaPolicyEnum> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
