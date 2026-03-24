using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<CreateConnectionRequestContentTwitterStrategy>))]
[Serializable]
public readonly record struct CreateConnectionRequestContentTwitterStrategy : IStringEnum
{
    public static readonly CreateConnectionRequestContentTwitterStrategy Twitter = new(
        Values.Twitter
    );

    public CreateConnectionRequestContentTwitterStrategy(string value)
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
    public static CreateConnectionRequestContentTwitterStrategy FromCustom(string value)
    {
        return new CreateConnectionRequestContentTwitterStrategy(value);
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
        CreateConnectionRequestContentTwitterStrategy value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateConnectionRequestContentTwitterStrategy value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreateConnectionRequestContentTwitterStrategy value) =>
        value.Value;

    public static explicit operator CreateConnectionRequestContentTwitterStrategy(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Twitter = "twitter";
    }
}
