// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(CreateFlowsVaultConnectionMailjet.JsonConverter))]
[Serializable]
public class CreateFlowsVaultConnectionMailjet
{
    private CreateFlowsVaultConnectionMailjet(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionMailjetApiKey value.
    /// </summary>
    public static CreateFlowsVaultConnectionMailjet FromCreateFlowsVaultConnectionMailjetApiKey(
        Auth0.ManagementApi.CreateFlowsVaultConnectionMailjetApiKey value
    ) => new("createFlowsVaultConnectionMailjetApiKey", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionMailjetUninitialized value.
    /// </summary>
    public static CreateFlowsVaultConnectionMailjet FromCreateFlowsVaultConnectionMailjetUninitialized(
        Auth0.ManagementApi.CreateFlowsVaultConnectionMailjetUninitialized value
    ) => new("createFlowsVaultConnectionMailjetUninitialized", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionMailjetApiKey"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionMailjetApiKey() =>
        Type == "createFlowsVaultConnectionMailjetApiKey";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionMailjetUninitialized"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionMailjetUninitialized() =>
        Type == "createFlowsVaultConnectionMailjetUninitialized";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionMailjetApiKey"/> if <see cref="Type"/> is 'createFlowsVaultConnectionMailjetApiKey', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionMailjetApiKey'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionMailjetApiKey AsCreateFlowsVaultConnectionMailjetApiKey() =>
        IsCreateFlowsVaultConnectionMailjetApiKey()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionMailjetApiKey)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionMailjetApiKey'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionMailjetUninitialized"/> if <see cref="Type"/> is 'createFlowsVaultConnectionMailjetUninitialized', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionMailjetUninitialized'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionMailjetUninitialized AsCreateFlowsVaultConnectionMailjetUninitialized() =>
        IsCreateFlowsVaultConnectionMailjetUninitialized()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionMailjetUninitialized)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionMailjetUninitialized'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionMailjetApiKey"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionMailjetApiKey(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionMailjetApiKey? value
    )
    {
        if (Type == "createFlowsVaultConnectionMailjetApiKey")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionMailjetApiKey)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionMailjetUninitialized"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionMailjetUninitialized(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionMailjetUninitialized? value
    )
    {
        if (Type == "createFlowsVaultConnectionMailjetUninitialized")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionMailjetUninitialized)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionMailjetApiKey,
            T
        > onCreateFlowsVaultConnectionMailjetApiKey,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionMailjetUninitialized,
            T
        > onCreateFlowsVaultConnectionMailjetUninitialized
    )
    {
        return Type switch
        {
            "createFlowsVaultConnectionMailjetApiKey" => onCreateFlowsVaultConnectionMailjetApiKey(
                AsCreateFlowsVaultConnectionMailjetApiKey()
            ),
            "createFlowsVaultConnectionMailjetUninitialized" =>
                onCreateFlowsVaultConnectionMailjetUninitialized(
                    AsCreateFlowsVaultConnectionMailjetUninitialized()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionMailjetApiKey> onCreateFlowsVaultConnectionMailjetApiKey,
        System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionMailjetUninitialized> onCreateFlowsVaultConnectionMailjetUninitialized
    )
    {
        switch (Type)
        {
            case "createFlowsVaultConnectionMailjetApiKey":
                onCreateFlowsVaultConnectionMailjetApiKey(
                    AsCreateFlowsVaultConnectionMailjetApiKey()
                );
                break;
            case "createFlowsVaultConnectionMailjetUninitialized":
                onCreateFlowsVaultConnectionMailjetUninitialized(
                    AsCreateFlowsVaultConnectionMailjetUninitialized()
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
        if (obj is not CreateFlowsVaultConnectionMailjet other)
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

    public static implicit operator CreateFlowsVaultConnectionMailjet(
        Auth0.ManagementApi.CreateFlowsVaultConnectionMailjetApiKey value
    ) => new("createFlowsVaultConnectionMailjetApiKey", value);

    public static implicit operator CreateFlowsVaultConnectionMailjet(
        Auth0.ManagementApi.CreateFlowsVaultConnectionMailjetUninitialized value
    ) => new("createFlowsVaultConnectionMailjetUninitialized", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CreateFlowsVaultConnectionMailjet>
    {
        public override CreateFlowsVaultConnectionMailjet? Read(
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
                        "createFlowsVaultConnectionMailjetApiKey",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionMailjetApiKey)
                    ),
                    (
                        "createFlowsVaultConnectionMailjetUninitialized",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionMailjetUninitialized)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            CreateFlowsVaultConnectionMailjet result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into CreateFlowsVaultConnectionMailjet"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateFlowsVaultConnectionMailjet value,
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

        public override CreateFlowsVaultConnectionMailjet ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            CreateFlowsVaultConnectionMailjet result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateFlowsVaultConnectionMailjet value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
