// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(ConnectionUpstreamAdditionalProperties.JsonConverter))]
[Serializable]
public class ConnectionUpstreamAdditionalProperties
{
    private ConnectionUpstreamAdditionalProperties(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.ConnectionUpstreamAlias value.
    /// </summary>
    public static ConnectionUpstreamAdditionalProperties FromConnectionUpstreamAlias(
        Auth0.ManagementApi.ConnectionUpstreamAlias value
    ) => new("connectionUpstreamAlias", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.ConnectionUpstreamValue value.
    /// </summary>
    public static ConnectionUpstreamAdditionalProperties FromConnectionUpstreamValue(
        Auth0.ManagementApi.ConnectionUpstreamValue value
    ) => new("connectionUpstreamValue", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "connectionUpstreamAlias"
    /// </summary>
    public bool IsConnectionUpstreamAlias() => Type == "connectionUpstreamAlias";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "connectionUpstreamValue"
    /// </summary>
    public bool IsConnectionUpstreamValue() => Type == "connectionUpstreamValue";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.ConnectionUpstreamAlias"/> if <see cref="Type"/> is 'connectionUpstreamAlias', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'connectionUpstreamAlias'.</exception>
    public Auth0.ManagementApi.ConnectionUpstreamAlias AsConnectionUpstreamAlias() =>
        IsConnectionUpstreamAlias()
            ? (Auth0.ManagementApi.ConnectionUpstreamAlias)Value!
            : throw new ManagementException("Union type is not 'connectionUpstreamAlias'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.ConnectionUpstreamValue"/> if <see cref="Type"/> is 'connectionUpstreamValue', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'connectionUpstreamValue'.</exception>
    public Auth0.ManagementApi.ConnectionUpstreamValue AsConnectionUpstreamValue() =>
        IsConnectionUpstreamValue()
            ? (Auth0.ManagementApi.ConnectionUpstreamValue)Value!
            : throw new ManagementException("Union type is not 'connectionUpstreamValue'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.ConnectionUpstreamAlias"/> and returns true if successful.
    /// </summary>
    public bool TryGetConnectionUpstreamAlias(
        out Auth0.ManagementApi.ConnectionUpstreamAlias? value
    )
    {
        if (Type == "connectionUpstreamAlias")
        {
            value = (Auth0.ManagementApi.ConnectionUpstreamAlias)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.ConnectionUpstreamValue"/> and returns true if successful.
    /// </summary>
    public bool TryGetConnectionUpstreamValue(
        out Auth0.ManagementApi.ConnectionUpstreamValue? value
    )
    {
        if (Type == "connectionUpstreamValue")
        {
            value = (Auth0.ManagementApi.ConnectionUpstreamValue)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Auth0.ManagementApi.ConnectionUpstreamAlias, T> onConnectionUpstreamAlias,
        Func<Auth0.ManagementApi.ConnectionUpstreamValue, T> onConnectionUpstreamValue
    )
    {
        return Type switch
        {
            "connectionUpstreamAlias" => onConnectionUpstreamAlias(AsConnectionUpstreamAlias()),
            "connectionUpstreamValue" => onConnectionUpstreamValue(AsConnectionUpstreamValue()),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.ConnectionUpstreamAlias> onConnectionUpstreamAlias,
        global::System.Action<Auth0.ManagementApi.ConnectionUpstreamValue> onConnectionUpstreamValue
    )
    {
        switch (Type)
        {
            case "connectionUpstreamAlias":
                onConnectionUpstreamAlias(AsConnectionUpstreamAlias());
                break;
            case "connectionUpstreamValue":
                onConnectionUpstreamValue(AsConnectionUpstreamValue());
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
        if (obj is not ConnectionUpstreamAdditionalProperties other)
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

    public static implicit operator ConnectionUpstreamAdditionalProperties(
        Auth0.ManagementApi.ConnectionUpstreamAlias value
    ) => new("connectionUpstreamAlias", value);

    public static implicit operator ConnectionUpstreamAdditionalProperties(
        Auth0.ManagementApi.ConnectionUpstreamValue value
    ) => new("connectionUpstreamValue", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<ConnectionUpstreamAdditionalProperties>
    {
        public override ConnectionUpstreamAdditionalProperties? Read(
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
                        "connectionUpstreamAlias",
                        typeof(Auth0.ManagementApi.ConnectionUpstreamAlias)
                    ),
                    (
                        "connectionUpstreamValue",
                        typeof(Auth0.ManagementApi.ConnectionUpstreamValue)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            ConnectionUpstreamAdditionalProperties result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into ConnectionUpstreamAdditionalProperties"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ConnectionUpstreamAdditionalProperties value,
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

        public override ConnectionUpstreamAdditionalProperties ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            ConnectionUpstreamAdditionalProperties result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ConnectionUpstreamAdditionalProperties value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
