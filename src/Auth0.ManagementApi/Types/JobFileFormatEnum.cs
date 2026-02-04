using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<JobFileFormatEnum>))]
[Serializable]
public readonly record struct JobFileFormatEnum : IStringEnum
{
    public static readonly JobFileFormatEnum Json = new(Values.Json);

    public static readonly JobFileFormatEnum Csv = new(Values.Csv);

    public JobFileFormatEnum(string value)
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
    public static JobFileFormatEnum FromCustom(string value)
    {
        return new JobFileFormatEnum(value);
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

    public static bool operator ==(JobFileFormatEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(JobFileFormatEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(JobFileFormatEnum value) => value.Value;

    public static explicit operator JobFileFormatEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Json = "json";

        public const string Csv = "csv";
    }
}
