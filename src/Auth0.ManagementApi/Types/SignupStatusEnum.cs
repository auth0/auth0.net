using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<SignupStatusEnum>))]
[Serializable]
public readonly record struct SignupStatusEnum : IStringEnum
{
    public static readonly SignupStatusEnum Required = new(Values.Required);

    public static readonly SignupStatusEnum Optional = new(Values.Optional);

    public static readonly SignupStatusEnum Inactive = new(Values.Inactive);

    public SignupStatusEnum(string value)
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
    public static SignupStatusEnum FromCustom(string value)
    {
        return new SignupStatusEnum(value);
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

    public static bool operator ==(SignupStatusEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SignupStatusEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SignupStatusEnum value) => value.Value;

    public static explicit operator SignupStatusEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Required = "required";

        public const string Optional = "optional";

        public const string Inactive = "inactive";
    }
}
