// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(CreateEventStreamResponseContent.JsonConverter))]
[Serializable]
public class CreateEventStreamResponseContent
{
    private CreateEventStreamResponseContent(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamWebhookResponseContent value.
    /// </summary>
    public static CreateEventStreamResponseContent FromEventStreamWebhookResponseContent(
        Auth0.ManagementApi.EventStreamWebhookResponseContent value
    ) => new("eventStreamWebhookResponseContent", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamEventBridgeResponseContent value.
    /// </summary>
    public static CreateEventStreamResponseContent FromEventStreamEventBridgeResponseContent(
        Auth0.ManagementApi.EventStreamEventBridgeResponseContent value
    ) => new("eventStreamEventBridgeResponseContent", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamActionResponseContent value.
    /// </summary>
    public static CreateEventStreamResponseContent FromEventStreamActionResponseContent(
        Auth0.ManagementApi.EventStreamActionResponseContent value
    ) => new("eventStreamActionResponseContent", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamWebhookResponseContent"
    /// </summary>
    public bool IsEventStreamWebhookResponseContent() =>
        Type == "eventStreamWebhookResponseContent";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamEventBridgeResponseContent"
    /// </summary>
    public bool IsEventStreamEventBridgeResponseContent() =>
        Type == "eventStreamEventBridgeResponseContent";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamActionResponseContent"
    /// </summary>
    public bool IsEventStreamActionResponseContent() => Type == "eventStreamActionResponseContent";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamWebhookResponseContent"/> if <see cref="Type"/> is 'eventStreamWebhookResponseContent', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamWebhookResponseContent'.</exception>
    public Auth0.ManagementApi.EventStreamWebhookResponseContent AsEventStreamWebhookResponseContent() =>
        IsEventStreamWebhookResponseContent()
            ? (Auth0.ManagementApi.EventStreamWebhookResponseContent)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamWebhookResponseContent'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamEventBridgeResponseContent"/> if <see cref="Type"/> is 'eventStreamEventBridgeResponseContent', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamEventBridgeResponseContent'.</exception>
    public Auth0.ManagementApi.EventStreamEventBridgeResponseContent AsEventStreamEventBridgeResponseContent() =>
        IsEventStreamEventBridgeResponseContent()
            ? (Auth0.ManagementApi.EventStreamEventBridgeResponseContent)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamEventBridgeResponseContent'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamActionResponseContent"/> if <see cref="Type"/> is 'eventStreamActionResponseContent', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamActionResponseContent'.</exception>
    public Auth0.ManagementApi.EventStreamActionResponseContent AsEventStreamActionResponseContent() =>
        IsEventStreamActionResponseContent()
            ? (Auth0.ManagementApi.EventStreamActionResponseContent)Value!
            : throw new ManagementException("Union type is not 'eventStreamActionResponseContent'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamWebhookResponseContent"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamWebhookResponseContent(
        out Auth0.ManagementApi.EventStreamWebhookResponseContent? value
    )
    {
        if (Type == "eventStreamWebhookResponseContent")
        {
            value = (Auth0.ManagementApi.EventStreamWebhookResponseContent)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamEventBridgeResponseContent"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamEventBridgeResponseContent(
        out Auth0.ManagementApi.EventStreamEventBridgeResponseContent? value
    )
    {
        if (Type == "eventStreamEventBridgeResponseContent")
        {
            value = (Auth0.ManagementApi.EventStreamEventBridgeResponseContent)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamActionResponseContent"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamActionResponseContent(
        out Auth0.ManagementApi.EventStreamActionResponseContent? value
    )
    {
        if (Type == "eventStreamActionResponseContent")
        {
            value = (Auth0.ManagementApi.EventStreamActionResponseContent)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamWebhookResponseContent,
            T
        > onEventStreamWebhookResponseContent,
        Func<
            Auth0.ManagementApi.EventStreamEventBridgeResponseContent,
            T
        > onEventStreamEventBridgeResponseContent,
        Func<
            Auth0.ManagementApi.EventStreamActionResponseContent,
            T
        > onEventStreamActionResponseContent
    )
    {
        return Type switch
        {
            "eventStreamWebhookResponseContent" => onEventStreamWebhookResponseContent(
                AsEventStreamWebhookResponseContent()
            ),
            "eventStreamEventBridgeResponseContent" => onEventStreamEventBridgeResponseContent(
                AsEventStreamEventBridgeResponseContent()
            ),
            "eventStreamActionResponseContent" => onEventStreamActionResponseContent(
                AsEventStreamActionResponseContent()
            ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        System.Action<Auth0.ManagementApi.EventStreamWebhookResponseContent> onEventStreamWebhookResponseContent,
        System.Action<Auth0.ManagementApi.EventStreamEventBridgeResponseContent> onEventStreamEventBridgeResponseContent,
        System.Action<Auth0.ManagementApi.EventStreamActionResponseContent> onEventStreamActionResponseContent
    )
    {
        switch (Type)
        {
            case "eventStreamWebhookResponseContent":
                onEventStreamWebhookResponseContent(AsEventStreamWebhookResponseContent());
                break;
            case "eventStreamEventBridgeResponseContent":
                onEventStreamEventBridgeResponseContent(AsEventStreamEventBridgeResponseContent());
                break;
            case "eventStreamActionResponseContent":
                onEventStreamActionResponseContent(AsEventStreamActionResponseContent());
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
        if (obj is not CreateEventStreamResponseContent other)
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

    public static implicit operator CreateEventStreamResponseContent(
        Auth0.ManagementApi.EventStreamWebhookResponseContent value
    ) => new("eventStreamWebhookResponseContent", value);

    public static implicit operator CreateEventStreamResponseContent(
        Auth0.ManagementApi.EventStreamEventBridgeResponseContent value
    ) => new("eventStreamEventBridgeResponseContent", value);

    public static implicit operator CreateEventStreamResponseContent(
        Auth0.ManagementApi.EventStreamActionResponseContent value
    ) => new("eventStreamActionResponseContent", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CreateEventStreamResponseContent>
    {
        public override CreateEventStreamResponseContent? Read(
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
                        "eventStreamWebhookResponseContent",
                        typeof(Auth0.ManagementApi.EventStreamWebhookResponseContent)
                    ),
                    (
                        "eventStreamEventBridgeResponseContent",
                        typeof(Auth0.ManagementApi.EventStreamEventBridgeResponseContent)
                    ),
                    (
                        "eventStreamActionResponseContent",
                        typeof(Auth0.ManagementApi.EventStreamActionResponseContent)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            CreateEventStreamResponseContent result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into CreateEventStreamResponseContent"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateEventStreamResponseContent value,
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
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override CreateEventStreamResponseContent ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            CreateEventStreamResponseContent result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateEventStreamResponseContent value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
