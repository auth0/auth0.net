using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<RefreshTokenRotationTypeEnum>))]
[Serializable]
public readonly record struct RefreshTokenRotationTypeEnum : IStringEnum
{
    public static readonly RefreshTokenRotationTypeEnum Rotating = new(Values.Rotating);

    public static readonly RefreshTokenRotationTypeEnum NonRotating = new(Values.NonRotating);

    public RefreshTokenRotationTypeEnum(string value)
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
    public static RefreshTokenRotationTypeEnum FromCustom(string value)
    {
        return new RefreshTokenRotationTypeEnum(value);
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

    public static bool operator ==(RefreshTokenRotationTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(RefreshTokenRotationTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(RefreshTokenRotationTypeEnum value) => value.Value;

    public static explicit operator RefreshTokenRotationTypeEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Rotating = "rotating";

        public const string NonRotating = "non-rotating";
    }
}
