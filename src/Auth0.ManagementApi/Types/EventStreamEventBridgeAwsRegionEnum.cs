using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(EventStreamEventBridgeAwsRegionEnum.EventStreamEventBridgeAwsRegionEnumSerializer)
)]
[Serializable]
public readonly record struct EventStreamEventBridgeAwsRegionEnum : IStringEnum
{
    public static readonly EventStreamEventBridgeAwsRegionEnum AfSouth1 = new(Values.AfSouth1);

    public static readonly EventStreamEventBridgeAwsRegionEnum ApEast1 = new(Values.ApEast1);

    public static readonly EventStreamEventBridgeAwsRegionEnum ApEast2 = new(Values.ApEast2);

    public static readonly EventStreamEventBridgeAwsRegionEnum ApNortheast1 = new(
        Values.ApNortheast1
    );

    public static readonly EventStreamEventBridgeAwsRegionEnum ApNortheast2 = new(
        Values.ApNortheast2
    );

    public static readonly EventStreamEventBridgeAwsRegionEnum ApNortheast3 = new(
        Values.ApNortheast3
    );

    public static readonly EventStreamEventBridgeAwsRegionEnum ApSouth1 = new(Values.ApSouth1);

    public static readonly EventStreamEventBridgeAwsRegionEnum ApSouth2 = new(Values.ApSouth2);

    public static readonly EventStreamEventBridgeAwsRegionEnum ApSoutheast1 = new(
        Values.ApSoutheast1
    );

    public static readonly EventStreamEventBridgeAwsRegionEnum ApSoutheast2 = new(
        Values.ApSoutheast2
    );

    public static readonly EventStreamEventBridgeAwsRegionEnum ApSoutheast3 = new(
        Values.ApSoutheast3
    );

    public static readonly EventStreamEventBridgeAwsRegionEnum ApSoutheast4 = new(
        Values.ApSoutheast4
    );

    public static readonly EventStreamEventBridgeAwsRegionEnum ApSoutheast5 = new(
        Values.ApSoutheast5
    );

    public static readonly EventStreamEventBridgeAwsRegionEnum ApSoutheast6 = new(
        Values.ApSoutheast6
    );

    public static readonly EventStreamEventBridgeAwsRegionEnum ApSoutheast7 = new(
        Values.ApSoutheast7
    );

    public static readonly EventStreamEventBridgeAwsRegionEnum CaCentral1 = new(Values.CaCentral1);

    public static readonly EventStreamEventBridgeAwsRegionEnum CaWest1 = new(Values.CaWest1);

    public static readonly EventStreamEventBridgeAwsRegionEnum EuCentral1 = new(Values.EuCentral1);

    public static readonly EventStreamEventBridgeAwsRegionEnum EuCentral2 = new(Values.EuCentral2);

    public static readonly EventStreamEventBridgeAwsRegionEnum EuNorth1 = new(Values.EuNorth1);

    public static readonly EventStreamEventBridgeAwsRegionEnum EuSouth1 = new(Values.EuSouth1);

    public static readonly EventStreamEventBridgeAwsRegionEnum EuSouth2 = new(Values.EuSouth2);

    public static readonly EventStreamEventBridgeAwsRegionEnum EuWest1 = new(Values.EuWest1);

    public static readonly EventStreamEventBridgeAwsRegionEnum EuWest2 = new(Values.EuWest2);

    public static readonly EventStreamEventBridgeAwsRegionEnum EuWest3 = new(Values.EuWest3);

    public static readonly EventStreamEventBridgeAwsRegionEnum IlCentral1 = new(Values.IlCentral1);

    public static readonly EventStreamEventBridgeAwsRegionEnum MeCentral1 = new(Values.MeCentral1);

    public static readonly EventStreamEventBridgeAwsRegionEnum MeSouth1 = new(Values.MeSouth1);

    public static readonly EventStreamEventBridgeAwsRegionEnum MxCentral1 = new(Values.MxCentral1);

    public static readonly EventStreamEventBridgeAwsRegionEnum SaEast1 = new(Values.SaEast1);

    public static readonly EventStreamEventBridgeAwsRegionEnum UsGovEast1 = new(Values.UsGovEast1);

    public static readonly EventStreamEventBridgeAwsRegionEnum UsGovWest1 = new(Values.UsGovWest1);

    public static readonly EventStreamEventBridgeAwsRegionEnum UsEast1 = new(Values.UsEast1);

    public static readonly EventStreamEventBridgeAwsRegionEnum UsEast2 = new(Values.UsEast2);

    public static readonly EventStreamEventBridgeAwsRegionEnum UsWest1 = new(Values.UsWest1);

    public static readonly EventStreamEventBridgeAwsRegionEnum UsWest2 = new(Values.UsWest2);

    public EventStreamEventBridgeAwsRegionEnum(string value)
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
    public static EventStreamEventBridgeAwsRegionEnum FromCustom(string value)
    {
        return new EventStreamEventBridgeAwsRegionEnum(value);
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

    public static bool operator ==(EventStreamEventBridgeAwsRegionEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(EventStreamEventBridgeAwsRegionEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(EventStreamEventBridgeAwsRegionEnum value) =>
        value.Value;

    public static explicit operator EventStreamEventBridgeAwsRegionEnum(string value) => new(value);

    internal class EventStreamEventBridgeAwsRegionEnumSerializer
        : JsonConverter<EventStreamEventBridgeAwsRegionEnum>
    {
        public override EventStreamEventBridgeAwsRegionEnum Read(
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
            return new EventStreamEventBridgeAwsRegionEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            EventStreamEventBridgeAwsRegionEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string AfSouth1 = "af-south-1";

        public const string ApEast1 = "ap-east-1";

        public const string ApEast2 = "ap-east-2";

        public const string ApNortheast1 = "ap-northeast-1";

        public const string ApNortheast2 = "ap-northeast-2";

        public const string ApNortheast3 = "ap-northeast-3";

        public const string ApSouth1 = "ap-south-1";

        public const string ApSouth2 = "ap-south-2";

        public const string ApSoutheast1 = "ap-southeast-1";

        public const string ApSoutheast2 = "ap-southeast-2";

        public const string ApSoutheast3 = "ap-southeast-3";

        public const string ApSoutheast4 = "ap-southeast-4";

        public const string ApSoutheast5 = "ap-southeast-5";

        public const string ApSoutheast6 = "ap-southeast-6";

        public const string ApSoutheast7 = "ap-southeast-7";

        public const string CaCentral1 = "ca-central-1";

        public const string CaWest1 = "ca-west-1";

        public const string EuCentral1 = "eu-central-1";

        public const string EuCentral2 = "eu-central-2";

        public const string EuNorth1 = "eu-north-1";

        public const string EuSouth1 = "eu-south-1";

        public const string EuSouth2 = "eu-south-2";

        public const string EuWest1 = "eu-west-1";

        public const string EuWest2 = "eu-west-2";

        public const string EuWest3 = "eu-west-3";

        public const string IlCentral1 = "il-central-1";

        public const string MeCentral1 = "me-central-1";

        public const string MeSouth1 = "me-south-1";

        public const string MxCentral1 = "mx-central-1";

        public const string SaEast1 = "sa-east-1";

        public const string UsGovEast1 = "us-gov-east-1";

        public const string UsGovWest1 = "us-gov-west-1";

        public const string UsEast1 = "us-east-1";

        public const string UsEast2 = "us-east-2";

        public const string UsWest1 = "us-west-1";

        public const string UsWest2 = "us-west-2";
    }
}
