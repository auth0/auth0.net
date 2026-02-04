// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Page Background Color or Gradient.
/// Property contains either <code>null</code> to unset, a solid color as a string value <code>#FFFFFF</code>, or a gradient as an object.
///
/// <pre><code>
/// {
///   type: 'linear-gradient',
///   start: '#FFFFFF',
///   end: '#000000',
///   angle_deg: 35
/// }
/// </code></pre>
/// </summary>
[JsonConverter(typeof(BrandingPageBackground.JsonConverter))]
[Serializable]
public class BrandingPageBackground
{
    private BrandingPageBackground(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Type discriminator
    /// </summary>
    [JsonIgnore]
    public string Type { get; internal set; }

    /// <summary>
    /// Union value
    /// </summary>
    [JsonIgnore]
    public object? Value { get; internal set; }

    /// <summary>
    /// Factory method to create a union from a string value.
    /// </summary>
    public static BrandingPageBackground FromString(string value) => new("string", value);

    /// <summary>
    /// Factory method to create a union from a Dictionary<string, object?> value.
    /// </summary>
    public static BrandingPageBackground FromMapOfStringToUnknown(
        Dictionary<string, object?> value
    ) => new("map", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "string"
    /// </summary>
    public bool IsString() => Type == "string";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "map"
    /// </summary>
    public bool IsMapOfStringToUnknown() => Type == "map";

    /// <summary>
    /// Returns the value as a <see cref="string"/> if <see cref="Type"/> is 'string', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'string'.</exception>
    public string AsString() =>
        IsString() ? (string)Value! : throw new ManagementException("Union type is not 'string'");

    /// <summary>
    /// Returns the value as a <see cref="Dictionary<string, object?>"/> if <see cref="Type"/> is 'map', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'map'.</exception>
    public Dictionary<string, object?> AsMapOfStringToUnknown() =>
        IsMapOfStringToUnknown()
            ? (Dictionary<string, object?>)Value!
            : throw new ManagementException("Union type is not 'map'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="string"/> and returns true if successful.
    /// </summary>
    public bool TryGetString(out string? value)
    {
        if (Type == "string")
        {
            value = (string)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Dictionary<string, object?>"/> and returns true if successful.
    /// </summary>
    public bool TryGetMapOfStringToUnknown(out Dictionary<string, object?>? value)
    {
        if (Type == "map")
        {
            value = (Dictionary<string, object?>)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<string, T> onString,
        Func<Dictionary<string, object?>, T> onMapOfStringToUnknown
    )
    {
        return Type switch
        {
            "string" => onString(AsString()),
            "map" => onMapOfStringToUnknown(AsMapOfStringToUnknown()),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        System.Action<string> onString,
        System.Action<Dictionary<string, object?>> onMapOfStringToUnknown
    )
    {
        switch (Type)
        {
            case "string":
                onString(AsString());
                break;
            case "map":
                onMapOfStringToUnknown(AsMapOfStringToUnknown());
                break;
            default:
                throw new ManagementException($"Unknown union type: {Type}");
        }
    }

    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = Type.GetHashCode();
            if (Value != null)
            {
                hashCode = (hashCode * 397) ^ Value.GetHashCode();
            }
            return hashCode;
        }
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        if (obj is not BrandingPageBackground other)
            return false;

        // Compare type discriminators
        if (Type != other.Type)
            return false;

        // Compare values using EqualityComparer for deep comparison
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator BrandingPageBackground(string value) => new("string", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<BrandingPageBackground>
    {
        public override BrandingPageBackground? Read(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            if (reader.TokenType == JsonTokenType.String)
            {
                var stringValue = reader.GetString()!;

                BrandingPageBackground stringResult = new("string", stringValue);
                return stringResult;
            }

            if (reader.TokenType == JsonTokenType.StartArray)
            {
                var document = JsonDocument.ParseValue(ref reader);

                var types = new (string Key, System.Type Type)[]
                {
                    ("map", typeof(Dictionary<string, object?>)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            BrandingPageBackground result = new(key, value);
                            return result;
                        }
                    }
                    catch (JsonException)
                    {
                        // Try next type;
                    }
                }
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into BrandingPageBackground"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            BrandingPageBackground value,
            JsonSerializerOptions options
        )
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            value.Visit(
                str => writer.WriteStringValue(str),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override BrandingPageBackground ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            BrandingPageBackground result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            BrandingPageBackground value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
