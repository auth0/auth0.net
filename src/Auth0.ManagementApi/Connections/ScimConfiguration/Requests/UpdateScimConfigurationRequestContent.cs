using System.Text.Json.Serialization;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Connections;

[Serializable]
public record UpdateScimConfigurationRequestContent
{
    /// <summary>
    /// User ID attribute for generating unique user ids
    /// </summary>
    [JsonPropertyName("user_id_attribute")]
    public required string UserIdAttribute { get; set; }

    /// <summary>
    /// The mapping between auth0 and SCIM
    /// </summary>
    [JsonPropertyName("mapping")]
    public IEnumerable<ScimMappingItem> Mapping { get; set; } = new List<ScimMappingItem>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
