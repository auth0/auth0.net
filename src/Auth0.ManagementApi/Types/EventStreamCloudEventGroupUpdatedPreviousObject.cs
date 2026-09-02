// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The event content as it was prior to the change described by this event, when applicable.
/// </summary>
[JsonConverter(typeof(EventStreamCloudEventGroupUpdatedPreviousObject.JsonConverter))]
[Serializable]
public class EventStreamCloudEventGroupUpdatedPreviousObject
{
    private EventStreamCloudEventGroupUpdatedPreviousObject(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedPreviousObject0 value.
    /// </summary>
    public static EventStreamCloudEventGroupUpdatedPreviousObject FromEventStreamCloudEventGroupUpdatedPreviousObject0(
        Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedPreviousObject0 value
    ) => new("eventStreamCloudEventGroupUpdatedPreviousObject0", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedPreviousObject1 value.
    /// </summary>
    public static EventStreamCloudEventGroupUpdatedPreviousObject FromEventStreamCloudEventGroupUpdatedPreviousObject1(
        Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedPreviousObject1 value
    ) => new("eventStreamCloudEventGroupUpdatedPreviousObject1", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedPreviousObject2 value.
    /// </summary>
    public static EventStreamCloudEventGroupUpdatedPreviousObject FromEventStreamCloudEventGroupUpdatedPreviousObject2(
        Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedPreviousObject2 value
    ) => new("eventStreamCloudEventGroupUpdatedPreviousObject2", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupUpdatedPreviousObject0"
    /// </summary>
    public bool IsEventStreamCloudEventGroupUpdatedPreviousObject0() =>
        Type == "eventStreamCloudEventGroupUpdatedPreviousObject0";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupUpdatedPreviousObject1"
    /// </summary>
    public bool IsEventStreamCloudEventGroupUpdatedPreviousObject1() =>
        Type == "eventStreamCloudEventGroupUpdatedPreviousObject1";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupUpdatedPreviousObject2"
    /// </summary>
    public bool IsEventStreamCloudEventGroupUpdatedPreviousObject2() =>
        Type == "eventStreamCloudEventGroupUpdatedPreviousObject2";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedPreviousObject0"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupUpdatedPreviousObject0', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupUpdatedPreviousObject0'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedPreviousObject0 AsEventStreamCloudEventGroupUpdatedPreviousObject0() =>
        IsEventStreamCloudEventGroupUpdatedPreviousObject0()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedPreviousObject0)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupUpdatedPreviousObject0'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedPreviousObject1"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupUpdatedPreviousObject1', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupUpdatedPreviousObject1'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedPreviousObject1 AsEventStreamCloudEventGroupUpdatedPreviousObject1() =>
        IsEventStreamCloudEventGroupUpdatedPreviousObject1()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedPreviousObject1)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupUpdatedPreviousObject1'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedPreviousObject2"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupUpdatedPreviousObject2', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupUpdatedPreviousObject2'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedPreviousObject2 AsEventStreamCloudEventGroupUpdatedPreviousObject2() =>
        IsEventStreamCloudEventGroupUpdatedPreviousObject2()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedPreviousObject2)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupUpdatedPreviousObject2'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedPreviousObject0"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupUpdatedPreviousObject0(
        out Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedPreviousObject0? value
    )
    {
        if (Type == "eventStreamCloudEventGroupUpdatedPreviousObject0")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedPreviousObject0)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedPreviousObject1"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupUpdatedPreviousObject1(
        out Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedPreviousObject1? value
    )
    {
        if (Type == "eventStreamCloudEventGroupUpdatedPreviousObject1")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedPreviousObject1)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedPreviousObject2"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupUpdatedPreviousObject2(
        out Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedPreviousObject2? value
    )
    {
        if (Type == "eventStreamCloudEventGroupUpdatedPreviousObject2")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedPreviousObject2)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedPreviousObject0,
            T
        > onEventStreamCloudEventGroupUpdatedPreviousObject0,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedPreviousObject1,
            T
        > onEventStreamCloudEventGroupUpdatedPreviousObject1,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedPreviousObject2,
            T
        > onEventStreamCloudEventGroupUpdatedPreviousObject2
    )
    {
        return Type switch
        {
            "eventStreamCloudEventGroupUpdatedPreviousObject0" =>
                onEventStreamCloudEventGroupUpdatedPreviousObject0(
                    AsEventStreamCloudEventGroupUpdatedPreviousObject0()
                ),
            "eventStreamCloudEventGroupUpdatedPreviousObject1" =>
                onEventStreamCloudEventGroupUpdatedPreviousObject1(
                    AsEventStreamCloudEventGroupUpdatedPreviousObject1()
                ),
            "eventStreamCloudEventGroupUpdatedPreviousObject2" =>
                onEventStreamCloudEventGroupUpdatedPreviousObject2(
                    AsEventStreamCloudEventGroupUpdatedPreviousObject2()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedPreviousObject0> onEventStreamCloudEventGroupUpdatedPreviousObject0,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedPreviousObject1> onEventStreamCloudEventGroupUpdatedPreviousObject1,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedPreviousObject2> onEventStreamCloudEventGroupUpdatedPreviousObject2
    )
    {
        switch (Type)
        {
            case "eventStreamCloudEventGroupUpdatedPreviousObject0":
                onEventStreamCloudEventGroupUpdatedPreviousObject0(
                    AsEventStreamCloudEventGroupUpdatedPreviousObject0()
                );
                break;
            case "eventStreamCloudEventGroupUpdatedPreviousObject1":
                onEventStreamCloudEventGroupUpdatedPreviousObject1(
                    AsEventStreamCloudEventGroupUpdatedPreviousObject1()
                );
                break;
            case "eventStreamCloudEventGroupUpdatedPreviousObject2":
                onEventStreamCloudEventGroupUpdatedPreviousObject2(
                    AsEventStreamCloudEventGroupUpdatedPreviousObject2()
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
        if (obj is not EventStreamCloudEventGroupUpdatedPreviousObject other)
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

    public static implicit operator EventStreamCloudEventGroupUpdatedPreviousObject(
        Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedPreviousObject0 value
    ) => new("eventStreamCloudEventGroupUpdatedPreviousObject0", value);

    public static implicit operator EventStreamCloudEventGroupUpdatedPreviousObject(
        Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedPreviousObject1 value
    ) => new("eventStreamCloudEventGroupUpdatedPreviousObject1", value);

    public static implicit operator EventStreamCloudEventGroupUpdatedPreviousObject(
        Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedPreviousObject2 value
    ) => new("eventStreamCloudEventGroupUpdatedPreviousObject2", value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<EventStreamCloudEventGroupUpdatedPreviousObject>
    {
        public override EventStreamCloudEventGroupUpdatedPreviousObject? Read(
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
                        "eventStreamCloudEventGroupUpdatedPreviousObject0",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedPreviousObject0)
                    ),
                    (
                        "eventStreamCloudEventGroupUpdatedPreviousObject1",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedPreviousObject1)
                    ),
                    (
                        "eventStreamCloudEventGroupUpdatedPreviousObject2",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedPreviousObject2)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamCloudEventGroupUpdatedPreviousObject result = new(
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventGroupUpdatedPreviousObject"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupUpdatedPreviousObject value,
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

        public override EventStreamCloudEventGroupUpdatedPreviousObject ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventGroupUpdatedPreviousObject result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupUpdatedPreviousObject value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
