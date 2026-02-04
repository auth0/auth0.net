using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<ActionExecutionStatusEnum>))]
[Serializable]
public readonly record struct ActionExecutionStatusEnum : IStringEnum
{
    public static readonly ActionExecutionStatusEnum Unspecified = new(Values.Unspecified);

    public static readonly ActionExecutionStatusEnum Pending = new(Values.Pending);

    public static readonly ActionExecutionStatusEnum Final = new(Values.Final);

    public static readonly ActionExecutionStatusEnum Partial = new(Values.Partial);

    public static readonly ActionExecutionStatusEnum Canceled = new(Values.Canceled);

    public static readonly ActionExecutionStatusEnum Suspended = new(Values.Suspended);

    public ActionExecutionStatusEnum(string value)
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
    public static ActionExecutionStatusEnum FromCustom(string value)
    {
        return new ActionExecutionStatusEnum(value);
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

    public static bool operator ==(ActionExecutionStatusEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ActionExecutionStatusEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ActionExecutionStatusEnum value) => value.Value;

    public static explicit operator ActionExecutionStatusEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Unspecified = "unspecified";

        public const string Pending = "pending";

        public const string Final = "final";

        public const string Partial = "partial";

        public const string Canceled = "canceled";

        public const string Suspended = "suspended";
    }
}
