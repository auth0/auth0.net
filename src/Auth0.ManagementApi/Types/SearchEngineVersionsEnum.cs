using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<SearchEngineVersionsEnum>))]
[Serializable]
public readonly record struct SearchEngineVersionsEnum : IStringEnum
{
    public static readonly SearchEngineVersionsEnum V1 = new(Values.V1);

    public static readonly SearchEngineVersionsEnum V2 = new(Values.V2);

    public static readonly SearchEngineVersionsEnum V3 = new(Values.V3);

    public SearchEngineVersionsEnum(string value)
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
    public static SearchEngineVersionsEnum FromCustom(string value)
    {
        return new SearchEngineVersionsEnum(value);
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

    public static bool operator ==(SearchEngineVersionsEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SearchEngineVersionsEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SearchEngineVersionsEnum value) => value.Value;

    public static explicit operator SearchEngineVersionsEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string V1 = "v1";

        public const string V2 = "v2";

        public const string V3 = "v3";
    }
}
