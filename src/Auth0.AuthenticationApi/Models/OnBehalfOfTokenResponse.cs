using System.Text.Json.Serialization;
using System.Threading;

using Auth0.AuthenticationApi.Tokens;

namespace Auth0.AuthenticationApi.Models;

/// <summary>
/// Represents the response of an On-Behalf-Of token exchange.
/// </summary>
/// <remarks>
/// On-Behalf-Of exchange issues an access token only - no refresh or ID token.
/// </remarks>
public class OnBehalfOfTokenResponse : TokenBase
{
    /// <summary>
    /// Expiration time in seconds.
    /// </summary>
    [JsonPropertyName("expires_in")]
    public int ExpiresIn { get; set; }

    /// <summary>
    /// The scopes that were actually granted for this token, which may be narrower than
    /// the scope that was requested.
    /// </summary>
    [JsonPropertyName("scope")]
    public string Scope { get; set; }

    /// <summary>
    /// The type of the token issued, as a URN.
    /// </summary>
    [JsonPropertyName("issued_token_type")]
    public string IssuedTokenType { get; set; }

    private ActorCache? actorCache;

    /// <summary>
    /// Returns the current actor - the outermost <c>act.sub</c>, identifying the client
    /// that performed the exchange. This is the <b>only</b> value to use for authorization
    /// decisions. Returns <c>null</c> when the token has no <c>act</c>
    /// claim or cannot be decoded.
    /// </summary>
    /// <remarks>
    /// The access token is decoded <b>without signature verification</b>. Validate the
    /// token separately before trusting this value.
    /// </remarks>
    public string? GetCurrentActor()
    {
        return GetActor()?.Subject;
    }

    /// <summary>
    /// Returns the full delegation chain (the current actor plus any nested prior actors).
    /// <b>For audit/logging only</b> - nested prior actors must not be used for access
    /// control. Returns <c>null</c> when the token has no <c>act</c> claim
    /// or cannot be decoded.
    /// </summary>
    /// <remarks>
    /// The access token is decoded <b>without signature verification</b>. Validate the
    /// token separately before trusting these values.
    /// </remarks>
    public Actor? GetDelegationChain()
    {
        return GetActor();
    }

    /// <summary>
    /// Decodes the <c>act</c> claim from <see cref="TokenBase.AccessToken"/>, caching the
    /// result so repeated calls to <see cref="GetCurrentActor"/> and
    /// <see cref="GetDelegationChain"/> do not re-parse the token. The cache is refreshed if
    /// <see cref="TokenBase.AccessToken"/> is reassigned.
    /// </summary>
    /// <remarks>
    /// The token and its decoded actor are held together in a single immutable
    /// <see cref="ActorCache"/> that is published with a volatile (release) write and read
    /// with a volatile (acquire) read. A caller reading concurrently always observes a
    /// consistent, fully-constructed (token, actor) pair - never a mismatched one - so the
    /// cache cannot return an actor decoded from a stale token.
    /// </remarks>
    private Actor? GetActor()
    {
        // Snapshot both the token and the cache once so this method is internally
        // consistent even if AccessToken is reassigned by another thread while it runs.
        // Volatile.Read/Write publish the immutable holder with acquire/release semantics so
        // a concurrent reader that sees the reference also sees its fully-constructed fields
        // (a plain write gives no such guarantee on weak memory models such as ARM64).
        var token = AccessToken;
        var cache = Volatile.Read(ref actorCache);

        if (cache is null || !ReferenceEquals(cache.Token, token))
        {
            cache = new ActorCache(token, ActClaimReader.ReadActor(token));
            Volatile.Write(ref actorCache, cache);
        }

        return cache.Actor;
    }

    /// <summary>
    /// Immutable pairing of an access token with the <see cref="Actor"/> decoded from it,
    /// so both are published together as a single reference (see <see cref="GetActor"/>).
    /// </summary>
    private sealed class ActorCache
    {
        public ActorCache(string? token, Actor? actor)
        {
            Token = token;
            Actor = actor;
        }

        public string? Token { get; }

        public Actor? Actor { get; }
    }
}
