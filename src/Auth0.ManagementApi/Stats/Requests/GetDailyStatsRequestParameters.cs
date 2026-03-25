using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record GetDailyStatsRequestParameters
{
    /// <summary>
    /// Optional first day of the date range (inclusive) in YYYYMMDD format.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> From { get; set; }

    /// <summary>
    /// Optional last day of the date range (inclusive) in YYYYMMDD format.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> To { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
