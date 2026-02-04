// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(LogStreamResponseSchema.JsonConverter))]
[Serializable]
public class LogStreamResponseSchema
{
    private LogStreamResponseSchema(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.LogStreamHttpResponseSchema value.
    /// </summary>
    public static LogStreamResponseSchema FromLogStreamHttpResponseSchema(
        Auth0.ManagementApi.LogStreamHttpResponseSchema value
    ) => new("logStreamHttpResponseSchema", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.LogStreamEventBridgeResponseSchema value.
    /// </summary>
    public static LogStreamResponseSchema FromLogStreamEventBridgeResponseSchema(
        Auth0.ManagementApi.LogStreamEventBridgeResponseSchema value
    ) => new("logStreamEventBridgeResponseSchema", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.LogStreamEventGridResponseSchema value.
    /// </summary>
    public static LogStreamResponseSchema FromLogStreamEventGridResponseSchema(
        Auth0.ManagementApi.LogStreamEventGridResponseSchema value
    ) => new("logStreamEventGridResponseSchema", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.LogStreamDatadogResponseSchema value.
    /// </summary>
    public static LogStreamResponseSchema FromLogStreamDatadogResponseSchema(
        Auth0.ManagementApi.LogStreamDatadogResponseSchema value
    ) => new("logStreamDatadogResponseSchema", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.LogStreamSplunkResponseSchema value.
    /// </summary>
    public static LogStreamResponseSchema FromLogStreamSplunkResponseSchema(
        Auth0.ManagementApi.LogStreamSplunkResponseSchema value
    ) => new("logStreamSplunkResponseSchema", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.LogStreamSumoResponseSchema value.
    /// </summary>
    public static LogStreamResponseSchema FromLogStreamSumoResponseSchema(
        Auth0.ManagementApi.LogStreamSumoResponseSchema value
    ) => new("logStreamSumoResponseSchema", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.LogStreamSegmentResponseSchema value.
    /// </summary>
    public static LogStreamResponseSchema FromLogStreamSegmentResponseSchema(
        Auth0.ManagementApi.LogStreamSegmentResponseSchema value
    ) => new("logStreamSegmentResponseSchema", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.LogStreamMixpanelResponseSchema value.
    /// </summary>
    public static LogStreamResponseSchema FromLogStreamMixpanelResponseSchema(
        Auth0.ManagementApi.LogStreamMixpanelResponseSchema value
    ) => new("logStreamMixpanelResponseSchema", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "logStreamHttpResponseSchema"
    /// </summary>
    public bool IsLogStreamHttpResponseSchema() => Type == "logStreamHttpResponseSchema";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "logStreamEventBridgeResponseSchema"
    /// </summary>
    public bool IsLogStreamEventBridgeResponseSchema() =>
        Type == "logStreamEventBridgeResponseSchema";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "logStreamEventGridResponseSchema"
    /// </summary>
    public bool IsLogStreamEventGridResponseSchema() => Type == "logStreamEventGridResponseSchema";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "logStreamDatadogResponseSchema"
    /// </summary>
    public bool IsLogStreamDatadogResponseSchema() => Type == "logStreamDatadogResponseSchema";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "logStreamSplunkResponseSchema"
    /// </summary>
    public bool IsLogStreamSplunkResponseSchema() => Type == "logStreamSplunkResponseSchema";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "logStreamSumoResponseSchema"
    /// </summary>
    public bool IsLogStreamSumoResponseSchema() => Type == "logStreamSumoResponseSchema";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "logStreamSegmentResponseSchema"
    /// </summary>
    public bool IsLogStreamSegmentResponseSchema() => Type == "logStreamSegmentResponseSchema";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "logStreamMixpanelResponseSchema"
    /// </summary>
    public bool IsLogStreamMixpanelResponseSchema() => Type == "logStreamMixpanelResponseSchema";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.LogStreamHttpResponseSchema"/> if <see cref="Type"/> is 'logStreamHttpResponseSchema', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'logStreamHttpResponseSchema'.</exception>
    public Auth0.ManagementApi.LogStreamHttpResponseSchema AsLogStreamHttpResponseSchema() =>
        IsLogStreamHttpResponseSchema()
            ? (Auth0.ManagementApi.LogStreamHttpResponseSchema)Value!
            : throw new ManagementException("Union type is not 'logStreamHttpResponseSchema'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.LogStreamEventBridgeResponseSchema"/> if <see cref="Type"/> is 'logStreamEventBridgeResponseSchema', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'logStreamEventBridgeResponseSchema'.</exception>
    public Auth0.ManagementApi.LogStreamEventBridgeResponseSchema AsLogStreamEventBridgeResponseSchema() =>
        IsLogStreamEventBridgeResponseSchema()
            ? (Auth0.ManagementApi.LogStreamEventBridgeResponseSchema)Value!
            : throw new ManagementException(
                "Union type is not 'logStreamEventBridgeResponseSchema'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.LogStreamEventGridResponseSchema"/> if <see cref="Type"/> is 'logStreamEventGridResponseSchema', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'logStreamEventGridResponseSchema'.</exception>
    public Auth0.ManagementApi.LogStreamEventGridResponseSchema AsLogStreamEventGridResponseSchema() =>
        IsLogStreamEventGridResponseSchema()
            ? (Auth0.ManagementApi.LogStreamEventGridResponseSchema)Value!
            : throw new ManagementException("Union type is not 'logStreamEventGridResponseSchema'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.LogStreamDatadogResponseSchema"/> if <see cref="Type"/> is 'logStreamDatadogResponseSchema', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'logStreamDatadogResponseSchema'.</exception>
    public Auth0.ManagementApi.LogStreamDatadogResponseSchema AsLogStreamDatadogResponseSchema() =>
        IsLogStreamDatadogResponseSchema()
            ? (Auth0.ManagementApi.LogStreamDatadogResponseSchema)Value!
            : throw new ManagementException("Union type is not 'logStreamDatadogResponseSchema'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.LogStreamSplunkResponseSchema"/> if <see cref="Type"/> is 'logStreamSplunkResponseSchema', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'logStreamSplunkResponseSchema'.</exception>
    public Auth0.ManagementApi.LogStreamSplunkResponseSchema AsLogStreamSplunkResponseSchema() =>
        IsLogStreamSplunkResponseSchema()
            ? (Auth0.ManagementApi.LogStreamSplunkResponseSchema)Value!
            : throw new ManagementException("Union type is not 'logStreamSplunkResponseSchema'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.LogStreamSumoResponseSchema"/> if <see cref="Type"/> is 'logStreamSumoResponseSchema', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'logStreamSumoResponseSchema'.</exception>
    public Auth0.ManagementApi.LogStreamSumoResponseSchema AsLogStreamSumoResponseSchema() =>
        IsLogStreamSumoResponseSchema()
            ? (Auth0.ManagementApi.LogStreamSumoResponseSchema)Value!
            : throw new ManagementException("Union type is not 'logStreamSumoResponseSchema'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.LogStreamSegmentResponseSchema"/> if <see cref="Type"/> is 'logStreamSegmentResponseSchema', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'logStreamSegmentResponseSchema'.</exception>
    public Auth0.ManagementApi.LogStreamSegmentResponseSchema AsLogStreamSegmentResponseSchema() =>
        IsLogStreamSegmentResponseSchema()
            ? (Auth0.ManagementApi.LogStreamSegmentResponseSchema)Value!
            : throw new ManagementException("Union type is not 'logStreamSegmentResponseSchema'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.LogStreamMixpanelResponseSchema"/> if <see cref="Type"/> is 'logStreamMixpanelResponseSchema', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'logStreamMixpanelResponseSchema'.</exception>
    public Auth0.ManagementApi.LogStreamMixpanelResponseSchema AsLogStreamMixpanelResponseSchema() =>
        IsLogStreamMixpanelResponseSchema()
            ? (Auth0.ManagementApi.LogStreamMixpanelResponseSchema)Value!
            : throw new ManagementException("Union type is not 'logStreamMixpanelResponseSchema'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.LogStreamHttpResponseSchema"/> and returns true if successful.
    /// </summary>
    public bool TryGetLogStreamHttpResponseSchema(
        out Auth0.ManagementApi.LogStreamHttpResponseSchema? value
    )
    {
        if (Type == "logStreamHttpResponseSchema")
        {
            value = (Auth0.ManagementApi.LogStreamHttpResponseSchema)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.LogStreamEventBridgeResponseSchema"/> and returns true if successful.
    /// </summary>
    public bool TryGetLogStreamEventBridgeResponseSchema(
        out Auth0.ManagementApi.LogStreamEventBridgeResponseSchema? value
    )
    {
        if (Type == "logStreamEventBridgeResponseSchema")
        {
            value = (Auth0.ManagementApi.LogStreamEventBridgeResponseSchema)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.LogStreamEventGridResponseSchema"/> and returns true if successful.
    /// </summary>
    public bool TryGetLogStreamEventGridResponseSchema(
        out Auth0.ManagementApi.LogStreamEventGridResponseSchema? value
    )
    {
        if (Type == "logStreamEventGridResponseSchema")
        {
            value = (Auth0.ManagementApi.LogStreamEventGridResponseSchema)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.LogStreamDatadogResponseSchema"/> and returns true if successful.
    /// </summary>
    public bool TryGetLogStreamDatadogResponseSchema(
        out Auth0.ManagementApi.LogStreamDatadogResponseSchema? value
    )
    {
        if (Type == "logStreamDatadogResponseSchema")
        {
            value = (Auth0.ManagementApi.LogStreamDatadogResponseSchema)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.LogStreamSplunkResponseSchema"/> and returns true if successful.
    /// </summary>
    public bool TryGetLogStreamSplunkResponseSchema(
        out Auth0.ManagementApi.LogStreamSplunkResponseSchema? value
    )
    {
        if (Type == "logStreamSplunkResponseSchema")
        {
            value = (Auth0.ManagementApi.LogStreamSplunkResponseSchema)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.LogStreamSumoResponseSchema"/> and returns true if successful.
    /// </summary>
    public bool TryGetLogStreamSumoResponseSchema(
        out Auth0.ManagementApi.LogStreamSumoResponseSchema? value
    )
    {
        if (Type == "logStreamSumoResponseSchema")
        {
            value = (Auth0.ManagementApi.LogStreamSumoResponseSchema)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.LogStreamSegmentResponseSchema"/> and returns true if successful.
    /// </summary>
    public bool TryGetLogStreamSegmentResponseSchema(
        out Auth0.ManagementApi.LogStreamSegmentResponseSchema? value
    )
    {
        if (Type == "logStreamSegmentResponseSchema")
        {
            value = (Auth0.ManagementApi.LogStreamSegmentResponseSchema)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.LogStreamMixpanelResponseSchema"/> and returns true if successful.
    /// </summary>
    public bool TryGetLogStreamMixpanelResponseSchema(
        out Auth0.ManagementApi.LogStreamMixpanelResponseSchema? value
    )
    {
        if (Type == "logStreamMixpanelResponseSchema")
        {
            value = (Auth0.ManagementApi.LogStreamMixpanelResponseSchema)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Auth0.ManagementApi.LogStreamHttpResponseSchema, T> onLogStreamHttpResponseSchema,
        Func<
            Auth0.ManagementApi.LogStreamEventBridgeResponseSchema,
            T
        > onLogStreamEventBridgeResponseSchema,
        Func<
            Auth0.ManagementApi.LogStreamEventGridResponseSchema,
            T
        > onLogStreamEventGridResponseSchema,
        Func<
            Auth0.ManagementApi.LogStreamDatadogResponseSchema,
            T
        > onLogStreamDatadogResponseSchema,
        Func<Auth0.ManagementApi.LogStreamSplunkResponseSchema, T> onLogStreamSplunkResponseSchema,
        Func<Auth0.ManagementApi.LogStreamSumoResponseSchema, T> onLogStreamSumoResponseSchema,
        Func<
            Auth0.ManagementApi.LogStreamSegmentResponseSchema,
            T
        > onLogStreamSegmentResponseSchema,
        Func<
            Auth0.ManagementApi.LogStreamMixpanelResponseSchema,
            T
        > onLogStreamMixpanelResponseSchema
    )
    {
        return Type switch
        {
            "logStreamHttpResponseSchema" => onLogStreamHttpResponseSchema(
                AsLogStreamHttpResponseSchema()
            ),
            "logStreamEventBridgeResponseSchema" => onLogStreamEventBridgeResponseSchema(
                AsLogStreamEventBridgeResponseSchema()
            ),
            "logStreamEventGridResponseSchema" => onLogStreamEventGridResponseSchema(
                AsLogStreamEventGridResponseSchema()
            ),
            "logStreamDatadogResponseSchema" => onLogStreamDatadogResponseSchema(
                AsLogStreamDatadogResponseSchema()
            ),
            "logStreamSplunkResponseSchema" => onLogStreamSplunkResponseSchema(
                AsLogStreamSplunkResponseSchema()
            ),
            "logStreamSumoResponseSchema" => onLogStreamSumoResponseSchema(
                AsLogStreamSumoResponseSchema()
            ),
            "logStreamSegmentResponseSchema" => onLogStreamSegmentResponseSchema(
                AsLogStreamSegmentResponseSchema()
            ),
            "logStreamMixpanelResponseSchema" => onLogStreamMixpanelResponseSchema(
                AsLogStreamMixpanelResponseSchema()
            ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        System.Action<Auth0.ManagementApi.LogStreamHttpResponseSchema> onLogStreamHttpResponseSchema,
        System.Action<Auth0.ManagementApi.LogStreamEventBridgeResponseSchema> onLogStreamEventBridgeResponseSchema,
        System.Action<Auth0.ManagementApi.LogStreamEventGridResponseSchema> onLogStreamEventGridResponseSchema,
        System.Action<Auth0.ManagementApi.LogStreamDatadogResponseSchema> onLogStreamDatadogResponseSchema,
        System.Action<Auth0.ManagementApi.LogStreamSplunkResponseSchema> onLogStreamSplunkResponseSchema,
        System.Action<Auth0.ManagementApi.LogStreamSumoResponseSchema> onLogStreamSumoResponseSchema,
        System.Action<Auth0.ManagementApi.LogStreamSegmentResponseSchema> onLogStreamSegmentResponseSchema,
        System.Action<Auth0.ManagementApi.LogStreamMixpanelResponseSchema> onLogStreamMixpanelResponseSchema
    )
    {
        switch (Type)
        {
            case "logStreamHttpResponseSchema":
                onLogStreamHttpResponseSchema(AsLogStreamHttpResponseSchema());
                break;
            case "logStreamEventBridgeResponseSchema":
                onLogStreamEventBridgeResponseSchema(AsLogStreamEventBridgeResponseSchema());
                break;
            case "logStreamEventGridResponseSchema":
                onLogStreamEventGridResponseSchema(AsLogStreamEventGridResponseSchema());
                break;
            case "logStreamDatadogResponseSchema":
                onLogStreamDatadogResponseSchema(AsLogStreamDatadogResponseSchema());
                break;
            case "logStreamSplunkResponseSchema":
                onLogStreamSplunkResponseSchema(AsLogStreamSplunkResponseSchema());
                break;
            case "logStreamSumoResponseSchema":
                onLogStreamSumoResponseSchema(AsLogStreamSumoResponseSchema());
                break;
            case "logStreamSegmentResponseSchema":
                onLogStreamSegmentResponseSchema(AsLogStreamSegmentResponseSchema());
                break;
            case "logStreamMixpanelResponseSchema":
                onLogStreamMixpanelResponseSchema(AsLogStreamMixpanelResponseSchema());
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
        if (obj is not LogStreamResponseSchema other)
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

    public static implicit operator LogStreamResponseSchema(
        Auth0.ManagementApi.LogStreamHttpResponseSchema value
    ) => new("logStreamHttpResponseSchema", value);

    public static implicit operator LogStreamResponseSchema(
        Auth0.ManagementApi.LogStreamEventBridgeResponseSchema value
    ) => new("logStreamEventBridgeResponseSchema", value);

    public static implicit operator LogStreamResponseSchema(
        Auth0.ManagementApi.LogStreamEventGridResponseSchema value
    ) => new("logStreamEventGridResponseSchema", value);

    public static implicit operator LogStreamResponseSchema(
        Auth0.ManagementApi.LogStreamDatadogResponseSchema value
    ) => new("logStreamDatadogResponseSchema", value);

    public static implicit operator LogStreamResponseSchema(
        Auth0.ManagementApi.LogStreamSplunkResponseSchema value
    ) => new("logStreamSplunkResponseSchema", value);

    public static implicit operator LogStreamResponseSchema(
        Auth0.ManagementApi.LogStreamSumoResponseSchema value
    ) => new("logStreamSumoResponseSchema", value);

    public static implicit operator LogStreamResponseSchema(
        Auth0.ManagementApi.LogStreamSegmentResponseSchema value
    ) => new("logStreamSegmentResponseSchema", value);

    public static implicit operator LogStreamResponseSchema(
        Auth0.ManagementApi.LogStreamMixpanelResponseSchema value
    ) => new("logStreamMixpanelResponseSchema", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<LogStreamResponseSchema>
    {
        public override LogStreamResponseSchema? Read(
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
                        "logStreamHttpResponseSchema",
                        typeof(Auth0.ManagementApi.LogStreamHttpResponseSchema)
                    ),
                    (
                        "logStreamEventBridgeResponseSchema",
                        typeof(Auth0.ManagementApi.LogStreamEventBridgeResponseSchema)
                    ),
                    (
                        "logStreamEventGridResponseSchema",
                        typeof(Auth0.ManagementApi.LogStreamEventGridResponseSchema)
                    ),
                    (
                        "logStreamDatadogResponseSchema",
                        typeof(Auth0.ManagementApi.LogStreamDatadogResponseSchema)
                    ),
                    (
                        "logStreamSplunkResponseSchema",
                        typeof(Auth0.ManagementApi.LogStreamSplunkResponseSchema)
                    ),
                    (
                        "logStreamSumoResponseSchema",
                        typeof(Auth0.ManagementApi.LogStreamSumoResponseSchema)
                    ),
                    (
                        "logStreamSegmentResponseSchema",
                        typeof(Auth0.ManagementApi.LogStreamSegmentResponseSchema)
                    ),
                    (
                        "logStreamMixpanelResponseSchema",
                        typeof(Auth0.ManagementApi.LogStreamMixpanelResponseSchema)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            LogStreamResponseSchema result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into LogStreamResponseSchema"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            LogStreamResponseSchema value,
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
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override LogStreamResponseSchema ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            LogStreamResponseSchema result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            LogStreamResponseSchema value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
