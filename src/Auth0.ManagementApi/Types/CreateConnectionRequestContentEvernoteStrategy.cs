using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<CreateConnectionRequestContentEvernoteStrategy>))]
[Serializable]
public readonly record struct CreateConnectionRequestContentEvernoteStrategy : IStringEnum
{
    public static readonly CreateConnectionRequestContentEvernoteStrategy Evernote = new(
        Values.Evernote
    );

    public CreateConnectionRequestContentEvernoteStrategy(string value)
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
    public static CreateConnectionRequestContentEvernoteStrategy FromCustom(string value)
    {
        return new CreateConnectionRequestContentEvernoteStrategy(value);
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
        CreateConnectionRequestContentEvernoteStrategy value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateConnectionRequestContentEvernoteStrategy value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreateConnectionRequestContentEvernoteStrategy value) =>
        value.Value;

    public static explicit operator CreateConnectionRequestContentEvernoteStrategy(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Evernote = "evernote";
    }
}
