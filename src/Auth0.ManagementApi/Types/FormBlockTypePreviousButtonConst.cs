using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FormBlockTypePreviousButtonConst>))]
[Serializable]
public readonly record struct FormBlockTypePreviousButtonConst : IStringEnum
{
    public static readonly FormBlockTypePreviousButtonConst PreviousButton = new(
        Values.PreviousButton
    );

    public FormBlockTypePreviousButtonConst(string value)
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
    public static FormBlockTypePreviousButtonConst FromCustom(string value)
    {
        return new FormBlockTypePreviousButtonConst(value);
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

    public static bool operator ==(FormBlockTypePreviousButtonConst value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FormBlockTypePreviousButtonConst value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FormBlockTypePreviousButtonConst value) => value.Value;

    public static explicit operator FormBlockTypePreviousButtonConst(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string PreviousButton = "PREVIOUS_BUTTON";
    }
}
