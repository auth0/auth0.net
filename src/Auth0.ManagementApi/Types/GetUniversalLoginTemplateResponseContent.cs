// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(GetUniversalLoginTemplateResponseContent.JsonConverter))]
[Serializable]
public class GetUniversalLoginTemplateResponseContent
{
    private GetUniversalLoginTemplateResponseContent(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.GetUniversalLoginTemplate value.
    /// </summary>
    public static GetUniversalLoginTemplateResponseContent FromGetUniversalLoginTemplate(
        Auth0.ManagementApi.GetUniversalLoginTemplate value
    ) => new("getUniversalLoginTemplate", value);

    /// <summary>
    /// Factory method to create a union from a string value.
    /// </summary>
    public static GetUniversalLoginTemplateResponseContent FromString(string value) =>
        new("string", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "getUniversalLoginTemplate"
    /// </summary>
    public bool IsGetUniversalLoginTemplate() => Type == "getUniversalLoginTemplate";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "string"
    /// </summary>
    public bool IsString() => Type == "string";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.GetUniversalLoginTemplate"/> if <see cref="Type"/> is 'getUniversalLoginTemplate', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'getUniversalLoginTemplate'.</exception>
    public Auth0.ManagementApi.GetUniversalLoginTemplate AsGetUniversalLoginTemplate() =>
        IsGetUniversalLoginTemplate()
            ? (Auth0.ManagementApi.GetUniversalLoginTemplate)Value!
            : throw new ManagementException("Union type is not 'getUniversalLoginTemplate'");

    /// <summary>
    /// Returns the value as a <see cref="string"/> if <see cref="Type"/> is 'string', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'string'.</exception>
    public string AsString() =>
        IsString() ? (string)Value! : throw new ManagementException("Union type is not 'string'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.GetUniversalLoginTemplate"/> and returns true if successful.
    /// </summary>
    public bool TryGetGetUniversalLoginTemplate(
        out Auth0.ManagementApi.GetUniversalLoginTemplate? value
    )
    {
        if (Type == "getUniversalLoginTemplate")
        {
            value = (Auth0.ManagementApi.GetUniversalLoginTemplate)Value!;
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
        Func<Auth0.ManagementApi.GetUniversalLoginTemplate, T> onGetUniversalLoginTemplate,
        Func<string, T> onString
    )
    {
        return Type switch
        {
            "getUniversalLoginTemplate" => onGetUniversalLoginTemplate(
                AsGetUniversalLoginTemplate()
            ),
            "string" => onString(AsString()),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        System.Action<Auth0.ManagementApi.GetUniversalLoginTemplate> onGetUniversalLoginTemplate,
        System.Action<string> onString
    )
    {
        switch (Type)
        {
            case "getUniversalLoginTemplate":
                onGetUniversalLoginTemplate(AsGetUniversalLoginTemplate());
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
        if (obj is not GetUniversalLoginTemplateResponseContent other)
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

    public static implicit operator GetUniversalLoginTemplateResponseContent(
        Auth0.ManagementApi.GetUniversalLoginTemplate value
    ) => new("getUniversalLoginTemplate", value);

    public static implicit operator GetUniversalLoginTemplateResponseContent(string value) =>
        new("string", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<GetUniversalLoginTemplateResponseContent>
    {
        public override GetUniversalLoginTemplateResponseContent? Read(
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

                GetUniversalLoginTemplateResponseContent stringResult = new("string", stringValue);
                return stringResult;
            }

            if (reader.TokenType == JsonTokenType.StartObject)
            {
                var document = JsonDocument.ParseValue(ref reader);

                var types = new (string Key, System.Type Type)[]
                {
                    (
                        "getUniversalLoginTemplate",
                        typeof(Auth0.ManagementApi.GetUniversalLoginTemplate)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            GetUniversalLoginTemplateResponseContent result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into GetUniversalLoginTemplateResponseContent"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetUniversalLoginTemplateResponseContent value,
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

        public override GetUniversalLoginTemplateResponseContent ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            GetUniversalLoginTemplateResponseContent result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetUniversalLoginTemplateResponseContent value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
