// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The group the member belongs to.
/// </summary>
[JsonConverter(typeof(EventStreamCloudEventGroupMemberAddedPreviousObjectGroup.JsonConverter))]
[Serializable]
public class EventStreamCloudEventGroupMemberAddedPreviousObjectGroup
{
    private EventStreamCloudEventGroupMemberAddedPreviousObjectGroup(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectGroup0 value.
    /// </summary>
    public static EventStreamCloudEventGroupMemberAddedPreviousObjectGroup FromEventStreamCloudEventGroupMemberAddedPreviousObjectGroup0(
        Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectGroup0 value
    ) => new("eventStreamCloudEventGroupMemberAddedPreviousObjectGroup0", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectGroup1 value.
    /// </summary>
    public static EventStreamCloudEventGroupMemberAddedPreviousObjectGroup FromEventStreamCloudEventGroupMemberAddedPreviousObjectGroup1(
        Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectGroup1 value
    ) => new("eventStreamCloudEventGroupMemberAddedPreviousObjectGroup1", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectGroup2 value.
    /// </summary>
    public static EventStreamCloudEventGroupMemberAddedPreviousObjectGroup FromEventStreamCloudEventGroupMemberAddedPreviousObjectGroup2(
        Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectGroup2 value
    ) => new("eventStreamCloudEventGroupMemberAddedPreviousObjectGroup2", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupMemberAddedPreviousObjectGroup0"
    /// </summary>
    public bool IsEventStreamCloudEventGroupMemberAddedPreviousObjectGroup0() =>
        Type == "eventStreamCloudEventGroupMemberAddedPreviousObjectGroup0";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupMemberAddedPreviousObjectGroup1"
    /// </summary>
    public bool IsEventStreamCloudEventGroupMemberAddedPreviousObjectGroup1() =>
        Type == "eventStreamCloudEventGroupMemberAddedPreviousObjectGroup1";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupMemberAddedPreviousObjectGroup2"
    /// </summary>
    public bool IsEventStreamCloudEventGroupMemberAddedPreviousObjectGroup2() =>
        Type == "eventStreamCloudEventGroupMemberAddedPreviousObjectGroup2";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectGroup0"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupMemberAddedPreviousObjectGroup0', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupMemberAddedPreviousObjectGroup0'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectGroup0 AsEventStreamCloudEventGroupMemberAddedPreviousObjectGroup0() =>
        IsEventStreamCloudEventGroupMemberAddedPreviousObjectGroup0()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectGroup0)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupMemberAddedPreviousObjectGroup0'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectGroup1"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupMemberAddedPreviousObjectGroup1', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupMemberAddedPreviousObjectGroup1'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectGroup1 AsEventStreamCloudEventGroupMemberAddedPreviousObjectGroup1() =>
        IsEventStreamCloudEventGroupMemberAddedPreviousObjectGroup1()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectGroup1)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupMemberAddedPreviousObjectGroup1'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectGroup2"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupMemberAddedPreviousObjectGroup2', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupMemberAddedPreviousObjectGroup2'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectGroup2 AsEventStreamCloudEventGroupMemberAddedPreviousObjectGroup2() =>
        IsEventStreamCloudEventGroupMemberAddedPreviousObjectGroup2()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectGroup2)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupMemberAddedPreviousObjectGroup2'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectGroup0"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupMemberAddedPreviousObjectGroup0(
        out Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectGroup0? value
    )
    {
        if (Type == "eventStreamCloudEventGroupMemberAddedPreviousObjectGroup0")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectGroup0)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectGroup1"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupMemberAddedPreviousObjectGroup1(
        out Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectGroup1? value
    )
    {
        if (Type == "eventStreamCloudEventGroupMemberAddedPreviousObjectGroup1")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectGroup1)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectGroup2"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupMemberAddedPreviousObjectGroup2(
        out Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectGroup2? value
    )
    {
        if (Type == "eventStreamCloudEventGroupMemberAddedPreviousObjectGroup2")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectGroup2)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectGroup0,
            T
        > onEventStreamCloudEventGroupMemberAddedPreviousObjectGroup0,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectGroup1,
            T
        > onEventStreamCloudEventGroupMemberAddedPreviousObjectGroup1,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectGroup2,
            T
        > onEventStreamCloudEventGroupMemberAddedPreviousObjectGroup2
    )
    {
        return Type switch
        {
            "eventStreamCloudEventGroupMemberAddedPreviousObjectGroup0" =>
                onEventStreamCloudEventGroupMemberAddedPreviousObjectGroup0(
                    AsEventStreamCloudEventGroupMemberAddedPreviousObjectGroup0()
                ),
            "eventStreamCloudEventGroupMemberAddedPreviousObjectGroup1" =>
                onEventStreamCloudEventGroupMemberAddedPreviousObjectGroup1(
                    AsEventStreamCloudEventGroupMemberAddedPreviousObjectGroup1()
                ),
            "eventStreamCloudEventGroupMemberAddedPreviousObjectGroup2" =>
                onEventStreamCloudEventGroupMemberAddedPreviousObjectGroup2(
                    AsEventStreamCloudEventGroupMemberAddedPreviousObjectGroup2()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectGroup0> onEventStreamCloudEventGroupMemberAddedPreviousObjectGroup0,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectGroup1> onEventStreamCloudEventGroupMemberAddedPreviousObjectGroup1,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectGroup2> onEventStreamCloudEventGroupMemberAddedPreviousObjectGroup2
    )
    {
        switch (Type)
        {
            case "eventStreamCloudEventGroupMemberAddedPreviousObjectGroup0":
                onEventStreamCloudEventGroupMemberAddedPreviousObjectGroup0(
                    AsEventStreamCloudEventGroupMemberAddedPreviousObjectGroup0()
                );
                break;
            case "eventStreamCloudEventGroupMemberAddedPreviousObjectGroup1":
                onEventStreamCloudEventGroupMemberAddedPreviousObjectGroup1(
                    AsEventStreamCloudEventGroupMemberAddedPreviousObjectGroup1()
                );
                break;
            case "eventStreamCloudEventGroupMemberAddedPreviousObjectGroup2":
                onEventStreamCloudEventGroupMemberAddedPreviousObjectGroup2(
                    AsEventStreamCloudEventGroupMemberAddedPreviousObjectGroup2()
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
        if (obj is not EventStreamCloudEventGroupMemberAddedPreviousObjectGroup other)
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

    public static implicit operator EventStreamCloudEventGroupMemberAddedPreviousObjectGroup(
        Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectGroup0 value
    ) => new("eventStreamCloudEventGroupMemberAddedPreviousObjectGroup0", value);

    public static implicit operator EventStreamCloudEventGroupMemberAddedPreviousObjectGroup(
        Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectGroup1 value
    ) => new("eventStreamCloudEventGroupMemberAddedPreviousObjectGroup1", value);

    public static implicit operator EventStreamCloudEventGroupMemberAddedPreviousObjectGroup(
        Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectGroup2 value
    ) => new("eventStreamCloudEventGroupMemberAddedPreviousObjectGroup2", value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<EventStreamCloudEventGroupMemberAddedPreviousObjectGroup>
    {
        public override EventStreamCloudEventGroupMemberAddedPreviousObjectGroup? Read(
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
                        "eventStreamCloudEventGroupMemberAddedPreviousObjectGroup0",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectGroup0)
                    ),
                    (
                        "eventStreamCloudEventGroupMemberAddedPreviousObjectGroup1",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectGroup1)
                    ),
                    (
                        "eventStreamCloudEventGroupMemberAddedPreviousObjectGroup2",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectGroup2)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamCloudEventGroupMemberAddedPreviousObjectGroup result = new(
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventGroupMemberAddedPreviousObjectGroup"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupMemberAddedPreviousObjectGroup value,
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

        public override EventStreamCloudEventGroupMemberAddedPreviousObjectGroup ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventGroupMemberAddedPreviousObjectGroup result = new(
                "string",
                stringValue
            );
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupMemberAddedPreviousObjectGroup value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
