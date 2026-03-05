using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<FlowActionJwtVerifyJwtAction>))]
[Serializable]
public readonly record struct FlowActionJwtVerifyJwtAction : IStringEnum
{
    public static readonly FlowActionJwtVerifyJwtAction VerifyJwt = new(Values.VerifyJwt);

    public FlowActionJwtVerifyJwtAction(string value)
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
    public static FlowActionJwtVerifyJwtAction FromCustom(string value)
    {
        return new FlowActionJwtVerifyJwtAction(value);
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

    public static bool operator ==(FlowActionJwtVerifyJwtAction value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(FlowActionJwtVerifyJwtAction value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(FlowActionJwtVerifyJwtAction value) => value.Value;

    public static explicit operator FlowActionJwtVerifyJwtAction(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string VerifyJwt = "VERIFY_JWT";
    }
}
