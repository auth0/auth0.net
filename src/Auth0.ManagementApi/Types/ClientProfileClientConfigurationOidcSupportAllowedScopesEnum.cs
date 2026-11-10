using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ClientProfileClientConfigurationOidcSupportAllowedScopesEnum.ClientProfileClientConfigurationOidcSupportAllowedScopesEnumSerializer)
)]
[Serializable]
public readonly record struct ClientProfileClientConfigurationOidcSupportAllowedScopesEnum
    : IStringEnum
{
    public static readonly ClientProfileClientConfigurationOidcSupportAllowedScopesEnum Profile =
        new(Values.Profile);

    public static readonly ClientProfileClientConfigurationOidcSupportAllowedScopesEnum Email = new(
        Values.Email
    );

    public static readonly ClientProfileClientConfigurationOidcSupportAllowedScopesEnum Address =
        new(Values.Address);

    public static readonly ClientProfileClientConfigurationOidcSupportAllowedScopesEnum Phone = new(
        Values.Phone
    );

    public ClientProfileClientConfigurationOidcSupportAllowedScopesEnum(string value)
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
    public static ClientProfileClientConfigurationOidcSupportAllowedScopesEnum FromCustom(
        string value
    )
    {
        return new ClientProfileClientConfigurationOidcSupportAllowedScopesEnum(value);
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
        ClientProfileClientConfigurationOidcSupportAllowedScopesEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ClientProfileClientConfigurationOidcSupportAllowedScopesEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ClientProfileClientConfigurationOidcSupportAllowedScopesEnum value
    ) => value.Value;

    public static explicit operator ClientProfileClientConfigurationOidcSupportAllowedScopesEnum(
        string value
    ) => new(value);

    internal class ClientProfileClientConfigurationOidcSupportAllowedScopesEnumSerializer
        : JsonConverter<ClientProfileClientConfigurationOidcSupportAllowedScopesEnum>
    {
        public override ClientProfileClientConfigurationOidcSupportAllowedScopesEnum Read(
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
            return new ClientProfileClientConfigurationOidcSupportAllowedScopesEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClientProfileClientConfigurationOidcSupportAllowedScopesEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ClientProfileClientConfigurationOidcSupportAllowedScopesEnum ReadAsPropertyName(
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
            return new ClientProfileClientConfigurationOidcSupportAllowedScopesEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ClientProfileClientConfigurationOidcSupportAllowedScopesEnum value,
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
        public const string Profile = "profile";

        public const string Email = "email";

        public const string Address = "address";

        public const string Phone = "phone";
    }
}
