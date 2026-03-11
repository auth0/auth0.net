using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<CreateConnectionRequestContentFacebookStrategy>))]
[Serializable]
public readonly record struct CreateConnectionRequestContentFacebookStrategy : IStringEnum
{
    public static readonly CreateConnectionRequestContentFacebookStrategy Facebook = new(
        Values.Facebook
    );

    public CreateConnectionRequestContentFacebookStrategy(string value)
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
    public static CreateConnectionRequestContentFacebookStrategy FromCustom(string value)
    {
        return new CreateConnectionRequestContentFacebookStrategy(value);
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
        CreateConnectionRequestContentFacebookStrategy value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateConnectionRequestContentFacebookStrategy value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreateConnectionRequestContentFacebookStrategy value) =>
        value.Value;

    public static explicit operator CreateConnectionRequestContentFacebookStrategy(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Facebook = "facebook";
    }
}
