using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ClientOidcBackchannelLogoutInitiatorsModeEnum.ClientOidcBackchannelLogoutInitiatorsModeEnumSerializer)
)]
[Serializable]
public readonly record struct ClientOidcBackchannelLogoutInitiatorsModeEnum : IStringEnum
{
    public static readonly ClientOidcBackchannelLogoutInitiatorsModeEnum Custom = new(
        Values.Custom
    );

    public static readonly ClientOidcBackchannelLogoutInitiatorsModeEnum All = new(Values.All);

    public ClientOidcBackchannelLogoutInitiatorsModeEnum(string value)
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
    public static ClientOidcBackchannelLogoutInitiatorsModeEnum FromCustom(string value)
    {
        return new ClientOidcBackchannelLogoutInitiatorsModeEnum(value);
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
        ClientOidcBackchannelLogoutInitiatorsModeEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ClientOidcBackchannelLogoutInitiatorsModeEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ClientOidcBackchannelLogoutInitiatorsModeEnum value) =>
        value.Value;

    public static explicit operator ClientOidcBackchannelLogoutInitiatorsModeEnum(string value) =>
        new(value);

    internal class ClientOidcBackchannelLogoutInitiatorsModeEnumSerializer
        : JsonConverter<ClientOidcBackchannelLogoutInitiatorsModeEnum>
    {
        public override ClientOidcBackchannelLogoutInitiatorsModeEnum Read(
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
            return new ClientOidcBackchannelLogoutInitiatorsModeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClientOidcBackchannelLogoutInitiatorsModeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ClientOidcBackchannelLogoutInitiatorsModeEnum ReadAsPropertyName(
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
            return new ClientOidcBackchannelLogoutInitiatorsModeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ClientOidcBackchannelLogoutInitiatorsModeEnum value,
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
        public const string Custom = "custom";

        public const string All = "all";
    }
}
