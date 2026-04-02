using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record GetOrganizationInvitationResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The id of the user invitation.
    /// </summary>
    [Optional]
    [JsonPropertyName("id")]
    public string? Id { get; set; }

    /// <summary>
    /// Organization identifier.
    /// </summary>
    [Optional]
    [JsonPropertyName("organization_id")]
    public string? OrganizationId { get; set; }

    [Optional]
    [JsonPropertyName("inviter")]
    public OrganizationInvitationInviter? Inviter { get; set; }

    [Optional]
    [JsonPropertyName("invitee")]
    public OrganizationInvitationInvitee? Invitee { get; set; }

    /// <summary>
    /// The invitation url to be send to the invitee.
    /// </summary>
    [Optional]
    [JsonPropertyName("invitation_url")]
    public string? InvitationUrl { get; set; }

    /// <summary>
    /// The ISO 8601 formatted timestamp representing the creation time of the invitation.
    /// </summary>
    [Optional]
    [JsonPropertyName("created_at")]
    public DateTime? CreatedAt { get; set; }

    /// <summary>
    /// The ISO 8601 formatted timestamp representing the expiration time of the invitation.
    /// </summary>
    [Optional]
    [JsonPropertyName("expires_at")]
    public DateTime? ExpiresAt { get; set; }

    /// <summary>
    /// Auth0 client ID. Used to resolve the application's login initiation endpoint.
    /// </summary>
    [Optional]
    [JsonPropertyName("client_id")]
    public string? ClientId { get; set; }

    /// <summary>
    /// The id of the connection to force invitee to authenticate with.
    /// </summary>
    [Optional]
    [JsonPropertyName("connection_id")]
    public string? ConnectionId { get; set; }

    [Optional]
    [JsonPropertyName("app_metadata")]
    public Dictionary<string, object?>? AppMetadata { get; set; }

    [Optional]
    [JsonPropertyName("user_metadata")]
    public Dictionary<string, object?>? UserMetadata { get; set; }

    /// <summary>
    /// List of roles IDs to associated with the user.
    /// </summary>
    [Optional]
    [JsonPropertyName("roles")]
    public IEnumerable<string>? Roles { get; set; }

    /// <summary>
    /// The id of the invitation ticket
    /// </summary>
    [Optional]
    [JsonPropertyName("ticket_id")]
    public string? TicketId { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
