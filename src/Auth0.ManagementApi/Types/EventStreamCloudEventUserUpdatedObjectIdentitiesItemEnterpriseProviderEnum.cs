using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterpriseProviderEnum.EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterpriseProviderEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterpriseProviderEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterpriseProviderEnum Ad =
        new(Values.Ad);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterpriseProviderEnum Adfs =
        new(Values.Adfs);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterpriseProviderEnum GoogleApps =
        new(Values.GoogleApps);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterpriseProviderEnum Ip =
        new(Values.Ip);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterpriseProviderEnum Office365 =
        new(Values.Office365);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterpriseProviderEnum Oidc =
        new(Values.Oidc);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterpriseProviderEnum Okta =
        new(Values.Okta);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterpriseProviderEnum Pingfederate =
        new(Values.Pingfederate);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterpriseProviderEnum Samlp =
        new(Values.Samlp);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterpriseProviderEnum Sharepoint =
        new(Values.Sharepoint);

    public static readonly EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterpriseProviderEnum Waad =
        new(Values.Waad);

    public EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterpriseProviderEnum(string value)
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
    public static EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterpriseProviderEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterpriseProviderEnum(
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
        EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterpriseProviderEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterpriseProviderEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterpriseProviderEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterpriseProviderEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterpriseProviderEnumSerializer
        : JsonConverter<EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterpriseProviderEnum>
    {
        public override EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterpriseProviderEnum Read(
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
            return new EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterpriseProviderEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterpriseProviderEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterpriseProviderEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterpriseProviderEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserUpdatedObjectIdentitiesItemEnterpriseProviderEnum value,
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
