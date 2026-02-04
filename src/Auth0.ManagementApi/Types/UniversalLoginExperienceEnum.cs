using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<UniversalLoginExperienceEnum>))]
[Serializable]
public readonly record struct UniversalLoginExperienceEnum : IStringEnum
{
    public static readonly UniversalLoginExperienceEnum New = new(Values.New);

    public static readonly UniversalLoginExperienceEnum Classic = new(Values.Classic);

    public UniversalLoginExperienceEnum(string value)
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
    public static UniversalLoginExperienceEnum FromCustom(string value)
    {
        return new UniversalLoginExperienceEnum(value);
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

    public static bool operator ==(UniversalLoginExperienceEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(UniversalLoginExperienceEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(UniversalLoginExperienceEnum value) => value.Value;

    public static explicit operator UniversalLoginExperienceEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string New = "new";

        public const string Classic = "classic";
    }
}
