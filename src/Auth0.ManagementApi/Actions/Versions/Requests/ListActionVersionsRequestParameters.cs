using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Actions;

[Serializable]
public record ListActionVersionsRequestParameters
{
    /// <summary>
    /// Use this field to request a specific page of the list results.
    /// </summary>
    [JsonIgnore]
    public Optional<int?> Page { get; set; } = 0;

    /// <summary>
    /// This field specify the maximum number of results to be returned by the server. 20 by default
    /// </summary>
    [JsonIgnore]
    public Optional<int?> PerPage { get; set; } = 50;

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
