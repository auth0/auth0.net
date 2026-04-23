using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ClientMyOrganizationConfigurationAllowedStrategiesEnum.ClientMyOrganizationConfigurationAllowedStrategiesEnumSerializer)
)]
[Serializable]
public readonly record struct ClientMyOrganizationConfigurationAllowedStrategiesEnum : IStringEnum
{
    public static readonly ClientMyOrganizationConfigurationAllowedStrategiesEnum Pingfederate =
        new(Values.Pingfederate);

    public static readonly ClientMyOrganizationConfigurationAllowedStrategiesEnum Adfs = new(
        Values.Adfs
    );

    public static readonly ClientMyOrganizationConfigurationAllowedStrategiesEnum Waad = new(
        Values.Waad
    );

    public static readonly ClientMyOrganizationConfigurationAllowedStrategiesEnum GoogleApps = new(
        Values.GoogleApps
    );

    public static readonly ClientMyOrganizationConfigurationAllowedStrategiesEnum Okta = new(
        Values.Okta
    );

    public static readonly ClientMyOrganizationConfigurationAllowedStrategiesEnum Oidc = new(
        Values.Oidc
    );

    public static readonly ClientMyOrganizationConfigurationAllowedStrategiesEnum Samlp = new(
        Values.Samlp
    );

    public ClientMyOrganizationConfigurationAllowedStrategiesEnum(string value)
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
    public static ClientMyOrganizationConfigurationAllowedStrategiesEnum FromCustom(string value)
    {
        return new ClientMyOrganizationConfigurationAllowedStrategiesEnum(value);
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
        ClientMyOrganizationConfigurationAllowedStrategiesEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ClientMyOrganizationConfigurationAllowedStrategiesEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ClientMyOrganizationConfigurationAllowedStrategiesEnum value
    ) => value.Value;

    public static explicit operator ClientMyOrganizationConfigurationAllowedStrategiesEnum(
        string value
    ) => new(value);

    internal class ClientMyOrganizationConfigurationAllowedStrategiesEnumSerializer
        : JsonConverter<ClientMyOrganizationConfigurationAllowedStrategiesEnum>
    {
        public override ClientMyOrganizationConfigurationAllowedStrategiesEnum Read(
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
            return new ClientMyOrganizationConfigurationAllowedStrategiesEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClientMyOrganizationConfigurationAllowedStrategiesEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ClientMyOrganizationConfigurationAllowedStrategiesEnum ReadAsPropertyName(
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
            return new ClientMyOrganizationConfigurationAllowedStrategiesEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ClientMyOrganizationConfigurationAllowedStrategiesEnum value,
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
        public const string Pingfederate = "pingfederate";

        public const string Adfs = "adfs";

        public const string Waad = "waad";

        public const string GoogleApps = "google-apps";

        public const string Okta = "okta";

        public const string Oidc = "oidc";

        public const string Samlp = "samlp";
    }
}
