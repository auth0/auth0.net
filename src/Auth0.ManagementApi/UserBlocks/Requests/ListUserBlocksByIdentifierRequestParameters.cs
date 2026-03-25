using Auth0.ManagementApi.Core;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[Serializable]
public record ListUserBlocksByIdentifierRequestParameters
{
    /// <summary>
    /// Should be any of a username, phone number, or email.
    /// </summary>
    [JsonIgnore]
    public required string Identifier { get; set; }

    /// <summary>
    /// If true and Brute Force Protection is enabled and configured to block logins, will return a list of blocked IP addresses.
    ///           If true and Brute Force Protection is disabled, will return an empty list.
    /// </summary>
    [JsonIgnore]
    public Optional<bool?> ConsiderBruteForceEnablement { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
