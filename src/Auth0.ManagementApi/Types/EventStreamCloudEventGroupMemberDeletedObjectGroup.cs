// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The group the member belongs to.
/// </summary>
[JsonConverter(typeof(EventStreamCloudEventGroupMemberDeletedObjectGroup.JsonConverter))]
[Serializable]
public class EventStreamCloudEventGroupMemberDeletedObjectGroup
{
    private EventStreamCloudEventGroupMemberDeletedObjectGroup(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectGroup0 value.
    /// </summary>
    public static EventStreamCloudEventGroupMemberDeletedObjectGroup FromEventStreamCloudEventGroupMemberDeletedObjectGroup0(
        Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectGroup0 value
    ) => new("eventStreamCloudEventGroupMemberDeletedObjectGroup0", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectGroup1 value.
    /// </summary>
    public static EventStreamCloudEventGroupMemberDeletedObjectGroup FromEventStreamCloudEventGroupMemberDeletedObjectGroup1(
        Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectGroup1 value
    ) => new("eventStreamCloudEventGroupMemberDeletedObjectGroup1", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectGroup2 value.
    /// </summary>
    public static EventStreamCloudEventGroupMemberDeletedObjectGroup FromEventStreamCloudEventGroupMemberDeletedObjectGroup2(
        Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectGroup2 value
    ) => new("eventStreamCloudEventGroupMemberDeletedObjectGroup2", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupMemberDeletedObjectGroup0"
    /// </summary>
    public bool IsEventStreamCloudEventGroupMemberDeletedObjectGroup0() =>
        Type == "eventStreamCloudEventGroupMemberDeletedObjectGroup0";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupMemberDeletedObjectGroup1"
    /// </summary>
    public bool IsEventStreamCloudEventGroupMemberDeletedObjectGroup1() =>
        Type == "eventStreamCloudEventGroupMemberDeletedObjectGroup1";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupMemberDeletedObjectGroup2"
    /// </summary>
    public bool IsEventStreamCloudEventGroupMemberDeletedObjectGroup2() =>
        Type == "eventStreamCloudEventGroupMemberDeletedObjectGroup2";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectGroup0"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupMemberDeletedObjectGroup0', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupMemberDeletedObjectGroup0'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectGroup0 AsEventStreamCloudEventGroupMemberDeletedObjectGroup0() =>
        IsEventStreamCloudEventGroupMemberDeletedObjectGroup0()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectGroup0)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupMemberDeletedObjectGroup0'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectGroup1"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupMemberDeletedObjectGroup1', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupMemberDeletedObjectGroup1'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectGroup1 AsEventStreamCloudEventGroupMemberDeletedObjectGroup1() =>
        IsEventStreamCloudEventGroupMemberDeletedObjectGroup1()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectGroup1)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupMemberDeletedObjectGroup1'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectGroup2"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupMemberDeletedObjectGroup2', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupMemberDeletedObjectGroup2'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectGroup2 AsEventStreamCloudEventGroupMemberDeletedObjectGroup2() =>
        IsEventStreamCloudEventGroupMemberDeletedObjectGroup2()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectGroup2)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupMemberDeletedObjectGroup2'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectGroup0"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupMemberDeletedObjectGroup0(
        out Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectGroup0? value
    )
    {
        if (Type == "eventStreamCloudEventGroupMemberDeletedObjectGroup0")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectGroup0)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectGroup1"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupMemberDeletedObjectGroup1(
        out Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectGroup1? value
    )
    {
        if (Type == "eventStreamCloudEventGroupMemberDeletedObjectGroup1")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectGroup1)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectGroup2"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupMemberDeletedObjectGroup2(
        out Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectGroup2? value
    )
    {
        if (Type == "eventStreamCloudEventGroupMemberDeletedObjectGroup2")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectGroup2)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectGroup0,
            T
        > onEventStreamCloudEventGroupMemberDeletedObjectGroup0,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectGroup1,
            T
        > onEventStreamCloudEventGroupMemberDeletedObjectGroup1,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectGroup2,
            T
        > onEventStreamCloudEventGroupMemberDeletedObjectGroup2
    )
    {
        return Type switch
        {
            "eventStreamCloudEventGroupMemberDeletedObjectGroup0" =>
                onEventStreamCloudEventGroupMemberDeletedObjectGroup0(
                    AsEventStreamCloudEventGroupMemberDeletedObjectGroup0()
                ),
            "eventStreamCloudEventGroupMemberDeletedObjectGroup1" =>
                onEventStreamCloudEventGroupMemberDeletedObjectGroup1(
                    AsEventStreamCloudEventGroupMemberDeletedObjectGroup1()
                ),
            "eventStreamCloudEventGroupMemberDeletedObjectGroup2" =>
                onEventStreamCloudEventGroupMemberDeletedObjectGroup2(
                    AsEventStreamCloudEventGroupMemberDeletedObjectGroup2()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectGroup0> onEventStreamCloudEventGroupMemberDeletedObjectGroup0,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectGroup1> onEventStreamCloudEventGroupMemberDeletedObjectGroup1,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectGroup2> onEventStreamCloudEventGroupMemberDeletedObjectGroup2
    )
    {
        switch (Type)
        {
            case "eventStreamCloudEventGroupMemberDeletedObjectGroup0":
                onEventStreamCloudEventGroupMemberDeletedObjectGroup0(
                    AsEventStreamCloudEventGroupMemberDeletedObjectGroup0()
                );
                break;
            case "eventStreamCloudEventGroupMemberDeletedObjectGroup1":
                onEventStreamCloudEventGroupMemberDeletedObjectGroup1(
                    AsEventStreamCloudEventGroupMemberDeletedObjectGroup1()
                );
                break;
            case "eventStreamCloudEventGroupMemberDeletedObjectGroup2":
                onEventStreamCloudEventGroupMemberDeletedObjectGroup2(
                    AsEventStreamCloudEventGroupMemberDeletedObjectGroup2()
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
        if (obj is not EventStreamCloudEventGroupMemberDeletedObjectGroup other)
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

    public static implicit operator EventStreamCloudEventGroupMemberDeletedObjectGroup(
        Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectGroup0 value
    ) => new("eventStreamCloudEventGroupMemberDeletedObjectGroup0", value);

    public static implicit operator EventStreamCloudEventGroupMemberDeletedObjectGroup(
        Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectGroup1 value
    ) => new("eventStreamCloudEventGroupMemberDeletedObjectGroup1", value);

    public static implicit operator EventStreamCloudEventGroupMemberDeletedObjectGroup(
        Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectGroup2 value
    ) => new("eventStreamCloudEventGroupMemberDeletedObjectGroup2", value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<EventStreamCloudEventGroupMemberDeletedObjectGroup>
    {
        public override EventStreamCloudEventGroupMemberDeletedObjectGroup? Read(
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
                        "eventStreamCloudEventGroupMemberDeletedObjectGroup0",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectGroup0)
                    ),
                    (
                        "eventStreamCloudEventGroupMemberDeletedObjectGroup1",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectGroup1)
                    ),
                    (
                        "eventStreamCloudEventGroupMemberDeletedObjectGroup2",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectGroup2)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamCloudEventGroupMemberDeletedObjectGroup result = new(
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventGroupMemberDeletedObjectGroup"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupMemberDeletedObjectGroup value,
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

        public override EventStreamCloudEventGroupMemberDeletedObjectGroup ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventGroupMemberDeletedObjectGroup result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupMemberDeletedObjectGroup value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
