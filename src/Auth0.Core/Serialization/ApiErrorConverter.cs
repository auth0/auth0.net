using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.Core.Exceptions;

namespace Auth0.Core.Serialization;

internal class ApiErrorConverter : JsonConverter<ApiError>
{
    private static readonly Dictionary<string, string> PropertyMappings = new(StringComparer.OrdinalIgnoreCase)
    {
        { "code", "errorCode" },
        { "name", "error" },
        { "description", "message" },
        { "error_description", "message" },
    };

    public override ApiError Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        using var doc = JsonDocument.ParseValue(ref reader);
        var error = new ApiError();

        foreach (var property in doc.RootElement.EnumerateObject())
        {
            if (!PropertyMappings.TryGetValue(property.Name, out var name))
                name = property.Name;

            if (string.Equals(name, "errorCode", StringComparison.OrdinalIgnoreCase))
                error.ErrorCode = ReadString(property.Value);
            else if (string.Equals(name, "error", StringComparison.OrdinalIgnoreCase))
                error.Error = ReadString(property.Value);
            else if (string.Equals(name, "message", StringComparison.OrdinalIgnoreCase))
                error.Message = ReadString(property.Value);
            else if (string.Equals(name, "extraData", StringComparison.OrdinalIgnoreCase)
                     && property.Value.ValueKind == JsonValueKind.Object)
            {
                foreach (var inner in property.Value.EnumerateObject())
                    error.ExtraData[inner.Name] = ReadString(inner.Value) ?? "";
            }
            else
            {
                error.ExtraData[name] = ReadString(property.Value) ?? "";
            }
        }

        return error;
    }

    // Mirrors Newtonsoft's ToObject<string>/ToString coercion: JSON null → null,
    // strings unwrapped, other scalars kept as their raw text (never throws on non-strings).
    private static string? ReadString(JsonElement value) => value.ValueKind switch
    {
        JsonValueKind.Null => null,
        JsonValueKind.String => value.GetString(),
        _ => value.GetRawText(),
    };

    public override void Write(Utf8JsonWriter writer, ApiError value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}
