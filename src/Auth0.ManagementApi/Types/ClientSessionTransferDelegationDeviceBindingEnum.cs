using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ClientSessionTransferDelegationDeviceBindingEnum.ClientSessionTransferDelegationDeviceBindingEnumSerializer)
)]
[Serializable]
public readonly record struct ClientSessionTransferDelegationDeviceBindingEnum : IStringEnum
{
    public static readonly ClientSessionTransferDelegationDeviceBindingEnum Ip = new(Values.Ip);

    public static readonly ClientSessionTransferDelegationDeviceBindingEnum Asn = new(Values.Asn);

    public ClientSessionTransferDelegationDeviceBindingEnum(string value)
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
    public static ClientSessionTransferDelegationDeviceBindingEnum FromCustom(string value)
    {
        return new ClientSessionTransferDelegationDeviceBindingEnum(value);
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
        ClientSessionTransferDelegationDeviceBindingEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ClientSessionTransferDelegationDeviceBindingEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ClientSessionTransferDelegationDeviceBindingEnum value
    ) => value.Value;

    public static explicit operator ClientSessionTransferDelegationDeviceBindingEnum(
        string value
    ) => new(value);

    internal class ClientSessionTransferDelegationDeviceBindingEnumSerializer
        : JsonConverter<ClientSessionTransferDelegationDeviceBindingEnum>
    {
        public override ClientSessionTransferDelegationDeviceBindingEnum Read(
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
            return new ClientSessionTransferDelegationDeviceBindingEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClientSessionTransferDelegationDeviceBindingEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ClientSessionTransferDelegationDeviceBindingEnum ReadAsPropertyName(
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
            return new ClientSessionTransferDelegationDeviceBindingEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ClientSessionTransferDelegationDeviceBindingEnum value,
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
    }
}
