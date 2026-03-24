using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FormBlockTypeNextButtonConst>))]
[Serializable]
public readonly record struct FormBlockTypeNextButtonConst : IStringEnum
{
    public static readonly FormBlockTypeNextButtonConst NextButton = new(Values.NextButton);

    public FormBlockTypeNextButtonConst(string value)
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
    public static FormBlockTypeNextButtonConst FromCustom(string value)
    {
        return new FormBlockTypeNextButtonConst(value);
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

    public static bool operator ==(FormBlockTypeNextButtonConst value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FormBlockTypeNextButtonConst value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FormBlockTypeNextButtonConst value) => value.Value;

    public static explicit operator FormBlockTypeNextButtonConst(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string NextButton = "NEXT_BUTTON";
    }
}
