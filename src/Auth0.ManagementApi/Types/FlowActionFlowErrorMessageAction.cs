using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FlowActionFlowErrorMessageAction>))]
[Serializable]
public readonly record struct FlowActionFlowErrorMessageAction : IStringEnum
{
    public static readonly FlowActionFlowErrorMessageAction ErrorMessage = new(Values.ErrorMessage);

    public FlowActionFlowErrorMessageAction(string value)
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
    public static FlowActionFlowErrorMessageAction FromCustom(string value)
    {
        return new FlowActionFlowErrorMessageAction(value);
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

    public static bool operator ==(FlowActionFlowErrorMessageAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionFlowErrorMessageAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionFlowErrorMessageAction value) => value.Value;

    public static explicit operator FlowActionFlowErrorMessageAction(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string ErrorMessage = "ERROR_MESSAGE";
    }
}
