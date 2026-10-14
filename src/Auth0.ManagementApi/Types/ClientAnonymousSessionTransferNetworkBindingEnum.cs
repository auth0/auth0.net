using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ClientAnonymousSessionTransferNetworkBindingEnum.ClientAnonymousSessionTransferNetworkBindingEnumSerializer)
)]
[Serializable]
public readonly record struct ClientAnonymousSessionTransferNetworkBindingEnum : IStringEnum
{
    public static readonly ClientAnonymousSessionTransferNetworkBindingEnum Ip = new(Values.Ip);

    public static readonly ClientAnonymousSessionTransferNetworkBindingEnum Asn = new(Values.Asn);

    public static readonly ClientAnonymousSessionTransferNetworkBindingEnum None = new(Values.None);

    public ClientAnonymousSessionTransferNetworkBindingEnum(string value)
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
    public static ClientAnonymousSessionTransferNetworkBindingEnum FromCustom(string value)
    {
        return new ClientAnonymousSessionTransferNetworkBindingEnum(value);
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
        ClientAnonymousSessionTransferNetworkBindingEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ClientAnonymousSessionTransferNetworkBindingEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ClientAnonymousSessionTransferNetworkBindingEnum value
    ) => value.Value;

    public static explicit operator ClientAnonymousSessionTransferNetworkBindingEnum(
        string value
    ) => new(value);

    internal class ClientAnonymousSessionTransferNetworkBindingEnumSerializer
        : JsonConverter<ClientAnonymousSessionTransferNetworkBindingEnum>
    {
        public override ClientAnonymousSessionTransferNetworkBindingEnum Read(
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
            return new ClientAnonymousSessionTransferNetworkBindingEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClientAnonymousSessionTransferNetworkBindingEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ClientAnonymousSessionTransferNetworkBindingEnum ReadAsPropertyName(
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
            return new ClientAnonymousSessionTransferNetworkBindingEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ClientAnonymousSessionTransferNetworkBindingEnum value,
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
        public const string Ip = "ip";

        public const string Asn = "asn";

        public const string None = "none";
    }
}
