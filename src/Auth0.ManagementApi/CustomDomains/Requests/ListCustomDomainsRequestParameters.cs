using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[Serializable]
public record ListCustomDomainsRequestParameters
{
    /// <summary>
    /// Number of results per page. Defaults to 50.
    /// </summary>
    [JsonIgnore]
    public Optional<int?> Take { get; set; } = 50;

    /// <summary>
    /// Optional Id from which to start selection.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> From { get; set; }

    /// <summary>
    /// Query in <a href ="http://www.lucenetutorial.com/lucene-query-syntax.html">Lucene query string syntax</a>.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> Q { get; set; }

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
    /// Field to sort by. Only <code>domain:1</code> (ascending order by domain) is supported at this time.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> Sort { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
