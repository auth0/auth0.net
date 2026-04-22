using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(ClientThirdPartySecurityModeEnum.ClientThirdPartySecurityModeEnumSerializer))]
[Serializable]
public readonly record struct ClientThirdPartySecurityModeEnum : IStringEnum
{
    public static readonly ClientThirdPartySecurityModeEnum Strict = new(Values.Strict);

    public static readonly ClientThirdPartySecurityModeEnum Permissive = new(Values.Permissive);

    public ClientThirdPartySecurityModeEnum(string value)
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
    public static ClientThirdPartySecurityModeEnum FromCustom(string value)
    {
        return new ClientThirdPartySecurityModeEnum(value);
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

    public static bool operator ==(ClientThirdPartySecurityModeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ClientThirdPartySecurityModeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ClientThirdPartySecurityModeEnum value) => value.Value;

    public static explicit operator ClientThirdPartySecurityModeEnum(string value) => new(value);

    internal class ClientThirdPartySecurityModeEnumSerializer
        : JsonConverter<ClientThirdPartySecurityModeEnum>
    {
        public override ClientThirdPartySecurityModeEnum Read(
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
            return new ClientThirdPartySecurityModeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClientThirdPartySecurityModeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ClientThirdPartySecurityModeEnum ReadAsPropertyName(
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
            return new ClientThirdPartySecurityModeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ClientThirdPartySecurityModeEnum value,
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
        public const string Strict = "strict";

        public const string Permissive = "permissive";
    }
}
