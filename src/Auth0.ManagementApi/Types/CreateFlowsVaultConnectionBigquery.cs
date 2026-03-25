// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(CreateFlowsVaultConnectionBigquery.JsonConverter))]
[Serializable]
public class CreateFlowsVaultConnectionBigquery
{
    private CreateFlowsVaultConnectionBigquery(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionBigqueryJwt value.
    /// </summary>
    public static CreateFlowsVaultConnectionBigquery FromCreateFlowsVaultConnectionBigqueryJwt(
        Auth0.ManagementApi.CreateFlowsVaultConnectionBigqueryJwt value
    ) => new("createFlowsVaultConnectionBigqueryJwt", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionBigqueryUninitialized value.
    /// </summary>
    public static CreateFlowsVaultConnectionBigquery FromCreateFlowsVaultConnectionBigqueryUninitialized(
        Auth0.ManagementApi.CreateFlowsVaultConnectionBigqueryUninitialized value
    ) => new("createFlowsVaultConnectionBigqueryUninitialized", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionBigqueryJwt"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionBigqueryJwt() =>
        Type == "createFlowsVaultConnectionBigqueryJwt";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionBigqueryUninitialized"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionBigqueryUninitialized() =>
        Type == "createFlowsVaultConnectionBigqueryUninitialized";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionBigqueryJwt"/> if <see cref="Type"/> is 'createFlowsVaultConnectionBigqueryJwt', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionBigqueryJwt'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionBigqueryJwt AsCreateFlowsVaultConnectionBigqueryJwt() =>
        IsCreateFlowsVaultConnectionBigqueryJwt()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionBigqueryJwt)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionBigqueryJwt'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionBigqueryUninitialized"/> if <see cref="Type"/> is 'createFlowsVaultConnectionBigqueryUninitialized', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionBigqueryUninitialized'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionBigqueryUninitialized AsCreateFlowsVaultConnectionBigqueryUninitialized() =>
        IsCreateFlowsVaultConnectionBigqueryUninitialized()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionBigqueryUninitialized)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionBigqueryUninitialized'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionBigqueryJwt"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionBigqueryJwt(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionBigqueryJwt? value
    )
    {
        if (Type == "createFlowsVaultConnectionBigqueryJwt")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionBigqueryJwt)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionBigqueryUninitialized"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionBigqueryUninitialized(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionBigqueryUninitialized? value
    )
    {
        if (Type == "createFlowsVaultConnectionBigqueryUninitialized")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionBigqueryUninitialized)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionBigqueryJwt,
            T
        > onCreateFlowsVaultConnectionBigqueryJwt,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionBigqueryUninitialized,
            T
        > onCreateFlowsVaultConnectionBigqueryUninitialized
    )
    {
        return Type switch
        {
            "createFlowsVaultConnectionBigqueryJwt" => onCreateFlowsVaultConnectionBigqueryJwt(
                AsCreateFlowsVaultConnectionBigqueryJwt()
            ),
            "createFlowsVaultConnectionBigqueryUninitialized" =>
                onCreateFlowsVaultConnectionBigqueryUninitialized(
                    AsCreateFlowsVaultConnectionBigqueryUninitialized()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionBigqueryJwt> onCreateFlowsVaultConnectionBigqueryJwt,
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionBigqueryUninitialized> onCreateFlowsVaultConnectionBigqueryUninitialized
    )
    {
        switch (Type)
        {
            case "createFlowsVaultConnectionBigqueryJwt":
                onCreateFlowsVaultConnectionBigqueryJwt(AsCreateFlowsVaultConnectionBigqueryJwt());
                break;
            case "createFlowsVaultConnectionBigqueryUninitialized":
                onCreateFlowsVaultConnectionBigqueryUninitialized(
                    AsCreateFlowsVaultConnectionBigqueryUninitialized()
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
        if (obj is not CreateFlowsVaultConnectionBigquery other)
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

    public static implicit operator CreateFlowsVaultConnectionBigquery(
        Auth0.ManagementApi.CreateFlowsVaultConnectionBigqueryJwt value
    ) => new("createFlowsVaultConnectionBigqueryJwt", value);

    public static implicit operator CreateFlowsVaultConnectionBigquery(
        Auth0.ManagementApi.CreateFlowsVaultConnectionBigqueryUninitialized value
    ) => new("createFlowsVaultConnectionBigqueryUninitialized", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CreateFlowsVaultConnectionBigquery>
    {
        public override CreateFlowsVaultConnectionBigquery? Read(
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
                        "createFlowsVaultConnectionBigqueryJwt",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionBigqueryJwt)
                    ),
                    (
                        "createFlowsVaultConnectionBigqueryUninitialized",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionBigqueryUninitialized)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            CreateFlowsVaultConnectionBigquery result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into CreateFlowsVaultConnectionBigquery"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateFlowsVaultConnectionBigquery value,
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

        public override CreateFlowsVaultConnectionBigquery ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            CreateFlowsVaultConnectionBigquery result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateFlowsVaultConnectionBigquery value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
