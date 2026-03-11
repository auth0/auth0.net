using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<ConnectionDpopSigningAlgEnum>))]
[Serializable]
public readonly record struct ConnectionDpopSigningAlgEnum : IStringEnum
{
    public static readonly ConnectionDpopSigningAlgEnum Es256 = new(Values.Es256);

    public static readonly ConnectionDpopSigningAlgEnum Ed25519 = new(Values.Ed25519);

    public ConnectionDpopSigningAlgEnum(string value)
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
    public static ConnectionDpopSigningAlgEnum FromCustom(string value)
    {
        return new ConnectionDpopSigningAlgEnum(value);
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

    public static bool operator ==(ConnectionDpopSigningAlgEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionDpopSigningAlgEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionDpopSigningAlgEnum value) => value.Value;

    public static explicit operator ConnectionDpopSigningAlgEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Es256 = "ES256";

        public const string Ed25519 = "Ed25519";
    }
}
