using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record OrganizationConnection : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// ID of the connection.
    /// </summary>
    [Optional]
    [JsonPropertyName("connection_id")]
    public string? ConnectionId { get; set; }

    /// <summary>
    /// When true, all users that log in with this connection will be automatically granted membership in the organization. When false, users must be granted membership in the organization before logging in with this connection.
    /// </summary>
    [Optional]
    [JsonPropertyName("assign_membership_on_login")]
    public bool? AssignMembershipOnLogin { get; set; }

    /// <summary>
    /// Determines whether a connection should be displayed on this organization’s login prompt. Only applicable for enterprise connections. Default: true.
    /// </summary>
    [Optional]
    [JsonPropertyName("show_as_button")]
    public bool? ShowAsButton { get; set; }

    /// <summary>
    /// Determines whether organization signup should be enabled for this organization connection. Only applicable for database connections. Default: false.
    /// </summary>
    [Optional]
    [JsonPropertyName("is_signup_enabled")]
    public bool? IsSignupEnabled { get; set; }

    [Optional]
    [JsonPropertyName("connection")]
    public OrganizationConnectionInformation? Connection { get; set; }

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
