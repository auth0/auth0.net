using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionOtpVerifyCodeType.FlowActionOtpVerifyCodeTypeSerializer))]
[Serializable]
public readonly record struct FlowActionOtpVerifyCodeType : IStringEnum
{
    public static readonly FlowActionOtpVerifyCodeType Otp = new(Values.Otp);

    public FlowActionOtpVerifyCodeType(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static FlowActionOtpVerifyCodeType FromCustom(string value)
    {
        return new FlowActionOtpVerifyCodeType(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(FlowActionOtpVerifyCodeType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionOtpVerifyCodeType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionOtpVerifyCodeType value) => value.Value;

    public static explicit operator FlowActionOtpVerifyCodeType(string value) => new(value);

    internal class FlowActionOtpVerifyCodeTypeSerializer
        : JsonConverter<FlowActionOtpVerifyCodeType>
    {
        public override FlowActionOtpVerifyCodeType Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new FlowActionOtpVerifyCodeType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionOtpVerifyCodeType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override FlowActionOtpVerifyCodeType ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new FlowActionOtpVerifyCodeType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionOtpVerifyCodeType value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Otp = "OTP";
    }
}
