using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record GetFlowRequestParameters
{
    /// <summary>
    /// hydration param
    /// </summary>
    [JsonIgnore]
    public IEnumerable<GetFlowRequestParametersHydrateEnum?> Hydrate { get; set; } =
        new List<GetFlowRequestParametersHydrateEnum?>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
