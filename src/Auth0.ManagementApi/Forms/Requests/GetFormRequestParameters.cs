using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record GetFormRequestParameters
{
    /// <summary>
    /// Query parameter to hydrate the response with additional data
    /// </summary>
    [JsonIgnore]
    public IEnumerable<FormsRequestParametersHydrateEnum?> Hydrate { get; set; } =
        new List<FormsRequestParametersHydrateEnum?>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
