// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The event content as it was prior to the change described by this event, when applicable.
/// </summary>
[JsonConverter(typeof(EventStreamCloudEventGroupCreatedPreviousObject.JsonConverter))]
[Serializable]
public class EventStreamCloudEventGroupCreatedPreviousObject
{
    private EventStreamCloudEventGroupCreatedPreviousObject(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupCreatedPreviousObject0 value.
    /// </summary>
    public static EventStreamCloudEventGroupCreatedPreviousObject FromEventStreamCloudEventGroupCreatedPreviousObject0(
        Auth0.ManagementApi.EventStreamCloudEventGroupCreatedPreviousObject0 value
    ) => new("eventStreamCloudEventGroupCreatedPreviousObject0", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupCreatedPreviousObject1 value.
    /// </summary>
    public static EventStreamCloudEventGroupCreatedPreviousObject FromEventStreamCloudEventGroupCreatedPreviousObject1(
        Auth0.ManagementApi.EventStreamCloudEventGroupCreatedPreviousObject1 value
    ) => new("eventStreamCloudEventGroupCreatedPreviousObject1", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupCreatedPreviousObject2 value.
    /// </summary>
    public static EventStreamCloudEventGroupCreatedPreviousObject FromEventStreamCloudEventGroupCreatedPreviousObject2(
        Auth0.ManagementApi.EventStreamCloudEventGroupCreatedPreviousObject2 value
    ) => new("eventStreamCloudEventGroupCreatedPreviousObject2", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupCreatedPreviousObject0"
    /// </summary>
    public bool IsEventStreamCloudEventGroupCreatedPreviousObject0() =>
        Type == "eventStreamCloudEventGroupCreatedPreviousObject0";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupCreatedPreviousObject1"
    /// </summary>
    public bool IsEventStreamCloudEventGroupCreatedPreviousObject1() =>
        Type == "eventStreamCloudEventGroupCreatedPreviousObject1";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupCreatedPreviousObject2"
    /// </summary>
    public bool IsEventStreamCloudEventGroupCreatedPreviousObject2() =>
        Type == "eventStreamCloudEventGroupCreatedPreviousObject2";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupCreatedPreviousObject0"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupCreatedPreviousObject0', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupCreatedPreviousObject0'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupCreatedPreviousObject0 AsEventStreamCloudEventGroupCreatedPreviousObject0() =>
        IsEventStreamCloudEventGroupCreatedPreviousObject0()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupCreatedPreviousObject0)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupCreatedPreviousObject0'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupCreatedPreviousObject1"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupCreatedPreviousObject1', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupCreatedPreviousObject1'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupCreatedPreviousObject1 AsEventStreamCloudEventGroupCreatedPreviousObject1() =>
        IsEventStreamCloudEventGroupCreatedPreviousObject1()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupCreatedPreviousObject1)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupCreatedPreviousObject1'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupCreatedPreviousObject2"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupCreatedPreviousObject2', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupCreatedPreviousObject2'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupCreatedPreviousObject2 AsEventStreamCloudEventGroupCreatedPreviousObject2() =>
        IsEventStreamCloudEventGroupCreatedPreviousObject2()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupCreatedPreviousObject2)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupCreatedPreviousObject2'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupCreatedPreviousObject0"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupCreatedPreviousObject0(
        out Auth0.ManagementApi.EventStreamCloudEventGroupCreatedPreviousObject0? value
    )
    {
        if (Type == "eventStreamCloudEventGroupCreatedPreviousObject0")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupCreatedPreviousObject0)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupCreatedPreviousObject1"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupCreatedPreviousObject1(
        out Auth0.ManagementApi.EventStreamCloudEventGroupCreatedPreviousObject1? value
    )
    {
        if (Type == "eventStreamCloudEventGroupCreatedPreviousObject1")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupCreatedPreviousObject1)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupCreatedPreviousObject2"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupCreatedPreviousObject2(
        out Auth0.ManagementApi.EventStreamCloudEventGroupCreatedPreviousObject2? value
    )
    {
        if (Type == "eventStreamCloudEventGroupCreatedPreviousObject2")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupCreatedPreviousObject2)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupCreatedPreviousObject0,
            T
        > onEventStreamCloudEventGroupCreatedPreviousObject0,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupCreatedPreviousObject1,
            T
        > onEventStreamCloudEventGroupCreatedPreviousObject1,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupCreatedPreviousObject2,
            T
        > onEventStreamCloudEventGroupCreatedPreviousObject2
    )
    {
        return Type switch
        {
            "eventStreamCloudEventGroupCreatedPreviousObject0" =>
                onEventStreamCloudEventGroupCreatedPreviousObject0(
                    AsEventStreamCloudEventGroupCreatedPreviousObject0()
                ),
            "eventStreamCloudEventGroupCreatedPreviousObject1" =>
                onEventStreamCloudEventGroupCreatedPreviousObject1(
                    AsEventStreamCloudEventGroupCreatedPreviousObject1()
                ),
            "eventStreamCloudEventGroupCreatedPreviousObject2" =>
                onEventStreamCloudEventGroupCreatedPreviousObject2(
                    AsEventStreamCloudEventGroupCreatedPreviousObject2()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupCreatedPreviousObject0> onEventStreamCloudEventGroupCreatedPreviousObject0,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupCreatedPreviousObject1> onEventStreamCloudEventGroupCreatedPreviousObject1,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupCreatedPreviousObject2> onEventStreamCloudEventGroupCreatedPreviousObject2
    )
    {
        switch (Type)
        {
            case "eventStreamCloudEventGroupCreatedPreviousObject0":
                onEventStreamCloudEventGroupCreatedPreviousObject0(
                    AsEventStreamCloudEventGroupCreatedPreviousObject0()
                );
                break;
            case "eventStreamCloudEventGroupCreatedPreviousObject1":
                onEventStreamCloudEventGroupCreatedPreviousObject1(
                    AsEventStreamCloudEventGroupCreatedPreviousObject1()
                );
                break;
            case "eventStreamCloudEventGroupCreatedPreviousObject2":
                onEventStreamCloudEventGroupCreatedPreviousObject2(
                    AsEventStreamCloudEventGroupCreatedPreviousObject2()
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
        if (obj is not EventStreamCloudEventGroupCreatedPreviousObject other)
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

    public static implicit operator EventStreamCloudEventGroupCreatedPreviousObject(
        Auth0.ManagementApi.EventStreamCloudEventGroupCreatedPreviousObject0 value
    ) => new("eventStreamCloudEventGroupCreatedPreviousObject0", value);

    public static implicit operator EventStreamCloudEventGroupCreatedPreviousObject(
        Auth0.ManagementApi.EventStreamCloudEventGroupCreatedPreviousObject1 value
    ) => new("eventStreamCloudEventGroupCreatedPreviousObject1", value);

    public static implicit operator EventStreamCloudEventGroupCreatedPreviousObject(
        Auth0.ManagementApi.EventStreamCloudEventGroupCreatedPreviousObject2 value
    ) => new("eventStreamCloudEventGroupCreatedPreviousObject2", value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<EventStreamCloudEventGroupCreatedPreviousObject>
    {
        public override EventStreamCloudEventGroupCreatedPreviousObject? Read(
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
                        "eventStreamCloudEventGroupCreatedPreviousObject0",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupCreatedPreviousObject0)
                    ),
                    (
                        "eventStreamCloudEventGroupCreatedPreviousObject1",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupCreatedPreviousObject1)
                    ),
                    (
                        "eventStreamCloudEventGroupCreatedPreviousObject2",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupCreatedPreviousObject2)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamCloudEventGroupCreatedPreviousObject result = new(
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventGroupCreatedPreviousObject"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupCreatedPreviousObject value,
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

        public override EventStreamCloudEventGroupCreatedPreviousObject ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventGroupCreatedPreviousObject result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupCreatedPreviousObject value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
