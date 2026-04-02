// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionSalesforce.JsonConverter))]
[Serializable]
public class FlowActionSalesforce
{
    private FlowActionSalesforce(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionSalesforceCreateLead value.
    /// </summary>
    public static FlowActionSalesforce FromFlowActionSalesforceCreateLead(
        Auth0.ManagementApi.FlowActionSalesforceCreateLead value
    ) => new("flowActionSalesforceCreateLead", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionSalesforceGetLead value.
    /// </summary>
    public static FlowActionSalesforce FromFlowActionSalesforceGetLead(
        Auth0.ManagementApi.FlowActionSalesforceGetLead value
    ) => new("flowActionSalesforceGetLead", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionSalesforceSearchLeads value.
    /// </summary>
    public static FlowActionSalesforce FromFlowActionSalesforceSearchLeads(
        Auth0.ManagementApi.FlowActionSalesforceSearchLeads value
    ) => new("flowActionSalesforceSearchLeads", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionSalesforceUpdateLead value.
    /// </summary>
    public static FlowActionSalesforce FromFlowActionSalesforceUpdateLead(
        Auth0.ManagementApi.FlowActionSalesforceUpdateLead value
    ) => new("flowActionSalesforceUpdateLead", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionSalesforceCreateLead"
    /// </summary>
    public bool IsFlowActionSalesforceCreateLead() => Type == "flowActionSalesforceCreateLead";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionSalesforceGetLead"
    /// </summary>
    public bool IsFlowActionSalesforceGetLead() => Type == "flowActionSalesforceGetLead";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionSalesforceSearchLeads"
    /// </summary>
    public bool IsFlowActionSalesforceSearchLeads() => Type == "flowActionSalesforceSearchLeads";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionSalesforceUpdateLead"
    /// </summary>
    public bool IsFlowActionSalesforceUpdateLead() => Type == "flowActionSalesforceUpdateLead";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionSalesforceCreateLead"/> if <see cref="Type"/> is 'flowActionSalesforceCreateLead', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionSalesforceCreateLead'.</exception>
    public Auth0.ManagementApi.FlowActionSalesforceCreateLead AsFlowActionSalesforceCreateLead() =>
        IsFlowActionSalesforceCreateLead()
            ? (Auth0.ManagementApi.FlowActionSalesforceCreateLead)Value!
            : throw new ManagementException("Union type is not 'flowActionSalesforceCreateLead'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionSalesforceGetLead"/> if <see cref="Type"/> is 'flowActionSalesforceGetLead', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionSalesforceGetLead'.</exception>
    public Auth0.ManagementApi.FlowActionSalesforceGetLead AsFlowActionSalesforceGetLead() =>
        IsFlowActionSalesforceGetLead()
            ? (Auth0.ManagementApi.FlowActionSalesforceGetLead)Value!
            : throw new ManagementException("Union type is not 'flowActionSalesforceGetLead'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionSalesforceSearchLeads"/> if <see cref="Type"/> is 'flowActionSalesforceSearchLeads', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionSalesforceSearchLeads'.</exception>
    public Auth0.ManagementApi.FlowActionSalesforceSearchLeads AsFlowActionSalesforceSearchLeads() =>
        IsFlowActionSalesforceSearchLeads()
            ? (Auth0.ManagementApi.FlowActionSalesforceSearchLeads)Value!
            : throw new ManagementException("Union type is not 'flowActionSalesforceSearchLeads'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionSalesforceUpdateLead"/> if <see cref="Type"/> is 'flowActionSalesforceUpdateLead', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionSalesforceUpdateLead'.</exception>
    public Auth0.ManagementApi.FlowActionSalesforceUpdateLead AsFlowActionSalesforceUpdateLead() =>
        IsFlowActionSalesforceUpdateLead()
            ? (Auth0.ManagementApi.FlowActionSalesforceUpdateLead)Value!
            : throw new ManagementException("Union type is not 'flowActionSalesforceUpdateLead'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionSalesforceCreateLead"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionSalesforceCreateLead(
        out Auth0.ManagementApi.FlowActionSalesforceCreateLead? value
    )
    {
        if (Type == "flowActionSalesforceCreateLead")
        {
            value = (Auth0.ManagementApi.FlowActionSalesforceCreateLead)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionSalesforceGetLead"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionSalesforceGetLead(
        out Auth0.ManagementApi.FlowActionSalesforceGetLead? value
    )
    {
        if (Type == "flowActionSalesforceGetLead")
        {
            value = (Auth0.ManagementApi.FlowActionSalesforceGetLead)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionSalesforceSearchLeads"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionSalesforceSearchLeads(
        out Auth0.ManagementApi.FlowActionSalesforceSearchLeads? value
    )
    {
        if (Type == "flowActionSalesforceSearchLeads")
        {
            value = (Auth0.ManagementApi.FlowActionSalesforceSearchLeads)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionSalesforceUpdateLead"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionSalesforceUpdateLead(
        out Auth0.ManagementApi.FlowActionSalesforceUpdateLead? value
    )
    {
        if (Type == "flowActionSalesforceUpdateLead")
        {
            value = (Auth0.ManagementApi.FlowActionSalesforceUpdateLead)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.FlowActionSalesforceCreateLead,
            T
        > onFlowActionSalesforceCreateLead,
        Func<Auth0.ManagementApi.FlowActionSalesforceGetLead, T> onFlowActionSalesforceGetLead,
        Func<
            Auth0.ManagementApi.FlowActionSalesforceSearchLeads,
            T
        > onFlowActionSalesforceSearchLeads,
        Func<Auth0.ManagementApi.FlowActionSalesforceUpdateLead, T> onFlowActionSalesforceUpdateLead
    )
    {
        return Type switch
        {
            "flowActionSalesforceCreateLead" => onFlowActionSalesforceCreateLead(
                AsFlowActionSalesforceCreateLead()
            ),
            "flowActionSalesforceGetLead" => onFlowActionSalesforceGetLead(
                AsFlowActionSalesforceGetLead()
            ),
            "flowActionSalesforceSearchLeads" => onFlowActionSalesforceSearchLeads(
                AsFlowActionSalesforceSearchLeads()
            ),
            "flowActionSalesforceUpdateLead" => onFlowActionSalesforceUpdateLead(
                AsFlowActionSalesforceUpdateLead()
            ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.FlowActionSalesforceCreateLead> onFlowActionSalesforceCreateLead,
        global::System.Action<Auth0.ManagementApi.FlowActionSalesforceGetLead> onFlowActionSalesforceGetLead,
        global::System.Action<Auth0.ManagementApi.FlowActionSalesforceSearchLeads> onFlowActionSalesforceSearchLeads,
        global::System.Action<Auth0.ManagementApi.FlowActionSalesforceUpdateLead> onFlowActionSalesforceUpdateLead
    )
    {
        switch (Type)
        {
            case "flowActionSalesforceCreateLead":
                onFlowActionSalesforceCreateLead(AsFlowActionSalesforceCreateLead());
                break;
            case "flowActionSalesforceGetLead":
                onFlowActionSalesforceGetLead(AsFlowActionSalesforceGetLead());
                break;
            case "flowActionSalesforceSearchLeads":
                onFlowActionSalesforceSearchLeads(AsFlowActionSalesforceSearchLeads());
                break;
            case "flowActionSalesforceUpdateLead":
                onFlowActionSalesforceUpdateLead(AsFlowActionSalesforceUpdateLead());
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
        if (obj is not FlowActionSalesforce other)
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

    public static implicit operator FlowActionSalesforce(
        Auth0.ManagementApi.FlowActionSalesforceCreateLead value
    ) => new("flowActionSalesforceCreateLead", value);

    public static implicit operator FlowActionSalesforce(
        Auth0.ManagementApi.FlowActionSalesforceGetLead value
    ) => new("flowActionSalesforceGetLead", value);

    public static implicit operator FlowActionSalesforce(
        Auth0.ManagementApi.FlowActionSalesforceSearchLeads value
    ) => new("flowActionSalesforceSearchLeads", value);

    public static implicit operator FlowActionSalesforce(
        Auth0.ManagementApi.FlowActionSalesforceUpdateLead value
    ) => new("flowActionSalesforceUpdateLead", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<FlowActionSalesforce>
    {
        public override FlowActionSalesforce? Read(
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
                        "flowActionSalesforceCreateLead",
                        typeof(Auth0.ManagementApi.FlowActionSalesforceCreateLead)
                    ),
                    (
                        "flowActionSalesforceGetLead",
                        typeof(Auth0.ManagementApi.FlowActionSalesforceGetLead)
                    ),
                    (
                        "flowActionSalesforceSearchLeads",
                        typeof(Auth0.ManagementApi.FlowActionSalesforceSearchLeads)
                    ),
                    (
                        "flowActionSalesforceUpdateLead",
                        typeof(Auth0.ManagementApi.FlowActionSalesforceUpdateLead)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            FlowActionSalesforce result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into FlowActionSalesforce"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionSalesforce value,
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
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override FlowActionSalesforce ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            FlowActionSalesforce result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionSalesforce value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
