using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(SelfServiceProfileSsoTicketIdpInitiatedClientProtocolEnum.SelfServiceProfileSsoTicketIdpInitiatedClientProtocolEnumSerializer)
)]
[Serializable]
public readonly record struct SelfServiceProfileSsoTicketIdpInitiatedClientProtocolEnum
    : IStringEnum
{
    public static readonly SelfServiceProfileSsoTicketIdpInitiatedClientProtocolEnum Samlp = new(
        Values.Samlp
    );

    public static readonly SelfServiceProfileSsoTicketIdpInitiatedClientProtocolEnum Wsfed = new(
        Values.Wsfed
    );

    public static readonly SelfServiceProfileSsoTicketIdpInitiatedClientProtocolEnum Oauth2 = new(
        Values.Oauth2
    );

    public SelfServiceProfileSsoTicketIdpInitiatedClientProtocolEnum(string value)
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
    public static SelfServiceProfileSsoTicketIdpInitiatedClientProtocolEnum FromCustom(string value)
    {
        return new SelfServiceProfileSsoTicketIdpInitiatedClientProtocolEnum(value);
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
        SelfServiceProfileSsoTicketIdpInitiatedClientProtocolEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        SelfServiceProfileSsoTicketIdpInitiatedClientProtocolEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        SelfServiceProfileSsoTicketIdpInitiatedClientProtocolEnum value
    ) => value.Value;

    public static explicit operator SelfServiceProfileSsoTicketIdpInitiatedClientProtocolEnum(
        string value
    ) => new(value);

    internal class SelfServiceProfileSsoTicketIdpInitiatedClientProtocolEnumSerializer
        : JsonConverter<SelfServiceProfileSsoTicketIdpInitiatedClientProtocolEnum>
    {
        public override SelfServiceProfileSsoTicketIdpInitiatedClientProtocolEnum Read(
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
            return new SelfServiceProfileSsoTicketIdpInitiatedClientProtocolEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SelfServiceProfileSsoTicketIdpInitiatedClientProtocolEnum value,
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
        public const string Samlp = "samlp";

        public const string Wsfed = "wsfed";

        public const string Oauth2 = "oauth2";
    }
}
