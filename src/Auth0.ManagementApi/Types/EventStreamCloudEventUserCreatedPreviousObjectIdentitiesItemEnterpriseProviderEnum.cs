using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterpriseProviderEnum.EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterpriseProviderEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterpriseProviderEnum
    : IStringEnum
{
    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterpriseProviderEnum Ad =
        new(Values.Ad);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterpriseProviderEnum Adfs =
        new(Values.Adfs);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterpriseProviderEnum GoogleApps =
        new(Values.GoogleApps);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterpriseProviderEnum Ip =
        new(Values.Ip);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterpriseProviderEnum Office365 =
        new(Values.Office365);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterpriseProviderEnum Oidc =
        new(Values.Oidc);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterpriseProviderEnum Okta =
        new(Values.Okta);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterpriseProviderEnum Pingfederate =
        new(Values.Pingfederate);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterpriseProviderEnum Samlp =
        new(Values.Samlp);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterpriseProviderEnum Sharepoint =
        new(Values.Sharepoint);

    public static readonly EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterpriseProviderEnum Waad =
        new(Values.Waad);

    public EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterpriseProviderEnum(
        string value
    )
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
    public static EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterpriseProviderEnum FromCustom(
        string value
    )
    {
        return new EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterpriseProviderEnum(
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
        EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterpriseProviderEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterpriseProviderEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(
        EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterpriseProviderEnum value
    ) => value.Value;

    public static explicit operator EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterpriseProviderEnum(
        string value
    ) => new(value);

    internal class EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterpriseProviderEnumSerializer
        : JsonConverter<EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterpriseProviderEnum>
    {
        public override EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterpriseProviderEnum Read(
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
            return new EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterpriseProviderEnum(
                stringValue
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterpriseProviderEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterpriseProviderEnum ReadAsPropertyName(
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
            return new EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterpriseProviderEnum(
                stringValue
            );
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EventStreamCloudEventUserCreatedPreviousObjectIdentitiesItemEnterpriseProviderEnum value,
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
