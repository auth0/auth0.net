using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Jobs;

[Serializable]
public record CreateExportUsersRequestContent
{
    /// <summary>
    /// connection_id of the connection from which users will be exported.
    /// </summary>
    [Optional]
    [JsonPropertyName("connection_id")]
    public string? ConnectionId { get; set; }

    [Optional]
    [JsonPropertyName("format")]
    public JobFileFormatEnum? Format { get; set; }

    /// <summary>
    /// Limit the number of records.
    /// </summary>
    [Optional]
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    /// <summary>
    /// List of fields to be included in the CSV. Defaults to a predefined set of fields.
    /// </summary>
    [Optional]
    [JsonPropertyName("fields")]
    public IEnumerable<CreateExportUsersFields>? Fields { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
