// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The member that is a part of the group.
/// </summary>
[JsonConverter(typeof(EventStreamCloudEventGroupMemberAddedObjectMember.JsonConverter))]
[Serializable]
public class EventStreamCloudEventGroupMemberAddedObjectMember
{
    private EventStreamCloudEventGroupMemberAddedObjectMember(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectMember0 value.
    /// </summary>
    public static EventStreamCloudEventGroupMemberAddedObjectMember FromEventStreamCloudEventGroupMemberAddedObjectMember0(
        Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectMember0 value
    ) => new("eventStreamCloudEventGroupMemberAddedObjectMember0", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectMember1 value.
    /// </summary>
    public static EventStreamCloudEventGroupMemberAddedObjectMember FromEventStreamCloudEventGroupMemberAddedObjectMember1(
        Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectMember1 value
    ) => new("eventStreamCloudEventGroupMemberAddedObjectMember1", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupMemberAddedObjectMember0"
    /// </summary>
    public bool IsEventStreamCloudEventGroupMemberAddedObjectMember0() =>
        Type == "eventStreamCloudEventGroupMemberAddedObjectMember0";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupMemberAddedObjectMember1"
    /// </summary>
    public bool IsEventStreamCloudEventGroupMemberAddedObjectMember1() =>
        Type == "eventStreamCloudEventGroupMemberAddedObjectMember1";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectMember0"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupMemberAddedObjectMember0', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupMemberAddedObjectMember0'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectMember0 AsEventStreamCloudEventGroupMemberAddedObjectMember0() =>
        IsEventStreamCloudEventGroupMemberAddedObjectMember0()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectMember0)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupMemberAddedObjectMember0'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectMember1"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupMemberAddedObjectMember1', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupMemberAddedObjectMember1'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectMember1 AsEventStreamCloudEventGroupMemberAddedObjectMember1() =>
        IsEventStreamCloudEventGroupMemberAddedObjectMember1()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectMember1)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupMemberAddedObjectMember1'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectMember0"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupMemberAddedObjectMember0(
        out Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectMember0? value
    )
    {
        if (Type == "eventStreamCloudEventGroupMemberAddedObjectMember0")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectMember0)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectMember1"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupMemberAddedObjectMember1(
        out Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectMember1? value
    )
    {
        if (Type == "eventStreamCloudEventGroupMemberAddedObjectMember1")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectMember1)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectMember0,
            T
        > onEventStreamCloudEventGroupMemberAddedObjectMember0,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectMember1,
            T
        > onEventStreamCloudEventGroupMemberAddedObjectMember1
    )
    {
        return Type switch
        {
            "eventStreamCloudEventGroupMemberAddedObjectMember0" =>
                onEventStreamCloudEventGroupMemberAddedObjectMember0(
                    AsEventStreamCloudEventGroupMemberAddedObjectMember0()
                ),
            "eventStreamCloudEventGroupMemberAddedObjectMember1" =>
                onEventStreamCloudEventGroupMemberAddedObjectMember1(
                    AsEventStreamCloudEventGroupMemberAddedObjectMember1()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectMember0> onEventStreamCloudEventGroupMemberAddedObjectMember0,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectMember1> onEventStreamCloudEventGroupMemberAddedObjectMember1
    )
    {
        switch (Type)
        {
            case "eventStreamCloudEventGroupMemberAddedObjectMember0":
                onEventStreamCloudEventGroupMemberAddedObjectMember0(
                    AsEventStreamCloudEventGroupMemberAddedObjectMember0()
                );
                break;
            case "eventStreamCloudEventGroupMemberAddedObjectMember1":
                onEventStreamCloudEventGroupMemberAddedObjectMember1(
                    AsEventStreamCloudEventGroupMemberAddedObjectMember1()
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
        if (obj is not EventStreamCloudEventGroupMemberAddedObjectMember other)
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

    public static implicit operator EventStreamCloudEventGroupMemberAddedObjectMember(
        Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectMember0 value
    ) => new("eventStreamCloudEventGroupMemberAddedObjectMember0", value);

    public static implicit operator EventStreamCloudEventGroupMemberAddedObjectMember(
        Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectMember1 value
    ) => new("eventStreamCloudEventGroupMemberAddedObjectMember1", value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<EventStreamCloudEventGroupMemberAddedObjectMember>
    {
        public override EventStreamCloudEventGroupMemberAddedObjectMember? Read(
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
                        "eventStreamCloudEventGroupMemberAddedObjectMember0",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectMember0)
                    ),
                    (
                        "eventStreamCloudEventGroupMemberAddedObjectMember1",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedObjectMember1)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamCloudEventGroupMemberAddedObjectMember result = new(
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventGroupMemberAddedObjectMember"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupMemberAddedObjectMember value,
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
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override EventStreamCloudEventGroupMemberAddedObjectMember ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventGroupMemberAddedObjectMember result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupMemberAddedObjectMember value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
