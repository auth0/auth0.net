// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(CreateFlowsVaultConnectionSendgrid.JsonConverter))]
[Serializable]
public class CreateFlowsVaultConnectionSendgrid
{
    private CreateFlowsVaultConnectionSendgrid(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionSendgridApiKey value.
    /// </summary>
    public static CreateFlowsVaultConnectionSendgrid FromCreateFlowsVaultConnectionSendgridApiKey(
        Auth0.ManagementApi.CreateFlowsVaultConnectionSendgridApiKey value
    ) => new("createFlowsVaultConnectionSendgridApiKey", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionSendgridUninitialized value.
    /// </summary>
    public static CreateFlowsVaultConnectionSendgrid FromCreateFlowsVaultConnectionSendgridUninitialized(
        Auth0.ManagementApi.CreateFlowsVaultConnectionSendgridUninitialized value
    ) => new("createFlowsVaultConnectionSendgridUninitialized", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionSendgridApiKey"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionSendgridApiKey() =>
        Type == "createFlowsVaultConnectionSendgridApiKey";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionSendgridUninitialized"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionSendgridUninitialized() =>
        Type == "createFlowsVaultConnectionSendgridUninitialized";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionSendgridApiKey"/> if <see cref="Type"/> is 'createFlowsVaultConnectionSendgridApiKey', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionSendgridApiKey'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionSendgridApiKey AsCreateFlowsVaultConnectionSendgridApiKey() =>
        IsCreateFlowsVaultConnectionSendgridApiKey()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionSendgridApiKey)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionSendgridApiKey'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionSendgridUninitialized"/> if <see cref="Type"/> is 'createFlowsVaultConnectionSendgridUninitialized', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionSendgridUninitialized'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionSendgridUninitialized AsCreateFlowsVaultConnectionSendgridUninitialized() =>
        IsCreateFlowsVaultConnectionSendgridUninitialized()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionSendgridUninitialized)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionSendgridUninitialized'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionSendgridApiKey"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionSendgridApiKey(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionSendgridApiKey? value
    )
    {
        if (Type == "createFlowsVaultConnectionSendgridApiKey")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionSendgridApiKey)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionSendgridUninitialized"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionSendgridUninitialized(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionSendgridUninitialized? value
    )
    {
        if (Type == "createFlowsVaultConnectionSendgridUninitialized")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionSendgridUninitialized)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionSendgridApiKey,
            T
        > onCreateFlowsVaultConnectionSendgridApiKey,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionSendgridUninitialized,
            T
        > onCreateFlowsVaultConnectionSendgridUninitialized
    )
    {
        return Type switch
        {
            "createFlowsVaultConnectionSendgridApiKey" =>
                onCreateFlowsVaultConnectionSendgridApiKey(
                    AsCreateFlowsVaultConnectionSendgridApiKey()
                ),
            "createFlowsVaultConnectionSendgridUninitialized" =>
                onCreateFlowsVaultConnectionSendgridUninitialized(
                    AsCreateFlowsVaultConnectionSendgridUninitialized()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionSendgridApiKey> onCreateFlowsVaultConnectionSendgridApiKey,
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionSendgridUninitialized> onCreateFlowsVaultConnectionSendgridUninitialized
    )
    {
        switch (Type)
        {
            case "createFlowsVaultConnectionSendgridApiKey":
                onCreateFlowsVaultConnectionSendgridApiKey(
                    AsCreateFlowsVaultConnectionSendgridApiKey()
                );
                break;
            case "createFlowsVaultConnectionSendgridUninitialized":
                onCreateFlowsVaultConnectionSendgridUninitialized(
                    AsCreateFlowsVaultConnectionSendgridUninitialized()
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
        if (obj is not CreateFlowsVaultConnectionSendgrid other)
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

    public static implicit operator CreateFlowsVaultConnectionSendgrid(
        Auth0.ManagementApi.CreateFlowsVaultConnectionSendgridApiKey value
    ) => new("createFlowsVaultConnectionSendgridApiKey", value);

    public static implicit operator CreateFlowsVaultConnectionSendgrid(
        Auth0.ManagementApi.CreateFlowsVaultConnectionSendgridUninitialized value
    ) => new("createFlowsVaultConnectionSendgridUninitialized", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CreateFlowsVaultConnectionSendgrid>
    {
        public override CreateFlowsVaultConnectionSendgrid? Read(
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
                        "createFlowsVaultConnectionSendgridApiKey",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionSendgridApiKey)
                    ),
                    (
                        "createFlowsVaultConnectionSendgridUninitialized",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionSendgridUninitialized)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            CreateFlowsVaultConnectionSendgrid result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into CreateFlowsVaultConnectionSendgrid"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateFlowsVaultConnectionSendgrid value,
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

        public override CreateFlowsVaultConnectionSendgrid ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            CreateFlowsVaultConnectionSendgrid result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateFlowsVaultConnectionSendgrid value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
