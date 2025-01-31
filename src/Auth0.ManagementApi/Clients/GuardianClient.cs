using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Auth0.ManagementApi.Models;

namespace Auth0.ManagementApi.Clients
{
    /// <summary>
    /// Contains methods to access the /guardian endpoints.
    /// </summary>
    public class GuardianClient : BaseClient, IGuardianClient
    {
        /// <summary>
        /// Initializes a new instance of <see cref="GuardianClient"/>.
        /// </summary>
        /// <param name="connection"><see cref="IManagementConnection"/> used to make all API calls.</param>
        /// <param name="baseUri"><see cref="Uri"/> of the endpoint to use in making API calls.</param>
        /// <param name="defaultHeaders">Dictionary containing default headers included with every request this client makes.</param>
        public GuardianClient(IManagementConnection connection, Uri baseUri, IDictionary<string, string> defaultHeaders)
            : base(connection, baseUri, defaultHeaders)
        {
        }

        /// <summary>
        /// Create a
        /// <a href='https://auth0.com/docs/secure/multi-factor-authentication/auth0-guardian/create-custom-enrollment-tickets'>
        /// multi-factor authentication (MFA) enrollment ticket </a>, and optionally send an email with the created
        /// ticket, to a given user.
        /// </summary>
        /// <param name="request">
        /// The <see cref="CreateGuardianEnrollmentTicketRequest" /> containing the information about the user
        /// who should be enrolled.
        /// </param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="CreateGuardianEnrollmentTicketResponse" /> with the details of the ticket that
        /// was created.</returns>
        public Task<CreateGuardianEnrollmentTicketResponse> CreateEnrollmentTicketAsync(
            CreateGuardianEnrollmentTicketRequest request, CancellationToken cancellationToken = default)
        {
            return Connection
                .SendAsync<CreateGuardianEnrollmentTicketResponse>(
                HttpMethod.Post,
                BuildUri("guardian/enrollments/ticket"),
                request,
                DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Remove a specific multi-factor authentication (MFA) enrollment from a user's account.
        /// This allows the user to re-enroll with MFA. For more information,
        /// review <a href="https://auth0.com/docs/secure/multi-factor-authentication/reset-user-mfa">
        /// Reset User Multi-Factor Authentication and Recovery Codes.</a>
        /// </summary>
        /// <param name="id">The ID of the enrollment to delete.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="Task"/> that represents the asynchronous delete operation.</returns>
        public Task DeleteEnrollmentAsync(string id, CancellationToken cancellationToken = default)
        {
            return Connection
                .SendAsync<object>(
                HttpMethod.Delete,
                BuildUri($"guardian/enrollments/{EncodePath(id)}"),
                null,
                DefaultHeaders, 
                cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Retrieve details, such as status and type, for a specific multi-factor authentication enrollment
        /// registered to a user account.
        /// </summary>
        /// <param name="id">The ID of the enrollment to retrieve.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="GuardianEnrollment"/> containing details of the enrollment.</returns>
        public Task<GuardianEnrollment> GetEnrollmentAsync(string id, CancellationToken cancellationToken = default)
        {
            return Connection
                .GetAsync<GuardianEnrollment>(
                BuildUri($"guardian/enrollments/{EncodePath(id)}"),
                DefaultHeaders, cancellationToken: cancellationToken);
        }
        
        /// <inheritdoc />
        public Task<IList<GuardianFactor>> GetFactorsAsync(CancellationToken cancellationToken = default)
        {
            return Connection
                .GetAsync<IList<GuardianFactor>>(
                BuildUri("guardian/factors"),
                DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Retrieves enrollment and verification templates. You can use it to check the current values for your templates.
        /// </summary>
        /// <returns>A <see cref="GuardianSmsEnrollmentTemplates" /> containing the templates.</returns>
        public Task<GuardianSmsEnrollmentTemplates> GetSmsTemplatesAsync(CancellationToken cancellationToken = default)
        {
            return Connection
                .GetAsync<GuardianSmsEnrollmentTemplates>(
                BuildUri("guardian/factors/sms/templates"),
                DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Returns provider configuration for AWS SNS.
        /// </summary>
        /// <returns>A <see cref="GuardianSnsConfiguration" /> containing Amazon SNS configuration.</returns>
        public Task<GuardianSnsConfiguration> GetSnsConfigurationAsync(CancellationToken cancellationToken = default)
        {
            return Connection
                .GetAsync<GuardianSnsConfiguration>(
                BuildUri("guardian/factors/push-notification/providers/sns"),
                DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <inheritdoc />
        public Task<GuardianTwilioConfiguration> GetTwilioConfigurationAsync(
            CancellationToken cancellationToken = default)
        {
            return Connection
                .GetAsync<GuardianTwilioConfiguration>(
                BuildUri("guardian/factors/sms/providers/twilio"),
                DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <inheritdoc />
        public Task<UpdateGuardianFactorResponse> UpdateFactorAsync(
            UpdateGuardianFactorRequest request, CancellationToken cancellationToken = default)
        {
            var name = request.Factor.ToEnumString();

            return Connection
                .SendAsync<UpdateGuardianFactorResponse>(
                HttpMethod.Put,
                BuildUri($"guardian/factors/{name}"),
                new { enabled = request.IsEnabled },
                DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Updates enrollment and verification templates. Useful to send custom messages on SMS enrollment and verification.
        /// </summary>
        /// <param name="templates">A <see cref="GuardianSmsEnrollmentTemplates" /> containing the updated templates.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A <see cref="GuardianSmsEnrollmentTemplates" /> containing the templates.</returns>
        public Task<GuardianSmsEnrollmentTemplates> UpdateSmsTemplatesAsync(
            GuardianSmsEnrollmentTemplates templates, CancellationToken cancellationToken = default)
        {
            return Connection
                .SendAsync<GuardianSmsEnrollmentTemplates>(
                HttpMethod.Put,
                BuildUri("guardian/factors/sms/templates"),
                templates,
                DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <inheritdoc />
        public Task<GuardianTwilioConfiguration> UpdateTwilioConfigurationAsync(
            UpdateGuardianTwilioConfigurationRequest request, CancellationToken cancellationToken = default)
        {
            return Connection
                .SendAsync<GuardianTwilioConfiguration>(
                HttpMethod.Put,
                BuildUri("guardian/factors/sms/providers/twilio"),
                request,
                DefaultHeaders, cancellationToken: cancellationToken);
        }

        /// <inheritdoc />
        public Task<GuardianPhoneMessageTypes> GetPhoneMessageTypesAsync(CancellationToken cancellationToken = default)
        {
            return Connection
                .GetAsync<GuardianPhoneMessageTypes>(
                    BuildUri("guardian/factors/phone/message-types"),
                    DefaultHeaders,
                    cancellationToken: cancellationToken
                 );
        }

        /// <inheritdoc />
        public Task<GuardianPhoneMessageTypes> UpdatePhoneMessageTypesAsync(
            GuardianPhoneMessageTypes messageTypes, CancellationToken cancellationToken = default)
        {
            return Connection
                .SendAsync<GuardianPhoneMessageTypes>(
                    HttpMethod.Put,
                    BuildUri("guardian/factors/phone/message-types"),
                    messageTypes,
                    DefaultHeaders,
                    cancellationToken: cancellationToken
                );
        }

        /// <inheritdoc />
        public Task<DuoConfiguration> GetDuoConfigurationAsync(CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<DuoConfiguration>(
                BuildUri("guardian/factors/duo/settings"),
                DefaultHeaders,
                cancellationToken: cancellationToken
                );
        }

        /// <inheritdoc />
        public Task<DuoConfiguration> UpdateDuoConfigurationAsync(
            DuoConfigurationPatchRequest configuration,
            CancellationToken cancellationToken = default)
        {
            return Connection
                .SendAsync<DuoConfiguration>(
                    new HttpMethod("PATCH"),
                    BuildUri("guardian/factors/duo/settings"),
                    configuration,
                    DefaultHeaders,
                    cancellationToken: cancellationToken);        
        }

        /// <inheritdoc />
        public Task<DuoConfiguration> UpdateDuoConfigurationAsync(
            DuoConfigurationPutRequest configuration,
            CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<DuoConfiguration>(
                    HttpMethod.Put,
                    BuildUri("guardian/factors/duo/settings"),
                    configuration,
                    DefaultHeaders,
                    cancellationToken: cancellationToken
                );
        }

        /// <inheritdoc />
        public Task<PhoneProviderConfiguration> GetPhoneProviderConfigurationAsync(
            CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<PhoneProviderConfiguration>(
                BuildUri("guardian/factors/phone/selected-provider"),
                DefaultHeaders,
                cancellationToken: cancellationToken
                );
        }

        /// <inheritdoc />
        public Task<PhoneProviderConfiguration> UpdatePhoneProviderConfigurationAsync(
            PhoneProviderConfiguration phoneProviderConfiguraiton,
            CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<PhoneProviderConfiguration>(
                HttpMethod.Put,
                BuildUri("guardian/factors/phone/selected-provider"),
                phoneProviderConfiguraiton,
                DefaultHeaders,
                cancellationToken: cancellationToken
                );
        }

        /// <inheritdoc />
        public Task<GuardianPhoneEnrollmentTemplate> GetPhoneEnrollmentTemplateAsync(
            CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<GuardianPhoneEnrollmentTemplate>(
                BuildUri("guardian/factors/phone/templates"),
                DefaultHeaders,
                cancellationToken: cancellationToken
                );
        }

        /// <inheritdoc />
        public Task<GuardianPhoneEnrollmentTemplate> UpdatePhoneEnrollmentTemplateAsync(
            GuardianPhoneEnrollmentTemplate phoneEnrollmentTemplate,
            CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<GuardianPhoneEnrollmentTemplate>(
                HttpMethod.Put,
                BuildUri("guardian/factors/phone/templates"),
                phoneEnrollmentTemplate,
                DefaultHeaders,
                cancellationToken: cancellationToken
                );
        }

        /// <inheritdoc />
        public Task<PushNotificationApnsConfiguration> GetPushNotificationApnsProviderConfigurationAsync(
            CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<PushNotificationApnsConfiguration>(
                BuildUri("guardian/factors/push-notification/providers/apns"),
                DefaultHeaders,
                cancellationToken: cancellationToken
                );
        }

        /// <inheritdoc />
        public Task<PushNotificationApnsConfigurationUpdateResponse> UpdatePushNotificationApnsProviderConfigurationAsync(
            PushNotificationApnsConfigurationPutUpdateRequest request,
            CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<PushNotificationApnsConfigurationUpdateResponse>(
                HttpMethod.Put,
                BuildUri("guardian/factors/push-notification/providers/apns"),
                request,
                DefaultHeaders,
                cancellationToken: cancellationToken
                );
        }

        /// <inheritdoc />
        public Task<PushNotificationApnsConfigurationUpdateResponse> UpdatePushNotificationApnsProviderConfigurationAsync(
            PushNotificationApnsConfigurationPatchUpdateRequest request,
            CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<PushNotificationApnsConfigurationUpdateResponse>(
                new HttpMethod("PATCH"),
                BuildUri("guardian/factors/push-notification/providers/apns"),
                request,
                DefaultHeaders,
                cancellationToken: cancellationToken
                );
        }

        /// <inheritdoc />
        public Task<object> UpdatePushNotificationFcmConfigurationAsync(
            FcmConfigurationPatchUpdateRequest request,
            CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<object>(
                new HttpMethod("PATCH"),
                BuildUri("guardian/factors/push-notification/providers/fcm"),
                request,
                DefaultHeaders,
                cancellationToken: cancellationToken
                );
        }

        /// <inheritdoc />
        public Task<object> UpdatePushNotificationFcmConfigurationAsync(
            FcmConfigurationPutUpdateRequest request,
            CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<object>(
                HttpMethod.Put,
                BuildUri("guardian/factors/push-notification/providers/fcm"),
                request,
                DefaultHeaders,
                cancellationToken: cancellationToken
                );
        }

        /// <inheritdoc />
        public Task<object> UpdatePushNotificationFcmV1ConfigurationAsync(FcmV1ConfigurationPatchUpdateRequest request,
            CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<object>(
                new HttpMethod("PATCH"),
                BuildUri("guardian/factors/push-notification/providers/fcmv1"),
                request,
                DefaultHeaders,
                cancellationToken: cancellationToken
                );
        }
        
        /// <inheritdoc />
        public Task<object> UpdatePushNotificationFcmV1ConfigurationAsync(FcmV1ConfigurationPutUpdateRequest request,
            CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<object>(
                HttpMethod.Put,
                BuildUri("guardian/factors/push-notification/providers/fcmv1"),
                request,
                DefaultHeaders,
                cancellationToken: cancellationToken
                );        
        }

        /// <inheritdoc />
        public Task<GuardianSnsConfiguration> UpdatePushNotificationSnsConfigurationAsync(
            GuardianSnsConfigurationPatchUpdateRequest request,
            CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<GuardianSnsConfiguration>(
                new HttpMethod("PATCH"),
                BuildUri("guardian/factors/push-notification/providers/sns"),
                request,
                DefaultHeaders,
                cancellationToken: cancellationToken
            );
        }

        /// <inheritdoc />
        public Task<GuardianSnsConfiguration> UpdatePushNotificationSnsConfigurationAsync(
            GuardianSnsConfigurationPutUpdateRequest request,
            CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<GuardianSnsConfiguration>(
                HttpMethod.Put,
                BuildUri("guardian/factors/push-notification/providers/sns"),
                request,
                DefaultHeaders,
                cancellationToken: cancellationToken
            );
        }

        /// <inheritdoc />
        public Task<PushNotificationProviderConfiguration> GetPushNotificationProviderConfigurationAsync(
            CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<PushNotificationProviderConfiguration>(
                BuildUri("guardian/factors/push-notification/selected-provider"),
                DefaultHeaders,
                cancellationToken: cancellationToken
            );
        }

        /// <inheritdoc />
        public Task<PushNotificationProviderConfiguration> UpdatePushNotificationProviderConfigurationAsync(
            PushNotificationProviderConfiguration pushNotificationProviderConfiguration,
            CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<PushNotificationProviderConfiguration>(
                HttpMethod.Put,
                BuildUri("guardian/factors/push-notification/selected-provider"),
                pushNotificationProviderConfiguration,
                DefaultHeaders,
                cancellationToken: cancellationToken
            );
        }

        /// <inheritdoc />
        public Task<string[]> GetMultifactorAuthenticationPolicies(CancellationToken cancellationToken = default)
        {
            return Connection.GetAsync<string[]>(
                BuildUri("guardian/policies"),
                DefaultHeaders,
                cancellationToken: cancellationToken
            );
        }

        /// <inheritdoc />
        public Task<string[]> UpdateMultifactorAuthenticationPolicies(
            string[] mfaPolicies,
            CancellationToken cancellationToken = default)
        {
            return Connection.SendAsync<string[]>(
                HttpMethod.Put,
                BuildUri("guardian/policies"),
                mfaPolicies,
                DefaultHeaders,
                cancellationToken: cancellationToken
            );
        }
    }
}
