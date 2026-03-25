// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionActivecampaign.JsonConverter))]
[Serializable]
public class FlowActionActivecampaign
{
    private FlowActionActivecampaign(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Type discriminator
    /// </summary>
    [JsonIgnore]
    public string Type { get; internal set; }

    /// <summary>
    /// Union value
    /// </summary>
    [JsonIgnore]
    public object? Value { get; internal set; }

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionActivecampaignListContacts value.
    /// </summary>
    public static FlowActionActivecampaign FromFlowActionActivecampaignListContacts(
        Auth0.ManagementApi.FlowActionActivecampaignListContacts value
    ) => new("flowActionActivecampaignListContacts", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionActivecampaignUpsertContact value.
    /// </summary>
    public static FlowActionActivecampaign FromFlowActionActivecampaignUpsertContact(
        Auth0.ManagementApi.FlowActionActivecampaignUpsertContact value
    ) => new("flowActionActivecampaignUpsertContact", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionActivecampaignListContacts"
    /// </summary>
    public bool IsFlowActionActivecampaignListContacts() =>
        Type == "flowActionActivecampaignListContacts";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionActivecampaignUpsertContact"
    /// </summary>
    public bool IsFlowActionActivecampaignUpsertContact() =>
        Type == "flowActionActivecampaignUpsertContact";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionActivecampaignListContacts"/> if <see cref="Type"/> is 'flowActionActivecampaignListContacts', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionActivecampaignListContacts'.</exception>
    public Auth0.ManagementApi.FlowActionActivecampaignListContacts AsFlowActionActivecampaignListContacts() =>
        IsFlowActionActivecampaignListContacts()
            ? (Auth0.ManagementApi.FlowActionActivecampaignListContacts)Value!
            : throw new ManagementException(
                "Union type is not 'flowActionActivecampaignListContacts'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionActivecampaignUpsertContact"/> if <see cref="Type"/> is 'flowActionActivecampaignUpsertContact', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionActivecampaignUpsertContact'.</exception>
    public Auth0.ManagementApi.FlowActionActivecampaignUpsertContact AsFlowActionActivecampaignUpsertContact() =>
        IsFlowActionActivecampaignUpsertContact()
            ? (Auth0.ManagementApi.FlowActionActivecampaignUpsertContact)Value!
            : throw new ManagementException(
                "Union type is not 'flowActionActivecampaignUpsertContact'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionActivecampaignListContacts"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionActivecampaignListContacts(
        out Auth0.ManagementApi.FlowActionActivecampaignListContacts? value
    )
    {
        if (Type == "flowActionActivecampaignListContacts")
        {
            value = (Auth0.ManagementApi.FlowActionActivecampaignListContacts)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionActivecampaignUpsertContact"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionActivecampaignUpsertContact(
        out Auth0.ManagementApi.FlowActionActivecampaignUpsertContact? value
    )
    {
        if (Type == "flowActionActivecampaignUpsertContact")
        {
            value = (Auth0.ManagementApi.FlowActionActivecampaignUpsertContact)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.FlowActionActivecampaignListContacts,
            T
        > onFlowActionActivecampaignListContacts,
        Func<
            Auth0.ManagementApi.FlowActionActivecampaignUpsertContact,
            T
        > onFlowActionActivecampaignUpsertContact
    )
    {
        return Type switch
        {
            "flowActionActivecampaignListContacts" => onFlowActionActivecampaignListContacts(
                AsFlowActionActivecampaignListContacts()
            ),
            "flowActionActivecampaignUpsertContact" => onFlowActionActivecampaignUpsertContact(
                AsFlowActionActivecampaignUpsertContact()
            ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.FlowActionActivecampaignListContacts> onFlowActionActivecampaignListContacts,
        global::System.Action<Auth0.ManagementApi.FlowActionActivecampaignUpsertContact> onFlowActionActivecampaignUpsertContact
    )
    {
        switch (Type)
        {
            case "flowActionActivecampaignListContacts":
                onFlowActionActivecampaignListContacts(AsFlowActionActivecampaignListContacts());
                break;
            case "flowActionActivecampaignUpsertContact":
                onFlowActionActivecampaignUpsertContact(AsFlowActionActivecampaignUpsertContact());
                break;
            default:
                throw new ManagementException($"Unknown union type: {Type}");
        }
    }

    public override int GetHashCode()
    {
        unchecked
        {
            var hashCode = Type.GetHashCode();
            if (Value != null)
            {
                hashCode = (hashCode * 397) ^ Value.GetHashCode();
            }
            return hashCode;
        }
    }

    public override bool Equals(object? obj)
    {
        if (obj is null)
            return false;
        if (ReferenceEquals(this, obj))
            return true;
        if (obj is not FlowActionActivecampaign other)
            return false;

        // Compare type discriminators
        if (Type != other.Type)
            return false;

        // Compare values using EqualityComparer for deep comparison
        return System.Collections.Generic.EqualityComparer<object?>.Default.Equals(
            Value,
            other.Value
        );
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator FlowActionActivecampaign(
        Auth0.ManagementApi.FlowActionActivecampaignListContacts value
    ) => new("flowActionActivecampaignListContacts", value);

    public static implicit operator FlowActionActivecampaign(
        Auth0.ManagementApi.FlowActionActivecampaignUpsertContact value
    ) => new("flowActionActivecampaignUpsertContact", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<FlowActionActivecampaign>
    {
        public override FlowActionActivecampaign? Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            if (reader.TokenType == JsonTokenType.StartObject)
            {
                var document = JsonDocument.ParseValue(ref reader);

                var types = new (string Key, System.Type Type)[]
                {
                    (
                        "flowActionActivecampaignListContacts",
                        typeof(Auth0.ManagementApi.FlowActionActivecampaignListContacts)
                    ),
                    (
                        "flowActionActivecampaignUpsertContact",
                        typeof(Auth0.ManagementApi.FlowActionActivecampaignUpsertContact)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            FlowActionActivecampaign result = new(key, value);
                            return result;
                        }
                    }
                    catch (JsonException)
                    {
                        // Try next type;
                    }
                }
            }

            throw new JsonException(
                $"Cannot deserialize JSON token {reader.TokenType} into FlowActionActivecampaign"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionActivecampaign value,
            JsonSerializerOptions options
        )
        {
            if (value == null)
            {
                writer.WriteNullValue();
                return;
            }

            value.Visit(
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override FlowActionActivecampaign ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            FlowActionActivecampaign result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionActivecampaign value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
