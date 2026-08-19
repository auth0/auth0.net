using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ClientMyOrganizationConfigurationThirdPartyClientAccessAllowedValuesEnum.ClientMyOrganizationConfigurationThirdPartyClientAccessAllowedValuesEnumSerializer)
)]
[Serializable]
public readonly record struct ClientMyOrganizationConfigurationThirdPartyClientAccessAllowedValuesEnum
    : IStringEnum
{
    public static readonly ClientMyOrganizationConfigurationThirdPartyClientAccessAllowedValuesEnum Allow =
        new(Values.Allow);

    public static readonly ClientMyOrganizationConfigurationThirdPartyClientAccessAllowedValuesEnum Block =
        new(Values.Block);

    public ClientMyOrganizationConfigurationThirdPartyClientAccessAllowedValuesEnum(string value)
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
    public static ClientMyOrganizationConfigurationThirdPartyClientAccessAllowedValuesEnum FromCustom(
        string value
    )
    {
        return new ClientMyOrganizationConfigurationThirdPartyClientAccessAllowedValuesEnum(value);
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
        ClientMyOrganizationConfigurationThirdPartyClientAccessAllowedValuesEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ClientMyOrganizationConfigurationThirdPartyClientAccessAllowedValuesEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ClientMyOrganizationConfigurationThirdPartyClientAccessAllowedValuesEnum value
    ) => value.Value;

    public static explicit operator ClientMyOrganizationConfigurationThirdPartyClientAccessAllowedValuesEnum(
        string value
    ) => new(value);

    internal class ClientMyOrganizationConfigurationThirdPartyClientAccessAllowedValuesEnumSerializer
        : JsonConverter<ClientMyOrganizationConfigurationThirdPartyClientAccessAllowedValuesEnum>
    {
        public override ClientMyOrganizationConfigurationThirdPartyClientAccessAllowedValuesEnum Read(
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
            return new ClientMyOrganizationConfigurationThirdPartyClientAccessAllowedValuesEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClientMyOrganizationConfigurationThirdPartyClientAccessAllowedValuesEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ClientMyOrganizationConfigurationThirdPartyClientAccessAllowedValuesEnum ReadAsPropertyName(
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
            return new ClientMyOrganizationConfigurationThirdPartyClientAccessAllowedValuesEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ClientMyOrganizationConfigurationThirdPartyClientAccessAllowedValuesEnum value,
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
        public const string Allow = "allow";

        public const string Block = "block";
    }
}
