using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<DeviceCredentialTypeEnum>))]
[Serializable]
public readonly record struct DeviceCredentialTypeEnum : IStringEnum
{
    public static readonly DeviceCredentialTypeEnum PublicKey = new(Values.PublicKey);

    public static readonly DeviceCredentialTypeEnum RefreshToken = new(Values.RefreshToken);

    public static readonly DeviceCredentialTypeEnum RotatingRefreshToken = new(
        Values.RotatingRefreshToken
    );

    public DeviceCredentialTypeEnum(string value)
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
    public static DeviceCredentialTypeEnum FromCustom(string value)
    {
        return new DeviceCredentialTypeEnum(value);
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

    public static bool operator ==(DeviceCredentialTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DeviceCredentialTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DeviceCredentialTypeEnum value) => value.Value;

    public static explicit operator DeviceCredentialTypeEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string PublicKey = "public_key";

        public const string RefreshToken = "refresh_token";

        public const string RotatingRefreshToken = "rotating_refresh_token";
    }
}
