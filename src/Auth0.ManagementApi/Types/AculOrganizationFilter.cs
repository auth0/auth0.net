// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Organizations array filter items
/// </summary>
[JsonConverter(typeof(AculOrganizationFilter.JsonConverter))]
[Serializable]
public class AculOrganizationFilter
{
    private AculOrganizationFilter(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.AculOrganizationFilterById value.
    /// </summary>
    public static AculOrganizationFilter FromAculOrganizationFilterById(
        Auth0.ManagementApi.AculOrganizationFilterById value
    ) => new("aculOrganizationFilterById", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.AculOrganizationFilterByMetadata value.
    /// </summary>
    public static AculOrganizationFilter FromAculOrganizationFilterByMetadata(
        Auth0.ManagementApi.AculOrganizationFilterByMetadata value
    ) => new("aculOrganizationFilterByMetadata", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "aculOrganizationFilterById"
    /// </summary>
    public bool IsAculOrganizationFilterById() => Type == "aculOrganizationFilterById";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "aculOrganizationFilterByMetadata"
    /// </summary>
    public bool IsAculOrganizationFilterByMetadata() => Type == "aculOrganizationFilterByMetadata";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.AculOrganizationFilterById"/> if <see cref="Type"/> is 'aculOrganizationFilterById', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'aculOrganizationFilterById'.</exception>
    public Auth0.ManagementApi.AculOrganizationFilterById AsAculOrganizationFilterById() =>
        IsAculOrganizationFilterById()
            ? (Auth0.ManagementApi.AculOrganizationFilterById)Value!
            : throw new ManagementException("Union type is not 'aculOrganizationFilterById'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.AculOrganizationFilterByMetadata"/> if <see cref="Type"/> is 'aculOrganizationFilterByMetadata', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'aculOrganizationFilterByMetadata'.</exception>
    public Auth0.ManagementApi.AculOrganizationFilterByMetadata AsAculOrganizationFilterByMetadata() =>
        IsAculOrganizationFilterByMetadata()
            ? (Auth0.ManagementApi.AculOrganizationFilterByMetadata)Value!
            : throw new ManagementException("Union type is not 'aculOrganizationFilterByMetadata'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.AculOrganizationFilterById"/> and returns true if successful.
    /// </summary>
    public bool TryGetAculOrganizationFilterById(
        out Auth0.ManagementApi.AculOrganizationFilterById? value
    )
    {
        if (Type == "aculOrganizationFilterById")
        {
            value = (Auth0.ManagementApi.AculOrganizationFilterById)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.AculOrganizationFilterByMetadata"/> and returns true if successful.
    /// </summary>
    public bool TryGetAculOrganizationFilterByMetadata(
        out Auth0.ManagementApi.AculOrganizationFilterByMetadata? value
    )
    {
        if (Type == "aculOrganizationFilterByMetadata")
        {
            value = (Auth0.ManagementApi.AculOrganizationFilterByMetadata)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Auth0.ManagementApi.AculOrganizationFilterById, T> onAculOrganizationFilterById,
        Func<
            Auth0.ManagementApi.AculOrganizationFilterByMetadata,
            T
        > onAculOrganizationFilterByMetadata
    )
    {
        return Type switch
        {
            "aculOrganizationFilterById" => onAculOrganizationFilterById(
                AsAculOrganizationFilterById()
            ),
            "aculOrganizationFilterByMetadata" => onAculOrganizationFilterByMetadata(
                AsAculOrganizationFilterByMetadata()
            ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        System.Action<Auth0.ManagementApi.AculOrganizationFilterById> onAculOrganizationFilterById,
        System.Action<Auth0.ManagementApi.AculOrganizationFilterByMetadata> onAculOrganizationFilterByMetadata
    )
    {
        switch (Type)
        {
            case "aculOrganizationFilterById":
                onAculOrganizationFilterById(AsAculOrganizationFilterById());
                break;
            case "aculOrganizationFilterByMetadata":
                onAculOrganizationFilterByMetadata(AsAculOrganizationFilterByMetadata());
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
        if (obj is not AculOrganizationFilter other)
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

    public static implicit operator AculOrganizationFilter(
        Auth0.ManagementApi.AculOrganizationFilterById value
    ) => new("aculOrganizationFilterById", value);

    public static implicit operator AculOrganizationFilter(
        Auth0.ManagementApi.AculOrganizationFilterByMetadata value
    ) => new("aculOrganizationFilterByMetadata", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<AculOrganizationFilter>
    {
        public override AculOrganizationFilter? Read(
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
                    (
                        "aculOrganizationFilterById",
                        typeof(Auth0.ManagementApi.AculOrganizationFilterById)
                    ),
                    (
                        "aculOrganizationFilterByMetadata",
                        typeof(Auth0.ManagementApi.AculOrganizationFilterByMetadata)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            AculOrganizationFilter result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into AculOrganizationFilter"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            AculOrganizationFilter value,
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

        public override AculOrganizationFilter ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            AculOrganizationFilter result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AculOrganizationFilter value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
