using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Users;

[Serializable]
public record GetUserConnectedAccountsRequestParameters
{
    /// <summary>
    /// Optional Id from which to start selection.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> From { get; set; }

    /// <summary>
    /// Number of results to return.  Defaults to 10 with a maximum of 20
    /// </summary>
    [JsonIgnore]
    public Optional<int?> Take { get; set; } = 50;

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
