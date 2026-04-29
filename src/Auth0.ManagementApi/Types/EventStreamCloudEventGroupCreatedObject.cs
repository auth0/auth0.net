// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The event content.
/// </summary>
[JsonConverter(typeof(EventStreamCloudEventGroupCreatedObject.JsonConverter))]
[Serializable]
public class EventStreamCloudEventGroupCreatedObject
{
    private EventStreamCloudEventGroupCreatedObject(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupCreatedObject0 value.
    /// </summary>
    public static EventStreamCloudEventGroupCreatedObject FromEventStreamCloudEventGroupCreatedObject0(
        Auth0.ManagementApi.EventStreamCloudEventGroupCreatedObject0 value
    ) => new("eventStreamCloudEventGroupCreatedObject0", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupCreatedObject1 value.
    /// </summary>
    public static EventStreamCloudEventGroupCreatedObject FromEventStreamCloudEventGroupCreatedObject1(
        Auth0.ManagementApi.EventStreamCloudEventGroupCreatedObject1 value
    ) => new("eventStreamCloudEventGroupCreatedObject1", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupCreatedObject2 value.
    /// </summary>
    public static EventStreamCloudEventGroupCreatedObject FromEventStreamCloudEventGroupCreatedObject2(
        Auth0.ManagementApi.EventStreamCloudEventGroupCreatedObject2 value
    ) => new("eventStreamCloudEventGroupCreatedObject2", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupCreatedObject0"
    /// </summary>
    public bool IsEventStreamCloudEventGroupCreatedObject0() =>
        Type == "eventStreamCloudEventGroupCreatedObject0";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupCreatedObject1"
    /// </summary>
    public bool IsEventStreamCloudEventGroupCreatedObject1() =>
        Type == "eventStreamCloudEventGroupCreatedObject1";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupCreatedObject2"
    /// </summary>
    public bool IsEventStreamCloudEventGroupCreatedObject2() =>
        Type == "eventStreamCloudEventGroupCreatedObject2";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupCreatedObject0"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupCreatedObject0', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupCreatedObject0'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupCreatedObject0 AsEventStreamCloudEventGroupCreatedObject0() =>
        IsEventStreamCloudEventGroupCreatedObject0()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupCreatedObject0)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupCreatedObject0'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupCreatedObject1"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupCreatedObject1', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupCreatedObject1'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupCreatedObject1 AsEventStreamCloudEventGroupCreatedObject1() =>
        IsEventStreamCloudEventGroupCreatedObject1()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupCreatedObject1)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupCreatedObject1'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupCreatedObject2"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupCreatedObject2', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupCreatedObject2'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupCreatedObject2 AsEventStreamCloudEventGroupCreatedObject2() =>
        IsEventStreamCloudEventGroupCreatedObject2()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupCreatedObject2)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupCreatedObject2'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupCreatedObject0"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupCreatedObject0(
        out Auth0.ManagementApi.EventStreamCloudEventGroupCreatedObject0? value
    )
    {
        if (Type == "eventStreamCloudEventGroupCreatedObject0")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupCreatedObject0)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupCreatedObject1"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupCreatedObject1(
        out Auth0.ManagementApi.EventStreamCloudEventGroupCreatedObject1? value
    )
    {
        if (Type == "eventStreamCloudEventGroupCreatedObject1")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupCreatedObject1)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupCreatedObject2"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupCreatedObject2(
        out Auth0.ManagementApi.EventStreamCloudEventGroupCreatedObject2? value
    )
    {
        if (Type == "eventStreamCloudEventGroupCreatedObject2")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupCreatedObject2)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupCreatedObject0,
            T
        > onEventStreamCloudEventGroupCreatedObject0,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupCreatedObject1,
            T
        > onEventStreamCloudEventGroupCreatedObject1,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupCreatedObject2,
            T
        > onEventStreamCloudEventGroupCreatedObject2
    )
    {
        return Type switch
        {
            "eventStreamCloudEventGroupCreatedObject0" =>
                onEventStreamCloudEventGroupCreatedObject0(
                    AsEventStreamCloudEventGroupCreatedObject0()
                ),
            "eventStreamCloudEventGroupCreatedObject1" =>
                onEventStreamCloudEventGroupCreatedObject1(
                    AsEventStreamCloudEventGroupCreatedObject1()
                ),
            "eventStreamCloudEventGroupCreatedObject2" =>
                onEventStreamCloudEventGroupCreatedObject2(
                    AsEventStreamCloudEventGroupCreatedObject2()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupCreatedObject0> onEventStreamCloudEventGroupCreatedObject0,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupCreatedObject1> onEventStreamCloudEventGroupCreatedObject1,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupCreatedObject2> onEventStreamCloudEventGroupCreatedObject2
    )
    {
        switch (Type)
        {
            case "eventStreamCloudEventGroupCreatedObject0":
                onEventStreamCloudEventGroupCreatedObject0(
                    AsEventStreamCloudEventGroupCreatedObject0()
                );
                break;
            case "eventStreamCloudEventGroupCreatedObject1":
                onEventStreamCloudEventGroupCreatedObject1(
                    AsEventStreamCloudEventGroupCreatedObject1()
                );
                break;
            case "eventStreamCloudEventGroupCreatedObject2":
                onEventStreamCloudEventGroupCreatedObject2(
                    AsEventStreamCloudEventGroupCreatedObject2()
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
        if (obj is not EventStreamCloudEventGroupCreatedObject other)
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

    public static implicit operator EventStreamCloudEventGroupCreatedObject(
        Auth0.ManagementApi.EventStreamCloudEventGroupCreatedObject0 value
    ) => new("eventStreamCloudEventGroupCreatedObject0", value);

    public static implicit operator EventStreamCloudEventGroupCreatedObject(
        Auth0.ManagementApi.EventStreamCloudEventGroupCreatedObject1 value
    ) => new("eventStreamCloudEventGroupCreatedObject1", value);

    public static implicit operator EventStreamCloudEventGroupCreatedObject(
        Auth0.ManagementApi.EventStreamCloudEventGroupCreatedObject2 value
    ) => new("eventStreamCloudEventGroupCreatedObject2", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<EventStreamCloudEventGroupCreatedObject>
    {
        public override EventStreamCloudEventGroupCreatedObject? Read(
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
                        "eventStreamCloudEventGroupCreatedObject0",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupCreatedObject0)
                    ),
                    (
                        "eventStreamCloudEventGroupCreatedObject1",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupCreatedObject1)
                    ),
                    (
                        "eventStreamCloudEventGroupCreatedObject2",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupCreatedObject2)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamCloudEventGroupCreatedObject result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventGroupCreatedObject"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupCreatedObject value,
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

        public override EventStreamCloudEventGroupCreatedObject ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventGroupCreatedObject result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupCreatedObject value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
