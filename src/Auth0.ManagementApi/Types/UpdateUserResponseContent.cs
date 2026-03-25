using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record UpdateUserResponseContent : IJsonOnDeserialized, IJsonOnSerializing
{
    [JsonExtensionData]
    private readonly IDictionary<string, object?> _extensionData =
        new Dictionary<string, object?>();

    /// <summary>
    /// ID of the user which can be used when interacting with other APIs.
    /// </summary>
    [Optional]
    [JsonPropertyName("user_id")]
    public string? UserId { get; set; }

    /// <summary>
    /// Email address of this user.
    /// </summary>
    [Optional]
    [JsonPropertyName("email")]
    public string? Email { get; set; }

    /// <summary>
    /// Whether this email address is verified (true) or unverified (false).
    /// </summary>
    [Optional]
    [JsonPropertyName("email_verified")]
    public bool? EmailVerified { get; set; }

    /// <summary>
    /// Username of this user.
    /// </summary>
    [Optional]
    [JsonPropertyName("username")]
    public string? Username { get; set; }

    /// <summary>
    /// Phone number for this user. Follows the <see href="https://en.wikipedia.org/wiki/E.164">E.164 recommendation</see>.
    /// </summary>
    [Optional]
    [JsonPropertyName("phone_number")]
    public string? PhoneNumber { get; set; }

    /// <summary>
    /// Whether this phone number has been verified (true) or not (false).
    /// </summary>
    [Optional]
    [JsonPropertyName("phone_verified")]
    public bool? PhoneVerified { get; set; }

    [Optional]
    [JsonPropertyName("created_at")]
    public UserDateSchema? CreatedAt { get; set; }

    [Optional]
    [JsonPropertyName("updated_at")]
    public UserDateSchema? UpdatedAt { get; set; }

    /// <summary>
    /// Array of user identity objects when accounts are linked.
    /// </summary>
    [Optional]
    [JsonPropertyName("identities")]
    public IEnumerable<UserIdentitySchema>? Identities { get; set; }

    [Optional]
    [JsonPropertyName("app_metadata")]
    public Dictionary<string, object?>? AppMetadata { get; set; }

    [Optional]
    [JsonPropertyName("user_metadata")]
    public Dictionary<string, object?>? UserMetadata { get; set; }

    /// <summary>
    /// URL to picture, photo, or avatar of this user.
    /// </summary>
    [Optional]
    [JsonPropertyName("picture")]
    public string? Picture { get; set; }

    /// <summary>
    /// Name of this user.
    /// </summary>
    [Optional]
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// Preferred nickname or alias of this user.
    /// </summary>
    [Optional]
    [JsonPropertyName("nickname")]
    public string? Nickname { get; set; }

    /// <summary>
    /// List of multi-factor authentication providers with which this user has enrolled.
    /// </summary>
    [Optional]
    [JsonPropertyName("multifactor")]
    public IEnumerable<string>? Multifactor { get; set; }

    /// <summary>
    /// Last IP address from which this user logged in.
    /// </summary>
    [Optional]
    [JsonPropertyName("last_ip")]
    public string? LastIp { get; set; }

    [Optional]
    [JsonPropertyName("last_login")]
    public UserDateSchema? LastLogin { get; set; }

    /// <summary>
    /// Total number of logins this user has performed.
    /// </summary>
    [Optional]
    [JsonPropertyName("logins_count")]
    public int? LoginsCount { get; set; }

    /// <summary>
    /// Whether this user was blocked by an administrator (true) or is not (false).
    /// </summary>
    [Optional]
    [JsonPropertyName("blocked")]
    public bool? Blocked { get; set; }

    /// <summary>
    /// Given name/first name/forename of this user.
    /// </summary>
    [Optional]
    [JsonPropertyName("given_name")]
    public string? GivenName { get; set; }

    /// <summary>
    /// Family name/last name/surname of this user.
    /// </summary>
    [Optional]
    [JsonPropertyName("family_name")]
    public string? FamilyName { get; set; }

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
