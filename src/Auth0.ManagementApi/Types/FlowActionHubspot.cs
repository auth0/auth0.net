// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionHubspot.JsonConverter))]
[Serializable]
public class FlowActionHubspot
{
    private FlowActionHubspot(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionHubspotEnrollContact value.
    /// </summary>
    public static FlowActionHubspot FromFlowActionHubspotEnrollContact(
        Auth0.ManagementApi.FlowActionHubspotEnrollContact value
    ) => new("flowActionHubspotEnrollContact", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionHubspotGetContact value.
    /// </summary>
    public static FlowActionHubspot FromFlowActionHubspotGetContact(
        Auth0.ManagementApi.FlowActionHubspotGetContact value
    ) => new("flowActionHubspotGetContact", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionHubspotUpsertContact value.
    /// </summary>
    public static FlowActionHubspot FromFlowActionHubspotUpsertContact(
        Auth0.ManagementApi.FlowActionHubspotUpsertContact value
    ) => new("flowActionHubspotUpsertContact", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionHubspotEnrollContact"
    /// </summary>
    public bool IsFlowActionHubspotEnrollContact() => Type == "flowActionHubspotEnrollContact";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionHubspotGetContact"
    /// </summary>
    public bool IsFlowActionHubspotGetContact() => Type == "flowActionHubspotGetContact";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionHubspotUpsertContact"
    /// </summary>
    public bool IsFlowActionHubspotUpsertContact() => Type == "flowActionHubspotUpsertContact";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionHubspotEnrollContact"/> if <see cref="Type"/> is 'flowActionHubspotEnrollContact', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionHubspotEnrollContact'.</exception>
    public Auth0.ManagementApi.FlowActionHubspotEnrollContact AsFlowActionHubspotEnrollContact() =>
        IsFlowActionHubspotEnrollContact()
            ? (Auth0.ManagementApi.FlowActionHubspotEnrollContact)Value!
            : throw new ManagementException("Union type is not 'flowActionHubspotEnrollContact'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionHubspotGetContact"/> if <see cref="Type"/> is 'flowActionHubspotGetContact', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionHubspotGetContact'.</exception>
    public Auth0.ManagementApi.FlowActionHubspotGetContact AsFlowActionHubspotGetContact() =>
        IsFlowActionHubspotGetContact()
            ? (Auth0.ManagementApi.FlowActionHubspotGetContact)Value!
            : throw new ManagementException("Union type is not 'flowActionHubspotGetContact'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionHubspotUpsertContact"/> if <see cref="Type"/> is 'flowActionHubspotUpsertContact', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionHubspotUpsertContact'.</exception>
    public Auth0.ManagementApi.FlowActionHubspotUpsertContact AsFlowActionHubspotUpsertContact() =>
        IsFlowActionHubspotUpsertContact()
            ? (Auth0.ManagementApi.FlowActionHubspotUpsertContact)Value!
            : throw new ManagementException("Union type is not 'flowActionHubspotUpsertContact'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionHubspotEnrollContact"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionHubspotEnrollContact(
        out Auth0.ManagementApi.FlowActionHubspotEnrollContact? value
    )
    {
        if (Type == "flowActionHubspotEnrollContact")
        {
            value = (Auth0.ManagementApi.FlowActionHubspotEnrollContact)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionHubspotGetContact"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionHubspotGetContact(
        out Auth0.ManagementApi.FlowActionHubspotGetContact? value
    )
    {
        if (Type == "flowActionHubspotGetContact")
        {
            value = (Auth0.ManagementApi.FlowActionHubspotGetContact)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionHubspotUpsertContact"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionHubspotUpsertContact(
        out Auth0.ManagementApi.FlowActionHubspotUpsertContact? value
    )
    {
        if (Type == "flowActionHubspotUpsertContact")
        {
            value = (Auth0.ManagementApi.FlowActionHubspotUpsertContact)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.FlowActionHubspotEnrollContact,
            T
        > onFlowActionHubspotEnrollContact,
        Func<Auth0.ManagementApi.FlowActionHubspotGetContact, T> onFlowActionHubspotGetContact,
        Func<Auth0.ManagementApi.FlowActionHubspotUpsertContact, T> onFlowActionHubspotUpsertContact
    )
    {
        return Type switch
        {
            "flowActionHubspotEnrollContact" => onFlowActionHubspotEnrollContact(
                AsFlowActionHubspotEnrollContact()
            ),
            "flowActionHubspotGetContact" => onFlowActionHubspotGetContact(
                AsFlowActionHubspotGetContact()
            ),
            "flowActionHubspotUpsertContact" => onFlowActionHubspotUpsertContact(
                AsFlowActionHubspotUpsertContact()
            ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.FlowActionHubspotEnrollContact> onFlowActionHubspotEnrollContact,
        global::System.Action<Auth0.ManagementApi.FlowActionHubspotGetContact> onFlowActionHubspotGetContact,
        global::System.Action<Auth0.ManagementApi.FlowActionHubspotUpsertContact> onFlowActionHubspotUpsertContact
    )
    {
        switch (Type)
        {
            case "flowActionHubspotEnrollContact":
                onFlowActionHubspotEnrollContact(AsFlowActionHubspotEnrollContact());
                break;
            case "flowActionHubspotGetContact":
                onFlowActionHubspotGetContact(AsFlowActionHubspotGetContact());
                break;
            case "flowActionHubspotUpsertContact":
                onFlowActionHubspotUpsertContact(AsFlowActionHubspotUpsertContact());
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
        if (obj is not FlowActionHubspot other)
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

    public static implicit operator FlowActionHubspot(
        Auth0.ManagementApi.FlowActionHubspotEnrollContact value
    ) => new("flowActionHubspotEnrollContact", value);

    public static implicit operator FlowActionHubspot(
        Auth0.ManagementApi.FlowActionHubspotGetContact value
    ) => new("flowActionHubspotGetContact", value);

    public static implicit operator FlowActionHubspot(
        Auth0.ManagementApi.FlowActionHubspotUpsertContact value
    ) => new("flowActionHubspotUpsertContact", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<FlowActionHubspot>
    {
        public override FlowActionHubspot? Read(
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
                        "flowActionHubspotEnrollContact",
                        typeof(Auth0.ManagementApi.FlowActionHubspotEnrollContact)
                    ),
                    (
                        "flowActionHubspotGetContact",
                        typeof(Auth0.ManagementApi.FlowActionHubspotGetContact)
                    ),
                    (
                        "flowActionHubspotUpsertContact",
                        typeof(Auth0.ManagementApi.FlowActionHubspotUpsertContact)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            FlowActionHubspot result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into FlowActionHubspot"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionHubspot value,
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
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override FlowActionHubspot ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            FlowActionHubspot result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionHubspot value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
