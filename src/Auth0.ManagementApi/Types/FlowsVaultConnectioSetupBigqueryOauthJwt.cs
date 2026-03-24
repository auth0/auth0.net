using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record FlowsVaultConnectioSetupBigqueryOauthJwt : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("type")]
    public FlowsVaultConnectioSetupTypeOauthJwtEnum? Type { get; set; }

    [Optional]
    [JsonPropertyName("project_id")]
    public string? ProjectId { get; set; }

    [Optional]
    [JsonPropertyName("private_key")]
    public string? PrivateKey { get; set; }

    [Optional]
    [JsonPropertyName("client_email")]
    public string? ClientEmail { get; set; }

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
