using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Specifies which features are enabled for an "edit connection" ticket. Only applicable when connection ID is provided.
/// </summary>
[Serializable]
public record SelfServiceProfileSsoTicketEnabledFeatures : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Whether SSO configuration is enabled in this ticket.
    /// </summary>
    [Optional]
    [JsonPropertyName("sso")]
    public bool? Sso { get; set; }

    /// <summary>
    /// Whether domain verification is enabled in this ticket.
    /// </summary>
    [Optional]
    [JsonPropertyName("domain_verification")]
    public bool? DomainVerification { get; set; }

    /// <summary>
    /// Whether provisioning configuration is enabled in this ticket.
    /// </summary>
    [Optional]
    [JsonPropertyName("provisioning")]
    public bool? Provisioning { get; set; }

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
