using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<ConnectionIdentifierPrecedenceEnum>))]
[Serializable]
public readonly record struct ConnectionIdentifierPrecedenceEnum : IStringEnum
{
    public static readonly ConnectionIdentifierPrecedenceEnum Email = new(Values.Email);

    public static readonly ConnectionIdentifierPrecedenceEnum PhoneNumber = new(Values.PhoneNumber);

    public static readonly ConnectionIdentifierPrecedenceEnum Username = new(Values.Username);

    public ConnectionIdentifierPrecedenceEnum(string value)
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
    public static ConnectionIdentifierPrecedenceEnum FromCustom(string value)
    {
        return new ConnectionIdentifierPrecedenceEnum(value);
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

    public static bool operator ==(ConnectionIdentifierPrecedenceEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionIdentifierPrecedenceEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionIdentifierPrecedenceEnum value) => value.Value;

    public static explicit operator ConnectionIdentifierPrecedenceEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Email = "email";

        public const string PhoneNumber = "phone_number";

        public const string Username = "username";
    }
}
