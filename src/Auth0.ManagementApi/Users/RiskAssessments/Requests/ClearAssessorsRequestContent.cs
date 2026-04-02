using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

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
    public IEnumerable<AssessorsTypeEnum> Assessors { get; set; } = new List<AssessorsTypeEnum>();

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
