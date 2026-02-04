// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(CreateFlowsVaultConnectionGoogleSheets.JsonConverter))]
[Serializable]
public class CreateFlowsVaultConnectionGoogleSheets
{
    private CreateFlowsVaultConnectionGoogleSheets(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionGoogleSheetsOauthCode value.
    /// </summary>
    public static CreateFlowsVaultConnectionGoogleSheets FromCreateFlowsVaultConnectionGoogleSheetsOauthCode(
        Auth0.ManagementApi.CreateFlowsVaultConnectionGoogleSheetsOauthCode value
    ) => new("createFlowsVaultConnectionGoogleSheetsOauthCode", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionGoogleSheetsUninitialized value.
    /// </summary>
    public static CreateFlowsVaultConnectionGoogleSheets FromCreateFlowsVaultConnectionGoogleSheetsUninitialized(
        Auth0.ManagementApi.CreateFlowsVaultConnectionGoogleSheetsUninitialized value
    ) => new("createFlowsVaultConnectionGoogleSheetsUninitialized", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionGoogleSheetsOauthCode"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionGoogleSheetsOauthCode() =>
        Type == "createFlowsVaultConnectionGoogleSheetsOauthCode";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionGoogleSheetsUninitialized"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionGoogleSheetsUninitialized() =>
        Type == "createFlowsVaultConnectionGoogleSheetsUninitialized";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionGoogleSheetsOauthCode"/> if <see cref="Type"/> is 'createFlowsVaultConnectionGoogleSheetsOauthCode', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionGoogleSheetsOauthCode'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionGoogleSheetsOauthCode AsCreateFlowsVaultConnectionGoogleSheetsOauthCode() =>
        IsCreateFlowsVaultConnectionGoogleSheetsOauthCode()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionGoogleSheetsOauthCode)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionGoogleSheetsOauthCode'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionGoogleSheetsUninitialized"/> if <see cref="Type"/> is 'createFlowsVaultConnectionGoogleSheetsUninitialized', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionGoogleSheetsUninitialized'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionGoogleSheetsUninitialized AsCreateFlowsVaultConnectionGoogleSheetsUninitialized() =>
        IsCreateFlowsVaultConnectionGoogleSheetsUninitialized()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionGoogleSheetsUninitialized)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionGoogleSheetsUninitialized'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionGoogleSheetsOauthCode"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionGoogleSheetsOauthCode(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionGoogleSheetsOauthCode? value
    )
    {
        if (Type == "createFlowsVaultConnectionGoogleSheetsOauthCode")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionGoogleSheetsOauthCode)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionGoogleSheetsUninitialized"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionGoogleSheetsUninitialized(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionGoogleSheetsUninitialized? value
    )
    {
        if (Type == "createFlowsVaultConnectionGoogleSheetsUninitialized")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionGoogleSheetsUninitialized)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionGoogleSheetsOauthCode,
            T
        > onCreateFlowsVaultConnectionGoogleSheetsOauthCode,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionGoogleSheetsUninitialized,
            T
        > onCreateFlowsVaultConnectionGoogleSheetsUninitialized
    )
    {
        return Type switch
        {
            "createFlowsVaultConnectionGoogleSheetsOauthCode" =>
                onCreateFlowsVaultConnectionGoogleSheetsOauthCode(
                    AsCreateFlowsVaultConnectionGoogleSheetsOauthCode()
                ),
            "createFlowsVaultConnectionGoogleSheetsUninitialized" =>
                onCreateFlowsVaultConnectionGoogleSheetsUninitialized(
                    AsCreateFlowsVaultConnectionGoogleSheetsUninitialized()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionGoogleSheetsOauthCode> onCreateFlowsVaultConnectionGoogleSheetsOauthCode,
        System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionGoogleSheetsUninitialized> onCreateFlowsVaultConnectionGoogleSheetsUninitialized
    )
    {
        switch (Type)
        {
            case "createFlowsVaultConnectionGoogleSheetsOauthCode":
                onCreateFlowsVaultConnectionGoogleSheetsOauthCode(
                    AsCreateFlowsVaultConnectionGoogleSheetsOauthCode()
                );
                break;
            case "createFlowsVaultConnectionGoogleSheetsUninitialized":
                onCreateFlowsVaultConnectionGoogleSheetsUninitialized(
                    AsCreateFlowsVaultConnectionGoogleSheetsUninitialized()
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
        if (obj is not CreateFlowsVaultConnectionGoogleSheets other)
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

    public static implicit operator CreateFlowsVaultConnectionGoogleSheets(
        Auth0.ManagementApi.CreateFlowsVaultConnectionGoogleSheetsOauthCode value
    ) => new("createFlowsVaultConnectionGoogleSheetsOauthCode", value);

    public static implicit operator CreateFlowsVaultConnectionGoogleSheets(
        Auth0.ManagementApi.CreateFlowsVaultConnectionGoogleSheetsUninitialized value
    ) => new("createFlowsVaultConnectionGoogleSheetsUninitialized", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CreateFlowsVaultConnectionGoogleSheets>
    {
        public override CreateFlowsVaultConnectionGoogleSheets? Read(
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
                        "createFlowsVaultConnectionGoogleSheetsOauthCode",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionGoogleSheetsOauthCode)
                    ),
                    (
                        "createFlowsVaultConnectionGoogleSheetsUninitialized",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionGoogleSheetsUninitialized)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            CreateFlowsVaultConnectionGoogleSheets result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into CreateFlowsVaultConnectionGoogleSheets"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateFlowsVaultConnectionGoogleSheets value,
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

        public override CreateFlowsVaultConnectionGoogleSheets ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            CreateFlowsVaultConnectionGoogleSheets result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateFlowsVaultConnectionGoogleSheets value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
