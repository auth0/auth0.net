using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<CreateConnectionRequestContentEvernoteSandboxStrategy>))]
[Serializable]
public readonly record struct CreateConnectionRequestContentEvernoteSandboxStrategy : IStringEnum
{
    public static readonly CreateConnectionRequestContentEvernoteSandboxStrategy EvernoteSandbox =
        new(Values.EvernoteSandbox);

    public CreateConnectionRequestContentEvernoteSandboxStrategy(string value)
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
    public static CreateConnectionRequestContentEvernoteSandboxStrategy FromCustom(string value)
    {
        return new CreateConnectionRequestContentEvernoteSandboxStrategy(value);
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
        CreateConnectionRequestContentEvernoteSandboxStrategy value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateConnectionRequestContentEvernoteSandboxStrategy value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        CreateConnectionRequestContentEvernoteSandboxStrategy value
    ) => value.Value;

    public static explicit operator CreateConnectionRequestContentEvernoteSandboxStrategy(
        string value
    ) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string EvernoteSandbox = "evernote-sandbox";
    }
}
