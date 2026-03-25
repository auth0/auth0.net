using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(CustomDomainProvisioningTypeEnum.CustomDomainProvisioningTypeEnumSerializer))]
[Serializable]
public readonly record struct CustomDomainProvisioningTypeEnum : IStringEnum
{
    public static readonly CustomDomainProvisioningTypeEnum Auth0ManagedCerts = new(
        Values.Auth0ManagedCerts
    );

    public static readonly CustomDomainProvisioningTypeEnum SelfManagedCerts = new(
        Values.SelfManagedCerts
    );

    public CustomDomainProvisioningTypeEnum(string value)
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
    public static CustomDomainProvisioningTypeEnum FromCustom(string value)
    {
        return new CustomDomainProvisioningTypeEnum(value);
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

    public static bool operator ==(CustomDomainProvisioningTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CustomDomainProvisioningTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CustomDomainProvisioningTypeEnum value) => value.Value;

    public static explicit operator CustomDomainProvisioningTypeEnum(string value) => new(value);

    internal class CustomDomainProvisioningTypeEnumSerializer
        : JsonConverter<CustomDomainProvisioningTypeEnum>
    {
        public override CustomDomainProvisioningTypeEnum Read(
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
            return new CustomDomainProvisioningTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CustomDomainProvisioningTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CustomDomainProvisioningTypeEnum ReadAsPropertyName(
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
            return new CustomDomainProvisioningTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CustomDomainProvisioningTypeEnum value,
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
        public const string Auth0ManagedCerts = "auth0_managed_certs";

        public const string SelfManagedCerts = "self_managed_certs";
    }
}
