// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(EventStreamsCreateRequest.JsonConverter))]
[Serializable]
public class EventStreamsCreateRequest
{
    private EventStreamsCreateRequest(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.CreateEventStreamWebHookRequestContent value.
    /// </summary>
    public static EventStreamsCreateRequest FromCreateEventStreamWebHookRequestContent(
        Auth0.ManagementApi.CreateEventStreamWebHookRequestContent value
    ) => new("createEventStreamWebHookRequestContent", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateEventStreamEventBridgeRequestContent value.
    /// </summary>
    public static EventStreamsCreateRequest FromCreateEventStreamEventBridgeRequestContent(
        Auth0.ManagementApi.CreateEventStreamEventBridgeRequestContent value
    ) => new("createEventStreamEventBridgeRequestContent", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateEventStreamActionRequestContent value.
    /// </summary>
    public static EventStreamsCreateRequest FromCreateEventStreamActionRequestContent(
        Auth0.ManagementApi.CreateEventStreamActionRequestContent value
    ) => new("createEventStreamActionRequestContent", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createEventStreamWebHookRequestContent"
    /// </summary>
    public bool IsCreateEventStreamWebHookRequestContent() =>
        Type == "createEventStreamWebHookRequestContent";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createEventStreamEventBridgeRequestContent"
    /// </summary>
    public bool IsCreateEventStreamEventBridgeRequestContent() =>
        Type == "createEventStreamEventBridgeRequestContent";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createEventStreamActionRequestContent"
    /// </summary>
    public bool IsCreateEventStreamActionRequestContent() =>
        Type == "createEventStreamActionRequestContent";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateEventStreamWebHookRequestContent"/> if <see cref="Type"/> is 'createEventStreamWebHookRequestContent', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createEventStreamWebHookRequestContent'.</exception>
    public Auth0.ManagementApi.CreateEventStreamWebHookRequestContent AsCreateEventStreamWebHookRequestContent() =>
        IsCreateEventStreamWebHookRequestContent()
            ? (Auth0.ManagementApi.CreateEventStreamWebHookRequestContent)Value!
            : throw new ManagementException(
                "Union type is not 'createEventStreamWebHookRequestContent'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateEventStreamEventBridgeRequestContent"/> if <see cref="Type"/> is 'createEventStreamEventBridgeRequestContent', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createEventStreamEventBridgeRequestContent'.</exception>
    public Auth0.ManagementApi.CreateEventStreamEventBridgeRequestContent AsCreateEventStreamEventBridgeRequestContent() =>
        IsCreateEventStreamEventBridgeRequestContent()
            ? (Auth0.ManagementApi.CreateEventStreamEventBridgeRequestContent)Value!
            : throw new ManagementException(
                "Union type is not 'createEventStreamEventBridgeRequestContent'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateEventStreamActionRequestContent"/> if <see cref="Type"/> is 'createEventStreamActionRequestContent', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createEventStreamActionRequestContent'.</exception>
    public Auth0.ManagementApi.CreateEventStreamActionRequestContent AsCreateEventStreamActionRequestContent() =>
        IsCreateEventStreamActionRequestContent()
            ? (Auth0.ManagementApi.CreateEventStreamActionRequestContent)Value!
            : throw new ManagementException(
                "Union type is not 'createEventStreamActionRequestContent'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateEventStreamWebHookRequestContent"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateEventStreamWebHookRequestContent(
        out Auth0.ManagementApi.CreateEventStreamWebHookRequestContent? value
    )
    {
        if (Type == "createEventStreamWebHookRequestContent")
        {
            value = (Auth0.ManagementApi.CreateEventStreamWebHookRequestContent)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateEventStreamEventBridgeRequestContent"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateEventStreamEventBridgeRequestContent(
        out Auth0.ManagementApi.CreateEventStreamEventBridgeRequestContent? value
    )
    {
        if (Type == "createEventStreamEventBridgeRequestContent")
        {
            value = (Auth0.ManagementApi.CreateEventStreamEventBridgeRequestContent)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateEventStreamActionRequestContent"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateEventStreamActionRequestContent(
        out Auth0.ManagementApi.CreateEventStreamActionRequestContent? value
    )
    {
        if (Type == "createEventStreamActionRequestContent")
        {
            value = (Auth0.ManagementApi.CreateEventStreamActionRequestContent)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.CreateEventStreamWebHookRequestContent,
            T
        > onCreateEventStreamWebHookRequestContent,
        Func<
            Auth0.ManagementApi.CreateEventStreamEventBridgeRequestContent,
            T
        > onCreateEventStreamEventBridgeRequestContent,
        Func<
            Auth0.ManagementApi.CreateEventStreamActionRequestContent,
            T
        > onCreateEventStreamActionRequestContent
    )
    {
        return Type switch
        {
            "createEventStreamWebHookRequestContent" => onCreateEventStreamWebHookRequestContent(
                AsCreateEventStreamWebHookRequestContent()
            ),
            "createEventStreamEventBridgeRequestContent" =>
                onCreateEventStreamEventBridgeRequestContent(
                    AsCreateEventStreamEventBridgeRequestContent()
                ),
            "createEventStreamActionRequestContent" => onCreateEventStreamActionRequestContent(
                AsCreateEventStreamActionRequestContent()
            ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.CreateEventStreamWebHookRequestContent> onCreateEventStreamWebHookRequestContent,
        global::System.Action<Auth0.ManagementApi.CreateEventStreamEventBridgeRequestContent> onCreateEventStreamEventBridgeRequestContent,
        global::System.Action<Auth0.ManagementApi.CreateEventStreamActionRequestContent> onCreateEventStreamActionRequestContent
    )
    {
        switch (Type)
        {
            case "createEventStreamWebHookRequestContent":
                onCreateEventStreamWebHookRequestContent(
                    AsCreateEventStreamWebHookRequestContent()
                );
                break;
            case "createEventStreamEventBridgeRequestContent":
                onCreateEventStreamEventBridgeRequestContent(
                    AsCreateEventStreamEventBridgeRequestContent()
                );
                break;
            case "createEventStreamActionRequestContent":
                onCreateEventStreamActionRequestContent(AsCreateEventStreamActionRequestContent());
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
        if (obj is not EventStreamsCreateRequest other)
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

    public static implicit operator EventStreamsCreateRequest(
        Auth0.ManagementApi.CreateEventStreamWebHookRequestContent value
    ) => new("createEventStreamWebHookRequestContent", value);

    public static implicit operator EventStreamsCreateRequest(
        Auth0.ManagementApi.CreateEventStreamEventBridgeRequestContent value
    ) => new("createEventStreamEventBridgeRequestContent", value);

    public static implicit operator EventStreamsCreateRequest(
        Auth0.ManagementApi.CreateEventStreamActionRequestContent value
    ) => new("createEventStreamActionRequestContent", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<EventStreamsCreateRequest>
    {
        public override EventStreamsCreateRequest? Read(
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
                        "createEventStreamWebHookRequestContent",
                        typeof(Auth0.ManagementApi.CreateEventStreamWebHookRequestContent)
                    ),
                    (
                        "createEventStreamEventBridgeRequestContent",
                        typeof(Auth0.ManagementApi.CreateEventStreamEventBridgeRequestContent)
                    ),
                    (
                        "createEventStreamActionRequestContent",
                        typeof(Auth0.ManagementApi.CreateEventStreamActionRequestContent)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EventStreamsCreateRequest result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamsCreateRequest"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamsCreateRequest value,
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

        public override EventStreamsCreateRequest ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamsCreateRequest result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamsCreateRequest value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
