using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Configuration for delegation (impersonation) access using Session Transfer Tokens
/// </summary>
[Serializable]
public record ClientSessionTransferDelegationConfiguration : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Indicates whether delegation (impersonation) access is allowed using Session Transfer Tokens. Default value is `false`.
    /// </summary>
    [Optional]
    [JsonPropertyName("allow_delegated_access")]
    public bool? AllowDelegatedAccess { get; set; }

    [Optional]
    [JsonPropertyName("enforce_device_binding")]
    public ClientSessionTransferDelegationDeviceBindingEnum? EnforceDeviceBinding { get; set; }

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
