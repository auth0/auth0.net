using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record SearchOrganizationsRequestParameters
{
    /// <summary>
    /// Filter expression in SCIM or Lucene syntax (depending on parser parameter, default: Lucene). Lucene examples: `name:acme*`, `display_name:*auth*`. SCIM examples: `name eq "Auth0"`, `display_name sw "auth" and created_at gt "2024-01-01"`. SCIM operators: eq, ne, sw, ew, co, pr, gt, ge, lt, le, and, or. <br/><br/><b>Supported Fields</b>:<list type="bullet"><item><description><i>id</i> - Organization ID (case-sensitive, exact match)</description></item><item><description><i>name</i> - Organization name (supports contains, starts-with, ends-with operators; sortable)</description></item><item><description><i>display_name</i> - Organization display name (supports contains, starts-with, ends-with operators; sortable)</description></item><item><description><i>created_at</i> - Creation timestamp (supports date range operators; sortable)</description></item><item><description><i>metadata.{key}</i> - Filter by organization metadata key-value pairs</description></item></list>Maximum 5 filter operations per query. Results are eventually consistent and may not reflect recent updates.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> Q { get; set; }

    /// <summary>
    /// Query parser to use for the filter expression. Use "scim" for SCIM filter syntax or "lucene" for Lucene query syntax (default).
    /// </summary>
    [JsonIgnore]
    public Optional<SearchParserEnum?> Parser { get; set; }

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
    /// Field name to sort results by in ascending order only. Defaults to insertion order (oldest first) if not provided.
    /// </summary>
    [JsonIgnore]
    public Optional<OrganizationSortFieldEnum?> Sort { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
