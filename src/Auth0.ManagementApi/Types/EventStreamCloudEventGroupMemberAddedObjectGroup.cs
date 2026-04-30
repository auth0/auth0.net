// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The group the member belongs to.
/// </summary>
[JsonConverter(typeof(EventStreamCloudEventGroupMemberAddedObjectGroup.JsonConverter))]
[Serializable]
public class EventStreamCloudEventGroupMemberAddedObjectGroup
{
    private EventStreamCloudEventGroupMemberAddedObjectGroup(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectGroup0 value.
    /// </summary>
    public static EventStreamCloudEventGroupMemberAddedObjectGroup FromEventStreamCloudEventGroupMemberAddedObjectGroup0(
        Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectGroup0 value
    ) => new("eventStreamCloudEventGroupMemberAddedObjectGroup0", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectGroup1 value.
    /// </summary>
    public static EventStreamCloudEventGroupMemberAddedObjectGroup FromEventStreamCloudEventGroupMemberAddedObjectGroup1(
        Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectGroup1 value
    ) => new("eventStreamCloudEventGroupMemberAddedObjectGroup1", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectGroup2 value.
    /// </summary>
    public static EventStreamCloudEventGroupMemberAddedObjectGroup FromEventStreamCloudEventGroupMemberAddedObjectGroup2(
        Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectGroup2 value
    ) => new("eventStreamCloudEventGroupMemberAddedObjectGroup2", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupMemberAddedObjectGroup0"
    /// </summary>
    public bool IsEventStreamCloudEventGroupMemberAddedObjectGroup0() =>
        Type == "eventStreamCloudEventGroupMemberAddedObjectGroup0";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupMemberAddedObjectGroup1"
    /// </summary>
    public bool IsEventStreamCloudEventGroupMemberAddedObjectGroup1() =>
        Type == "eventStreamCloudEventGroupMemberAddedObjectGroup1";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupMemberAddedObjectGroup2"
    /// </summary>
    public bool IsEventStreamCloudEventGroupMemberAddedObjectGroup2() =>
        Type == "eventStreamCloudEventGroupMemberAddedObjectGroup2";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectGroup0"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupMemberAddedObjectGroup0', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupMemberAddedObjectGroup0'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectGroup0 AsEventStreamCloudEventGroupMemberAddedObjectGroup0() =>
        IsEventStreamCloudEventGroupMemberAddedObjectGroup0()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectGroup0)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupMemberAddedObjectGroup0'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectGroup1"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupMemberAddedObjectGroup1', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupMemberAddedObjectGroup1'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectGroup1 AsEventStreamCloudEventGroupMemberAddedObjectGroup1() =>
        IsEventStreamCloudEventGroupMemberAddedObjectGroup1()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectGroup1)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupMemberAddedObjectGroup1'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectGroup2"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupMemberAddedObjectGroup2', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupMemberAddedObjectGroup2'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectGroup2 AsEventStreamCloudEventGroupMemberAddedObjectGroup2() =>
        IsEventStreamCloudEventGroupMemberAddedObjectGroup2()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectGroup2)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupMemberAddedObjectGroup2'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectGroup0"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupMemberAddedObjectGroup0(
        out Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectGroup0? value
    )
    {
        if (Type == "eventStreamCloudEventGroupMemberAddedObjectGroup0")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectGroup0)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectGroup1"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupMemberAddedObjectGroup1(
        out Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectGroup1? value
    )
    {
        if (Type == "eventStreamCloudEventGroupMemberAddedObjectGroup1")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectGroup1)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectGroup2"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupMemberAddedObjectGroup2(
        out Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectGroup2? value
    )
    {
        if (Type == "eventStreamCloudEventGroupMemberAddedObjectGroup2")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectGroup2)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectGroup0,
            T
        > onEventStreamCloudEventGroupMemberAddedObjectGroup0,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectGroup1,
            T
        > onEventStreamCloudEventGroupMemberAddedObjectGroup1,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectGroup2,
            T
        > onEventStreamCloudEventGroupMemberAddedObjectGroup2
    )
    {
        return Type switch
        {
            "eventStreamCloudEventGroupMemberAddedObjectGroup0" =>
                onEventStreamCloudEventGroupMemberAddedObjectGroup0(
                    AsEventStreamCloudEventGroupMemberAddedObjectGroup0()
                ),
            "eventStreamCloudEventGroupMemberAddedObjectGroup1" =>
                onEventStreamCloudEventGroupMemberAddedObjectGroup1(
                    AsEventStreamCloudEventGroupMemberAddedObjectGroup1()
                ),
            "eventStreamCloudEventGroupMemberAddedObjectGroup2" =>
                onEventStreamCloudEventGroupMemberAddedObjectGroup2(
                    AsEventStreamCloudEventGroupMemberAddedObjectGroup2()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectGroup0> onEventStreamCloudEventGroupMemberAddedObjectGroup0,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectGroup1> onEventStreamCloudEventGroupMemberAddedObjectGroup1,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectGroup2> onEventStreamCloudEventGroupMemberAddedObjectGroup2
    )
    {
        switch (Type)
        {
            case "eventStreamCloudEventGroupMemberAddedObjectGroup0":
                onEventStreamCloudEventGroupMemberAddedObjectGroup0(
                    AsEventStreamCloudEventGroupMemberAddedObjectGroup0()
                );
                break;
            case "eventStreamCloudEventGroupMemberAddedObjectGroup1":
                onEventStreamCloudEventGroupMemberAddedObjectGroup1(
                    AsEventStreamCloudEventGroupMemberAddedObjectGroup1()
                );
                break;
            case "eventStreamCloudEventGroupMemberAddedObjectGroup2":
                onEventStreamCloudEventGroupMemberAddedObjectGroup2(
                    AsEventStreamCloudEventGroupMemberAddedObjectGroup2()
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
        if (obj is not EventStreamCloudEventGroupMemberAddedObjectGroup other)
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

    public static implicit operator EventStreamCloudEventGroupMemberAddedObjectGroup(
        Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectGroup0 value
    ) => new("eventStreamCloudEventGroupMemberAddedObjectGroup0", value);

    public static implicit operator EventStreamCloudEventGroupMemberAddedObjectGroup(
        Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectGroup1 value
    ) => new("eventStreamCloudEventGroupMemberAddedObjectGroup1", value);

    public static implicit operator EventStreamCloudEventGroupMemberAddedObjectGroup(
        Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectGroup2 value
    ) => new("eventStreamCloudEventGroupMemberAddedObjectGroup2", value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<EventStreamCloudEventGroupMemberAddedObjectGroup>
    {
        public override EventStreamCloudEventGroupMemberAddedObjectGroup? Read(
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
                        "eventStreamCloudEventGroupMemberAddedObjectGroup0",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectGroup0)
                    ),
                    (
                        "eventStreamCloudEventGroupMemberAddedObjectGroup1",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectGroup1)
                    ),
                    (
                        "eventStreamCloudEventGroupMemberAddedObjectGroup2",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectGroup2)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamCloudEventGroupMemberAddedObjectGroup result = new(
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventGroupMemberAddedObjectGroup"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupMemberAddedObjectGroup value,
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

        public override EventStreamCloudEventGroupMemberAddedObjectGroup ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventGroupMemberAddedObjectGroup result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupMemberAddedObjectGroup value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
