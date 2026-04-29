// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The event content.
/// </summary>
[JsonConverter(typeof(EventStreamCloudEventGroupDeletedObject.JsonConverter))]
[Serializable]
public class EventStreamCloudEventGroupDeletedObject
{
    private EventStreamCloudEventGroupDeletedObject(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupDeletedObject0 value.
    /// </summary>
    public static EventStreamCloudEventGroupDeletedObject FromEventStreamCloudEventGroupDeletedObject0(
        Auth0.ManagementApi.EventStreamCloudEventGroupDeletedObject0 value
    ) => new("eventStreamCloudEventGroupDeletedObject0", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupDeletedObject1 value.
    /// </summary>
    public static EventStreamCloudEventGroupDeletedObject FromEventStreamCloudEventGroupDeletedObject1(
        Auth0.ManagementApi.EventStreamCloudEventGroupDeletedObject1 value
    ) => new("eventStreamCloudEventGroupDeletedObject1", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupDeletedObject2 value.
    /// </summary>
    public static EventStreamCloudEventGroupDeletedObject FromEventStreamCloudEventGroupDeletedObject2(
        Auth0.ManagementApi.EventStreamCloudEventGroupDeletedObject2 value
    ) => new("eventStreamCloudEventGroupDeletedObject2", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupDeletedObject0"
    /// </summary>
    public bool IsEventStreamCloudEventGroupDeletedObject0() =>
        Type == "eventStreamCloudEventGroupDeletedObject0";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupDeletedObject1"
    /// </summary>
    public bool IsEventStreamCloudEventGroupDeletedObject1() =>
        Type == "eventStreamCloudEventGroupDeletedObject1";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupDeletedObject2"
    /// </summary>
    public bool IsEventStreamCloudEventGroupDeletedObject2() =>
        Type == "eventStreamCloudEventGroupDeletedObject2";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupDeletedObject0"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupDeletedObject0', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupDeletedObject0'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupDeletedObject0 AsEventStreamCloudEventGroupDeletedObject0() =>
        IsEventStreamCloudEventGroupDeletedObject0()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupDeletedObject0)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupDeletedObject0'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupDeletedObject1"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupDeletedObject1', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupDeletedObject1'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupDeletedObject1 AsEventStreamCloudEventGroupDeletedObject1() =>
        IsEventStreamCloudEventGroupDeletedObject1()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupDeletedObject1)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupDeletedObject1'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupDeletedObject2"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupDeletedObject2', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupDeletedObject2'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupDeletedObject2 AsEventStreamCloudEventGroupDeletedObject2() =>
        IsEventStreamCloudEventGroupDeletedObject2()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupDeletedObject2)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupDeletedObject2'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupDeletedObject0"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupDeletedObject0(
        out Auth0.ManagementApi.EventStreamCloudEventGroupDeletedObject0? value
    )
    {
        if (Type == "eventStreamCloudEventGroupDeletedObject0")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupDeletedObject0)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupDeletedObject1"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupDeletedObject1(
        out Auth0.ManagementApi.EventStreamCloudEventGroupDeletedObject1? value
    )
    {
        if (Type == "eventStreamCloudEventGroupDeletedObject1")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupDeletedObject1)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupDeletedObject2"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupDeletedObject2(
        out Auth0.ManagementApi.EventStreamCloudEventGroupDeletedObject2? value
    )
    {
        if (Type == "eventStreamCloudEventGroupDeletedObject2")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupDeletedObject2)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupDeletedObject0,
            T
        > onEventStreamCloudEventGroupDeletedObject0,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupDeletedObject1,
            T
        > onEventStreamCloudEventGroupDeletedObject1,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupDeletedObject2,
            T
        > onEventStreamCloudEventGroupDeletedObject2
    )
    {
        return Type switch
        {
            "eventStreamCloudEventGroupDeletedObject0" =>
                onEventStreamCloudEventGroupDeletedObject0(
                    AsEventStreamCloudEventGroupDeletedObject0()
                ),
            "eventStreamCloudEventGroupDeletedObject1" =>
                onEventStreamCloudEventGroupDeletedObject1(
                    AsEventStreamCloudEventGroupDeletedObject1()
                ),
            "eventStreamCloudEventGroupDeletedObject2" =>
                onEventStreamCloudEventGroupDeletedObject2(
                    AsEventStreamCloudEventGroupDeletedObject2()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupDeletedObject0> onEventStreamCloudEventGroupDeletedObject0,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupDeletedObject1> onEventStreamCloudEventGroupDeletedObject1,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupDeletedObject2> onEventStreamCloudEventGroupDeletedObject2
    )
    {
        switch (Type)
        {
            case "eventStreamCloudEventGroupDeletedObject0":
                onEventStreamCloudEventGroupDeletedObject0(
                    AsEventStreamCloudEventGroupDeletedObject0()
                );
                break;
            case "eventStreamCloudEventGroupDeletedObject1":
                onEventStreamCloudEventGroupDeletedObject1(
                    AsEventStreamCloudEventGroupDeletedObject1()
                );
                break;
            case "eventStreamCloudEventGroupDeletedObject2":
                onEventStreamCloudEventGroupDeletedObject2(
                    AsEventStreamCloudEventGroupDeletedObject2()
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
        if (obj is not EventStreamCloudEventGroupDeletedObject other)
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

    public static implicit operator EventStreamCloudEventGroupDeletedObject(
        Auth0.ManagementApi.EventStreamCloudEventGroupDeletedObject0 value
    ) => new("eventStreamCloudEventGroupDeletedObject0", value);

    public static implicit operator EventStreamCloudEventGroupDeletedObject(
        Auth0.ManagementApi.EventStreamCloudEventGroupDeletedObject1 value
    ) => new("eventStreamCloudEventGroupDeletedObject1", value);

    public static implicit operator EventStreamCloudEventGroupDeletedObject(
        Auth0.ManagementApi.EventStreamCloudEventGroupDeletedObject2 value
    ) => new("eventStreamCloudEventGroupDeletedObject2", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<EventStreamCloudEventGroupDeletedObject>
    {
        public override EventStreamCloudEventGroupDeletedObject? Read(
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
                        "eventStreamCloudEventGroupDeletedObject0",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupDeletedObject0)
                    ),
                    (
                        "eventStreamCloudEventGroupDeletedObject1",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupDeletedObject1)
                    ),
                    (
                        "eventStreamCloudEventGroupDeletedObject2",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupDeletedObject2)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamCloudEventGroupDeletedObject result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventGroupDeletedObject"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupDeletedObject value,
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

        public override EventStreamCloudEventGroupDeletedObject ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventGroupDeletedObject result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupDeletedObject value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
