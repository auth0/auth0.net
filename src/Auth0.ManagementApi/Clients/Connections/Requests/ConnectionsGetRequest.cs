using System.Text.Json.Serialization;
using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Clients;

[Serializable]
public record ConnectionsGetRequest
{
    /// <summary>
    /// Provide strategies to only retrieve connections with such strategies
    /// </summary>
    [JsonIgnore]
    public IEnumerable<ConnectionStrategyEnum?> Strategy { get; set; } =
        new List<ConnectionStrategyEnum?>();

    /// <summary>
    /// Optional Id from which to start selection.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> From { get; set; }

    /// <summary>
    /// Number of results per page. Defaults to 50.
    /// </summary>
    [JsonIgnore]
    public Optional<int?> Take { get; set; } = 50;

    /// <summary>
    /// A comma separated list of fields to include or exclude (depending on include_fields) from the result, empty to retrieve all fields
    /// </summary>
    [JsonIgnore]
    public Optional<string?> Fields { get; set; }

    /// <summary>
    /// <c>true</c> if the fields specified are to be included in the result, <c>false</c> otherwise (defaults to <c>true</c>)
    /// </summary>
    [JsonIgnore]
    public Optional<bool?> IncludeFields { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
