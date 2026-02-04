// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(CreateFlowsVaultConnectionStripe.JsonConverter))]
[Serializable]
public class CreateFlowsVaultConnectionStripe
{
    private CreateFlowsVaultConnectionStripe(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionStripeKeyPair value.
    /// </summary>
    public static CreateFlowsVaultConnectionStripe FromCreateFlowsVaultConnectionStripeKeyPair(
        Auth0.ManagementApi.CreateFlowsVaultConnectionStripeKeyPair value
    ) => new("createFlowsVaultConnectionStripeKeyPair", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionStripeOauthCode value.
    /// </summary>
    public static CreateFlowsVaultConnectionStripe FromCreateFlowsVaultConnectionStripeOauthCode(
        Auth0.ManagementApi.CreateFlowsVaultConnectionStripeOauthCode value
    ) => new("createFlowsVaultConnectionStripeOauthCode", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionStripeUninitialized value.
    /// </summary>
    public static CreateFlowsVaultConnectionStripe FromCreateFlowsVaultConnectionStripeUninitialized(
        Auth0.ManagementApi.CreateFlowsVaultConnectionStripeUninitialized value
    ) => new("createFlowsVaultConnectionStripeUninitialized", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionStripeKeyPair"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionStripeKeyPair() =>
        Type == "createFlowsVaultConnectionStripeKeyPair";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionStripeOauthCode"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionStripeOauthCode() =>
        Type == "createFlowsVaultConnectionStripeOauthCode";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionStripeUninitialized"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionStripeUninitialized() =>
        Type == "createFlowsVaultConnectionStripeUninitialized";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionStripeKeyPair"/> if <see cref="Type"/> is 'createFlowsVaultConnectionStripeKeyPair', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionStripeKeyPair'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionStripeKeyPair AsCreateFlowsVaultConnectionStripeKeyPair() =>
        IsCreateFlowsVaultConnectionStripeKeyPair()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionStripeKeyPair)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionStripeKeyPair'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionStripeOauthCode"/> if <see cref="Type"/> is 'createFlowsVaultConnectionStripeOauthCode', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionStripeOauthCode'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionStripeOauthCode AsCreateFlowsVaultConnectionStripeOauthCode() =>
        IsCreateFlowsVaultConnectionStripeOauthCode()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionStripeOauthCode)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionStripeOauthCode'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionStripeUninitialized"/> if <see cref="Type"/> is 'createFlowsVaultConnectionStripeUninitialized', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionStripeUninitialized'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionStripeUninitialized AsCreateFlowsVaultConnectionStripeUninitialized() =>
        IsCreateFlowsVaultConnectionStripeUninitialized()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionStripeUninitialized)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionStripeUninitialized'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionStripeKeyPair"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionStripeKeyPair(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionStripeKeyPair? value
    )
    {
        if (Type == "createFlowsVaultConnectionStripeKeyPair")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionStripeKeyPair)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionStripeOauthCode"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionStripeOauthCode(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionStripeOauthCode? value
    )
    {
        if (Type == "createFlowsVaultConnectionStripeOauthCode")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionStripeOauthCode)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionStripeUninitialized"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionStripeUninitialized(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionStripeUninitialized? value
    )
    {
        if (Type == "createFlowsVaultConnectionStripeUninitialized")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionStripeUninitialized)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionStripeKeyPair,
            T
        > onCreateFlowsVaultConnectionStripeKeyPair,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionStripeOauthCode,
            T
        > onCreateFlowsVaultConnectionStripeOauthCode,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionStripeUninitialized,
            T
        > onCreateFlowsVaultConnectionStripeUninitialized
    )
    {
        return Type switch
        {
            "createFlowsVaultConnectionStripeKeyPair" => onCreateFlowsVaultConnectionStripeKeyPair(
                AsCreateFlowsVaultConnectionStripeKeyPair()
            ),
            "createFlowsVaultConnectionStripeOauthCode" =>
                onCreateFlowsVaultConnectionStripeOauthCode(
                    AsCreateFlowsVaultConnectionStripeOauthCode()
                ),
            "createFlowsVaultConnectionStripeUninitialized" =>
                onCreateFlowsVaultConnectionStripeUninitialized(
                    AsCreateFlowsVaultConnectionStripeUninitialized()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionStripeKeyPair> onCreateFlowsVaultConnectionStripeKeyPair,
        System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionStripeOauthCode> onCreateFlowsVaultConnectionStripeOauthCode,
        System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionStripeUninitialized> onCreateFlowsVaultConnectionStripeUninitialized
    )
    {
        switch (Type)
        {
            case "createFlowsVaultConnectionStripeKeyPair":
                onCreateFlowsVaultConnectionStripeKeyPair(
                    AsCreateFlowsVaultConnectionStripeKeyPair()
                );
                break;
            case "createFlowsVaultConnectionStripeOauthCode":
                onCreateFlowsVaultConnectionStripeOauthCode(
                    AsCreateFlowsVaultConnectionStripeOauthCode()
                );
                break;
            case "createFlowsVaultConnectionStripeUninitialized":
                onCreateFlowsVaultConnectionStripeUninitialized(
                    AsCreateFlowsVaultConnectionStripeUninitialized()
                );
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
        if (obj is not CreateFlowsVaultConnectionStripe other)
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

    public static implicit operator CreateFlowsVaultConnectionStripe(
        Auth0.ManagementApi.CreateFlowsVaultConnectionStripeKeyPair value
    ) => new("createFlowsVaultConnectionStripeKeyPair", value);

    public static implicit operator CreateFlowsVaultConnectionStripe(
        Auth0.ManagementApi.CreateFlowsVaultConnectionStripeOauthCode value
    ) => new("createFlowsVaultConnectionStripeOauthCode", value);

    public static implicit operator CreateFlowsVaultConnectionStripe(
        Auth0.ManagementApi.CreateFlowsVaultConnectionStripeUninitialized value
    ) => new("createFlowsVaultConnectionStripeUninitialized", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CreateFlowsVaultConnectionStripe>
    {
        public override CreateFlowsVaultConnectionStripe? Read(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
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
                        "createFlowsVaultConnectionStripeKeyPair",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionStripeKeyPair)
                    ),
                    (
                        "createFlowsVaultConnectionStripeOauthCode",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionStripeOauthCode)
                    ),
                    (
                        "createFlowsVaultConnectionStripeUninitialized",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionStripeUninitialized)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            CreateFlowsVaultConnectionStripe result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into CreateFlowsVaultConnectionStripe"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateFlowsVaultConnectionStripe value,
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

        public override CreateFlowsVaultConnectionStripe ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            CreateFlowsVaultConnectionStripe result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateFlowsVaultConnectionStripe value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
