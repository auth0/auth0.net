using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record SearchResourceServersRequestParameters
{
    /// <summary>
    /// Filter expression in SCIM or Lucene syntax (depending on parser parameter). SCIM examples: `name eq "My API"`, `identifier sw "https://"`. SCIM operators: eq, ne, sw, ew, co, pr, gt, ge, lt, le, and, or. <br/><br/><b>Supported Fields</b>:<list type="bullet"><item><description><i>id</i> - Filter by resource server ID</description></item><item><description><i>identifier</i> - Filter by resource server identifier</description></item><item><description><i>name</i> - Filter by resource server name</description></item><item><description><i>updated_at</i> - Filter by last update date</description></item></list>Maximum 5 filter operations per query. Results are eventually consistent and may not reflect recent updates.
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
    /// Field name to sort results by in ascending order only. Defaults to insertion order (oldest first) if not provided.
    /// </summary>
    [JsonIgnore]
    public Optional<ResourceServerSortFieldEnum?> Sort { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
