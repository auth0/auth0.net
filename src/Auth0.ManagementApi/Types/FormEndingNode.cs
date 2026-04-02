using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record FormEndingNode : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("redirection")]
    public FormEndingNodeRedirection? Redirection { get; set; }

    [Optional]
    [JsonPropertyName("after_submit")]
    public FormEndingNodeAfterSubmit? AfterSubmit { get; set; }

    [Optional]
    [JsonPropertyName("coordinates")]
    public FormNodeCoordinates? Coordinates { get; set; }

    [Optional]
    [JsonPropertyName("resume_flow")]
    public bool? ResumeFlow { get; set; }

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
