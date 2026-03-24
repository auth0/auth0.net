using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<CreateConnectionRequestContentDaccountStrategy>))]
[Serializable]
public readonly record struct CreateConnectionRequestContentDaccountStrategy : IStringEnum
{
    public static readonly CreateConnectionRequestContentDaccountStrategy Daccount = new(
        Values.Daccount
    );

    public CreateConnectionRequestContentDaccountStrategy(string value)
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
    public static CreateConnectionRequestContentDaccountStrategy FromCustom(string value)
    {
        return new CreateConnectionRequestContentDaccountStrategy(value);
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
        CreateConnectionRequestContentDaccountStrategy value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        CreateConnectionRequestContentDaccountStrategy value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(CreateConnectionRequestContentDaccountStrategy value) =>
        value.Value;

    public static explicit operator CreateConnectionRequestContentDaccountStrategy(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Daccount = "daccount";
    }
}
