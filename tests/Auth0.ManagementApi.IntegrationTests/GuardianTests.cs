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
        GuardianTestsFixture fixture;

        public GuardianTests(GuardianTestsFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public async Task Can_retrieve_guardian_factors()
        {
            var response = await fixture.ApiClient.Guardian.GetFactorsAsync();

            response.Should().HaveCount(8);

            foreach (var guardianFactor in response)
            {
                guardianFactor.Name.Should().NotBeNull();
            }
        }

        [Fact]
        public async Task Retrieving_non_existent_enrollment_throws()
        {
            Func<Task> getFunc = async () => await fixture.ApiClient.Guardian.GetEnrollmentAsync("dev_123456");

            (await getFunc.Should().ThrowAsync<ErrorApiException>())
                .And.ApiError.ErrorCode.Should().Be("enrollment_not_found");
        }

        [Fact]
        public async Task Deleting_non_existent_enrollment_throws()
        {
            Func<Task> deleteFunc = async () => await fixture.ApiClient.Guardian.DeleteEnrollmentAsync("dev_123456");

            (await deleteFunc.Should().ThrowAsync<ErrorApiException>())
                .And.ApiError.ErrorCode.Should().Be("enrollment_not_found");
        }

        [Fact]
        public async Task Can_perform_sms_template_maintenance()
        {
            // Get the current templates
            var initialTemplates = await fixture.ApiClient.Guardian.GetSmsTemplatesAsync();
            initialTemplates.Should().NotBeNull();

            // Update the templates
            var templateUpdateRequest = new GuardianSmsEnrollmentTemplates
            {
                EnrollmentMessage = $"This is the enrollment message {Guid.NewGuid()}",
                VerificationMessage = $"This is the verification message {Guid.NewGuid()}"
            };
            var templateUpdateResponse = await fixture.ApiClient.Guardian.UpdateSmsTemplatesAsync(templateUpdateRequest);
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
                connection = await fixture.ApiClient.Connections.CreateAsync(new ConnectionCreateRequest
                {
                    Name = $"{TestingConstants.ConnectionPrefix}-{TestBaseUtils.MakeRandomName()}",
                    Strategy = "auth0",
                    EnabledClients = new[]
                    {
                        TestBaseUtils.GetVariable("AUTH0_CLIENT_ID"),
                        TestBaseUtils.GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID")
                    }
                });

                fixture.TrackIdentifier(CleanUpType.Connections, connection.Id);

                // Create a new user
                var userCreateRequest = new UserCreateRequest
                {
                    Connection = connection.Name,
                    Email = $"{Guid.NewGuid():N}{TestingConstants.UserEmailDomain}",
                    EmailVerified = true,
                    Password = "jd78w3hku23134?"
                };
                user = await fixture.ApiClient.Users.CreateAsync(userCreateRequest);

                fixture.TrackIdentifier(CleanUpType.Users, user.UserId);

                // Create an enrollment request
                var request = new CreateGuardianEnrollmentTicketRequest
                {
                    UserId = user.UserId,
                    MustSendMail = false
                };
                var response = await fixture.ApiClient.Guardian.CreateEnrollmentTicketAsync(request);
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
            UpdateGuardianFactorResponse response;

            response = await fixture.ApiClient.Guardian.UpdateFactorAsync(new UpdateGuardianFactorRequest
            {
                Factor = GuardianFactorName.Sms,
                IsEnabled = false
            });
            response.IsEnabled.Should().BeFalse();

            response = await fixture.ApiClient.Guardian.UpdateFactorAsync(new UpdateGuardianFactorRequest
            {
                Factor = GuardianFactorName.Sms,
                IsEnabled = true
            });
            response.IsEnabled.Should().BeTrue();

            response = await fixture.ApiClient.Guardian.UpdateFactorAsync(new UpdateGuardianFactorRequest
            {
                Factor = GuardianFactorName.PushNotifications,
                IsEnabled = false
            });
            response.IsEnabled.Should().BeFalse();

            response = await fixture.ApiClient.Guardian.UpdateFactorAsync(new UpdateGuardianFactorRequest
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
            var response = await fixture.ApiClient.Guardian.UpdateTwilioConfigurationAsync(request);
            response.Should().BeEquivalentTo(request);


            request = new UpdateGuardianTwilioConfigurationRequest
            {
                AuthToken = Guid.NewGuid().ToString("N"),
                MessagingServiceSid = Guid.NewGuid().ToString("N"),
                Sid = Guid.NewGuid().ToString("N")
            };
            response = await fixture.ApiClient.Guardian.UpdateTwilioConfigurationAsync(request);
            response.Should().BeEquivalentTo(request);

            response = await fixture.ApiClient.Guardian.GetTwilioConfigurationAsync();
            response.Should().BeEquivalentTo(request);
        }

        [Fact]
        public async Task Can_update_phone_messagetypes()
        {
            GuardianPhoneMessageTypes response;

            response = await fixture.ApiClient.Guardian.UpdatePhoneMessageTypesAsync(new GuardianPhoneMessageTypes
            {
                MessageTypes = new List<string> { "sms" }
            });
            response.MessageTypes.Count.Should().Be(1);

            response = await fixture.ApiClient.Guardian.UpdatePhoneMessageTypesAsync(new GuardianPhoneMessageTypes
            {
                MessageTypes = new List<string> { "sms", "voice" }
            });
            response.MessageTypes.Count.Should().Be(2);

            response = await fixture.ApiClient.Guardian.GetPhoneMessageTypesAsync();
            response.MessageTypes.Count.Should().Be(2);
        }
    }
}
