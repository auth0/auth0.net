using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<ConnectionTokenEndpointAuthSigningAlgEnum>))]
[Serializable]
public readonly record struct ConnectionTokenEndpointAuthSigningAlgEnum : IStringEnum
{
    public static readonly ConnectionTokenEndpointAuthSigningAlgEnum Es256 = new(Values.Es256);

    public static readonly ConnectionTokenEndpointAuthSigningAlgEnum Es384 = new(Values.Es384);

    public static readonly ConnectionTokenEndpointAuthSigningAlgEnum Ps256 = new(Values.Ps256);

    public static readonly ConnectionTokenEndpointAuthSigningAlgEnum Ps384 = new(Values.Ps384);

    public static readonly ConnectionTokenEndpointAuthSigningAlgEnum Rs256 = new(Values.Rs256);

    public static readonly ConnectionTokenEndpointAuthSigningAlgEnum Rs384 = new(Values.Rs384);

    public static readonly ConnectionTokenEndpointAuthSigningAlgEnum Rs512 = new(Values.Rs512);

    public ConnectionTokenEndpointAuthSigningAlgEnum(string value)
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
    public static ConnectionTokenEndpointAuthSigningAlgEnum FromCustom(string value)
    {
        return new ConnectionTokenEndpointAuthSigningAlgEnum(value);
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
        ConnectionTokenEndpointAuthSigningAlgEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ConnectionTokenEndpointAuthSigningAlgEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionTokenEndpointAuthSigningAlgEnum value) =>
        value.Value;

    public static explicit operator ConnectionTokenEndpointAuthSigningAlgEnum(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Es256 = "ES256";

        public const string Es384 = "ES384";

        public const string Ps256 = "PS256";

        public const string Ps384 = "PS384";

        public const string Rs256 = "RS256";

        public const string Rs384 = "RS384";

        public const string Rs512 = "RS512";
    }
}
