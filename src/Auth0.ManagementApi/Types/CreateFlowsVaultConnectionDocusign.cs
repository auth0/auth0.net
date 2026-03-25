// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(CreateFlowsVaultConnectionDocusign.JsonConverter))]
[Serializable]
public class CreateFlowsVaultConnectionDocusign
{
    private CreateFlowsVaultConnectionDocusign(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionDocusignOauthCode value.
    /// </summary>
    public static CreateFlowsVaultConnectionDocusign FromCreateFlowsVaultConnectionDocusignOauthCode(
        Auth0.ManagementApi.CreateFlowsVaultConnectionDocusignOauthCode value
    ) => new("createFlowsVaultConnectionDocusignOauthCode", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionDocusignUninitialized value.
    /// </summary>
    public static CreateFlowsVaultConnectionDocusign FromCreateFlowsVaultConnectionDocusignUninitialized(
        Auth0.ManagementApi.CreateFlowsVaultConnectionDocusignUninitialized value
    ) => new("createFlowsVaultConnectionDocusignUninitialized", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionDocusignOauthCode"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionDocusignOauthCode() =>
        Type == "createFlowsVaultConnectionDocusignOauthCode";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionDocusignUninitialized"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionDocusignUninitialized() =>
        Type == "createFlowsVaultConnectionDocusignUninitialized";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionDocusignOauthCode"/> if <see cref="Type"/> is 'createFlowsVaultConnectionDocusignOauthCode', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionDocusignOauthCode'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionDocusignOauthCode AsCreateFlowsVaultConnectionDocusignOauthCode() =>
        IsCreateFlowsVaultConnectionDocusignOauthCode()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionDocusignOauthCode)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionDocusignOauthCode'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionDocusignUninitialized"/> if <see cref="Type"/> is 'createFlowsVaultConnectionDocusignUninitialized', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionDocusignUninitialized'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionDocusignUninitialized AsCreateFlowsVaultConnectionDocusignUninitialized() =>
        IsCreateFlowsVaultConnectionDocusignUninitialized()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionDocusignUninitialized)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionDocusignUninitialized'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionDocusignOauthCode"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionDocusignOauthCode(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionDocusignOauthCode? value
    )
    {
        if (Type == "createFlowsVaultConnectionDocusignOauthCode")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionDocusignOauthCode)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionDocusignUninitialized"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionDocusignUninitialized(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionDocusignUninitialized? value
    )
    {
        if (Type == "createFlowsVaultConnectionDocusignUninitialized")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionDocusignUninitialized)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionDocusignOauthCode,
            T
        > onCreateFlowsVaultConnectionDocusignOauthCode,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionDocusignUninitialized,
            T
        > onCreateFlowsVaultConnectionDocusignUninitialized
    )
    {
        return Type switch
        {
            "createFlowsVaultConnectionDocusignOauthCode" =>
                onCreateFlowsVaultConnectionDocusignOauthCode(
                    AsCreateFlowsVaultConnectionDocusignOauthCode()
                ),
            "createFlowsVaultConnectionDocusignUninitialized" =>
                onCreateFlowsVaultConnectionDocusignUninitialized(
                    AsCreateFlowsVaultConnectionDocusignUninitialized()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionDocusignOauthCode> onCreateFlowsVaultConnectionDocusignOauthCode,
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionDocusignUninitialized> onCreateFlowsVaultConnectionDocusignUninitialized
    )
    {
        switch (Type)
        {
            case "createFlowsVaultConnectionDocusignOauthCode":
                onCreateFlowsVaultConnectionDocusignOauthCode(
                    AsCreateFlowsVaultConnectionDocusignOauthCode()
                );
                break;
            case "createFlowsVaultConnectionDocusignUninitialized":
                onCreateFlowsVaultConnectionDocusignUninitialized(
                    AsCreateFlowsVaultConnectionDocusignUninitialized()
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
        if (obj is not CreateFlowsVaultConnectionDocusign other)
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

    public static implicit operator CreateFlowsVaultConnectionDocusign(
        Auth0.ManagementApi.CreateFlowsVaultConnectionDocusignOauthCode value
    ) => new("createFlowsVaultConnectionDocusignOauthCode", value);

    public static implicit operator CreateFlowsVaultConnectionDocusign(
        Auth0.ManagementApi.CreateFlowsVaultConnectionDocusignUninitialized value
    ) => new("createFlowsVaultConnectionDocusignUninitialized", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CreateFlowsVaultConnectionDocusign>
    {
        public override CreateFlowsVaultConnectionDocusign? Read(
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
                        "createFlowsVaultConnectionDocusignOauthCode",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionDocusignOauthCode)
                    ),
                    (
                        "createFlowsVaultConnectionDocusignUninitialized",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionDocusignUninitialized)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            CreateFlowsVaultConnectionDocusign result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into CreateFlowsVaultConnectionDocusign"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateFlowsVaultConnectionDocusign value,
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

        public override CreateFlowsVaultConnectionDocusign ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            CreateFlowsVaultConnectionDocusign result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateFlowsVaultConnectionDocusign value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
