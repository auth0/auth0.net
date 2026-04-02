// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Credentials required to use the provider.
/// </summary>
[JsonConverter(typeof(EmailProviderCredentialsSchema.JsonConverter))]
[Serializable]
public class EmailProviderCredentialsSchema
{
    private EmailProviderCredentialsSchema(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.EmailProviderCredentialsSchemaZero value.
    /// </summary>
    public static EmailProviderCredentialsSchema FromEmailProviderCredentialsSchemaZero(
        Auth0.ManagementApi.EmailProviderCredentialsSchemaZero value
    ) => new("emailProviderCredentialsSchemaZero", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EmailProviderCredentialsSchemaAccessKeyId value.
    /// </summary>
    public static EmailProviderCredentialsSchema FromEmailProviderCredentialsSchemaAccessKeyId(
        Auth0.ManagementApi.EmailProviderCredentialsSchemaAccessKeyId value
    ) => new("emailProviderCredentialsSchemaAccessKeyId", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EmailProviderCredentialsSchemaSmtpHost value.
    /// </summary>
    public static EmailProviderCredentialsSchema FromEmailProviderCredentialsSchemaSmtpHost(
        Auth0.ManagementApi.EmailProviderCredentialsSchemaSmtpHost value
    ) => new("emailProviderCredentialsSchemaSmtpHost", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EmailProviderCredentialsSchemaThree value.
    /// </summary>
    public static EmailProviderCredentialsSchema FromEmailProviderCredentialsSchemaThree(
        Auth0.ManagementApi.EmailProviderCredentialsSchemaThree value
    ) => new("emailProviderCredentialsSchemaThree", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EmailProviderCredentialsSchemaApiKey value.
    /// </summary>
    public static EmailProviderCredentialsSchema FromEmailProviderCredentialsSchemaApiKey(
        Auth0.ManagementApi.EmailProviderCredentialsSchemaApiKey value
    ) => new("emailProviderCredentialsSchemaApiKey", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EmailProviderCredentialsSchemaConnectionString value.
    /// </summary>
    public static EmailProviderCredentialsSchema FromEmailProviderCredentialsSchemaConnectionString(
        Auth0.ManagementApi.EmailProviderCredentialsSchemaConnectionString value
    ) => new("emailProviderCredentialsSchemaConnectionString", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.EmailProviderCredentialsSchemaClientId value.
    /// </summary>
    public static EmailProviderCredentialsSchema FromEmailProviderCredentialsSchemaClientId(
        Auth0.ManagementApi.EmailProviderCredentialsSchemaClientId value
    ) => new("emailProviderCredentialsSchemaClientId", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.ExtensibilityEmailProviderCredentials value.
    /// </summary>
    public static EmailProviderCredentialsSchema FromExtensibilityEmailProviderCredentials(
        Auth0.ManagementApi.ExtensibilityEmailProviderCredentials value
    ) => new("extensibilityEmailProviderCredentials", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "emailProviderCredentialsSchemaZero"
    /// </summary>
    public bool IsEmailProviderCredentialsSchemaZero() =>
        Type == "emailProviderCredentialsSchemaZero";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "emailProviderCredentialsSchemaAccessKeyId"
    /// </summary>
    public bool IsEmailProviderCredentialsSchemaAccessKeyId() =>
        Type == "emailProviderCredentialsSchemaAccessKeyId";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "emailProviderCredentialsSchemaSmtpHost"
    /// </summary>
    public bool IsEmailProviderCredentialsSchemaSmtpHost() =>
        Type == "emailProviderCredentialsSchemaSmtpHost";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "emailProviderCredentialsSchemaThree"
    /// </summary>
    public bool IsEmailProviderCredentialsSchemaThree() =>
        Type == "emailProviderCredentialsSchemaThree";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "emailProviderCredentialsSchemaApiKey"
    /// </summary>
    public bool IsEmailProviderCredentialsSchemaApiKey() =>
        Type == "emailProviderCredentialsSchemaApiKey";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "emailProviderCredentialsSchemaConnectionString"
    /// </summary>
    public bool IsEmailProviderCredentialsSchemaConnectionString() =>
        Type == "emailProviderCredentialsSchemaConnectionString";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "emailProviderCredentialsSchemaClientId"
    /// </summary>
    public bool IsEmailProviderCredentialsSchemaClientId() =>
        Type == "emailProviderCredentialsSchemaClientId";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "extensibilityEmailProviderCredentials"
    /// </summary>
    public bool IsExtensibilityEmailProviderCredentials() =>
        Type == "extensibilityEmailProviderCredentials";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EmailProviderCredentialsSchemaZero"/> if <see cref="Type"/> is 'emailProviderCredentialsSchemaZero', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'emailProviderCredentialsSchemaZero'.</exception>
    public Auth0.ManagementApi.EmailProviderCredentialsSchemaZero AsEmailProviderCredentialsSchemaZero() =>
        IsEmailProviderCredentialsSchemaZero()
            ? (Auth0.ManagementApi.EmailProviderCredentialsSchemaZero)Value!
            : throw new ManagementException(
                "Union type is not 'emailProviderCredentialsSchemaZero'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EmailProviderCredentialsSchemaAccessKeyId"/> if <see cref="Type"/> is 'emailProviderCredentialsSchemaAccessKeyId', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'emailProviderCredentialsSchemaAccessKeyId'.</exception>
    public Auth0.ManagementApi.EmailProviderCredentialsSchemaAccessKeyId AsEmailProviderCredentialsSchemaAccessKeyId() =>
        IsEmailProviderCredentialsSchemaAccessKeyId()
            ? (Auth0.ManagementApi.EmailProviderCredentialsSchemaAccessKeyId)Value!
            : throw new ManagementException(
                "Union type is not 'emailProviderCredentialsSchemaAccessKeyId'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EmailProviderCredentialsSchemaSmtpHost"/> if <see cref="Type"/> is 'emailProviderCredentialsSchemaSmtpHost', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'emailProviderCredentialsSchemaSmtpHost'.</exception>
    public Auth0.ManagementApi.EmailProviderCredentialsSchemaSmtpHost AsEmailProviderCredentialsSchemaSmtpHost() =>
        IsEmailProviderCredentialsSchemaSmtpHost()
            ? (Auth0.ManagementApi.EmailProviderCredentialsSchemaSmtpHost)Value!
            : throw new ManagementException(
                "Union type is not 'emailProviderCredentialsSchemaSmtpHost'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EmailProviderCredentialsSchemaThree"/> if <see cref="Type"/> is 'emailProviderCredentialsSchemaThree', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'emailProviderCredentialsSchemaThree'.</exception>
    public Auth0.ManagementApi.EmailProviderCredentialsSchemaThree AsEmailProviderCredentialsSchemaThree() =>
        IsEmailProviderCredentialsSchemaThree()
            ? (Auth0.ManagementApi.EmailProviderCredentialsSchemaThree)Value!
            : throw new ManagementException(
                "Union type is not 'emailProviderCredentialsSchemaThree'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EmailProviderCredentialsSchemaApiKey"/> if <see cref="Type"/> is 'emailProviderCredentialsSchemaApiKey', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'emailProviderCredentialsSchemaApiKey'.</exception>
    public Auth0.ManagementApi.EmailProviderCredentialsSchemaApiKey AsEmailProviderCredentialsSchemaApiKey() =>
        IsEmailProviderCredentialsSchemaApiKey()
            ? (Auth0.ManagementApi.EmailProviderCredentialsSchemaApiKey)Value!
            : throw new ManagementException(
                "Union type is not 'emailProviderCredentialsSchemaApiKey'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EmailProviderCredentialsSchemaConnectionString"/> if <see cref="Type"/> is 'emailProviderCredentialsSchemaConnectionString', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'emailProviderCredentialsSchemaConnectionString'.</exception>
    public Auth0.ManagementApi.EmailProviderCredentialsSchemaConnectionString AsEmailProviderCredentialsSchemaConnectionString() =>
        IsEmailProviderCredentialsSchemaConnectionString()
            ? (Auth0.ManagementApi.EmailProviderCredentialsSchemaConnectionString)Value!
            : throw new ManagementException(
                "Union type is not 'emailProviderCredentialsSchemaConnectionString'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.EmailProviderCredentialsSchemaClientId"/> if <see cref="Type"/> is 'emailProviderCredentialsSchemaClientId', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'emailProviderCredentialsSchemaClientId'.</exception>
    public Auth0.ManagementApi.EmailProviderCredentialsSchemaClientId AsEmailProviderCredentialsSchemaClientId() =>
        IsEmailProviderCredentialsSchemaClientId()
            ? (Auth0.ManagementApi.EmailProviderCredentialsSchemaClientId)Value!
            : throw new ManagementException(
                "Union type is not 'emailProviderCredentialsSchemaClientId'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.ExtensibilityEmailProviderCredentials"/> if <see cref="Type"/> is 'extensibilityEmailProviderCredentials', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'extensibilityEmailProviderCredentials'.</exception>
    public Auth0.ManagementApi.ExtensibilityEmailProviderCredentials AsExtensibilityEmailProviderCredentials() =>
        IsExtensibilityEmailProviderCredentials()
            ? (Auth0.ManagementApi.ExtensibilityEmailProviderCredentials)Value!
            : throw new ManagementException(
                "Union type is not 'extensibilityEmailProviderCredentials'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EmailProviderCredentialsSchemaZero"/> and returns true if successful.
    /// </summary>
    public bool TryGetEmailProviderCredentialsSchemaZero(
        out Auth0.ManagementApi.EmailProviderCredentialsSchemaZero? value
    )
    {
        if (Type == "emailProviderCredentialsSchemaZero")
        {
            value = (Auth0.ManagementApi.EmailProviderCredentialsSchemaZero)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EmailProviderCredentialsSchemaAccessKeyId"/> and returns true if successful.
    /// </summary>
    public bool TryGetEmailProviderCredentialsSchemaAccessKeyId(
        out Auth0.ManagementApi.EmailProviderCredentialsSchemaAccessKeyId? value
    )
    {
        if (Type == "emailProviderCredentialsSchemaAccessKeyId")
        {
            value = (Auth0.ManagementApi.EmailProviderCredentialsSchemaAccessKeyId)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EmailProviderCredentialsSchemaSmtpHost"/> and returns true if successful.
    /// </summary>
    public bool TryGetEmailProviderCredentialsSchemaSmtpHost(
        out Auth0.ManagementApi.EmailProviderCredentialsSchemaSmtpHost? value
    )
    {
        if (Type == "emailProviderCredentialsSchemaSmtpHost")
        {
            value = (Auth0.ManagementApi.EmailProviderCredentialsSchemaSmtpHost)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EmailProviderCredentialsSchemaThree"/> and returns true if successful.
    /// </summary>
    public bool TryGetEmailProviderCredentialsSchemaThree(
        out Auth0.ManagementApi.EmailProviderCredentialsSchemaThree? value
    )
    {
        if (Type == "emailProviderCredentialsSchemaThree")
        {
            value = (Auth0.ManagementApi.EmailProviderCredentialsSchemaThree)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EmailProviderCredentialsSchemaApiKey"/> and returns true if successful.
    /// </summary>
    public bool TryGetEmailProviderCredentialsSchemaApiKey(
        out Auth0.ManagementApi.EmailProviderCredentialsSchemaApiKey? value
    )
    {
        if (Type == "emailProviderCredentialsSchemaApiKey")
        {
            value = (Auth0.ManagementApi.EmailProviderCredentialsSchemaApiKey)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EmailProviderCredentialsSchemaConnectionString"/> and returns true if successful.
    /// </summary>
    public bool TryGetEmailProviderCredentialsSchemaConnectionString(
        out Auth0.ManagementApi.EmailProviderCredentialsSchemaConnectionString? value
    )
    {
        if (Type == "emailProviderCredentialsSchemaConnectionString")
        {
            value = (Auth0.ManagementApi.EmailProviderCredentialsSchemaConnectionString)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.EmailProviderCredentialsSchemaClientId"/> and returns true if successful.
    /// </summary>
    public bool TryGetEmailProviderCredentialsSchemaClientId(
        out Auth0.ManagementApi.EmailProviderCredentialsSchemaClientId? value
    )
    {
        if (Type == "emailProviderCredentialsSchemaClientId")
        {
            value = (Auth0.ManagementApi.EmailProviderCredentialsSchemaClientId)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.ExtensibilityEmailProviderCredentials"/> and returns true if successful.
    /// </summary>
    public bool TryGetExtensibilityEmailProviderCredentials(
        out Auth0.ManagementApi.ExtensibilityEmailProviderCredentials? value
    )
    {
        if (Type == "extensibilityEmailProviderCredentials")
        {
            value = (Auth0.ManagementApi.ExtensibilityEmailProviderCredentials)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.EmailProviderCredentialsSchemaZero,
            T
        > onEmailProviderCredentialsSchemaZero,
        Func<
            Auth0.ManagementApi.EmailProviderCredentialsSchemaAccessKeyId,
            T
        > onEmailProviderCredentialsSchemaAccessKeyId,
        Func<
            Auth0.ManagementApi.EmailProviderCredentialsSchemaSmtpHost,
            T
        > onEmailProviderCredentialsSchemaSmtpHost,
        Func<
            Auth0.ManagementApi.EmailProviderCredentialsSchemaThree,
            T
        > onEmailProviderCredentialsSchemaThree,
        Func<
            Auth0.ManagementApi.EmailProviderCredentialsSchemaApiKey,
            T
        > onEmailProviderCredentialsSchemaApiKey,
        Func<
            Auth0.ManagementApi.EmailProviderCredentialsSchemaConnectionString,
            T
        > onEmailProviderCredentialsSchemaConnectionString,
        Func<
            Auth0.ManagementApi.EmailProviderCredentialsSchemaClientId,
            T
        > onEmailProviderCredentialsSchemaClientId,
        Func<
            Auth0.ManagementApi.ExtensibilityEmailProviderCredentials,
            T
        > onExtensibilityEmailProviderCredentials
    )
    {
        return Type switch
        {
            "emailProviderCredentialsSchemaZero" => onEmailProviderCredentialsSchemaZero(
                AsEmailProviderCredentialsSchemaZero()
            ),
            "emailProviderCredentialsSchemaAccessKeyId" =>
                onEmailProviderCredentialsSchemaAccessKeyId(
                    AsEmailProviderCredentialsSchemaAccessKeyId()
                ),
            "emailProviderCredentialsSchemaSmtpHost" => onEmailProviderCredentialsSchemaSmtpHost(
                AsEmailProviderCredentialsSchemaSmtpHost()
            ),
            "emailProviderCredentialsSchemaThree" => onEmailProviderCredentialsSchemaThree(
                AsEmailProviderCredentialsSchemaThree()
            ),
            "emailProviderCredentialsSchemaApiKey" => onEmailProviderCredentialsSchemaApiKey(
                AsEmailProviderCredentialsSchemaApiKey()
            ),
            "emailProviderCredentialsSchemaConnectionString" =>
                onEmailProviderCredentialsSchemaConnectionString(
                    AsEmailProviderCredentialsSchemaConnectionString()
                ),
            "emailProviderCredentialsSchemaClientId" => onEmailProviderCredentialsSchemaClientId(
                AsEmailProviderCredentialsSchemaClientId()
            ),
            "extensibilityEmailProviderCredentials" => onExtensibilityEmailProviderCredentials(
                AsExtensibilityEmailProviderCredentials()
            ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.EmailProviderCredentialsSchemaZero> onEmailProviderCredentialsSchemaZero,
        global::System.Action<Auth0.ManagementApi.EmailProviderCredentialsSchemaAccessKeyId> onEmailProviderCredentialsSchemaAccessKeyId,
        global::System.Action<Auth0.ManagementApi.EmailProviderCredentialsSchemaSmtpHost> onEmailProviderCredentialsSchemaSmtpHost,
        global::System.Action<Auth0.ManagementApi.EmailProviderCredentialsSchemaThree> onEmailProviderCredentialsSchemaThree,
        global::System.Action<Auth0.ManagementApi.EmailProviderCredentialsSchemaApiKey> onEmailProviderCredentialsSchemaApiKey,
        global::System.Action<Auth0.ManagementApi.EmailProviderCredentialsSchemaConnectionString> onEmailProviderCredentialsSchemaConnectionString,
        global::System.Action<Auth0.ManagementApi.EmailProviderCredentialsSchemaClientId> onEmailProviderCredentialsSchemaClientId,
        global::System.Action<Auth0.ManagementApi.ExtensibilityEmailProviderCredentials> onExtensibilityEmailProviderCredentials
    )
    {
        switch (Type)
        {
            case "emailProviderCredentialsSchemaZero":
                onEmailProviderCredentialsSchemaZero(AsEmailProviderCredentialsSchemaZero());
                break;
            case "emailProviderCredentialsSchemaAccessKeyId":
                onEmailProviderCredentialsSchemaAccessKeyId(
                    AsEmailProviderCredentialsSchemaAccessKeyId()
                );
                break;
            case "emailProviderCredentialsSchemaSmtpHost":
                onEmailProviderCredentialsSchemaSmtpHost(
                    AsEmailProviderCredentialsSchemaSmtpHost()
                );
                break;
            case "emailProviderCredentialsSchemaThree":
                onEmailProviderCredentialsSchemaThree(AsEmailProviderCredentialsSchemaThree());
                break;
            case "emailProviderCredentialsSchemaApiKey":
                onEmailProviderCredentialsSchemaApiKey(AsEmailProviderCredentialsSchemaApiKey());
                break;
            case "emailProviderCredentialsSchemaConnectionString":
                onEmailProviderCredentialsSchemaConnectionString(
                    AsEmailProviderCredentialsSchemaConnectionString()
                );
                break;
            case "emailProviderCredentialsSchemaClientId":
                onEmailProviderCredentialsSchemaClientId(
                    AsEmailProviderCredentialsSchemaClientId()
                );
                break;
            case "extensibilityEmailProviderCredentials":
                onExtensibilityEmailProviderCredentials(AsExtensibilityEmailProviderCredentials());
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
        if (obj is not EmailProviderCredentialsSchema other)
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

    public static implicit operator EmailProviderCredentialsSchema(
        Auth0.ManagementApi.EmailProviderCredentialsSchemaZero value
    ) => new("emailProviderCredentialsSchemaZero", value);

    public static implicit operator EmailProviderCredentialsSchema(
        Auth0.ManagementApi.EmailProviderCredentialsSchemaAccessKeyId value
    ) => new("emailProviderCredentialsSchemaAccessKeyId", value);

    public static implicit operator EmailProviderCredentialsSchema(
        Auth0.ManagementApi.EmailProviderCredentialsSchemaSmtpHost value
    ) => new("emailProviderCredentialsSchemaSmtpHost", value);

    public static implicit operator EmailProviderCredentialsSchema(
        Auth0.ManagementApi.EmailProviderCredentialsSchemaThree value
    ) => new("emailProviderCredentialsSchemaThree", value);

    public static implicit operator EmailProviderCredentialsSchema(
        Auth0.ManagementApi.EmailProviderCredentialsSchemaApiKey value
    ) => new("emailProviderCredentialsSchemaApiKey", value);

    public static implicit operator EmailProviderCredentialsSchema(
        Auth0.ManagementApi.EmailProviderCredentialsSchemaConnectionString value
    ) => new("emailProviderCredentialsSchemaConnectionString", value);

    public static implicit operator EmailProviderCredentialsSchema(
        Auth0.ManagementApi.EmailProviderCredentialsSchemaClientId value
    ) => new("emailProviderCredentialsSchemaClientId", value);

    public static implicit operator EmailProviderCredentialsSchema(
        Auth0.ManagementApi.ExtensibilityEmailProviderCredentials value
    ) => new("extensibilityEmailProviderCredentials", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<EmailProviderCredentialsSchema>
    {
        public override EmailProviderCredentialsSchema? Read(
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
                        "emailProviderCredentialsSchemaZero",
                        typeof(Auth0.ManagementApi.EmailProviderCredentialsSchemaZero)
                    ),
                    (
                        "emailProviderCredentialsSchemaAccessKeyId",
                        typeof(Auth0.ManagementApi.EmailProviderCredentialsSchemaAccessKeyId)
                    ),
                    (
                        "emailProviderCredentialsSchemaSmtpHost",
                        typeof(Auth0.ManagementApi.EmailProviderCredentialsSchemaSmtpHost)
                    ),
                    (
                        "emailProviderCredentialsSchemaThree",
                        typeof(Auth0.ManagementApi.EmailProviderCredentialsSchemaThree)
                    ),
                    (
                        "emailProviderCredentialsSchemaApiKey",
                        typeof(Auth0.ManagementApi.EmailProviderCredentialsSchemaApiKey)
                    ),
                    (
                        "emailProviderCredentialsSchemaConnectionString",
                        typeof(Auth0.ManagementApi.EmailProviderCredentialsSchemaConnectionString)
                    ),
                    (
                        "emailProviderCredentialsSchemaClientId",
                        typeof(Auth0.ManagementApi.EmailProviderCredentialsSchemaClientId)
                    ),
                    (
                        "extensibilityEmailProviderCredentials",
                        typeof(Auth0.ManagementApi.ExtensibilityEmailProviderCredentials)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            EmailProviderCredentialsSchema result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into EmailProviderCredentialsSchema"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            EmailProviderCredentialsSchema value,
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
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override EmailProviderCredentialsSchema ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            EmailProviderCredentialsSchema result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            EmailProviderCredentialsSchema value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
