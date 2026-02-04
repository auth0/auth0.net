using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record DomainVerificationMethod : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("name")]
    public required DomainVerificationMethodNameEnum Name { get; set; }

    /// <summary>
    /// Value used to verify the domain.
    /// </summary>
    [JsonPropertyName("record")]
    public required string Record { get; set; }

    /// <summary>
    /// The name of the txt record for verification
    /// </summary>
    [Optional]
    [JsonPropertyName("domain")]
    public string? Domain { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
