using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FlowActionJsonSerializeJsonType>))]
[Serializable]
public readonly record struct FlowActionJsonSerializeJsonType : IStringEnum
{
    public static readonly FlowActionJsonSerializeJsonType Json = new(Values.Json);

    public FlowActionJsonSerializeJsonType(string value)
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
    public static FlowActionJsonSerializeJsonType FromCustom(string value)
    {
        return new FlowActionJsonSerializeJsonType(value);
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

    public static bool operator ==(FlowActionJsonSerializeJsonType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionJsonSerializeJsonType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionJsonSerializeJsonType value) => value.Value;

    public static explicit operator FlowActionJsonSerializeJsonType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Json = "JSON";
    }
}
