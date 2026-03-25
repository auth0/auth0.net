using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(CustomDomainTypeEnum.CustomDomainTypeEnumSerializer))]
[Serializable]
public readonly record struct CustomDomainTypeEnum : IStringEnum
{
    public static readonly CustomDomainTypeEnum Auth0ManagedCerts = new(Values.Auth0ManagedCerts);

    public static readonly CustomDomainTypeEnum SelfManagedCerts = new(Values.SelfManagedCerts);

    public CustomDomainTypeEnum(string value)
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
    public static CustomDomainTypeEnum FromCustom(string value)
    {
        return new CustomDomainTypeEnum(value);
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

    public static bool operator ==(CustomDomainTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(CustomDomainTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(CustomDomainTypeEnum value) => value.Value;

    public static explicit operator CustomDomainTypeEnum(string value) => new(value);

    internal class CustomDomainTypeEnumSerializer : JsonConverter<CustomDomainTypeEnum>
    {
        public override CustomDomainTypeEnum Read(
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
            return new CustomDomainTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            CustomDomainTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override CustomDomainTypeEnum ReadAsPropertyName(
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
            return new CustomDomainTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CustomDomainTypeEnum value,
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
