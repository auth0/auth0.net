// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionJson.JsonConverter))]
[Serializable]
public class FlowActionJson
{
    private FlowActionJson(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionJsonCreateJson value.
    /// </summary>
    public static FlowActionJson FromFlowActionJsonCreateJson(
        Auth0.ManagementApi.FlowActionJsonCreateJson value
    ) => new("flowActionJsonCreateJson", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionJsonParseJson value.
    /// </summary>
    public static FlowActionJson FromFlowActionJsonParseJson(
        Auth0.ManagementApi.FlowActionJsonParseJson value
    ) => new("flowActionJsonParseJson", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionJsonSerializeJson value.
    /// </summary>
    public static FlowActionJson FromFlowActionJsonSerializeJson(
        Auth0.ManagementApi.FlowActionJsonSerializeJson value
    ) => new("flowActionJsonSerializeJson", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionJsonCreateJson"
    /// </summary>
    public bool IsFlowActionJsonCreateJson() => Type == "flowActionJsonCreateJson";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionJsonParseJson"
    /// </summary>
    public bool IsFlowActionJsonParseJson() => Type == "flowActionJsonParseJson";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionJsonSerializeJson"
    /// </summary>
    public bool IsFlowActionJsonSerializeJson() => Type == "flowActionJsonSerializeJson";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionJsonCreateJson"/> if <see cref="Type"/> is 'flowActionJsonCreateJson', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionJsonCreateJson'.</exception>
    public Auth0.ManagementApi.FlowActionJsonCreateJson AsFlowActionJsonCreateJson() =>
        IsFlowActionJsonCreateJson()
            ? (Auth0.ManagementApi.FlowActionJsonCreateJson)Value!
            : throw new ManagementException("Union type is not 'flowActionJsonCreateJson'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionJsonParseJson"/> if <see cref="Type"/> is 'flowActionJsonParseJson', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionJsonParseJson'.</exception>
    public Auth0.ManagementApi.FlowActionJsonParseJson AsFlowActionJsonParseJson() =>
        IsFlowActionJsonParseJson()
            ? (Auth0.ManagementApi.FlowActionJsonParseJson)Value!
            : throw new ManagementException("Union type is not 'flowActionJsonParseJson'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionJsonSerializeJson"/> if <see cref="Type"/> is 'flowActionJsonSerializeJson', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionJsonSerializeJson'.</exception>
    public Auth0.ManagementApi.FlowActionJsonSerializeJson AsFlowActionJsonSerializeJson() =>
        IsFlowActionJsonSerializeJson()
            ? (Auth0.ManagementApi.FlowActionJsonSerializeJson)Value!
            : throw new ManagementException("Union type is not 'flowActionJsonSerializeJson'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionJsonCreateJson"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionJsonCreateJson(
        out Auth0.ManagementApi.FlowActionJsonCreateJson? value
    )
    {
        if (Type == "flowActionJsonCreateJson")
        {
            value = (Auth0.ManagementApi.FlowActionJsonCreateJson)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionJsonParseJson"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionJsonParseJson(
        out Auth0.ManagementApi.FlowActionJsonParseJson? value
    )
    {
        if (Type == "flowActionJsonParseJson")
        {
            value = (Auth0.ManagementApi.FlowActionJsonParseJson)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionJsonSerializeJson"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionJsonSerializeJson(
        out Auth0.ManagementApi.FlowActionJsonSerializeJson? value
    )
    {
        if (Type == "flowActionJsonSerializeJson")
        {
            value = (Auth0.ManagementApi.FlowActionJsonSerializeJson)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Auth0.ManagementApi.FlowActionJsonCreateJson, T> onFlowActionJsonCreateJson,
        Func<Auth0.ManagementApi.FlowActionJsonParseJson, T> onFlowActionJsonParseJson,
        Func<Auth0.ManagementApi.FlowActionJsonSerializeJson, T> onFlowActionJsonSerializeJson
    )
    {
        return Type switch
        {
            "flowActionJsonCreateJson" => onFlowActionJsonCreateJson(AsFlowActionJsonCreateJson()),
            "flowActionJsonParseJson" => onFlowActionJsonParseJson(AsFlowActionJsonParseJson()),
            "flowActionJsonSerializeJson" => onFlowActionJsonSerializeJson(
                AsFlowActionJsonSerializeJson()
            ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.FlowActionJsonCreateJson> onFlowActionJsonCreateJson,
        global::System.Action<Auth0.ManagementApi.FlowActionJsonParseJson> onFlowActionJsonParseJson,
        global::System.Action<Auth0.ManagementApi.FlowActionJsonSerializeJson> onFlowActionJsonSerializeJson
    )
    {
        switch (Type)
        {
            case "flowActionJsonCreateJson":
                onFlowActionJsonCreateJson(AsFlowActionJsonCreateJson());
                break;
            case "flowActionJsonParseJson":
                onFlowActionJsonParseJson(AsFlowActionJsonParseJson());
                break;
            case "flowActionJsonSerializeJson":
                onFlowActionJsonSerializeJson(AsFlowActionJsonSerializeJson());
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
        if (obj is not FlowActionJson other)
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

    public static implicit operator FlowActionJson(
        Auth0.ManagementApi.FlowActionJsonCreateJson value
    ) => new("flowActionJsonCreateJson", value);

    public static implicit operator FlowActionJson(
        Auth0.ManagementApi.FlowActionJsonParseJson value
    ) => new("flowActionJsonParseJson", value);

    public static implicit operator FlowActionJson(
        Auth0.ManagementApi.FlowActionJsonSerializeJson value
    ) => new("flowActionJsonSerializeJson", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<FlowActionJson>
    {
        public override FlowActionJson? Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
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
                    (
                        "flowActionJsonCreateJson",
                        typeof(Auth0.ManagementApi.FlowActionJsonCreateJson)
                    ),
                    (
                        "flowActionJsonParseJson",
                        typeof(Auth0.ManagementApi.FlowActionJsonParseJson)
                    ),
                    (
                        "flowActionJsonSerializeJson",
                        typeof(Auth0.ManagementApi.FlowActionJsonSerializeJson)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            FlowActionJson result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into FlowActionJson"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionJson value,
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
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override FlowActionJson ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            FlowActionJson result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionJson value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
