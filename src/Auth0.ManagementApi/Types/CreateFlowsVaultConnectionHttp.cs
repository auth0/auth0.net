// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(CreateFlowsVaultConnectionHttp.JsonConverter))]
[Serializable]
public class CreateFlowsVaultConnectionHttp
{
    private CreateFlowsVaultConnectionHttp(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionHttpBearer value.
    /// </summary>
    public static CreateFlowsVaultConnectionHttp FromCreateFlowsVaultConnectionHttpBearer(
        Auth0.ManagementApi.CreateFlowsVaultConnectionHttpBearer value
    ) => new("createFlowsVaultConnectionHttpBearer", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionHttpBasicAuth value.
    /// </summary>
    public static CreateFlowsVaultConnectionHttp FromCreateFlowsVaultConnectionHttpBasicAuth(
        Auth0.ManagementApi.CreateFlowsVaultConnectionHttpBasicAuth value
    ) => new("createFlowsVaultConnectionHttpBasicAuth", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionHttpApiKey value.
    /// </summary>
    public static CreateFlowsVaultConnectionHttp FromCreateFlowsVaultConnectionHttpApiKey(
        Auth0.ManagementApi.CreateFlowsVaultConnectionHttpApiKey value
    ) => new("createFlowsVaultConnectionHttpApiKey", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionHttpOauthClientCredentials value.
    /// </summary>
    public static CreateFlowsVaultConnectionHttp FromCreateFlowsVaultConnectionHttpOauthClientCredentials(
        Auth0.ManagementApi.CreateFlowsVaultConnectionHttpOauthClientCredentials value
    ) => new("createFlowsVaultConnectionHttpOauthClientCredentials", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionHttpUninitialized value.
    /// </summary>
    public static CreateFlowsVaultConnectionHttp FromCreateFlowsVaultConnectionHttpUninitialized(
        Auth0.ManagementApi.CreateFlowsVaultConnectionHttpUninitialized value
    ) => new("createFlowsVaultConnectionHttpUninitialized", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionHttpBearer"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionHttpBearer() =>
        Type == "createFlowsVaultConnectionHttpBearer";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionHttpBasicAuth"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionHttpBasicAuth() =>
        Type == "createFlowsVaultConnectionHttpBasicAuth";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionHttpApiKey"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionHttpApiKey() =>
        Type == "createFlowsVaultConnectionHttpApiKey";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionHttpOauthClientCredentials"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionHttpOauthClientCredentials() =>
        Type == "createFlowsVaultConnectionHttpOauthClientCredentials";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionHttpUninitialized"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionHttpUninitialized() =>
        Type == "createFlowsVaultConnectionHttpUninitialized";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionHttpBearer"/> if <see cref="Type"/> is 'createFlowsVaultConnectionHttpBearer', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionHttpBearer'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionHttpBearer AsCreateFlowsVaultConnectionHttpBearer() =>
        IsCreateFlowsVaultConnectionHttpBearer()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionHttpBearer)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionHttpBearer'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionHttpBasicAuth"/> if <see cref="Type"/> is 'createFlowsVaultConnectionHttpBasicAuth', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionHttpBasicAuth'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionHttpBasicAuth AsCreateFlowsVaultConnectionHttpBasicAuth() =>
        IsCreateFlowsVaultConnectionHttpBasicAuth()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionHttpBasicAuth)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionHttpBasicAuth'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionHttpApiKey"/> if <see cref="Type"/> is 'createFlowsVaultConnectionHttpApiKey', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionHttpApiKey'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionHttpApiKey AsCreateFlowsVaultConnectionHttpApiKey() =>
        IsCreateFlowsVaultConnectionHttpApiKey()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionHttpApiKey)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionHttpApiKey'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionHttpOauthClientCredentials"/> if <see cref="Type"/> is 'createFlowsVaultConnectionHttpOauthClientCredentials', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionHttpOauthClientCredentials'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionHttpOauthClientCredentials AsCreateFlowsVaultConnectionHttpOauthClientCredentials() =>
        IsCreateFlowsVaultConnectionHttpOauthClientCredentials()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionHttpOauthClientCredentials)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionHttpOauthClientCredentials'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionHttpUninitialized"/> if <see cref="Type"/> is 'createFlowsVaultConnectionHttpUninitialized', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionHttpUninitialized'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionHttpUninitialized AsCreateFlowsVaultConnectionHttpUninitialized() =>
        IsCreateFlowsVaultConnectionHttpUninitialized()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionHttpUninitialized)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionHttpUninitialized'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionHttpBearer"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionHttpBearer(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionHttpBearer? value
    )
    {
        if (Type == "createFlowsVaultConnectionHttpBearer")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionHttpBearer)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionHttpBasicAuth"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionHttpBasicAuth(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionHttpBasicAuth? value
    )
    {
        if (Type == "createFlowsVaultConnectionHttpBasicAuth")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionHttpBasicAuth)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionHttpApiKey"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionHttpApiKey(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionHttpApiKey? value
    )
    {
        if (Type == "createFlowsVaultConnectionHttpApiKey")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionHttpApiKey)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionHttpOauthClientCredentials"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionHttpOauthClientCredentials(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionHttpOauthClientCredentials? value
    )
    {
        if (Type == "createFlowsVaultConnectionHttpOauthClientCredentials")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionHttpOauthClientCredentials)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionHttpUninitialized"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionHttpUninitialized(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionHttpUninitialized? value
    )
    {
        if (Type == "createFlowsVaultConnectionHttpUninitialized")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionHttpUninitialized)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionHttpBearer,
            T
        > onCreateFlowsVaultConnectionHttpBearer,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionHttpBasicAuth,
            T
        > onCreateFlowsVaultConnectionHttpBasicAuth,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionHttpApiKey,
            T
        > onCreateFlowsVaultConnectionHttpApiKey,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionHttpOauthClientCredentials,
            T
        > onCreateFlowsVaultConnectionHttpOauthClientCredentials,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionHttpUninitialized,
            T
        > onCreateFlowsVaultConnectionHttpUninitialized
    )
    {
        return Type switch
        {
            "createFlowsVaultConnectionHttpBearer" => onCreateFlowsVaultConnectionHttpBearer(
                AsCreateFlowsVaultConnectionHttpBearer()
            ),
            "createFlowsVaultConnectionHttpBasicAuth" => onCreateFlowsVaultConnectionHttpBasicAuth(
                AsCreateFlowsVaultConnectionHttpBasicAuth()
            ),
            "createFlowsVaultConnectionHttpApiKey" => onCreateFlowsVaultConnectionHttpApiKey(
                AsCreateFlowsVaultConnectionHttpApiKey()
            ),
            "createFlowsVaultConnectionHttpOauthClientCredentials" =>
                onCreateFlowsVaultConnectionHttpOauthClientCredentials(
                    AsCreateFlowsVaultConnectionHttpOauthClientCredentials()
                ),
            "createFlowsVaultConnectionHttpUninitialized" =>
                onCreateFlowsVaultConnectionHttpUninitialized(
                    AsCreateFlowsVaultConnectionHttpUninitialized()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionHttpBearer> onCreateFlowsVaultConnectionHttpBearer,
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionHttpBasicAuth> onCreateFlowsVaultConnectionHttpBasicAuth,
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionHttpApiKey> onCreateFlowsVaultConnectionHttpApiKey,
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionHttpOauthClientCredentials> onCreateFlowsVaultConnectionHttpOauthClientCredentials,
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionHttpUninitialized> onCreateFlowsVaultConnectionHttpUninitialized
    )
    {
        switch (Type)
        {
            case "createFlowsVaultConnectionHttpBearer":
                onCreateFlowsVaultConnectionHttpBearer(AsCreateFlowsVaultConnectionHttpBearer());
                break;
            case "createFlowsVaultConnectionHttpBasicAuth":
                onCreateFlowsVaultConnectionHttpBasicAuth(
                    AsCreateFlowsVaultConnectionHttpBasicAuth()
                );
                break;
            case "createFlowsVaultConnectionHttpApiKey":
                onCreateFlowsVaultConnectionHttpApiKey(AsCreateFlowsVaultConnectionHttpApiKey());
                break;
            case "createFlowsVaultConnectionHttpOauthClientCredentials":
                onCreateFlowsVaultConnectionHttpOauthClientCredentials(
                    AsCreateFlowsVaultConnectionHttpOauthClientCredentials()
                );
                break;
            case "createFlowsVaultConnectionHttpUninitialized":
                onCreateFlowsVaultConnectionHttpUninitialized(
                    AsCreateFlowsVaultConnectionHttpUninitialized()
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
        if (obj is not CreateFlowsVaultConnectionHttp other)
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

    public static implicit operator CreateFlowsVaultConnectionHttp(
        Auth0.ManagementApi.CreateFlowsVaultConnectionHttpBearer value
    ) => new("createFlowsVaultConnectionHttpBearer", value);

    public static implicit operator CreateFlowsVaultConnectionHttp(
        Auth0.ManagementApi.CreateFlowsVaultConnectionHttpBasicAuth value
    ) => new("createFlowsVaultConnectionHttpBasicAuth", value);

    public static implicit operator CreateFlowsVaultConnectionHttp(
        Auth0.ManagementApi.CreateFlowsVaultConnectionHttpApiKey value
    ) => new("createFlowsVaultConnectionHttpApiKey", value);

    public static implicit operator CreateFlowsVaultConnectionHttp(
        Auth0.ManagementApi.CreateFlowsVaultConnectionHttpOauthClientCredentials value
    ) => new("createFlowsVaultConnectionHttpOauthClientCredentials", value);

    public static implicit operator CreateFlowsVaultConnectionHttp(
        Auth0.ManagementApi.CreateFlowsVaultConnectionHttpUninitialized value
    ) => new("createFlowsVaultConnectionHttpUninitialized", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CreateFlowsVaultConnectionHttp>
    {
        public override CreateFlowsVaultConnectionHttp? Read(
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
                        "createFlowsVaultConnectionHttpBearer",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionHttpBearer)
                    ),
                    (
                        "createFlowsVaultConnectionHttpBasicAuth",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionHttpBasicAuth)
                    ),
                    (
                        "createFlowsVaultConnectionHttpApiKey",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionHttpApiKey)
                    ),
                    (
                        "createFlowsVaultConnectionHttpOauthClientCredentials",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionHttpOauthClientCredentials)
                    ),
                    (
                        "createFlowsVaultConnectionHttpUninitialized",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionHttpUninitialized)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            CreateFlowsVaultConnectionHttp result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into CreateFlowsVaultConnectionHttp"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateFlowsVaultConnectionHttp value,
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
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override CreateFlowsVaultConnectionHttp ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            CreateFlowsVaultConnectionHttp result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateFlowsVaultConnectionHttp value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
