using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record ListDirectoryProvisioningsResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// List of directory provisioning configurations
    /// </summary>
    [JsonPropertyName("directory_provisionings")]
    public IEnumerable<DirectoryProvisioning> DirectoryProvisionings { get; set; } =
        new List<DirectoryProvisioning>();

    /// <summary>
    /// The cursor to be used as the "from" query parameter for the next page of results.
    /// </summary>
    [Optional]
    [JsonPropertyName("next")]
    public string? Next { get; set; }

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
