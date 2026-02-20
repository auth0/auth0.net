using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record ListUsersRequestParameters
{
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
    /// Field to sort by. Use <c>field:order</c> where order is <c>1</c> for ascending and <c>-1</c> for descending. e.g. <c>created_at:1</c>
    /// </summary>
    [JsonIgnore]
    public Optional<string?> Sort { get; set; }

    /// <summary>
    /// Connection filter. Only applies when using <c>search_engine=v1</c>. To filter by connection with <c>search_engine=v2|v3</c>, use <c>q=identities.connection:"connection_name"</c>
    /// </summary>
    [JsonIgnore]
    public Optional<string?> Connection { get; set; }

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
    /// Query in <see href="http://www.lucenetutorial.com/lucene-query-syntax.html">Lucene query string syntax</see>. Some query types cannot be used on metadata fields, for details see <see href="https://auth0.com/docs/users/search/v3/query-syntax#searchable-fields">Searchable Fields</see>.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> Q { get; set; }

    /// <summary>
    /// The version of the search engine
    /// </summary>
    [JsonIgnore]
    public Optional<SearchEngineVersionsEnum?> SearchEngine { get; set; }

    /// <summary>
    /// If true (default), results are returned in a deterministic order. If false, results may be returned in a non-deterministic order, which can enhance performance for complex queries targeting a small number of users. Set to false only when consistent ordering and pagination is not required.
    /// </summary>
    [JsonIgnore]
    public Optional<bool?> PrimaryOrder { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
