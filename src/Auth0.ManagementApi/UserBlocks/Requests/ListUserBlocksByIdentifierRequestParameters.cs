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
    /// If true, returns only blocks that are currently enforced (e.g. subject to protection status, IP allowlist, etc.).
    ///           If false or omitted, returns all blocks regardless of enforcement state.
    /// </summary>
    [JsonIgnore]
    public Optional<bool?> ConsiderBruteForceEnablement { get; set; }

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
