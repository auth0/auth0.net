// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The group the role is assigned to.
/// </summary>
[JsonConverter(typeof(EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup.JsonConverter))]
[Serializable]
public class EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup
{
    private EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup0 value.
    /// </summary>
    public static EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup FromEventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup0(
        Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup0 value
    ) => new("eventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup0", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup1 value.
    /// </summary>
    public static EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup FromEventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup1(
        Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup1 value
    ) => new("eventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup1", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup2 value.
    /// </summary>
    public static EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup FromEventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup2(
        Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup2 value
    ) => new("eventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup2", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup0"
    /// </summary>
    public bool IsEventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup0() =>
        Type == "eventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup0";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup1"
    /// </summary>
    public bool IsEventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup1() =>
        Type == "eventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup1";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup2"
    /// </summary>
    public bool IsEventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup2() =>
        Type == "eventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup2";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup0"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup0', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup0'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup0 AsEventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup0() =>
        IsEventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup0()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup0)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup0'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup1"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup1', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup1'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup1 AsEventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup1() =>
        IsEventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup1()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup1)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup1'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup2"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup2', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup2'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup2 AsEventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup2() =>
        IsEventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup2()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup2)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup2'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup0"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup0(
        out Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup0? value
    )
    {
        if (Type == "eventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup0")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup0)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup1"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup1(
        out Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup1? value
    )
    {
        if (Type == "eventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup1")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup1)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup2"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup2(
        out Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup2? value
    )
    {
        if (Type == "eventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup2")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup2)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup0,
            T
        > onEventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup0,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup1,
            T
        > onEventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup1,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup2,
            T
        > onEventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup2
    )
    {
        return Type switch
        {
            "eventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup0" =>
                onEventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup0(
                    AsEventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup0()
                ),
            "eventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup1" =>
                onEventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup1(
                    AsEventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup1()
                ),
            "eventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup2" =>
                onEventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup2(
                    AsEventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup2()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup0> onEventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup0,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup1> onEventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup1,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup2> onEventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup2
    )
    {
        switch (Type)
        {
            case "eventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup0":
                onEventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup0(
                    AsEventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup0()
                );
                break;
            case "eventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup1":
                onEventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup1(
                    AsEventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup1()
                );
                break;
            case "eventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup2":
                onEventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup2(
                    AsEventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup2()
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
        if (obj is not EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup other)
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

    public static implicit operator EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup(
        Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup0 value
    ) => new("eventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup0", value);

    public static implicit operator EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup(
        Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup1 value
    ) => new("eventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup1", value);

    public static implicit operator EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup(
        Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup2 value
    ) => new("eventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup2", value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup>
    {
        public override EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup? Read(
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
                        "eventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup0",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup0)
                    ),
                    (
                        "eventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup1",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup1)
                    ),
                    (
                        "eventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup2",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup2)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup result =
                                new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup value,
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

        public override EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup result = new(
                "string",
                stringValue
            );
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgGroupRoleAssignedPreviousObjectGroup value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
