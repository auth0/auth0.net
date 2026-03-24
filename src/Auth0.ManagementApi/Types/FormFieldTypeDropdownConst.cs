using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FormFieldTypeDropdownConst>))]
[Serializable]
public readonly record struct FormFieldTypeDropdownConst : IStringEnum
{
    public static readonly FormFieldTypeDropdownConst Dropdown = new(Values.Dropdown);

    public FormFieldTypeDropdownConst(string value)
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
    public static FormFieldTypeDropdownConst FromCustom(string value)
    {
        return new FormFieldTypeDropdownConst(value);
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

    public static bool operator ==(FormFieldTypeDropdownConst value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FormFieldTypeDropdownConst value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FormFieldTypeDropdownConst value) => value.Value;

    public static explicit operator FormFieldTypeDropdownConst(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Dropdown = "DROPDOWN";
    }
}
