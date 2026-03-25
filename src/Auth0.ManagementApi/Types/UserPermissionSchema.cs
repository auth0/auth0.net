using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record UserPermissionSchema : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Resource server (API) identifier that this permission is for.
    /// </summary>
    [Optional]
    [JsonPropertyName("resource_server_identifier")]
    public string? ResourceServerIdentifier { get; set; }

    /// <summary>
    /// Name of this permission.
    /// </summary>
    [Optional]
    [JsonPropertyName("permission_name")]
    public string? PermissionName { get; set; }

    /// <summary>
    /// Resource server (API) name this permission is for.
    /// </summary>
    [Optional]
    [JsonPropertyName("resource_server_name")]
    public string? ResourceServerName { get; set; }

    /// <summary>
    /// Description of this permission.
    /// </summary>
    [Optional]
    [JsonPropertyName("description")]
    public string? Description { get; set; }

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
