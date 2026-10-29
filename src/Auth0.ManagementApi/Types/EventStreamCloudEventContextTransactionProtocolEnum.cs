using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventContextTransactionProtocolEnum.EventStreamCloudEventContextTransactionProtocolEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventContextTransactionProtocolEnum : IStringEnum
{
    public static readonly EventStreamCloudEventContextTransactionProtocolEnum OidcBasicProfile =
        new(Values.OidcBasicProfile);

    public static readonly EventStreamCloudEventContextTransactionProtocolEnum OidcImplicitProfile =
        new(Values.OidcImplicitProfile);

    public static readonly EventStreamCloudEventContextTransactionProtocolEnum Oauth2DeviceCode =
        new(Values.Oauth2DeviceCode);

    public static readonly EventStreamCloudEventContextTransactionProtocolEnum Oauth2ResourceOwner =
        new(Values.Oauth2ResourceOwner);

    public static readonly EventStreamCloudEventContextTransactionProtocolEnum Oauth2ResourceOwnerJwtBearer =
        new(Values.Oauth2ResourceOwnerJwtBearer);

    public static readonly EventStreamCloudEventContextTransactionProtocolEnum Oauth2Password = new(
        Values.Oauth2Password
    );

    public static readonly EventStreamCloudEventContextTransactionProtocolEnum Oauth2Webauthn = new(
        Values.Oauth2Webauthn
    );

    public static readonly EventStreamCloudEventContextTransactionProtocolEnum Oauth2AccessToken =
        new(Values.Oauth2AccessToken);

    public static readonly EventStreamCloudEventContextTransactionProtocolEnum Oauth2RefreshToken =
        new(Values.Oauth2RefreshToken);

    public static readonly EventStreamCloudEventContextTransactionProtocolEnum Oauth2TokenExchange =
        new(Values.Oauth2TokenExchange);

    public static readonly EventStreamCloudEventContextTransactionProtocolEnum OidcHybridProfile =
        new(Values.OidcHybridProfile);

    public static readonly EventStreamCloudEventContextTransactionProtocolEnum Samlp = new(
        Values.Samlp
    );

    public static readonly EventStreamCloudEventContextTransactionProtocolEnum Wsfed = new(
        Values.Wsfed
    );

    public static readonly EventStreamCloudEventContextTransactionProtocolEnum WstrustUsernamemixed =
        new(Values.WstrustUsernamemixed);

    public EventStreamCloudEventContextTransactionProtocolEnum(string value)
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
    public static EventStreamCloudEventContextTransactionProtocolEnum FromCustom(string value)
    {
        return new EventStreamCloudEventContextTransactionProtocolEnum(value);
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
        EventStreamCloudEventContextTransactionProtocolEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventContextTransactionProtocolEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventContextTransactionProtocolEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventContextTransactionProtocolEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventContextTransactionProtocolEnumSerializer
        : JsonConverter<EventStreamCloudEventContextTransactionProtocolEnum>
    {
        public override EventStreamCloudEventContextTransactionProtocolEnum Read(
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
            return new EventStreamCloudEventContextTransactionProtocolEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventContextTransactionProtocolEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventContextTransactionProtocolEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventContextTransactionProtocolEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventContextTransactionProtocolEnum value,
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
        public const string OidcBasicProfile = "oidc-basic-profile";

        public const string OidcImplicitProfile = "oidc-implicit-profile";

        public const string Oauth2DeviceCode = "oauth2-device-code";

        public const string Oauth2ResourceOwner = "oauth2-resource-owner";

        public const string Oauth2ResourceOwnerJwtBearer = "oauth2-resource-owner-jwt-bearer";

        public const string Oauth2Password = "oauth2-password";

        public const string Oauth2Webauthn = "oauth2-webauthn";

        public const string Oauth2AccessToken = "oauth2-access-token";

        public const string Oauth2RefreshToken = "oauth2-refresh-token";

        public const string Oauth2TokenExchange = "oauth2-token-exchange";

        public const string OidcHybridProfile = "oidc-hybrid-profile";

        public const string Samlp = "samlp";

        public const string Wsfed = "wsfed";

        public const string WstrustUsernamemixed = "wstrust-usernamemixed";
    }
}
