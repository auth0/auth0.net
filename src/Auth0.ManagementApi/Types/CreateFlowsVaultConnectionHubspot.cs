// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(CreateFlowsVaultConnectionHubspot.JsonConverter))]
[Serializable]
public class CreateFlowsVaultConnectionHubspot
{
    private CreateFlowsVaultConnectionHubspot(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionHubspotApiKey value.
    /// </summary>
    public static CreateFlowsVaultConnectionHubspot FromCreateFlowsVaultConnectionHubspotApiKey(
        Auth0.ManagementApi.CreateFlowsVaultConnectionHubspotApiKey value
    ) => new("createFlowsVaultConnectionHubspotApiKey", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionHubspotOauthCode value.
    /// </summary>
    public static CreateFlowsVaultConnectionHubspot FromCreateFlowsVaultConnectionHubspotOauthCode(
        Auth0.ManagementApi.CreateFlowsVaultConnectionHubspotOauthCode value
    ) => new("createFlowsVaultConnectionHubspotOauthCode", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionHubspotUninitialized value.
    /// </summary>
    public static CreateFlowsVaultConnectionHubspot FromCreateFlowsVaultConnectionHubspotUninitialized(
        Auth0.ManagementApi.CreateFlowsVaultConnectionHubspotUninitialized value
    ) => new("createFlowsVaultConnectionHubspotUninitialized", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionHubspotApiKey"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionHubspotApiKey() =>
        Type == "createFlowsVaultConnectionHubspotApiKey";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionHubspotOauthCode"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionHubspotOauthCode() =>
        Type == "createFlowsVaultConnectionHubspotOauthCode";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionHubspotUninitialized"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionHubspotUninitialized() =>
        Type == "createFlowsVaultConnectionHubspotUninitialized";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionHubspotApiKey"/> if <see cref="Type"/> is 'createFlowsVaultConnectionHubspotApiKey', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionHubspotApiKey'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionHubspotApiKey AsCreateFlowsVaultConnectionHubspotApiKey() =>
        IsCreateFlowsVaultConnectionHubspotApiKey()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionHubspotApiKey)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionHubspotApiKey'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionHubspotOauthCode"/> if <see cref="Type"/> is 'createFlowsVaultConnectionHubspotOauthCode', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionHubspotOauthCode'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionHubspotOauthCode AsCreateFlowsVaultConnectionHubspotOauthCode() =>
        IsCreateFlowsVaultConnectionHubspotOauthCode()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionHubspotOauthCode)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionHubspotOauthCode'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionHubspotUninitialized"/> if <see cref="Type"/> is 'createFlowsVaultConnectionHubspotUninitialized', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionHubspotUninitialized'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionHubspotUninitialized AsCreateFlowsVaultConnectionHubspotUninitialized() =>
        IsCreateFlowsVaultConnectionHubspotUninitialized()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionHubspotUninitialized)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionHubspotUninitialized'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionHubspotApiKey"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionHubspotApiKey(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionHubspotApiKey? value
    )
    {
        if (Type == "createFlowsVaultConnectionHubspotApiKey")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionHubspotApiKey)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionHubspotOauthCode"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionHubspotOauthCode(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionHubspotOauthCode? value
    )
    {
        if (Type == "createFlowsVaultConnectionHubspotOauthCode")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionHubspotOauthCode)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionHubspotUninitialized"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionHubspotUninitialized(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionHubspotUninitialized? value
    )
    {
        if (Type == "createFlowsVaultConnectionHubspotUninitialized")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionHubspotUninitialized)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionHubspotApiKey,
            T
        > onCreateFlowsVaultConnectionHubspotApiKey,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionHubspotOauthCode,
            T
        > onCreateFlowsVaultConnectionHubspotOauthCode,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionHubspotUninitialized,
            T
        > onCreateFlowsVaultConnectionHubspotUninitialized
    )
    {
        return Type switch
        {
            "createFlowsVaultConnectionHubspotApiKey" => onCreateFlowsVaultConnectionHubspotApiKey(
                AsCreateFlowsVaultConnectionHubspotApiKey()
            ),
            "createFlowsVaultConnectionHubspotOauthCode" =>
                onCreateFlowsVaultConnectionHubspotOauthCode(
                    AsCreateFlowsVaultConnectionHubspotOauthCode()
                ),
            "createFlowsVaultConnectionHubspotUninitialized" =>
                onCreateFlowsVaultConnectionHubspotUninitialized(
                    AsCreateFlowsVaultConnectionHubspotUninitialized()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionHubspotApiKey> onCreateFlowsVaultConnectionHubspotApiKey,
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionHubspotOauthCode> onCreateFlowsVaultConnectionHubspotOauthCode,
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionHubspotUninitialized> onCreateFlowsVaultConnectionHubspotUninitialized
    )
    {
        switch (Type)
        {
            case "createFlowsVaultConnectionHubspotApiKey":
                onCreateFlowsVaultConnectionHubspotApiKey(
                    AsCreateFlowsVaultConnectionHubspotApiKey()
                );
                break;
            case "createFlowsVaultConnectionHubspotOauthCode":
                onCreateFlowsVaultConnectionHubspotOauthCode(
                    AsCreateFlowsVaultConnectionHubspotOauthCode()
                );
                break;
            case "createFlowsVaultConnectionHubspotUninitialized":
                onCreateFlowsVaultConnectionHubspotUninitialized(
                    AsCreateFlowsVaultConnectionHubspotUninitialized()
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
        if (obj is not CreateFlowsVaultConnectionHubspot other)
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

    public static implicit operator CreateFlowsVaultConnectionHubspot(
        Auth0.ManagementApi.CreateFlowsVaultConnectionHubspotApiKey value
    ) => new("createFlowsVaultConnectionHubspotApiKey", value);

    public static implicit operator CreateFlowsVaultConnectionHubspot(
        Auth0.ManagementApi.CreateFlowsVaultConnectionHubspotOauthCode value
    ) => new("createFlowsVaultConnectionHubspotOauthCode", value);

    public static implicit operator CreateFlowsVaultConnectionHubspot(
        Auth0.ManagementApi.CreateFlowsVaultConnectionHubspotUninitialized value
    ) => new("createFlowsVaultConnectionHubspotUninitialized", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CreateFlowsVaultConnectionHubspot>
    {
        public override CreateFlowsVaultConnectionHubspot? Read(
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
                        "createFlowsVaultConnectionHubspotApiKey",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionHubspotApiKey)
                    ),
                    (
                        "createFlowsVaultConnectionHubspotOauthCode",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionHubspotOauthCode)
                    ),
                    (
                        "createFlowsVaultConnectionHubspotUninitialized",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionHubspotUninitialized)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            CreateFlowsVaultConnectionHubspot result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into CreateFlowsVaultConnectionHubspot"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateFlowsVaultConnectionHubspot value,
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

        public override CreateFlowsVaultConnectionHubspot ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            CreateFlowsVaultConnectionHubspot result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateFlowsVaultConnectionHubspot value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
