using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<RotateConnectionKeysSigningAlgEnum>))]
[Serializable]
public readonly record struct RotateConnectionKeysSigningAlgEnum : IStringEnum
{
    public static readonly RotateConnectionKeysSigningAlgEnum Rs256 = new(Values.Rs256);

    public static readonly RotateConnectionKeysSigningAlgEnum Rs384 = new(Values.Rs384);

    public static readonly RotateConnectionKeysSigningAlgEnum Rs512 = new(Values.Rs512);

    public static readonly RotateConnectionKeysSigningAlgEnum Ps256 = new(Values.Ps256);

    public static readonly RotateConnectionKeysSigningAlgEnum Ps384 = new(Values.Ps384);

    public static readonly RotateConnectionKeysSigningAlgEnum Es256 = new(Values.Es256);

    public static readonly RotateConnectionKeysSigningAlgEnum Es384 = new(Values.Es384);

    public RotateConnectionKeysSigningAlgEnum(string value)
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
    public static RotateConnectionKeysSigningAlgEnum FromCustom(string value)
    {
        return new RotateConnectionKeysSigningAlgEnum(value);
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

    public static bool operator ==(RotateConnectionKeysSigningAlgEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(RotateConnectionKeysSigningAlgEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(RotateConnectionKeysSigningAlgEnum value) => value.Value;

    public static explicit operator RotateConnectionKeysSigningAlgEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Rs256 = "RS256";

        public const string Rs384 = "RS384";

        public const string Rs512 = "RS512";

        public const string Ps256 = "PS256";

        public const string Ps384 = "PS384";

        public const string Es256 = "ES256";

        public const string Es384 = "ES384";
    }
}
