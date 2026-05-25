using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Core;

/// <summary>
/// Handles deserialization of boolean values that may arrive as JSON strings
/// (e.g., "true"/"false") from the Auth0 API, particularly for SAML/SSO users.
/// </summary>
internal class BooleanStringConverter : JsonConverter<bool>
{
    public override bool Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        return reader.TokenType switch
        {
            JsonTokenType.True => true,
            JsonTokenType.False => false,
            JsonTokenType.String when bool.TryParse(reader.GetString(), out var b) => b,
            JsonTokenType.String => throw new JsonException(
                $"Cannot convert \"{reader.GetString()}\" to boolean."),
            _ => throw new JsonException(
                $"Cannot convert token type '{reader.TokenType}' to boolean.")
        };
    }

    public override void Write(
        Utf8JsonWriter writer,
        bool value,
        JsonSerializerOptions options)
    {
        writer.WriteBooleanValue(value);
    }
}
