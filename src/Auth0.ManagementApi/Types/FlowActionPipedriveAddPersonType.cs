using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FlowActionPipedriveAddPersonType>))]
[Serializable]
public readonly record struct FlowActionPipedriveAddPersonType : IStringEnum
{
    public static readonly FlowActionPipedriveAddPersonType Pipedrive = new(Values.Pipedrive);

    public FlowActionPipedriveAddPersonType(string value)
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
    public static FlowActionPipedriveAddPersonType FromCustom(string value)
    {
        return new FlowActionPipedriveAddPersonType(value);
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

    public static bool operator ==(FlowActionPipedriveAddPersonType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionPipedriveAddPersonType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionPipedriveAddPersonType value) => value.Value;

    public static explicit operator FlowActionPipedriveAddPersonType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Pipedrive = "PIPEDRIVE";
    }
}
