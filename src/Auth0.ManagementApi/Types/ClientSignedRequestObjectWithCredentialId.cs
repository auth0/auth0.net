using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// JWT-secured Authorization Requests (JAR) settings.
/// </summary>
[Serializable]
public record ClientSignedRequestObjectWithCredentialId : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Indicates whether the JAR requests are mandatory
    /// </summary>
    [Optional]
    [JsonPropertyName("required")]
    public bool? Required { get; set; }

    [Optional]
    [JsonPropertyName("credentials")]
    public IEnumerable<CredentialId>? Credentials { get; set; }

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
