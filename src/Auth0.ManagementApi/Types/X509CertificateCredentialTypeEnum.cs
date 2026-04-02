using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(X509CertificateCredentialTypeEnum.X509CertificateCredentialTypeEnumSerializer)
)]
[Serializable]
public readonly record struct X509CertificateCredentialTypeEnum : IStringEnum
{
    public static readonly X509CertificateCredentialTypeEnum X509Cert = new(Values.X509Cert);

    public X509CertificateCredentialTypeEnum(string value)
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
    public static X509CertificateCredentialTypeEnum FromCustom(string value)
    {
        return new X509CertificateCredentialTypeEnum(value);
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

    public static bool operator ==(X509CertificateCredentialTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(X509CertificateCredentialTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(X509CertificateCredentialTypeEnum value) => value.Value;

    public static explicit operator X509CertificateCredentialTypeEnum(string value) => new(value);

    internal class X509CertificateCredentialTypeEnumSerializer
        : JsonConverter<X509CertificateCredentialTypeEnum>
    {
        public override X509CertificateCredentialTypeEnum Read(
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
            return new X509CertificateCredentialTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            X509CertificateCredentialTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override X509CertificateCredentialTypeEnum ReadAsPropertyName(
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
            return new X509CertificateCredentialTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            X509CertificateCredentialTypeEnum value,
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
        public const string X509Cert = "x509_cert";
    }
}
