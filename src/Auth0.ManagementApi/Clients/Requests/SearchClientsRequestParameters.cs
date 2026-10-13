using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record SearchClientsRequestParameters
{
    /// <summary>
    /// Filter expression in SCIM or Lucene syntax (depending on parser parameter). SCIM examples: `name eq "Auth0"`, `name sw "auth" and app_type eq "spa"`. SCIM operators: eq, ne, sw, ew, co, pr, gt, ge, lt, le, and, or. <br/><br/><b>Supported Fields</b>:<br/><list type="bullet"><item><description><i>client_id</i> - Auth0 client ID (case-sensitive, exact match)</description></item><item><description><i>external_client_id</i> - URL of the Client ID Metadata Document (CIMD); case-sensitive, exact match</description></item><item><description><i>name</i> - Client name (supports contains, starts-with, ends-with operators; sortable)</description></item><item><description><i>app_type</i> - Application type (e.g. "spa", "native", "non_interactive")</description></item><item><description><i>is_first_party</i> - Whether the client is first-party (boolean)</description></item><item><description><i>updated_at</i> - Last update timestamp (supports date range operators; sortable)</description></item><item><description><i>metadata.{key}</i> - Filter by client metadata key-value pairs (max 2-level key depth, values indexed up to 64 characters)</description></item><item><description><i>client_grant.organization_id</i> - Filter by associated organization ID</description></item><item><description><i>client_grant.allow_any_organization</i> - Filter by allow any organization setting</description></item></list>Maximum 5 filter operations per query. Results are eventually consistent and may not reflect recent updates.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> Q { get; set; }

    /// <summary>
    /// Query parser to use for the filter expression. Use "scim" for SCIM filter syntax or "lucene" for Lucene query syntax (default).
    /// </summary>
    [JsonIgnore]
    public Optional<SearchParserEnum?> Parser { get; set; }

    /// <summary>
    /// Comma-separated list of fields to include or exclude in the response. Works with the include_fields parameter to control projection mode. Maximum 50 fields.
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
    public Optional<ClientSortFieldEnum?> Sort { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
