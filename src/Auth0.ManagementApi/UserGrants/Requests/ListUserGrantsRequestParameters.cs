using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record ListUserGrantsRequestParameters
{
    /// <summary>
    /// Number of results per page.
    /// </summary>
    [JsonIgnore]
    public Optional<int?> PerPage { get; set; } = 50;

    /// <summary>
    /// Page index of the results to return. First page is 0.
    /// </summary>
    [JsonIgnore]
    public Optional<int?> Page { get; set; } = 0;

    /// <summary>
    /// Return results inside an object that contains the total result count (true) or as a direct array of results (false, default).
    /// </summary>
    [JsonIgnore]
    public Optional<bool?> IncludeTotals { get; set; } = true;

    /// <summary>
    /// user_id of the grants to retrieve.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> UserId { get; set; }

    /// <summary>
    /// client_id of the grants to retrieve.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> ClientId { get; set; }

    /// <summary>
    /// audience of the grants to retrieve.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> Audience { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
