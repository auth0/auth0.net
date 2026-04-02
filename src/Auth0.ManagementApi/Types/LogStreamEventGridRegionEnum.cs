using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(LogStreamEventGridRegionEnum.LogStreamEventGridRegionEnumSerializer))]
[Serializable]
public readonly record struct LogStreamEventGridRegionEnum : IStringEnum
{
    public static readonly LogStreamEventGridRegionEnum Australiacentral = new(
        Values.Australiacentral
    );

    public static readonly LogStreamEventGridRegionEnum Australiaeast = new(Values.Australiaeast);

    public static readonly LogStreamEventGridRegionEnum Australiasoutheast = new(
        Values.Australiasoutheast
    );

    public static readonly LogStreamEventGridRegionEnum Brazilsouth = new(Values.Brazilsouth);

    public static readonly LogStreamEventGridRegionEnum Canadacentral = new(Values.Canadacentral);

    public static readonly LogStreamEventGridRegionEnum Canadaeast = new(Values.Canadaeast);

    public static readonly LogStreamEventGridRegionEnum Centralindia = new(Values.Centralindia);

    public static readonly LogStreamEventGridRegionEnum Centralus = new(Values.Centralus);

    public static readonly LogStreamEventGridRegionEnum Eastasia = new(Values.Eastasia);

    public static readonly LogStreamEventGridRegionEnum Eastus = new(Values.Eastus);

    public static readonly LogStreamEventGridRegionEnum Eastus2 = new(Values.Eastus2);

    public static readonly LogStreamEventGridRegionEnum Francecentral = new(Values.Francecentral);

    public static readonly LogStreamEventGridRegionEnum Germanywestcentral = new(
        Values.Germanywestcentral
    );

    public static readonly LogStreamEventGridRegionEnum Japaneast = new(Values.Japaneast);

    public static readonly LogStreamEventGridRegionEnum Japanwest = new(Values.Japanwest);

    public static readonly LogStreamEventGridRegionEnum Koreacentral = new(Values.Koreacentral);

    public static readonly LogStreamEventGridRegionEnum Koreasouth = new(Values.Koreasouth);

    public static readonly LogStreamEventGridRegionEnum Northcentralus = new(Values.Northcentralus);

    public static readonly LogStreamEventGridRegionEnum Northeurope = new(Values.Northeurope);

    public static readonly LogStreamEventGridRegionEnum Norwayeast = new(Values.Norwayeast);

    public static readonly LogStreamEventGridRegionEnum Southafricanorth = new(
        Values.Southafricanorth
    );

    public static readonly LogStreamEventGridRegionEnum Southcentralus = new(Values.Southcentralus);

    public static readonly LogStreamEventGridRegionEnum Southeastasia = new(Values.Southeastasia);

    public static readonly LogStreamEventGridRegionEnum Southindia = new(Values.Southindia);

    public static readonly LogStreamEventGridRegionEnum Swedencentral = new(Values.Swedencentral);

    public static readonly LogStreamEventGridRegionEnum Switzerlandnorth = new(
        Values.Switzerlandnorth
    );

    public static readonly LogStreamEventGridRegionEnum Uaenorth = new(Values.Uaenorth);

    public static readonly LogStreamEventGridRegionEnum Uksouth = new(Values.Uksouth);

    public static readonly LogStreamEventGridRegionEnum Ukwest = new(Values.Ukwest);

    public static readonly LogStreamEventGridRegionEnum Westcentralus = new(Values.Westcentralus);

    public static readonly LogStreamEventGridRegionEnum Westeurope = new(Values.Westeurope);

    public static readonly LogStreamEventGridRegionEnum Westindia = new(Values.Westindia);

    public static readonly LogStreamEventGridRegionEnum Westus = new(Values.Westus);

    public static readonly LogStreamEventGridRegionEnum Westus2 = new(Values.Westus2);

    public LogStreamEventGridRegionEnum(string value)
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
    public static LogStreamEventGridRegionEnum FromCustom(string value)
    {
        return new LogStreamEventGridRegionEnum(value);
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

    public static bool operator ==(LogStreamEventGridRegionEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(LogStreamEventGridRegionEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(LogStreamEventGridRegionEnum value) => value.Value;

    public static explicit operator LogStreamEventGridRegionEnum(string value) => new(value);

    internal class LogStreamEventGridRegionEnumSerializer
        : JsonConverter<LogStreamEventGridRegionEnum>
    {
        public override LogStreamEventGridRegionEnum Read(
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
            return new LogStreamEventGridRegionEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            LogStreamEventGridRegionEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override LogStreamEventGridRegionEnum ReadAsPropertyName(
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
            return new LogStreamEventGridRegionEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            LogStreamEventGridRegionEnum value,
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
        public const string Australiacentral = "australiacentral";

        public const string Australiaeast = "australiaeast";

        public const string Australiasoutheast = "australiasoutheast";

        public const string Brazilsouth = "brazilsouth";

        public const string Canadacentral = "canadacentral";

        public const string Canadaeast = "canadaeast";

        public const string Centralindia = "centralindia";

        public const string Centralus = "centralus";

        public const string Eastasia = "eastasia";

        public const string Eastus = "eastus";

        public const string Eastus2 = "eastus2";

        public const string Francecentral = "francecentral";

        public const string Germanywestcentral = "germanywestcentral";

        public const string Japaneast = "japaneast";

        public const string Japanwest = "japanwest";

        public const string Koreacentral = "koreacentral";

        public const string Koreasouth = "koreasouth";

        public const string Northcentralus = "northcentralus";

        public const string Northeurope = "northeurope";

        public const string Norwayeast = "norwayeast";

        public const string Southafricanorth = "southafricanorth";

        public const string Southcentralus = "southcentralus";

        public const string Southeastasia = "southeastasia";

        public const string Southindia = "southindia";

        public const string Swedencentral = "swedencentral";

        public const string Switzerlandnorth = "switzerlandnorth";

        public const string Uaenorth = "uaenorth";

        public const string Uksouth = "uksouth";

        public const string Ukwest = "ukwest";

        public const string Westcentralus = "westcentralus";

        public const string Westeurope = "westeurope";

        public const string Westindia = "westindia";

        public const string Westus = "westus";

        public const string Westus2 = "westus2";
    }
}
