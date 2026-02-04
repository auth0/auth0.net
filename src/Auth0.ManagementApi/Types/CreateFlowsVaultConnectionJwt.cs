// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(CreateFlowsVaultConnectionJwt.JsonConverter))]
[Serializable]
public class CreateFlowsVaultConnectionJwt
{
    private CreateFlowsVaultConnectionJwt(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionJwtJwt value.
    /// </summary>
    public static CreateFlowsVaultConnectionJwt FromCreateFlowsVaultConnectionJwtJwt(
        Auth0.ManagementApi.CreateFlowsVaultConnectionJwtJwt value
    ) => new("createFlowsVaultConnectionJwtJwt", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionJwtUninitialized value.
    /// </summary>
    public static CreateFlowsVaultConnectionJwt FromCreateFlowsVaultConnectionJwtUninitialized(
        Auth0.ManagementApi.CreateFlowsVaultConnectionJwtUninitialized value
    ) => new("createFlowsVaultConnectionJwtUninitialized", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionJwtJwt"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionJwtJwt() => Type == "createFlowsVaultConnectionJwtJwt";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionJwtUninitialized"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionJwtUninitialized() =>
        Type == "createFlowsVaultConnectionJwtUninitialized";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionJwtJwt"/> if <see cref="Type"/> is 'createFlowsVaultConnectionJwtJwt', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionJwtJwt'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionJwtJwt AsCreateFlowsVaultConnectionJwtJwt() =>
        IsCreateFlowsVaultConnectionJwtJwt()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionJwtJwt)Value!
            : throw new ManagementException("Union type is not 'createFlowsVaultConnectionJwtJwt'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionJwtUninitialized"/> if <see cref="Type"/> is 'createFlowsVaultConnectionJwtUninitialized', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionJwtUninitialized'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionJwtUninitialized AsCreateFlowsVaultConnectionJwtUninitialized() =>
        IsCreateFlowsVaultConnectionJwtUninitialized()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionJwtUninitialized)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionJwtUninitialized'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionJwtJwt"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionJwtJwt(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionJwtJwt? value
    )
    {
        if (Type == "createFlowsVaultConnectionJwtJwt")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionJwtJwt)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionJwtUninitialized"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionJwtUninitialized(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionJwtUninitialized? value
    )
    {
        if (Type == "createFlowsVaultConnectionJwtUninitialized")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionJwtUninitialized)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionJwtJwt,
            T
        > onCreateFlowsVaultConnectionJwtJwt,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionJwtUninitialized,
            T
        > onCreateFlowsVaultConnectionJwtUninitialized
    )
    {
        return Type switch
        {
            "createFlowsVaultConnectionJwtJwt" => onCreateFlowsVaultConnectionJwtJwt(
                AsCreateFlowsVaultConnectionJwtJwt()
            ),
            "createFlowsVaultConnectionJwtUninitialized" =>
                onCreateFlowsVaultConnectionJwtUninitialized(
                    AsCreateFlowsVaultConnectionJwtUninitialized()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionJwtJwt> onCreateFlowsVaultConnectionJwtJwt,
        System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionJwtUninitialized> onCreateFlowsVaultConnectionJwtUninitialized
    )
    {
        switch (Type)
        {
            case "createFlowsVaultConnectionJwtJwt":
                onCreateFlowsVaultConnectionJwtJwt(AsCreateFlowsVaultConnectionJwtJwt());
                break;
            case "createFlowsVaultConnectionJwtUninitialized":
                onCreateFlowsVaultConnectionJwtUninitialized(
                    AsCreateFlowsVaultConnectionJwtUninitialized()
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
        if (obj is not CreateFlowsVaultConnectionJwt other)
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

    public static implicit operator CreateFlowsVaultConnectionJwt(
        Auth0.ManagementApi.CreateFlowsVaultConnectionJwtJwt value
    ) => new("createFlowsVaultConnectionJwtJwt", value);

    public static implicit operator CreateFlowsVaultConnectionJwt(
        Auth0.ManagementApi.CreateFlowsVaultConnectionJwtUninitialized value
    ) => new("createFlowsVaultConnectionJwtUninitialized", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CreateFlowsVaultConnectionJwt>
    {
        public override CreateFlowsVaultConnectionJwt? Read(
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
                        "createFlowsVaultConnectionJwtJwt",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionJwtJwt)
                    ),
                    (
                        "createFlowsVaultConnectionJwtUninitialized",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionJwtUninitialized)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            CreateFlowsVaultConnectionJwt result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into CreateFlowsVaultConnectionJwt"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateFlowsVaultConnectionJwt value,
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

        public override CreateFlowsVaultConnectionJwt ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            CreateFlowsVaultConnectionJwt result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateFlowsVaultConnectionJwt value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
