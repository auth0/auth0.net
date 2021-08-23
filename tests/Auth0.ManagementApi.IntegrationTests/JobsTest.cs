using Auth0.ManagementApi.Models;
using Auth0.Tests.Shared;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class JobsTest : TestBase, IAsyncLifetime
    {
        private ManagementApiClient _apiClient;
        private Connection _auth0Connection;
        private Connection _emailConnection;
        private User _auth0User;
        private User _emailUser;
        private const string Password = "4cX8awB3T%@Aw-R:=h@ae@k?";

        public async Task InitializeAsync()
        {
            string token = await GenerateManagementApiToken();

            _apiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"));

            // Create a connection
            _auth0Connection = await _apiClient.Connections.CreateAsync(new ConnectionCreateRequest
            {
                Name = "Temp-Int-Test-" + MakeRandomName(),
                Strategy = "auth0",
                EnabledClients = new[] { GetVariable("AUTH0_CLIENT_ID"), GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID") }
            });

            _emailConnection = await _apiClient.Connections.CreateAsync(new ConnectionCreateRequest
            {
                Name = "Temp-Int-Test-" + MakeRandomName(),
                Strategy = "email",
                EnabledClients = new[] { GetVariable("AUTH0_CLIENT_ID"), GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID") }
            });

            // Create a user
            _auth0User = await _apiClient.Users.CreateAsync(new UserCreateRequest
            {
                Connection = _auth0Connection.Name,
                Email = $"{Guid.NewGuid():N}@nonexistingdomain.aaa",
                EmailVerified = true,
                Password = Password
            });

            _emailUser = await _apiClient.Users.CreateAsync(new UserCreateRequest
            {
                Connection = _emailConnection.Name,
                Email = $"{Guid.NewGuid():N}@nonexistingdomain.aaa",
                EmailVerified = true,
            });
        }

        public async Task DisposeAsync()
        {
            await _apiClient.Users.DeleteAsync(_auth0User.UserId);
            await _apiClient.Connections.DeleteAsync(_auth0Connection.Id);

            await _apiClient.Users.DeleteAsync(_emailUser.UserId);
            await _apiClient.Connections.DeleteAsync(_emailConnection.Id);
            _apiClient.Dispose();
        }

        [Fact]
        public async Task Can_send_verification_email()
        {
            var existingOrganizationId = "org_Jif6mLeWXT5ec0nu";

            await _apiClient.Organizations.AddMembersAsync(existingOrganizationId, new OrganizationAddMembersRequest
            {
                Members = new List<string> { _auth0User.UserId }
            });

            var sendVerification = await _apiClient.Jobs.SendVerificationEmailAsync(new VerifyEmailJobRequest
            {
                UserId = _auth0User.UserId,
                ClientId = GetVariable("AUTH0_CLIENT_ID"),
                OrganizationId = existingOrganizationId
            });
            sendVerification.Should().NotBeNull();
            sendVerification.Id.Should().NotBeNull();

            // Check to see whether we can get the same job again
            var job = await _apiClient.Jobs.GetAsync(sendVerification.Id);
            job.Should().NotBeNull();
            job.Id.Should().Be(sendVerification.Id);
            job.Type.Should().Be("verification_email");
            job.Status.Should().Be("pending");
            job.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromMinutes(5));

            await _apiClient.Organizations.DeleteMemberAsync(existingOrganizationId, new OrganizationDeleteMembersRequest
            {
                Members = new List<string> { _auth0User.UserId }
            });
        }

        [Fact]
        public async Task Can_send_verification_email_with_identity()
        {
            var sendVerification = await _apiClient.Jobs.SendVerificationEmailAsync(new VerifyEmailJobRequest
            {
                UserId = _emailUser.UserId,
                ClientId = GetVariable("AUTH0_CLIENT_ID"),
                Identity = new EmailVerificationIdentity
                {
                    Provider = "email",
                    UserId = _emailUser.UserId.Replace("email|", "")
                }
            });
            sendVerification.Should().NotBeNull();
            sendVerification.Id.Should().NotBeNull();

            // Check to see whether we can get the same job again
            var job = await _apiClient.Jobs.GetAsync(sendVerification.Id);
            job.Should().NotBeNull();
            job.Id.Should().Be(sendVerification.Id);
            job.Type.Should().Be("verification_email");
            job.Status.Should().Be("pending");
            job.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromMinutes(5));
        }

        [Fact]
        public async Task Can_import_users()
        {
            // Send a user import request
            using (var stream = GetType().Assembly.GetManifestResourceStream("Auth0.ManagementApi.IntegrationTests.user-import-test.json"))
            {
                var importUsers = await _apiClient.Jobs.ImportUsersAsync(_auth0Connection.Id, "user-import-test.json", stream, sendCompletionEmail: false);
                importUsers.Should().NotBeNull();
                importUsers.Id.Should().NotBeNull();
                importUsers.Type.Should().Be("users_import");
                importUsers.Status.Should().Be("pending");
                importUsers.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromMinutes(5));
                importUsers.ConnectionId.Should().Be(_auth0Connection.Id);
                importUsers.Connection.Should().Be(_auth0Connection.Name);
            }
        }

        [Fact]
        public async Task Can_export_users()
        {
            var request = new UsersExportsJobRequest
            {
                ConnectionId = _auth0Connection.Id,
                Format = UsersExportsJobFormat.JSON,
                Limit = 1,
                Fields = new System.Collections.Generic.List<UsersExportsJobField> { new UsersExportsJobField { Name = "email" } }
            };

            var exportUsers = await _apiClient.Jobs.ExportUsersAsync(request);
            exportUsers.Should().NotBeNull();
            exportUsers.Id.Should().NotBeNull();
            exportUsers.Type.Should().Be("users_export");
            exportUsers.Status.Should().Be("pending");
            exportUsers.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromMinutes(5));
            exportUsers.ConnectionId.Should().Be(_auth0Connection.Id);
            exportUsers.Connection.Should().Be(_auth0Connection.Name);
        }
    }
}