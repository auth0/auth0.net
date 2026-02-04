using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

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
