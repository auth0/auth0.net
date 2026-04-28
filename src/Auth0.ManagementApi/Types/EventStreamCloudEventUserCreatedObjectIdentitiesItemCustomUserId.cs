// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The IDP-specific identifer for the user.
/// </summary>
[JsonConverter(
    typeof(EventStreamCloudEventUserCreatedObjectIdentitiesItemCustomUserId.JsonConverter)
)]
[Serializable]
public class EventStreamCloudEventUserCreatedObjectIdentitiesItemCustomUserId
{
    private EventStreamCloudEventUserCreatedObjectIdentitiesItemCustomUserId(
        string type,
        object? value
    )
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
    public static EventStreamCloudEventUserCreatedObjectIdentitiesItemCustomUserId FromString(
        string value
    ) => new("string", value);

    /// <summary>
    /// Factory method to create a union from a int value.
    /// </summary>
    public static EventStreamCloudEventUserCreatedObjectIdentitiesItemCustomUserId FromInt(
        int value
    ) => new("int", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "string"
    /// </summary>
    public bool IsString() => Type == "string";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "int"
    /// </summary>
    public bool IsInt() => Type == "int";

    /// <summary>
    /// Returns the value as a <see cref="string"/> if <see cref="Type"/> is 'string', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'string'.</exception>
    public string AsString() =>
        IsString() ? (string)Value! : throw new ManagementException("Union type is not 'string'");

    /// <summary>
    /// Returns the value as a <see cref="int"/> if <see cref="Type"/> is 'int', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'int'.</exception>
    public int AsInt() =>
        IsInt() ? (int)Value! : throw new ManagementException("Union type is not 'int'");

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
    /// Attempts to cast the value to a <see cref="int"/> and returns true if successful.
    /// </summary>
    public bool TryGetInt(out int? value)
    {
        if (Type == "int")
        {
            value = (int)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(Func<string, T> onString, Func<int, T> onInt)
    {
        return Type switch
        {
            "string" => onString(AsString()),
            "int" => onInt(AsInt()),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(global::System.Action<string> onString, global::System.Action<int> onInt)
    {
        switch (Type)
        {
            case "string":
                onString(AsString());
                break;
            case "int":
                onInt(AsInt());
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
        if (obj is not EventStreamCloudEventUserCreatedObjectIdentitiesItemCustomUserId other)
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

    public static implicit operator EventStreamCloudEventUserCreatedObjectIdentitiesItemCustomUserId(
        string value
    ) => new("string", value);

    public static implicit operator EventStreamCloudEventUserCreatedObjectIdentitiesItemCustomUserId(
        int value
    ) => new("int", value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<EventStreamCloudEventUserCreatedObjectIdentitiesItemCustomUserId>
    {
        public override EventStreamCloudEventUserCreatedObjectIdentitiesItemCustomUserId? Read(
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
                if (reader.TryGetInt32(out var intValue))
                {
                    EventStreamCloudEventUserCreatedObjectIdentitiesItemCustomUserId intResult =
                        new("int", intValue);
                    return intResult;
                }
            }

            if (reader.TokenType == JsonTokenType.String)
            {
                var stringValue = reader.GetString()!;

                if (int.TryParse(stringValue, out var intFromStringValue))
                {
                    EventStreamCloudEventUserCreatedObjectIdentitiesItemCustomUserId intFromStringResult =
                        new("int", intFromStringValue);
                    return intFromStringResult;
                }

                EventStreamCloudEventUserCreatedObjectIdentitiesItemCustomUserId stringResult = new(
                    "string",
                    stringValue
                );
                return stringResult;
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into EventStreamCloudEventUserCreatedObjectIdentitiesItemCustomUserId"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserCreatedObjectIdentitiesItemCustomUserId value,
            JsonSerializerOptions options
        )
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            value.Visit(str => writer.WriteStringValue(str), num => writer.WriteNumberValue(num));
        }

        public override EventStreamCloudEventUserCreatedObjectIdentitiesItemCustomUserId ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EventStreamCloudEventUserCreatedObjectIdentitiesItemCustomUserId result = new(
                "string",
                stringValue
            );
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserCreatedObjectIdentitiesItemCustomUserId value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
