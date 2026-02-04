using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<ClientCredentialAlgorithmEnum>))]
[Serializable]
public readonly record struct ClientCredentialAlgorithmEnum : IStringEnum
{
    public static readonly ClientCredentialAlgorithmEnum Rs256 = new(Values.Rs256);

    public static readonly ClientCredentialAlgorithmEnum Rs384 = new(Values.Rs384);

    public static readonly ClientCredentialAlgorithmEnum Ps256 = new(Values.Ps256);

    public ClientCredentialAlgorithmEnum(string value)
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
    public static ClientCredentialAlgorithmEnum FromCustom(string value)
    {
        return new ClientCredentialAlgorithmEnum(value);
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

    public static bool operator ==(ClientCredentialAlgorithmEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ClientCredentialAlgorithmEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ClientCredentialAlgorithmEnum value) => value.Value;

    public static explicit operator ClientCredentialAlgorithmEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Rs256 = "RS256";

        public const string Rs384 = "RS384";

        public const string Ps256 = "PS256";
    }
}
