using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Defines application access permission for a resource server. Use of this field is subject to the applicable Free Trial terms in Okta’s <a href="https://www.okta.com/legal/"> Master Subscription Agreement.</a>
/// </summary>
[Serializable]
public record ResourceServerSubjectTypeAuthorization : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("user")]
    public ResourceServerSubjectTypeAuthorizationUser? User { get; set; }

    [Optional]
    [JsonPropertyName("client")]
    public ResourceServerSubjectTypeAuthorizationClient? Client { get; set; }

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
