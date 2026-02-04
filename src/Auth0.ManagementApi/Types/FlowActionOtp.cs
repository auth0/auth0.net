// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionOtp.JsonConverter))]
[Serializable]
public class FlowActionOtp
{
    private FlowActionOtp(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionOtpGenerateCode value.
    /// </summary>
    public static FlowActionOtp FromFlowActionOtpGenerateCode(
        Auth0.ManagementApi.FlowActionOtpGenerateCode value
    ) => new("flowActionOtpGenerateCode", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionOtpVerifyCode value.
    /// </summary>
    public static FlowActionOtp FromFlowActionOtpVerifyCode(
        Auth0.ManagementApi.FlowActionOtpVerifyCode value
    ) => new("flowActionOtpVerifyCode", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionOtpGenerateCode"
    /// </summary>
    public bool IsFlowActionOtpGenerateCode() => Type == "flowActionOtpGenerateCode";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionOtpVerifyCode"
    /// </summary>
    public bool IsFlowActionOtpVerifyCode() => Type == "flowActionOtpVerifyCode";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionOtpGenerateCode"/> if <see cref="Type"/> is 'flowActionOtpGenerateCode', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionOtpGenerateCode'.</exception>
    public Auth0.ManagementApi.FlowActionOtpGenerateCode AsFlowActionOtpGenerateCode() =>
        IsFlowActionOtpGenerateCode()
            ? (Auth0.ManagementApi.FlowActionOtpGenerateCode)Value!
            : throw new ManagementException("Union type is not 'flowActionOtpGenerateCode'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionOtpVerifyCode"/> if <see cref="Type"/> is 'flowActionOtpVerifyCode', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionOtpVerifyCode'.</exception>
    public Auth0.ManagementApi.FlowActionOtpVerifyCode AsFlowActionOtpVerifyCode() =>
        IsFlowActionOtpVerifyCode()
            ? (Auth0.ManagementApi.FlowActionOtpVerifyCode)Value!
            : throw new ManagementException("Union type is not 'flowActionOtpVerifyCode'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionOtpGenerateCode"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionOtpGenerateCode(
        out Auth0.ManagementApi.FlowActionOtpGenerateCode? value
    )
    {
        if (Type == "flowActionOtpGenerateCode")
        {
            value = (Auth0.ManagementApi.FlowActionOtpGenerateCode)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionOtpVerifyCode"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionOtpVerifyCode(
        out Auth0.ManagementApi.FlowActionOtpVerifyCode? value
    )
    {
        if (Type == "flowActionOtpVerifyCode")
        {
            value = (Auth0.ManagementApi.FlowActionOtpVerifyCode)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Auth0.ManagementApi.FlowActionOtpGenerateCode, T> onFlowActionOtpGenerateCode,
        Func<Auth0.ManagementApi.FlowActionOtpVerifyCode, T> onFlowActionOtpVerifyCode
    )
    {
        return Type switch
        {
            "flowActionOtpGenerateCode" => onFlowActionOtpGenerateCode(
                AsFlowActionOtpGenerateCode()
            ),
            "flowActionOtpVerifyCode" => onFlowActionOtpVerifyCode(AsFlowActionOtpVerifyCode()),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        System.Action<Auth0.ManagementApi.FlowActionOtpGenerateCode> onFlowActionOtpGenerateCode,
        System.Action<Auth0.ManagementApi.FlowActionOtpVerifyCode> onFlowActionOtpVerifyCode
    )
    {
        switch (Type)
        {
            case "flowActionOtpGenerateCode":
                onFlowActionOtpGenerateCode(AsFlowActionOtpGenerateCode());
                break;
            case "flowActionOtpVerifyCode":
                onFlowActionOtpVerifyCode(AsFlowActionOtpVerifyCode());
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
        if (obj is not FlowActionOtp other)
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

    public static implicit operator FlowActionOtp(
        Auth0.ManagementApi.FlowActionOtpGenerateCode value
    ) => new("flowActionOtpGenerateCode", value);

    public static implicit operator FlowActionOtp(
        Auth0.ManagementApi.FlowActionOtpVerifyCode value
    ) => new("flowActionOtpVerifyCode", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<FlowActionOtp>
    {
        public override FlowActionOtp? Read(
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
                    (
                        "flowActionOtpGenerateCode",
                        typeof(Auth0.ManagementApi.FlowActionOtpGenerateCode)
                    ),
                    (
                        "flowActionOtpVerifyCode",
                        typeof(Auth0.ManagementApi.FlowActionOtpVerifyCode)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            FlowActionOtp result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into FlowActionOtp"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionOtp value,
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

        public override FlowActionOtp ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            FlowActionOtp result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionOtp value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
