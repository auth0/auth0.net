using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<VerificationMethodEnum>))]
[Serializable]
public readonly record struct VerificationMethodEnum : IStringEnum
{
    public static readonly VerificationMethodEnum Link = new(Values.Link);

    public static readonly VerificationMethodEnum Otp = new(Values.Otp);

    public VerificationMethodEnum(string value)
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
    public static VerificationMethodEnum FromCustom(string value)
    {
        return new VerificationMethodEnum(value);
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

    public static bool operator ==(VerificationMethodEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(VerificationMethodEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(VerificationMethodEnum value) => value.Value;

    public static explicit operator VerificationMethodEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Link = "link";

        public const string Otp = "otp";
    }
}
