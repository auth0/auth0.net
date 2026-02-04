using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Guardian.Factors;

public partial interface ISmsClient
{
    /// <summary>
    /// Retrieve the <a href="https://auth0.com/docs/multifactor-authentication/twilio-configuration">Twilio SMS provider configuration</a> (subscription required).
    ///
    ///     A new endpoint is available to retrieve the Twilio configuration related to phone factors (<a href='https://auth0.com/docs/api/management/v2/#!/Guardian/get_twilio'>phone Twilio configuration</a>). It has the same payload as this one. Please use it instead.
    /// </summary>
    WithRawResponseTask<GetGuardianFactorsProviderSmsTwilioResponseContent> GetTwilioProviderAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint has been deprecated. To complete this action, use the <a href="https://auth0.com/docs/api/management/v2/guardian/put-twilio">Update Twilio phone configuration</a> endpoint.
    ///
    ///     <b>Previous functionality</b>: Update the Twilio SMS provider configuration.
    /// </summary>
    WithRawResponseTask<SetGuardianFactorsProviderSmsTwilioResponseContent> SetTwilioProviderAsync(
        SetGuardianFactorsProviderSmsTwilioRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint has been deprecated. To complete this action, use the <a href="https://auth0.com/docs/api/management/v2/guardian/get-phone-providers">Retrieve phone configuration</a> endpoint instead.
    ///
    ///     <b>Previous functionality</b>: Retrieve details for the multi-factor authentication SMS provider configured for your tenant.
    /// </summary>
    WithRawResponseTask<GetGuardianFactorsProviderSmsResponseContent> GetSelectedProviderAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint has been deprecated. To complete this action, use the <a href="https://auth0.com/docs/api/management/v2/guardian/put-phone-providers">Update phone configuration</a> endpoint instead.
    ///
    ///     <b>Previous functionality</b>: Update the multi-factor authentication SMS provider configuration in your tenant.
    /// </summary>
    WithRawResponseTask<SetGuardianFactorsProviderSmsResponseContent> SetProviderAsync(
        SetGuardianFactorsProviderSmsRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint has been deprecated. To complete this action, use the <a href="https://auth0.com/docs/api/management/v2/guardian/get-factor-phone-templates">Retrieve enrollment and verification phone templates</a> endpoint instead.
    ///
    ///     <b>Previous function</b>: Retrieve details of SMS enrollment and verification templates configured for your tenant.
    /// </summary>
    WithRawResponseTask<GetGuardianFactorSmsTemplatesResponseContent> GetTemplatesAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// This endpoint has been deprecated. To complete this action, use the <a href="https://auth0.com/docs/api/management/v2/guardian/put-factor-phone-templates">Update enrollment and verification phone templates</a> endpoint instead.
    ///
    ///     <b>Previous functionality</b>: Customize the messages sent to complete SMS enrollment and verification.
    /// </summary>
    WithRawResponseTask<SetGuardianFactorSmsTemplatesResponseContent> SetTemplatesAsync(
        SetGuardianFactorSmsTemplatesRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
