// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(EventStreamWebhookAuthorizationResponse.JsonConverter))]
[Serializable]
public class EventStreamWebhookAuthorizationResponse
{
    private EventStreamWebhookAuthorizationResponse(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamWebhookBasicAuth value.
    /// </summary>
    public static EventStreamWebhookAuthorizationResponse FromEventStreamWebhookBasicAuth(
        Auth0.ManagementApi.EventStreamWebhookBasicAuth value
    ) => new("eventStreamWebhookBasicAuth", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EventStreamWebhookBearerAuth value.
    /// </summary>
    public static EventStreamWebhookAuthorizationResponse FromEventStreamWebhookBearerAuth(
        Auth0.ManagementApi.EventStreamWebhookBearerAuth value
    ) => new("eventStreamWebhookBearerAuth", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamWebhookBasicAuth"
    /// </summary>
    public bool IsEventStreamWebhookBasicAuth() => Type == "eventStreamWebhookBasicAuth";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "eventStreamWebhookBearerAuth"
    /// </summary>
    public bool IsEventStreamWebhookBearerAuth() => Type == "eventStreamWebhookBearerAuth";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamWebhookBasicAuth"/> if <see cref="Type"/> is 'eventStreamWebhookBasicAuth', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamWebhookBasicAuth'.</exception>
    public Auth0.ManagementApi.EventStreamWebhookBasicAuth AsEventStreamWebhookBasicAuth() =>
        IsEventStreamWebhookBasicAuth()
            ? (Auth0.ManagementApi.EventStreamWebhookBasicAuth)Value!
            : throw new ManagementException("Union type is not 'eventStreamWebhookBasicAuth'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EventStreamWebhookBearerAuth"/> if <see cref="Type"/> is 'eventStreamWebhookBearerAuth', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'eventStreamWebhookBearerAuth'.</exception>
    public Auth0.ManagementApi.EventStreamWebhookBearerAuth AsEventStreamWebhookBearerAuth() =>
        IsEventStreamWebhookBearerAuth()
            ? (Auth0.ManagementApi.EventStreamWebhookBearerAuth)Value!
            : throw new ManagementException("Union type is not 'eventStreamWebhookBearerAuth'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamWebhookBasicAuth"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamWebhookBasicAuth(
        out Auth0.ManagementApi.EventStreamWebhookBasicAuth? value
    )
    {
        if (Type == "eventStreamWebhookBasicAuth")
        {
            value = (Auth0.ManagementApi.EventStreamWebhookBasicAuth)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EventStreamWebhookBearerAuth"/> and returns true if successful.
    /// </summary>
    public bool TryGetEventStreamWebhookBearerAuth(
        out Auth0.ManagementApi.EventStreamWebhookBearerAuth? value
    )
    {
        if (Type == "eventStreamWebhookBearerAuth")
        {
            value = (Auth0.ManagementApi.EventStreamWebhookBearerAuth)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Auth0.ManagementApi.EventStreamWebhookBasicAuth, T> onEventStreamWebhookBasicAuth,
        Func<Auth0.ManagementApi.EventStreamWebhookBearerAuth, T> onEventStreamWebhookBearerAuth
    )
    {
        return Type switch
        {
            "eventStreamWebhookBasicAuth" => onEventStreamWebhookBasicAuth(
                AsEventStreamWebhookBasicAuth()
            ),
            "eventStreamWebhookBearerAuth" => onEventStreamWebhookBearerAuth(
                AsEventStreamWebhookBearerAuth()
            ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EventStreamWebhookBasicAuth> onEventStreamWebhookBasicAuth,
        global::System.Action<Auth0.ManagementApi.EventStreamWebhookBearerAuth> onEventStreamWebhookBearerAuth
    )
    {
        switch (Type)
        {
            case "eventStreamWebhookBasicAuth":
                onEventStreamWebhookBasicAuth(AsEventStreamWebhookBasicAuth());
                break;
            case "eventStreamWebhookBearerAuth":
                onEventStreamWebhookBearerAuth(AsEventStreamWebhookBearerAuth());
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
        if (obj is not EventStreamWebhookAuthorizationResponse other)
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

    public static implicit operator EventStreamWebhookAuthorizationResponse(
        Auth0.ManagementApi.EventStreamWebhookBasicAuth value
    ) => new("eventStreamWebhookBasicAuth", value);

    public static implicit operator EventStreamWebhookAuthorizationResponse(
        Auth0.ManagementApi.EventStreamWebhookBearerAuth value
    ) => new("eventStreamWebhookBearerAuth", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<EventStreamWebhookAuthorizationResponse>
    {
        public override EventStreamWebhookAuthorizationResponse? Read(
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
                        "eventStreamWebhookBasicAuth",
                        typeof(Auth0.ManagementApi.EventStreamWebhookBasicAuth)
                    ),
                    (
                        "eventStreamWebhookBearerAuth",
                        typeof(Auth0.ManagementApi.EventStreamWebhookBearerAuth)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamWebhookAuthorizationResponse result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamWebhookAuthorizationResponse"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamWebhookAuthorizationResponse value,
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

        public override EventStreamWebhookAuthorizationResponse ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamWebhookAuthorizationResponse result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamWebhookAuthorizationResponse value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
