using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<ClientTokenExchangeTypeEnum>))]
[Serializable]
public readonly record struct ClientTokenExchangeTypeEnum : IStringEnum
{
    public static readonly ClientTokenExchangeTypeEnum CustomAuthentication = new(
        Values.CustomAuthentication
    );

    public static readonly ClientTokenExchangeTypeEnum OnBehalfOfTokenExchange = new(
        Values.OnBehalfOfTokenExchange
    );

    public ClientTokenExchangeTypeEnum(string value)
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
    public static ClientTokenExchangeTypeEnum FromCustom(string value)
    {
        return new ClientTokenExchangeTypeEnum(value);
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

    public static bool operator ==(ClientTokenExchangeTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ClientTokenExchangeTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ClientTokenExchangeTypeEnum value) => value.Value;

    public static explicit operator ClientTokenExchangeTypeEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string CustomAuthentication = "custom_authentication";

        public const string OnBehalfOfTokenExchange = "on_behalf_of_token_exchange";
    }
}
