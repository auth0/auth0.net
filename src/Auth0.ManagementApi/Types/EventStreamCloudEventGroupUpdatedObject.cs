// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The event content.
/// </summary>
[JsonConverter(typeof(EventStreamCloudEventGroupUpdatedObject.JsonConverter))]
[Serializable]
public class EventStreamCloudEventGroupUpdatedObject
{
    private EventStreamCloudEventGroupUpdatedObject(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedObject0 value.
    /// </summary>
    public static EventStreamCloudEventGroupUpdatedObject FromEventStreamCloudEventGroupUpdatedObject0(
        Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedObject0 value
    ) => new("eventStreamCloudEventGroupUpdatedObject0", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedObject1 value.
    /// </summary>
    public static EventStreamCloudEventGroupUpdatedObject FromEventStreamCloudEventGroupUpdatedObject1(
        Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedObject1 value
    ) => new("eventStreamCloudEventGroupUpdatedObject1", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedObject2 value.
    /// </summary>
    public static EventStreamCloudEventGroupUpdatedObject FromEventStreamCloudEventGroupUpdatedObject2(
        Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedObject2 value
    ) => new("eventStreamCloudEventGroupUpdatedObject2", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupUpdatedObject0"
    /// </summary>
    public bool IsEventStreamCloudEventGroupUpdatedObject0() =>
        Type == "eventStreamCloudEventGroupUpdatedObject0";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupUpdatedObject1"
    /// </summary>
    public bool IsEventStreamCloudEventGroupUpdatedObject1() =>
        Type == "eventStreamCloudEventGroupUpdatedObject1";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupUpdatedObject2"
    /// </summary>
    public bool IsEventStreamCloudEventGroupUpdatedObject2() =>
        Type == "eventStreamCloudEventGroupUpdatedObject2";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedObject0"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupUpdatedObject0', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupUpdatedObject0'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedObject0 AsEventStreamCloudEventGroupUpdatedObject0() =>
        IsEventStreamCloudEventGroupUpdatedObject0()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedObject0)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupUpdatedObject0'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedObject1"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupUpdatedObject1', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupUpdatedObject1'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedObject1 AsEventStreamCloudEventGroupUpdatedObject1() =>
        IsEventStreamCloudEventGroupUpdatedObject1()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedObject1)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupUpdatedObject1'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedObject2"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupUpdatedObject2', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupUpdatedObject2'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedObject2 AsEventStreamCloudEventGroupUpdatedObject2() =>
        IsEventStreamCloudEventGroupUpdatedObject2()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedObject2)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupUpdatedObject2'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedObject0"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupUpdatedObject0(
        out Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedObject0? value
    )
    {
        if (Type == "eventStreamCloudEventGroupUpdatedObject0")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedObject0)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedObject1"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupUpdatedObject1(
        out Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedObject1? value
    )
    {
        if (Type == "eventStreamCloudEventGroupUpdatedObject1")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedObject1)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedObject2"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupUpdatedObject2(
        out Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedObject2? value
    )
    {
        if (Type == "eventStreamCloudEventGroupUpdatedObject2")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedObject2)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedObject0,
            T
        > onEventStreamCloudEventGroupUpdatedObject0,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedObject1,
            T
        > onEventStreamCloudEventGroupUpdatedObject1,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedObject2,
            T
        > onEventStreamCloudEventGroupUpdatedObject2
    )
    {
        return Type switch
        {
            "eventStreamCloudEventGroupUpdatedObject0" =>
                onEventStreamCloudEventGroupUpdatedObject0(
                    AsEventStreamCloudEventGroupUpdatedObject0()
                ),
            "eventStreamCloudEventGroupUpdatedObject1" =>
                onEventStreamCloudEventGroupUpdatedObject1(
                    AsEventStreamCloudEventGroupUpdatedObject1()
                ),
            "eventStreamCloudEventGroupUpdatedObject2" =>
                onEventStreamCloudEventGroupUpdatedObject2(
                    AsEventStreamCloudEventGroupUpdatedObject2()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedObject0> onEventStreamCloudEventGroupUpdatedObject0,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedObject1> onEventStreamCloudEventGroupUpdatedObject1,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedObject2> onEventStreamCloudEventGroupUpdatedObject2
    )
    {
        switch (Type)
        {
            case "eventStreamCloudEventGroupUpdatedObject0":
                onEventStreamCloudEventGroupUpdatedObject0(
                    AsEventStreamCloudEventGroupUpdatedObject0()
                );
                break;
            case "eventStreamCloudEventGroupUpdatedObject1":
                onEventStreamCloudEventGroupUpdatedObject1(
                    AsEventStreamCloudEventGroupUpdatedObject1()
                );
                break;
            case "eventStreamCloudEventGroupUpdatedObject2":
                onEventStreamCloudEventGroupUpdatedObject2(
                    AsEventStreamCloudEventGroupUpdatedObject2()
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
        if (obj is not EventStreamCloudEventGroupUpdatedObject other)
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

    public static implicit operator EventStreamCloudEventGroupUpdatedObject(
        Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedObject0 value
    ) => new("eventStreamCloudEventGroupUpdatedObject0", value);

    public static implicit operator EventStreamCloudEventGroupUpdatedObject(
        Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedObject1 value
    ) => new("eventStreamCloudEventGroupUpdatedObject1", value);

    public static implicit operator EventStreamCloudEventGroupUpdatedObject(
        Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedObject2 value
    ) => new("eventStreamCloudEventGroupUpdatedObject2", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<EventStreamCloudEventGroupUpdatedObject>
    {
        public override EventStreamCloudEventGroupUpdatedObject? Read(
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
                        "eventStreamCloudEventGroupUpdatedObject0",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedObject0)
                    ),
                    (
                        "eventStreamCloudEventGroupUpdatedObject1",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedObject1)
                    ),
                    (
                        "eventStreamCloudEventGroupUpdatedObject2",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupUpdatedObject2)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamCloudEventGroupUpdatedObject result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventGroupUpdatedObject"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupUpdatedObject value,
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

        public override EventStreamCloudEventGroupUpdatedObject ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventGroupUpdatedObject result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupUpdatedObject value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
