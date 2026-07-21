// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Additional property for session actor, can be string, boolean, or number.
/// </summary>
[JsonConverter(typeof(SessionActorClaimValue.JsonConverter))]
[Serializable]
public class SessionActorClaimValue
{
    private SessionActorClaimValue(string type, object? value)
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
    public static SessionActorClaimValue FromString(string value) => new("string", value);

    /// <summary>
    /// Factory method to create a union from a bool value.
    /// </summary>
    public static SessionActorClaimValue FromBool(bool value) => new("bool", value);

    /// <summary>
    /// Factory method to create a union from a double value.
    /// </summary>
    public static SessionActorClaimValue FromDouble(double value) => new("double", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "string"
    /// </summary>
    public bool IsString() => Type == "string";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "bool"
    /// </summary>
    public bool IsBool() => Type == "bool";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "double"
    /// </summary>
    public bool IsDouble() => Type == "double";

    /// <summary>
    /// Returns the value as a <see cref="string"/> if <see cref="Type"/> is 'string', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'string'.</exception>
    public string AsString() =>
        IsString() ? (string)Value! : throw new ManagementException("Union type is not 'string'");

    /// <summary>
    /// Returns the value as a <see cref="bool"/> if <see cref="Type"/> is 'bool', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'bool'.</exception>
    public bool AsBool() =>
        IsBool() ? (bool)Value! : throw new ManagementException("Union type is not 'bool'");

    /// <summary>
    /// Returns the value as a <see cref="double"/> if <see cref="Type"/> is 'double', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'double'.</exception>
    public double AsDouble() =>
        IsDouble() ? (double)Value! : throw new ManagementException("Union type is not 'double'");

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
    /// Attempts to cast the value to a <see cref="bool"/> and returns true if successful.
    /// </summary>
    public bool TryGetBool(out bool? value)
    {
        if (Type == "bool")
        {
            value = (bool)Value!;
            return true;
        }
        value = null;
        return false;
    }

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

    public T Match<T>(Func<string, T> onString, Func<bool, T> onBool, Func<double, T> onDouble)
    {
        return Type switch
        {
            "string" => onString(AsString()),
            "bool" => onBool(AsBool()),
            "double" => onDouble(AsDouble()),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<string> onString,
        global::System.Action<bool> onBool,
        global::System.Action<double> onDouble
    )
    {
        switch (Type)
        {
            case "string":
                onString(AsString());
                break;
            case "bool":
                onBool(AsBool());
                break;
            case "double":
                onDouble(AsDouble());
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
        if (obj is not SessionActorClaimValue other)
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

    public static implicit operator SessionActorClaimValue(string value) => new("string", value);

    public static implicit operator SessionActorClaimValue(bool value) => new("bool", value);

    public static implicit operator SessionActorClaimValue(double value) => new("double", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<SessionActorClaimValue>
    {
        public override SessionActorClaimValue? Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            if (reader.TokenType == JsonTokenType.Number)
            {
                SessionActorClaimValue doubleResult = new("double", reader.GetDouble());
                return doubleResult;
            }

            if (reader.TokenType == JsonTokenType.True || reader.TokenType == JsonTokenType.False)
            {
                SessionActorClaimValue boolResult = new("bool", reader.GetBoolean());
                return boolResult;
            }

            if (reader.TokenType == JsonTokenType.String)
            {
                var stringValue = reader.GetString()!;

                SessionActorClaimValue stringResult = new("string", stringValue);
                return stringResult;
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into SessionActorClaimValue"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            SessionActorClaimValue value,
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
                b => writer.WriteBooleanValue(b),
                num => writer.WriteNumberValue(num)
            );
        }

        public override SessionActorClaimValue ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            SessionActorClaimValue result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SessionActorClaimValue value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
