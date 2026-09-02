// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The group the role is assigned to.
/// </summary>
[JsonConverter(typeof(EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup.JsonConverter))]
[Serializable]
public class EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup
{
    private EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup0 value.
    /// </summary>
    public static EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup FromEventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup0(
        Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup0 value
    ) => new("eventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup0", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup1 value.
    /// </summary>
    public static EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup FromEventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup1(
        Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup1 value
    ) => new("eventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup1", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup2 value.
    /// </summary>
    public static EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup FromEventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup2(
        Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup2 value
    ) => new("eventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup2", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup0"
    /// </summary>
    public bool IsEventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup0() =>
        Type == "eventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup0";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup1"
    /// </summary>
    public bool IsEventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup1() =>
        Type == "eventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup1";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup2"
    /// </summary>
    public bool IsEventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup2() =>
        Type == "eventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup2";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup0"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup0', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup0'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup0 AsEventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup0() =>
        IsEventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup0()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup0)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup0'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup1"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup1', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup1'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup1 AsEventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup1() =>
        IsEventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup1()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup1)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup1'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup2"/> if <see cref="Type"/> is 'eventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup2', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup2'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup2 AsEventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup2() =>
        IsEventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup2()
            ? (Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup2)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup2'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup0"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup0(
        out Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup0? value
    )
    {
        if (Type == "eventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup0")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup0)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup1"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup1(
        out Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup1? value
    )
    {
        if (Type == "eventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup1")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup1)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup2"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup2(
        out Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup2? value
    )
    {
        if (Type == "eventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup2")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup2)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup0,
            T
        > onEventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup0,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup1,
            T
        > onEventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup1,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup2,
            T
        > onEventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup2
    )
    {
        return Type switch
        {
            "eventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup0" =>
                onEventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup0(
                    AsEventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup0()
                ),
            "eventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup1" =>
                onEventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup1(
                    AsEventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup1()
                ),
            "eventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup2" =>
                onEventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup2(
                    AsEventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup2()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup0> onEventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup0,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup1> onEventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup1,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup2> onEventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup2
    )
    {
        switch (Type)
        {
            case "eventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup0":
                onEventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup0(
                    AsEventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup0()
                );
                break;
            case "eventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup1":
                onEventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup1(
                    AsEventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup1()
                );
                break;
            case "eventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup2":
                onEventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup2(
                    AsEventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup2()
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
        if (obj is not EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup other)
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

    public static implicit operator EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup(
        Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup0 value
    ) => new("eventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup0", value);

    public static implicit operator EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup(
        Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup1 value
    ) => new("eventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup1", value);

    public static implicit operator EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup(
        Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup2 value
    ) => new("eventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup2", value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup>
    {
        public override EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup? Read(
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
                        "eventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup0",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup0)
                    ),
                    (
                        "eventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup1",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup1)
                    ),
                    (
                        "eventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup2",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup2)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup result =
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup value,
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

        public override EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup result = new(
                "string",
                stringValue
            );
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventOrgGroupRoleDeletedPreviousObjectGroup value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
