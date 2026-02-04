// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(CreateFlowsVaultConnectionTwilio.JsonConverter))]
[Serializable]
public class CreateFlowsVaultConnectionTwilio
{
    private CreateFlowsVaultConnectionTwilio(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionTwilioApiKey value.
    /// </summary>
    public static CreateFlowsVaultConnectionTwilio FromCreateFlowsVaultConnectionTwilioApiKey(
        Auth0.ManagementApi.CreateFlowsVaultConnectionTwilioApiKey value
    ) => new("createFlowsVaultConnectionTwilioApiKey", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionTwilioUninitialized value.
    /// </summary>
    public static CreateFlowsVaultConnectionTwilio FromCreateFlowsVaultConnectionTwilioUninitialized(
        Auth0.ManagementApi.CreateFlowsVaultConnectionTwilioUninitialized value
    ) => new("createFlowsVaultConnectionTwilioUninitialized", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionTwilioApiKey"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionTwilioApiKey() =>
        Type == "createFlowsVaultConnectionTwilioApiKey";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionTwilioUninitialized"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionTwilioUninitialized() =>
        Type == "createFlowsVaultConnectionTwilioUninitialized";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionTwilioApiKey"/> if <see cref="Type"/> is 'createFlowsVaultConnectionTwilioApiKey', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionTwilioApiKey'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionTwilioApiKey AsCreateFlowsVaultConnectionTwilioApiKey() =>
        IsCreateFlowsVaultConnectionTwilioApiKey()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionTwilioApiKey)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionTwilioApiKey'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionTwilioUninitialized"/> if <see cref="Type"/> is 'createFlowsVaultConnectionTwilioUninitialized', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionTwilioUninitialized'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionTwilioUninitialized AsCreateFlowsVaultConnectionTwilioUninitialized() =>
        IsCreateFlowsVaultConnectionTwilioUninitialized()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionTwilioUninitialized)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionTwilioUninitialized'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionTwilioApiKey"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionTwilioApiKey(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionTwilioApiKey? value
    )
    {
        if (Type == "createFlowsVaultConnectionTwilioApiKey")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionTwilioApiKey)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionTwilioUninitialized"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionTwilioUninitialized(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionTwilioUninitialized? value
    )
    {
        if (Type == "createFlowsVaultConnectionTwilioUninitialized")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionTwilioUninitialized)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionTwilioApiKey,
            T
        > onCreateFlowsVaultConnectionTwilioApiKey,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionTwilioUninitialized,
            T
        > onCreateFlowsVaultConnectionTwilioUninitialized
    )
    {
        return Type switch
        {
            "createFlowsVaultConnectionTwilioApiKey" => onCreateFlowsVaultConnectionTwilioApiKey(
                AsCreateFlowsVaultConnectionTwilioApiKey()
            ),
            "createFlowsVaultConnectionTwilioUninitialized" =>
                onCreateFlowsVaultConnectionTwilioUninitialized(
                    AsCreateFlowsVaultConnectionTwilioUninitialized()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionTwilioApiKey> onCreateFlowsVaultConnectionTwilioApiKey,
        System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionTwilioUninitialized> onCreateFlowsVaultConnectionTwilioUninitialized
    )
    {
        switch (Type)
        {
            case "createFlowsVaultConnectionTwilioApiKey":
                onCreateFlowsVaultConnectionTwilioApiKey(
                    AsCreateFlowsVaultConnectionTwilioApiKey()
                );
                break;
            case "createFlowsVaultConnectionTwilioUninitialized":
                onCreateFlowsVaultConnectionTwilioUninitialized(
                    AsCreateFlowsVaultConnectionTwilioUninitialized()
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
        if (obj is not CreateFlowsVaultConnectionTwilio other)
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

    public static implicit operator CreateFlowsVaultConnectionTwilio(
        Auth0.ManagementApi.CreateFlowsVaultConnectionTwilioApiKey value
    ) => new("createFlowsVaultConnectionTwilioApiKey", value);

    public static implicit operator CreateFlowsVaultConnectionTwilio(
        Auth0.ManagementApi.CreateFlowsVaultConnectionTwilioUninitialized value
    ) => new("createFlowsVaultConnectionTwilioUninitialized", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CreateFlowsVaultConnectionTwilio>
    {
        public override CreateFlowsVaultConnectionTwilio? Read(
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
                        "createFlowsVaultConnectionTwilioApiKey",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionTwilioApiKey)
                    ),
                    (
                        "createFlowsVaultConnectionTwilioUninitialized",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionTwilioUninitialized)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            CreateFlowsVaultConnectionTwilio result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into CreateFlowsVaultConnectionTwilio"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateFlowsVaultConnectionTwilio value,
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

        public override CreateFlowsVaultConnectionTwilio ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            CreateFlowsVaultConnectionTwilio result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateFlowsVaultConnectionTwilio value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
