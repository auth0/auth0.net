using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(DeviceCredentialTypeEnum.DeviceCredentialTypeEnumSerializer))]
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

    internal class DeviceCredentialTypeEnumSerializer : JsonConverter<DeviceCredentialTypeEnum>
    {
        public override DeviceCredentialTypeEnum Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new DeviceCredentialTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DeviceCredentialTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DeviceCredentialTypeEnum ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new DeviceCredentialTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DeviceCredentialTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

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
