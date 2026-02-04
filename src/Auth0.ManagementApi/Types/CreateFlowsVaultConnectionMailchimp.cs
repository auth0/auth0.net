// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(CreateFlowsVaultConnectionMailchimp.JsonConverter))]
[Serializable]
public class CreateFlowsVaultConnectionMailchimp
{
    private CreateFlowsVaultConnectionMailchimp(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimpApiKey value.
    /// </summary>
    public static CreateFlowsVaultConnectionMailchimp FromCreateFlowsVaultConnectionMailchimpApiKey(
        Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimpApiKey value
    ) => new("createFlowsVaultConnectionMailchimpApiKey", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimpOauthCode value.
    /// </summary>
    public static CreateFlowsVaultConnectionMailchimp FromCreateFlowsVaultConnectionMailchimpOauthCode(
        Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimpOauthCode value
    ) => new("createFlowsVaultConnectionMailchimpOauthCode", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimpUninitialized value.
    /// </summary>
    public static CreateFlowsVaultConnectionMailchimp FromCreateFlowsVaultConnectionMailchimpUninitialized(
        Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimpUninitialized value
    ) => new("createFlowsVaultConnectionMailchimpUninitialized", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionMailchimpApiKey"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionMailchimpApiKey() =>
        Type == "createFlowsVaultConnectionMailchimpApiKey";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionMailchimpOauthCode"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionMailchimpOauthCode() =>
        Type == "createFlowsVaultConnectionMailchimpOauthCode";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionMailchimpUninitialized"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionMailchimpUninitialized() =>
        Type == "createFlowsVaultConnectionMailchimpUninitialized";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimpApiKey"/> if <see cref="Type"/> is 'createFlowsVaultConnectionMailchimpApiKey', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionMailchimpApiKey'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimpApiKey AsCreateFlowsVaultConnectionMailchimpApiKey() =>
        IsCreateFlowsVaultConnectionMailchimpApiKey()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimpApiKey)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionMailchimpApiKey'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimpOauthCode"/> if <see cref="Type"/> is 'createFlowsVaultConnectionMailchimpOauthCode', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionMailchimpOauthCode'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimpOauthCode AsCreateFlowsVaultConnectionMailchimpOauthCode() =>
        IsCreateFlowsVaultConnectionMailchimpOauthCode()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimpOauthCode)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionMailchimpOauthCode'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimpUninitialized"/> if <see cref="Type"/> is 'createFlowsVaultConnectionMailchimpUninitialized', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionMailchimpUninitialized'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimpUninitialized AsCreateFlowsVaultConnectionMailchimpUninitialized() =>
        IsCreateFlowsVaultConnectionMailchimpUninitialized()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimpUninitialized)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionMailchimpUninitialized'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimpApiKey"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionMailchimpApiKey(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimpApiKey? value
    )
    {
        if (Type == "createFlowsVaultConnectionMailchimpApiKey")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimpApiKey)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimpOauthCode"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionMailchimpOauthCode(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimpOauthCode? value
    )
    {
        if (Type == "createFlowsVaultConnectionMailchimpOauthCode")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimpOauthCode)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimpUninitialized"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionMailchimpUninitialized(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimpUninitialized? value
    )
    {
        if (Type == "createFlowsVaultConnectionMailchimpUninitialized")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimpUninitialized)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimpApiKey,
            T
        > onCreateFlowsVaultConnectionMailchimpApiKey,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimpOauthCode,
            T
        > onCreateFlowsVaultConnectionMailchimpOauthCode,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimpUninitialized,
            T
        > onCreateFlowsVaultConnectionMailchimpUninitialized
    )
    {
        return Type switch
        {
            "createFlowsVaultConnectionMailchimpApiKey" =>
                onCreateFlowsVaultConnectionMailchimpApiKey(
                    AsCreateFlowsVaultConnectionMailchimpApiKey()
                ),
            "createFlowsVaultConnectionMailchimpOauthCode" =>
                onCreateFlowsVaultConnectionMailchimpOauthCode(
                    AsCreateFlowsVaultConnectionMailchimpOauthCode()
                ),
            "createFlowsVaultConnectionMailchimpUninitialized" =>
                onCreateFlowsVaultConnectionMailchimpUninitialized(
                    AsCreateFlowsVaultConnectionMailchimpUninitialized()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimpApiKey> onCreateFlowsVaultConnectionMailchimpApiKey,
        System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimpOauthCode> onCreateFlowsVaultConnectionMailchimpOauthCode,
        System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimpUninitialized> onCreateFlowsVaultConnectionMailchimpUninitialized
    )
    {
        switch (Type)
        {
            case "createFlowsVaultConnectionMailchimpApiKey":
                onCreateFlowsVaultConnectionMailchimpApiKey(
                    AsCreateFlowsVaultConnectionMailchimpApiKey()
                );
                break;
            case "createFlowsVaultConnectionMailchimpOauthCode":
                onCreateFlowsVaultConnectionMailchimpOauthCode(
                    AsCreateFlowsVaultConnectionMailchimpOauthCode()
                );
                break;
            case "createFlowsVaultConnectionMailchimpUninitialized":
                onCreateFlowsVaultConnectionMailchimpUninitialized(
                    AsCreateFlowsVaultConnectionMailchimpUninitialized()
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
        if (obj is not CreateFlowsVaultConnectionMailchimp other)
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

    public static implicit operator CreateFlowsVaultConnectionMailchimp(
        Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimpApiKey value
    ) => new("createFlowsVaultConnectionMailchimpApiKey", value);

    public static implicit operator CreateFlowsVaultConnectionMailchimp(
        Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimpOauthCode value
    ) => new("createFlowsVaultConnectionMailchimpOauthCode", value);

    public static implicit operator CreateFlowsVaultConnectionMailchimp(
        Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimpUninitialized value
    ) => new("createFlowsVaultConnectionMailchimpUninitialized", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CreateFlowsVaultConnectionMailchimp>
    {
        public override CreateFlowsVaultConnectionMailchimp? Read(
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
                        "createFlowsVaultConnectionMailchimpApiKey",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimpApiKey)
                    ),
                    (
                        "createFlowsVaultConnectionMailchimpOauthCode",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimpOauthCode)
                    ),
                    (
                        "createFlowsVaultConnectionMailchimpUninitialized",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionMailchimpUninitialized)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            CreateFlowsVaultConnectionMailchimp result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into CreateFlowsVaultConnectionMailchimp"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateFlowsVaultConnectionMailchimp value,
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

        public override CreateFlowsVaultConnectionMailchimp ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            CreateFlowsVaultConnectionMailchimp result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateFlowsVaultConnectionMailchimp value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
