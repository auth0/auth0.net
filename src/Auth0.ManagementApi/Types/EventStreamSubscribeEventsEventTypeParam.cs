// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Event type(s) to listen for. Specify multiple times for multiple types (e.g., ?event_type=user.created&event_type=user.updated). If not provided, all event types will be streamed.
/// </summary>
[JsonConverter(typeof(EventStreamSubscribeEventsEventTypeParam.JsonConverter))]
[Serializable]
public class EventStreamSubscribeEventsEventTypeParam
{
    private EventStreamSubscribeEventsEventTypeParam(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamSubscribeEventsEventTypeEnum value.
    /// </summary>
    public static EventStreamSubscribeEventsEventTypeParam FromEventStreamSubscribeEventsEventTypeEnum(
        Auth0.ManagementApi.EventStreamSubscribeEventsEventTypeEnum value
    ) => new("eventStreamSubscribeEventsEventTypeEnum", value);

    /// <summary>
    /// Factory method to create a union from a IEnumerable<EventStreamSubscribeEventsEventTypeEnum> value.
    /// </summary>
    public static EventStreamSubscribeEventsEventTypeParam FromListOfEventStreamSubscribeEventsEventTypeEnum(
        IEnumerable<EventStreamSubscribeEventsEventTypeEnum> value
    ) => new("list", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamSubscribeEventsEventTypeEnum"
    /// </summary>
    public bool IsEventStreamSubscribeEventsEventTypeEnum() =>
        Type == "eventStreamSubscribeEventsEventTypeEnum";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "list"
    /// </summary>
    public bool IsListOfEventStreamSubscribeEventsEventTypeEnum() => Type == "list";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamSubscribeEventsEventTypeEnum"/> if <see cref="Type"/> is 'eventStreamSubscribeEventsEventTypeEnum', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamSubscribeEventsEventTypeEnum'.</exception>
    public Auth0.ManagementApi.EventStreamSubscribeEventsEventTypeEnum AsEventStreamSubscribeEventsEventTypeEnum() =>
        IsEventStreamSubscribeEventsEventTypeEnum()
            ? (Auth0.ManagementApi.EventStreamSubscribeEventsEventTypeEnum)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamSubscribeEventsEventTypeEnum'"
            );

    /// <summary>
    /// Returns the value as a <see cref="IEnumerable<EventStreamSubscribeEventsEventTypeEnum>"/> if <see cref="Type"/> is 'list', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'list'.</exception>
    public IEnumerable<EventStreamSubscribeEventsEventTypeEnum> AsListOfEventStreamSubscribeEventsEventTypeEnum() =>
        IsListOfEventStreamSubscribeEventsEventTypeEnum()
            ? (IEnumerable<EventStreamSubscribeEventsEventTypeEnum>)Value!
            : throw new ManagementException("Union type is not 'list'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamSubscribeEventsEventTypeEnum"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamSubscribeEventsEventTypeEnum(
        out Auth0.ManagementApi.EventStreamSubscribeEventsEventTypeEnum? value
    )
    {
        if (Type == "eventStreamSubscribeEventsEventTypeEnum")
        {
            value = (Auth0.ManagementApi.EventStreamSubscribeEventsEventTypeEnum)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="IEnumerable<EventStreamSubscribeEventsEventTypeEnum>"/> and returns true if successful.
    /// </summary>
    public bool TryGetListOfEventStreamSubscribeEventsEventTypeEnum(
        out IEnumerable<EventStreamSubscribeEventsEventTypeEnum>? value
    )
    {
        if (Type == "list")
        {
            value = (IEnumerable<EventStreamSubscribeEventsEventTypeEnum>)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamSubscribeEventsEventTypeEnum,
            T
        > onEventStreamSubscribeEventsEventTypeEnum,
        Func<
            IEnumerable<EventStreamSubscribeEventsEventTypeEnum>,
            T
        > onListOfEventStreamSubscribeEventsEventTypeEnum
    )
    {
        return Type switch
        {
            "eventStreamSubscribeEventsEventTypeEnum" => onEventStreamSubscribeEventsEventTypeEnum(
                AsEventStreamSubscribeEventsEventTypeEnum()
            ),
            "list" => onListOfEventStreamSubscribeEventsEventTypeEnum(
                AsListOfEventStreamSubscribeEventsEventTypeEnum()
            ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamSubscribeEventsEventTypeEnum> onEventStreamSubscribeEventsEventTypeEnum,
        global::System.Action<
            IEnumerable<EventStreamSubscribeEventsEventTypeEnum>
        > onListOfEventStreamSubscribeEventsEventTypeEnum
    )
    {
        switch (Type)
        {
            case "eventStreamSubscribeEventsEventTypeEnum":
                onEventStreamSubscribeEventsEventTypeEnum(
                    AsEventStreamSubscribeEventsEventTypeEnum()
                );
                break;
            case "list":
                onListOfEventStreamSubscribeEventsEventTypeEnum(
                    AsListOfEventStreamSubscribeEventsEventTypeEnum()
                );
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
        if (obj is not EventStreamSubscribeEventsEventTypeParam other)
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

    public static implicit operator EventStreamSubscribeEventsEventTypeParam(
        Auth0.ManagementApi.EventStreamSubscribeEventsEventTypeEnum value
    ) => new("eventStreamSubscribeEventsEventTypeEnum", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<EventStreamSubscribeEventsEventTypeParam>
    {
        public override EventStreamSubscribeEventsEventTypeParam? Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            if (reader.TokenType == JsonTokenType.StartArray)
            {
                var document = JsonDocument.ParseValue(ref reader);

                var types = new (string Key, System.Type Type)[]
                {
                    ("list", typeof(IEnumerable<EventStreamSubscribeEventsEventTypeEnum>)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamSubscribeEventsEventTypeParam result = new(key, value);
                            return result;
                        }
                    }
                    catch (JsonException)
                    {
                        // Try next type;
                    }
                }
            }

            if (reader.TokenType == JsonTokenType.StartObject)
            {
                var document = JsonDocument.ParseValue(ref reader);

                var types = new (string Key, System.Type Type)[]
                {
                    (
                        "eventStreamSubscribeEventsEventTypeEnum",
                        typeof(Auth0.ManagementApi.EventStreamSubscribeEventsEventTypeEnum)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamSubscribeEventsEventTypeParam result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamSubscribeEventsEventTypeParam"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamSubscribeEventsEventTypeParam value,
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

        public override EventStreamSubscribeEventsEventTypeParam ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamSubscribeEventsEventTypeParam result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamSubscribeEventsEventTypeParam value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
