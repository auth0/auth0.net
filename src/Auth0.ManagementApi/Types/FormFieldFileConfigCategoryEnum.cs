using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FormFieldFileConfigCategoryEnum>))]
[Serializable]
public readonly record struct FormFieldFileConfigCategoryEnum : IStringEnum
{
    public static readonly FormFieldFileConfigCategoryEnum Audio = new(Values.Audio);

    public static readonly FormFieldFileConfigCategoryEnum Video = new(Values.Video);

    public static readonly FormFieldFileConfigCategoryEnum Image = new(Values.Image);

    public static readonly FormFieldFileConfigCategoryEnum Document = new(Values.Document);

    public static readonly FormFieldFileConfigCategoryEnum Archive = new(Values.Archive);

    public FormFieldFileConfigCategoryEnum(string value)
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
    public static FormFieldFileConfigCategoryEnum FromCustom(string value)
    {
        return new FormFieldFileConfigCategoryEnum(value);
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

    public static bool operator ==(FormFieldFileConfigCategoryEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FormFieldFileConfigCategoryEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FormFieldFileConfigCategoryEnum value) => value.Value;

    public static explicit operator FormFieldFileConfigCategoryEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Audio = "AUDIO";

        public const string Video = "VIDEO";

        public const string Image = "IMAGE";

        public const string Document = "DOCUMENT";

        public const string Archive = "ARCHIVE";
    }
}
