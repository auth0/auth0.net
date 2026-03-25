using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Flows;

[Serializable]
public record GetFlowExecutionRequestParameters
{
    /// <summary>
    /// Hydration param
    /// </summary>
    [JsonIgnore]
    public IEnumerable<GetFlowExecutionRequestParametersHydrateEnum?> Hydrate { get; set; } =
        new List<GetFlowExecutionRequestParametersHydrateEnum?>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
