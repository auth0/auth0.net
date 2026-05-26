using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Guardian;

public partial interface IPoliciesClient
{
    /// <summary>
    /// Retrieve the [multi-factor authentication (MFA) policies](https://auth0.com/docs/secure/multi-factor-authentication/enable-mfa) configured for your tenant.
    ///
    /// The following policies are supported:
    ///
    /// - `all-applications` policy prompts with MFA for all logins.
    /// - `confidence-score` policy prompts with MFA only for low confidence logins.
    ///
    /// **Note**: The `confidence-score` policy is part of the [Adaptive MFA feature](https://auth0.com/docs/secure/multi-factor-authentication/adaptive-mfa). Adaptive MFA requires an add-on for the Enterprise plan; review [Auth0 Pricing](https://auth0.com/pricing) for more details.
    /// </summary>
    WithRawResponseTask<IEnumerable<MfaPolicyEnum>> ListAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Set [multi-factor authentication (MFA) policies](https://auth0.com/docs/secure/multi-factor-authentication/enable-mfa) for your tenant.
    ///
    /// The following policies are supported:
    ///
    /// - `all-applications` policy prompts with MFA for all logins.
    /// - `confidence-score` policy prompts with MFA only for low confidence logins.
    ///
    /// **Note**: The `confidence-score` policy is part of the [Adaptive MFA feature](https://auth0.com/docs/secure/multi-factor-authentication/adaptive-mfa). Adaptive MFA requires an add-on for the Enterprise plan; review [Auth0 Pricing](https://auth0.com/pricing) for more details.
    /// </summary>
    WithRawResponseTask<IEnumerable<MfaPolicyEnum>> SetAsync(
        IEnumerable<MfaPolicyEnum> request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
