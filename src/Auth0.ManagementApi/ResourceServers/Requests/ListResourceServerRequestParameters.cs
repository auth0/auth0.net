using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record ListResourceServerRequestParameters
{
    /// <summary>
    /// An optional filter on the resource server identifier. Must be URL encoded and may be specified multiple times (max 10).<br/><b>e.g.</b> <i>../resource-servers?identifiers=id1&identifiers=id2</i>
    /// </summary>
    [JsonIgnore]
    public IEnumerable<string?> Identifiers { get; set; } = new List<string?>();

    /// <summary>
    /// Page index of the results to return. First page is 0.
    /// </summary>
    [JsonIgnore]
    public Optional<int?> Page { get; set; } = 0;

    /// <summary>
    /// Number of results per page.
    /// </summary>
    [JsonIgnore]
    public Optional<int?> PerPage { get; set; } = 50;

    /// <summary>
    /// Return results inside an object that contains the total result count (true) or as a direct array of results (false, default).
    /// </summary>
    [JsonIgnore]
    public Optional<bool?> IncludeTotals { get; set; } = true;

    /// <summary>
    /// Whether specified fields are to be included (true) or excluded (false).
    /// </summary>
    [JsonIgnore]
    public Optional<bool?> IncludeFields { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
