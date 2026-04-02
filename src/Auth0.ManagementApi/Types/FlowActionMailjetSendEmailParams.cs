// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionMailjetSendEmailParams.JsonConverter))]
[Serializable]
public class FlowActionMailjetSendEmailParams
{
    private FlowActionMailjetSendEmailParams(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionMailjetSendEmailParamsContent value.
    /// </summary>
    public static FlowActionMailjetSendEmailParams FromFlowActionMailjetSendEmailParamsContent(
        Auth0.ManagementApi.FlowActionMailjetSendEmailParamsContent value
    ) => new("flowActionMailjetSendEmailParamsContent", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionMailjetSendEmailParamsTemplateId value.
    /// </summary>
    public static FlowActionMailjetSendEmailParams FromFlowActionMailjetSendEmailParamsTemplateId(
        Auth0.ManagementApi.FlowActionMailjetSendEmailParamsTemplateId value
    ) => new("flowActionMailjetSendEmailParamsTemplateId", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionMailjetSendEmailParamsContent"
    /// </summary>
    public bool IsFlowActionMailjetSendEmailParamsContent() =>
        Type == "flowActionMailjetSendEmailParamsContent";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionMailjetSendEmailParamsTemplateId"
    /// </summary>
    public bool IsFlowActionMailjetSendEmailParamsTemplateId() =>
        Type == "flowActionMailjetSendEmailParamsTemplateId";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionMailjetSendEmailParamsContent"/> if <see cref="Type"/> is 'flowActionMailjetSendEmailParamsContent', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionMailjetSendEmailParamsContent'.</exception>
    public Auth0.ManagementApi.FlowActionMailjetSendEmailParamsContent AsFlowActionMailjetSendEmailParamsContent() =>
        IsFlowActionMailjetSendEmailParamsContent()
            ? (Auth0.ManagementApi.FlowActionMailjetSendEmailParamsContent)Value!
            : throw new ManagementException(
                "Union type is not 'flowActionMailjetSendEmailParamsContent'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionMailjetSendEmailParamsTemplateId"/> if <see cref="Type"/> is 'flowActionMailjetSendEmailParamsTemplateId', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionMailjetSendEmailParamsTemplateId'.</exception>
    public Auth0.ManagementApi.FlowActionMailjetSendEmailParamsTemplateId AsFlowActionMailjetSendEmailParamsTemplateId() =>
        IsFlowActionMailjetSendEmailParamsTemplateId()
            ? (Auth0.ManagementApi.FlowActionMailjetSendEmailParamsTemplateId)Value!
            : throw new ManagementException(
                "Union type is not 'flowActionMailjetSendEmailParamsTemplateId'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionMailjetSendEmailParamsContent"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionMailjetSendEmailParamsContent(
        out Auth0.ManagementApi.FlowActionMailjetSendEmailParamsContent? value
    )
    {
        if (Type == "flowActionMailjetSendEmailParamsContent")
        {
            value = (Auth0.ManagementApi.FlowActionMailjetSendEmailParamsContent)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionMailjetSendEmailParamsTemplateId"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionMailjetSendEmailParamsTemplateId(
        out Auth0.ManagementApi.FlowActionMailjetSendEmailParamsTemplateId? value
    )
    {
        if (Type == "flowActionMailjetSendEmailParamsTemplateId")
        {
            value = (Auth0.ManagementApi.FlowActionMailjetSendEmailParamsTemplateId)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.FlowActionMailjetSendEmailParamsContent,
            T
        > onFlowActionMailjetSendEmailParamsContent,
        Func<
            Auth0.ManagementApi.FlowActionMailjetSendEmailParamsTemplateId,
            T
        > onFlowActionMailjetSendEmailParamsTemplateId
    )
    {
        return Type switch
        {
            "flowActionMailjetSendEmailParamsContent" => onFlowActionMailjetSendEmailParamsContent(
                AsFlowActionMailjetSendEmailParamsContent()
            ),
            "flowActionMailjetSendEmailParamsTemplateId" =>
                onFlowActionMailjetSendEmailParamsTemplateId(
                    AsFlowActionMailjetSendEmailParamsTemplateId()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.FlowActionMailjetSendEmailParamsContent> onFlowActionMailjetSendEmailParamsContent,
        global::System.Action<Auth0.ManagementApi.FlowActionMailjetSendEmailParamsTemplateId> onFlowActionMailjetSendEmailParamsTemplateId
    )
    {
        switch (Type)
        {
            case "flowActionMailjetSendEmailParamsContent":
                onFlowActionMailjetSendEmailParamsContent(
                    AsFlowActionMailjetSendEmailParamsContent()
                );
                break;
            case "flowActionMailjetSendEmailParamsTemplateId":
                onFlowActionMailjetSendEmailParamsTemplateId(
                    AsFlowActionMailjetSendEmailParamsTemplateId()
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
        if (obj is not FlowActionMailjetSendEmailParams other)
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

    public static implicit operator FlowActionMailjetSendEmailParams(
        Auth0.ManagementApi.FlowActionMailjetSendEmailParamsContent value
    ) => new("flowActionMailjetSendEmailParamsContent", value);

    public static implicit operator FlowActionMailjetSendEmailParams(
        Auth0.ManagementApi.FlowActionMailjetSendEmailParamsTemplateId value
    ) => new("flowActionMailjetSendEmailParamsTemplateId", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<FlowActionMailjetSendEmailParams>
    {
        public override FlowActionMailjetSendEmailParams? Read(
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
                        "flowActionMailjetSendEmailParamsContent",
                        typeof(Auth0.ManagementApi.FlowActionMailjetSendEmailParamsContent)
                    ),
                    (
                        "flowActionMailjetSendEmailParamsTemplateId",
                        typeof(Auth0.ManagementApi.FlowActionMailjetSendEmailParamsTemplateId)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            FlowActionMailjetSendEmailParams result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into FlowActionMailjetSendEmailParams"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionMailjetSendEmailParams value,
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

        public override FlowActionMailjetSendEmailParams ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            FlowActionMailjetSendEmailParams result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionMailjetSendEmailParams value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
