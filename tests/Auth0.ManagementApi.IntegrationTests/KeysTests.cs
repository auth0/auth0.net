using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class KeysTestsFixture : TestBaseFixture {}

    public class KeysTests : IClassFixture<KeysTestsFixture>
    {
        KeysTestsFixture fixture;

        public KeysTests(KeysTestsFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public async Task Test_keys_can_be_retrieved()
        {
            var signingKeys = await fixture.ApiClient.Keys.GetAllAsync();

            signingKeys.Any().Should().BeTrue();
        }

        [Fact]
        public async Task Test_keys_can_be_retrieved_by_kid()
        {
            var signingKeys = await fixture.ApiClient.Keys.GetAllAsync();

            // select the current key id
            var currentKeyId = signingKeys.First(key => key.Current.HasValue && key.Current.Value).Kid;

            // retrieve the key by id
            var currentKey = await fixture.ApiClient.Keys.GetAsync(currentKeyId);

            currentKey.Kid.Should().Be(currentKeyId);
        }

        [Fact(Skip = "Run Manual")]
        public async Task Test_keys_rotate_signing_key()
        {
            // Rotate the signing key
            var rotateKeyResponse = await fixture.ApiClient.Keys.RotateSigningKeyAsync();
            
            await fixture.InitializeAsync();

            // Get all signing key
            var signingKeys = await fixture.ApiClient.Keys.GetAllAsync();

            // Select the next key
            var nextKey = signingKeys.First(key => key.Next.HasValue && key.Next.Value);

            // Assert
            nextKey.Kid.Should().Be(rotateKeyResponse.Kid);
        }

        
        [Fact(Skip = "Run Manual")]
        public async Task Test_keys_can_be_revoked_by_kid()
        {
            // Rotate the signing key before we revoke
            var rotateKeyResponse = await fixture.ApiClient.Keys.RotateSigningKeyAsync();

            await fixture.InitializeAsync();

            // Get all signing keys
            var signingKeys = await fixture.ApiClient.Keys.GetAllAsync();

            // Select the previous key id
            var previousKeyId = signingKeys.First(key => key.Previous.HasValue && key.Previous.Value).Kid;

            // Revoke the key by id
            var revoked = await fixture.ApiClient.Keys.RevokeSigningKeyAsync(previousKeyId);

            // Assert
            revoked.Kid.Should().Be(previousKeyId);
        }
    }
}
