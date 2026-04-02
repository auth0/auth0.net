using System.Linq;
using System.Threading.Tasks;
using Auth0.ManagementApi.Keys;
using FluentAssertions;
using Xunit;

namespace Auth0.ManagementApi.IntegrationTests;

public class KeysTestsFixture : TestBaseFixture
{
}

public class KeysTests : IClassFixture<KeysTestsFixture>
{
    private KeysTestsFixture fixture;

    public KeysTests(KeysTestsFixture fixture)
    {
        this.fixture = fixture;
    }

    [Fact]
    public async Task Test_signing_keys_list()
    {
        var keys = await fixture.ApiClient.Keys.Signing.ListAsync();

        keys.Should().NotBeEmpty();
        foreach (var key in keys)
        {
            key.Kid.Should().NotBeNullOrEmpty();
        }
    }

    [Fact]
    public async Task Test_signing_keys_get_current()
    {
        var keys = await fixture.ApiClient.Keys.Signing.ListAsync();
        var currentKey = keys.FirstOrDefault(k => k.Current == true);

        currentKey.Should().NotBeNull();

        var key = await fixture.ApiClient.Keys.Signing.GetAsync(currentKey!.Kid);
        key.Should().NotBeNull();
        key.Kid.Should().Be(currentKey.Kid);
    }

    [Fact(Skip = "This test rotates keys and can cause issues in shared environments")]
    public async Task Test_signing_keys_rotate()
    {
        var rotatedKey = await fixture.ApiClient.Keys.Signing.RotateAsync();
        rotatedKey.Should().NotBeNull();
    }

    [Fact(Skip = "This test revokes keys and can cause issues in shared environments")]
    public async Task Test_signing_keys_revoke()
    {
        // First rotate to create a new key
        var rotatedKey = await fixture.ApiClient.Keys.Signing.RotateAsync();

        // Get all keys
        var keys = await fixture.ApiClient.Keys.Signing.ListAsync();
        var previousKey = keys.FirstOrDefault(k => k.Kid != rotatedKey.Kid && k.Revoked != true);

        if (previousKey != null)
        {
            var revokedKey = await fixture.ApiClient.Keys.Signing.RevokeAsync(previousKey.Kid);
            revokedKey.Should().NotBeNull();
        }
    }

    [Fact]
    public async Task Test_encryption_keys_list()
    {
        var keysPager = await fixture.ApiClient.Keys.Encryption.ListAsync(new ListEncryptionKeysRequestParameters());
        var keys = keysPager.CurrentPage.Items.ToList();

        keys.Should().NotBeNull();
        // There should be at least one encryption key (tenant-master-key)
        keys.Should().NotBeEmpty();
    }

    [Fact]
    public async Task Test_encryption_keys_get()
    {
        var keysPager = await fixture.ApiClient.Keys.Encryption.ListAsync(new ListEncryptionKeysRequestParameters());
        var keys = keysPager.CurrentPage.Items.ToList();

        if (keys.Any())
        {
            var firstKey = keys.First();
            var key = await fixture.ApiClient.Keys.Encryption.GetAsync(firstKey.Kid);

            key.Should().NotBeNull();
            key.Kid.Should().Be(firstKey.Kid);
        }
    }

    [Fact(Skip = "This test creates encryption keys - may require elevated permissions")]
    public async Task Test_encryption_keys_create_and_delete()
    {
        // Create a new encryption key
        var newKey = await fixture.ApiClient.Keys.Encryption.CreateAsync(new CreateEncryptionKeyRequestContent
        {
            Type = CreateEncryptionKeyType.CustomerProvidedRootKey
        });

        newKey.Should().NotBeNull();
        newKey.Kid.Should().NotBeNullOrEmpty();

        try
        {
            // Get the key to verify it was created
            var fetchedKey = await fixture.ApiClient.Keys.Encryption.GetAsync(newKey.Kid);
            fetchedKey.Should().NotBeNull();
        }
        finally
        {
            // Delete the key
            await fixture.ApiClient.Keys.Encryption.DeleteAsync(newKey.Kid);
        }
    }

    [Fact(Skip = "This test creates wrapping keys - may require elevated permissions")]
    public async Task Test_encryption_keys_create_public_wrapping_key()
    {
        var keysPager = await fixture.ApiClient.Keys.Encryption.ListAsync(new ListEncryptionKeysRequestParameters());
        var customerKey = keysPager.CurrentPage.Items.FirstOrDefault(k => k.Type == "customer-provided-root-key");

        if (customerKey != null)
        {
            var wrappingKey = await fixture.ApiClient.Keys.Encryption.CreatePublicWrappingKeyAsync(customerKey.Kid);
            wrappingKey.Should().NotBeNull();
            wrappingKey.PublicKey.Should().NotBeNullOrEmpty();
        }
    }

    [Fact(Skip = "This test rekeys - can cause issues in shared environments")]
    public async Task Test_encryption_keys_rekey()
    {
        await fixture.ApiClient.Keys.Encryption.RekeyAsync();
    }
}
