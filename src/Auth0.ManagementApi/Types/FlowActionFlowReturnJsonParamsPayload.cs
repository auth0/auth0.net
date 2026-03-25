// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionFlowReturnJsonParamsPayload.JsonConverter))]
[Serializable]
public class FlowActionFlowReturnJsonParamsPayload
{
    private FlowActionFlowReturnJsonParamsPayload(string type, object? value)
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
    /// Factory method to create a union from a Dictionary<string, object?> value.
    /// </summary>
    public static FlowActionFlowReturnJsonParamsPayload FromFlowActionFlowReturnJsonParamsPayloadObject(
        Dictionary<string, object?> value
    ) => new("flowActionFlowReturnJsonParamsPayloadObject", value);

    /// <summary>
    /// Factory method to create a union from a string value.
    /// </summary>
    public static FlowActionFlowReturnJsonParamsPayload FromString(string value) =>
        new("string", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionFlowReturnJsonParamsPayloadObject"
    /// </summary>
    public bool IsFlowActionFlowReturnJsonParamsPayloadObject() =>
        Type == "flowActionFlowReturnJsonParamsPayloadObject";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "string"
    /// </summary>
    public bool IsString() => Type == "string";

    /// <summary>
    /// Returns the value as a <see cref="Dictionary<string, object?>"/> if <see cref="Type"/> is 'flowActionFlowReturnJsonParamsPayloadObject', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionFlowReturnJsonParamsPayloadObject'.</exception>
    public Dictionary<string, object?> AsFlowActionFlowReturnJsonParamsPayloadObject() =>
        IsFlowActionFlowReturnJsonParamsPayloadObject()
            ? (Dictionary<string, object?>)Value!
            : throw new ManagementException(
                "Union type is not 'flowActionFlowReturnJsonParamsPayloadObject'"
            );

    /// <summary>
    /// Returns the value as a <see cref="string"/> if <see cref="Type"/> is 'string', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'string'.</exception>
    public string AsString() =>
        IsString() ? (string)Value! : throw new ManagementException("Union type is not 'string'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Dictionary<string, object?>"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionFlowReturnJsonParamsPayloadObject(
        out Dictionary<string, object?>? value
    )
    {
        if (Type == "flowActionFlowReturnJsonParamsPayloadObject")
        {
            value = (Dictionary<string, object?>)Value!;
            return true;
        }
        value = null;
        return false;
    }

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

    public T Match<T>(
        Func<Dictionary<string, object?>, T> onFlowActionFlowReturnJsonParamsPayloadObject,
        Func<string, T> onString
    )
    {
        return Type switch
        {
            "flowActionFlowReturnJsonParamsPayloadObject" =>
                onFlowActionFlowReturnJsonParamsPayloadObject(
                    AsFlowActionFlowReturnJsonParamsPayloadObject()
                ),
            "string" => onString(AsString()),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<
            Dictionary<string, object?>
        > onFlowActionFlowReturnJsonParamsPayloadObject,
        global::System.Action<string> onString
    )
    {
        switch (Type)
        {
            case "flowActionFlowReturnJsonParamsPayloadObject":
                onFlowActionFlowReturnJsonParamsPayloadObject(
                    AsFlowActionFlowReturnJsonParamsPayloadObject()
                );
                break;
            case "string":
                onString(AsString());
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
        if (obj is not FlowActionFlowReturnJsonParamsPayload other)
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

    public static implicit operator FlowActionFlowReturnJsonParamsPayload(
        Dictionary<string, object?> value
    ) => new("flowActionFlowReturnJsonParamsPayloadObject", value);

    public static implicit operator FlowActionFlowReturnJsonParamsPayload(string value) =>
        new("string", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<FlowActionFlowReturnJsonParamsPayload>
    {
        public override FlowActionFlowReturnJsonParamsPayload? Read(
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

                FlowActionFlowReturnJsonParamsPayload stringResult = new("string", stringValue);
                return stringResult;
            }

            if (reader.TokenType == JsonTokenType.StartObject)
            {
                var document = JsonDocument.ParseValue(ref reader);

                var types = new (string Key, System.Type Type)[]
                {
                    (
                        "flowActionFlowReturnJsonParamsPayloadObject",
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
                            FlowActionFlowReturnJsonParamsPayload result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into FlowActionFlowReturnJsonParamsPayload"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionFlowReturnJsonParamsPayload value,
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
                str => writer.WriteStringValue(str)
            );
        }

        public override FlowActionFlowReturnJsonParamsPayload ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            FlowActionFlowReturnJsonParamsPayload result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionFlowReturnJsonParamsPayload value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
