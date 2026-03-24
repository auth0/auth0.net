using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FlowActionPipedriveAddPersonAction>))]
[Serializable]
public readonly record struct FlowActionPipedriveAddPersonAction : IStringEnum
{
    public static readonly FlowActionPipedriveAddPersonAction AddPerson = new(Values.AddPerson);

    public FlowActionPipedriveAddPersonAction(string value)
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
    public static FlowActionPipedriveAddPersonAction FromCustom(string value)
    {
        return new FlowActionPipedriveAddPersonAction(value);
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

    public static bool operator ==(FlowActionPipedriveAddPersonAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionPipedriveAddPersonAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionPipedriveAddPersonAction value) => value.Value;

    public static explicit operator FlowActionPipedriveAddPersonAction(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string AddPerson = "ADD_PERSON";
    }
}
