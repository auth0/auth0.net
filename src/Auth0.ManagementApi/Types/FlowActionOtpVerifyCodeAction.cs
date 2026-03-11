using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FlowActionOtpVerifyCodeAction>))]
[Serializable]
public readonly record struct FlowActionOtpVerifyCodeAction : IStringEnum
{
    public static readonly FlowActionOtpVerifyCodeAction VerifyCode = new(Values.VerifyCode);

    public FlowActionOtpVerifyCodeAction(string value)
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
    public static FlowActionOtpVerifyCodeAction FromCustom(string value)
    {
        return new FlowActionOtpVerifyCodeAction(value);
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

    public static bool operator ==(FlowActionOtpVerifyCodeAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionOtpVerifyCodeAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionOtpVerifyCodeAction value) => value.Value;

    public static explicit operator FlowActionOtpVerifyCodeAction(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string VerifyCode = "VERIFY_CODE";
    }
}
