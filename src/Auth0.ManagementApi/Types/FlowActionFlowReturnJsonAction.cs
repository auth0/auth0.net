using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FlowActionFlowReturnJsonAction>))]
[Serializable]
public readonly record struct FlowActionFlowReturnJsonAction : IStringEnum
{
    public static readonly FlowActionFlowReturnJsonAction ReturnJson = new(Values.ReturnJson);

    public FlowActionFlowReturnJsonAction(string value)
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
    public static FlowActionFlowReturnJsonAction FromCustom(string value)
    {
        return new FlowActionFlowReturnJsonAction(value);
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

    public static bool operator ==(FlowActionFlowReturnJsonAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionFlowReturnJsonAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionFlowReturnJsonAction value) => value.Value;

    public static explicit operator FlowActionFlowReturnJsonAction(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string ReturnJson = "RETURN_JSON";
    }
}
