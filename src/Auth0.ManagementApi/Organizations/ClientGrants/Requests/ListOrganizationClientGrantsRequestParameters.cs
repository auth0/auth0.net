using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Organizations;

[Serializable]
public record ListOrganizationClientGrantsRequestParameters
{
    /// <summary>
    /// Optional filter on audience of the client grant.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> Audience { get; set; }

    /// <summary>
    /// Optional filter on client_id of the client grant.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> ClientId { get; set; }

    /// <summary>
    /// Optional filter on the ID of the client grant. Must be URL encoded and may be specified multiple times (max 10).<br/><b>e.g.</b> <i>../client-grants?grant_ids=id1&grant_ids=id2</i>
    /// </summary>
    [JsonIgnore]
    public IEnumerable<string?> GrantIds { get; set; } = new List<string?>();

    /// <summary>
    /// Page index of the results to return. First page is 0.
    /// </summary>
    [JsonIgnore]
    public Optional<int?> Page { get; set; } = 0;

    /// <summary>
    /// Number of results per page. Defaults to 50.
    /// </summary>
    [JsonIgnore]
    public Optional<int?> PerPage { get; set; } = 50;

    /// <summary>
    /// Return results inside an object that contains the total result count (true) or as a direct array of results (false, default).
    /// </summary>
    [JsonIgnore]
    public Optional<bool?> IncludeTotals { get; set; } = true;

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
