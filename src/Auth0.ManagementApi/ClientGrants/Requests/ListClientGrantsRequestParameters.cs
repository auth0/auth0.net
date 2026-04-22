using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record ListClientGrantsRequestParameters
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
    /// Optional filter on audience.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> Audience { get; set; }

    /// <summary>
    /// Optional filter on client_id.
    /// </summary>
    [JsonIgnore]
    public Optional<string?> ClientId { get; set; }

    /// <summary>
    /// Optional filter on allow_any_organization.
    /// </summary>
    [JsonIgnore]
    public Optional<bool?> AllowAnyOrganization { get; set; }

    /// <summary>
    /// The type of application access the client grant allows.
    /// </summary>
    [JsonIgnore]
    public Optional<ClientGrantSubjectTypeEnum?> SubjectType { get; set; }

    /// <summary>
    /// Applies this client grant as the default for all clients in the specified group. The only accepted value is `third_party_clients`, which applies the grant to all third-party clients. Per-client grants for the same audience take precedence. Mutually exclusive with `client_id`.
    /// </summary>
    [JsonIgnore]
    public Optional<ClientGrantDefaultForEnum?> DefaultFor { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
