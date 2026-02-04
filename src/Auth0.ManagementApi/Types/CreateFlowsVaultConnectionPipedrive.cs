// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(CreateFlowsVaultConnectionPipedrive.JsonConverter))]
[Serializable]
public class CreateFlowsVaultConnectionPipedrive
{
    private CreateFlowsVaultConnectionPipedrive(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionPipedriveToken value.
    /// </summary>
    public static CreateFlowsVaultConnectionPipedrive FromCreateFlowsVaultConnectionPipedriveToken(
        Auth0.ManagementApi.CreateFlowsVaultConnectionPipedriveToken value
    ) => new("createFlowsVaultConnectionPipedriveToken", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionPipedriveOauthCode value.
    /// </summary>
    public static CreateFlowsVaultConnectionPipedrive FromCreateFlowsVaultConnectionPipedriveOauthCode(
        Auth0.ManagementApi.CreateFlowsVaultConnectionPipedriveOauthCode value
    ) => new("createFlowsVaultConnectionPipedriveOauthCode", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionPipedriveUninitialized value.
    /// </summary>
    public static CreateFlowsVaultConnectionPipedrive FromCreateFlowsVaultConnectionPipedriveUninitialized(
        Auth0.ManagementApi.CreateFlowsVaultConnectionPipedriveUninitialized value
    ) => new("createFlowsVaultConnectionPipedriveUninitialized", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionPipedriveToken"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionPipedriveToken() =>
        Type == "createFlowsVaultConnectionPipedriveToken";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionPipedriveOauthCode"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionPipedriveOauthCode() =>
        Type == "createFlowsVaultConnectionPipedriveOauthCode";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionPipedriveUninitialized"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionPipedriveUninitialized() =>
        Type == "createFlowsVaultConnectionPipedriveUninitialized";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionPipedriveToken"/> if <see cref="Type"/> is 'createFlowsVaultConnectionPipedriveToken', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionPipedriveToken'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionPipedriveToken AsCreateFlowsVaultConnectionPipedriveToken() =>
        IsCreateFlowsVaultConnectionPipedriveToken()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionPipedriveToken)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionPipedriveToken'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionPipedriveOauthCode"/> if <see cref="Type"/> is 'createFlowsVaultConnectionPipedriveOauthCode', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionPipedriveOauthCode'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionPipedriveOauthCode AsCreateFlowsVaultConnectionPipedriveOauthCode() =>
        IsCreateFlowsVaultConnectionPipedriveOauthCode()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionPipedriveOauthCode)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionPipedriveOauthCode'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionPipedriveUninitialized"/> if <see cref="Type"/> is 'createFlowsVaultConnectionPipedriveUninitialized', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionPipedriveUninitialized'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionPipedriveUninitialized AsCreateFlowsVaultConnectionPipedriveUninitialized() =>
        IsCreateFlowsVaultConnectionPipedriveUninitialized()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionPipedriveUninitialized)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionPipedriveUninitialized'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionPipedriveToken"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionPipedriveToken(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionPipedriveToken? value
    )
    {
        if (Type == "createFlowsVaultConnectionPipedriveToken")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionPipedriveToken)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionPipedriveOauthCode"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionPipedriveOauthCode(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionPipedriveOauthCode? value
    )
    {
        if (Type == "createFlowsVaultConnectionPipedriveOauthCode")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionPipedriveOauthCode)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionPipedriveUninitialized"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionPipedriveUninitialized(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionPipedriveUninitialized? value
    )
    {
        if (Type == "createFlowsVaultConnectionPipedriveUninitialized")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionPipedriveUninitialized)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionPipedriveToken,
            T
        > onCreateFlowsVaultConnectionPipedriveToken,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionPipedriveOauthCode,
            T
        > onCreateFlowsVaultConnectionPipedriveOauthCode,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionPipedriveUninitialized,
            T
        > onCreateFlowsVaultConnectionPipedriveUninitialized
    )
    {
        return Type switch
        {
            "createFlowsVaultConnectionPipedriveToken" =>
                onCreateFlowsVaultConnectionPipedriveToken(
                    AsCreateFlowsVaultConnectionPipedriveToken()
                ),
            "createFlowsVaultConnectionPipedriveOauthCode" =>
                onCreateFlowsVaultConnectionPipedriveOauthCode(
                    AsCreateFlowsVaultConnectionPipedriveOauthCode()
                ),
            "createFlowsVaultConnectionPipedriveUninitialized" =>
                onCreateFlowsVaultConnectionPipedriveUninitialized(
                    AsCreateFlowsVaultConnectionPipedriveUninitialized()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionPipedriveToken> onCreateFlowsVaultConnectionPipedriveToken,
        System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionPipedriveOauthCode> onCreateFlowsVaultConnectionPipedriveOauthCode,
        System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionPipedriveUninitialized> onCreateFlowsVaultConnectionPipedriveUninitialized
    )
    {
        switch (Type)
        {
            case "createFlowsVaultConnectionPipedriveToken":
                onCreateFlowsVaultConnectionPipedriveToken(
                    AsCreateFlowsVaultConnectionPipedriveToken()
                );
                break;
            case "createFlowsVaultConnectionPipedriveOauthCode":
                onCreateFlowsVaultConnectionPipedriveOauthCode(
                    AsCreateFlowsVaultConnectionPipedriveOauthCode()
                );
                break;
            case "createFlowsVaultConnectionPipedriveUninitialized":
                onCreateFlowsVaultConnectionPipedriveUninitialized(
                    AsCreateFlowsVaultConnectionPipedriveUninitialized()
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
        if (obj is not CreateFlowsVaultConnectionPipedrive other)
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

    public static implicit operator CreateFlowsVaultConnectionPipedrive(
        Auth0.ManagementApi.CreateFlowsVaultConnectionPipedriveToken value
    ) => new("createFlowsVaultConnectionPipedriveToken", value);

    public static implicit operator CreateFlowsVaultConnectionPipedrive(
        Auth0.ManagementApi.CreateFlowsVaultConnectionPipedriveOauthCode value
    ) => new("createFlowsVaultConnectionPipedriveOauthCode", value);

    public static implicit operator CreateFlowsVaultConnectionPipedrive(
        Auth0.ManagementApi.CreateFlowsVaultConnectionPipedriveUninitialized value
    ) => new("createFlowsVaultConnectionPipedriveUninitialized", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CreateFlowsVaultConnectionPipedrive>
    {
        public override CreateFlowsVaultConnectionPipedrive? Read(
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
                        "createFlowsVaultConnectionPipedriveToken",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionPipedriveToken)
                    ),
                    (
                        "createFlowsVaultConnectionPipedriveOauthCode",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionPipedriveOauthCode)
                    ),
                    (
                        "createFlowsVaultConnectionPipedriveUninitialized",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionPipedriveUninitialized)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            CreateFlowsVaultConnectionPipedrive result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into CreateFlowsVaultConnectionPipedrive"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateFlowsVaultConnectionPipedrive value,
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

        public override CreateFlowsVaultConnectionPipedrive ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            CreateFlowsVaultConnectionPipedrive result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateFlowsVaultConnectionPipedrive value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
