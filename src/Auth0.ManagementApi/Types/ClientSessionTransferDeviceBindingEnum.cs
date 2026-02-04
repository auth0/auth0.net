using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<ClientSessionTransferDeviceBindingEnum>))]
[Serializable]
public readonly record struct ClientSessionTransferDeviceBindingEnum : IStringEnum
{
    public static readonly ClientSessionTransferDeviceBindingEnum Ip = new(Values.Ip);

    public static readonly ClientSessionTransferDeviceBindingEnum Asn = new(Values.Asn);

    public static readonly ClientSessionTransferDeviceBindingEnum None = new(Values.None);

    public ClientSessionTransferDeviceBindingEnum(string value)
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
    public static ClientSessionTransferDeviceBindingEnum FromCustom(string value)
    {
        return new ClientSessionTransferDeviceBindingEnum(value);
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

    public static bool operator ==(ClientSessionTransferDeviceBindingEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ClientSessionTransferDeviceBindingEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ClientSessionTransferDeviceBindingEnum value) =>
        value.Value;

    public static explicit operator ClientSessionTransferDeviceBindingEnum(string value) =>
        new(value);

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
