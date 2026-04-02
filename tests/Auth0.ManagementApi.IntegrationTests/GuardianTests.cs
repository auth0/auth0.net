using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.Guardian;
using Auth0.ManagementApi.Guardian.Factors;
using Auth0.ManagementApi.Guardian.Factors.Duo;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.Tests.Shared;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests;

public class GuardianTestsFixture : TestBaseFixture
{
    public override async Task DisposeAsync()
    {
        foreach (KeyValuePair<CleanUpType, IList<string>> entry in identifiers)
        {
            await ManagementTestBaseUtils.CleanupAsync(ApiClient, entry.Key, entry.Value);
        }

        ApiClient.Dispose();
    }
}

public class GuardianTests : IClassFixture<GuardianTestsFixture>
{
    private GuardianTestsFixture fixture;

    public GuardianTests(GuardianTestsFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public async Task Can_retrieve_guardian_factors()
    {
        var response = await fixture.ApiClient.Guardian.Factors.ListAsync();

        response.Count().Should().Be(8);

        foreach (var guardianFactor in response)
        {
            guardianFactor.Name.Should().NotBeNull();
        }
    }

    [Fact]
    public async Task Retrieving_non_existent_enrollment_throws()
    {
        Func<Task> getFunc = async () => await fixture.ApiClient.Guardian.Enrollments.GetAsync("dev_123456");

        // The SDK throws ManagementApiException with status 404 for non-existent enrollments
        (await getFunc.Should().ThrowAsync<ManagementApiException>())
            .And.StatusCode.Should().Be(404);
    }

    [Fact]
    public async Task Deleting_non_existent_enrollment_throws()
    {
        Func<Task> deleteFunc = async () => await fixture.ApiClient.Guardian.Enrollments.DeleteAsync("dev_123456");

        // The SDK throws ManagementApiException with status 404 for non-existent enrollments
        (await deleteFunc.Should().ThrowAsync<ManagementApiException>())
            .And.StatusCode.Should().Be(404);
    }

    [Fact]
    public async Task Can_perform_sms_template_maintenance()
    {
        // Get the current templates
        var initialTemplates = await fixture.ApiClient.Guardian.Factors.Sms.GetTemplatesAsync();
        initialTemplates.Should().NotBeNull();

        // Update the templates
        var templateUpdateRequest = new SetGuardianFactorSmsTemplatesRequestContent
        {
            EnrollmentMessage = $"This is the enrollment message {Guid.NewGuid()}",
            VerificationMessage = $"This is the verification message {Guid.NewGuid()}"
        };
        var templateUpdateResponse = await fixture.ApiClient.Guardian.Factors.Sms.SetTemplatesAsync(templateUpdateRequest);
        templateUpdateResponse.EnrollmentMessage.Should().Be(templateUpdateRequest.EnrollmentMessage);
        templateUpdateResponse.VerificationMessage.Should().Be(templateUpdateRequest.VerificationMessage);
    }

    [Fact]
    public async Task Can_create_enrollment_ticket()
    {
        CreateConnectionResponseContent connection = null;
        CreateUserResponseContent user = null;
        try
        {
            // Create a connection for creating a user
            connection = await fixture.ApiClient.Connections.CreateAsync(new CreateConnectionRequestContent
            {
                Name = $"{TestingConstants.ConnectionPrefix}-{TestBaseUtils.MakeRandomName()}",
                Strategy = ConnectionIdentityProviderEnum.Auth0,
                EnabledClients = new[]
                {
                    TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"),
                    TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID")
                }
            });

            fixture.TrackIdentifier(CleanUpType.Connections, connection.Id);

            // Create a new user
            var userCreateRequest = TestBaseUtils.CreateUserRequest(
                connection: connection.Name,
                email: $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
                emailVerified: true,
                password: "jd78w3hku23134?"
            );
            user = await fixture.ApiClient.Users.CreateAsync(userCreateRequest);

            fixture.TrackIdentifier(CleanUpType.Users, user.UserId);

            // Create an enrollment request
            var request = new CreateGuardianEnrollmentTicketRequestContent
            {
                UserId = user.UserId,
                SendMail = false,
                Email = user.Email
            };
            var response = await fixture.ApiClient.Guardian.Enrollments.CreateTicketAsync(request);
            response.TicketId.Should().NotBeNull();
            response.TicketUrl.Should().NotBeNull();
        }
        finally
        {
            // Clean up after ourselves
            if (user != null)
            {
                await fixture.ApiClient.Users.DeleteAsync(user.UserId);
                fixture.UnTrackIdentifier(CleanUpType.Users, user.UserId);
            }

            if (connection != null)
            {

                await fixture.ApiClient.Connections.DeleteAsync(connection.Id);
                fixture.UnTrackIdentifier(CleanUpType.Connections, connection.Id);
            }
        }
    }

    [Fact]
    public async Task Can_update_factors()
    {
        SetGuardianFactorResponseContent response;

        response = await fixture.ApiClient.Guardian.Factors.SetAsync(
            GuardianFactorNameEnum.Sms,
            new SetGuardianFactorRequestContent { Enabled = false });
        response.Enabled.Should().BeFalse();

        response = await fixture.ApiClient.Guardian.Factors.SetAsync(
            GuardianFactorNameEnum.Sms,
            new SetGuardianFactorRequestContent { Enabled = true });
        response.Enabled.Should().BeTrue();

        response = await fixture.ApiClient.Guardian.Factors.SetAsync(
            GuardianFactorNameEnum.PushNotification,
            new SetGuardianFactorRequestContent { Enabled = false });
        response.Enabled.Should().BeFalse();

        response = await fixture.ApiClient.Guardian.Factors.SetAsync(
            GuardianFactorNameEnum.Sms,
            new SetGuardianFactorRequestContent { Enabled = true });
        response.Enabled.Should().BeTrue();
    }

    [Fact]
    public async Task Can_update_twilio_provider_configuration()
    {
        var request = new SetGuardianFactorsProviderPhoneTwilioRequestContent
        {
            AuthToken = Guid.NewGuid().ToString("N"),
            From = "+123456789",
            Sid = Guid.NewGuid().ToString("N")
        };
        var response = await fixture.ApiClient.Guardian.Factors.Phone.SetTwilioProviderAsync(request);
        response.AuthToken.Should().Be(request.AuthToken);
        response.From.Should().Be(request.From);
        response.Sid.Should().Be(request.Sid);


        request = new SetGuardianFactorsProviderPhoneTwilioRequestContent
        {
            AuthToken = Guid.NewGuid().ToString("N"),
            MessagingServiceSid = Guid.NewGuid().ToString("N"),
            Sid = Guid.NewGuid().ToString("N")
        };
        response = await fixture.ApiClient.Guardian.Factors.Phone.SetTwilioProviderAsync(request);
        response.AuthToken.Should().Be(request.AuthToken);
        response.MessagingServiceSid.Should().Be(request.MessagingServiceSid);
        response.Sid.Should().Be(request.Sid);

        var fetchedResponse = await fixture.ApiClient.Guardian.Factors.Phone.GetTwilioProviderAsync();
        fetchedResponse.AuthToken.Should().Be(request.AuthToken);
        fetchedResponse.MessagingServiceSid.Should().Be(request.MessagingServiceSid);
        fetchedResponse.Sid.Should().Be(request.Sid);
    }

    [Fact]
    public async Task Can_update_phone_messagetypes()
    {
        var response =
            await fixture.ApiClient.Guardian.Factors.Phone.SetMessageTypesAsync(
                new SetGuardianFactorPhoneMessageTypesRequestContent
                {
                    MessageTypes = new List<GuardianFactorPhoneFactorMessageTypeEnum> { GuardianFactorPhoneFactorMessageTypeEnum.Sms }
                });

        response.MessageTypes.Count().Should().Be(1);

        response = await fixture.ApiClient.Guardian.Factors.Phone.SetMessageTypesAsync(
            new SetGuardianFactorPhoneMessageTypesRequestContent
            {
                MessageTypes = new List<GuardianFactorPhoneFactorMessageTypeEnum> { GuardianFactorPhoneFactorMessageTypeEnum.Sms, GuardianFactorPhoneFactorMessageTypeEnum.Voice }
            });

        response.MessageTypes.Count().Should().Be(2);

        var getMessageTypesResponse = await fixture.ApiClient.Guardian.Factors.Phone.GetMessageTypesAsync();
        getMessageTypesResponse.MessageTypes.Count().Should().Be(2);
    }

    [Fact]
    public async void Update_Get_duo_configuration_successfully()
    {
        var configurationPatchRequestRequest = new UpdateGuardianFactorDuoSettingsRequestContent
        {
            Host = "api-hostname",
            Ikey = "someKey",
            Skey = "someSecret"
        };
        var configurationPutRequestRequest = new SetGuardianFactorDuoSettingsRequestContent
        {
            Host = "api-hostname",
            Ikey = "someKey",
            Skey = "someSecret"
        };

        // Update using PATCH
        var updatedDuoConfiguration =
            await fixture.ApiClient.Guardian.Factors.Duo.Settings.UpdateAsync(configurationPatchRequestRequest);
        updatedDuoConfiguration.Should().NotBeNull();
        updatedDuoConfiguration.Ikey.Should().Be("someKey");
        updatedDuoConfiguration.Skey.Should().Be("someSecret");
        updatedDuoConfiguration.Host.Should().Be("api-hostname");

        // Update using PUT
        var setDuoConfiguration =
            await fixture.ApiClient.Guardian.Factors.Duo.Settings.SetAsync(configurationPutRequestRequest);
        setDuoConfiguration.Should().NotBeNull();
        setDuoConfiguration.Ikey.Should().Be("someKey");
        setDuoConfiguration.Skey.Should().Be("someSecret");
        setDuoConfiguration.Host.Should().Be("api-hostname");

        // Get DUO configuration
        var duoConfiguration = await fixture.ApiClient.Guardian.Factors.Duo.Settings.GetAsync();
        duoConfiguration.Should().NotBeNull();
        duoConfiguration.Ikey.Should().Be("someKey");
        duoConfiguration.Skey.Should().Be("someSecret");
        duoConfiguration.Host.Should().Be("api-hostname");
    }

    [Fact]
    public async void Update_Get_PhoneProviderConfiguration_successfully()
    {
        var phoneProviderConfiguration = new SetGuardianFactorsProviderPhoneRequestContent
        {
            Provider = GuardianFactorsProviderSmsProviderEnum.Auth0,
        };

        // update phone provider configuration
        var updatedProviderConfiguration =
            await fixture.ApiClient.Guardian.Factors.Phone.SetProviderAsync(phoneProviderConfiguration);
        updatedProviderConfiguration.Should().NotBeNull();
        updatedProviderConfiguration.Provider.Should().Be(GuardianFactorsProviderSmsProviderEnum.Auth0);

        // Get the Phone provider configuration explicitly
        var fetchedPhoneProviderConfiguration = await fixture.ApiClient.Guardian.Factors.Phone.GetSelectedProviderAsync();
        fetchedPhoneProviderConfiguration.Should().NotBeNull();
        fetchedPhoneProviderConfiguration.Provider.Should().Be(GuardianFactorsProviderSmsProviderEnum.Auth0);
    }

    [Fact]
    public async void Update_Get_GuardianPhoneEnrollmentTemplate_successfully()
    {
        var phoneEnrollmentTemplate = new SetGuardianFactorPhoneTemplatesRequestContent
        {
            EnrollmentMessage = "Enrollment message",
            VerificationMessage = "Verification message"
        };

        // update phone enrollment template
        var updatedPhoneEnrollmentTemplate =
            await fixture.ApiClient.Guardian.Factors.Phone.SetTemplatesAsync(phoneEnrollmentTemplate);
        updatedPhoneEnrollmentTemplate.Should().NotBeNull();
        updatedPhoneEnrollmentTemplate.EnrollmentMessage.Should().Be(phoneEnrollmentTemplate.EnrollmentMessage);
        updatedPhoneEnrollmentTemplate.VerificationMessage.Should().Be(phoneEnrollmentTemplate.VerificationMessage);

        // Get the phone enrollment template configuration explicitly
        var fetchedPhoneEnrollmentTemplate = await fixture.ApiClient.Guardian.Factors.Phone.GetTemplatesAsync();
        fetchedPhoneEnrollmentTemplate.Should().NotBeNull();
        fetchedPhoneEnrollmentTemplate.EnrollmentMessage.Should().Be(phoneEnrollmentTemplate.EnrollmentMessage);
        fetchedPhoneEnrollmentTemplate.VerificationMessage.Should().Be(phoneEnrollmentTemplate.VerificationMessage);
    }

    [Fact(Skip = "Run Manually - Requires certificate setup.")]
    public async void Update_Get_PushNotificationApnsProviderConfiguration_successfully()
    {
        var apnsConfigurationUpdateRequest = new SetGuardianFactorsProviderPushNotificationApnsRequestContent
        {
            BundleId = "com.auth0.test",
            Sandbox = true,
            P12 = "random_string"
        };

        // update Push notification APNS provider configuration
        var apnsConfigurationUpdateResponse =
            await fixture.ApiClient.Guardian.Factors.PushNotification.SetApnsProviderAsync(apnsConfigurationUpdateRequest);
        apnsConfigurationUpdateResponse.Should().NotBeNull();

        apnsConfigurationUpdateResponse.Sandbox.Should().Be(apnsConfigurationUpdateRequest.Sandbox);
        apnsConfigurationUpdateResponse.BundleId.Should().Be(apnsConfigurationUpdateRequest.BundleId);

        // update Push notification APNS provider configuration again
        apnsConfigurationUpdateRequest.Sandbox = false;
        apnsConfigurationUpdateResponse =
            await fixture.ApiClient.Guardian.Factors.PushNotification.SetApnsProviderAsync(apnsConfigurationUpdateRequest);
        apnsConfigurationUpdateResponse.Should().NotBeNull();

        apnsConfigurationUpdateResponse.Sandbox.Should().Be(apnsConfigurationUpdateRequest.Sandbox);
        apnsConfigurationUpdateResponse.BundleId.Should().Be(apnsConfigurationUpdateRequest.BundleId);

        // Get the APNS provider configuration explicitly
        var fetchedApnsProviderConfiguration = await fixture.ApiClient.Guardian.Factors.PushNotification.GetApnsProviderAsync();
        fetchedApnsProviderConfiguration.Should().NotBeNull();
        fetchedApnsProviderConfiguration.Sandbox.Should().Be(apnsConfigurationUpdateRequest.Sandbox);
        fetchedApnsProviderConfiguration.BundleId.Should().Be(apnsConfigurationUpdateRequest.BundleId);
    }

    [Fact(Skip = "Run Manually - Requires FCM setup")]
    public async void Test_Update_Fcm_configuration_successfully()
    {
        var fcmConfigurationRequest = new SetGuardianFactorsProviderPushNotificationFcmRequestContent
        {
            ServerKey = "server_key"
        };

        var fcmV1ConfigurationRequest = new SetGuardianFactorsProviderPushNotificationFcmv1RequestContent
        {
            ServerCredentials = "server_credentials"
        };

        // Update FCM configuration
        var response =
            await fixture.ApiClient.Guardian.Factors.PushNotification.SetFcmProviderAsync(fcmConfigurationRequest);
        response.Should().NotBeNull();

        // Update FCMV1 configuration
        response =
            await fixture.ApiClient.Guardian.Factors.PushNotification.SetFcmv1ProviderAsync(fcmV1ConfigurationRequest);
        response.Should().NotBeNull();
    }

    [Fact]
    public async void Update_Get_PushNotificationProviderConfiguration_successfully()
    {
        var pushNotificationProviderConfiguration = new SetGuardianFactorsProviderPushNotificationRequestContent
        {
            Provider = GuardianFactorsProviderPushNotificationProviderDataEnum.Direct,
        };

        // update push notification provider configuration
        var updatedProviderConfiguration =
            await fixture.ApiClient.Guardian.Factors.PushNotification.SetProviderAsync(
                pushNotificationProviderConfiguration);

        updatedProviderConfiguration.Should().NotBeNull();
        updatedProviderConfiguration.Provider.Should().Be(GuardianFactorsProviderPushNotificationProviderDataEnum.Direct);

        // Get the Push Notification provider configuration explicitly
        var fetchedPushNotificationProviderConfiguration =
            await fixture.ApiClient.Guardian.Factors.PushNotification.GetSelectedProviderAsync();
        fetchedPushNotificationProviderConfiguration.Should().NotBeNull();
        fetchedPushNotificationProviderConfiguration.Provider.Should().Be(GuardianFactorsProviderPushNotificationProviderDataEnum.Direct);
    }

    [Fact]
    public async void Update_Get_MultifactorAuthenticationPolicies_successfully()
    {
        try
        {
            // update MFA policy
            var updatedMfaPolicy =
                await fixture.ApiClient.Guardian.Policies.SetAsync(new[] { MfaPolicyEnum.AllApplications });

            updatedMfaPolicy.Should().NotBeNull();
            updatedMfaPolicy.Should().Contain(MfaPolicyEnum.AllApplications);

            // Get the MFA policy
            var mfaPolicy =
                await fixture.ApiClient.Guardian.Policies.ListAsync();
            mfaPolicy.Should().NotBeNull();
            mfaPolicy.Should().Contain(MfaPolicyEnum.AllApplications);
        }
        finally
        {
            await fixture.ApiClient.Guardian.Policies.SetAsync(Array.Empty<MfaPolicyEnum>());
        }
    }
}
