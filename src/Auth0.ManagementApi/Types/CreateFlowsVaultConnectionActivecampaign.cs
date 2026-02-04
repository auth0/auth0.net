// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(CreateFlowsVaultConnectionActivecampaign.JsonConverter))]
[Serializable]
public class CreateFlowsVaultConnectionActivecampaign
{
    private CreateFlowsVaultConnectionActivecampaign(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionActivecampaignApiKey value.
    /// </summary>
    public static CreateFlowsVaultConnectionActivecampaign FromCreateFlowsVaultConnectionActivecampaignApiKey(
        Auth0.ManagementApi.CreateFlowsVaultConnectionActivecampaignApiKey value
    ) => new("createFlowsVaultConnectionActivecampaignApiKey", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionActivecampaignUninitialized value.
    /// </summary>
    public static CreateFlowsVaultConnectionActivecampaign FromCreateFlowsVaultConnectionActivecampaignUninitialized(
        Auth0.ManagementApi.CreateFlowsVaultConnectionActivecampaignUninitialized value
    ) => new("createFlowsVaultConnectionActivecampaignUninitialized", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionActivecampaignApiKey"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionActivecampaignApiKey() =>
        Type == "createFlowsVaultConnectionActivecampaignApiKey";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionActivecampaignUninitialized"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionActivecampaignUninitialized() =>
        Type == "createFlowsVaultConnectionActivecampaignUninitialized";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionActivecampaignApiKey"/> if <see cref="Type"/> is 'createFlowsVaultConnectionActivecampaignApiKey', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionActivecampaignApiKey'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionActivecampaignApiKey AsCreateFlowsVaultConnectionActivecampaignApiKey() =>
        IsCreateFlowsVaultConnectionActivecampaignApiKey()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionActivecampaignApiKey)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionActivecampaignApiKey'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionActivecampaignUninitialized"/> if <see cref="Type"/> is 'createFlowsVaultConnectionActivecampaignUninitialized', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionActivecampaignUninitialized'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionActivecampaignUninitialized AsCreateFlowsVaultConnectionActivecampaignUninitialized() =>
        IsCreateFlowsVaultConnectionActivecampaignUninitialized()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionActivecampaignUninitialized)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionActivecampaignUninitialized'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionActivecampaignApiKey"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionActivecampaignApiKey(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionActivecampaignApiKey? value
    )
    {
        if (Type == "createFlowsVaultConnectionActivecampaignApiKey")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionActivecampaignApiKey)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionActivecampaignUninitialized"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionActivecampaignUninitialized(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionActivecampaignUninitialized? value
    )
    {
        if (Type == "createFlowsVaultConnectionActivecampaignUninitialized")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionActivecampaignUninitialized)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionActivecampaignApiKey,
            T
        > onCreateFlowsVaultConnectionActivecampaignApiKey,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionActivecampaignUninitialized,
            T
        > onCreateFlowsVaultConnectionActivecampaignUninitialized
    )
    {
        return Type switch
        {
            "createFlowsVaultConnectionActivecampaignApiKey" =>
                onCreateFlowsVaultConnectionActivecampaignApiKey(
                    AsCreateFlowsVaultConnectionActivecampaignApiKey()
                ),
            "createFlowsVaultConnectionActivecampaignUninitialized" =>
                onCreateFlowsVaultConnectionActivecampaignUninitialized(
                    AsCreateFlowsVaultConnectionActivecampaignUninitialized()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionActivecampaignApiKey> onCreateFlowsVaultConnectionActivecampaignApiKey,
        System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionActivecampaignUninitialized> onCreateFlowsVaultConnectionActivecampaignUninitialized
    )
    {
        switch (Type)
        {
            case "createFlowsVaultConnectionActivecampaignApiKey":
                onCreateFlowsVaultConnectionActivecampaignApiKey(
                    AsCreateFlowsVaultConnectionActivecampaignApiKey()
                );
                break;
            case "createFlowsVaultConnectionActivecampaignUninitialized":
                onCreateFlowsVaultConnectionActivecampaignUninitialized(
                    AsCreateFlowsVaultConnectionActivecampaignUninitialized()
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
        if (obj is not CreateFlowsVaultConnectionActivecampaign other)
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

    public static implicit operator CreateFlowsVaultConnectionActivecampaign(
        Auth0.ManagementApi.CreateFlowsVaultConnectionActivecampaignApiKey value
    ) => new("createFlowsVaultConnectionActivecampaignApiKey", value);

    public static implicit operator CreateFlowsVaultConnectionActivecampaign(
        Auth0.ManagementApi.CreateFlowsVaultConnectionActivecampaignUninitialized value
    ) => new("createFlowsVaultConnectionActivecampaignUninitialized", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CreateFlowsVaultConnectionActivecampaign>
    {
        public override CreateFlowsVaultConnectionActivecampaign? Read(
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
                        "createFlowsVaultConnectionActivecampaignApiKey",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionActivecampaignApiKey)
                    ),
                    (
                        "createFlowsVaultConnectionActivecampaignUninitialized",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionActivecampaignUninitialized)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            CreateFlowsVaultConnectionActivecampaign result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into CreateFlowsVaultConnectionActivecampaign"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateFlowsVaultConnectionActivecampaign value,
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

        public override CreateFlowsVaultConnectionActivecampaign ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            CreateFlowsVaultConnectionActivecampaign result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateFlowsVaultConnectionActivecampaign value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
