using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<SelfServiceProfileSsoTicketProvisioningScopeEnum>))]
[Serializable]
public readonly record struct SelfServiceProfileSsoTicketProvisioningScopeEnum : IStringEnum
{
    public static readonly SelfServiceProfileSsoTicketProvisioningScopeEnum GetUsers = new(
        Values.GetUsers
    );

    public static readonly SelfServiceProfileSsoTicketProvisioningScopeEnum PostUsers = new(
        Values.PostUsers
    );

    public static readonly SelfServiceProfileSsoTicketProvisioningScopeEnum PutUsers = new(
        Values.PutUsers
    );

    public static readonly SelfServiceProfileSsoTicketProvisioningScopeEnum PatchUsers = new(
        Values.PatchUsers
    );

    public static readonly SelfServiceProfileSsoTicketProvisioningScopeEnum DeleteUsers = new(
        Values.DeleteUsers
    );

    public SelfServiceProfileSsoTicketProvisioningScopeEnum(string value)
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
    public static SelfServiceProfileSsoTicketProvisioningScopeEnum FromCustom(string value)
    {
        return new SelfServiceProfileSsoTicketProvisioningScopeEnum(value);
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
        SelfServiceProfileSsoTicketProvisioningScopeEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        SelfServiceProfileSsoTicketProvisioningScopeEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        SelfServiceProfileSsoTicketProvisioningScopeEnum value
    ) => value.Value;

    public static explicit operator SelfServiceProfileSsoTicketProvisioningScopeEnum(
        string value
    ) => new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string GetUsers = "get:users";

        public const string PostUsers = "post:users";

        public const string PutUsers = "put:users";

        public const string PatchUsers = "patch:users";

        public const string DeleteUsers = "delete:users";
    }
}
