// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Client array filter items
/// </summary>
[JsonConverter(typeof(AculClientFilter.JsonConverter))]
[Serializable]
public class AculClientFilter
{
    private AculClientFilter(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.AculClientFilterById value.
    /// </summary>
    public static AculClientFilter FromAculClientFilterById(
        Auth0.ManagementApi.AculClientFilterById value
    ) => new("aculClientFilterById", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.AculClientFilterByMetadata value.
    /// </summary>
    public static AculClientFilter FromAculClientFilterByMetadata(
        Auth0.ManagementApi.AculClientFilterByMetadata value
    ) => new("aculClientFilterByMetadata", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "aculClientFilterById"
    /// </summary>
    public bool IsAculClientFilterById() => Type == "aculClientFilterById";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "aculClientFilterByMetadata"
    /// </summary>
    public bool IsAculClientFilterByMetadata() => Type == "aculClientFilterByMetadata";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.AculClientFilterById"/> if <see cref="Type"/> is 'aculClientFilterById', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'aculClientFilterById'.</exception>
    public Auth0.ManagementApi.AculClientFilterById AsAculClientFilterById() =>
        IsAculClientFilterById()
            ? (Auth0.ManagementApi.AculClientFilterById)Value!
            : throw new ManagementException("Union type is not 'aculClientFilterById'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.AculClientFilterByMetadata"/> if <see cref="Type"/> is 'aculClientFilterByMetadata', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'aculClientFilterByMetadata'.</exception>
    public Auth0.ManagementApi.AculClientFilterByMetadata AsAculClientFilterByMetadata() =>
        IsAculClientFilterByMetadata()
            ? (Auth0.ManagementApi.AculClientFilterByMetadata)Value!
            : throw new ManagementException("Union type is not 'aculClientFilterByMetadata'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.AculClientFilterById"/> and returns true if successful.
    /// </summary>
    public bool TryGetAculClientFilterById(out Auth0.ManagementApi.AculClientFilterById? value)
    {
        if (Type == "aculClientFilterById")
        {
            value = (Auth0.ManagementApi.AculClientFilterById)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.AculClientFilterByMetadata"/> and returns true if successful.
    /// </summary>
    public bool TryGetAculClientFilterByMetadata(
        out Auth0.ManagementApi.AculClientFilterByMetadata? value
    )
    {
        if (Type == "aculClientFilterByMetadata")
        {
            value = (Auth0.ManagementApi.AculClientFilterByMetadata)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Auth0.ManagementApi.AculClientFilterById, T> onAculClientFilterById,
        Func<Auth0.ManagementApi.AculClientFilterByMetadata, T> onAculClientFilterByMetadata
    )
    {
        return Type switch
        {
            "aculClientFilterById" => onAculClientFilterById(AsAculClientFilterById()),
            "aculClientFilterByMetadata" => onAculClientFilterByMetadata(
                AsAculClientFilterByMetadata()
            ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.AculClientFilterById> onAculClientFilterById,
        global::System.Action<Auth0.ManagementApi.AculClientFilterByMetadata> onAculClientFilterByMetadata
    )
    {
        switch (Type)
        {
            case "aculClientFilterById":
                onAculClientFilterById(AsAculClientFilterById());
                break;
            case "aculClientFilterByMetadata":
                onAculClientFilterByMetadata(AsAculClientFilterByMetadata());
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
        if (obj is not AculClientFilter other)
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

    public static implicit operator AculClientFilter(
        Auth0.ManagementApi.AculClientFilterById value
    ) => new("aculClientFilterById", value);

    public static implicit operator AculClientFilter(
        Auth0.ManagementApi.AculClientFilterByMetadata value
    ) => new("aculClientFilterByMetadata", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<AculClientFilter>
    {
        public override AculClientFilter? Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            if (reader.TokenType == JsonTokenType.StartObject)
            {
                var document = JsonDocument.ParseValue(ref reader);

                var types = new (string Key, System.Type Type)[]
                {
                    ("aculClientFilterById", typeof(Auth0.ManagementApi.AculClientFilterById)),
                    (
                        "aculClientFilterByMetadata",
                        typeof(Auth0.ManagementApi.AculClientFilterByMetadata)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            AculClientFilter result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into AculClientFilter"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            AculClientFilter value,
            JsonSerializerOptions options
        )
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            value.Visit(
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override AculClientFilter ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            AculClientFilter result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AculClientFilter value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
