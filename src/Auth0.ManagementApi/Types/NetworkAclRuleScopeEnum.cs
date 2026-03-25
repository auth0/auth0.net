using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(NetworkAclRuleScopeEnum.NetworkAclRuleScopeEnumSerializer))]
[Serializable]
public readonly record struct NetworkAclRuleScopeEnum : IStringEnum
{
    public static readonly NetworkAclRuleScopeEnum Management = new(Values.Management);

    public static readonly NetworkAclRuleScopeEnum Authentication = new(Values.Authentication);

    public static readonly NetworkAclRuleScopeEnum Tenant = new(Values.Tenant);

    public static readonly NetworkAclRuleScopeEnum DynamicClientRegistration = new(
        Values.DynamicClientRegistration
    );

    public NetworkAclRuleScopeEnum(string value)
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
    public static NetworkAclRuleScopeEnum FromCustom(string value)
    {
        return new NetworkAclRuleScopeEnum(value);
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

    public static bool operator ==(NetworkAclRuleScopeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(NetworkAclRuleScopeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(NetworkAclRuleScopeEnum value) => value.Value;

    public static explicit operator NetworkAclRuleScopeEnum(string value) => new(value);

    internal class NetworkAclRuleScopeEnumSerializer : JsonConverter<NetworkAclRuleScopeEnum>
    {
        public override NetworkAclRuleScopeEnum Read(
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
            return new NetworkAclRuleScopeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            NetworkAclRuleScopeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override NetworkAclRuleScopeEnum ReadAsPropertyName(
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
            return new NetworkAclRuleScopeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            NetworkAclRuleScopeEnum value,
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
        public const string Management = "management";

        public const string Authentication = "authentication";

        public const string Tenant = "tenant";

        public const string DynamicClientRegistration = "dynamic_client_registration";
    }
}
