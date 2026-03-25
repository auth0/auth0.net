using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Prompts;

[Serializable]
public record BulkUpdateAculRequestContent
{
    [JsonPropertyName("configs")]
    public IEnumerable<AculConfigsItem> Configs { get; set; } = new List<AculConfigsItem>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
