using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Options for the 'github' connection
/// </summary>
[Serializable]
public record ConnectionOptionsGitHub : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    [Optional]
    [JsonPropertyName("client_id")]
    public string? ClientId { get; set; }

    [Optional]
    [JsonPropertyName("client_secret")]
    public string? ClientSecret { get; set; }

    [Optional]
    [JsonPropertyName("freeform_scopes")]
    public IEnumerable<string>? FreeformScopes { get; set; }

    [Optional]
    [JsonPropertyName("scope")]
    public IEnumerable<string>? Scope { get; set; }

    [Optional]
    [JsonPropertyName("set_user_root_attributes")]
    public ConnectionSetUserRootAttributesEnum? SetUserRootAttributes { get; set; }

    [Nullable, Optional]
    [JsonPropertyName("upstream_params")]
    public Optional<Dictionary<
        string,
        ConnectionUpstreamAdditionalProperties?
    >?> UpstreamParams { get; set; }

    /// <summary>
    /// Requests the GitHub admin:org scope so Auth0 can fully manage organizations, teams, and memberships on behalf of the user.
    /// </summary>
    [Optional]
    [JsonPropertyName("admin_org")]
    public bool? AdminOrg { get; set; }

    /// <summary>
    /// Requests the admin:public_key scope to allow creating, updating, and deleting the user's SSH public keys.
    /// </summary>
    [Optional]
    [JsonPropertyName("admin_public_key")]
    public bool? AdminPublicKey { get; set; }

    /// <summary>
    /// Requests the admin:repo_hook scope so Auth0 can read, write, ping, and delete repository webhooks.
    /// </summary>
    [Optional]
    [JsonPropertyName("admin_repo_hook")]
    public bool? AdminRepoHook { get; set; }

    /// <summary>
    /// Requests the delete_repo scope so the user can remove repositories they administer while signing in through Auth0.
    /// </summary>
    [Optional]
    [JsonPropertyName("delete_repo")]
    public bool? DeleteRepo { get; set; }

    /// <summary>
    /// Requests the user:email scope so Auth0 pulls addresses from GitHub's /user/emails endpoint and populates the profile.
    /// </summary>
    [Optional]
    [JsonPropertyName("email")]
    public bool? Email { get; set; }

    /// <summary>
    /// Requests the user:follow scope to allow following or unfollowing GitHub users for the signed-in account.
    /// </summary>
    [Optional]
    [JsonPropertyName("follow")]
    public bool? Follow { get; set; }

    /// <summary>
    /// Requests the gist scope so the application can create or update gists on behalf of the user.
    /// </summary>
    [Optional]
    [JsonPropertyName("gist")]
    public bool? Gist { get; set; }

    /// <summary>
    /// Requests the notifications scope to read GitHub inbox notifications; repo also implicitly grants this access.
    /// </summary>
    [Optional]
    [JsonPropertyName("notifications")]
    public bool? Notifications { get; set; }

    /// <summary>
    /// Controls the GitHub read:user call that returns the user's basic profile (name, avatar, profile URL) and is on by default for successful logins.
    /// </summary>
    [Optional]
    [JsonPropertyName("profile")]
    public bool? Profile { get; set; }

    /// <summary>
    /// Requests the public_repo scope for read and write operations on public repositories, deployments, and statuses.
    /// </summary>
    [Optional]
    [JsonPropertyName("public_repo")]
    public bool? PublicRepo { get; set; }

    /// <summary>
    /// Requests the read:org scope so Auth0 can view organizations, teams, and membership lists without making changes.
    /// </summary>
    [Optional]
    [JsonPropertyName("read_org")]
    public bool? ReadOrg { get; set; }

    /// <summary>
    /// Requests the read:public_key scope so Auth0 can list and inspect the user's SSH public keys.
    /// </summary>
    [Optional]
    [JsonPropertyName("read_public_key")]
    public bool? ReadPublicKey { get; set; }

    /// <summary>
    /// Requests the read:repo_hook scope to read and ping repository webhooks.
    /// </summary>
    [Optional]
    [JsonPropertyName("read_repo_hook")]
    public bool? ReadRepoHook { get; set; }

    /// <summary>
    /// Requests the read:user scope to load extended profile information, implicitly covering user:email and user:follow.
    /// </summary>
    [Optional]
    [JsonPropertyName("read_user")]
    public bool? ReadUser { get; set; }

    /// <summary>
    /// Requests the repo scope for read and write access to both public and private repositories, deployments, and statuses.
    /// </summary>
    [Optional]
    [JsonPropertyName("repo")]
    public bool? Repo { get; set; }

    /// <summary>
    /// Requests the repo_deployment scope in order to read and write deployment statuses for repositories.
    /// </summary>
    [Optional]
    [JsonPropertyName("repo_deployment")]
    public bool? RepoDeployment { get; set; }

    /// <summary>
    /// Requests the repo:status scope to manage commit statuses on public and private repositories.
    /// </summary>
    [Optional]
    [JsonPropertyName("repo_status")]
    public bool? RepoStatus { get; set; }

    /// <summary>
    /// Requests the write:org scope so Auth0 can change whether organization memberships are publicized.
    /// </summary>
    [Optional]
    [JsonPropertyName("write_org")]
    public bool? WriteOrg { get; set; }

    /// <summary>
    /// Requests the write:public_key scope to create or update SSH public keys for the user.
    /// </summary>
    [Optional]
    [JsonPropertyName("write_public_key")]
    public bool? WritePublicKey { get; set; }

    /// <summary>
    /// Requests the write:repo_hook scope so Auth0 can read, create, update, and ping repository webhooks.
    /// </summary>
    [Optional]
    [JsonPropertyName("write_repo_hook")]
    public bool? WriteRepoHook { get; set; }

    [Optional]
    [JsonPropertyName("non_persistent_attrs")]
    public IEnumerable<string>? NonPersistentAttrs { get; set; }

    [JsonIgnore]
    public AdditionalProperties AdditionalProperties { get; set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    void IJsonOnSerializing.OnSerializing() =>
        AdditionalProperties.CopyToExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
