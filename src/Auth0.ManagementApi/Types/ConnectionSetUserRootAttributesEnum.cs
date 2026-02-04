using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<ConnectionSetUserRootAttributesEnum>))]
[Serializable]
public readonly record struct ConnectionSetUserRootAttributesEnum : IStringEnum
{
    public static readonly ConnectionSetUserRootAttributesEnum OnEachLogin = new(
        Values.OnEachLogin
    );

    public static readonly ConnectionSetUserRootAttributesEnum OnFirstLogin = new(
        Values.OnFirstLogin
    );

    public static readonly ConnectionSetUserRootAttributesEnum NeverOnLogin = new(
        Values.NeverOnLogin
    );

    public ConnectionSetUserRootAttributesEnum(string value)
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
    public static ConnectionSetUserRootAttributesEnum FromCustom(string value)
    {
        return new ConnectionSetUserRootAttributesEnum(value);
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

    public static bool operator ==(ConnectionSetUserRootAttributesEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ConnectionSetUserRootAttributesEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ConnectionSetUserRootAttributesEnum value) =>
        value.Value;

    public static explicit operator ConnectionSetUserRootAttributesEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string OnEachLogin = "on_each_login";

        public const string OnFirstLogin = "on_first_login";

        public const string NeverOnLogin = "never_on_login";
    }
}
