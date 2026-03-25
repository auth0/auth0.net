// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionTwilio.JsonConverter))]
[Serializable]
public class FlowActionTwilio
{
    private FlowActionTwilio(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionTwilioMakeCall value.
    /// </summary>
    public static FlowActionTwilio FromFlowActionTwilioMakeCall(
        Auth0.ManagementApi.FlowActionTwilioMakeCall value
    ) => new("flowActionTwilioMakeCall", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionTwilioSendSms value.
    /// </summary>
    public static FlowActionTwilio FromFlowActionTwilioSendSms(
        Auth0.ManagementApi.FlowActionTwilioSendSms value
    ) => new("flowActionTwilioSendSms", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionTwilioMakeCall"
    /// </summary>
    public bool IsFlowActionTwilioMakeCall() => Type == "flowActionTwilioMakeCall";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionTwilioSendSms"
    /// </summary>
    public bool IsFlowActionTwilioSendSms() => Type == "flowActionTwilioSendSms";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionTwilioMakeCall"/> if <see cref="Type"/> is 'flowActionTwilioMakeCall', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionTwilioMakeCall'.</exception>
    public Auth0.ManagementApi.FlowActionTwilioMakeCall AsFlowActionTwilioMakeCall() =>
        IsFlowActionTwilioMakeCall()
            ? (Auth0.ManagementApi.FlowActionTwilioMakeCall)Value!
            : throw new ManagementException("Union type is not 'flowActionTwilioMakeCall'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionTwilioSendSms"/> if <see cref="Type"/> is 'flowActionTwilioSendSms', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionTwilioSendSms'.</exception>
    public Auth0.ManagementApi.FlowActionTwilioSendSms AsFlowActionTwilioSendSms() =>
        IsFlowActionTwilioSendSms()
            ? (Auth0.ManagementApi.FlowActionTwilioSendSms)Value!
            : throw new ManagementException("Union type is not 'flowActionTwilioSendSms'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionTwilioMakeCall"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionTwilioMakeCall(
        out Auth0.ManagementApi.FlowActionTwilioMakeCall? value
    )
    {
        if (Type == "flowActionTwilioMakeCall")
        {
            value = (Auth0.ManagementApi.FlowActionTwilioMakeCall)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionTwilioSendSms"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionTwilioSendSms(
        out Auth0.ManagementApi.FlowActionTwilioSendSms? value
    )
    {
        if (Type == "flowActionTwilioSendSms")
        {
            value = (Auth0.ManagementApi.FlowActionTwilioSendSms)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Auth0.ManagementApi.FlowActionTwilioMakeCall, T> onFlowActionTwilioMakeCall,
        Func<Auth0.ManagementApi.FlowActionTwilioSendSms, T> onFlowActionTwilioSendSms
    )
    {
        return Type switch
        {
            "flowActionTwilioMakeCall" => onFlowActionTwilioMakeCall(AsFlowActionTwilioMakeCall()),
            "flowActionTwilioSendSms" => onFlowActionTwilioSendSms(AsFlowActionTwilioSendSms()),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.FlowActionTwilioMakeCall> onFlowActionTwilioMakeCall,
        global::System.Action<Auth0.ManagementApi.FlowActionTwilioSendSms> onFlowActionTwilioSendSms
    )
    {
        switch (Type)
        {
            case "flowActionTwilioMakeCall":
                onFlowActionTwilioMakeCall(AsFlowActionTwilioMakeCall());
                break;
            case "flowActionTwilioSendSms":
                onFlowActionTwilioSendSms(AsFlowActionTwilioSendSms());
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
        if (obj is not FlowActionTwilio other)
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

    public static implicit operator FlowActionTwilio(
        Auth0.ManagementApi.FlowActionTwilioMakeCall value
    ) => new("flowActionTwilioMakeCall", value);

    public static implicit operator FlowActionTwilio(
        Auth0.ManagementApi.FlowActionTwilioSendSms value
    ) => new("flowActionTwilioSendSms", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<FlowActionTwilio>
    {
        public override FlowActionTwilio? Read(
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
                        "flowActionTwilioMakeCall",
                        typeof(Auth0.ManagementApi.FlowActionTwilioMakeCall)
                    ),
                    (
                        "flowActionTwilioSendSms",
                        typeof(Auth0.ManagementApi.FlowActionTwilioSendSms)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            FlowActionTwilio result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into FlowActionTwilio"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionTwilio value,
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

        public override FlowActionTwilio ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            FlowActionTwilio result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionTwilio value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
