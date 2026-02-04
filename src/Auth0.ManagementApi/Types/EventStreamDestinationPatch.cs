// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(EventStreamDestinationPatch.JsonConverter))]
[Serializable]
public class EventStreamDestinationPatch
{
    private EventStreamDestinationPatch(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamWebhookDestination value.
    /// </summary>
    public static EventStreamDestinationPatch FromEventStreamWebhookDestination(
        Auth0.ManagementApi.EventStreamWebhookDestination value
    ) => new("eventStreamWebhookDestination", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamActionDestination value.
    /// </summary>
    public static EventStreamDestinationPatch FromEventStreamActionDestination(
        Auth0.ManagementApi.EventStreamActionDestination value
    ) => new("eventStreamActionDestination", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamWebhookDestination"
    /// </summary>
    public bool IsEventStreamWebhookDestination() => Type == "eventStreamWebhookDestination";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamActionDestination"
    /// </summary>
    public bool IsEventStreamActionDestination() => Type == "eventStreamActionDestination";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamWebhookDestination"/> if <see cref="Type"/> is 'eventStreamWebhookDestination', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamWebhookDestination'.</exception>
    public Auth0.ManagementApi.EventStreamWebhookDestination AsEventStreamWebhookDestination() =>
        IsEventStreamWebhookDestination()
            ? (Auth0.ManagementApi.EventStreamWebhookDestination)Value!
            : throw new ManagementException("Union type is not 'eventStreamWebhookDestination'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamActionDestination"/> if <see cref="Type"/> is 'eventStreamActionDestination', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamActionDestination'.</exception>
    public Auth0.ManagementApi.EventStreamActionDestination AsEventStreamActionDestination() =>
        IsEventStreamActionDestination()
            ? (Auth0.ManagementApi.EventStreamActionDestination)Value!
            : throw new ManagementException("Union type is not 'eventStreamActionDestination'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamWebhookDestination"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamWebhookDestination(
        out Auth0.ManagementApi.EventStreamWebhookDestination? value
    )
    {
        if (Type == "eventStreamWebhookDestination")
        {
            value = (Auth0.ManagementApi.EventStreamWebhookDestination)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamActionDestination"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamActionDestination(
        out Auth0.ManagementApi.EventStreamActionDestination? value
    )
    {
        if (Type == "eventStreamActionDestination")
        {
            value = (Auth0.ManagementApi.EventStreamActionDestination)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Auth0.ManagementApi.EventStreamWebhookDestination, T> onEventStreamWebhookDestination,
        Func<Auth0.ManagementApi.EventStreamActionDestination, T> onEventStreamActionDestination
    )
    {
        return Type switch
        {
            "eventStreamWebhookDestination" => onEventStreamWebhookDestination(
                AsEventStreamWebhookDestination()
            ),
            "eventStreamActionDestination" => onEventStreamActionDestination(
                AsEventStreamActionDestination()
            ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        System.Action<Auth0.ManagementApi.EventStreamWebhookDestination> onEventStreamWebhookDestination,
        System.Action<Auth0.ManagementApi.EventStreamActionDestination> onEventStreamActionDestination
    )
    {
        switch (Type)
        {
            case "eventStreamWebhookDestination":
                onEventStreamWebhookDestination(AsEventStreamWebhookDestination());
                break;
            case "eventStreamActionDestination":
                onEventStreamActionDestination(AsEventStreamActionDestination());
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
        if (obj is not EventStreamDestinationPatch other)
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

    public static implicit operator EventStreamDestinationPatch(
        Auth0.ManagementApi.EventStreamWebhookDestination value
    ) => new("eventStreamWebhookDestination", value);

    public static implicit operator EventStreamDestinationPatch(
        Auth0.ManagementApi.EventStreamActionDestination value
    ) => new("eventStreamActionDestination", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<EventStreamDestinationPatch>
    {
        public override EventStreamDestinationPatch? Read(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
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
                        "eventStreamWebhookDestination",
                        typeof(Auth0.ManagementApi.EventStreamWebhookDestination)
                    ),
                    (
                        "eventStreamActionDestination",
                        typeof(Auth0.ManagementApi.EventStreamActionDestination)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamDestinationPatch result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamDestinationPatch"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamDestinationPatch value,
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

        public override EventStreamDestinationPatch ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamDestinationPatch result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamDestinationPatch value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
