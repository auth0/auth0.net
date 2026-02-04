// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(CreateFlowsVaultConnectionSlack.JsonConverter))]
[Serializable]
public class CreateFlowsVaultConnectionSlack
{
    private CreateFlowsVaultConnectionSlack(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionSlackWebhook value.
    /// </summary>
    public static CreateFlowsVaultConnectionSlack FromCreateFlowsVaultConnectionSlackWebhook(
        Auth0.ManagementApi.CreateFlowsVaultConnectionSlackWebhook value
    ) => new("createFlowsVaultConnectionSlackWebhook", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionSlackOauthCode value.
    /// </summary>
    public static CreateFlowsVaultConnectionSlack FromCreateFlowsVaultConnectionSlackOauthCode(
        Auth0.ManagementApi.CreateFlowsVaultConnectionSlackOauthCode value
    ) => new("createFlowsVaultConnectionSlackOauthCode", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionSlackUninitialized value.
    /// </summary>
    public static CreateFlowsVaultConnectionSlack FromCreateFlowsVaultConnectionSlackUninitialized(
        Auth0.ManagementApi.CreateFlowsVaultConnectionSlackUninitialized value
    ) => new("createFlowsVaultConnectionSlackUninitialized", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionSlackWebhook"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionSlackWebhook() =>
        Type == "createFlowsVaultConnectionSlackWebhook";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionSlackOauthCode"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionSlackOauthCode() =>
        Type == "createFlowsVaultConnectionSlackOauthCode";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionSlackUninitialized"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionSlackUninitialized() =>
        Type == "createFlowsVaultConnectionSlackUninitialized";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionSlackWebhook"/> if <see cref="Type"/> is 'createFlowsVaultConnectionSlackWebhook', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionSlackWebhook'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionSlackWebhook AsCreateFlowsVaultConnectionSlackWebhook() =>
        IsCreateFlowsVaultConnectionSlackWebhook()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionSlackWebhook)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionSlackWebhook'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionSlackOauthCode"/> if <see cref="Type"/> is 'createFlowsVaultConnectionSlackOauthCode', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionSlackOauthCode'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionSlackOauthCode AsCreateFlowsVaultConnectionSlackOauthCode() =>
        IsCreateFlowsVaultConnectionSlackOauthCode()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionSlackOauthCode)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionSlackOauthCode'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionSlackUninitialized"/> if <see cref="Type"/> is 'createFlowsVaultConnectionSlackUninitialized', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionSlackUninitialized'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionSlackUninitialized AsCreateFlowsVaultConnectionSlackUninitialized() =>
        IsCreateFlowsVaultConnectionSlackUninitialized()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionSlackUninitialized)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionSlackUninitialized'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionSlackWebhook"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionSlackWebhook(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionSlackWebhook? value
    )
    {
        if (Type == "createFlowsVaultConnectionSlackWebhook")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionSlackWebhook)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionSlackOauthCode"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionSlackOauthCode(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionSlackOauthCode? value
    )
    {
        if (Type == "createFlowsVaultConnectionSlackOauthCode")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionSlackOauthCode)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionSlackUninitialized"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionSlackUninitialized(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionSlackUninitialized? value
    )
    {
        if (Type == "createFlowsVaultConnectionSlackUninitialized")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionSlackUninitialized)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionSlackWebhook,
            T
        > onCreateFlowsVaultConnectionSlackWebhook,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionSlackOauthCode,
            T
        > onCreateFlowsVaultConnectionSlackOauthCode,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionSlackUninitialized,
            T
        > onCreateFlowsVaultConnectionSlackUninitialized
    )
    {
        return Type switch
        {
            "createFlowsVaultConnectionSlackWebhook" => onCreateFlowsVaultConnectionSlackWebhook(
                AsCreateFlowsVaultConnectionSlackWebhook()
            ),
            "createFlowsVaultConnectionSlackOauthCode" =>
                onCreateFlowsVaultConnectionSlackOauthCode(
                    AsCreateFlowsVaultConnectionSlackOauthCode()
                ),
            "createFlowsVaultConnectionSlackUninitialized" =>
                onCreateFlowsVaultConnectionSlackUninitialized(
                    AsCreateFlowsVaultConnectionSlackUninitialized()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionSlackWebhook> onCreateFlowsVaultConnectionSlackWebhook,
        System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionSlackOauthCode> onCreateFlowsVaultConnectionSlackOauthCode,
        System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionSlackUninitialized> onCreateFlowsVaultConnectionSlackUninitialized
    )
    {
        switch (Type)
        {
            case "createFlowsVaultConnectionSlackWebhook":
                onCreateFlowsVaultConnectionSlackWebhook(
                    AsCreateFlowsVaultConnectionSlackWebhook()
                );
                break;
            case "createFlowsVaultConnectionSlackOauthCode":
                onCreateFlowsVaultConnectionSlackOauthCode(
                    AsCreateFlowsVaultConnectionSlackOauthCode()
                );
                break;
            case "createFlowsVaultConnectionSlackUninitialized":
                onCreateFlowsVaultConnectionSlackUninitialized(
                    AsCreateFlowsVaultConnectionSlackUninitialized()
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
        if (obj is not CreateFlowsVaultConnectionSlack other)
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

    public static implicit operator CreateFlowsVaultConnectionSlack(
        Auth0.ManagementApi.CreateFlowsVaultConnectionSlackWebhook value
    ) => new("createFlowsVaultConnectionSlackWebhook", value);

    public static implicit operator CreateFlowsVaultConnectionSlack(
        Auth0.ManagementApi.CreateFlowsVaultConnectionSlackOauthCode value
    ) => new("createFlowsVaultConnectionSlackOauthCode", value);

    public static implicit operator CreateFlowsVaultConnectionSlack(
        Auth0.ManagementApi.CreateFlowsVaultConnectionSlackUninitialized value
    ) => new("createFlowsVaultConnectionSlackUninitialized", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CreateFlowsVaultConnectionSlack>
    {
        public override CreateFlowsVaultConnectionSlack? Read(
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
                        "createFlowsVaultConnectionSlackWebhook",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionSlackWebhook)
                    ),
                    (
                        "createFlowsVaultConnectionSlackOauthCode",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionSlackOauthCode)
                    ),
                    (
                        "createFlowsVaultConnectionSlackUninitialized",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionSlackUninitialized)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            CreateFlowsVaultConnectionSlack result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into CreateFlowsVaultConnectionSlack"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateFlowsVaultConnectionSlack value,
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

        public override CreateFlowsVaultConnectionSlack ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            CreateFlowsVaultConnectionSlack result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateFlowsVaultConnectionSlack value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
