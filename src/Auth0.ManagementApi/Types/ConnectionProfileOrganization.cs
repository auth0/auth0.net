using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// The organization of the connection profile.
/// </summary>
[Serializable]
public record ConnectionProfileOrganization : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("show_as_button")]
    public ConnectionProfileOrganizationShowAsButtonEnum? ShowAsButton { get; set; }

    [Optional]
    [JsonPropertyName("assign_membership_on_login")]
    public ConnectionProfileOrganizationAssignMembershipOnLoginEnum? AssignMembershipOnLogin { get; set; }

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
