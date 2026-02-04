using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<PartialGroupsEnum>))]
[Serializable]
public readonly record struct PartialGroupsEnum : IStringEnum
{
    public static readonly PartialGroupsEnum Login = new(Values.Login);

    public static readonly PartialGroupsEnum LoginId = new(Values.LoginId);

    public static readonly PartialGroupsEnum LoginPassword = new(Values.LoginPassword);

    public static readonly PartialGroupsEnum LoginPasswordless = new(Values.LoginPasswordless);

    public static readonly PartialGroupsEnum Signup = new(Values.Signup);

    public static readonly PartialGroupsEnum SignupId = new(Values.SignupId);

    public static readonly PartialGroupsEnum SignupPassword = new(Values.SignupPassword);

    public static readonly PartialGroupsEnum CustomizedConsent = new(Values.CustomizedConsent);

    public PartialGroupsEnum(string value)
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
    public static PartialGroupsEnum FromCustom(string value)
    {
        return new PartialGroupsEnum(value);
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

    public static bool operator ==(PartialGroupsEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(PartialGroupsEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(PartialGroupsEnum value) => value.Value;

    public static explicit operator PartialGroupsEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Login = "login";

        public const string LoginId = "login-id";

        public const string LoginPassword = "login-password";

        public const string LoginPasswordless = "login-passwordless";

        public const string Signup = "signup";

        public const string SignupId = "signup-id";

        public const string SignupPassword = "signup-password";

        public const string CustomizedConsent = "customized-consent";
    }
}
