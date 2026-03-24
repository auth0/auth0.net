using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record UpdateFlowRequestContent
{
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("actions")]
    public Optional<IEnumerable<FlowAction>?> Actions { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
