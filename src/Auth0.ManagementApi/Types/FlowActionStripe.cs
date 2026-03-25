// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionStripe.JsonConverter))]
[Serializable]
public class FlowActionStripe
{
    private FlowActionStripe(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionStripeAddTaxId value.
    /// </summary>
    public static FlowActionStripe FromFlowActionStripeAddTaxId(
        Auth0.ManagementApi.FlowActionStripeAddTaxId value
    ) => new("flowActionStripeAddTaxId", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionStripeCreateCustomer value.
    /// </summary>
    public static FlowActionStripe FromFlowActionStripeCreateCustomer(
        Auth0.ManagementApi.FlowActionStripeCreateCustomer value
    ) => new("flowActionStripeCreateCustomer", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionStripeCreatePortalSession value.
    /// </summary>
    public static FlowActionStripe FromFlowActionStripeCreatePortalSession(
        Auth0.ManagementApi.FlowActionStripeCreatePortalSession value
    ) => new("flowActionStripeCreatePortalSession", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionStripeDeleteTaxId value.
    /// </summary>
    public static FlowActionStripe FromFlowActionStripeDeleteTaxId(
        Auth0.ManagementApi.FlowActionStripeDeleteTaxId value
    ) => new("flowActionStripeDeleteTaxId", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionStripeFindCustomers value.
    /// </summary>
    public static FlowActionStripe FromFlowActionStripeFindCustomers(
        Auth0.ManagementApi.FlowActionStripeFindCustomers value
    ) => new("flowActionStripeFindCustomers", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionStripeGetCustomer value.
    /// </summary>
    public static FlowActionStripe FromFlowActionStripeGetCustomer(
        Auth0.ManagementApi.FlowActionStripeGetCustomer value
    ) => new("flowActionStripeGetCustomer", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionStripeUpdateCustomer value.
    /// </summary>
    public static FlowActionStripe FromFlowActionStripeUpdateCustomer(
        Auth0.ManagementApi.FlowActionStripeUpdateCustomer value
    ) => new("flowActionStripeUpdateCustomer", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionStripeAddTaxId"
    /// </summary>
    public bool IsFlowActionStripeAddTaxId() => Type == "flowActionStripeAddTaxId";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionStripeCreateCustomer"
    /// </summary>
    public bool IsFlowActionStripeCreateCustomer() => Type == "flowActionStripeCreateCustomer";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionStripeCreatePortalSession"
    /// </summary>
    public bool IsFlowActionStripeCreatePortalSession() =>
        Type == "flowActionStripeCreatePortalSession";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionStripeDeleteTaxId"
    /// </summary>
    public bool IsFlowActionStripeDeleteTaxId() => Type == "flowActionStripeDeleteTaxId";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionStripeFindCustomers"
    /// </summary>
    public bool IsFlowActionStripeFindCustomers() => Type == "flowActionStripeFindCustomers";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionStripeGetCustomer"
    /// </summary>
    public bool IsFlowActionStripeGetCustomer() => Type == "flowActionStripeGetCustomer";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionStripeUpdateCustomer"
    /// </summary>
    public bool IsFlowActionStripeUpdateCustomer() => Type == "flowActionStripeUpdateCustomer";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionStripeAddTaxId"/> if <see cref="Type"/> is 'flowActionStripeAddTaxId', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionStripeAddTaxId'.</exception>
    public Auth0.ManagementApi.FlowActionStripeAddTaxId AsFlowActionStripeAddTaxId() =>
        IsFlowActionStripeAddTaxId()
            ? (Auth0.ManagementApi.FlowActionStripeAddTaxId)Value!
            : throw new ManagementException("Union type is not 'flowActionStripeAddTaxId'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionStripeCreateCustomer"/> if <see cref="Type"/> is 'flowActionStripeCreateCustomer', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionStripeCreateCustomer'.</exception>
    public Auth0.ManagementApi.FlowActionStripeCreateCustomer AsFlowActionStripeCreateCustomer() =>
        IsFlowActionStripeCreateCustomer()
            ? (Auth0.ManagementApi.FlowActionStripeCreateCustomer)Value!
            : throw new ManagementException("Union type is not 'flowActionStripeCreateCustomer'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionStripeCreatePortalSession"/> if <see cref="Type"/> is 'flowActionStripeCreatePortalSession', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionStripeCreatePortalSession'.</exception>
    public Auth0.ManagementApi.FlowActionStripeCreatePortalSession AsFlowActionStripeCreatePortalSession() =>
        IsFlowActionStripeCreatePortalSession()
            ? (Auth0.ManagementApi.FlowActionStripeCreatePortalSession)Value!
            : throw new ManagementException(
                "Union type is not 'flowActionStripeCreatePortalSession'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionStripeDeleteTaxId"/> if <see cref="Type"/> is 'flowActionStripeDeleteTaxId', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionStripeDeleteTaxId'.</exception>
    public Auth0.ManagementApi.FlowActionStripeDeleteTaxId AsFlowActionStripeDeleteTaxId() =>
        IsFlowActionStripeDeleteTaxId()
            ? (Auth0.ManagementApi.FlowActionStripeDeleteTaxId)Value!
            : throw new ManagementException("Union type is not 'flowActionStripeDeleteTaxId'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionStripeFindCustomers"/> if <see cref="Type"/> is 'flowActionStripeFindCustomers', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionStripeFindCustomers'.</exception>
    public Auth0.ManagementApi.FlowActionStripeFindCustomers AsFlowActionStripeFindCustomers() =>
        IsFlowActionStripeFindCustomers()
            ? (Auth0.ManagementApi.FlowActionStripeFindCustomers)Value!
            : throw new ManagementException("Union type is not 'flowActionStripeFindCustomers'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionStripeGetCustomer"/> if <see cref="Type"/> is 'flowActionStripeGetCustomer', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionStripeGetCustomer'.</exception>
    public Auth0.ManagementApi.FlowActionStripeGetCustomer AsFlowActionStripeGetCustomer() =>
        IsFlowActionStripeGetCustomer()
            ? (Auth0.ManagementApi.FlowActionStripeGetCustomer)Value!
            : throw new ManagementException("Union type is not 'flowActionStripeGetCustomer'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionStripeUpdateCustomer"/> if <see cref="Type"/> is 'flowActionStripeUpdateCustomer', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionStripeUpdateCustomer'.</exception>
    public Auth0.ManagementApi.FlowActionStripeUpdateCustomer AsFlowActionStripeUpdateCustomer() =>
        IsFlowActionStripeUpdateCustomer()
            ? (Auth0.ManagementApi.FlowActionStripeUpdateCustomer)Value!
            : throw new ManagementException("Union type is not 'flowActionStripeUpdateCustomer'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionStripeAddTaxId"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionStripeAddTaxId(
        out Auth0.ManagementApi.FlowActionStripeAddTaxId? value
    )
    {
        if (Type == "flowActionStripeAddTaxId")
        {
            value = (Auth0.ManagementApi.FlowActionStripeAddTaxId)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionStripeCreateCustomer"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionStripeCreateCustomer(
        out Auth0.ManagementApi.FlowActionStripeCreateCustomer? value
    )
    {
        if (Type == "flowActionStripeCreateCustomer")
        {
            value = (Auth0.ManagementApi.FlowActionStripeCreateCustomer)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionStripeCreatePortalSession"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionStripeCreatePortalSession(
        out Auth0.ManagementApi.FlowActionStripeCreatePortalSession? value
    )
    {
        if (Type == "flowActionStripeCreatePortalSession")
        {
            value = (Auth0.ManagementApi.FlowActionStripeCreatePortalSession)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionStripeDeleteTaxId"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionStripeDeleteTaxId(
        out Auth0.ManagementApi.FlowActionStripeDeleteTaxId? value
    )
    {
        if (Type == "flowActionStripeDeleteTaxId")
        {
            value = (Auth0.ManagementApi.FlowActionStripeDeleteTaxId)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionStripeFindCustomers"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionStripeFindCustomers(
        out Auth0.ManagementApi.FlowActionStripeFindCustomers? value
    )
    {
        if (Type == "flowActionStripeFindCustomers")
        {
            value = (Auth0.ManagementApi.FlowActionStripeFindCustomers)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionStripeGetCustomer"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionStripeGetCustomer(
        out Auth0.ManagementApi.FlowActionStripeGetCustomer? value
    )
    {
        if (Type == "flowActionStripeGetCustomer")
        {
            value = (Auth0.ManagementApi.FlowActionStripeGetCustomer)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionStripeUpdateCustomer"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionStripeUpdateCustomer(
        out Auth0.ManagementApi.FlowActionStripeUpdateCustomer? value
    )
    {
        if (Type == "flowActionStripeUpdateCustomer")
        {
            value = (Auth0.ManagementApi.FlowActionStripeUpdateCustomer)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Auth0.ManagementApi.FlowActionStripeAddTaxId, T> onFlowActionStripeAddTaxId,
        Func<
            Auth0.ManagementApi.FlowActionStripeCreateCustomer,
            T
        > onFlowActionStripeCreateCustomer,
        Func<
            Auth0.ManagementApi.FlowActionStripeCreatePortalSession,
            T
        > onFlowActionStripeCreatePortalSession,
        Func<Auth0.ManagementApi.FlowActionStripeDeleteTaxId, T> onFlowActionStripeDeleteTaxId,
        Func<Auth0.ManagementApi.FlowActionStripeFindCustomers, T> onFlowActionStripeFindCustomers,
        Func<Auth0.ManagementApi.FlowActionStripeGetCustomer, T> onFlowActionStripeGetCustomer,
        Func<Auth0.ManagementApi.FlowActionStripeUpdateCustomer, T> onFlowActionStripeUpdateCustomer
    )
    {
        return Type switch
        {
            "flowActionStripeAddTaxId" => onFlowActionStripeAddTaxId(AsFlowActionStripeAddTaxId()),
            "flowActionStripeCreateCustomer" => onFlowActionStripeCreateCustomer(
                AsFlowActionStripeCreateCustomer()
            ),
            "flowActionStripeCreatePortalSession" => onFlowActionStripeCreatePortalSession(
                AsFlowActionStripeCreatePortalSession()
            ),
            "flowActionStripeDeleteTaxId" => onFlowActionStripeDeleteTaxId(
                AsFlowActionStripeDeleteTaxId()
            ),
            "flowActionStripeFindCustomers" => onFlowActionStripeFindCustomers(
                AsFlowActionStripeFindCustomers()
            ),
            "flowActionStripeGetCustomer" => onFlowActionStripeGetCustomer(
                AsFlowActionStripeGetCustomer()
            ),
            "flowActionStripeUpdateCustomer" => onFlowActionStripeUpdateCustomer(
                AsFlowActionStripeUpdateCustomer()
            ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.FlowActionStripeAddTaxId> onFlowActionStripeAddTaxId,
        global::System.Action<Auth0.ManagementApi.FlowActionStripeCreateCustomer> onFlowActionStripeCreateCustomer,
        global::System.Action<Auth0.ManagementApi.FlowActionStripeCreatePortalSession> onFlowActionStripeCreatePortalSession,
        global::System.Action<Auth0.ManagementApi.FlowActionStripeDeleteTaxId> onFlowActionStripeDeleteTaxId,
        global::System.Action<Auth0.ManagementApi.FlowActionStripeFindCustomers> onFlowActionStripeFindCustomers,
        global::System.Action<Auth0.ManagementApi.FlowActionStripeGetCustomer> onFlowActionStripeGetCustomer,
        global::System.Action<Auth0.ManagementApi.FlowActionStripeUpdateCustomer> onFlowActionStripeUpdateCustomer
    )
    {
        switch (Type)
        {
            case "flowActionStripeAddTaxId":
                onFlowActionStripeAddTaxId(AsFlowActionStripeAddTaxId());
                break;
            case "flowActionStripeCreateCustomer":
                onFlowActionStripeCreateCustomer(AsFlowActionStripeCreateCustomer());
                break;
            case "flowActionStripeCreatePortalSession":
                onFlowActionStripeCreatePortalSession(AsFlowActionStripeCreatePortalSession());
                break;
            case "flowActionStripeDeleteTaxId":
                onFlowActionStripeDeleteTaxId(AsFlowActionStripeDeleteTaxId());
                break;
            case "flowActionStripeFindCustomers":
                onFlowActionStripeFindCustomers(AsFlowActionStripeFindCustomers());
                break;
            case "flowActionStripeGetCustomer":
                onFlowActionStripeGetCustomer(AsFlowActionStripeGetCustomer());
                break;
            case "flowActionStripeUpdateCustomer":
                onFlowActionStripeUpdateCustomer(AsFlowActionStripeUpdateCustomer());
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
        if (obj is not FlowActionStripe other)
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

    public static implicit operator FlowActionStripe(
        Auth0.ManagementApi.FlowActionStripeAddTaxId value
    ) => new("flowActionStripeAddTaxId", value);

    public static implicit operator FlowActionStripe(
        Auth0.ManagementApi.FlowActionStripeCreateCustomer value
    ) => new("flowActionStripeCreateCustomer", value);

    public static implicit operator FlowActionStripe(
        Auth0.ManagementApi.FlowActionStripeCreatePortalSession value
    ) => new("flowActionStripeCreatePortalSession", value);

    public static implicit operator FlowActionStripe(
        Auth0.ManagementApi.FlowActionStripeDeleteTaxId value
    ) => new("flowActionStripeDeleteTaxId", value);

    public static implicit operator FlowActionStripe(
        Auth0.ManagementApi.FlowActionStripeFindCustomers value
    ) => new("flowActionStripeFindCustomers", value);

    public static implicit operator FlowActionStripe(
        Auth0.ManagementApi.FlowActionStripeGetCustomer value
    ) => new("flowActionStripeGetCustomer", value);

    public static implicit operator FlowActionStripe(
        Auth0.ManagementApi.FlowActionStripeUpdateCustomer value
    ) => new("flowActionStripeUpdateCustomer", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<FlowActionStripe>
    {
        public override FlowActionStripe? Read(
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
                        "flowActionStripeAddTaxId",
                        typeof(Auth0.ManagementApi.FlowActionStripeAddTaxId)
                    ),
                    (
                        "flowActionStripeCreateCustomer",
                        typeof(Auth0.ManagementApi.FlowActionStripeCreateCustomer)
                    ),
                    (
                        "flowActionStripeCreatePortalSession",
                        typeof(Auth0.ManagementApi.FlowActionStripeCreatePortalSession)
                    ),
                    (
                        "flowActionStripeDeleteTaxId",
                        typeof(Auth0.ManagementApi.FlowActionStripeDeleteTaxId)
                    ),
                    (
                        "flowActionStripeFindCustomers",
                        typeof(Auth0.ManagementApi.FlowActionStripeFindCustomers)
                    ),
                    (
                        "flowActionStripeGetCustomer",
                        typeof(Auth0.ManagementApi.FlowActionStripeGetCustomer)
                    ),
                    (
                        "flowActionStripeUpdateCustomer",
                        typeof(Auth0.ManagementApi.FlowActionStripeUpdateCustomer)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            FlowActionStripe result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into FlowActionStripe"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionStripe value,
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
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override FlowActionStripe ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            FlowActionStripe result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionStripe value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
