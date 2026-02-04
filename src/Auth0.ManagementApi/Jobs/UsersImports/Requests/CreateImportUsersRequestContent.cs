using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi.Jobs;

[Serializable]
public record CreateImportUsersRequestContent
{
    public required FileParameter Users { get; set; }

    /// <summary>
    /// connection_id of the connection to which users will be imported.
    /// </summary>
    public required string ConnectionId { get; set; }

    /// <summary>
    /// Whether to update users if they already exist (true) or to ignore them (false).
    /// </summary>
    public bool? Upsert { get; set; }

    /// <summary>
    /// Customer-defined ID.
    /// </summary>
    public string? ExternalId { get; set; }

    /// <summary>
    /// Whether to send a completion email to all tenant owners when the job is finished (true) or not (false).
    /// </summary>
    public bool? SendCompletionEmail { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
