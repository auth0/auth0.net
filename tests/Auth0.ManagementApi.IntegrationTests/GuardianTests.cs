using Auth0.Core.Exceptions;
using Auth0.ManagementApi.Models;
using Auth0.Tests.Shared;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class GuardianTests : ManagementTestBase, IAsyncLifetime
    {
        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();

            ApiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"), new HttpClientManagementConnection(options: new HttpClientManagementConnectionOptions { NumberOfHttpRetries = 9 }));
        }

        public override async Task DisposeAsync()
        {
            await CleanupAndDisposeAsync(CleanUpType.Connections);
            await CleanupAndDisposeAsync(CleanUpType.Users);
        }

        [Fact]
        public async Task Can_retrieve_guardian_factors()
        {
            var response = await ApiClient.Guardian.GetFactorsAsync();

            response.Should().HaveCount(8);

            foreach (var guardianFactor in response)
            {
                guardianFactor.Name.Should().NotBeNull();
            }
        }

        [Fact]
        public async Task Retrieving_non_existent_enrollment_throws()
        {
            Func<Task> getFunc = async () => await ApiClient.Guardian.GetEnrollmentAsync("dev_123456");

            (await getFunc.Should().ThrowAsync<ErrorApiException>())
                .And.ApiError.ErrorCode.Should().Be("enrollment_not_found");
        }

        [Fact]
        public async Task Deleting_non_existent_enrollment_throws()
        {
            Func<Task> deleteFunc = async () => await ApiClient.Guardian.DeleteEnrollmentAsync("dev_123456");

            (await deleteFunc.Should().ThrowAsync<ErrorApiException>())
                .And.ApiError.ErrorCode.Should().Be("enrollment_not_found");
        }

        [Fact]
        public async Task Can_perform_sms_template_maintenance()
        {
            // Get the current templates
            var initialTemplates = await ApiClient.Guardian.GetSmsTemplatesAsync();
            initialTemplates.Should().NotBeNull();

            // Update the templates
            var templateUpdateRequest = new GuardianSmsEnrollmentTemplates
            {
                EnrollmentMessage = $"This is the enrollment message {Guid.NewGuid()}",
                VerificationMessage = $"This is the verification message {Guid.NewGuid()}"
            };
            var templateUpdateResponse = await ApiClient.Guardian.UpdateSmsTemplatesAsync(templateUpdateRequest);
            templateUpdateResponse.Should().BeEquivalentTo(templateUpdateRequest);
        }

        [Fact]
        public async Task Can_create_enrollment_ticket()
        {
            Connection connection = null;
            User user = null;
            try
            {
                // Create a connection for creating a user
                connection = await ApiClient.Connections.CreateAsync(new ConnectionCreateRequest
                {
                    Name = $"{TestingConstants.ConnectionPrefix}-{MakeRandomName()}",
                    Strategy = "auth0",
                    EnabledClients = new[]
                    {
                        GetVariable("AUTH0_CLIENT_ID"),
                        GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID")
                    }
                });

                // Create a new user
                var userCreateRequest = new UserCreateRequest
                {
                    Connection = connection.Name,
                    Email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
                    EmailVerified = true,
                    Password = "jd78w3hku23134?"
                };
                user = await ApiClient.Users.CreateAsync(userCreateRequest);

                // Create an enrollment request
                var request = new CreateGuardianEnrollmentTicketRequest
                {
                    UserId = user.UserId,
                    MustSendMail = false
                };
                var response = await ApiClient.Guardian.CreateEnrollmentTicketAsync(request);
                response.TicketId.Should().NotBeNull();
                response.TicketUrl.Should().NotBeNull();
            }
            finally
            {
                // Clean up after ourselves
                if (user != null)
                {
                    await ApiClient.Users.DeleteAsync(user.UserId);
                }

                if (connection != null)
                {

                    await ApiClient.Connections.DeleteAsync(connection.Id);
                }
            }
        }

        [Fact]
        public async Task Can_update_factors()
        {
            UpdateGuardianFactorResponse response;

            response = await ApiClient.Guardian.UpdateFactorAsync(new UpdateGuardianFactorRequest
            {
                Factor = GuardianFactorName.Sms,
                IsEnabled = false
            });
            response.IsEnabled.Should().BeFalse();

            response = await ApiClient.Guardian.UpdateFactorAsync(new UpdateGuardianFactorRequest
            {
                Factor = GuardianFactorName.Sms,
                IsEnabled = true
            });
            response.IsEnabled.Should().BeTrue();

            response = await ApiClient.Guardian.UpdateFactorAsync(new UpdateGuardianFactorRequest
            {
                Factor = GuardianFactorName.PushNotifications,
                IsEnabled = false
            });
            response.IsEnabled.Should().BeFalse();

            response = await ApiClient.Guardian.UpdateFactorAsync(new UpdateGuardianFactorRequest
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
            var response = await ApiClient.Guardian.UpdateTwilioConfigurationAsync(request);
            response.Should().BeEquivalentTo(request);


            request = new UpdateGuardianTwilioConfigurationRequest
            {
                AuthToken = Guid.NewGuid().ToString("N"),
                MessagingServiceSid = Guid.NewGuid().ToString("N"),
                Sid = Guid.NewGuid().ToString("N")
            };
            response = await ApiClient.Guardian.UpdateTwilioConfigurationAsync(request);
            response.Should().BeEquivalentTo(request);

            response = await ApiClient.Guardian.GetTwilioConfigurationAsync();
            response.Should().BeEquivalentTo(request);
        }

        [Fact]
        public async Task Can_update_phone_messagetypes()
        {
            GuardianPhoneMessageTypes response;

            response = await ApiClient.Guardian.UpdatePhoneMessageTypesAsync(new GuardianPhoneMessageTypes
            {
                MessageTypes = new List<string> { "sms" }
            });
            response.MessageTypes.Count.Should().Be(1);

            response = await ApiClient.Guardian.UpdatePhoneMessageTypesAsync(new GuardianPhoneMessageTypes
            {
                MessageTypes = new List<string> { "sms", "voice" }
            });
            response.MessageTypes.Count.Should().Be(2);

            response = await ApiClient.Guardian.GetPhoneMessageTypesAsync();
            response.MessageTypes.Count.Should().Be(2);
        }
    }
}
