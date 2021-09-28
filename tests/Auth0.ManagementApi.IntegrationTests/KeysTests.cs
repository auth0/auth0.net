using System.Linq;
using System.Threading.Tasks;
using Auth0.ManagementApi.Models;
using FluentAssertions;
using Xunit;
using Auth0.Tests.Shared;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class KeysTests : TestBase, IAsyncLifetime
    {
        private ManagementApiClient _apiClient;
        private Connection _connection;
        private const string Password = "4cX8awB3T%@Aw-R:=h@ae@k?";

        public async Task InitializeAsync()
        {
            await GetTokenAndInitializeAsync();

            // We will need a connection to add the roles to...
            _connection = await _apiClient.Connections.CreateAsync(new ConnectionCreateRequest
            {
                Name = "Temp-Int-Test-" + MakeRandomName(),
                Strategy = "auth0",
                EnabledClients = new[] {GetVariable("AUTH0_CLIENT_ID"), GetVariable("AUTH0_MANAGEMENT_API_CLIENT_ID")}
            });
        }

        private async Task GetTokenAndInitializeAsync()
        {
            string token = await GenerateManagementApiToken();

            _apiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"), new HttpClientManagementConnection(options: new HttpClientManagementConnectionOptions { NumberOfHttpRetries = 9 }));
        }

        public async Task DisposeAsync()
        {
            await _apiClient.Connections.DeleteAsync(_connection.Id);
            _apiClient.Dispose();
        }

        [Fact]
        public async Task Test_keys_can_be_retrieved()
        {
            var signingKeys = await _apiClient.Keys.GetAllAsync();

            signingKeys.Any().Should().BeTrue();
        }

        [Fact]
        public async Task Test_keys_can_be_retrieved_by_kid()
        {
            var signingKeys = await _apiClient.Keys.GetAllAsync();

            // select the current key id
            var currentKeyId = signingKeys.First(key => key.Current.HasValue && key.Current.Value).Kid;

            // retrieve the key by id
            var currentKey = await _apiClient.Keys.GetAsync(currentKeyId);

            currentKey.Kid.Should().Be(currentKeyId);
        }

        [Fact(Skip = "Run Manual")]
        public async Task Test_keys_rotate_signing_key()
        {
            // Rotate the signing key
            var rotateKeyResponse = await _apiClient.Keys.RotateSigningKeyAsync();
            
            await GetTokenAndInitializeAsync();

            // Get all signing key
            var signingKeys = await _apiClient.Keys.GetAllAsync();

            // Select the next key
            var nextKey = signingKeys.First(key => key.Next.HasValue && key.Next.Value);

            // Assert
            nextKey.Kid.Should().Be(rotateKeyResponse.Kid);
        }

        
        [Fact(Skip = "Run Manual")]
        public async Task Test_keys_can_be_revoked_by_kid()
        {
            // Rotate the signing key before we revoke
            var rotateKeyResponse = await _apiClient.Keys.RotateSigningKeyAsync();

            await GetTokenAndInitializeAsync();

            // Get all signing keys
            var signingKeys = await _apiClient.Keys.GetAllAsync();

            // Select the previous key id
            var previousKeyId = signingKeys.First(key => key.Previous.HasValue && key.Previous.Value).Kid;

            // Revoke the key by id
            var revoked = await _apiClient.Keys.RevokeSigningKeyAsync(previousKeyId);

            // Assert
            revoked.Kid.Should().Be(previousKeyId);
        }
    }
}
