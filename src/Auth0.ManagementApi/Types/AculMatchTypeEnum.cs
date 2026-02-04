using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<AculMatchTypeEnum>))]
[Serializable]
public readonly record struct AculMatchTypeEnum : IStringEnum
{
    public static readonly AculMatchTypeEnum IncludesAny = new(Values.IncludesAny);

    public static readonly AculMatchTypeEnum ExcludesAny = new(Values.ExcludesAny);

    public AculMatchTypeEnum(string value)
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
    public static AculMatchTypeEnum FromCustom(string value)
    {
        return new AculMatchTypeEnum(value);
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

    public static bool operator ==(AculMatchTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(AculMatchTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(AculMatchTypeEnum value) => value.Value;

    public static explicit operator AculMatchTypeEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string IncludesAny = "includes_any";

        public const string ExcludesAny = "excludes_any";
    }
}
