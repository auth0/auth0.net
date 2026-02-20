using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record ListGroupsRequestParameters
{
    /// <summary>
    /// Filter groups by connection ID.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> ConnectionId { get; set; }

    /// <summary>
    /// Filter groups by name.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> Name { get; set; }

    /// <summary>
    /// Filter groups by external ID.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> ExternalId { get; set; }

    /// <summary>
    /// A comma separated list of fields to include or exclude (depending on include_fields) from the result, empty to retrieve all fields
    /// </summary>
    [JsonIgnore]
    public Optional<string?> Fields { get; set; }

    /// <summary>
    /// Whether specified fields are to be included (true) or excluded (false).
    /// </summary>
    [JsonIgnore]
    public Optional<bool?> IncludeFields { get; set; }

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

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
