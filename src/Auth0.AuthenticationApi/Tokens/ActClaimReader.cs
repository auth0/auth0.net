using System;
using System.Text.Json;

using Auth0.AuthenticationApi.Models;

namespace Auth0.AuthenticationApi.Tokens;

/// <summary>
/// Reads the <c>act</c> (actor) claim from a JWT access-token payload
/// <b>without verifying the token signature</b>. Verifying the token is the responsibility
/// of the downstream resource server and is out of scope for this client.
/// </summary>
internal static class ActClaimReader
{
    /// <summary>
    /// Decodes the payload of <paramref name="accessToken"/> and returns its <c>act</c>
    /// claim as an <see cref="Actor"/>, or <c>null</c> when the token is not a well-formed
    /// JWT or has no <c>act</c> claim.
    /// </summary>
    public static Actor? ReadActor(string? accessToken)
    {
        if (string.IsNullOrEmpty(accessToken))
            return null;

        var parts = accessToken.Split('.');
        if (parts.Length != 3)
            return null;

        try
        {
            var payload = Base64UrlDecode(parts[1]);
            using var document = JsonDocument.Parse(payload);
            if (!document.RootElement.TryGetProperty("act", out var act))
                return null;

            return act.Deserialize<Actor>();
        }
        catch (FormatException)
        {
            return null;
        }
        catch (JsonException)
        {
            return null;
        }
    }

    private static byte[] Base64UrlDecode(string input)
    {
        var output = input.Replace('-', '+').Replace('_', '/');
        switch (output.Length % 4)
        {
            case 2: output += "=="; break;
            case 3: output += "="; break;
        }

        return Convert.FromBase64String(output);
    }
}
