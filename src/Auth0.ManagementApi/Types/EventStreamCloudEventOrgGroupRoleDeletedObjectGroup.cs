// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The group the role is removed from.
/// </summary>
[JsonConverter(typeof(EventStreamCloudEventOrgGroupRoleDeletedObjectGroup.JsonConverter))]
[Serializable]
public class EventStreamCloudEventOrgGroupRoleDeletedObjectGroup
{
    private EventStreamCloudEventOrgGroupRoleDeletedObjectGroup(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedObjectGroup0 value.
    /// </summary>
    public static EventStreamCloudEventOrgGroupRoleDeletedObjectGroup FromEventStreamCloudEventOrgGroupRoleDeletedObjectGroup0(
        Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedObjectGroup0 value
    ) => new("eventStreamCloudEventOrgGroupRoleDeletedObjectGroup0", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedObjectGroup1 value.
    /// </summary>
    public static EventStreamCloudEventOrgGroupRoleDeletedObjectGroup FromEventStreamCloudEventOrgGroupRoleDeletedObjectGroup1(
        Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedObjectGroup1 value
    ) => new("eventStreamCloudEventOrgGroupRoleDeletedObjectGroup1", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedObjectGroup2 value.
    /// </summary>
    public static EventStreamCloudEventOrgGroupRoleDeletedObjectGroup FromEventStreamCloudEventOrgGroupRoleDeletedObjectGroup2(
        Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedObjectGroup2 value
    ) => new("eventStreamCloudEventOrgGroupRoleDeletedObjectGroup2", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgGroupRoleDeletedObjectGroup0"
    /// </summary>
    public bool IsEventStreamCloudEventOrgGroupRoleDeletedObjectGroup0() =>
        Type == "eventStreamCloudEventOrgGroupRoleDeletedObjectGroup0";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgGroupRoleDeletedObjectGroup1"
    /// </summary>
    public bool IsEventStreamCloudEventOrgGroupRoleDeletedObjectGroup1() =>
        Type == "eventStreamCloudEventOrgGroupRoleDeletedObjectGroup1";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgGroupRoleDeletedObjectGroup2"
    /// </summary>
    public bool IsEventStreamCloudEventOrgGroupRoleDeletedObjectGroup2() =>
        Type == "eventStreamCloudEventOrgGroupRoleDeletedObjectGroup2";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedObjectGroup0"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgGroupRoleDeletedObjectGroup0', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgGroupRoleDeletedObjectGroup0'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedObjectGroup0 AsEventStreamCloudEventOrgGroupRoleDeletedObjectGroup0() =>
        IsEventStreamCloudEventOrgGroupRoleDeletedObjectGroup0()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedObjectGroup0)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgGroupRoleDeletedObjectGroup0'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedObjectGroup1"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgGroupRoleDeletedObjectGroup1', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgGroupRoleDeletedObjectGroup1'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedObjectGroup1 AsEventStreamCloudEventOrgGroupRoleDeletedObjectGroup1() =>
        IsEventStreamCloudEventOrgGroupRoleDeletedObjectGroup1()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedObjectGroup1)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgGroupRoleDeletedObjectGroup1'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedObjectGroup2"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgGroupRoleDeletedObjectGroup2', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgGroupRoleDeletedObjectGroup2'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedObjectGroup2 AsEventStreamCloudEventOrgGroupRoleDeletedObjectGroup2() =>
        IsEventStreamCloudEventOrgGroupRoleDeletedObjectGroup2()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedObjectGroup2)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgGroupRoleDeletedObjectGroup2'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedObjectGroup0"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgGroupRoleDeletedObjectGroup0(
        out Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedObjectGroup0? value
    )
    {
        if (Type == "eventStreamCloudEventOrgGroupRoleDeletedObjectGroup0")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedObjectGroup0)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedObjectGroup1"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgGroupRoleDeletedObjectGroup1(
        out Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedObjectGroup1? value
    )
    {
        if (Type == "eventStreamCloudEventOrgGroupRoleDeletedObjectGroup1")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedObjectGroup1)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedObjectGroup2"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgGroupRoleDeletedObjectGroup2(
        out Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedObjectGroup2? value
    )
    {
        if (Type == "eventStreamCloudEventOrgGroupRoleDeletedObjectGroup2")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedObjectGroup2)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedObjectGroup0,
            T
        > onEventStreamCloudEventOrgGroupRoleDeletedObjectGroup0,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedObjectGroup1,
            T
        > onEventStreamCloudEventOrgGroupRoleDeletedObjectGroup1,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedObjectGroup2,
            T
        > onEventStreamCloudEventOrgGroupRoleDeletedObjectGroup2
    )
    {
        return Type switch
        {
            "eventStreamCloudEventOrgGroupRoleDeletedObjectGroup0" =>
                onEventStreamCloudEventOrgGroupRoleDeletedObjectGroup0(
                    AsEventStreamCloudEventOrgGroupRoleDeletedObjectGroup0()
                ),
            "eventStreamCloudEventOrgGroupRoleDeletedObjectGroup1" =>
                onEventStreamCloudEventOrgGroupRoleDeletedObjectGroup1(
                    AsEventStreamCloudEventOrgGroupRoleDeletedObjectGroup1()
                ),
            "eventStreamCloudEventOrgGroupRoleDeletedObjectGroup2" =>
                onEventStreamCloudEventOrgGroupRoleDeletedObjectGroup2(
                    AsEventStreamCloudEventOrgGroupRoleDeletedObjectGroup2()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedObjectGroup0> onEventStreamCloudEventOrgGroupRoleDeletedObjectGroup0,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedObjectGroup1> onEventStreamCloudEventOrgGroupRoleDeletedObjectGroup1,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedObjectGroup2> onEventStreamCloudEventOrgGroupRoleDeletedObjectGroup2
    )
    {
        switch (Type)
        {
            case "eventStreamCloudEventOrgGroupRoleDeletedObjectGroup0":
                onEventStreamCloudEventOrgGroupRoleDeletedObjectGroup0(
                    AsEventStreamCloudEventOrgGroupRoleDeletedObjectGroup0()
                );
                break;
            case "eventStreamCloudEventOrgGroupRoleDeletedObjectGroup1":
                onEventStreamCloudEventOrgGroupRoleDeletedObjectGroup1(
                    AsEventStreamCloudEventOrgGroupRoleDeletedObjectGroup1()
                );
                break;
            case "eventStreamCloudEventOrgGroupRoleDeletedObjectGroup2":
                onEventStreamCloudEventOrgGroupRoleDeletedObjectGroup2(
                    AsEventStreamCloudEventOrgGroupRoleDeletedObjectGroup2()
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
        if (obj is not EventStreamCloudEventOrgGroupRoleDeletedObjectGroup other)
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

    public static implicit operator EventStreamCloudEventOrgGroupRoleDeletedObjectGroup(
        Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedObjectGroup0 value
    ) => new("eventStreamCloudEventOrgGroupRoleDeletedObjectGroup0", value);

    public static implicit operator EventStreamCloudEventOrgGroupRoleDeletedObjectGroup(
        Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedObjectGroup1 value
    ) => new("eventStreamCloudEventOrgGroupRoleDeletedObjectGroup1", value);

    public static implicit operator EventStreamCloudEventOrgGroupRoleDeletedObjectGroup(
        Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedObjectGroup2 value
    ) => new("eventStreamCloudEventOrgGroupRoleDeletedObjectGroup2", value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<EventStreamCloudEventOrgGroupRoleDeletedObjectGroup>
    {
        public override EventStreamCloudEventOrgGroupRoleDeletedObjectGroup? Read(
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
                        "eventStreamCloudEventOrgGroupRoleDeletedObjectGroup0",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedObjectGroup0)
                    ),
                    (
                        "eventStreamCloudEventOrgGroupRoleDeletedObjectGroup1",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedObjectGroup1)
                    ),
                    (
                        "eventStreamCloudEventOrgGroupRoleDeletedObjectGroup2",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedObjectGroup2)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamCloudEventOrgGroupRoleDeletedObjectGroup result = new(
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventOrgGroupRoleDeletedObjectGroup"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgGroupRoleDeletedObjectGroup value,
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

        public override EventStreamCloudEventOrgGroupRoleDeletedObjectGroup ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventOrgGroupRoleDeletedObjectGroup result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgGroupRoleDeletedObjectGroup value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
