// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionXml.JsonConverter))]
[Serializable]
public class FlowActionXml
{
    private FlowActionXml(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionXmlParseXml value.
    /// </summary>
    public static FlowActionXml FromFlowActionXmlParseXml(
        Auth0.ManagementApi.FlowActionXmlParseXml value
    ) => new("flowActionXmlParseXml", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionXmlSerializeXml value.
    /// </summary>
    public static FlowActionXml FromFlowActionXmlSerializeXml(
        Auth0.ManagementApi.FlowActionXmlSerializeXml value
    ) => new("flowActionXmlSerializeXml", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionXmlParseXml"
    /// </summary>
    public bool IsFlowActionXmlParseXml() => Type == "flowActionXmlParseXml";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionXmlSerializeXml"
    /// </summary>
    public bool IsFlowActionXmlSerializeXml() => Type == "flowActionXmlSerializeXml";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionXmlParseXml"/> if <see cref="Type"/> is 'flowActionXmlParseXml', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionXmlParseXml'.</exception>
    public Auth0.ManagementApi.FlowActionXmlParseXml AsFlowActionXmlParseXml() =>
        IsFlowActionXmlParseXml()
            ? (Auth0.ManagementApi.FlowActionXmlParseXml)Value!
            : throw new ManagementException("Union type is not 'flowActionXmlParseXml'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionXmlSerializeXml"/> if <see cref="Type"/> is 'flowActionXmlSerializeXml', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionXmlSerializeXml'.</exception>
    public Auth0.ManagementApi.FlowActionXmlSerializeXml AsFlowActionXmlSerializeXml() =>
        IsFlowActionXmlSerializeXml()
            ? (Auth0.ManagementApi.FlowActionXmlSerializeXml)Value!
            : throw new ManagementException("Union type is not 'flowActionXmlSerializeXml'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionXmlParseXml"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionXmlParseXml(out Auth0.ManagementApi.FlowActionXmlParseXml? value)
    {
        if (Type == "flowActionXmlParseXml")
        {
            value = (Auth0.ManagementApi.FlowActionXmlParseXml)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionXmlSerializeXml"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionXmlSerializeXml(
        out Auth0.ManagementApi.FlowActionXmlSerializeXml? value
    )
    {
        if (Type == "flowActionXmlSerializeXml")
        {
            value = (Auth0.ManagementApi.FlowActionXmlSerializeXml)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Auth0.ManagementApi.FlowActionXmlParseXml, T> onFlowActionXmlParseXml,
        Func<Auth0.ManagementApi.FlowActionXmlSerializeXml, T> onFlowActionXmlSerializeXml
    )
    {
        return Type switch
        {
            "flowActionXmlParseXml" => onFlowActionXmlParseXml(AsFlowActionXmlParseXml()),
            "flowActionXmlSerializeXml" => onFlowActionXmlSerializeXml(
                AsFlowActionXmlSerializeXml()
            ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        System.Action<Auth0.ManagementApi.FlowActionXmlParseXml> onFlowActionXmlParseXml,
        System.Action<Auth0.ManagementApi.FlowActionXmlSerializeXml> onFlowActionXmlSerializeXml
    )
    {
        switch (Type)
        {
            case "flowActionXmlParseXml":
                onFlowActionXmlParseXml(AsFlowActionXmlParseXml());
                break;
            case "flowActionXmlSerializeXml":
                onFlowActionXmlSerializeXml(AsFlowActionXmlSerializeXml());
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
        if (obj is not FlowActionXml other)
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

    public static implicit operator FlowActionXml(
        Auth0.ManagementApi.FlowActionXmlParseXml value
    ) => new("flowActionXmlParseXml", value);

    public static implicit operator FlowActionXml(
        Auth0.ManagementApi.FlowActionXmlSerializeXml value
    ) => new("flowActionXmlSerializeXml", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<FlowActionXml>
    {
        public override FlowActionXml? Read(
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
                    ("flowActionXmlParseXml", typeof(Auth0.ManagementApi.FlowActionXmlParseXml)),
                    (
                        "flowActionXmlSerializeXml",
                        typeof(Auth0.ManagementApi.FlowActionXmlSerializeXml)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            FlowActionXml result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into FlowActionXml"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionXml value,
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
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override FlowActionXml ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            FlowActionXml result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionXml value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
