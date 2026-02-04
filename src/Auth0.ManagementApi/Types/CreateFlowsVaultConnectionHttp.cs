// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

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
            "createFlowsVaultConnectionHttpUninitialized" =>
                onCreateFlowsVaultConnectionHttpUninitialized(
                    AsCreateFlowsVaultConnectionHttpUninitialized()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionHttpBearer> onCreateFlowsVaultConnectionHttpBearer,
        System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionHttpUninitialized> onCreateFlowsVaultConnectionHttpUninitialized
    )
    {
        switch (Type)
        {
            case "createFlowsVaultConnectionHttpBearer":
                onCreateFlowsVaultConnectionHttpBearer(AsCreateFlowsVaultConnectionHttpBearer());
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
        Auth0.ManagementApi.CreateFlowsVaultConnectionHttpUninitialized value
    ) => new("createFlowsVaultConnectionHttpUninitialized", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CreateFlowsVaultConnectionHttp>
    {
        public override CreateFlowsVaultConnectionHttp? Read(
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
                        "createFlowsVaultConnectionHttpBearer",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionHttpBearer)
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
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override CreateFlowsVaultConnectionHttp ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
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
