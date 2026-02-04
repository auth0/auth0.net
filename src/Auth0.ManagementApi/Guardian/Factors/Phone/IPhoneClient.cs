using Auth0.ManagementApi;

namespace Auth0.ManagementApi.Guardian.Factors;

public partial interface IPhoneClient
{
    /// <summary>
    /// Retrieve list of <a href="https://auth0.com/docs/secure/multi-factor-authentication/multi-factor-authentication-factors/configure-sms-voice-notifications-mfa">phone-type MFA factors</a> (i.e., sms and voice) that are enabled for your tenant.
    /// </summary>
    WithRawResponseTask<GetGuardianFactorPhoneMessageTypesResponseContent> GetMessageTypesAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Replace the list of <a href="https://auth0.com/docs/secure/multi-factor-authentication/multi-factor-authentication-factors/configure-sms-voice-notifications-mfa">phone-type MFA factors</a> (i.e., sms and voice) that are enabled for your tenant.
    /// </summary>
    WithRawResponseTask<SetGuardianFactorPhoneMessageTypesResponseContent> SetMessageTypesAsync(
        SetGuardianFactorPhoneMessageTypesRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve configuration details for a Twilio phone provider that has been set up in your tenant. To learn more, review <a href="https://auth0.com/docs/secure/multi-factor-authentication/multi-factor-authentication-factors/configure-sms-voice-notifications-mfa">Configure SMS and Voice Notifications for MFA</a>.
    /// </summary>
    WithRawResponseTask<GetGuardianFactorsProviderPhoneTwilioResponseContent> GetTwilioProviderAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update the configuration of a Twilio phone provider that has been set up in your tenant. To learn more, review <a href="https://auth0.com/docs/secure/multi-factor-authentication/multi-factor-authentication-factors/configure-sms-voice-notifications-mfa">Configure SMS and Voice Notifications for MFA</a>.
    /// </summary>
    WithRawResponseTask<SetGuardianFactorsProviderPhoneTwilioResponseContent> SetTwilioProviderAsync(
        SetGuardianFactorsProviderPhoneTwilioRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve details of the multi-factor authentication phone provider configured for your tenant.
    /// </summary>
    WithRawResponseTask<GetGuardianFactorsProviderPhoneResponseContent> GetSelectedProviderAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    WithRawResponseTask<SetGuardianFactorsProviderPhoneResponseContent> SetProviderAsync(
        SetGuardianFactorsProviderPhoneRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieve details of the multi-factor authentication enrollment and verification templates for phone-type factors available in your tenant.
    /// </summary>
    WithRawResponseTask<GetGuardianFactorPhoneTemplatesResponseContent> GetTemplatesAsync(
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Customize the messages sent to complete phone enrollment and verification (subscription required).
    /// </summary>
    WithRawResponseTask<SetGuardianFactorPhoneTemplatesResponseContent> SetTemplatesAsync(
        SetGuardianFactorPhoneTemplatesRequestContent request,
        RequestOptions? options = null,
        CancellationToken cancellationToken = default
    );
}
