using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(SelfServiceProfileSsoTicketDomainVerificationEnum.SelfServiceProfileSsoTicketDomainVerificationEnumSerializer)
)]
[Serializable]
public readonly record struct SelfServiceProfileSsoTicketDomainVerificationEnum : IStringEnum
{
    public static readonly SelfServiceProfileSsoTicketDomainVerificationEnum None = new(
        Values.None
    );

    public static readonly SelfServiceProfileSsoTicketDomainVerificationEnum Optional = new(
        Values.Optional
    );

    public static readonly SelfServiceProfileSsoTicketDomainVerificationEnum Required = new(
        Values.Required
    );

    public SelfServiceProfileSsoTicketDomainVerificationEnum(string value)
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
    public static SelfServiceProfileSsoTicketDomainVerificationEnum FromCustom(string value)
    {
        return new SelfServiceProfileSsoTicketDomainVerificationEnum(value);
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

    public static bool operator ==(
        SelfServiceProfileSsoTicketDomainVerificationEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        SelfServiceProfileSsoTicketDomainVerificationEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        SelfServiceProfileSsoTicketDomainVerificationEnum value
    ) => value.Value;

    public static explicit operator SelfServiceProfileSsoTicketDomainVerificationEnum(
        string value
    ) => new(value);

    internal class SelfServiceProfileSsoTicketDomainVerificationEnumSerializer
        : JsonConverter<SelfServiceProfileSsoTicketDomainVerificationEnum>
    {
        public override SelfServiceProfileSsoTicketDomainVerificationEnum Read(
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
            return new SelfServiceProfileSsoTicketDomainVerificationEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SelfServiceProfileSsoTicketDomainVerificationEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SelfServiceProfileSsoTicketDomainVerificationEnum ReadAsPropertyName(
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
            return new SelfServiceProfileSsoTicketDomainVerificationEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SelfServiceProfileSsoTicketDomainVerificationEnum value,
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
        public const string None = "none";

        public const string Optional = "optional";

        public const string Required = "required";
    }
}
