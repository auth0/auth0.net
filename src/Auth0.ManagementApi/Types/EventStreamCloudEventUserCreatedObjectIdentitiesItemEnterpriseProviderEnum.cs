using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventUserCreatedObjectIdentitiesItemEnterpriseProviderEnum.EventStreamCloudEventUserCreatedObjectIdentitiesItemEnterpriseProviderEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventUserCreatedObjectIdentitiesItemEnterpriseProviderEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemEnterpriseProviderEnum Ad =
        new(Values.Ad);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemEnterpriseProviderEnum Adfs =
        new(Values.Adfs);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemEnterpriseProviderEnum GoogleApps =
        new(Values.GoogleApps);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemEnterpriseProviderEnum Ip =
        new(Values.Ip);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemEnterpriseProviderEnum Office365 =
        new(Values.Office365);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemEnterpriseProviderEnum Oidc =
        new(Values.Oidc);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemEnterpriseProviderEnum Okta =
        new(Values.Okta);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemEnterpriseProviderEnum Pingfederate =
        new(Values.Pingfederate);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemEnterpriseProviderEnum Samlp =
        new(Values.Samlp);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemEnterpriseProviderEnum Sharepoint =
        new(Values.Sharepoint);

    public static readonly EventStreamCloudEventUserCreatedObjectIdentitiesItemEnterpriseProviderEnum Waad =
        new(Values.Waad);

    public EventStreamCloudEventUserCreatedObjectIdentitiesItemEnterpriseProviderEnum(string value)
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
    public static EventStreamCloudEventUserCreatedObjectIdentitiesItemEnterpriseProviderEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventUserCreatedObjectIdentitiesItemEnterpriseProviderEnum(
            value
        );
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
        EventStreamCloudEventUserCreatedObjectIdentitiesItemEnterpriseProviderEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventUserCreatedObjectIdentitiesItemEnterpriseProviderEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventUserCreatedObjectIdentitiesItemEnterpriseProviderEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventUserCreatedObjectIdentitiesItemEnterpriseProviderEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventUserCreatedObjectIdentitiesItemEnterpriseProviderEnumSerializer
        : JsonConverter<EventStreamCloudEventUserCreatedObjectIdentitiesItemEnterpriseProviderEnum>
    {
        public override EventStreamCloudEventUserCreatedObjectIdentitiesItemEnterpriseProviderEnum Read(
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
            return new EventStreamCloudEventUserCreatedObjectIdentitiesItemEnterpriseProviderEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserCreatedObjectIdentitiesItemEnterpriseProviderEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventUserCreatedObjectIdentitiesItemEnterpriseProviderEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventUserCreatedObjectIdentitiesItemEnterpriseProviderEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserCreatedObjectIdentitiesItemEnterpriseProviderEnum value,
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
        public const string Ad = "ad";

        public const string Adfs = "adfs";

        public const string GoogleApps = "google-apps";

        public const string Ip = "ip";

        public const string Office365 = "office365";

        public const string Oidc = "oidc";

        public const string Okta = "okta";

        public const string Pingfederate = "pingfederate";

        public const string Samlp = "samlp";

        public const string Sharepoint = "sharepoint";

        public const string Waad = "waad";
    }
}
