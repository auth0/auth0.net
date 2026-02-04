using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<SigningAlgorithmEnum>))]
[Serializable]
public readonly record struct SigningAlgorithmEnum : IStringEnum
{
    public static readonly SigningAlgorithmEnum Hs256 = new(Values.Hs256);

    public static readonly SigningAlgorithmEnum Rs256 = new(Values.Rs256);

    public static readonly SigningAlgorithmEnum Rs512 = new(Values.Rs512);

    public static readonly SigningAlgorithmEnum Ps256 = new(Values.Ps256);

    public SigningAlgorithmEnum(string value)
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
    public static SigningAlgorithmEnum FromCustom(string value)
    {
        return new SigningAlgorithmEnum(value);
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

    public static bool operator ==(SigningAlgorithmEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SigningAlgorithmEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SigningAlgorithmEnum value) => value.Value;

    public static explicit operator SigningAlgorithmEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Hs256 = "HS256";

        public const string Rs256 = "RS256";

        public const string Rs512 = "RS512";

        public const string Ps256 = "PS256";
    }
}
