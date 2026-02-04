// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionHttpSendRequestParamsQueryParamsValue.JsonConverter))]
[Serializable]
public class FlowActionHttpSendRequestParamsQueryParamsValue
{
    private FlowActionHttpSendRequestParamsQueryParamsValue(string type, object? value)
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
    /// Factory method to create a union from a double value.
    /// </summary>
    public static FlowActionHttpSendRequestParamsQueryParamsValue FromDouble(double value) =>
        new("double", value);

    /// <summary>
    /// Factory method to create a union from a string value.
    /// </summary>
    public static FlowActionHttpSendRequestParamsQueryParamsValue FromString(string value) =>
        new("string", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "double"
    /// </summary>
    public bool IsDouble() => Type == "double";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "string"
    /// </summary>
    public bool IsString() => Type == "string";

    /// <summary>
    /// Returns the value as a <see cref="double"/> if <see cref="Type"/> is 'double', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'double'.</exception>
    public double AsDouble() =>
        IsDouble() ? (double)Value! : throw new ManagementException("Union type is not 'double'");

    /// <summary>
    /// Returns the value as a <see cref="string"/> if <see cref="Type"/> is 'string', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'string'.</exception>
    public string AsString() =>
        IsString() ? (string)Value! : throw new ManagementException("Union type is not 'string'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="double"/> and returns true if successful.
    /// </summary>
    public bool TryGetDouble(out double? value)
    {
        if (Type == "double")
        {
            value = (double)Value!;
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

    public T Match<T>(Func<double, T> onDouble, Func<string, T> onString)
    {
        return Type switch
        {
            "double" => onDouble(AsDouble()),
            "string" => onString(AsString()),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(System.Action<double> onDouble, System.Action<string> onString)
    {
        switch (Type)
        {
            case "double":
                onDouble(AsDouble());
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
        if (obj is not FlowActionHttpSendRequestParamsQueryParamsValue other)
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

    public static implicit operator FlowActionHttpSendRequestParamsQueryParamsValue(double value) =>
        new("double", value);

    public static implicit operator FlowActionHttpSendRequestParamsQueryParamsValue(string value) =>
        new("string", value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<FlowActionHttpSendRequestParamsQueryParamsValue>
    {
        public override FlowActionHttpSendRequestParamsQueryParamsValue? Read(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            if (reader.TokenType == JsonTokenType.Number)
            {
                FlowActionHttpSendRequestParamsQueryParamsValue doubleResult = new(
                    "double",
                    reader.GetDouble()
                );
                return doubleResult;
            }

            if (reader.TokenType == JsonTokenType.String)
            {
                var stringValue = reader.GetString()!;

                FlowActionHttpSendRequestParamsQueryParamsValue stringResult = new(
                    "string",
                    stringValue
                );
                return stringResult;
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into FlowActionHttpSendRequestParamsQueryParamsValue"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionHttpSendRequestParamsQueryParamsValue value,
            JsonSerializerOptions options
        )
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            value.Visit(num => writer.WriteNumberValue(num), str => writer.WriteStringValue(str));
        }

        public override FlowActionHttpSendRequestParamsQueryParamsValue ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            FlowActionHttpSendRequestParamsQueryParamsValue result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionHttpSendRequestParamsQueryParamsValue value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
