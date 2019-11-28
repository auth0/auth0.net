using Auth0.Core.Exceptions;
using Auth0.ManagementApi.Models;
using Auth0.Tests.Shared;
using FluentAssertions;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class GuardianTests : TestBase, IAsyncLifetime
    {
        ManagementApiClient _managementApiClient;

        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();

            _managementApiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"));
        }

        public Task DisposeAsync()
        {
            _managementApiClient.Dispose();
            return Task.CompletedTask;
        }

        [Fact]
        public async Task Can_retrieve_guardian_factors()
        {
            var response = await _managementApiClient.Guardian.GetFactorsAsync();

            response.Should().HaveCount(5);
        }

        [Fact]
        public async Task Retrieving_non_existent_enrollment_throws()
        {
            Func<Task> getFunc = async () => await _managementApiClient.Guardian.GetEnrollmentAsync("dev_123456");

            (await getFunc.Should().ThrowAsync<ErrorApiException>())
                .And.ApiError.ErrorCode.Should().Be("enrollment_not_found");
        }

        [Fact]
        public async Task Deleting_non_existent_enrollment_throws()
        {
            Func<Task> deleteFunc = async () => await _managementApiClient.Guardian.DeleteEnrollmentAsync("dev_123456");

            (await deleteFunc.Should().ThrowAsync<ErrorApiException>())
                .And.ApiError.ErrorCode.Should().Be("enrollment_not_found");
        }

        [Fact]
        public async Task Can_perform_sms_template_maintenance()
        {
            // Get the current templates
            var initialTemplates = await _managementApiClient.Guardian.GetSmsTemplatesAsync();
            initialTemplates.Should().NotBeNull();

            // Update the templates
            var templateUpdateRequest = new GuardianSmsEnrollmentTemplates
            {
                EnrollmentMessage = $"This is the enrollment message {Guid.NewGuid()}",
                VerificationMessage = $"This is the verification message {Guid.NewGuid()}"
            };
            var templateUpdateResponse = await _managementApiClient.Guardian.UpdateSmsTemplatesAsync(templateUpdateRequest);
            templateUpdateResponse.Should().BeEquivalentTo(templateUpdateRequest);
        }

        [Fact]
        public async Task Can_create_enrollment_ticket()
        {
            // Create a connection for creating a user
            var connection = await _managementApiClient.Connections.CreateAsync(new ConnectionCreateRequest
            {
                Name = "Temp-Int-Test-" + MakeRandomName(),
                Strategy = "auth0",
                EnabledClients = new[] {
                    GetVariable("AUTH0_CLIENT_ID"),
                    GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID")
                }
            });

            // Create a new user
            var userCreateRequest = new UserCreateRequest
            {
                Connection = connection.Name,
                Email = $"{Guid.NewGuid():N}@nonexistingdomain.aaa",
                EmailVerified = true,
                Password = "jd78w3hku23134?"
            };
            var user = await _managementApiClient.Users.CreateAsync(userCreateRequest);

            // Create an enrollment request
            var request = new CreateGuardianEnrollmentTicketRequest
            {
                UserId = user.UserId,
                MustSendMail = false
            };
            var response = await _managementApiClient.Guardian.CreateEnrollmentTicketAsync(request);
            response.TicketId.Should().NotBeNull();
            response.TicketUrl.Should().NotBeNull();

            // Clean up after ourselves
            await _managementApiClient.Users.DeleteAsync(user.UserId);
            await _managementApiClient.Connections.DeleteAsync(connection.Id);
        }

        [Fact]
        public async Task Can_update_factors()
        {
            UpdateGuardianFactorResponse response;

            response = await _managementApiClient.Guardian.UpdateFactorAsync(new UpdateGuardianFactorRequest
            {
                Factor = GuardianFactorName.Sms,
                IsEnabled = false
            });
            response.IsEnabled.Should().BeFalse();

            response = await _managementApiClient.Guardian.UpdateFactorAsync(new UpdateGuardianFactorRequest
            {
                Factor = GuardianFactorName.Sms,
                IsEnabled = true
            });
            response.IsEnabled.Should().BeTrue();

            response = await _managementApiClient.Guardian.UpdateFactorAsync(new UpdateGuardianFactorRequest
            {
                Factor = GuardianFactorName.PushNotifications,
                IsEnabled = false
            });
            response.IsEnabled.Should().BeFalse();

            response = await _managementApiClient.Guardian.UpdateFactorAsync(new UpdateGuardianFactorRequest
            {
                Factor = GuardianFactorName.Sms,
                IsEnabled = true
            });
            response.IsEnabled.Should().BeTrue();
        }

        [Fact]
        public async Task Can_update_twilio_provider_configuration()
        {
            var request = new UpdateGuardianTwilioConfigurationRequest
            {
                AuthToken = Guid.NewGuid().ToString("N"),
                From = "+123456789",
                Sid = Guid.NewGuid().ToString("N")
            };
            var response = await _managementApiClient.Guardian.UpdateTwilioConfigurationAsync(request);
            response.Should().BeEquivalentTo(request);


            request = new UpdateGuardianTwilioConfigurationRequest
            {
                AuthToken = Guid.NewGuid().ToString("N"),
                MessagingServiceSid = Guid.NewGuid().ToString("N"),
                Sid = Guid.NewGuid().ToString("N")
            };
            response = await _managementApiClient.Guardian.UpdateTwilioConfigurationAsync(request);
            response.Should().BeEquivalentTo(request);

            response = await _managementApiClient.Guardian.GetTwilioConfigurationAsync();
            response.Should().BeEquivalentTo(request);
        }
    }
}
