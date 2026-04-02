using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The structure of the template, which can be used as the payload for creating or updating a User Attribute Profile.
/// </summary>
[Serializable]
public record UserAttributeProfileTemplate : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [Optional]
    [JsonPropertyName("user_id")]
    public UserAttributeProfileUserId? UserId { get; set; }

    [Optional]
    [JsonPropertyName("user_attributes")]
    public Dictionary<
        string,
        UserAttributeProfileUserAttributeAdditionalProperties
    >? UserAttributes { get; set; }

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
