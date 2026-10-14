using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record SearchClientGrantsRequestParameters
{
    /// <summary>
    /// Filter expression in SCIM or Lucene syntax (depending on parser parameter). SCIM examples: `audience eq "https://api.example.com"`, `client_id eq "cli_abc"`, `subject_type eq "client"`, `allow_any_organization eq true`, `default_for eq "third_party_clients"`, `audience co "example" and organization_id eq "org_123"`. SCIM operators: eq, ne, sw, ew, co, pr, gt, ge, lt, le, and, or. <br/><br/><b>Supported Fields</b>:<list type="bullet"><item><description><i>audience</i> - Filter by audience (eq, ne, sw, co, ew, pr)</description></item><item><description><i>client_id</i> - Filter by client ID (eq, ne, sw, pr)</description></item><item><description><i>subject_type</i> - Filter by subject type (eq, ne, sw, pr)</description></item><item><description><i>allow_any_organization</i> - Filter by allow_any_organization (eq, ne, pr)</description></item><item><description><i>organization_id</i> - Filter by organization ID (eq, ne, sw, pr)</description></item><item><description><i>updated_at</i> - Filter by last update date (eq, ne, gt, ge, lt, le, pr)</description></item><item><description><i>default_for</i> - Filter by default grant group (eq, ne, sw, pr)</description></item></list>Maximum 5 filter operations per query. Results are eventually consistent and may not reflect recent updates.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> Q { get; set; }

    /// <summary>
    /// Query parser to use for the filter expression. Use "scim" for SCIM filter syntax or "lucene" for Lucene query syntax (default).
    /// </summary>
    [JsonIgnore]
    public Optional<SearchParserEnum?> Parser { get; set; }

    /// <summary>
    /// Comma-separated list of fields to include or exclude in the response. Works with the include_fields parameter to control projection mode.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> Fields { get; set; }

    /// <summary>
    /// Controls field projection mode. Set to true to include only fields specified in the fields parameter. Set to false to exclude fields specified in the fields parameter. Defaults to true if not specified.
    /// </summary>
    [JsonIgnore]
    public Optional<bool?> IncludeFields { get; set; }

    /// <summary>
    /// Maximum number of results to return per page (1-100). Defaults to 50.
    /// </summary>
    [JsonIgnore]
    public Optional<int?> Take { get; set; } = 50;

    /// <summary>
    /// Cursor for the next page of results. Use the value from the next field in the previous response.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> From { get; set; }

    /// <summary>
    /// Field name to sort results by in ascending order. Defaults to insertion order (oldest first) if not provided.
    /// </summary>
    [JsonIgnore]
    public Optional<ClientGrantSortFieldEnum?> Sort { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
