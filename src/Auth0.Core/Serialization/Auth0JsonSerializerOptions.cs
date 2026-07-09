using System.Text.Json;
using System.Text.Json.Serialization;

namespace Auth0.Core.Serialization;

/// <summary>
/// Shared System.Text.Json options that reproduce the serialization behavior the SDK
/// historically provided via Newtonsoft.Json (case-insensitive matching, null omission
/// on write). This is the single source of truth for serialization configuration.
/// </summary>
internal static class Auth0JsonSerializerOptions
{
    public static readonly JsonSerializerOptions Default = Create();

    private static JsonSerializerOptions Create()
    {
        return new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        };
    }
}
