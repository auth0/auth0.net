using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FlowActionGoogleSheetsAddRowAction>))]
[Serializable]
public readonly record struct FlowActionGoogleSheetsAddRowAction : IStringEnum
{
    public static readonly FlowActionGoogleSheetsAddRowAction AddRow = new(Values.AddRow);

    public FlowActionGoogleSheetsAddRowAction(string value)
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
    public static FlowActionGoogleSheetsAddRowAction FromCustom(string value)
    {
        return new FlowActionGoogleSheetsAddRowAction(value);
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

    public static bool operator ==(FlowActionGoogleSheetsAddRowAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionGoogleSheetsAddRowAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionGoogleSheetsAddRowAction value) => value.Value;

    public static explicit operator FlowActionGoogleSheetsAddRowAction(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string AddRow = "ADD_ROW";
    }
}
