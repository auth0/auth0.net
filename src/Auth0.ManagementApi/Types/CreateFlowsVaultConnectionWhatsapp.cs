// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(CreateFlowsVaultConnectionWhatsapp.JsonConverter))]
[Serializable]
public class CreateFlowsVaultConnectionWhatsapp
{
    private CreateFlowsVaultConnectionWhatsapp(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionWhatsappToken value.
    /// </summary>
    public static CreateFlowsVaultConnectionWhatsapp FromCreateFlowsVaultConnectionWhatsappToken(
        Auth0.ManagementApi.CreateFlowsVaultConnectionWhatsappToken value
    ) => new("createFlowsVaultConnectionWhatsappToken", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionWhatsappUninitialized value.
    /// </summary>
    public static CreateFlowsVaultConnectionWhatsapp FromCreateFlowsVaultConnectionWhatsappUninitialized(
        Auth0.ManagementApi.CreateFlowsVaultConnectionWhatsappUninitialized value
    ) => new("createFlowsVaultConnectionWhatsappUninitialized", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionWhatsappToken"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionWhatsappToken() =>
        Type == "createFlowsVaultConnectionWhatsappToken";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionWhatsappUninitialized"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionWhatsappUninitialized() =>
        Type == "createFlowsVaultConnectionWhatsappUninitialized";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionWhatsappToken"/> if <see cref="Type"/> is 'createFlowsVaultConnectionWhatsappToken', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionWhatsappToken'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionWhatsappToken AsCreateFlowsVaultConnectionWhatsappToken() =>
        IsCreateFlowsVaultConnectionWhatsappToken()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionWhatsappToken)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionWhatsappToken'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionWhatsappUninitialized"/> if <see cref="Type"/> is 'createFlowsVaultConnectionWhatsappUninitialized', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionWhatsappUninitialized'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionWhatsappUninitialized AsCreateFlowsVaultConnectionWhatsappUninitialized() =>
        IsCreateFlowsVaultConnectionWhatsappUninitialized()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionWhatsappUninitialized)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionWhatsappUninitialized'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionWhatsappToken"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionWhatsappToken(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionWhatsappToken? value
    )
    {
        if (Type == "createFlowsVaultConnectionWhatsappToken")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionWhatsappToken)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionWhatsappUninitialized"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionWhatsappUninitialized(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionWhatsappUninitialized? value
    )
    {
        if (Type == "createFlowsVaultConnectionWhatsappUninitialized")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionWhatsappUninitialized)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionWhatsappToken,
            T
        > onCreateFlowsVaultConnectionWhatsappToken,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionWhatsappUninitialized,
            T
        > onCreateFlowsVaultConnectionWhatsappUninitialized
    )
    {
        return Type switch
        {
            "createFlowsVaultConnectionWhatsappToken" => onCreateFlowsVaultConnectionWhatsappToken(
                AsCreateFlowsVaultConnectionWhatsappToken()
            ),
            "createFlowsVaultConnectionWhatsappUninitialized" =>
                onCreateFlowsVaultConnectionWhatsappUninitialized(
                    AsCreateFlowsVaultConnectionWhatsappUninitialized()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionWhatsappToken> onCreateFlowsVaultConnectionWhatsappToken,
        System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionWhatsappUninitialized> onCreateFlowsVaultConnectionWhatsappUninitialized
    )
    {
        switch (Type)
        {
            case "createFlowsVaultConnectionWhatsappToken":
                onCreateFlowsVaultConnectionWhatsappToken(
                    AsCreateFlowsVaultConnectionWhatsappToken()
                );
                break;
            case "createFlowsVaultConnectionWhatsappUninitialized":
                onCreateFlowsVaultConnectionWhatsappUninitialized(
                    AsCreateFlowsVaultConnectionWhatsappUninitialized()
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
        if (obj is not CreateFlowsVaultConnectionWhatsapp other)
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

    public static implicit operator CreateFlowsVaultConnectionWhatsapp(
        Auth0.ManagementApi.CreateFlowsVaultConnectionWhatsappToken value
    ) => new("createFlowsVaultConnectionWhatsappToken", value);

    public static implicit operator CreateFlowsVaultConnectionWhatsapp(
        Auth0.ManagementApi.CreateFlowsVaultConnectionWhatsappUninitialized value
    ) => new("createFlowsVaultConnectionWhatsappUninitialized", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CreateFlowsVaultConnectionWhatsapp>
    {
        public override CreateFlowsVaultConnectionWhatsapp? Read(
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
                        "createFlowsVaultConnectionWhatsappToken",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionWhatsappToken)
                    ),
                    (
                        "createFlowsVaultConnectionWhatsappUninitialized",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionWhatsappUninitialized)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            CreateFlowsVaultConnectionWhatsapp result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into CreateFlowsVaultConnectionWhatsapp"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateFlowsVaultConnectionWhatsapp value,
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

        public override CreateFlowsVaultConnectionWhatsapp ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            CreateFlowsVaultConnectionWhatsapp result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateFlowsVaultConnectionWhatsapp value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
