using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<UserAttributeProfileUserIdOidcMappingEnum>))]
[Serializable]
public readonly record struct UserAttributeProfileUserIdOidcMappingEnum : IStringEnum
{
    public static readonly UserAttributeProfileUserIdOidcMappingEnum Sub = new(Values.Sub);

    public UserAttributeProfileUserIdOidcMappingEnum(string value)
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
    public static UserAttributeProfileUserIdOidcMappingEnum FromCustom(string value)
    {
        return new UserAttributeProfileUserIdOidcMappingEnum(value);
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

    public static bool operator ==(
        UserAttributeProfileUserIdOidcMappingEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        UserAttributeProfileUserIdOidcMappingEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(UserAttributeProfileUserIdOidcMappingEnum value) =>
        value.Value;

    public static explicit operator UserAttributeProfileUserIdOidcMappingEnum(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string Sub = "sub";
    }
}
