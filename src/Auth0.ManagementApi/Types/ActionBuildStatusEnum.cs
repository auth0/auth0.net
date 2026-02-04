using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<ActionBuildStatusEnum>))]
[Serializable]
public readonly record struct ActionBuildStatusEnum : IStringEnum
{
    public static readonly ActionBuildStatusEnum Pending = new(Values.Pending);

    public static readonly ActionBuildStatusEnum Building = new(Values.Building);

    public static readonly ActionBuildStatusEnum Packaged = new(Values.Packaged);

    public static readonly ActionBuildStatusEnum Built = new(Values.Built);

    public static readonly ActionBuildStatusEnum Retrying = new(Values.Retrying);

    public static readonly ActionBuildStatusEnum Failed = new(Values.Failed);

    public ActionBuildStatusEnum(string value)
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
    public static ActionBuildStatusEnum FromCustom(string value)
    {
        return new ActionBuildStatusEnum(value);
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

    public static bool operator ==(ActionBuildStatusEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ActionBuildStatusEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ActionBuildStatusEnum value) => value.Value;

    public static explicit operator ActionBuildStatusEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Pending = "pending";

        public const string Building = "building";

        public const string Packaged = "packaged";

        public const string Built = "built";

        public const string Retrying = "retrying";

        public const string Failed = "failed";
    }
}
