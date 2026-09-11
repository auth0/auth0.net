using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Anonymous session settings for tenant.
/// </summary>
[Serializable]
public record TenantSettingsSessionsAnonymous : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Anonymous session lifetime, in minutes. Defaults to 43200 (30 days); maximum 525600 (1 year).
    /// </summary>
    [Optional]
    [JsonPropertyName("lifetime_in_minutes")]
    public int? LifetimeInMinutes { get; set; }

    /// <summary>
    /// Whether anonymous session requests return the `auth0_anon` cookie. Defaults to enabled; set to false to stop issuing the cookie.
    /// </summary>
    [Optional]
    [JsonPropertyName("activate_cookie")]
    public bool? ActivateCookie { get; set; }

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
