// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

/// <summary>
/// Private key used to decrypt encrypted SAML Assertions received from the identity provider. Required when the identity provider encrypts assertions for enhanced security. Can be a string (PEM) or an object with key-value pairs.
/// </summary>
[JsonConverter(typeof(ConnectionDecryptionKeySaml.JsonConverter))]
[Serializable]
public class ConnectionDecryptionKeySaml
{
    private ConnectionDecryptionKeySaml(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.ConnectionDecryptionKeySamlCert value.
    /// </summary>
    public static ConnectionDecryptionKeySaml FromConnectionDecryptionKeySamlCert(
        Auth0.ManagementApi.ConnectionDecryptionKeySamlCert value
    ) => new("connectionDecryptionKeySamlCert", value);

    /// <summary>
    /// Factory method to create a union from a string value.
    /// </summary>
    public static ConnectionDecryptionKeySaml FromString(string value) => new("string", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "connectionDecryptionKeySamlCert"
    /// </summary>
    public bool IsConnectionDecryptionKeySamlCert() => Type == "connectionDecryptionKeySamlCert";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "string"
    /// </summary>
    public bool IsString() => Type == "string";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.ConnectionDecryptionKeySamlCert"/> if <see cref="Type"/> is 'connectionDecryptionKeySamlCert', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'connectionDecryptionKeySamlCert'.</exception>
    public Auth0.ManagementApi.ConnectionDecryptionKeySamlCert AsConnectionDecryptionKeySamlCert() =>
        IsConnectionDecryptionKeySamlCert()
            ? (Auth0.ManagementApi.ConnectionDecryptionKeySamlCert)Value!
            : throw new ManagementException("Union type is not 'connectionDecryptionKeySamlCert'");

    /// <summary>
    /// Returns the value as a <see cref="string"/> if <see cref="Type"/> is 'string', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'string'.</exception>
    public string AsString() =>
        IsString() ? (string)Value! : throw new ManagementException("Union type is not 'string'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.ConnectionDecryptionKeySamlCert"/> and returns true if successful.
    /// </summary>
    public bool TryGetConnectionDecryptionKeySamlCert(
        out Auth0.ManagementApi.ConnectionDecryptionKeySamlCert? value
    )
    {
        if (Type == "connectionDecryptionKeySamlCert")
        {
            value = (Auth0.ManagementApi.ConnectionDecryptionKeySamlCert)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="string"/> and returns true if successful.
    /// </summary>
    public bool TryGetString(out string? value)
    {
        if (Type == "string")
        {
            value = (string)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.ConnectionDecryptionKeySamlCert,
            T
        > onConnectionDecryptionKeySamlCert,
        Func<string, T> onString
    )
    {
        return Type switch
        {
            "connectionDecryptionKeySamlCert" => onConnectionDecryptionKeySamlCert(
                AsConnectionDecryptionKeySamlCert()
            ),
            "string" => onString(AsString()),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        System.Action<Auth0.ManagementApi.ConnectionDecryptionKeySamlCert> onConnectionDecryptionKeySamlCert,
        System.Action<string> onString
    )
    {
        switch (Type)
        {
            case "connectionDecryptionKeySamlCert":
                onConnectionDecryptionKeySamlCert(AsConnectionDecryptionKeySamlCert());
                break;
            case "string":
                onString(AsString());
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
        if (obj is not ConnectionDecryptionKeySaml other)
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

    public static implicit operator ConnectionDecryptionKeySaml(
        Auth0.ManagementApi.ConnectionDecryptionKeySamlCert value
    ) => new("connectionDecryptionKeySamlCert", value);

    public static implicit operator ConnectionDecryptionKeySaml(string value) =>
        new("string", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<ConnectionDecryptionKeySaml>
    {
        public override ConnectionDecryptionKeySaml? Read(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            if (reader.TokenType == JsonTokenType.String)
            {
                var stringValue = reader.GetString()!;

                ConnectionDecryptionKeySaml stringResult = new("string", stringValue);
                return stringResult;
            }

            if (reader.TokenType == JsonTokenType.StartObject)
            {
                var document = JsonDocument.ParseValue(ref reader);

                var types = new (string Key, System.Type Type)[]
                {
                    (
                        "connectionDecryptionKeySamlCert",
                        typeof(Auth0.ManagementApi.ConnectionDecryptionKeySamlCert)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            ConnectionDecryptionKeySaml result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into ConnectionDecryptionKeySaml"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionDecryptionKeySaml value,
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
                str => writer.WriteStringValue(str)
            );
        }

        public override ConnectionDecryptionKeySaml ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            ConnectionDecryptionKeySaml result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConnectionDecryptionKeySaml value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
