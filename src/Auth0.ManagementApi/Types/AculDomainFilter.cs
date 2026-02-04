// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Domains array filter items
/// </summary>
[JsonConverter(typeof(AculDomainFilter.JsonConverter))]
[Serializable]
public class AculDomainFilter
{
    private AculDomainFilter(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.AculDomainFilterById value.
    /// </summary>
    public static AculDomainFilter FromAculDomainFilterById(
        Auth0.ManagementApi.AculDomainFilterById value
    ) => new("aculDomainFilterById", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.AculDomainFilterByMetadata value.
    /// </summary>
    public static AculDomainFilter FromAculDomainFilterByMetadata(
        Auth0.ManagementApi.AculDomainFilterByMetadata value
    ) => new("aculDomainFilterByMetadata", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "aculDomainFilterById"
    /// </summary>
    public bool IsAculDomainFilterById() => Type == "aculDomainFilterById";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "aculDomainFilterByMetadata"
    /// </summary>
    public bool IsAculDomainFilterByMetadata() => Type == "aculDomainFilterByMetadata";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.AculDomainFilterById"/> if <see cref="Type"/> is 'aculDomainFilterById', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'aculDomainFilterById'.</exception>
    public Auth0.ManagementApi.AculDomainFilterById AsAculDomainFilterById() =>
        IsAculDomainFilterById()
            ? (Auth0.ManagementApi.AculDomainFilterById)Value!
            : throw new ManagementException("Union type is not 'aculDomainFilterById'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.AculDomainFilterByMetadata"/> if <see cref="Type"/> is 'aculDomainFilterByMetadata', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'aculDomainFilterByMetadata'.</exception>
    public Auth0.ManagementApi.AculDomainFilterByMetadata AsAculDomainFilterByMetadata() =>
        IsAculDomainFilterByMetadata()
            ? (Auth0.ManagementApi.AculDomainFilterByMetadata)Value!
            : throw new ManagementException("Union type is not 'aculDomainFilterByMetadata'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.AculDomainFilterById"/> and returns true if successful.
    /// </summary>
    public bool TryGetAculDomainFilterById(out Auth0.ManagementApi.AculDomainFilterById? value)
    {
        if (Type == "aculDomainFilterById")
        {
            value = (Auth0.ManagementApi.AculDomainFilterById)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.AculDomainFilterByMetadata"/> and returns true if successful.
    /// </summary>
    public bool TryGetAculDomainFilterByMetadata(
        out Auth0.ManagementApi.AculDomainFilterByMetadata? value
    )
    {
        if (Type == "aculDomainFilterByMetadata")
        {
            value = (Auth0.ManagementApi.AculDomainFilterByMetadata)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Auth0.ManagementApi.AculDomainFilterById, T> onAculDomainFilterById,
        Func<Auth0.ManagementApi.AculDomainFilterByMetadata, T> onAculDomainFilterByMetadata
    )
    {
        return Type switch
        {
            "aculDomainFilterById" => onAculDomainFilterById(AsAculDomainFilterById()),
            "aculDomainFilterByMetadata" => onAculDomainFilterByMetadata(
                AsAculDomainFilterByMetadata()
            ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        System.Action<Auth0.ManagementApi.AculDomainFilterById> onAculDomainFilterById,
        System.Action<Auth0.ManagementApi.AculDomainFilterByMetadata> onAculDomainFilterByMetadata
    )
    {
        switch (Type)
        {
            case "aculDomainFilterById":
                onAculDomainFilterById(AsAculDomainFilterById());
                break;
            case "aculDomainFilterByMetadata":
                onAculDomainFilterByMetadata(AsAculDomainFilterByMetadata());
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
        if (obj is not AculDomainFilter other)
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

    public static implicit operator AculDomainFilter(
        Auth0.ManagementApi.AculDomainFilterById value
    ) => new("aculDomainFilterById", value);

    public static implicit operator AculDomainFilter(
        Auth0.ManagementApi.AculDomainFilterByMetadata value
    ) => new("aculDomainFilterByMetadata", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<AculDomainFilter>
    {
        public override AculDomainFilter? Read(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
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
                    ("aculDomainFilterById", typeof(Auth0.ManagementApi.AculDomainFilterById)),
                    (
                        "aculDomainFilterByMetadata",
                        typeof(Auth0.ManagementApi.AculDomainFilterByMetadata)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            AculDomainFilter result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into AculDomainFilter"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            AculDomainFilter value,
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

        public override AculDomainFilter ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            AculDomainFilter result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AculDomainFilter value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
