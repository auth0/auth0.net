using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Users;

[Serializable]
public record ClearAssessorsRequestContent
{
    /// <summary>
    /// The name of the connection containing the user whose assessors should be cleared.
    /// </summary>
    [JsonPropertyName("connection")]
    public required string Connection { get; set; }

    /// <summary>
    /// List of assessors to clear.
    /// </summary>
    [JsonPropertyName("assessors")]
    public IEnumerable<string> Assessors { get; set; } = new List<string>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
