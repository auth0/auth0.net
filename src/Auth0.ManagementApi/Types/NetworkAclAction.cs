using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record NetworkAclAction : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("block")]
    public bool? Block { get; set; }

    [Optional]
    [JsonPropertyName("allow")]
    public bool? Allow { get; set; }

    [Optional]
    [JsonPropertyName("log")]
    public bool? Log { get; set; }

    [Optional]
    [JsonPropertyName("redirect")]
    public bool? Redirect { get; set; }

    /// <summary>
    /// The URI to which the match or not_match requests will be routed
    /// </summary>
    [Optional]
    [JsonPropertyName("redirect_uri")]
    public string? RedirectUri { get; set; }

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
