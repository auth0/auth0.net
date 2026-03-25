using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ResourceServerSubjectTypeAuthorizationUserPolicyEnum.ResourceServerSubjectTypeAuthorizationUserPolicyEnumSerializer)
)]
[Serializable]
public readonly record struct ResourceServerSubjectTypeAuthorizationUserPolicyEnum : IStringEnum
{
    public static readonly ResourceServerSubjectTypeAuthorizationUserPolicyEnum AllowAll = new(
        Values.AllowAll
    );

    public static readonly ResourceServerSubjectTypeAuthorizationUserPolicyEnum DenyAll = new(
        Values.DenyAll
    );

    public static readonly ResourceServerSubjectTypeAuthorizationUserPolicyEnum RequireClientGrant =
        new(Values.RequireClientGrant);

    public ResourceServerSubjectTypeAuthorizationUserPolicyEnum(string value)
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
    public static ResourceServerSubjectTypeAuthorizationUserPolicyEnum FromCustom(string value)
    {
        return new ResourceServerSubjectTypeAuthorizationUserPolicyEnum(value);
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
        ResourceServerSubjectTypeAuthorizationUserPolicyEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ResourceServerSubjectTypeAuthorizationUserPolicyEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        ResourceServerSubjectTypeAuthorizationUserPolicyEnum value
    ) => value.Value;

    public static explicit operator ResourceServerSubjectTypeAuthorizationUserPolicyEnum(
        string value
    ) => new(value);

    internal class ResourceServerSubjectTypeAuthorizationUserPolicyEnumSerializer
        : JsonConverter<ResourceServerSubjectTypeAuthorizationUserPolicyEnum>
    {
        public override ResourceServerSubjectTypeAuthorizationUserPolicyEnum Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new ResourceServerSubjectTypeAuthorizationUserPolicyEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ResourceServerSubjectTypeAuthorizationUserPolicyEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ResourceServerSubjectTypeAuthorizationUserPolicyEnum ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new ResourceServerSubjectTypeAuthorizationUserPolicyEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ResourceServerSubjectTypeAuthorizationUserPolicyEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string AllowAll = "allow_all";

        public const string DenyAll = "deny_all";

        public const string RequireClientGrant = "require_client_grant";
    }
}
