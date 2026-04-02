using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Keys;

[Serializable]
public record ImportEncryptionKeyRequestContent
{
    /// <summary>
    /// Base64 encoded ciphertext of key material wrapped by public wrapping key.
    /// </summary>
    [JsonPropertyName("wrapped_key")]
    public required string WrappedKey { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
