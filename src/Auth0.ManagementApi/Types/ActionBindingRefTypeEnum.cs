using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<ActionBindingRefTypeEnum>))]
[Serializable]
public readonly record struct ActionBindingRefTypeEnum : IStringEnum
{
    public static readonly ActionBindingRefTypeEnum BindingId = new(Values.BindingId);

    public static readonly ActionBindingRefTypeEnum ActionId = new(Values.ActionId);

    public static readonly ActionBindingRefTypeEnum ActionName = new(Values.ActionName);

    public ActionBindingRefTypeEnum(string value)
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
    public static ActionBindingRefTypeEnum FromCustom(string value)
    {
        return new ActionBindingRefTypeEnum(value);
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

    public static bool operator ==(ActionBindingRefTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ActionBindingRefTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ActionBindingRefTypeEnum value) => value.Value;

    public static explicit operator ActionBindingRefTypeEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string BindingId = "binding_id";

        public const string ActionId = "action_id";

        public const string ActionName = "action_name";
    }
}
