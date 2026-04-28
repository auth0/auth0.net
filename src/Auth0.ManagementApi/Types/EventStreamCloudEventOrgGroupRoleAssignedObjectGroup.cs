// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The group the role is assigned to.
/// </summary>
[JsonConverter(typeof(EventStreamCloudEventOrgGroupRoleAssignedObjectGroup.JsonConverter))]
[Serializable]
public class EventStreamCloudEventOrgGroupRoleAssignedObjectGroup
{
    private EventStreamCloudEventOrgGroupRoleAssignedObjectGroup(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedObjectGroup0 value.
    /// </summary>
    public static EventStreamCloudEventOrgGroupRoleAssignedObjectGroup FromEventStreamCloudEventOrgGroupRoleAssignedObjectGroup0(
        Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedObjectGroup0 value
    ) => new("eventStreamCloudEventOrgGroupRoleAssignedObjectGroup0", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedObjectGroup1 value.
    /// </summary>
    public static EventStreamCloudEventOrgGroupRoleAssignedObjectGroup FromEventStreamCloudEventOrgGroupRoleAssignedObjectGroup1(
        Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedObjectGroup1 value
    ) => new("eventStreamCloudEventOrgGroupRoleAssignedObjectGroup1", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedObjectGroup2 value.
    /// </summary>
    public static EventStreamCloudEventOrgGroupRoleAssignedObjectGroup FromEventStreamCloudEventOrgGroupRoleAssignedObjectGroup2(
        Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedObjectGroup2 value
    ) => new("eventStreamCloudEventOrgGroupRoleAssignedObjectGroup2", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgGroupRoleAssignedObjectGroup0"
    /// </summary>
    public bool IsEventStreamCloudEventOrgGroupRoleAssignedObjectGroup0() =>
        Type == "eventStreamCloudEventOrgGroupRoleAssignedObjectGroup0";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgGroupRoleAssignedObjectGroup1"
    /// </summary>
    public bool IsEventStreamCloudEventOrgGroupRoleAssignedObjectGroup1() =>
        Type == "eventStreamCloudEventOrgGroupRoleAssignedObjectGroup1";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgGroupRoleAssignedObjectGroup2"
    /// </summary>
    public bool IsEventStreamCloudEventOrgGroupRoleAssignedObjectGroup2() =>
        Type == "eventStreamCloudEventOrgGroupRoleAssignedObjectGroup2";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedObjectGroup0"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgGroupRoleAssignedObjectGroup0', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgGroupRoleAssignedObjectGroup0'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedObjectGroup0 AsEventStreamCloudEventOrgGroupRoleAssignedObjectGroup0() =>
        IsEventStreamCloudEventOrgGroupRoleAssignedObjectGroup0()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedObjectGroup0)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgGroupRoleAssignedObjectGroup0'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedObjectGroup1"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgGroupRoleAssignedObjectGroup1', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgGroupRoleAssignedObjectGroup1'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedObjectGroup1 AsEventStreamCloudEventOrgGroupRoleAssignedObjectGroup1() =>
        IsEventStreamCloudEventOrgGroupRoleAssignedObjectGroup1()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedObjectGroup1)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgGroupRoleAssignedObjectGroup1'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedObjectGroup2"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgGroupRoleAssignedObjectGroup2', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgGroupRoleAssignedObjectGroup2'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedObjectGroup2 AsEventStreamCloudEventOrgGroupRoleAssignedObjectGroup2() =>
        IsEventStreamCloudEventOrgGroupRoleAssignedObjectGroup2()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedObjectGroup2)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgGroupRoleAssignedObjectGroup2'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedObjectGroup0"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgGroupRoleAssignedObjectGroup0(
        out Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedObjectGroup0? value
    )
    {
        if (Type == "eventStreamCloudEventOrgGroupRoleAssignedObjectGroup0")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedObjectGroup0)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedObjectGroup1"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgGroupRoleAssignedObjectGroup1(
        out Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedObjectGroup1? value
    )
    {
        if (Type == "eventStreamCloudEventOrgGroupRoleAssignedObjectGroup1")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedObjectGroup1)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedObjectGroup2"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgGroupRoleAssignedObjectGroup2(
        out Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedObjectGroup2? value
    )
    {
        if (Type == "eventStreamCloudEventOrgGroupRoleAssignedObjectGroup2")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedObjectGroup2)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedObjectGroup0,
            T
        > onEventStreamCloudEventOrgGroupRoleAssignedObjectGroup0,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedObjectGroup1,
            T
        > onEventStreamCloudEventOrgGroupRoleAssignedObjectGroup1,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedObjectGroup2,
            T
        > onEventStreamCloudEventOrgGroupRoleAssignedObjectGroup2
    )
    {
        return Type switch
        {
            "eventStreamCloudEventOrgGroupRoleAssignedObjectGroup0" =>
                onEventStreamCloudEventOrgGroupRoleAssignedObjectGroup0(
                    AsEventStreamCloudEventOrgGroupRoleAssignedObjectGroup0()
                ),
            "eventStreamCloudEventOrgGroupRoleAssignedObjectGroup1" =>
                onEventStreamCloudEventOrgGroupRoleAssignedObjectGroup1(
                    AsEventStreamCloudEventOrgGroupRoleAssignedObjectGroup1()
                ),
            "eventStreamCloudEventOrgGroupRoleAssignedObjectGroup2" =>
                onEventStreamCloudEventOrgGroupRoleAssignedObjectGroup2(
                    AsEventStreamCloudEventOrgGroupRoleAssignedObjectGroup2()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedObjectGroup0> onEventStreamCloudEventOrgGroupRoleAssignedObjectGroup0,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedObjectGroup1> onEventStreamCloudEventOrgGroupRoleAssignedObjectGroup1,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedObjectGroup2> onEventStreamCloudEventOrgGroupRoleAssignedObjectGroup2
    )
    {
        switch (Type)
        {
            case "eventStreamCloudEventOrgGroupRoleAssignedObjectGroup0":
                onEventStreamCloudEventOrgGroupRoleAssignedObjectGroup0(
                    AsEventStreamCloudEventOrgGroupRoleAssignedObjectGroup0()
                );
                break;
            case "eventStreamCloudEventOrgGroupRoleAssignedObjectGroup1":
                onEventStreamCloudEventOrgGroupRoleAssignedObjectGroup1(
                    AsEventStreamCloudEventOrgGroupRoleAssignedObjectGroup1()
                );
                break;
            case "eventStreamCloudEventOrgGroupRoleAssignedObjectGroup2":
                onEventStreamCloudEventOrgGroupRoleAssignedObjectGroup2(
                    AsEventStreamCloudEventOrgGroupRoleAssignedObjectGroup2()
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
        if (obj is not EventStreamCloudEventOrgGroupRoleAssignedObjectGroup other)
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

    public static implicit operator EventStreamCloudEventOrgGroupRoleAssignedObjectGroup(
        Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedObjectGroup0 value
    ) => new("eventStreamCloudEventOrgGroupRoleAssignedObjectGroup0", value);

    public static implicit operator EventStreamCloudEventOrgGroupRoleAssignedObjectGroup(
        Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedObjectGroup1 value
    ) => new("eventStreamCloudEventOrgGroupRoleAssignedObjectGroup1", value);

    public static implicit operator EventStreamCloudEventOrgGroupRoleAssignedObjectGroup(
        Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedObjectGroup2 value
    ) => new("eventStreamCloudEventOrgGroupRoleAssignedObjectGroup2", value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<EventStreamCloudEventOrgGroupRoleAssignedObjectGroup>
    {
        public override EventStreamCloudEventOrgGroupRoleAssignedObjectGroup? Read(
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
                        "eventStreamCloudEventOrgGroupRoleAssignedObjectGroup0",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedObjectGroup0)
                    ),
                    (
                        "eventStreamCloudEventOrgGroupRoleAssignedObjectGroup1",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedObjectGroup1)
                    ),
                    (
                        "eventStreamCloudEventOrgGroupRoleAssignedObjectGroup2",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedObjectGroup2)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamCloudEventOrgGroupRoleAssignedObjectGroup result = new(
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventOrgGroupRoleAssignedObjectGroup"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgGroupRoleAssignedObjectGroup value,
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

        public override EventStreamCloudEventOrgGroupRoleAssignedObjectGroup ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventOrgGroupRoleAssignedObjectGroup result = new(
                "string",
                stringValue
            );
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgGroupRoleAssignedObjectGroup value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
