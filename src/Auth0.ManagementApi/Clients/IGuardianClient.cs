namespace Auth0.ManagementApi.Clients
{
  using System.Collections.Generic;
  using System.Threading;
  using System.Threading.Tasks;
  using Models;

  public interface IGuardianClient
  {
    /// <summary>
    /// Generate an email with a link to start the Guardian enrollment process.
    /// </summary>
    /// <param name="request">
    /// The <see cref="CreateGuardianEnrollmentTicketRequest" /> containing the information about the user who should be enrolled.
    /// </param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="CreateGuardianEnrollmentTicketResponse" /> with the details of the ticket that was created.</returns>
    Task<CreateGuardianEnrollmentTicketResponse> CreateEnrollmentTicketAsync(CreateGuardianEnrollmentTicketRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes an enrollment.
    /// </summary>
    /// <param name="id">The ID of the enrollment to delete.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
    Task DeleteEnrollmentAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves an enrollment.
    /// </summary>
    /// <param name="id">The ID of the enrollment to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="GuardianEnrollment"/> containing details of the enrollment.</returns>
    Task<GuardianEnrollment> GetEnrollmentAsync(string id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieve details of all
    /// <a href="https://auth0.com/docs/secure/multi-factor-authentication/multi-factor-authentication-factors">
    /// multi-factor authentication factors associated with your tenant </a>.
    /// </summary>
    /// <returns>List of <see cref="GuardianFactor" /> instances with the available factors.</returns>
    Task<IList<GuardianFactor>> GetFactorsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves enrollment and verification templates. You can use it to check the current values for your templates.
    /// </summary>
    /// <returns>A <see cref="GuardianSmsEnrollmentTemplates" /> containing the templates.</returns>
    Task<GuardianSmsEnrollmentTemplates> GetSmsTemplatesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns provider configuration for AWS SNS.
    /// </summary>
    /// <returns>A <see cref="GuardianSnsConfiguration" /> containing Amazon SNS configuration.</returns>
    Task<GuardianSnsConfiguration> GetSnsConfigurationAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieve configuration details for a Twilio phone provider that has been set up in your tenant.
    /// To learn more, review
    /// <a href ="https://auth0.com/docs/secure/multi-factor-authentication/multi-factor-authentication-factors/configure-sms-voice-notifications-mfa">
    /// Configure SMS and Voice Notifications for MFA. </a>
    /// </summary>
    /// <returns><see cref="GuardianTwilioConfiguration" /> with the Twilio configuration.</returns>
    Task<GuardianTwilioConfiguration> GetTwilioConfigurationAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Enable or Disable a Guardian factor.
    /// </summary>
    /// <param name="request">The <see cref="UpdateGuardianFactorRequest" /> containing the details of the factor to update.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>The <see cref="UpdateGuardianFactorResponse" /> indicating the status of the factor.</returns>
    Task<UpdateGuardianFactorResponse> UpdateFactorAsync(UpdateGuardianFactorRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates enrollment and verification templates. Useful to send custom messages on SMS enrollment and verification.
    /// </summary>
    /// <param name="templates">A <see cref="GuardianSmsEnrollmentTemplates" /> containing the updated templates.</param>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="GuardianSmsEnrollmentTemplates" /> containing the templates.</returns>
    Task<GuardianSmsEnrollmentTemplates> UpdateSmsTemplatesAsync(GuardianSmsEnrollmentTemplates templates, CancellationToken cancellationToken = default);

    /// <summary>
    /// Update the configuration of a Twilio phone provider that has been set up in your tenant.
    /// To learn more, review
    /// <a href="https://auth0.com/docs/secure/multi-factor-authentication/multi-factor-authentication-factors/configure-sms-voice-notifications-mfa">
    /// Configure SMS and Voice Notifications for MFA.</a>
    /// </summary>
    /// <param name="request">
    /// The <see cref="UpdateGuardianTwilioConfigurationRequest" /> containing the configuration settings.
    /// </param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/> - The cancellation token to cancel operation.</param>
    /// <returns>The <see cref="GuardianTwilioConfiguration" /> containing the updated configuration settings.</returns>
    Task<GuardianTwilioConfiguration> UpdateTwilioConfigurationAsync(UpdateGuardianTwilioConfigurationRequest request, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieve list of
    /// <a href="https://auth0.com/docs/secure/multi-factor-authentication/multi-factor-authentication-factors/configure-sms-voice-notifications-mfa">
    /// phone-type MFA factors </a> (i.e., sms and voice) that are enabled for your tenant.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="GuardianPhoneMessageTypes" /> containing the message types.</returns>
    Task<GuardianPhoneMessageTypes> GetPhoneMessageTypesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Replace the list of
    /// <a href="https://auth0.com/docs/secure/multi-factor-authentication/multi-factor-authentication-factors/configure-sms-voice-notifications-mfa">
    /// phone-type MFA factors </a> (i.e., sms and voice) that are enabled for your tenant.
    /// </summary>
    /// <param name="messageTypes">A <see cref="GuardianPhoneMessageTypes" /> containing the list of phone factors to enable on the tenant.</param>
    /// <param name="cancellationToken"><see cref="CancellationToken"/> The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="GuardianPhoneMessageTypes" /> containing the message types.</returns>
    Task<GuardianPhoneMessageTypes> UpdatePhoneMessageTypesAsync(GuardianPhoneMessageTypes messageTypes, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Retrieves the DUO account and factor configuration.
    /// </summary>
    /// <param name="cancellationToken">
    /// <see cref="CancellationToken"/> The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="DuoConfiguration"/> containing the Duo configuration</returns>
    Task<DuoConfiguration> GetDuoConfigurationAsync(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Update the DUO Configuration using PATCH
    /// </summary>
    /// <param name="configuration"><see cref="DuoConfigurationPatchRequest"/></param>
    /// <param name="cancellationToken">
    /// <see cref="CancellationToken"/> The cancellation token to cancel operation.</param>
    /// <returns><see cref="DuoConfiguration"/> containing the updated configuration</returns>
    Task<DuoConfiguration> UpdateDuoConfigurationAsync(
      DuoConfigurationPatchRequest configuration, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Update the DUO Configuration using PUT
    /// </summary>
    /// <param name="configuration"><see cref="DuoConfigurationPatchRequest"/></param>
    /// <param name="cancellationToken">
    /// <see cref="CancellationToken"/> The cancellation token to cancel operation.</param>
    /// <returns><see cref="DuoConfiguration"/> containing the updated configuration</returns>
    Task<DuoConfiguration> UpdateDuoConfigurationAsync(
      DuoConfigurationPutRequest configuration, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Retrieve details of the multi-factor authentication phone provider configured for your tenant.
    /// </summary>
    /// <param name="cancellationToken">
    /// <see cref="CancellationToken"/> The cancellation token to cancel operation.</param>
    /// <returns><see cref="PhoneProviderConfiguration"/></returns>
    Task<PhoneProviderConfiguration> GetPhoneProviderConfigurationAsync(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Update Phone provider configuration.
    /// </summary>
    /// <param name="phoneProviderConfiguraiton"><see cref="PhoneProviderConfiguration"/> - Containing the configuration information to be updated</param>
    /// <param name="cancellationToken">
    /// <see cref="CancellationToken"/> The cancellation token to cancel operation.</param>
    /// <returns><see cref="PhoneProviderConfiguration"/></returns>
    Task<PhoneProviderConfiguration> UpdatePhoneProviderConfigurationAsync(PhoneProviderConfiguration phoneProviderConfiguraiton, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Retrieve details of the multi-factor authentication enrollment and verification templates for
    /// phone-type factors available in your tenant.
    /// </summary>
    /// <param name="cancellationToken">
    /// <see cref="CancellationToken"/> The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="GuardianPhoneEnrollmentTemplate" /> containing the templates.</returns>
    Task<GuardianPhoneEnrollmentTemplate> GetPhoneEnrollmentTemplateAsync(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Customize the messages sent to complete phone enrollment and verification (subscription required).
    /// </summary>
    /// <param name="phoneEnrollmentTemplate">A <see cref="GuardianPhoneEnrollmentTemplate" /> containing the template to be udpated.</param>
    /// <param name="cancellationToken">
    /// <see cref="CancellationToken"/> The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="GuardianPhoneEnrollmentTemplate" /> containing the templates.</returns>
    Task<GuardianPhoneEnrollmentTemplate> UpdatePhoneEnrollmentTemplateAsync(GuardianPhoneEnrollmentTemplate phoneEnrollmentTemplate, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Retrieve configuration details for the multi-factor authentication APNS provider associated with your tenant.
    /// </summary>
    /// <param name="cancellationToken">
    /// <see cref="CancellationToken"/> The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="PushNotificationApnsConfiguration"/> containing the details regarding APNS Push Notification Provider configuration.</returns>
    Task<PushNotificationApnsConfiguration> GetPushNotificationApnsProviderConfigurationAsync(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Overwrite all configuration details of the multi-factor authentication APNS provider associated with your tenant.
    /// </summary>
    /// <param name="request"><see cref="PushNotificationApnsConfigurationPutUpdateRequest"/></param>
    /// <param name="cancellationToken">
    /// <see cref="CancellationToken"/> The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="PushNotificationApnsConfigurationUpdateResponse"/></returns>
    Task<PushNotificationApnsConfigurationUpdateResponse> UpdatePushNotificationApnsProviderConfigurationAsync(
      PushNotificationApnsConfigurationPutUpdateRequest request, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Modify configuration details of the multi-factor authentication APNS provider associated with your tenant.
    /// </summary>
    /// <param name="request"><see cref="PushNotificationApnsConfigurationPatchUpdateRequest"/></param>
    /// <param name="cancellationToken">
    /// <see cref="CancellationToken"/> The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="PushNotificationApnsConfigurationUpdateResponse"/></returns>
    Task<PushNotificationApnsConfigurationUpdateResponse> UpdatePushNotificationApnsProviderConfigurationAsync(
      PushNotificationApnsConfigurationPatchUpdateRequest request, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Modify configuration details of the multi-factor authentication FCM provider associated with your tenant.
    /// </summary>
    /// <param name="request"><see cref="FcmConfigurationPatchUpdateRequest"/></param>
    /// <param name="cancellationToken">
    /// <see cref="CancellationToken"/> The cancellation token to cancel operation.</param>
    /// <returns>An <see cref="object"/> containing information about the FCM configuration</returns>
    Task<object> UpdatePushNotificationFcmConfigurationAsync(FcmConfigurationPatchUpdateRequest request, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Overwrite all configuration details of the multi-factor authentication FCM provider associated with your tenant.
    /// </summary>
    /// <param name="request"><see cref="FcmConfigurationPutUpdateRequest"/></param>
    /// <param name="cancellationToken">
    /// <see cref="CancellationToken"/> The cancellation token to cancel operation.</param>
    /// <returns></returns>
    Task<object> UpdatePushNotificationFcmConfigurationAsync(FcmConfigurationPutUpdateRequest request, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Modify configuration details of the multi-factor authentication FCMV1 provider associated with your tenant.
    /// </summary>
    /// <param name="request"><see cref="FcmV1ConfigurationPatchUpdateRequest"/></param>
    /// <param name="cancellationToken">
    /// <see cref="CancellationToken"/> The cancellation token to cancel operation.</param>
    /// <returns>An <see cref="object"/> containing information about the FCMV1 configuration</returns>
    Task<object> UpdatePushNotificationFcmV1ConfigurationAsync(FcmV1ConfigurationPatchUpdateRequest request, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Overwrite all configuration details of the multi-factor authentication FCMV1 provider associated with your tenant.
    /// </summary>
    /// <param name="request"><see cref="FcmV1ConfigurationPutUpdateRequest"/></param>
    /// <param name="cancellationToken">
    /// <see cref="CancellationToken"/> The cancellation token to cancel operation.</param>
    /// <returns>An <see cref="object"/> containing information about the FCMV1 configuration</returns>
    Task<object> UpdatePushNotificationFcmV1ConfigurationAsync(FcmV1ConfigurationPutUpdateRequest request, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Configure the
    /// <a href="https://auth0.com/docs/multifactor-authentication/developer/sns-configuration">
    /// AWS SNS push notification provider configuration </a> (subscription required).
    /// </summary>
    /// <param name="request"><see cref="GuardianSnsConfigurationPatchUpdateRequest"/></param>
    /// <param name="cancellationToken">
    /// <see cref="CancellationToken"/> The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="GuardianSnsConfiguration"/> containing information about the SNS configuration</returns>
    Task<GuardianSnsConfiguration> UpdatePushNotificationSnsConfigurationAsync(GuardianSnsConfigurationPatchUpdateRequest request, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Configure the
    /// <a href="https://auth0.com/docs/multifactor-authentication/developer/sns-configuration">
    /// AWS SNS push notification provider configuration </a> (subscription required).
    /// </summary>
    /// <param name="request"><see cref="GuardianSnsConfigurationPutUpdateRequest"/></param>
    /// <param name="cancellationToken">
    /// <see cref="CancellationToken"/> The cancellation token to cancel operation.</param>
    /// <returns>A <see cref="GuardianSnsConfiguration"/> containing information about the SNS configuration</returns>
    Task<GuardianSnsConfiguration> UpdatePushNotificationSnsConfigurationAsync(GuardianSnsConfigurationPutUpdateRequest request, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Retrieve details of the push-notification providers configured for your tenant.
    /// </summary>
    /// <param name="cancellationToken">
    /// <see cref="CancellationToken"/> The cancellation token to cancel operation.</param>
    /// <returns><see cref="PushNotificationProviderConfiguration"/></returns>
    Task<PushNotificationProviderConfiguration> GetPushNotificationProviderConfigurationAsync(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Modify the push notification provider configured for your tenant. For more information, review
    /// <a href="https://auth0.com/docs/secure/multi-factor-authentication/multi-factor-authentication-factors/configure-push-notifications-for-mfa">
    /// Configure Push Notifications for MFA. </a>
    /// </summary>
    /// <param name="pushNotificationProviderConfiguration"><see cref="PushNotificationProviderConfiguration"/> - Containing the configuration information to be updated</param>
    /// <param name="cancellationToken">
    /// <see cref="CancellationToken"/> The cancellation token to cancel operation.</param>
    /// <returns><see cref="PushNotificationProviderConfiguration"/></returns>
    Task<PushNotificationProviderConfiguration> UpdatePushNotificationProviderConfigurationAsync(PushNotificationProviderConfiguration pushNotificationProviderConfiguration, CancellationToken cancellationToken = default);
  }
}
