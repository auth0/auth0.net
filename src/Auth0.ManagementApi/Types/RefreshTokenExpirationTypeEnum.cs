using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<RefreshTokenExpirationTypeEnum>))]
[Serializable]
public readonly record struct RefreshTokenExpirationTypeEnum : IStringEnum
{
    public static readonly RefreshTokenExpirationTypeEnum Expiring = new(Values.Expiring);

    public static readonly RefreshTokenExpirationTypeEnum NonExpiring = new(Values.NonExpiring);

    public RefreshTokenExpirationTypeEnum(string value)
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
    public static RefreshTokenExpirationTypeEnum FromCustom(string value)
    {
        return new RefreshTokenExpirationTypeEnum(value);
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

    public static bool operator ==(RefreshTokenExpirationTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(RefreshTokenExpirationTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(RefreshTokenExpirationTypeEnum value) => value.Value;

    public static explicit operator RefreshTokenExpirationTypeEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Expiring = "expiring";

        public const string NonExpiring = "non-expiring";
    }
}
