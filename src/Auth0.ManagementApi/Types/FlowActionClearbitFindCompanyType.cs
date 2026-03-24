using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowActionClearbitFindCompanyType.FlowActionClearbitFindCompanyTypeSerializer)
)]
[Serializable]
public readonly record struct FlowActionClearbitFindCompanyType : IStringEnum
{
    public static readonly FlowActionClearbitFindCompanyType Clearbit = new(Values.Clearbit);

    public FlowActionClearbitFindCompanyType(string value)
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
    public static FlowActionClearbitFindCompanyType FromCustom(string value)
    {
        return new FlowActionClearbitFindCompanyType(value);
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

    public static bool operator ==(FlowActionClearbitFindCompanyType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionClearbitFindCompanyType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionClearbitFindCompanyType value) => value.Value;

    public static explicit operator FlowActionClearbitFindCompanyType(string value) => new(value);

    internal class FlowActionClearbitFindCompanyTypeSerializer
        : JsonConverter<FlowActionClearbitFindCompanyType>
    {
        public override FlowActionClearbitFindCompanyType Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new FlowActionClearbitFindCompanyType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionClearbitFindCompanyType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Clearbit = "CLEARBIT";
    }
}
