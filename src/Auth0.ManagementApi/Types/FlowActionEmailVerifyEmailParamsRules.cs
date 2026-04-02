using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record FlowActionEmailVerifyEmailParamsRules : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("require_mx_record")]
    public bool? RequireMxRecord { get; set; }

    [Optional]
    [JsonPropertyName("block_aliases")]
    public bool? BlockAliases { get; set; }

    [Optional]
    [JsonPropertyName("block_free_emails")]
    public bool? BlockFreeEmails { get; set; }

    [Optional]
    [JsonPropertyName("block_disposable_emails")]
    public bool? BlockDisposableEmails { get; set; }

    [Optional]
    [JsonPropertyName("blocklist")]
    public IEnumerable<string>? Blocklist { get; set; }

    [Optional]
    [JsonPropertyName("allowlist")]
    public IEnumerable<string>? Allowlist { get; set; }

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
