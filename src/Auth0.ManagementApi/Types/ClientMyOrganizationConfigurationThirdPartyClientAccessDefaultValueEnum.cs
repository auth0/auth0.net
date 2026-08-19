using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ClientMyOrganizationConfigurationThirdPartyClientAccessDefaultValueEnum.ClientMyOrganizationConfigurationThirdPartyClientAccessDefaultValueEnumSerializer)
)]
[Serializable]
public readonly record struct ClientMyOrganizationConfigurationThirdPartyClientAccessDefaultValueEnum
    : IStringEnum
{
    public static readonly ClientMyOrganizationConfigurationThirdPartyClientAccessDefaultValueEnum Block =
        new(Values.Block);

    public ClientMyOrganizationConfigurationThirdPartyClientAccessDefaultValueEnum(string value)
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
    public static ClientMyOrganizationConfigurationThirdPartyClientAccessDefaultValueEnum FromCustom(
        string value
    )
    {
        return new ClientMyOrganizationConfigurationThirdPartyClientAccessDefaultValueEnum(value);
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
        ClientMyOrganizationConfigurationThirdPartyClientAccessDefaultValueEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ClientMyOrganizationConfigurationThirdPartyClientAccessDefaultValueEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ClientMyOrganizationConfigurationThirdPartyClientAccessDefaultValueEnum value
    ) => value.Value;

    public static explicit operator ClientMyOrganizationConfigurationThirdPartyClientAccessDefaultValueEnum(
        string value
    ) => new(value);

    internal class ClientMyOrganizationConfigurationThirdPartyClientAccessDefaultValueEnumSerializer
        : JsonConverter<ClientMyOrganizationConfigurationThirdPartyClientAccessDefaultValueEnum>
    {
        public override ClientMyOrganizationConfigurationThirdPartyClientAccessDefaultValueEnum Read(
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
            return new ClientMyOrganizationConfigurationThirdPartyClientAccessDefaultValueEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClientMyOrganizationConfigurationThirdPartyClientAccessDefaultValueEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ClientMyOrganizationConfigurationThirdPartyClientAccessDefaultValueEnum ReadAsPropertyName(
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
            return new ClientMyOrganizationConfigurationThirdPartyClientAccessDefaultValueEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ClientMyOrganizationConfigurationThirdPartyClientAccessDefaultValueEnum value,
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
        public const string Block = "block";
    }
}
