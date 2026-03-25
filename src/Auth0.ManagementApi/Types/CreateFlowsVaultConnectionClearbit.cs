// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(CreateFlowsVaultConnectionClearbit.JsonConverter))]
[Serializable]
public class CreateFlowsVaultConnectionClearbit
{
    private CreateFlowsVaultConnectionClearbit(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionClearbitApiKey value.
    /// </summary>
    public static CreateFlowsVaultConnectionClearbit FromCreateFlowsVaultConnectionClearbitApiKey(
        Auth0.ManagementApi.CreateFlowsVaultConnectionClearbitApiKey value
    ) => new("createFlowsVaultConnectionClearbitApiKey", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionClearbitUninitialized value.
    /// </summary>
    public static CreateFlowsVaultConnectionClearbit FromCreateFlowsVaultConnectionClearbitUninitialized(
        Auth0.ManagementApi.CreateFlowsVaultConnectionClearbitUninitialized value
    ) => new("createFlowsVaultConnectionClearbitUninitialized", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionClearbitApiKey"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionClearbitApiKey() =>
        Type == "createFlowsVaultConnectionClearbitApiKey";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionClearbitUninitialized"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionClearbitUninitialized() =>
        Type == "createFlowsVaultConnectionClearbitUninitialized";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionClearbitApiKey"/> if <see cref="Type"/> is 'createFlowsVaultConnectionClearbitApiKey', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionClearbitApiKey'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionClearbitApiKey AsCreateFlowsVaultConnectionClearbitApiKey() =>
        IsCreateFlowsVaultConnectionClearbitApiKey()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionClearbitApiKey)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionClearbitApiKey'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionClearbitUninitialized"/> if <see cref="Type"/> is 'createFlowsVaultConnectionClearbitUninitialized', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionClearbitUninitialized'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionClearbitUninitialized AsCreateFlowsVaultConnectionClearbitUninitialized() =>
        IsCreateFlowsVaultConnectionClearbitUninitialized()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionClearbitUninitialized)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionClearbitUninitialized'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionClearbitApiKey"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionClearbitApiKey(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionClearbitApiKey? value
    )
    {
        if (Type == "createFlowsVaultConnectionClearbitApiKey")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionClearbitApiKey)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionClearbitUninitialized"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionClearbitUninitialized(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionClearbitUninitialized? value
    )
    {
        if (Type == "createFlowsVaultConnectionClearbitUninitialized")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionClearbitUninitialized)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionClearbitApiKey,
            T
        > onCreateFlowsVaultConnectionClearbitApiKey,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionClearbitUninitialized,
            T
        > onCreateFlowsVaultConnectionClearbitUninitialized
    )
    {
        return Type switch
        {
            "createFlowsVaultConnectionClearbitApiKey" =>
                onCreateFlowsVaultConnectionClearbitApiKey(
                    AsCreateFlowsVaultConnectionClearbitApiKey()
                ),
            "createFlowsVaultConnectionClearbitUninitialized" =>
                onCreateFlowsVaultConnectionClearbitUninitialized(
                    AsCreateFlowsVaultConnectionClearbitUninitialized()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionClearbitApiKey> onCreateFlowsVaultConnectionClearbitApiKey,
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionClearbitUninitialized> onCreateFlowsVaultConnectionClearbitUninitialized
    )
    {
        switch (Type)
        {
            case "createFlowsVaultConnectionClearbitApiKey":
                onCreateFlowsVaultConnectionClearbitApiKey(
                    AsCreateFlowsVaultConnectionClearbitApiKey()
                );
                break;
            case "createFlowsVaultConnectionClearbitUninitialized":
                onCreateFlowsVaultConnectionClearbitUninitialized(
                    AsCreateFlowsVaultConnectionClearbitUninitialized()
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
        if (obj is not CreateFlowsVaultConnectionClearbit other)
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

    public static implicit operator CreateFlowsVaultConnectionClearbit(
        Auth0.ManagementApi.CreateFlowsVaultConnectionClearbitApiKey value
    ) => new("createFlowsVaultConnectionClearbitApiKey", value);

    public static implicit operator CreateFlowsVaultConnectionClearbit(
        Auth0.ManagementApi.CreateFlowsVaultConnectionClearbitUninitialized value
    ) => new("createFlowsVaultConnectionClearbitUninitialized", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CreateFlowsVaultConnectionClearbit>
    {
        public override CreateFlowsVaultConnectionClearbit? Read(
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
                        "createFlowsVaultConnectionClearbitApiKey",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionClearbitApiKey)
                    ),
                    (
                        "createFlowsVaultConnectionClearbitUninitialized",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionClearbitUninitialized)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            CreateFlowsVaultConnectionClearbit result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into CreateFlowsVaultConnectionClearbit"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateFlowsVaultConnectionClearbit value,
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

        public override CreateFlowsVaultConnectionClearbit ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            CreateFlowsVaultConnectionClearbit result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateFlowsVaultConnectionClearbit value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
