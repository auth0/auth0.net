// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FormNodePointer.JsonConverter))]
[Serializable]
public class FormNodePointer
{
    private FormNodePointer(string type, object? value)
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
    public static FormNodePointer FromString(string value) => new("string", value);

    /// <summary>
    /// Factory method to create a union from a string value.
    /// </summary>
    public static FormNodePointer FromFormEndingNodeId(string value) =>
        new("formEndingNodeId", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "string"
    /// </summary>
    public bool IsString() => Type == "string";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "formEndingNodeId"
    /// </summary>
    public bool IsFormEndingNodeId() => Type == "formEndingNodeId";

    /// <summary>
    /// Returns the value as a <see cref="string"/> if <see cref="Type"/> is 'string', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'string'.</exception>
    public string AsString() =>
        IsString() ? (string)Value! : throw new ManagementException("Union type is not 'string'");

    /// <summary>
    /// Returns the value as a <see cref="string"/> if <see cref="Type"/> is 'formEndingNodeId', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'formEndingNodeId'.</exception>
    public string AsFormEndingNodeId() =>
        IsFormEndingNodeId()
            ? (string)Value!
            : throw new ManagementException("Union type is not 'formEndingNodeId'");

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
    /// Attempts to cast the value to a <see cref="string"/> and returns true if successful.
    /// </summary>
    public bool TryGetFormEndingNodeId(out string? value)
    {
        if (Type == "formEndingNodeId")
        {
            value = (string)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(Func<string, T> onString, Func<string, T> onFormEndingNodeId)
    {
        return Type switch
        {
            "string" => onString(AsString()),
            "formEndingNodeId" => onFormEndingNodeId(AsFormEndingNodeId()),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(System.Action<string> onString, System.Action<string> onFormEndingNodeId)
    {
        switch (Type)
        {
            case "string":
                onString(AsString());
                break;
            case "formEndingNodeId":
                onFormEndingNodeId(AsFormEndingNodeId());
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
        if (obj is not FormNodePointer other)
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

    public static implicit operator FormNodePointer(string value) => new("string", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<FormNodePointer>
    {
        public override FormNodePointer? Read(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
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

                FormNodePointer stringResult = new("string", stringValue);
                return stringResult;
            }

            if (reader.TokenType == JsonTokenType.StartObject)
            {
                var document = JsonDocument.ParseValue(ref reader);

                var types = new (string Key, System.Type Type)[]
                {
                    ("formEndingNodeId", typeof(string)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            FormNodePointer result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into FormNodePointer"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            FormNodePointer value,
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

        public override FormNodePointer ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            FormNodePointer result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FormNodePointer value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
