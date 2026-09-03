// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The member that is a part of the group.
/// </summary>
[JsonConverter(typeof(EventStreamCloudEventGroupMemberAddedPreviousObjectMember.JsonConverter))]
[Serializable]
public class EventStreamCloudEventGroupMemberAddedPreviousObjectMember
{
    private EventStreamCloudEventGroupMemberAddedPreviousObjectMember(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectMember0 value.
    /// </summary>
    public static EventStreamCloudEventGroupMemberAddedPreviousObjectMember FromEventStreamCloudEventGroupMemberAddedPreviousObjectMember0(
        Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectMember0 value
    ) => new("eventStreamCloudEventGroupMemberAddedPreviousObjectMember0", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectMember1 value.
    /// </summary>
    public static EventStreamCloudEventGroupMemberAddedPreviousObjectMember FromEventStreamCloudEventGroupMemberAddedPreviousObjectMember1(
        Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectMember1 value
    ) => new("eventStreamCloudEventGroupMemberAddedPreviousObjectMember1", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupMemberAddedPreviousObjectMember0"
    /// </summary>
    public bool IsEventStreamCloudEventGroupMemberAddedPreviousObjectMember0() =>
        Type == "eventStreamCloudEventGroupMemberAddedPreviousObjectMember0";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamCloudEventGroupMemberAddedPreviousObjectMember1"
    /// </summary>
    public bool IsEventStreamCloudEventGroupMemberAddedPreviousObjectMember1() =>
        Type == "eventStreamCloudEventGroupMemberAddedPreviousObjectMember1";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectMember0"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupMemberAddedPreviousObjectMember0', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupMemberAddedPreviousObjectMember0'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectMember0 AsEventStreamCloudEventGroupMemberAddedPreviousObjectMember0() =>
        IsEventStreamCloudEventGroupMemberAddedPreviousObjectMember0()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectMember0)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupMemberAddedPreviousObjectMember0'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectMember1"/> if <see cref="Type"/> is 'eventStreamCloudEventGroupMemberAddedPreviousObjectMember1', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamCloudEventGroupMemberAddedPreviousObjectMember1'.</exception>
    public Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectMember1 AsEventStreamCloudEventGroupMemberAddedPreviousObjectMember1() =>
        IsEventStreamCloudEventGroupMemberAddedPreviousObjectMember1()
            ? (Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectMember1)Value!
            : throw new ManagementException(
                "Union type is not 'eventStreamCloudEventGroupMemberAddedPreviousObjectMember1'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectMember0"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupMemberAddedPreviousObjectMember0(
        out Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectMember0? value
    )
    {
        if (Type == "eventStreamCloudEventGroupMemberAddedPreviousObjectMember0")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectMember0)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectMember1"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamCloudEventGroupMemberAddedPreviousObjectMember1(
        out Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectMember1? value
    )
    {
        if (Type == "eventStreamCloudEventGroupMemberAddedPreviousObjectMember1")
        {
            value = (Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectMember1)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectMember0,
            T
        > onEventStreamCloudEventGroupMemberAddedPreviousObjectMember0,
        Func<
            Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectMember1,
            T
        > onEventStreamCloudEventGroupMemberAddedPreviousObjectMember1
    )
    {
        return Type switch
        {
            "eventStreamCloudEventGroupMemberAddedPreviousObjectMember0" =>
                onEventStreamCloudEventGroupMemberAddedPreviousObjectMember0(
                    AsEventStreamCloudEventGroupMemberAddedPreviousObjectMember0()
                ),
            "eventStreamCloudEventGroupMemberAddedPreviousObjectMember1" =>
                onEventStreamCloudEventGroupMemberAddedPreviousObjectMember1(
                    AsEventStreamCloudEventGroupMemberAddedPreviousObjectMember1()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectMember0> onEventStreamCloudEventGroupMemberAddedPreviousObjectMember0,
        global::System.Action<Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectMember1> onEventStreamCloudEventGroupMemberAddedPreviousObjectMember1
    )
    {
        switch (Type)
        {
            case "eventStreamCloudEventGroupMemberAddedPreviousObjectMember0":
                onEventStreamCloudEventGroupMemberAddedPreviousObjectMember0(
                    AsEventStreamCloudEventGroupMemberAddedPreviousObjectMember0()
                );
                break;
            case "eventStreamCloudEventGroupMemberAddedPreviousObjectMember1":
                onEventStreamCloudEventGroupMemberAddedPreviousObjectMember1(
                    AsEventStreamCloudEventGroupMemberAddedPreviousObjectMember1()
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
        if (obj is not EventStreamCloudEventGroupMemberAddedPreviousObjectMember other)
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

    public static implicit operator EventStreamCloudEventGroupMemberAddedPreviousObjectMember(
        Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectMember0 value
    ) => new("eventStreamCloudEventGroupMemberAddedPreviousObjectMember0", value);

    public static implicit operator EventStreamCloudEventGroupMemberAddedPreviousObjectMember(
        Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectMember1 value
    ) => new("eventStreamCloudEventGroupMemberAddedPreviousObjectMember1", value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<EventStreamCloudEventGroupMemberAddedPreviousObjectMember>
    {
        public override EventStreamCloudEventGroupMemberAddedPreviousObjectMember? Read(
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
                        "eventStreamCloudEventGroupMemberAddedPreviousObjectMember0",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectMember0)
                    ),
                    (
                        "eventStreamCloudEventGroupMemberAddedPreviousObjectMember1",
                        typeof(Auth0.ManagementApi.EventStreamCloudEventGroupMemberAddedPreviousObjectMember1)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamCloudEventGroupMemberAddedPreviousObjectMember result = new(
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventGroupMemberAddedPreviousObjectMember"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupMemberAddedPreviousObjectMember value,
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

        public override EventStreamCloudEventGroupMemberAddedPreviousObjectMember ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventGroupMemberAddedPreviousObjectMember result = new(
                "string",
                stringValue
            );
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventGroupMemberAddedPreviousObjectMember value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
