// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(CreateFlowsVaultConnectionAirtable.JsonConverter))]
[Serializable]
public class CreateFlowsVaultConnectionAirtable
{
    private CreateFlowsVaultConnectionAirtable(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionAirtableApiKey value.
    /// </summary>
    public static CreateFlowsVaultConnectionAirtable FromCreateFlowsVaultConnectionAirtableApiKey(
        Auth0.ManagementApi.CreateFlowsVaultConnectionAirtableApiKey value
    ) => new("createFlowsVaultConnectionAirtableApiKey", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionAirtableUninitialized value.
    /// </summary>
    public static CreateFlowsVaultConnectionAirtable FromCreateFlowsVaultConnectionAirtableUninitialized(
        Auth0.ManagementApi.CreateFlowsVaultConnectionAirtableUninitialized value
    ) => new("createFlowsVaultConnectionAirtableUninitialized", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionAirtableApiKey"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionAirtableApiKey() =>
        Type == "createFlowsVaultConnectionAirtableApiKey";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionAirtableUninitialized"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionAirtableUninitialized() =>
        Type == "createFlowsVaultConnectionAirtableUninitialized";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionAirtableApiKey"/> if <see cref="Type"/> is 'createFlowsVaultConnectionAirtableApiKey', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionAirtableApiKey'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionAirtableApiKey AsCreateFlowsVaultConnectionAirtableApiKey() =>
        IsCreateFlowsVaultConnectionAirtableApiKey()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionAirtableApiKey)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionAirtableApiKey'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionAirtableUninitialized"/> if <see cref="Type"/> is 'createFlowsVaultConnectionAirtableUninitialized', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionAirtableUninitialized'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionAirtableUninitialized AsCreateFlowsVaultConnectionAirtableUninitialized() =>
        IsCreateFlowsVaultConnectionAirtableUninitialized()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionAirtableUninitialized)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionAirtableUninitialized'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionAirtableApiKey"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionAirtableApiKey(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionAirtableApiKey? value
    )
    {
        if (Type == "createFlowsVaultConnectionAirtableApiKey")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionAirtableApiKey)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionAirtableUninitialized"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionAirtableUninitialized(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionAirtableUninitialized? value
    )
    {
        if (Type == "createFlowsVaultConnectionAirtableUninitialized")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionAirtableUninitialized)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionAirtableApiKey,
            T
        > onCreateFlowsVaultConnectionAirtableApiKey,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionAirtableUninitialized,
            T
        > onCreateFlowsVaultConnectionAirtableUninitialized
    )
    {
        return Type switch
        {
            "createFlowsVaultConnectionAirtableApiKey" =>
                onCreateFlowsVaultConnectionAirtableApiKey(
                    AsCreateFlowsVaultConnectionAirtableApiKey()
                ),
            "createFlowsVaultConnectionAirtableUninitialized" =>
                onCreateFlowsVaultConnectionAirtableUninitialized(
                    AsCreateFlowsVaultConnectionAirtableUninitialized()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionAirtableApiKey> onCreateFlowsVaultConnectionAirtableApiKey,
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionAirtableUninitialized> onCreateFlowsVaultConnectionAirtableUninitialized
    )
    {
        switch (Type)
        {
            case "createFlowsVaultConnectionAirtableApiKey":
                onCreateFlowsVaultConnectionAirtableApiKey(
                    AsCreateFlowsVaultConnectionAirtableApiKey()
                );
                break;
            case "createFlowsVaultConnectionAirtableUninitialized":
                onCreateFlowsVaultConnectionAirtableUninitialized(
                    AsCreateFlowsVaultConnectionAirtableUninitialized()
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
        if (obj is not CreateFlowsVaultConnectionAirtable other)
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

    public static implicit operator CreateFlowsVaultConnectionAirtable(
        Auth0.ManagementApi.CreateFlowsVaultConnectionAirtableApiKey value
    ) => new("createFlowsVaultConnectionAirtableApiKey", value);

    public static implicit operator CreateFlowsVaultConnectionAirtable(
        Auth0.ManagementApi.CreateFlowsVaultConnectionAirtableUninitialized value
    ) => new("createFlowsVaultConnectionAirtableUninitialized", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CreateFlowsVaultConnectionAirtable>
    {
        public override CreateFlowsVaultConnectionAirtable? Read(
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
                        "createFlowsVaultConnectionAirtableApiKey",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionAirtableApiKey)
                    ),
                    (
                        "createFlowsVaultConnectionAirtableUninitialized",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionAirtableUninitialized)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            CreateFlowsVaultConnectionAirtable result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into CreateFlowsVaultConnectionAirtable"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateFlowsVaultConnectionAirtable value,
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

        public override CreateFlowsVaultConnectionAirtable ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            CreateFlowsVaultConnectionAirtable result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateFlowsVaultConnectionAirtable value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
