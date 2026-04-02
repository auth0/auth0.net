using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(DomainCertificateStatusEnum.DomainCertificateStatusEnumSerializer))]
[Serializable]
public readonly record struct DomainCertificateStatusEnum : IStringEnum
{
    public static readonly DomainCertificateStatusEnum Provisioning = new(Values.Provisioning);

    public static readonly DomainCertificateStatusEnum ProvisioningFailed = new(
        Values.ProvisioningFailed
    );

    public static readonly DomainCertificateStatusEnum Provisioned = new(Values.Provisioned);

    public static readonly DomainCertificateStatusEnum RenewingFailed = new(Values.RenewingFailed);

    public DomainCertificateStatusEnum(string value)
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
    public static DomainCertificateStatusEnum FromCustom(string value)
    {
        return new DomainCertificateStatusEnum(value);
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

    public static bool operator ==(DomainCertificateStatusEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DomainCertificateStatusEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DomainCertificateStatusEnum value) => value.Value;

    public static explicit operator DomainCertificateStatusEnum(string value) => new(value);

    internal class DomainCertificateStatusEnumSerializer
        : JsonConverter<DomainCertificateStatusEnum>
    {
        public override DomainCertificateStatusEnum Read(
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
            return new DomainCertificateStatusEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DomainCertificateStatusEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DomainCertificateStatusEnum ReadAsPropertyName(
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
            return new DomainCertificateStatusEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DomainCertificateStatusEnum value,
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
        public const string Provisioning = "provisioning";

        public const string ProvisioningFailed = "provisioning_failed";

        public const string Provisioned = "provisioned";

        public const string RenewingFailed = "renewing_failed";
    }
}
