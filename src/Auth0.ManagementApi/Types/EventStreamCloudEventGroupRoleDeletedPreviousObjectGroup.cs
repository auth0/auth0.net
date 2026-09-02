// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The group the role is assigned to.
/// </summary>
[JsonConverter(typeof(EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup.JsonConverter))]
[Serializable]
public class EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup
{
    private EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup0 value.
    /// </summary>
    public static EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup FromEventStreamCloudEventGroupRoleDeletedPreviousObjectGroup0(
        Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup0 value
    ) => new("eventStreamCloudEventGroupRoleDeletedPreviousObjectGroup0", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup1 value.
    /// </summary>
    public static EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup FromEventStreamCloudEventGroupRoleDeletedPreviousObjectGroup1(
        Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup1 value
    ) => new("eventStreamCloudEventGroupRoleDeletedPreviousObjectGroup1", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup2 value.
    /// </summary>
    public static EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup FromEventStreamCloudEventGroupRoleDeletedPreviousObjectGroup2(
        Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup2 value
    ) => new("eventStreamCloudEventGroupRoleDeletedPreviousObjectGroup2", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupRoleDeletedPreviousObjectGroup0"
    /// </summary>
    public bool IsEventStreamCloudEventGroupRoleDeletedPreviousObjectGroup0() =>
        Type == "eventStreamCloudEventGroupRoleDeletedPreviousObjectGroup0";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupRoleDeletedPreviousObjectGroup1"
    /// </summary>
    public bool IsEventStreamCloudEventGroupRoleDeletedPreviousObjectGroup1() =>
        Type == "eventStreamCloudEventGroupRoleDeletedPreviousObjectGroup1";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupRoleDeletedPreviousObjectGroup2"
    /// </summary>
    public bool IsEventStreamCloudEventGroupRoleDeletedPreviousObjectGroup2() =>
        Type == "eventStreamCloudEventGroupRoleDeletedPreviousObjectGroup2";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup0"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupRoleDeletedPreviousObjectGroup0', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupRoleDeletedPreviousObjectGroup0'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup0 AsEventStreamCloudEventGroupRoleDeletedPreviousObjectGroup0() =>
        IsEventStreamCloudEventGroupRoleDeletedPreviousObjectGroup0()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup0)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupRoleDeletedPreviousObjectGroup0'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup1"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupRoleDeletedPreviousObjectGroup1', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupRoleDeletedPreviousObjectGroup1'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup1 AsEventStreamCloudEventGroupRoleDeletedPreviousObjectGroup1() =>
        IsEventStreamCloudEventGroupRoleDeletedPreviousObjectGroup1()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup1)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupRoleDeletedPreviousObjectGroup1'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup2"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupRoleDeletedPreviousObjectGroup2', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupRoleDeletedPreviousObjectGroup2'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup2 AsEventStreamCloudEventGroupRoleDeletedPreviousObjectGroup2() =>
        IsEventStreamCloudEventGroupRoleDeletedPreviousObjectGroup2()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup2)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupRoleDeletedPreviousObjectGroup2'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup0"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupRoleDeletedPreviousObjectGroup0(
        out Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup0? value
    )
    {
        if (Type == "eventStreamCloudEventGroupRoleDeletedPreviousObjectGroup0")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup0)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup1"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupRoleDeletedPreviousObjectGroup1(
        out Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup1? value
    )
    {
        if (Type == "eventStreamCloudEventGroupRoleDeletedPreviousObjectGroup1")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup1)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup2"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupRoleDeletedPreviousObjectGroup2(
        out Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup2? value
    )
    {
        if (Type == "eventStreamCloudEventGroupRoleDeletedPreviousObjectGroup2")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup2)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup0,
            T
        > onEventStreamCloudEventGroupRoleDeletedPreviousObjectGroup0,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup1,
            T
        > onEventStreamCloudEventGroupRoleDeletedPreviousObjectGroup1,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup2,
            T
        > onEventStreamCloudEventGroupRoleDeletedPreviousObjectGroup2
    )
    {
        return Type switch
        {
            "eventStreamCloudEventGroupRoleDeletedPreviousObjectGroup0" =>
                onEventStreamCloudEventGroupRoleDeletedPreviousObjectGroup0(
                    AsEventStreamCloudEventGroupRoleDeletedPreviousObjectGroup0()
                ),
            "eventStreamCloudEventGroupRoleDeletedPreviousObjectGroup1" =>
                onEventStreamCloudEventGroupRoleDeletedPreviousObjectGroup1(
                    AsEventStreamCloudEventGroupRoleDeletedPreviousObjectGroup1()
                ),
            "eventStreamCloudEventGroupRoleDeletedPreviousObjectGroup2" =>
                onEventStreamCloudEventGroupRoleDeletedPreviousObjectGroup2(
                    AsEventStreamCloudEventGroupRoleDeletedPreviousObjectGroup2()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup0> onEventStreamCloudEventGroupRoleDeletedPreviousObjectGroup0,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup1> onEventStreamCloudEventGroupRoleDeletedPreviousObjectGroup1,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup2> onEventStreamCloudEventGroupRoleDeletedPreviousObjectGroup2
    )
    {
        switch (Type)
        {
            case "eventStreamCloudEventGroupRoleDeletedPreviousObjectGroup0":
                onEventStreamCloudEventGroupRoleDeletedPreviousObjectGroup0(
                    AsEventStreamCloudEventGroupRoleDeletedPreviousObjectGroup0()
                );
                break;
            case "eventStreamCloudEventGroupRoleDeletedPreviousObjectGroup1":
                onEventStreamCloudEventGroupRoleDeletedPreviousObjectGroup1(
                    AsEventStreamCloudEventGroupRoleDeletedPreviousObjectGroup1()
                );
                break;
            case "eventStreamCloudEventGroupRoleDeletedPreviousObjectGroup2":
                onEventStreamCloudEventGroupRoleDeletedPreviousObjectGroup2(
                    AsEventStreamCloudEventGroupRoleDeletedPreviousObjectGroup2()
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
        if (obj is not EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup other)
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

    public static implicit operator EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup(
        Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup0 value
    ) => new("eventStreamCloudEventGroupRoleDeletedPreviousObjectGroup0", value);

    public static implicit operator EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup(
        Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup1 value
    ) => new("eventStreamCloudEventGroupRoleDeletedPreviousObjectGroup1", value);

    public static implicit operator EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup(
        Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup2 value
    ) => new("eventStreamCloudEventGroupRoleDeletedPreviousObjectGroup2", value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup>
    {
        public override EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup? Read(
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
                        "eventStreamCloudEventGroupRoleDeletedPreviousObjectGroup0",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup0)
                    ),
                    (
                        "eventStreamCloudEventGroupRoleDeletedPreviousObjectGroup1",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup1)
                    ),
                    (
                        "eventStreamCloudEventGroupRoleDeletedPreviousObjectGroup2",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup2)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup result = new(
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup value,
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

        public override EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup result = new(
                "string",
                stringValue
            );
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupRoleDeletedPreviousObjectGroup value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
