using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<TokenExchangeProfileTypeEnum>))]
[Serializable]
public readonly record struct TokenExchangeProfileTypeEnum : IStringEnum
{
    public static readonly TokenExchangeProfileTypeEnum CustomAuthentication = new(
        Values.CustomAuthentication
    );

    public TokenExchangeProfileTypeEnum(string value)
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
    public static TokenExchangeProfileTypeEnum FromCustom(string value)
    {
        return new TokenExchangeProfileTypeEnum(value);
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

    public static bool operator ==(TokenExchangeProfileTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(TokenExchangeProfileTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(TokenExchangeProfileTypeEnum value) => value.Value;

    public static explicit operator TokenExchangeProfileTypeEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string CustomAuthentication = "custom_authentication";
    }
}
