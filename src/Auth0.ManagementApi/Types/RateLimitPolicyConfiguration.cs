// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// The configuration of the rate limit policy.
/// </summary>
[JsonConverter(typeof(RateLimitPolicyConfiguration.JsonConverter))]
[Serializable]
public class RateLimitPolicyConfiguration
{
    private RateLimitPolicyConfiguration(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.RateLimitPolicyConfigurationZero value.
    /// </summary>
    public static RateLimitPolicyConfiguration FromRateLimitPolicyConfigurationZero(
        Auth0.ManagementApi.RateLimitPolicyConfigurationZero value
    ) => new("rateLimitPolicyConfigurationZero", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.RateLimitPolicyConfigurationOne value.
    /// </summary>
    public static RateLimitPolicyConfiguration FromRateLimitPolicyConfigurationOne(
        Auth0.ManagementApi.RateLimitPolicyConfigurationOne value
    ) => new("rateLimitPolicyConfigurationOne", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.RateLimitPolicyConfigurationAction value.
    /// </summary>
    public static RateLimitPolicyConfiguration FromRateLimitPolicyConfigurationAction(
        Auth0.ManagementApi.RateLimitPolicyConfigurationAction value
    ) => new("rateLimitPolicyConfigurationAction", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "rateLimitPolicyConfigurationZero"
    /// </summary>
    public bool IsRateLimitPolicyConfigurationZero() => Type == "rateLimitPolicyConfigurationZero";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "rateLimitPolicyConfigurationOne"
    /// </summary>
    public bool IsRateLimitPolicyConfigurationOne() => Type == "rateLimitPolicyConfigurationOne";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "rateLimitPolicyConfigurationAction"
    /// </summary>
    public bool IsRateLimitPolicyConfigurationAction() =>
        Type == "rateLimitPolicyConfigurationAction";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.RateLimitPolicyConfigurationZero"/> if <see cref="Type"/> is 'rateLimitPolicyConfigurationZero', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'rateLimitPolicyConfigurationZero'.</exception>
    public Auth0.ManagementApi.RateLimitPolicyConfigurationZero AsRateLimitPolicyConfigurationZero() =>
        IsRateLimitPolicyConfigurationZero()
            ? (Auth0.ManagementApi.RateLimitPolicyConfigurationZero)Value!
            : throw new ManagementException("Union type is not 'rateLimitPolicyConfigurationZero'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.RateLimitPolicyConfigurationOne"/> if <see cref="Type"/> is 'rateLimitPolicyConfigurationOne', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'rateLimitPolicyConfigurationOne'.</exception>
    public Auth0.ManagementApi.RateLimitPolicyConfigurationOne AsRateLimitPolicyConfigurationOne() =>
        IsRateLimitPolicyConfigurationOne()
            ? (Auth0.ManagementApi.RateLimitPolicyConfigurationOne)Value!
            : throw new ManagementException("Union type is not 'rateLimitPolicyConfigurationOne'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.RateLimitPolicyConfigurationAction"/> if <see cref="Type"/> is 'rateLimitPolicyConfigurationAction', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'rateLimitPolicyConfigurationAction'.</exception>
    public Auth0.ManagementApi.RateLimitPolicyConfigurationAction AsRateLimitPolicyConfigurationAction() =>
        IsRateLimitPolicyConfigurationAction()
            ? (Auth0.ManagementApi.RateLimitPolicyConfigurationAction)Value!
            : throw new ManagementException(
                "Union type is not 'rateLimitPolicyConfigurationAction'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.RateLimitPolicyConfigurationZero"/> and returns true if successful.
    /// </summary>
    public bool TryGetRateLimitPolicyConfigurationZero(
        out Auth0.ManagementApi.RateLimitPolicyConfigurationZero? value
    )
    {
        if (Type == "rateLimitPolicyConfigurationZero")
        {
            value = (Auth0.ManagementApi.RateLimitPolicyConfigurationZero)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.RateLimitPolicyConfigurationOne"/> and returns true if successful.
    /// </summary>
    public bool TryGetRateLimitPolicyConfigurationOne(
        out Auth0.ManagementApi.RateLimitPolicyConfigurationOne? value
    )
    {
        if (Type == "rateLimitPolicyConfigurationOne")
        {
            value = (Auth0.ManagementApi.RateLimitPolicyConfigurationOne)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.RateLimitPolicyConfigurationAction"/> and returns true if successful.
    /// </summary>
    public bool TryGetRateLimitPolicyConfigurationAction(
        out Auth0.ManagementApi.RateLimitPolicyConfigurationAction? value
    )
    {
        if (Type == "rateLimitPolicyConfigurationAction")
        {
            value = (Auth0.ManagementApi.RateLimitPolicyConfigurationAction)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.RateLimitPolicyConfigurationZero,
            T
        > onRateLimitPolicyConfigurationZero,
        Func<
            Auth0.ManagementApi.RateLimitPolicyConfigurationOne,
            T
        > onRateLimitPolicyConfigurationOne,
        Func<
            Auth0.ManagementApi.RateLimitPolicyConfigurationAction,
            T
        > onRateLimitPolicyConfigurationAction
    )
    {
        return Type switch
        {
            "rateLimitPolicyConfigurationZero" => onRateLimitPolicyConfigurationZero(
                AsRateLimitPolicyConfigurationZero()
            ),
            "rateLimitPolicyConfigurationOne" => onRateLimitPolicyConfigurationOne(
                AsRateLimitPolicyConfigurationOne()
            ),
            "rateLimitPolicyConfigurationAction" => onRateLimitPolicyConfigurationAction(
                AsRateLimitPolicyConfigurationAction()
            ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.RateLimitPolicyConfigurationZero> onRateLimitPolicyConfigurationZero,
        global::System.Action<Auth0.ManagementApi.RateLimitPolicyConfigurationOne> onRateLimitPolicyConfigurationOne,
        global::System.Action<Auth0.ManagementApi.RateLimitPolicyConfigurationAction> onRateLimitPolicyConfigurationAction
    )
    {
        switch (Type)
        {
            case "rateLimitPolicyConfigurationZero":
                onRateLimitPolicyConfigurationZero(AsRateLimitPolicyConfigurationZero());
                break;
            case "rateLimitPolicyConfigurationOne":
                onRateLimitPolicyConfigurationOne(AsRateLimitPolicyConfigurationOne());
                break;
            case "rateLimitPolicyConfigurationAction":
                onRateLimitPolicyConfigurationAction(AsRateLimitPolicyConfigurationAction());
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
        if (obj is not RateLimitPolicyConfiguration other)
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

    public static implicit operator RateLimitPolicyConfiguration(
        Auth0.ManagementApi.RateLimitPolicyConfigurationZero value
    ) => new("rateLimitPolicyConfigurationZero", value);

    public static implicit operator RateLimitPolicyConfiguration(
        Auth0.ManagementApi.RateLimitPolicyConfigurationOne value
    ) => new("rateLimitPolicyConfigurationOne", value);

    public static implicit operator RateLimitPolicyConfiguration(
        Auth0.ManagementApi.RateLimitPolicyConfigurationAction value
    ) => new("rateLimitPolicyConfigurationAction", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<RateLimitPolicyConfiguration>
    {
        public override RateLimitPolicyConfiguration? Read(
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
                        "rateLimitPolicyConfigurationZero",
                        typeof(Auth0.ManagementApi.RateLimitPolicyConfigurationZero)
                    ),
                    (
                        "rateLimitPolicyConfigurationOne",
                        typeof(Auth0.ManagementApi.RateLimitPolicyConfigurationOne)
                    ),
                    (
                        "rateLimitPolicyConfigurationAction",
                        typeof(Auth0.ManagementApi.RateLimitPolicyConfigurationAction)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            RateLimitPolicyConfiguration result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into RateLimitPolicyConfiguration"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            RateLimitPolicyConfiguration value,
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

        public override RateLimitPolicyConfiguration ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            RateLimitPolicyConfiguration result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            RateLimitPolicyConfiguration value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
