// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(AculContextConfigurationItem.JsonConverter))]
[Serializable]
public class AculContextConfigurationItem
{
    private AculContextConfigurationItem(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.AculContextEnum value.
    /// </summary>
    public static AculContextConfigurationItem FromAculContextEnum(
        Auth0.ManagementApi.AculContextEnum value
    ) => new("aculContextEnum", value);

    /// <summary>
    /// Factory method to create a union from a string value.
    /// </summary>
    public static AculContextConfigurationItem FromString(string value) => new("string", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "aculContextEnum"
    /// </summary>
    public bool IsAculContextEnum() => Type == "aculContextEnum";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "string"
    /// </summary>
    public bool IsString() => Type == "string";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.AculContextEnum"/> if <see cref="Type"/> is 'aculContextEnum', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'aculContextEnum'.</exception>
    public Auth0.ManagementApi.AculContextEnum AsAculContextEnum() =>
        IsAculContextEnum()
            ? (Auth0.ManagementApi.AculContextEnum)Value!
            : throw new ManagementException("Union type is not 'aculContextEnum'");

    /// <summary>
    /// Returns the value as a <see cref="string"/> if <see cref="Type"/> is 'string', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'string'.</exception>
    public string AsString() =>
        IsString() ? (string)Value! : throw new ManagementException("Union type is not 'string'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.AculContextEnum"/> and returns true if successful.
    /// </summary>
    public bool TryGetAculContextEnum(out Auth0.ManagementApi.AculContextEnum? value)
    {
        if (Type == "aculContextEnum")
        {
            value = (Auth0.ManagementApi.AculContextEnum)Value!;
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
        Func<Auth0.ManagementApi.AculContextEnum, T> onAculContextEnum,
        Func<string, T> onString
    )
    {
        return Type switch
        {
            "aculContextEnum" => onAculContextEnum(AsAculContextEnum()),
            "string" => onString(AsString()),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.AculContextEnum> onAculContextEnum,
        global::System.Action<string> onString
    )
    {
        switch (Type)
        {
            case "aculContextEnum":
                onAculContextEnum(AsAculContextEnum());
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
        if (obj is not AculContextConfigurationItem other)
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

    public static implicit operator AculContextConfigurationItem(
        Auth0.ManagementApi.AculContextEnum value
    ) => new("aculContextEnum", value);

    public static implicit operator AculContextConfigurationItem(string value) =>
        new("string", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<AculContextConfigurationItem>
    {
        public override AculContextConfigurationItem? Read(
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

                AculContextConfigurationItem stringResult = new("string", stringValue);
                return stringResult;
            }

            if (reader.TokenType == JsonTokenType.StartObject)
            {
                var document = JsonDocument.ParseValue(ref reader);

                var types = new (string Key, System.Type Type)[]
                {
                    ("aculContextEnum", typeof(Auth0.ManagementApi.AculContextEnum)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            AculContextConfigurationItem result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into AculContextConfigurationItem"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            AculContextConfigurationItem value,
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

        public override AculContextConfigurationItem ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            AculContextConfigurationItem result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            AculContextConfigurationItem value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
