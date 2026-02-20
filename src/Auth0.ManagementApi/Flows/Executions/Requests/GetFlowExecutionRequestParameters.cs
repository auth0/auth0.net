using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Flows;

[Serializable]
public record GetFlowExecutionRequestParameters
{
    /// <summary>
    /// Hydration param
    /// </summary>
    [JsonIgnore]
    public IEnumerable<string?> Hydrate { get; set; } = new List<string?>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
