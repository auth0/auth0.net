using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Actions.Modules;

[Serializable]
public record GetActionModuleVersionsRequestParameters
{
    /// <summary>
    /// Use this field to request a specific page of the list results.
    /// </summary>
    [JsonIgnore]
    public Optional<int?> Page { get; set; } = 0;

    /// <summary>
    /// The maximum number of results to be returned by the server in a single response. 20 by default.
    /// </summary>
    [JsonIgnore]
    public Optional<int?> PerPage { get; set; } = 50;

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
