using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<DefaultMethodEmailIdentifierEnum>))]
[Serializable]
public readonly record struct DefaultMethodEmailIdentifierEnum : IStringEnum
{
    public static readonly DefaultMethodEmailIdentifierEnum Password = new(Values.Password);

    public static readonly DefaultMethodEmailIdentifierEnum EmailOtp = new(Values.EmailOtp);

    public DefaultMethodEmailIdentifierEnum(string value)
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
    public static DefaultMethodEmailIdentifierEnum FromCustom(string value)
    {
        return new DefaultMethodEmailIdentifierEnum(value);
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

    public static bool operator ==(DefaultMethodEmailIdentifierEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DefaultMethodEmailIdentifierEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DefaultMethodEmailIdentifierEnum value) => value.Value;

    public static explicit operator DefaultMethodEmailIdentifierEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Password = "password";

        public const string EmailOtp = "email_otp";
    }
}
