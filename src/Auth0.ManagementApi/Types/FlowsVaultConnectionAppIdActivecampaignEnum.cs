using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(FlowsVaultConnectionAppIdActivecampaignEnum.FlowsVaultConnectionAppIdActivecampaignEnumSerializer)
)]
[Serializable]
public readonly record struct FlowsVaultConnectionAppIdActivecampaignEnum : IStringEnum
{
    public static readonly FlowsVaultConnectionAppIdActivecampaignEnum Activecampaign = new(
        Values.Activecampaign
    );

    public FlowsVaultConnectionAppIdActivecampaignEnum(string value)
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
    public static FlowsVaultConnectionAppIdActivecampaignEnum FromCustom(string value)
    {
        return new FlowsVaultConnectionAppIdActivecampaignEnum(value);
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
        FlowsVaultConnectionAppIdActivecampaignEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        FlowsVaultConnectionAppIdActivecampaignEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(FlowsVaultConnectionAppIdActivecampaignEnum value) =>
        value.Value;

    public static explicit operator FlowsVaultConnectionAppIdActivecampaignEnum(string value) =>
        new(value);

    internal class FlowsVaultConnectionAppIdActivecampaignEnumSerializer
        : JsonConverter<FlowsVaultConnectionAppIdActivecampaignEnum>
    {
        public override FlowsVaultConnectionAppIdActivecampaignEnum Read(
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
            return new FlowsVaultConnectionAppIdActivecampaignEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowsVaultConnectionAppIdActivecampaignEnum value,
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
        public const string Activecampaign = "ACTIVECAMPAIGN";
    }
}
