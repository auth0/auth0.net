using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Guardian;

public partial interface IPoliciesClient
{
    /// <summary>
    /// Retrieve the <a href="https://auth0.com/docs/secure/multi-factor-authentication/enable-mfa">multi-factor authentication (MFA) policies</a> configured for your tenant.
    ///
    /// The following policies are supported:
    /// <ul>
    /// <li><code>all-applications</code> policy prompts with MFA for all logins.</li>
    /// <li><code>confidence-score</code> policy prompts with MFA only for low confidence logins.</li>
    /// </ul>
    ///
    /// <b>Note</b>: The <code>confidence-score</code> policy is part of the <a href="https://auth0.com/docs/secure/multi-factor-authentication/adaptive-mfa">Adaptive MFA feature</a>. Adaptive MFA requires an add-on for the Enterprise plan; review <a href="https://auth0.com/pricing">Auth0 Pricing</a> for more details.
    /// </summary>
    WithRawResponseTask<IEnumerable<MfaPolicyEnum>> ListAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Set <a href="https://auth0.com/docs/secure/multi-factor-authentication/enable-mfa">multi-factor authentication (MFA) policies</a> for your tenant.
    ///
    /// The following policies are supported:
    /// <ul>
    /// <li><code>all-applications</code> policy prompts with MFA for all logins.</li>
    /// <li><code>confidence-score</code> policy prompts with MFA only for low confidence logins.</li>
    /// </ul>
    ///
    /// <b>Note</b>: The <code>confidence-score</code> policy is part of the <a href="https://auth0.com/docs/secure/multi-factor-authentication/adaptive-mfa">Adaptive MFA feature</a>. Adaptive MFA requires an add-on for the Enterprise plan; review <a href="https://auth0.com/pricing">Auth0 Pricing</a> for more details.
    /// </summary>
    WithRawResponseTask<IEnumerable<MfaPolicyEnum>> SetAsync(
        IEnumerable<MfaPolicyEnum> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
