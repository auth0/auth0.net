// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionJsonSerializeJsonParamsObject.JsonConverter))]
[Serializable]
public class FlowActionJsonSerializeJsonParamsObject
{
    private FlowActionJsonSerializeJsonParamsObject(string type, object? value)
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
    public static FlowActionJsonSerializeJsonParamsObject FromString(string value) =>
        new("string", value);

    /// <summary>
    /// Factory method to create a union from a Dictionary<string, object?> value.
    /// </summary>
    public static FlowActionJsonSerializeJsonParamsObject FromFlowActionJsonSerializeJsonParamsObjectObject(
        Dictionary<string, object?> value
    ) => new("flowActionJsonSerializeJsonParamsObjectObject", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "string"
    /// </summary>
    public bool IsString() => Type == "string";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionJsonSerializeJsonParamsObjectObject"
    /// </summary>
    public bool IsFlowActionJsonSerializeJsonParamsObjectObject() =>
        Type == "flowActionJsonSerializeJsonParamsObjectObject";

    /// <summary>
    /// Returns the value as a <see cref="string"/> if <see cref="Type"/> is 'string', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'string'.</exception>
    public string AsString() =>
        IsString() ? (string)Value! : throw new ManagementException("Union type is not 'string'");

    /// <summary>
    /// Returns the value as a <see cref="Dictionary<string, object?>"/> if <see cref="Type"/> is 'flowActionJsonSerializeJsonParamsObjectObject', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionJsonSerializeJsonParamsObjectObject'.</exception>
    public Dictionary<string, object?> AsFlowActionJsonSerializeJsonParamsObjectObject() =>
        IsFlowActionJsonSerializeJsonParamsObjectObject()
            ? (Dictionary<string, object?>)Value!
            : throw new ManagementException(
                "Union type is not 'flowActionJsonSerializeJsonParamsObjectObject'"
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
    /// Attempts to cast the value to a <see cref="Dictionary<string, object?>"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionJsonSerializeJsonParamsObjectObject(
        out Dictionary<string, object?>? value
    )
    {
        if (Type == "flowActionJsonSerializeJsonParamsObjectObject")
        {
            value = (Dictionary<string, object?>)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<string, T> onString,
        Func<Dictionary<string, object?>, T> onFlowActionJsonSerializeJsonParamsObjectObject
    )
    {
        return Type switch
        {
            "string" => onString(AsString()),
            "flowActionJsonSerializeJsonParamsObjectObject" =>
                onFlowActionJsonSerializeJsonParamsObjectObject(
                    AsFlowActionJsonSerializeJsonParamsObjectObject()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<string> onString,
        global::System.Action<
            Dictionary<string, object?>
        > onFlowActionJsonSerializeJsonParamsObjectObject
    )
    {
        switch (Type)
        {
            case "string":
                onString(AsString());
                break;
            case "flowActionJsonSerializeJsonParamsObjectObject":
                onFlowActionJsonSerializeJsonParamsObjectObject(
                    AsFlowActionJsonSerializeJsonParamsObjectObject()
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
        if (obj is not FlowActionJsonSerializeJsonParamsObject other)
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

    public static implicit operator FlowActionJsonSerializeJsonParamsObject(string value) =>
        new("string", value);

    public static implicit operator FlowActionJsonSerializeJsonParamsObject(
        Dictionary<string, object?> value
    ) => new("flowActionJsonSerializeJsonParamsObjectObject", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<FlowActionJsonSerializeJsonParamsObject>
    {
        public override FlowActionJsonSerializeJsonParamsObject? Read(
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

                FlowActionJsonSerializeJsonParamsObject stringResult = new("string", stringValue);
                return stringResult;
            }

            if (reader.TokenType == JsonTokenType.StartObject)
            {
                var document = JsonDocument.ParseValue(ref reader);

                var types = new (string Key, System.Type Type)[]
                {
                    (
                        "flowActionJsonSerializeJsonParamsObjectObject",
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
                            FlowActionJsonSerializeJsonParamsObject result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into FlowActionJsonSerializeJsonParamsObject"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionJsonSerializeJsonParamsObject value,
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
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override FlowActionJsonSerializeJsonParamsObject ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            FlowActionJsonSerializeJsonParamsObject result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionJsonSerializeJsonParamsObject value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
