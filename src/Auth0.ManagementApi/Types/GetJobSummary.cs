using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Job execution summary.
/// </summary>
[Serializable]
public record GetJobSummary : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// Number of failed operations.
    /// </summary>
    [Optional]
    [JsonPropertyName("failed")]
    public int? Failed { get; set; }

    /// <summary>
    /// Number of updated records.
    /// </summary>
    [Optional]
    [JsonPropertyName("updated")]
    public int? Updated { get; set; }

    /// <summary>
    /// Number of inserted records.
    /// </summary>
    [Optional]
    [JsonPropertyName("inserted")]
    public int? Inserted { get; set; }

    /// <summary>
    /// Total number of operations.
    /// </summary>
    [Optional]
    [JsonPropertyName("total")]
    public int? Total { get; set; }

    [JsonIgnore]
    public AdditionalProperties AdditionalProperties { get; set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    void IJsonOnSerializing.OnSerializing() =>
        AdditionalProperties.CopyToExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
