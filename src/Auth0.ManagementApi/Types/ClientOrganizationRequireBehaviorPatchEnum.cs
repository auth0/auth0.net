using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(
    typeof(ClientOrganizationRequireBehaviorPatchEnum.ClientOrganizationRequireBehaviorPatchEnumSerializer)
)]
[Serializable]
public readonly record struct ClientOrganizationRequireBehaviorPatchEnum : IStringEnum
{
    public static readonly ClientOrganizationRequireBehaviorPatchEnum NoPrompt = new(
        Values.NoPrompt
    );

    public static readonly ClientOrganizationRequireBehaviorPatchEnum PreLoginPrompt = new(
        Values.PreLoginPrompt
    );

    public static readonly ClientOrganizationRequireBehaviorPatchEnum PostLoginPrompt = new(
        Values.PostLoginPrompt
    );

    public ClientOrganizationRequireBehaviorPatchEnum(string value)
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
    public static ClientOrganizationRequireBehaviorPatchEnum FromCustom(string value)
    {
        return new ClientOrganizationRequireBehaviorPatchEnum(value);
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
        ClientOrganizationRequireBehaviorPatchEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        ClientOrganizationRequireBehaviorPatchEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(ClientOrganizationRequireBehaviorPatchEnum value) =>
        value.Value;

    public static explicit operator ClientOrganizationRequireBehaviorPatchEnum(string value) =>
        new(value);

    internal class ClientOrganizationRequireBehaviorPatchEnumSerializer
        : JsonConverter<ClientOrganizationRequireBehaviorPatchEnum>
    {
        public override ClientOrganizationRequireBehaviorPatchEnum Read(
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
            return new ClientOrganizationRequireBehaviorPatchEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClientOrganizationRequireBehaviorPatchEnum value,
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
        public const string NoPrompt = "no_prompt";

        public const string PreLoginPrompt = "pre_login_prompt";

        public const string PostLoginPrompt = "post_login_prompt";
    }
}
