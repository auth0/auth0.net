// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The event content as it was prior to the change described by this event, when applicable.
/// </summary>
[JsonConverter(typeof(EventStreamCloudEventGroupDeletedPreviousObject.JsonConverter))]
[Serializable]
public class EventStreamCloudEventGroupDeletedPreviousObject
{
    private EventStreamCloudEventGroupDeletedPreviousObject(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupDeletedPreviousObject0 value.
    /// </summary>
    public static EventStreamCloudEventGroupDeletedPreviousObject FromEventStreamCloudEventGroupDeletedPreviousObject0(
        Auth0.ManagementApi.EventStreamCloudEventGroupDeletedPreviousObject0 value
    ) => new("eventStreamCloudEventGroupDeletedPreviousObject0", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupDeletedPreviousObject1 value.
    /// </summary>
    public static EventStreamCloudEventGroupDeletedPreviousObject FromEventStreamCloudEventGroupDeletedPreviousObject1(
        Auth0.ManagementApi.EventStreamCloudEventGroupDeletedPreviousObject1 value
    ) => new("eventStreamCloudEventGroupDeletedPreviousObject1", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupDeletedPreviousObject2 value.
    /// </summary>
    public static EventStreamCloudEventGroupDeletedPreviousObject FromEventStreamCloudEventGroupDeletedPreviousObject2(
        Auth0.ManagementApi.EventStreamCloudEventGroupDeletedPreviousObject2 value
    ) => new("eventStreamCloudEventGroupDeletedPreviousObject2", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupDeletedPreviousObject0"
    /// </summary>
    public bool IsEventStreamCloudEventGroupDeletedPreviousObject0() =>
        Type == "eventStreamCloudEventGroupDeletedPreviousObject0";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupDeletedPreviousObject1"
    /// </summary>
    public bool IsEventStreamCloudEventGroupDeletedPreviousObject1() =>
        Type == "eventStreamCloudEventGroupDeletedPreviousObject1";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupDeletedPreviousObject2"
    /// </summary>
    public bool IsEventStreamCloudEventGroupDeletedPreviousObject2() =>
        Type == "eventStreamCloudEventGroupDeletedPreviousObject2";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupDeletedPreviousObject0"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupDeletedPreviousObject0', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupDeletedPreviousObject0'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupDeletedPreviousObject0 AsEventStreamCloudEventGroupDeletedPreviousObject0() =>
        IsEventStreamCloudEventGroupDeletedPreviousObject0()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupDeletedPreviousObject0)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupDeletedPreviousObject0'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupDeletedPreviousObject1"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupDeletedPreviousObject1', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupDeletedPreviousObject1'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupDeletedPreviousObject1 AsEventStreamCloudEventGroupDeletedPreviousObject1() =>
        IsEventStreamCloudEventGroupDeletedPreviousObject1()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupDeletedPreviousObject1)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupDeletedPreviousObject1'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupDeletedPreviousObject2"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupDeletedPreviousObject2', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupDeletedPreviousObject2'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupDeletedPreviousObject2 AsEventStreamCloudEventGroupDeletedPreviousObject2() =>
        IsEventStreamCloudEventGroupDeletedPreviousObject2()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupDeletedPreviousObject2)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupDeletedPreviousObject2'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupDeletedPreviousObject0"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupDeletedPreviousObject0(
        out Auth0.ManagementApi.EventStreamCloudEventGroupDeletedPreviousObject0? value
    )
    {
        if (Type == "eventStreamCloudEventGroupDeletedPreviousObject0")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupDeletedPreviousObject0)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupDeletedPreviousObject1"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupDeletedPreviousObject1(
        out Auth0.ManagementApi.EventStreamCloudEventGroupDeletedPreviousObject1? value
    )
    {
        if (Type == "eventStreamCloudEventGroupDeletedPreviousObject1")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupDeletedPreviousObject1)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupDeletedPreviousObject2"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupDeletedPreviousObject2(
        out Auth0.ManagementApi.EventStreamCloudEventGroupDeletedPreviousObject2? value
    )
    {
        if (Type == "eventStreamCloudEventGroupDeletedPreviousObject2")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupDeletedPreviousObject2)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupDeletedPreviousObject0,
            T
        > onEventStreamCloudEventGroupDeletedPreviousObject0,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupDeletedPreviousObject1,
            T
        > onEventStreamCloudEventGroupDeletedPreviousObject1,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupDeletedPreviousObject2,
            T
        > onEventStreamCloudEventGroupDeletedPreviousObject2
    )
    {
        return Type switch
        {
            "eventStreamCloudEventGroupDeletedPreviousObject0" =>
                onEventStreamCloudEventGroupDeletedPreviousObject0(
                    AsEventStreamCloudEventGroupDeletedPreviousObject0()
                ),
            "eventStreamCloudEventGroupDeletedPreviousObject1" =>
                onEventStreamCloudEventGroupDeletedPreviousObject1(
                    AsEventStreamCloudEventGroupDeletedPreviousObject1()
                ),
            "eventStreamCloudEventGroupDeletedPreviousObject2" =>
                onEventStreamCloudEventGroupDeletedPreviousObject2(
                    AsEventStreamCloudEventGroupDeletedPreviousObject2()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupDeletedPreviousObject0> onEventStreamCloudEventGroupDeletedPreviousObject0,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupDeletedPreviousObject1> onEventStreamCloudEventGroupDeletedPreviousObject1,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupDeletedPreviousObject2> onEventStreamCloudEventGroupDeletedPreviousObject2
    )
    {
        switch (Type)
        {
            case "eventStreamCloudEventGroupDeletedPreviousObject0":
                onEventStreamCloudEventGroupDeletedPreviousObject0(
                    AsEventStreamCloudEventGroupDeletedPreviousObject0()
                );
                break;
            case "eventStreamCloudEventGroupDeletedPreviousObject1":
                onEventStreamCloudEventGroupDeletedPreviousObject1(
                    AsEventStreamCloudEventGroupDeletedPreviousObject1()
                );
                break;
            case "eventStreamCloudEventGroupDeletedPreviousObject2":
                onEventStreamCloudEventGroupDeletedPreviousObject2(
                    AsEventStreamCloudEventGroupDeletedPreviousObject2()
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
        if (obj is not EventStreamCloudEventGroupDeletedPreviousObject other)
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

    public static implicit operator EventStreamCloudEventGroupDeletedPreviousObject(
        Auth0.ManagementApi.EventStreamCloudEventGroupDeletedPreviousObject0 value
    ) => new("eventStreamCloudEventGroupDeletedPreviousObject0", value);

    public static implicit operator EventStreamCloudEventGroupDeletedPreviousObject(
        Auth0.ManagementApi.EventStreamCloudEventGroupDeletedPreviousObject1 value
    ) => new("eventStreamCloudEventGroupDeletedPreviousObject1", value);

    public static implicit operator EventStreamCloudEventGroupDeletedPreviousObject(
        Auth0.ManagementApi.EventStreamCloudEventGroupDeletedPreviousObject2 value
    ) => new("eventStreamCloudEventGroupDeletedPreviousObject2", value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<EventStreamCloudEventGroupDeletedPreviousObject>
    {
        public override EventStreamCloudEventGroupDeletedPreviousObject? Read(
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
                    (
                        "eventStreamCloudEventGroupDeletedPreviousObject0",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupDeletedPreviousObject0)
                    ),
                    (
                        "eventStreamCloudEventGroupDeletedPreviousObject1",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupDeletedPreviousObject1)
                    ),
                    (
                        "eventStreamCloudEventGroupDeletedPreviousObject2",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupDeletedPreviousObject2)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamCloudEventGroupDeletedPreviousObject result = new(
                                key,
                                value
                            );
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventGroupDeletedPreviousObject"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupDeletedPreviousObject value,
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

        public override EventStreamCloudEventGroupDeletedPreviousObject ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventGroupDeletedPreviousObject result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupDeletedPreviousObject value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
