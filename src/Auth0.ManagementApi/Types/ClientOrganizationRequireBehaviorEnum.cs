using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(StringEnumSerializer<ClientOrganizationRequireBehaviorEnum>))]
[Serializable]
public readonly record struct ClientOrganizationRequireBehaviorEnum : IStringEnum
{
    public static readonly ClientOrganizationRequireBehaviorEnum NoPrompt = new(Values.NoPrompt);

    public static readonly ClientOrganizationRequireBehaviorEnum PreLoginPrompt = new(
        Values.PreLoginPrompt
    );

    public static readonly ClientOrganizationRequireBehaviorEnum PostLoginPrompt = new(
        Values.PostLoginPrompt
    );

    public ClientOrganizationRequireBehaviorEnum(string value)
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
    public static ClientOrganizationRequireBehaviorEnum FromCustom(string value)
    {
        return new ClientOrganizationRequireBehaviorEnum(value);
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

    public static bool operator ==(ClientOrganizationRequireBehaviorEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ClientOrganizationRequireBehaviorEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ClientOrganizationRequireBehaviorEnum value) =>
        value.Value;

    public static explicit operator ClientOrganizationRequireBehaviorEnum(string value) =>
        new(value);

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string NoPrompt = "no_prompt";

        public const string PreLoginPrompt = "pre_login_prompt";

        public const string PostLoginPrompt = "post_login_prompt";
    }
}
