using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ClientOidcSupportAllowedScopesEnum.ClientOidcSupportAllowedScopesEnumSerializer)
)]
[Serializable]
public readonly record struct ClientOidcSupportAllowedScopesEnum : IStringEnum
{
    public static readonly ClientOidcSupportAllowedScopesEnum Profile = new(Values.Profile);

    public static readonly ClientOidcSupportAllowedScopesEnum Email = new(Values.Email);

    public static readonly ClientOidcSupportAllowedScopesEnum Address = new(Values.Address);

    public static readonly ClientOidcSupportAllowedScopesEnum Phone = new(Values.Phone);

    public ClientOidcSupportAllowedScopesEnum(string value)
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
    public static ClientOidcSupportAllowedScopesEnum FromCustom(string value)
    {
        return new ClientOidcSupportAllowedScopesEnum(value);
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

    public static bool operator ==(ClientOidcSupportAllowedScopesEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ClientOidcSupportAllowedScopesEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ClientOidcSupportAllowedScopesEnum value) => value.Value;

    public static explicit operator ClientOidcSupportAllowedScopesEnum(string value) => new(value);

    internal class ClientOidcSupportAllowedScopesEnumSerializer
        : JsonConverter<ClientOidcSupportAllowedScopesEnum>
    {
        public override ClientOidcSupportAllowedScopesEnum Read(
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
            return new ClientOidcSupportAllowedScopesEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClientOidcSupportAllowedScopesEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ClientOidcSupportAllowedScopesEnum ReadAsPropertyName(
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
            return new ClientOidcSupportAllowedScopesEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ClientOidcSupportAllowedScopesEnum value,
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
