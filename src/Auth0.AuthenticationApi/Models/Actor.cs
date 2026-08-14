using System.Text.Json.Serialization;

namespace Auth0.AuthenticationApi.Models;

/// <summary>
/// Represents the <c>act</c> (actor) claim from an exchanged access token.
/// </summary>
/// <remarks>
/// The outermost <see cref="Actor"/> identifies the <b>current actor</b> — the client that
/// performed the token exchange. Only the current actor may be used for access-control
/// decisions. Prior actors reachable through <see cref="Act"/> are informational only
/// (audit/logging).
/// </remarks>
public class Actor
{
    /// <summary>
    /// Initializes a new <see cref="Actor"/>. Used by the deserializer to populate the
    /// read-only properties; the type is otherwise only produced by decoding an access token.
    /// </summary>
    [JsonConstructor]
    public Actor(string? subject, Actor? act)
    {
        Subject = subject;
        Act = act;
    }

    /// <summary>
    /// The <c>sub</c> of this actor. May be <c>null</c> if the decoded <c>act</c> claim did
    /// not contain a <c>sub</c>.
    /// </summary>
    [JsonPropertyName("sub")]
    public string? Subject { get; }

    /// <summary>
    /// The nested prior actor, or <c>null</c> if this is the end of the delegation chain.
    /// </summary>
    [JsonPropertyName("act")]
    public Actor? Act { get; }
}
