using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(SuspiciousIpThrottlingShieldsEnum.SuspiciousIpThrottlingShieldsEnumSerializer)
)]
[Serializable]
public readonly record struct SuspiciousIpThrottlingShieldsEnum : IStringEnum
{
    public static readonly SuspiciousIpThrottlingShieldsEnum Block = new(Values.Block);

    public static readonly SuspiciousIpThrottlingShieldsEnum AdminNotification = new(
        Values.AdminNotification
    );

    public SuspiciousIpThrottlingShieldsEnum(string value)
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
    public static SuspiciousIpThrottlingShieldsEnum FromCustom(string value)
    {
        return new SuspiciousIpThrottlingShieldsEnum(value);
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

    public static bool operator ==(SuspiciousIpThrottlingShieldsEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SuspiciousIpThrottlingShieldsEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SuspiciousIpThrottlingShieldsEnum value) => value.Value;

    public static explicit operator SuspiciousIpThrottlingShieldsEnum(string value) => new(value);

    internal class SuspiciousIpThrottlingShieldsEnumSerializer
        : JsonConverter<SuspiciousIpThrottlingShieldsEnum>
    {
        public override SuspiciousIpThrottlingShieldsEnum Read(
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
            return new SuspiciousIpThrottlingShieldsEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SuspiciousIpThrottlingShieldsEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Block = "block";

        public const string AdminNotification = "admin_notification";
    }
}
