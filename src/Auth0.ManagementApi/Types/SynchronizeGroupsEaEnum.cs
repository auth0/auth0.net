using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<SynchronizeGroupsEaEnum>))]
[Serializable]
public readonly record struct SynchronizeGroupsEaEnum : IStringEnum
{
    public static readonly SynchronizeGroupsEaEnum All = new(Values.All);

    public static readonly SynchronizeGroupsEaEnum Off = new(Values.Off);

    public SynchronizeGroupsEaEnum(string value)
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
    public static SynchronizeGroupsEaEnum FromCustom(string value)
    {
        return new SynchronizeGroupsEaEnum(value);
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

    public static bool operator ==(SynchronizeGroupsEaEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SynchronizeGroupsEaEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SynchronizeGroupsEaEnum value) => value.Value;

    public static explicit operator SynchronizeGroupsEaEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string All = "all";

        public const string Off = "off";
    }
}
