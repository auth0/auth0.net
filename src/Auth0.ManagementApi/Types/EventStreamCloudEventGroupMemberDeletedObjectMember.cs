// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The member that is a part of the group.
/// </summary>
[JsonConverter(typeof(EventStreamCloudEventGroupMemberDeletedObjectMember.JsonConverter))]
[Serializable]
public class EventStreamCloudEventGroupMemberDeletedObjectMember
{
    private EventStreamCloudEventGroupMemberDeletedObjectMember(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectMember0 value.
    /// </summary>
    public static EventStreamCloudEventGroupMemberDeletedObjectMember FromEventStreamCloudEventGroupMemberDeletedObjectMember0(
        Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectMember0 value
    ) => new("eventStreamCloudEventGroupMemberDeletedObjectMember0", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectMember1 value.
    /// </summary>
    public static EventStreamCloudEventGroupMemberDeletedObjectMember FromEventStreamCloudEventGroupMemberDeletedObjectMember1(
        Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectMember1 value
    ) => new("eventStreamCloudEventGroupMemberDeletedObjectMember1", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupMemberDeletedObjectMember0"
    /// </summary>
    public bool IsEventStreamCloudEventGroupMemberDeletedObjectMember0() =>
        Type == "eventStreamCloudEventGroupMemberDeletedObjectMember0";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupMemberDeletedObjectMember1"
    /// </summary>
    public bool IsEventStreamCloudEventGroupMemberDeletedObjectMember1() =>
        Type == "eventStreamCloudEventGroupMemberDeletedObjectMember1";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectMember0"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupMemberDeletedObjectMember0', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupMemberDeletedObjectMember0'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectMember0 AsEventStreamCloudEventGroupMemberDeletedObjectMember0() =>
        IsEventStreamCloudEventGroupMemberDeletedObjectMember0()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectMember0)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupMemberDeletedObjectMember0'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectMember1"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupMemberDeletedObjectMember1', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupMemberDeletedObjectMember1'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectMember1 AsEventStreamCloudEventGroupMemberDeletedObjectMember1() =>
        IsEventStreamCloudEventGroupMemberDeletedObjectMember1()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectMember1)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupMemberDeletedObjectMember1'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectMember0"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupMemberDeletedObjectMember0(
        out Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectMember0? value
    )
    {
        if (Type == "eventStreamCloudEventGroupMemberDeletedObjectMember0")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectMember0)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectMember1"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupMemberDeletedObjectMember1(
        out Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectMember1? value
    )
    {
        if (Type == "eventStreamCloudEventGroupMemberDeletedObjectMember1")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectMember1)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectMember0,
            T
        > onEventStreamCloudEventGroupMemberDeletedObjectMember0,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectMember1,
            T
        > onEventStreamCloudEventGroupMemberDeletedObjectMember1
    )
    {
        return Type switch
        {
            "eventStreamCloudEventGroupMemberDeletedObjectMember0" =>
                onEventStreamCloudEventGroupMemberDeletedObjectMember0(
                    AsEventStreamCloudEventGroupMemberDeletedObjectMember0()
                ),
            "eventStreamCloudEventGroupMemberDeletedObjectMember1" =>
                onEventStreamCloudEventGroupMemberDeletedObjectMember1(
                    AsEventStreamCloudEventGroupMemberDeletedObjectMember1()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectMember0> onEventStreamCloudEventGroupMemberDeletedObjectMember0,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectMember1> onEventStreamCloudEventGroupMemberDeletedObjectMember1
    )
    {
        switch (Type)
        {
            case "eventStreamCloudEventGroupMemberDeletedObjectMember0":
                onEventStreamCloudEventGroupMemberDeletedObjectMember0(
                    AsEventStreamCloudEventGroupMemberDeletedObjectMember0()
                );
                break;
            case "eventStreamCloudEventGroupMemberDeletedObjectMember1":
                onEventStreamCloudEventGroupMemberDeletedObjectMember1(
                    AsEventStreamCloudEventGroupMemberDeletedObjectMember1()
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
        if (obj is not EventStreamCloudEventGroupMemberDeletedObjectMember other)
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

    public static implicit operator EventStreamCloudEventGroupMemberDeletedObjectMember(
        Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectMember0 value
    ) => new("eventStreamCloudEventGroupMemberDeletedObjectMember0", value);

    public static implicit operator EventStreamCloudEventGroupMemberDeletedObjectMember(
        Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectMember1 value
    ) => new("eventStreamCloudEventGroupMemberDeletedObjectMember1", value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<EventStreamCloudEventGroupMemberDeletedObjectMember>
    {
        public override EventStreamCloudEventGroupMemberDeletedObjectMember? Read(
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
                        "eventStreamCloudEventGroupMemberDeletedObjectMember0",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectMember0)
                    ),
                    (
                        "eventStreamCloudEventGroupMemberDeletedObjectMember1",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedObjectMember1)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamCloudEventGroupMemberDeletedObjectMember result = new(
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventGroupMemberDeletedObjectMember"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupMemberDeletedObjectMember value,
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

        public override EventStreamCloudEventGroupMemberDeletedObjectMember ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventGroupMemberDeletedObjectMember result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupMemberDeletedObjectMember value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
