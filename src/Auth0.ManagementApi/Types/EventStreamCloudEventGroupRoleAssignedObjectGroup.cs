// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The group the role is assigned to.
/// </summary>
[JsonConverter(typeof(EventStreamCloudEventGroupRoleAssignedObjectGroup.JsonConverter))]
[Serializable]
public class EventStreamCloudEventGroupRoleAssignedObjectGroup
{
    private EventStreamCloudEventGroupRoleAssignedObjectGroup(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedObjectGroup0 value.
    /// </summary>
    public static EventStreamCloudEventGroupRoleAssignedObjectGroup FromEventStreamCloudEventGroupRoleAssignedObjectGroup0(
        Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedObjectGroup0 value
    ) => new("eventStreamCloudEventGroupRoleAssignedObjectGroup0", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedObjectGroup1 value.
    /// </summary>
    public static EventStreamCloudEventGroupRoleAssignedObjectGroup FromEventStreamCloudEventGroupRoleAssignedObjectGroup1(
        Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedObjectGroup1 value
    ) => new("eventStreamCloudEventGroupRoleAssignedObjectGroup1", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedObjectGroup2 value.
    /// </summary>
    public static EventStreamCloudEventGroupRoleAssignedObjectGroup FromEventStreamCloudEventGroupRoleAssignedObjectGroup2(
        Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedObjectGroup2 value
    ) => new("eventStreamCloudEventGroupRoleAssignedObjectGroup2", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupRoleAssignedObjectGroup0"
    /// </summary>
    public bool IsEventStreamCloudEventGroupRoleAssignedObjectGroup0() =>
        Type == "eventStreamCloudEventGroupRoleAssignedObjectGroup0";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupRoleAssignedObjectGroup1"
    /// </summary>
    public bool IsEventStreamCloudEventGroupRoleAssignedObjectGroup1() =>
        Type == "eventStreamCloudEventGroupRoleAssignedObjectGroup1";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupRoleAssignedObjectGroup2"
    /// </summary>
    public bool IsEventStreamCloudEventGroupRoleAssignedObjectGroup2() =>
        Type == "eventStreamCloudEventGroupRoleAssignedObjectGroup2";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedObjectGroup0"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupRoleAssignedObjectGroup0', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupRoleAssignedObjectGroup0'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedObjectGroup0 AsEventStreamCloudEventGroupRoleAssignedObjectGroup0() =>
        IsEventStreamCloudEventGroupRoleAssignedObjectGroup0()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedObjectGroup0)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupRoleAssignedObjectGroup0'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedObjectGroup1"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupRoleAssignedObjectGroup1', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupRoleAssignedObjectGroup1'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedObjectGroup1 AsEventStreamCloudEventGroupRoleAssignedObjectGroup1() =>
        IsEventStreamCloudEventGroupRoleAssignedObjectGroup1()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedObjectGroup1)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupRoleAssignedObjectGroup1'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedObjectGroup2"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupRoleAssignedObjectGroup2', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupRoleAssignedObjectGroup2'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedObjectGroup2 AsEventStreamCloudEventGroupRoleAssignedObjectGroup2() =>
        IsEventStreamCloudEventGroupRoleAssignedObjectGroup2()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedObjectGroup2)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupRoleAssignedObjectGroup2'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedObjectGroup0"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupRoleAssignedObjectGroup0(
        out Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedObjectGroup0? value
    )
    {
        if (Type == "eventStreamCloudEventGroupRoleAssignedObjectGroup0")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedObjectGroup0)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedObjectGroup1"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupRoleAssignedObjectGroup1(
        out Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedObjectGroup1? value
    )
    {
        if (Type == "eventStreamCloudEventGroupRoleAssignedObjectGroup1")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedObjectGroup1)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedObjectGroup2"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupRoleAssignedObjectGroup2(
        out Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedObjectGroup2? value
    )
    {
        if (Type == "eventStreamCloudEventGroupRoleAssignedObjectGroup2")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedObjectGroup2)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedObjectGroup0,
            T
        > onEventStreamCloudEventGroupRoleAssignedObjectGroup0,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedObjectGroup1,
            T
        > onEventStreamCloudEventGroupRoleAssignedObjectGroup1,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedObjectGroup2,
            T
        > onEventStreamCloudEventGroupRoleAssignedObjectGroup2
    )
    {
        return Type switch
        {
            "eventStreamCloudEventGroupRoleAssignedObjectGroup0" =>
                onEventStreamCloudEventGroupRoleAssignedObjectGroup0(
                    AsEventStreamCloudEventGroupRoleAssignedObjectGroup0()
                ),
            "eventStreamCloudEventGroupRoleAssignedObjectGroup1" =>
                onEventStreamCloudEventGroupRoleAssignedObjectGroup1(
                    AsEventStreamCloudEventGroupRoleAssignedObjectGroup1()
                ),
            "eventStreamCloudEventGroupRoleAssignedObjectGroup2" =>
                onEventStreamCloudEventGroupRoleAssignedObjectGroup2(
                    AsEventStreamCloudEventGroupRoleAssignedObjectGroup2()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedObjectGroup0> onEventStreamCloudEventGroupRoleAssignedObjectGroup0,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedObjectGroup1> onEventStreamCloudEventGroupRoleAssignedObjectGroup1,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedObjectGroup2> onEventStreamCloudEventGroupRoleAssignedObjectGroup2
    )
    {
        switch (Type)
        {
            case "eventStreamCloudEventGroupRoleAssignedObjectGroup0":
                onEventStreamCloudEventGroupRoleAssignedObjectGroup0(
                    AsEventStreamCloudEventGroupRoleAssignedObjectGroup0()
                );
                break;
            case "eventStreamCloudEventGroupRoleAssignedObjectGroup1":
                onEventStreamCloudEventGroupRoleAssignedObjectGroup1(
                    AsEventStreamCloudEventGroupRoleAssignedObjectGroup1()
                );
                break;
            case "eventStreamCloudEventGroupRoleAssignedObjectGroup2":
                onEventStreamCloudEventGroupRoleAssignedObjectGroup2(
                    AsEventStreamCloudEventGroupRoleAssignedObjectGroup2()
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
        if (obj is not EventStreamCloudEventGroupRoleAssignedObjectGroup other)
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

    public static implicit operator EventStreamCloudEventGroupRoleAssignedObjectGroup(
        Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedObjectGroup0 value
    ) => new("eventStreamCloudEventGroupRoleAssignedObjectGroup0", value);

    public static implicit operator EventStreamCloudEventGroupRoleAssignedObjectGroup(
        Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedObjectGroup1 value
    ) => new("eventStreamCloudEventGroupRoleAssignedObjectGroup1", value);

    public static implicit operator EventStreamCloudEventGroupRoleAssignedObjectGroup(
        Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedObjectGroup2 value
    ) => new("eventStreamCloudEventGroupRoleAssignedObjectGroup2", value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<EventStreamCloudEventGroupRoleAssignedObjectGroup>
    {
        public override EventStreamCloudEventGroupRoleAssignedObjectGroup? Read(
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
                        "eventStreamCloudEventGroupRoleAssignedObjectGroup0",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedObjectGroup0)
                    ),
                    (
                        "eventStreamCloudEventGroupRoleAssignedObjectGroup1",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedObjectGroup1)
                    ),
                    (
                        "eventStreamCloudEventGroupRoleAssignedObjectGroup2",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedObjectGroup2)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamCloudEventGroupRoleAssignedObjectGroup result = new(
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventGroupRoleAssignedObjectGroup"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupRoleAssignedObjectGroup value,
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

        public override EventStreamCloudEventGroupRoleAssignedObjectGroup ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventGroupRoleAssignedObjectGroup result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupRoleAssignedObjectGroup value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
