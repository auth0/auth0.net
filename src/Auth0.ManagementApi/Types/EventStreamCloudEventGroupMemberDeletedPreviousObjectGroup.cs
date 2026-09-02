// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The group the member belongs to.
/// </summary>
[JsonConverter(typeof(EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup.JsonConverter))]
[Serializable]
public class EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup
{
    private EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup0 value.
    /// </summary>
    public static EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup FromEventStreamCloudEventGroupMemberDeletedPreviousObjectGroup0(
        Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup0 value
    ) => new("eventStreamCloudEventGroupMemberDeletedPreviousObjectGroup0", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup1 value.
    /// </summary>
    public static EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup FromEventStreamCloudEventGroupMemberDeletedPreviousObjectGroup1(
        Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup1 value
    ) => new("eventStreamCloudEventGroupMemberDeletedPreviousObjectGroup1", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup2 value.
    /// </summary>
    public static EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup FromEventStreamCloudEventGroupMemberDeletedPreviousObjectGroup2(
        Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup2 value
    ) => new("eventStreamCloudEventGroupMemberDeletedPreviousObjectGroup2", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupMemberDeletedPreviousObjectGroup0"
    /// </summary>
    public bool IsEventStreamCloudEventGroupMemberDeletedPreviousObjectGroup0() =>
        Type == "eventStreamCloudEventGroupMemberDeletedPreviousObjectGroup0";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupMemberDeletedPreviousObjectGroup1"
    /// </summary>
    public bool IsEventStreamCloudEventGroupMemberDeletedPreviousObjectGroup1() =>
        Type == "eventStreamCloudEventGroupMemberDeletedPreviousObjectGroup1";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupMemberDeletedPreviousObjectGroup2"
    /// </summary>
    public bool IsEventStreamCloudEventGroupMemberDeletedPreviousObjectGroup2() =>
        Type == "eventStreamCloudEventGroupMemberDeletedPreviousObjectGroup2";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup0"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupMemberDeletedPreviousObjectGroup0', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupMemberDeletedPreviousObjectGroup0'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup0 AsEventStreamCloudEventGroupMemberDeletedPreviousObjectGroup0() =>
        IsEventStreamCloudEventGroupMemberDeletedPreviousObjectGroup0()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup0)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupMemberDeletedPreviousObjectGroup0'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup1"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupMemberDeletedPreviousObjectGroup1', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupMemberDeletedPreviousObjectGroup1'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup1 AsEventStreamCloudEventGroupMemberDeletedPreviousObjectGroup1() =>
        IsEventStreamCloudEventGroupMemberDeletedPreviousObjectGroup1()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup1)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupMemberDeletedPreviousObjectGroup1'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup2"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupMemberDeletedPreviousObjectGroup2', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupMemberDeletedPreviousObjectGroup2'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup2 AsEventStreamCloudEventGroupMemberDeletedPreviousObjectGroup2() =>
        IsEventStreamCloudEventGroupMemberDeletedPreviousObjectGroup2()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup2)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupMemberDeletedPreviousObjectGroup2'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup0"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupMemberDeletedPreviousObjectGroup0(
        out Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup0? value
    )
    {
        if (Type == "eventStreamCloudEventGroupMemberDeletedPreviousObjectGroup0")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup0)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup1"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupMemberDeletedPreviousObjectGroup1(
        out Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup1? value
    )
    {
        if (Type == "eventStreamCloudEventGroupMemberDeletedPreviousObjectGroup1")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup1)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup2"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupMemberDeletedPreviousObjectGroup2(
        out Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup2? value
    )
    {
        if (Type == "eventStreamCloudEventGroupMemberDeletedPreviousObjectGroup2")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup2)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup0,
            T
        > onEventStreamCloudEventGroupMemberDeletedPreviousObjectGroup0,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup1,
            T
        > onEventStreamCloudEventGroupMemberDeletedPreviousObjectGroup1,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup2,
            T
        > onEventStreamCloudEventGroupMemberDeletedPreviousObjectGroup2
    )
    {
        return Type switch
        {
            "eventStreamCloudEventGroupMemberDeletedPreviousObjectGroup0" =>
                onEventStreamCloudEventGroupMemberDeletedPreviousObjectGroup0(
                    AsEventStreamCloudEventGroupMemberDeletedPreviousObjectGroup0()
                ),
            "eventStreamCloudEventGroupMemberDeletedPreviousObjectGroup1" =>
                onEventStreamCloudEventGroupMemberDeletedPreviousObjectGroup1(
                    AsEventStreamCloudEventGroupMemberDeletedPreviousObjectGroup1()
                ),
            "eventStreamCloudEventGroupMemberDeletedPreviousObjectGroup2" =>
                onEventStreamCloudEventGroupMemberDeletedPreviousObjectGroup2(
                    AsEventStreamCloudEventGroupMemberDeletedPreviousObjectGroup2()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup0> onEventStreamCloudEventGroupMemberDeletedPreviousObjectGroup0,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup1> onEventStreamCloudEventGroupMemberDeletedPreviousObjectGroup1,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup2> onEventStreamCloudEventGroupMemberDeletedPreviousObjectGroup2
    )
    {
        switch (Type)
        {
            case "eventStreamCloudEventGroupMemberDeletedPreviousObjectGroup0":
                onEventStreamCloudEventGroupMemberDeletedPreviousObjectGroup0(
                    AsEventStreamCloudEventGroupMemberDeletedPreviousObjectGroup0()
                );
                break;
            case "eventStreamCloudEventGroupMemberDeletedPreviousObjectGroup1":
                onEventStreamCloudEventGroupMemberDeletedPreviousObjectGroup1(
                    AsEventStreamCloudEventGroupMemberDeletedPreviousObjectGroup1()
                );
                break;
            case "eventStreamCloudEventGroupMemberDeletedPreviousObjectGroup2":
                onEventStreamCloudEventGroupMemberDeletedPreviousObjectGroup2(
                    AsEventStreamCloudEventGroupMemberDeletedPreviousObjectGroup2()
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
        if (obj is not EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup other)
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

    public static implicit operator EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup(
        Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup0 value
    ) => new("eventStreamCloudEventGroupMemberDeletedPreviousObjectGroup0", value);

    public static implicit operator EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup(
        Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup1 value
    ) => new("eventStreamCloudEventGroupMemberDeletedPreviousObjectGroup1", value);

    public static implicit operator EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup(
        Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup2 value
    ) => new("eventStreamCloudEventGroupMemberDeletedPreviousObjectGroup2", value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup>
    {
        public override EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup? Read(
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
                        "eventStreamCloudEventGroupMemberDeletedPreviousObjectGroup0",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup0)
                    ),
                    (
                        "eventStreamCloudEventGroupMemberDeletedPreviousObjectGroup1",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup1)
                    ),
                    (
                        "eventStreamCloudEventGroupMemberDeletedPreviousObjectGroup2",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup2)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup result = new(
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup value,
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

        public override EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup result = new(
                "string",
                stringValue
            );
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupMemberDeletedPreviousObjectGroup value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
