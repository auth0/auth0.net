using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ClientProfileClientConfigurationOrganizationUsageEnum.ClientProfileClientConfigurationOrganizationUsageEnumSerializer)
)]
[Serializable]
public readonly record struct ClientProfileClientConfigurationOrganizationUsageEnum : IStringEnum
{
    public static readonly ClientProfileClientConfigurationOrganizationUsageEnum Deny = new(
        Values.Deny
    );

    public static readonly ClientProfileClientConfigurationOrganizationUsageEnum Allow = new(
        Values.Allow
    );

    public static readonly ClientProfileClientConfigurationOrganizationUsageEnum Require = new(
        Values.Require
    );

    public ClientProfileClientConfigurationOrganizationUsageEnum(string value)
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
    public static ClientProfileClientConfigurationOrganizationUsageEnum FromCustom(string value)
    {
        return new ClientProfileClientConfigurationOrganizationUsageEnum(value);
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
        ClientProfileClientConfigurationOrganizationUsageEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ClientProfileClientConfigurationOrganizationUsageEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ClientProfileClientConfigurationOrganizationUsageEnum value
    ) => value.Value;

    public static explicit operator ClientProfileClientConfigurationOrganizationUsageEnum(
        string value
    ) => new(value);

    internal class ClientProfileClientConfigurationOrganizationUsageEnumSerializer
        : JsonConverter<ClientProfileClientConfigurationOrganizationUsageEnum>
    {
        public override ClientProfileClientConfigurationOrganizationUsageEnum Read(
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
            return new ClientProfileClientConfigurationOrganizationUsageEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClientProfileClientConfigurationOrganizationUsageEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ClientProfileClientConfigurationOrganizationUsageEnum ReadAsPropertyName(
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
            return new ClientProfileClientConfigurationOrganizationUsageEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ClientProfileClientConfigurationOrganizationUsageEnum value,
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
        public const string Deny = "deny";

        public const string Allow = "allow";

        public const string Require = "require";
    }
}
