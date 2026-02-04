// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(CreateLogStreamRequestContent.JsonConverter))]
[Serializable]
public class CreateLogStreamRequestContent
{
    private CreateLogStreamRequestContent(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.CreateLogStreamHttpRequestBody value.
    /// </summary>
    public static CreateLogStreamRequestContent FromCreateLogStreamHttpRequestBody(
        Auth0.ManagementApi.CreateLogStreamHttpRequestBody value
    ) => new("createLogStreamHttpRequestBody", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateLogStreamEventBridgeRequestBody value.
    /// </summary>
    public static CreateLogStreamRequestContent FromCreateLogStreamEventBridgeRequestBody(
        Auth0.ManagementApi.CreateLogStreamEventBridgeRequestBody value
    ) => new("createLogStreamEventBridgeRequestBody", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateLogStreamEventGridRequestBody value.
    /// </summary>
    public static CreateLogStreamRequestContent FromCreateLogStreamEventGridRequestBody(
        Auth0.ManagementApi.CreateLogStreamEventGridRequestBody value
    ) => new("createLogStreamEventGridRequestBody", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateLogStreamDatadogRequestBody value.
    /// </summary>
    public static CreateLogStreamRequestContent FromCreateLogStreamDatadogRequestBody(
        Auth0.ManagementApi.CreateLogStreamDatadogRequestBody value
    ) => new("createLogStreamDatadogRequestBody", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateLogStreamSplunkRequestBody value.
    /// </summary>
    public static CreateLogStreamRequestContent FromCreateLogStreamSplunkRequestBody(
        Auth0.ManagementApi.CreateLogStreamSplunkRequestBody value
    ) => new("createLogStreamSplunkRequestBody", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateLogStreamSumoRequestBody value.
    /// </summary>
    public static CreateLogStreamRequestContent FromCreateLogStreamSumoRequestBody(
        Auth0.ManagementApi.CreateLogStreamSumoRequestBody value
    ) => new("createLogStreamSumoRequestBody", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateLogStreamSegmentRequestBody value.
    /// </summary>
    public static CreateLogStreamRequestContent FromCreateLogStreamSegmentRequestBody(
        Auth0.ManagementApi.CreateLogStreamSegmentRequestBody value
    ) => new("createLogStreamSegmentRequestBody", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateLogStreamMixpanelRequestBody value.
    /// </summary>
    public static CreateLogStreamRequestContent FromCreateLogStreamMixpanelRequestBody(
        Auth0.ManagementApi.CreateLogStreamMixpanelRequestBody value
    ) => new("createLogStreamMixpanelRequestBody", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createLogStreamHttpRequestBody"
    /// </summary>
    public bool IsCreateLogStreamHttpRequestBody() => Type == "createLogStreamHttpRequestBody";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createLogStreamEventBridgeRequestBody"
    /// </summary>
    public bool IsCreateLogStreamEventBridgeRequestBody() =>
        Type == "createLogStreamEventBridgeRequestBody";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createLogStreamEventGridRequestBody"
    /// </summary>
    public bool IsCreateLogStreamEventGridRequestBody() =>
        Type == "createLogStreamEventGridRequestBody";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createLogStreamDatadogRequestBody"
    /// </summary>
    public bool IsCreateLogStreamDatadogRequestBody() =>
        Type == "createLogStreamDatadogRequestBody";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createLogStreamSplunkRequestBody"
    /// </summary>
    public bool IsCreateLogStreamSplunkRequestBody() => Type == "createLogStreamSplunkRequestBody";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createLogStreamSumoRequestBody"
    /// </summary>
    public bool IsCreateLogStreamSumoRequestBody() => Type == "createLogStreamSumoRequestBody";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createLogStreamSegmentRequestBody"
    /// </summary>
    public bool IsCreateLogStreamSegmentRequestBody() =>
        Type == "createLogStreamSegmentRequestBody";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createLogStreamMixpanelRequestBody"
    /// </summary>
    public bool IsCreateLogStreamMixpanelRequestBody() =>
        Type == "createLogStreamMixpanelRequestBody";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateLogStreamHttpRequestBody"/> if <see cref="Type"/> is 'createLogStreamHttpRequestBody', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createLogStreamHttpRequestBody'.</exception>
    public Auth0.ManagementApi.CreateLogStreamHttpRequestBody AsCreateLogStreamHttpRequestBody() =>
        IsCreateLogStreamHttpRequestBody()
            ? (Auth0.ManagementApi.CreateLogStreamHttpRequestBody)Value!
            : throw new ManagementException("Union type is not 'createLogStreamHttpRequestBody'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateLogStreamEventBridgeRequestBody"/> if <see cref="Type"/> is 'createLogStreamEventBridgeRequestBody', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createLogStreamEventBridgeRequestBody'.</exception>
    public Auth0.ManagementApi.CreateLogStreamEventBridgeRequestBody AsCreateLogStreamEventBridgeRequestBody() =>
        IsCreateLogStreamEventBridgeRequestBody()
            ? (Auth0.ManagementApi.CreateLogStreamEventBridgeRequestBody)Value!
            : throw new ManagementException(
                "Union type is not 'createLogStreamEventBridgeRequestBody'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateLogStreamEventGridRequestBody"/> if <see cref="Type"/> is 'createLogStreamEventGridRequestBody', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createLogStreamEventGridRequestBody'.</exception>
    public Auth0.ManagementApi.CreateLogStreamEventGridRequestBody AsCreateLogStreamEventGridRequestBody() =>
        IsCreateLogStreamEventGridRequestBody()
            ? (Auth0.ManagementApi.CreateLogStreamEventGridRequestBody)Value!
            : throw new ManagementException(
                "Union type is not 'createLogStreamEventGridRequestBody'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateLogStreamDatadogRequestBody"/> if <see cref="Type"/> is 'createLogStreamDatadogRequestBody', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createLogStreamDatadogRequestBody'.</exception>
    public Auth0.ManagementApi.CreateLogStreamDatadogRequestBody AsCreateLogStreamDatadogRequestBody() =>
        IsCreateLogStreamDatadogRequestBody()
            ? (Auth0.ManagementApi.CreateLogStreamDatadogRequestBody)Value!
            : throw new ManagementException(
                "Union type is not 'createLogStreamDatadogRequestBody'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateLogStreamSplunkRequestBody"/> if <see cref="Type"/> is 'createLogStreamSplunkRequestBody', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createLogStreamSplunkRequestBody'.</exception>
    public Auth0.ManagementApi.CreateLogStreamSplunkRequestBody AsCreateLogStreamSplunkRequestBody() =>
        IsCreateLogStreamSplunkRequestBody()
            ? (Auth0.ManagementApi.CreateLogStreamSplunkRequestBody)Value!
            : throw new ManagementException("Union type is not 'createLogStreamSplunkRequestBody'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateLogStreamSumoRequestBody"/> if <see cref="Type"/> is 'createLogStreamSumoRequestBody', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createLogStreamSumoRequestBody'.</exception>
    public Auth0.ManagementApi.CreateLogStreamSumoRequestBody AsCreateLogStreamSumoRequestBody() =>
        IsCreateLogStreamSumoRequestBody()
            ? (Auth0.ManagementApi.CreateLogStreamSumoRequestBody)Value!
            : throw new ManagementException("Union type is not 'createLogStreamSumoRequestBody'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateLogStreamSegmentRequestBody"/> if <see cref="Type"/> is 'createLogStreamSegmentRequestBody', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createLogStreamSegmentRequestBody'.</exception>
    public Auth0.ManagementApi.CreateLogStreamSegmentRequestBody AsCreateLogStreamSegmentRequestBody() =>
        IsCreateLogStreamSegmentRequestBody()
            ? (Auth0.ManagementApi.CreateLogStreamSegmentRequestBody)Value!
            : throw new ManagementException(
                "Union type is not 'createLogStreamSegmentRequestBody'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateLogStreamMixpanelRequestBody"/> if <see cref="Type"/> is 'createLogStreamMixpanelRequestBody', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createLogStreamMixpanelRequestBody'.</exception>
    public Auth0.ManagementApi.CreateLogStreamMixpanelRequestBody AsCreateLogStreamMixpanelRequestBody() =>
        IsCreateLogStreamMixpanelRequestBody()
            ? (Auth0.ManagementApi.CreateLogStreamMixpanelRequestBody)Value!
            : throw new ManagementException(
                "Union type is not 'createLogStreamMixpanelRequestBody'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateLogStreamHttpRequestBody"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateLogStreamHttpRequestBody(
        out Auth0.ManagementApi.CreateLogStreamHttpRequestBody? value
    )
    {
        if (Type == "createLogStreamHttpRequestBody")
        {
            value = (Auth0.ManagementApi.CreateLogStreamHttpRequestBody)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateLogStreamEventBridgeRequestBody"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateLogStreamEventBridgeRequestBody(
        out Auth0.ManagementApi.CreateLogStreamEventBridgeRequestBody? value
    )
    {
        if (Type == "createLogStreamEventBridgeRequestBody")
        {
            value = (Auth0.ManagementApi.CreateLogStreamEventBridgeRequestBody)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateLogStreamEventGridRequestBody"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateLogStreamEventGridRequestBody(
        out Auth0.ManagementApi.CreateLogStreamEventGridRequestBody? value
    )
    {
        if (Type == "createLogStreamEventGridRequestBody")
        {
            value = (Auth0.ManagementApi.CreateLogStreamEventGridRequestBody)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateLogStreamDatadogRequestBody"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateLogStreamDatadogRequestBody(
        out Auth0.ManagementApi.CreateLogStreamDatadogRequestBody? value
    )
    {
        if (Type == "createLogStreamDatadogRequestBody")
        {
            value = (Auth0.ManagementApi.CreateLogStreamDatadogRequestBody)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateLogStreamSplunkRequestBody"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateLogStreamSplunkRequestBody(
        out Auth0.ManagementApi.CreateLogStreamSplunkRequestBody? value
    )
    {
        if (Type == "createLogStreamSplunkRequestBody")
        {
            value = (Auth0.ManagementApi.CreateLogStreamSplunkRequestBody)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateLogStreamSumoRequestBody"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateLogStreamSumoRequestBody(
        out Auth0.ManagementApi.CreateLogStreamSumoRequestBody? value
    )
    {
        if (Type == "createLogStreamSumoRequestBody")
        {
            value = (Auth0.ManagementApi.CreateLogStreamSumoRequestBody)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateLogStreamSegmentRequestBody"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateLogStreamSegmentRequestBody(
        out Auth0.ManagementApi.CreateLogStreamSegmentRequestBody? value
    )
    {
        if (Type == "createLogStreamSegmentRequestBody")
        {
            value = (Auth0.ManagementApi.CreateLogStreamSegmentRequestBody)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateLogStreamMixpanelRequestBody"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateLogStreamMixpanelRequestBody(
        out Auth0.ManagementApi.CreateLogStreamMixpanelRequestBody? value
    )
    {
        if (Type == "createLogStreamMixpanelRequestBody")
        {
            value = (Auth0.ManagementApi.CreateLogStreamMixpanelRequestBody)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.CreateLogStreamHttpRequestBody,
            T
        > onCreateLogStreamHttpRequestBody,
        Func<
            Auth0.ManagementApi.CreateLogStreamEventBridgeRequestBody,
            T
        > onCreateLogStreamEventBridgeRequestBody,
        Func<
            Auth0.ManagementApi.CreateLogStreamEventGridRequestBody,
            T
        > onCreateLogStreamEventGridRequestBody,
        Func<
            Auth0.ManagementApi.CreateLogStreamDatadogRequestBody,
            T
        > onCreateLogStreamDatadogRequestBody,
        Func<
            Auth0.ManagementApi.CreateLogStreamSplunkRequestBody,
            T
        > onCreateLogStreamSplunkRequestBody,
        Func<
            Auth0.ManagementApi.CreateLogStreamSumoRequestBody,
            T
        > onCreateLogStreamSumoRequestBody,
        Func<
            Auth0.ManagementApi.CreateLogStreamSegmentRequestBody,
            T
        > onCreateLogStreamSegmentRequestBody,
        Func<
            Auth0.ManagementApi.CreateLogStreamMixpanelRequestBody,
            T
        > onCreateLogStreamMixpanelRequestBody
    )
    {
        return Type switch
        {
            "createLogStreamHttpRequestBody" => onCreateLogStreamHttpRequestBody(
                AsCreateLogStreamHttpRequestBody()
            ),
            "createLogStreamEventBridgeRequestBody" => onCreateLogStreamEventBridgeRequestBody(
                AsCreateLogStreamEventBridgeRequestBody()
            ),
            "createLogStreamEventGridRequestBody" => onCreateLogStreamEventGridRequestBody(
                AsCreateLogStreamEventGridRequestBody()
            ),
            "createLogStreamDatadogRequestBody" => onCreateLogStreamDatadogRequestBody(
                AsCreateLogStreamDatadogRequestBody()
            ),
            "createLogStreamSplunkRequestBody" => onCreateLogStreamSplunkRequestBody(
                AsCreateLogStreamSplunkRequestBody()
            ),
            "createLogStreamSumoRequestBody" => onCreateLogStreamSumoRequestBody(
                AsCreateLogStreamSumoRequestBody()
            ),
            "createLogStreamSegmentRequestBody" => onCreateLogStreamSegmentRequestBody(
                AsCreateLogStreamSegmentRequestBody()
            ),
            "createLogStreamMixpanelRequestBody" => onCreateLogStreamMixpanelRequestBody(
                AsCreateLogStreamMixpanelRequestBody()
            ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        System.Action<Auth0.ManagementApi.CreateLogStreamHttpRequestBody> onCreateLogStreamHttpRequestBody,
        System.Action<Auth0.ManagementApi.CreateLogStreamEventBridgeRequestBody> onCreateLogStreamEventBridgeRequestBody,
        System.Action<Auth0.ManagementApi.CreateLogStreamEventGridRequestBody> onCreateLogStreamEventGridRequestBody,
        System.Action<Auth0.ManagementApi.CreateLogStreamDatadogRequestBody> onCreateLogStreamDatadogRequestBody,
        System.Action<Auth0.ManagementApi.CreateLogStreamSplunkRequestBody> onCreateLogStreamSplunkRequestBody,
        System.Action<Auth0.ManagementApi.CreateLogStreamSumoRequestBody> onCreateLogStreamSumoRequestBody,
        System.Action<Auth0.ManagementApi.CreateLogStreamSegmentRequestBody> onCreateLogStreamSegmentRequestBody,
        System.Action<Auth0.ManagementApi.CreateLogStreamMixpanelRequestBody> onCreateLogStreamMixpanelRequestBody
    )
    {
        switch (Type)
        {
            case "createLogStreamHttpRequestBody":
                onCreateLogStreamHttpRequestBody(AsCreateLogStreamHttpRequestBody());
                break;
            case "createLogStreamEventBridgeRequestBody":
                onCreateLogStreamEventBridgeRequestBody(AsCreateLogStreamEventBridgeRequestBody());
                break;
            case "createLogStreamEventGridRequestBody":
                onCreateLogStreamEventGridRequestBody(AsCreateLogStreamEventGridRequestBody());
                break;
            case "createLogStreamDatadogRequestBody":
                onCreateLogStreamDatadogRequestBody(AsCreateLogStreamDatadogRequestBody());
                break;
            case "createLogStreamSplunkRequestBody":
                onCreateLogStreamSplunkRequestBody(AsCreateLogStreamSplunkRequestBody());
                break;
            case "createLogStreamSumoRequestBody":
                onCreateLogStreamSumoRequestBody(AsCreateLogStreamSumoRequestBody());
                break;
            case "createLogStreamSegmentRequestBody":
                onCreateLogStreamSegmentRequestBody(AsCreateLogStreamSegmentRequestBody());
                break;
            case "createLogStreamMixpanelRequestBody":
                onCreateLogStreamMixpanelRequestBody(AsCreateLogStreamMixpanelRequestBody());
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
        if (obj is not CreateLogStreamRequestContent other)
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

    public static implicit operator CreateLogStreamRequestContent(
        Auth0.ManagementApi.CreateLogStreamHttpRequestBody value
    ) => new("createLogStreamHttpRequestBody", value);

    public static implicit operator CreateLogStreamRequestContent(
        Auth0.ManagementApi.CreateLogStreamEventBridgeRequestBody value
    ) => new("createLogStreamEventBridgeRequestBody", value);

    public static implicit operator CreateLogStreamRequestContent(
        Auth0.ManagementApi.CreateLogStreamEventGridRequestBody value
    ) => new("createLogStreamEventGridRequestBody", value);

    public static implicit operator CreateLogStreamRequestContent(
        Auth0.ManagementApi.CreateLogStreamDatadogRequestBody value
    ) => new("createLogStreamDatadogRequestBody", value);

    public static implicit operator CreateLogStreamRequestContent(
        Auth0.ManagementApi.CreateLogStreamSplunkRequestBody value
    ) => new("createLogStreamSplunkRequestBody", value);

    public static implicit operator CreateLogStreamRequestContent(
        Auth0.ManagementApi.CreateLogStreamSumoRequestBody value
    ) => new("createLogStreamSumoRequestBody", value);

    public static implicit operator CreateLogStreamRequestContent(
        Auth0.ManagementApi.CreateLogStreamSegmentRequestBody value
    ) => new("createLogStreamSegmentRequestBody", value);

    public static implicit operator CreateLogStreamRequestContent(
        Auth0.ManagementApi.CreateLogStreamMixpanelRequestBody value
    ) => new("createLogStreamMixpanelRequestBody", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CreateLogStreamRequestContent>
    {
        public override CreateLogStreamRequestContent? Read(
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
                        "createLogStreamHttpRequestBody",
                        typeof(Auth0.ManagementApi.CreateLogStreamHttpRequestBody)
                    ),
                    (
                        "createLogStreamEventBridgeRequestBody",
                        typeof(Auth0.ManagementApi.CreateLogStreamEventBridgeRequestBody)
                    ),
                    (
                        "createLogStreamEventGridRequestBody",
                        typeof(Auth0.ManagementApi.CreateLogStreamEventGridRequestBody)
                    ),
                    (
                        "createLogStreamDatadogRequestBody",
                        typeof(Auth0.ManagementApi.CreateLogStreamDatadogRequestBody)
                    ),
                    (
                        "createLogStreamSplunkRequestBody",
                        typeof(Auth0.ManagementApi.CreateLogStreamSplunkRequestBody)
                    ),
                    (
                        "createLogStreamSumoRequestBody",
                        typeof(Auth0.ManagementApi.CreateLogStreamSumoRequestBody)
                    ),
                    (
                        "createLogStreamSegmentRequestBody",
                        typeof(Auth0.ManagementApi.CreateLogStreamSegmentRequestBody)
                    ),
                    (
                        "createLogStreamMixpanelRequestBody",
                        typeof(Auth0.ManagementApi.CreateLogStreamMixpanelRequestBody)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            CreateLogStreamRequestContent result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into CreateLogStreamRequestContent"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateLogStreamRequestContent value,
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
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override CreateLogStreamRequestContent ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            CreateLogStreamRequestContent result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateLogStreamRequestContent value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
