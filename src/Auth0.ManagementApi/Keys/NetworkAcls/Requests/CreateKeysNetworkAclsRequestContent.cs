using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Keys;

[Serializable]
public record CreateKeysNetworkAclsRequestContent
{
    /// <summary>
    /// Customer-supplied label with no cryptographic meaning. Must be unique across all Network ACL keys for the tenant.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("alg")]
    public required NetworkAclKeyAlgorithmEnum Alg { get; set; }

    /// <summary>
    /// Base64-encoded raw key material. Constraints on the decoded value depend on the algorithm specified. Currently only HMAC-SHA256 is supported.
    /// </summary>
    [JsonPropertyName("value")]
    public required string Value { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
