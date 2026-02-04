using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record OrganizationMember : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// ID of this user.
    /// </summary>
    [Optional]
    [JsonPropertyName("user_id")]
    public string? UserId { get; set; }

    /// <summary>
    /// URL to a picture for this user.
    /// </summary>
    [Optional]
    [JsonPropertyName("picture")]
    public string? Picture { get; set; }

    /// <summary>
    /// Name of this user.
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Email address of this user.
    /// </summary>
    [Optional]
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    [Optional]
    [JsonPropertyName("roles")]
    public IEnumerable<OrganizationMemberRole>? Roles { get; set; }

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
