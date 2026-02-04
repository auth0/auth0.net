using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record NetworkAclRule : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("action")]
    public required NetworkAclAction Action { get; set; }

    [Optional]
    [JsonPropertyName("match")]
    public NetworkAclMatch? Match { get; set; }

    [Optional]
    [JsonPropertyName("not_match")]
    public NetworkAclMatch? NotMatch { get; set; }

    [JsonPropertyName("scope")]
    public required NetworkAclRuleScopeEnum Scope { get; set; }

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
