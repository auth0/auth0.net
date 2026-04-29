// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The group the role is removed from.
/// </summary>
[JsonConverter(typeof(EventStreamCloudEventGroupRoleDeletedObjectGroup.JsonConverter))]
[Serializable]
public class EventStreamCloudEventGroupRoleDeletedObjectGroup
{
    private EventStreamCloudEventGroupRoleDeletedObjectGroup(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedObjectGroup0 value.
    /// </summary>
    public static EventStreamCloudEventGroupRoleDeletedObjectGroup FromEventStreamCloudEventGroupRoleDeletedObjectGroup0(
        Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedObjectGroup0 value
    ) => new("eventStreamCloudEventGroupRoleDeletedObjectGroup0", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedObjectGroup1 value.
    /// </summary>
    public static EventStreamCloudEventGroupRoleDeletedObjectGroup FromEventStreamCloudEventGroupRoleDeletedObjectGroup1(
        Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedObjectGroup1 value
    ) => new("eventStreamCloudEventGroupRoleDeletedObjectGroup1", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedObjectGroup2 value.
    /// </summary>
    public static EventStreamCloudEventGroupRoleDeletedObjectGroup FromEventStreamCloudEventGroupRoleDeletedObjectGroup2(
        Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedObjectGroup2 value
    ) => new("eventStreamCloudEventGroupRoleDeletedObjectGroup2", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupRoleDeletedObjectGroup0"
    /// </summary>
    public bool IsEventStreamCloudEventGroupRoleDeletedObjectGroup0() =>
        Type == "eventStreamCloudEventGroupRoleDeletedObjectGroup0";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupRoleDeletedObjectGroup1"
    /// </summary>
    public bool IsEventStreamCloudEventGroupRoleDeletedObjectGroup1() =>
        Type == "eventStreamCloudEventGroupRoleDeletedObjectGroup1";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupRoleDeletedObjectGroup2"
    /// </summary>
    public bool IsEventStreamCloudEventGroupRoleDeletedObjectGroup2() =>
        Type == "eventStreamCloudEventGroupRoleDeletedObjectGroup2";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedObjectGroup0"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupRoleDeletedObjectGroup0', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupRoleDeletedObjectGroup0'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedObjectGroup0 AsEventStreamCloudEventGroupRoleDeletedObjectGroup0() =>
        IsEventStreamCloudEventGroupRoleDeletedObjectGroup0()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedObjectGroup0)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupRoleDeletedObjectGroup0'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedObjectGroup1"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupRoleDeletedObjectGroup1', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupRoleDeletedObjectGroup1'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedObjectGroup1 AsEventStreamCloudEventGroupRoleDeletedObjectGroup1() =>
        IsEventStreamCloudEventGroupRoleDeletedObjectGroup1()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedObjectGroup1)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupRoleDeletedObjectGroup1'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedObjectGroup2"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupRoleDeletedObjectGroup2', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupRoleDeletedObjectGroup2'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedObjectGroup2 AsEventStreamCloudEventGroupRoleDeletedObjectGroup2() =>
        IsEventStreamCloudEventGroupRoleDeletedObjectGroup2()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedObjectGroup2)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupRoleDeletedObjectGroup2'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedObjectGroup0"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupRoleDeletedObjectGroup0(
        out Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedObjectGroup0? value
    )
    {
        if (Type == "eventStreamCloudEventGroupRoleDeletedObjectGroup0")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedObjectGroup0)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedObjectGroup1"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupRoleDeletedObjectGroup1(
        out Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedObjectGroup1? value
    )
    {
        if (Type == "eventStreamCloudEventGroupRoleDeletedObjectGroup1")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedObjectGroup1)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedObjectGroup2"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupRoleDeletedObjectGroup2(
        out Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedObjectGroup2? value
    )
    {
        if (Type == "eventStreamCloudEventGroupRoleDeletedObjectGroup2")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedObjectGroup2)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedObjectGroup0,
            T
        > onEventStreamCloudEventGroupRoleDeletedObjectGroup0,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedObjectGroup1,
            T
        > onEventStreamCloudEventGroupRoleDeletedObjectGroup1,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedObjectGroup2,
            T
        > onEventStreamCloudEventGroupRoleDeletedObjectGroup2
    )
    {
        return Type switch
        {
            "eventStreamCloudEventGroupRoleDeletedObjectGroup0" =>
                onEventStreamCloudEventGroupRoleDeletedObjectGroup0(
                    AsEventStreamCloudEventGroupRoleDeletedObjectGroup0()
                ),
            "eventStreamCloudEventGroupRoleDeletedObjectGroup1" =>
                onEventStreamCloudEventGroupRoleDeletedObjectGroup1(
                    AsEventStreamCloudEventGroupRoleDeletedObjectGroup1()
                ),
            "eventStreamCloudEventGroupRoleDeletedObjectGroup2" =>
                onEventStreamCloudEventGroupRoleDeletedObjectGroup2(
                    AsEventStreamCloudEventGroupRoleDeletedObjectGroup2()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedObjectGroup0> onEventStreamCloudEventGroupRoleDeletedObjectGroup0,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedObjectGroup1> onEventStreamCloudEventGroupRoleDeletedObjectGroup1,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedObjectGroup2> onEventStreamCloudEventGroupRoleDeletedObjectGroup2
    )
    {
        switch (Type)
        {
            case "eventStreamCloudEventGroupRoleDeletedObjectGroup0":
                onEventStreamCloudEventGroupRoleDeletedObjectGroup0(
                    AsEventStreamCloudEventGroupRoleDeletedObjectGroup0()
                );
                break;
            case "eventStreamCloudEventGroupRoleDeletedObjectGroup1":
                onEventStreamCloudEventGroupRoleDeletedObjectGroup1(
                    AsEventStreamCloudEventGroupRoleDeletedObjectGroup1()
                );
                break;
            case "eventStreamCloudEventGroupRoleDeletedObjectGroup2":
                onEventStreamCloudEventGroupRoleDeletedObjectGroup2(
                    AsEventStreamCloudEventGroupRoleDeletedObjectGroup2()
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
        if (obj is not EventStreamCloudEventGroupRoleDeletedObjectGroup other)
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

    public static implicit operator EventStreamCloudEventGroupRoleDeletedObjectGroup(
        Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedObjectGroup0 value
    ) => new("eventStreamCloudEventGroupRoleDeletedObjectGroup0", value);

    public static implicit operator EventStreamCloudEventGroupRoleDeletedObjectGroup(
        Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedObjectGroup1 value
    ) => new("eventStreamCloudEventGroupRoleDeletedObjectGroup1", value);

    public static implicit operator EventStreamCloudEventGroupRoleDeletedObjectGroup(
        Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedObjectGroup2 value
    ) => new("eventStreamCloudEventGroupRoleDeletedObjectGroup2", value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<EventStreamCloudEventGroupRoleDeletedObjectGroup>
    {
        public override EventStreamCloudEventGroupRoleDeletedObjectGroup? Read(
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
                        "eventStreamCloudEventGroupRoleDeletedObjectGroup0",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedObjectGroup0)
                    ),
                    (
                        "eventStreamCloudEventGroupRoleDeletedObjectGroup1",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedObjectGroup1)
                    ),
                    (
                        "eventStreamCloudEventGroupRoleDeletedObjectGroup2",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupRoleDeletedObjectGroup2)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamCloudEventGroupRoleDeletedObjectGroup result = new(
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventGroupRoleDeletedObjectGroup"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupRoleDeletedObjectGroup value,
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

        public override EventStreamCloudEventGroupRoleDeletedObjectGroup ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventGroupRoleDeletedObjectGroup result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupRoleDeletedObjectGroup value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
