using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FormBlockTypeRichTextConst>))]
[Serializable]
public readonly record struct FormBlockTypeRichTextConst : IStringEnum
{
    public static readonly FormBlockTypeRichTextConst RichText = new(Values.RichText);

    public FormBlockTypeRichTextConst(string value)
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
    public static FormBlockTypeRichTextConst FromCustom(string value)
    {
        return new FormBlockTypeRichTextConst(value);
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

    public static bool operator ==(FormBlockTypeRichTextConst value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FormBlockTypeRichTextConst value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FormBlockTypeRichTextConst value) => value.Value;

    public static explicit operator FormBlockTypeRichTextConst(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string RichText = "RICH_TEXT";
    }
}
