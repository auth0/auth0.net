using Auth0.Tests.Shared;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Auth0.Core.Exceptions;
using Auth0.ManagementApi.Models;
using FluentAssertions;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class GuardianTests : TestBase, IAsyncLifetime
    {
        IManagementApiClient _managementApiClient;

        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();

            _managementApiClient = new ManagementApiClient(token, new Uri(GetVariable("AUTH0_MANAGEMENT_API_URL")));
        }

        public Task DisposeAsync()
        {
            return Task.CompletedTask;
        }

        [Fact]
        public async Task Can_retrieve_guardian_factors()
        {
            var response = await _managementApiClient.Guardian.GetFactorsAsync();

            response.Should().HaveCount(2);
        }

        [Fact]
        public async Task Retrieving_non_existent_enrollment_throws()
        {
            Func<Task> getFunc = async () => await _managementApiClient.Guardian.GetEnrollment("dev_123456");

            getFunc.ShouldThrow<ApiException>()
                .And.ApiError.ErrorCode.Should().Be("enrollment_not_found");
        }

        [Fact]
        public async Task Deleting_non_existent_enrollment_throws()
        {
            Func<Task> deleteFunc = async () => await _managementApiClient.Guardian.DeleteEnrollment("dev_123456");

            deleteFunc.ShouldThrow<ApiException>()
                .And.ApiError.ErrorCode.Should().Be("enrollment_not_found");
        }

        [Fact]
        public async Task Can_perform_sms_template_maintenance()
        {
            // Get the current templates
            var initialTemplates = await _managementApiClient.Guardian.GetSmsTemplates();
            initialTemplates.Should().NotBeNull();

            // Update the templates
            var templateUpdateRequest = new GuardianSmsEnrollmentTemplates
            {
                EnrollmentMessage = $"This is the enrollment message {Guid.NewGuid()}",
                VerificationMessage = $"This is the verification message {Guid.NewGuid()}"
            };
            var templateUpdateResponse = await _managementApiClient.Guardian.UpdateSmsTemplates(templateUpdateRequest);
            templateUpdateResponse.ShouldBeEquivalentTo(templateUpdateRequest);
        }

        [Fact]
        public async Task Can_create_enrollment_ticket()
        {
            // Create a connection for creating a user
            var connection = await _managementApiClient.Connections.CreateAsync(new ConnectionCreateRequest
            {
                Name = Guid.NewGuid().ToString("N"),
                Strategy = "auth0",
                EnabledClients = new[] { GetVariable("AUTH0_CLIENT_ID"), GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID") }
            });

            // Create a new user
            var userCreateRequest = new UserCreateRequest
            {
                Connection = connection.Name,
                Email = $"{Guid.NewGuid():N}@nonexistingdomain.aaa",
                EmailVerified = true,
                Password = "password"
            };
            var user = await _managementApiClient.Users.CreateAsync(userCreateRequest);

            // Create an enrollment request
            var request = new CreateGuardianEnrollmentTicketRequest
            {
                UserId = user.UserId,
                MustSendMail = false
            };
            var response = await _managementApiClient.Guardian.CreateEnrollmentTicket(request);
            response.TicketId.Should().NotBeNull();
            response.TicketUrl.Should().NotBeNull();

            // Clean up after ourselves
            await _managementApiClient.Users.DeleteAsync(user.UserId);
            await _managementApiClient.Connections.DeleteAsync(connection.Id);
        }
    }
}
