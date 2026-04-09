using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record GetRefreshTokensRequestParameters
{
    /// <summary>
    /// ID of the user whose refresh tokens to retrieve. Required.
    /// </summary>
    [JsonIgnore]
    public required string UserId { get; set; }

    /// <summary>
    /// Filter results by client ID. Only valid when user_id is provided.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> ClientId { get; set; }

    /// <summary>
    /// An opaque cursor from which to start the selection (exclusive). Expires after 24 hours. Obtained from the next property of a previous response.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> From { get; set; }

    /// <summary>
    /// Number of results per page. Defaults to 50.
    /// </summary>
    [JsonIgnore]
    public Optional<int?> Take { get; set; } = 50;

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

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
