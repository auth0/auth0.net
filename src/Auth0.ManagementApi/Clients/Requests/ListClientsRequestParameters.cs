using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record ListClientsRequestParameters
{
    /// <summary>
    /// Comma-separated list of fields to include or exclude (based on value provided for include_fields) in the result. Leave empty to retrieve all fields.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> Fields { get; set; }

    /// <summary>
    /// Whether specified fields are to be included (true) or excluded (false).
    /// </summary>
    [JsonIgnore]
    public Optional<bool?> IncludeFields { get; set; }

    /// <summary>
    /// Page index of the results to return. First page is 0.
    /// </summary>
    [JsonIgnore]
    public Optional<int?> Page { get; set; } = 0;

    /// <summary>
    /// Number of results per page. Default value is 50, maximum value is 100
    /// </summary>
    [JsonIgnore]
    public Optional<int?> PerPage { get; set; } = 50;

    /// <summary>
    /// Return results inside an object that contains the total result count (true) or as a direct array of results (false, default).
    /// </summary>
    [JsonIgnore]
    public Optional<bool?> IncludeTotals { get; set; } = true;

    /// <summary>
    /// Optional filter on the global client parameter.
    /// </summary>
    [JsonIgnore]
    public Optional<bool?> IsGlobal { get; set; }

    /// <summary>
    /// Optional filter on whether or not a client is a first-party client.
    /// </summary>
    [JsonIgnore]
    public Optional<bool?> IsFirstParty { get; set; }

    /// <summary>
    /// Optional filter by a comma-separated list of application types.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> AppType { get; set; }

    /// <summary>
    /// Advanced Query in <see href="https://lucene.apache.org/core/2_9_4/queryparsersyntax.html">Lucene</see> syntax.<br/><b>Permitted Queries</b>:<br/><list type="bullet"><item><description><i>client_grant.organization_id:{organization_id}</i></description></item><item><description><i>client_grant.allow_any_organization:true</i></description></item></list><b>Additional Restrictions</b>:<br/><list type="bullet"><item><description>Cannot be used in combination with other filters</description></item><item><description>Requires use of the <i>from</i> and <i>take</i> paging parameters (checkpoint paginatinon)</description></item><item><description>Reduced rate limits apply. See <see href="https://auth0.com/docs/troubleshoot/customer-support/operational-policies/rate-limit-policy/rate-limit-configurations/enterprise-public">Rate Limit Configurations</see></description></item></list><i><b>Note</b>: Recent updates may not be immediately reflected in query results</i>
    /// </summary>
    [JsonIgnore]
    public Optional<string?> Q { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
