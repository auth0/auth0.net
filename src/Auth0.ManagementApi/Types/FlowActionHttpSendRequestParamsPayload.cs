// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionHttpSendRequestParamsPayload.JsonConverter))]
[Serializable]
public class FlowActionHttpSendRequestParamsPayload
{
    private FlowActionHttpSendRequestParamsPayload(string type, object? value)
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
    /// Factory method to create a union from a string value.
    /// </summary>
    public static FlowActionHttpSendRequestParamsPayload FromString(string value) =>
        new("string", value);

    /// <summary>
    /// Factory method to create a union from a IEnumerable<object> value.
    /// </summary>
    public static FlowActionHttpSendRequestParamsPayload FromListOfUnknown(
        IEnumerable<object> value
    ) => new("list", value);

    /// <summary>
    /// Factory method to create a union from a Dictionary<string, object?> value.
    /// </summary>
    public static FlowActionHttpSendRequestParamsPayload FromFlowActionHttpSendRequestParamsPayloadObject(
        Dictionary<string, object?> value
    ) => new("flowActionHttpSendRequestParamsPayloadObject", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "string"
    /// </summary>
    public bool IsString() => Type == "string";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "list"
    /// </summary>
    public bool IsListOfUnknown() => Type == "list";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionHttpSendRequestParamsPayloadObject"
    /// </summary>
    public bool IsFlowActionHttpSendRequestParamsPayloadObject() =>
        Type == "flowActionHttpSendRequestParamsPayloadObject";

    /// <summary>
    /// Returns the value as a <see cref="string"/> if <see cref="Type"/> is 'string', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'string'.</exception>
    public string AsString() =>
        IsString() ? (string)Value! : throw new ManagementException("Union type is not 'string'");

    /// <summary>
    /// Returns the value as a <see cref="IEnumerable<object>"/> if <see cref="Type"/> is 'list', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'list'.</exception>
    public IEnumerable<object> AsListOfUnknown() =>
        IsListOfUnknown()
            ? (IEnumerable<object>)Value!
            : throw new ManagementException("Union type is not 'list'");

    /// <summary>
    /// Returns the value as a <see cref="Dictionary<string, object?>"/> if <see cref="Type"/> is 'flowActionHttpSendRequestParamsPayloadObject', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionHttpSendRequestParamsPayloadObject'.</exception>
    public Dictionary<string, object?> AsFlowActionHttpSendRequestParamsPayloadObject() =>
        IsFlowActionHttpSendRequestParamsPayloadObject()
            ? (Dictionary<string, object?>)Value!
            : throw new ManagementException(
                "Union type is not 'flowActionHttpSendRequestParamsPayloadObject'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="string"/> and returns true if successful.
    /// </summary>
    public bool TryGetString(out string? value)
    {
        if (Type == "string")
        {
            value = (string)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="IEnumerable<object>"/> and returns true if successful.
    /// </summary>
    public bool TryGetListOfUnknown(out IEnumerable<object>? value)
    {
        if (Type == "list")
        {
            value = (IEnumerable<object>)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Dictionary<string, object?>"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionHttpSendRequestParamsPayloadObject(
        out Dictionary<string, object?>? value
    )
    {
        if (Type == "flowActionHttpSendRequestParamsPayloadObject")
        {
            value = (Dictionary<string, object?>)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<string, T> onString,
        Func<IEnumerable<object>, T> onListOfUnknown,
        Func<Dictionary<string, object?>, T> onFlowActionHttpSendRequestParamsPayloadObject
    )
    {
        return Type switch
        {
            "string" => onString(AsString()),
            "list" => onListOfUnknown(AsListOfUnknown()),
            "flowActionHttpSendRequestParamsPayloadObject" =>
                onFlowActionHttpSendRequestParamsPayloadObject(
                    AsFlowActionHttpSendRequestParamsPayloadObject()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<string> onString,
        global::System.Action<IEnumerable<object>> onListOfUnknown,
        global::System.Action<
            Dictionary<string, object?>
        > onFlowActionHttpSendRequestParamsPayloadObject
    )
    {
        switch (Type)
        {
            case "string":
                onString(AsString());
                break;
            case "list":
                onListOfUnknown(AsListOfUnknown());
                break;
            case "flowActionHttpSendRequestParamsPayloadObject":
                onFlowActionHttpSendRequestParamsPayloadObject(
                    AsFlowActionHttpSendRequestParamsPayloadObject()
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
        if (obj is not FlowActionHttpSendRequestParamsPayload other)
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

    public static implicit operator FlowActionHttpSendRequestParamsPayload(string value) =>
        new("string", value);

    public static implicit operator FlowActionHttpSendRequestParamsPayload(
        Dictionary<string, object?> value
    ) => new("flowActionHttpSendRequestParamsPayloadObject", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<FlowActionHttpSendRequestParamsPayload>
    {
        public override FlowActionHttpSendRequestParamsPayload? Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            if (reader.TokenType == JsonTokenType.String)
            {
                var stringValue = reader.GetString()!;

                FlowActionHttpSendRequestParamsPayload stringResult = new("string", stringValue);
                return stringResult;
            }

            if (reader.TokenType == JsonTokenType.StartArray)
            {
                var document = JsonDocument.ParseValue(ref reader);

                var types = new (string Key, System.Type Type)[]
                {
                    ("list", typeof(IEnumerable<object>)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            FlowActionHttpSendRequestParamsPayload result = new(key, value);
                            return result;
                        }
                    }
                    catch (JsonException)
                    {
                        // Try next type;
                    }
                }
            }

            if (reader.TokenType == JsonTokenType.StartObject)
            {
                var document = JsonDocument.ParseValue(ref reader);

                var types = new (string Key, System.Type Type)[]
                {
                    (
                        "flowActionHttpSendRequestParamsPayloadObject",
                        typeof(Dictionary<string, object?>)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            FlowActionHttpSendRequestParamsPayload result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into FlowActionHttpSendRequestParamsPayload"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionHttpSendRequestParamsPayload value,
            JsonSerializerOptions options
        )
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            value.Visit(
                str => writer.WriteStringValue(str),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override FlowActionHttpSendRequestParamsPayload ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            FlowActionHttpSendRequestParamsPayload result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionHttpSendRequestParamsPayload value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
