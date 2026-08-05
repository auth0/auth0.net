using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Connections;

[Serializable]
public record ListSynchronizedGroupsRequestParameters
{
    /// <summary>
    /// Optional Id from which to start selection.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> From { get; set; }

    /// <summary>
    /// Number of results per page. Defaults to 50.
    /// </summary>
    [JsonIgnore]
    public Optional<int?> Take { get; set; } = 50;

    /// <summary>
    /// Query in <see href="https://lucene.apache.org/core/2_9_4/queryparsersyntax.html">Lucene query string syntax</see>. Only prefix search on "name" or "email" fields are allowed, with a single wildcard suffix. Operators, modifiers, and groupings are not allowed. Terms are treated as case-insensitive. Example query: "name:engineering*".
    /// </summary>
    [JsonIgnore]
    public Optional<string?> Q { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
