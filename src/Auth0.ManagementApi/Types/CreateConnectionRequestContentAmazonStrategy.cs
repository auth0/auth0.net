using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<CreateConnectionRequestContentAmazonStrategy>))]
[Serializable]
public readonly record struct CreateConnectionRequestContentAmazonStrategy : IStringEnum
{
    public static readonly CreateConnectionRequestContentAmazonStrategy Amazon = new(Values.Amazon);

    public CreateConnectionRequestContentAmazonStrategy(string value)
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
    public static CreateConnectionRequestContentAmazonStrategy FromCustom(string value)
    {
        return new CreateConnectionRequestContentAmazonStrategy(value);
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
        CreateConnectionRequestContentAmazonStrategy value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateConnectionRequestContentAmazonStrategy value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreateConnectionRequestContentAmazonStrategy value) =>
        value.Value;

    public static explicit operator CreateConnectionRequestContentAmazonStrategy(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Amazon = "amazon";
    }
}
