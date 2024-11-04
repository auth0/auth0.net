using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Auth0.IntegrationTests.Shared.CleanUp;
using Auth0.ManagementApi.Clients;
using Auth0.ManagementApi.IntegrationTests.Testing;
using Auth0.ManagementApi.Models.Keys;
using Auth0.ManagementApi.Paging;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests
{
    public class KeysTestsFixture : TestBaseFixture
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

        [Fact]
        public async Task Test_encryption_keys_crud_sequence()
        {
            var encryptionKeysCreateRequest = new EncryptionKeyCreateRequest()
            {
                Type = "customer-provided-root-key"
            };
            // Create a new Encryption Key for testing purpose
            var encryptionKey = await fixture.ApiClient.Keys.CreateEncryptionKeyAsync(encryptionKeysCreateRequest);
            fixture.TrackIdentifier(CleanUpType.EncryptionKeys, encryptionKey.Kid);
            
            encryptionKey.Type.Should().Be(EncryptionKeyType.CustomerProvidedRootKey);
            encryptionKey.State.Should().NotBeNull();
            
            // Get all the existing encryption keys
            var allEncryptionKeys = 
                await fixture.ApiClient.Keys.GetAllEncryptionKeysAsync(new PaginationInfo());
            allEncryptionKeys.Count.Should().BeGreaterThan(0);
            
            // Get the newly created encryption key by its kid
            var encryptionKeyById = await fixture.ApiClient.Keys.GetEncryptionKeyAsync(new EncryptionKeyGetRequest()
            {
                Kid = encryptionKey.Kid     
            });
            encryptionKeyById.Should().BeEquivalentTo(encryptionKey);

            // Create Public key wrapping
            var wrapping = await fixture.ApiClient.Keys.CreatePublicWrappingKeyAsync(new WrappingKeyCreateRequest()
            {
                Kid = encryptionKey.Kid
            });

            wrapping.Should().NotBeNull();
            wrapping.Algorithm.Should().NotBeNull();
            wrapping.PublicKey.Should().NotBeNull();

            // Delete the encryption key
            await fixture.ApiClient.Keys.DeleteEncryptionKeyAsync(encryptionKey.Kid);
            fixture.UnTrackIdentifier(CleanUpType.EncryptionKeys, encryptionKey.Kid);
            var allEncryptionKeysAfterCleanup = 
                await fixture.ApiClient.Keys.GetAllEncryptionKeysAsync(new PaginationInfo());
            allEncryptionKeysAfterCleanup.Should().NotContain(encryptionKey);
        }
        
        [Fact]
        public async void Test_import_encrypted_keys()
        {
            var sampleImportEncryptionKeyResponse = 
                await File.ReadAllTextAsync("./Data/ImportEncryptionKeyResponse.json");
            var httpClientManagementConnection = new HttpClientManagementConnection();
            var importedKeys = 
                httpClientManagementConnection.DeserializeContent<EncryptionKey>(sampleImportEncryptionKeyResponse, null);
            importedKeys.PublicKey.Should().Be("Random-PUBLIC-KEY");
            importedKeys.Kid.Should().Be("093e36a8-88a1-4c34-8202-e454553ee2dc");
            importedKeys.State.Should().Be(EncryptionKeyState.Destroyed);
            importedKeys.Type.Should().Be(EncryptionKeyType.CustomerProvidedRootKey);
            importedKeys.ParentKid.Should().Be("a20128c5-9bf5-4209-8c43-b6dfcee60e9b");
        }
    }
}
