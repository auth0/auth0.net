// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The member that is a part of the group.
/// </summary>
[JsonConverter(typeof(EventStreamCloudEventGroupMemberDeletedPreviousObjectMember.JsonConverter))]
[Serializable]
public class EventStreamCloudEventGroupMemberDeletedPreviousObjectMember
{
    private EventStreamCloudEventGroupMemberDeletedPreviousObjectMember(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectMember0 value.
    /// </summary>
    public static EventStreamCloudEventGroupMemberDeletedPreviousObjectMember FromEventStreamCloudEventGroupMemberDeletedPreviousObjectMember0(
        Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectMember0 value
    ) => new("eventStreamCloudEventGroupMemberDeletedPreviousObjectMember0", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectMember1 value.
    /// </summary>
    public static EventStreamCloudEventGroupMemberDeletedPreviousObjectMember FromEventStreamCloudEventGroupMemberDeletedPreviousObjectMember1(
        Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectMember1 value
    ) => new("eventStreamCloudEventGroupMemberDeletedPreviousObjectMember1", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupMemberDeletedPreviousObjectMember0"
    /// </summary>
    public bool IsEventStreamCloudEventGroupMemberDeletedPreviousObjectMember0() =>
        Type == "eventStreamCloudEventGroupMemberDeletedPreviousObjectMember0";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupMemberDeletedPreviousObjectMember1"
    /// </summary>
    public bool IsEventStreamCloudEventGroupMemberDeletedPreviousObjectMember1() =>
        Type == "eventStreamCloudEventGroupMemberDeletedPreviousObjectMember1";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectMember0"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupMemberDeletedPreviousObjectMember0', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupMemberDeletedPreviousObjectMember0'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectMember0 AsEventStreamCloudEventGroupMemberDeletedPreviousObjectMember0() =>
        IsEventStreamCloudEventGroupMemberDeletedPreviousObjectMember0()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectMember0)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupMemberDeletedPreviousObjectMember0'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectMember1"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupMemberDeletedPreviousObjectMember1', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupMemberDeletedPreviousObjectMember1'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectMember1 AsEventStreamCloudEventGroupMemberDeletedPreviousObjectMember1() =>
        IsEventStreamCloudEventGroupMemberDeletedPreviousObjectMember1()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectMember1)
                Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupMemberDeletedPreviousObjectMember1'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectMember0"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupMemberDeletedPreviousObjectMember0(
        out Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectMember0? value
    )
    {
        if (Type == "eventStreamCloudEventGroupMemberDeletedPreviousObjectMember0")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectMember0)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectMember1"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupMemberDeletedPreviousObjectMember1(
        out Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectMember1? value
    )
    {
        if (Type == "eventStreamCloudEventGroupMemberDeletedPreviousObjectMember1")
        {
            value =
                (Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectMember1)
                    Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectMember0,
            T
        > onEventStreamCloudEventGroupMemberDeletedPreviousObjectMember0,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectMember1,
            T
        > onEventStreamCloudEventGroupMemberDeletedPreviousObjectMember1
    )
    {
        return Type switch
        {
            "eventStreamCloudEventGroupMemberDeletedPreviousObjectMember0" =>
                onEventStreamCloudEventGroupMemberDeletedPreviousObjectMember0(
                    AsEventStreamCloudEventGroupMemberDeletedPreviousObjectMember0()
                ),
            "eventStreamCloudEventGroupMemberDeletedPreviousObjectMember1" =>
                onEventStreamCloudEventGroupMemberDeletedPreviousObjectMember1(
                    AsEventStreamCloudEventGroupMemberDeletedPreviousObjectMember1()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectMember0> onEventStreamCloudEventGroupMemberDeletedPreviousObjectMember0,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectMember1> onEventStreamCloudEventGroupMemberDeletedPreviousObjectMember1
    )
    {
        switch (Type)
        {
            case "eventStreamCloudEventGroupMemberDeletedPreviousObjectMember0":
                onEventStreamCloudEventGroupMemberDeletedPreviousObjectMember0(
                    AsEventStreamCloudEventGroupMemberDeletedPreviousObjectMember0()
                );
                break;
            case "eventStreamCloudEventGroupMemberDeletedPreviousObjectMember1":
                onEventStreamCloudEventGroupMemberDeletedPreviousObjectMember1(
                    AsEventStreamCloudEventGroupMemberDeletedPreviousObjectMember1()
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
        if (obj is not EventStreamCloudEventGroupMemberDeletedPreviousObjectMember other)
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

    public static implicit operator EventStreamCloudEventGroupMemberDeletedPreviousObjectMember(
        Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectMember0 value
    ) => new("eventStreamCloudEventGroupMemberDeletedPreviousObjectMember0", value);

    public static implicit operator EventStreamCloudEventGroupMemberDeletedPreviousObjectMember(
        Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectMember1 value
    ) => new("eventStreamCloudEventGroupMemberDeletedPreviousObjectMember1", value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<EventStreamCloudEventGroupMemberDeletedPreviousObjectMember>
    {
        public override EventStreamCloudEventGroupMemberDeletedPreviousObjectMember? Read(
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
                        "eventStreamCloudEventGroupMemberDeletedPreviousObjectMember0",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectMember0)
                    ),
                    (
                        "eventStreamCloudEventGroupMemberDeletedPreviousObjectMember1",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupMemberDeletedPreviousObjectMember1)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamCloudEventGroupMemberDeletedPreviousObjectMember result =
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventGroupMemberDeletedPreviousObjectMember"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupMemberDeletedPreviousObjectMember value,
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

        public override EventStreamCloudEventGroupMemberDeletedPreviousObjectMember ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventGroupMemberDeletedPreviousObjectMember result = new(
                "string",
                stringValue
            );
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupMemberDeletedPreviousObjectMember value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
