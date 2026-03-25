// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(CreateFlowsVaultConnectionTelegram.JsonConverter))]
[Serializable]
public class CreateFlowsVaultConnectionTelegram
{
    private CreateFlowsVaultConnectionTelegram(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionTelegramToken value.
    /// </summary>
    public static CreateFlowsVaultConnectionTelegram FromCreateFlowsVaultConnectionTelegramToken(
        Auth0.ManagementApi.CreateFlowsVaultConnectionTelegramToken value
    ) => new("createFlowsVaultConnectionTelegramToken", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionTelegramUninitialized value.
    /// </summary>
    public static CreateFlowsVaultConnectionTelegram FromCreateFlowsVaultConnectionTelegramUninitialized(
        Auth0.ManagementApi.CreateFlowsVaultConnectionTelegramUninitialized value
    ) => new("createFlowsVaultConnectionTelegramUninitialized", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionTelegramToken"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionTelegramToken() =>
        Type == "createFlowsVaultConnectionTelegramToken";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionTelegramUninitialized"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionTelegramUninitialized() =>
        Type == "createFlowsVaultConnectionTelegramUninitialized";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionTelegramToken"/> if <see cref="Type"/> is 'createFlowsVaultConnectionTelegramToken', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionTelegramToken'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionTelegramToken AsCreateFlowsVaultConnectionTelegramToken() =>
        IsCreateFlowsVaultConnectionTelegramToken()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionTelegramToken)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionTelegramToken'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionTelegramUninitialized"/> if <see cref="Type"/> is 'createFlowsVaultConnectionTelegramUninitialized', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionTelegramUninitialized'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionTelegramUninitialized AsCreateFlowsVaultConnectionTelegramUninitialized() =>
        IsCreateFlowsVaultConnectionTelegramUninitialized()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionTelegramUninitialized)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionTelegramUninitialized'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionTelegramToken"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionTelegramToken(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionTelegramToken? value
    )
    {
        if (Type == "createFlowsVaultConnectionTelegramToken")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionTelegramToken)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionTelegramUninitialized"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionTelegramUninitialized(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionTelegramUninitialized? value
    )
    {
        if (Type == "createFlowsVaultConnectionTelegramUninitialized")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionTelegramUninitialized)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionTelegramToken,
            T
        > onCreateFlowsVaultConnectionTelegramToken,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionTelegramUninitialized,
            T
        > onCreateFlowsVaultConnectionTelegramUninitialized
    )
    {
        return Type switch
        {
            "createFlowsVaultConnectionTelegramToken" => onCreateFlowsVaultConnectionTelegramToken(
                AsCreateFlowsVaultConnectionTelegramToken()
            ),
            "createFlowsVaultConnectionTelegramUninitialized" =>
                onCreateFlowsVaultConnectionTelegramUninitialized(
                    AsCreateFlowsVaultConnectionTelegramUninitialized()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionTelegramToken> onCreateFlowsVaultConnectionTelegramToken,
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionTelegramUninitialized> onCreateFlowsVaultConnectionTelegramUninitialized
    )
    {
        switch (Type)
        {
            case "createFlowsVaultConnectionTelegramToken":
                onCreateFlowsVaultConnectionTelegramToken(
                    AsCreateFlowsVaultConnectionTelegramToken()
                );
                break;
            case "createFlowsVaultConnectionTelegramUninitialized":
                onCreateFlowsVaultConnectionTelegramUninitialized(
                    AsCreateFlowsVaultConnectionTelegramUninitialized()
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
        if (obj is not CreateFlowsVaultConnectionTelegram other)
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

    public static implicit operator CreateFlowsVaultConnectionTelegram(
        Auth0.ManagementApi.CreateFlowsVaultConnectionTelegramToken value
    ) => new("createFlowsVaultConnectionTelegramToken", value);

    public static implicit operator CreateFlowsVaultConnectionTelegram(
        Auth0.ManagementApi.CreateFlowsVaultConnectionTelegramUninitialized value
    ) => new("createFlowsVaultConnectionTelegramUninitialized", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CreateFlowsVaultConnectionTelegram>
    {
        public override CreateFlowsVaultConnectionTelegram? Read(
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
                        "createFlowsVaultConnectionTelegramToken",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionTelegramToken)
                    ),
                    (
                        "createFlowsVaultConnectionTelegramUninitialized",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionTelegramUninitialized)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            CreateFlowsVaultConnectionTelegram result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into CreateFlowsVaultConnectionTelegram"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateFlowsVaultConnectionTelegram value,
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

        public override CreateFlowsVaultConnectionTelegram ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            CreateFlowsVaultConnectionTelegram result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateFlowsVaultConnectionTelegram value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
