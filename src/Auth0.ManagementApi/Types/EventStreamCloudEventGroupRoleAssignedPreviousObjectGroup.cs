// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The group the role is assigned to.
/// </summary>
[JsonConverter(typeof(EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup.JsonConverter))]
[Serializable]
public class EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup
{
    private EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0 value.
    /// </summary>
    public static EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup FromEventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0(
        Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0 value
    ) => new("eventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup1 value.
    /// </summary>
    public static EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup FromEventStreamCloudEventGroupRoleAssignedPreviousObjectGroup1(
        Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup1 value
    ) => new("eventStreamCloudEventGroupRoleAssignedPreviousObjectGroup1", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2 value.
    /// </summary>
    public static EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup FromEventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2(
        Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2 value
    ) => new("eventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0"
    /// </summary>
    public bool IsEventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0() =>
        Type == "eventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupRoleAssignedPreviousObjectGroup1"
    /// </summary>
    public bool IsEventStreamCloudEventGroupRoleAssignedPreviousObjectGroup1() =>
        Type == "eventStreamCloudEventGroupRoleAssignedPreviousObjectGroup1";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2"
    /// </summary>
    public bool IsEventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2() =>
        Type == "eventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0 AsEventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0() =>
        IsEventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup1"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupRoleAssignedPreviousObjectGroup1', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupRoleAssignedPreviousObjectGroup1'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup1 AsEventStreamCloudEventGroupRoleAssignedPreviousObjectGroup1() =>
        IsEventStreamCloudEventGroupRoleAssignedPreviousObjectGroup1()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup1)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupRoleAssignedPreviousObjectGroup1'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2 AsEventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2() =>
        IsEventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0(
        out Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0? value
    )
    {
        if (Type == "eventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup1"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupRoleAssignedPreviousObjectGroup1(
        out Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup1? value
    )
    {
        if (Type == "eventStreamCloudEventGroupRoleAssignedPreviousObjectGroup1")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup1)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2(
        out Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2? value
    )
    {
        if (Type == "eventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0,
            T
        > onEventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup1,
            T
        > onEventStreamCloudEventGroupRoleAssignedPreviousObjectGroup1,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2,
            T
        > onEventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2
    )
    {
        return Type switch
        {
            "eventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0" =>
                onEventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0(
                    AsEventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0()
                ),
            "eventStreamCloudEventGroupRoleAssignedPreviousObjectGroup1" =>
                onEventStreamCloudEventGroupRoleAssignedPreviousObjectGroup1(
                    AsEventStreamCloudEventGroupRoleAssignedPreviousObjectGroup1()
                ),
            "eventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2" =>
                onEventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2(
                    AsEventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0> onEventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup1> onEventStreamCloudEventGroupRoleAssignedPreviousObjectGroup1,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2> onEventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2
    )
    {
        switch (Type)
        {
            case "eventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0":
                onEventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0(
                    AsEventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0()
                );
                break;
            case "eventStreamCloudEventGroupRoleAssignedPreviousObjectGroup1":
                onEventStreamCloudEventGroupRoleAssignedPreviousObjectGroup1(
                    AsEventStreamCloudEventGroupRoleAssignedPreviousObjectGroup1()
                );
                break;
            case "eventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2":
                onEventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2(
                    AsEventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2()
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
        if (obj is not EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup other)
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

    public static implicit operator EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup(
        Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0 value
    ) => new("eventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0", value);

    public static implicit operator EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup(
        Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup1 value
    ) => new("eventStreamCloudEventGroupRoleAssignedPreviousObjectGroup1", value);

    public static implicit operator EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup(
        Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2 value
    ) => new("eventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2", value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup>
    {
        public override EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup? Read(
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
                        "eventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup0)
                    ),
                    (
                        "eventStreamCloudEventGroupRoleAssignedPreviousObjectGroup1",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup1)
                    ),
                    (
                        "eventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup2)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup result = new(
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup value,
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

        public override EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup result = new(
                "string",
                stringValue
            );
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupRoleAssignedPreviousObjectGroup value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
