using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<LogStreamPiiLogFieldsEnum>))]
[Serializable]
public readonly record struct LogStreamPiiLogFieldsEnum : IStringEnum
{
    public static readonly LogStreamPiiLogFieldsEnum FirstName = new(Values.FirstName);

    public static readonly LogStreamPiiLogFieldsEnum LastName = new(Values.LastName);

    public static readonly LogStreamPiiLogFieldsEnum Username = new(Values.Username);

    public static readonly LogStreamPiiLogFieldsEnum Email = new(Values.Email);

    public static readonly LogStreamPiiLogFieldsEnum Phone = new(Values.Phone);

    public static readonly LogStreamPiiLogFieldsEnum Address = new(Values.Address);

    public LogStreamPiiLogFieldsEnum(string value)
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
    public static LogStreamPiiLogFieldsEnum FromCustom(string value)
    {
        return new LogStreamPiiLogFieldsEnum(value);
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

    public static bool operator ==(LogStreamPiiLogFieldsEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LogStreamPiiLogFieldsEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LogStreamPiiLogFieldsEnum value) => value.Value;

    public static explicit operator LogStreamPiiLogFieldsEnum(string value) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string FirstName = "first_name";

        public const string LastName = "last_name";

        public const string Username = "username";

        public const string Email = "email";

        public const string Phone = "phone";

        public const string Address = "address";
    }
}
