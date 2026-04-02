using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(DomainCertificateAuthorityEnum.DomainCertificateAuthorityEnumSerializer))]
[Serializable]
public readonly record struct DomainCertificateAuthorityEnum : IStringEnum
{
    public static readonly DomainCertificateAuthorityEnum Letsencrypt = new(Values.Letsencrypt);

    public static readonly DomainCertificateAuthorityEnum Googletrust = new(Values.Googletrust);

    public DomainCertificateAuthorityEnum(string value)
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
    public static DomainCertificateAuthorityEnum FromCustom(string value)
    {
        return new DomainCertificateAuthorityEnum(value);
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

    public static bool operator ==(DomainCertificateAuthorityEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(DomainCertificateAuthorityEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(DomainCertificateAuthorityEnum value) => value.Value;

    public static explicit operator DomainCertificateAuthorityEnum(string value) => new(value);

    internal class DomainCertificateAuthorityEnumSerializer
        : JsonConverter<DomainCertificateAuthorityEnum>
    {
        public override DomainCertificateAuthorityEnum Read(
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
            return new DomainCertificateAuthorityEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DomainCertificateAuthorityEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override DomainCertificateAuthorityEnum ReadAsPropertyName(
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
            return new DomainCertificateAuthorityEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            DomainCertificateAuthorityEnum value,
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
        public const string Letsencrypt = "letsencrypt";

        public const string Googletrust = "googletrust";
    }
}
