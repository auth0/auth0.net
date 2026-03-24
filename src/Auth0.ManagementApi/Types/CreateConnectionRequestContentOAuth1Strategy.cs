using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<CreateConnectionRequestContentOAuth1Strategy>))]
[Serializable]
public readonly record struct CreateConnectionRequestContentOAuth1Strategy : IStringEnum
{
    public static readonly CreateConnectionRequestContentOAuth1Strategy Oauth1 = new(Values.Oauth1);

    public CreateConnectionRequestContentOAuth1Strategy(string value)
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
    public static CreateConnectionRequestContentOAuth1Strategy FromCustom(string value)
    {
        return new CreateConnectionRequestContentOAuth1Strategy(value);
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
        CreateConnectionRequestContentOAuth1Strategy value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateConnectionRequestContentOAuth1Strategy value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreateConnectionRequestContentOAuth1Strategy value) =>
        value.Value;

    public static explicit operator CreateConnectionRequestContentOAuth1Strategy(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Oauth1 = "oauth1";
    }
}
