using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FlowActionFlowMapValueType>))]
[Serializable]
public readonly record struct FlowActionFlowMapValueType : IStringEnum
{
    public static readonly FlowActionFlowMapValueType Flow = new(Values.Flow);

    public FlowActionFlowMapValueType(string value)
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
    public static FlowActionFlowMapValueType FromCustom(string value)
    {
        return new FlowActionFlowMapValueType(value);
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

    public static bool operator ==(FlowActionFlowMapValueType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionFlowMapValueType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionFlowMapValueType value) => value.Value;

    public static explicit operator FlowActionFlowMapValueType(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Flow = "FLOW";
    }
}
