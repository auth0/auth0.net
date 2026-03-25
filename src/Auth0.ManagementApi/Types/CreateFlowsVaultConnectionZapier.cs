// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(CreateFlowsVaultConnectionZapier.JsonConverter))]
[Serializable]
public class CreateFlowsVaultConnectionZapier
{
    private CreateFlowsVaultConnectionZapier(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionZapierWebhook value.
    /// </summary>
    public static CreateFlowsVaultConnectionZapier FromCreateFlowsVaultConnectionZapierWebhook(
        Auth0.ManagementApi.CreateFlowsVaultConnectionZapierWebhook value
    ) => new("createFlowsVaultConnectionZapierWebhook", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionZapierUninitialized value.
    /// </summary>
    public static CreateFlowsVaultConnectionZapier FromCreateFlowsVaultConnectionZapierUninitialized(
        Auth0.ManagementApi.CreateFlowsVaultConnectionZapierUninitialized value
    ) => new("createFlowsVaultConnectionZapierUninitialized", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionZapierWebhook"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionZapierWebhook() =>
        Type == "createFlowsVaultConnectionZapierWebhook";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionZapierUninitialized"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionZapierUninitialized() =>
        Type == "createFlowsVaultConnectionZapierUninitialized";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionZapierWebhook"/> if <see cref="Type"/> is 'createFlowsVaultConnectionZapierWebhook', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionZapierWebhook'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionZapierWebhook AsCreateFlowsVaultConnectionZapierWebhook() =>
        IsCreateFlowsVaultConnectionZapierWebhook()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionZapierWebhook)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionZapierWebhook'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionZapierUninitialized"/> if <see cref="Type"/> is 'createFlowsVaultConnectionZapierUninitialized', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionZapierUninitialized'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionZapierUninitialized AsCreateFlowsVaultConnectionZapierUninitialized() =>
        IsCreateFlowsVaultConnectionZapierUninitialized()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionZapierUninitialized)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionZapierUninitialized'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionZapierWebhook"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionZapierWebhook(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionZapierWebhook? value
    )
    {
        if (Type == "createFlowsVaultConnectionZapierWebhook")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionZapierWebhook)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionZapierUninitialized"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionZapierUninitialized(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionZapierUninitialized? value
    )
    {
        if (Type == "createFlowsVaultConnectionZapierUninitialized")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionZapierUninitialized)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionZapierWebhook,
            T
        > onCreateFlowsVaultConnectionZapierWebhook,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionZapierUninitialized,
            T
        > onCreateFlowsVaultConnectionZapierUninitialized
    )
    {
        return Type switch
        {
            "createFlowsVaultConnectionZapierWebhook" => onCreateFlowsVaultConnectionZapierWebhook(
                AsCreateFlowsVaultConnectionZapierWebhook()
            ),
            "createFlowsVaultConnectionZapierUninitialized" =>
                onCreateFlowsVaultConnectionZapierUninitialized(
                    AsCreateFlowsVaultConnectionZapierUninitialized()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionZapierWebhook> onCreateFlowsVaultConnectionZapierWebhook,
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionZapierUninitialized> onCreateFlowsVaultConnectionZapierUninitialized
    )
    {
        switch (Type)
        {
            case "createFlowsVaultConnectionZapierWebhook":
                onCreateFlowsVaultConnectionZapierWebhook(
                    AsCreateFlowsVaultConnectionZapierWebhook()
                );
                break;
            case "createFlowsVaultConnectionZapierUninitialized":
                onCreateFlowsVaultConnectionZapierUninitialized(
                    AsCreateFlowsVaultConnectionZapierUninitialized()
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
        if (obj is not CreateFlowsVaultConnectionZapier other)
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

    public static implicit operator CreateFlowsVaultConnectionZapier(
        Auth0.ManagementApi.CreateFlowsVaultConnectionZapierWebhook value
    ) => new("createFlowsVaultConnectionZapierWebhook", value);

    public static implicit operator CreateFlowsVaultConnectionZapier(
        Auth0.ManagementApi.CreateFlowsVaultConnectionZapierUninitialized value
    ) => new("createFlowsVaultConnectionZapierUninitialized", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CreateFlowsVaultConnectionZapier>
    {
        public override CreateFlowsVaultConnectionZapier? Read(
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
                        "createFlowsVaultConnectionZapierWebhook",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionZapierWebhook)
                    ),
                    (
                        "createFlowsVaultConnectionZapierUninitialized",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionZapierUninitialized)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            CreateFlowsVaultConnectionZapier result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into CreateFlowsVaultConnectionZapier"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateFlowsVaultConnectionZapier value,
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

        public override CreateFlowsVaultConnectionZapier ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            CreateFlowsVaultConnectionZapier result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateFlowsVaultConnectionZapier value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
