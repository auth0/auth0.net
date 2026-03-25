// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(CreateFlowsVaultConnectionAuth0.JsonConverter))]
[Serializable]
public class CreateFlowsVaultConnectionAuth0
{
    private CreateFlowsVaultConnectionAuth0(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionAuth0OauthApp value.
    /// </summary>
    public static CreateFlowsVaultConnectionAuth0 FromCreateFlowsVaultConnectionAuth0OauthApp(
        Auth0.ManagementApi.CreateFlowsVaultConnectionAuth0OauthApp value
    ) => new("createFlowsVaultConnectionAuth0OauthApp", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.CreateFlowsVaultConnectionAuth0Uninitialized value.
    /// </summary>
    public static CreateFlowsVaultConnectionAuth0 FromCreateFlowsVaultConnectionAuth0Uninitialized(
        Auth0.ManagementApi.CreateFlowsVaultConnectionAuth0Uninitialized value
    ) => new("createFlowsVaultConnectionAuth0Uninitialized", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionAuth0OauthApp"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionAuth0OauthApp() =>
        Type == "createFlowsVaultConnectionAuth0OauthApp";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "createFlowsVaultConnectionAuth0Uninitialized"
    /// </summary>
    public bool IsCreateFlowsVaultConnectionAuth0Uninitialized() =>
        Type == "createFlowsVaultConnectionAuth0Uninitialized";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionAuth0OauthApp"/> if <see cref="Type"/> is 'createFlowsVaultConnectionAuth0OauthApp', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionAuth0OauthApp'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionAuth0OauthApp AsCreateFlowsVaultConnectionAuth0OauthApp() =>
        IsCreateFlowsVaultConnectionAuth0OauthApp()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionAuth0OauthApp)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionAuth0OauthApp'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionAuth0Uninitialized"/> if <see cref="Type"/> is 'createFlowsVaultConnectionAuth0Uninitialized', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'createFlowsVaultConnectionAuth0Uninitialized'.</exception>
    public Auth0.ManagementApi.CreateFlowsVaultConnectionAuth0Uninitialized AsCreateFlowsVaultConnectionAuth0Uninitialized() =>
        IsCreateFlowsVaultConnectionAuth0Uninitialized()
            ? (Auth0.ManagementApi.CreateFlowsVaultConnectionAuth0Uninitialized)Value!
            : throw new ManagementException(
                "Union type is not 'createFlowsVaultConnectionAuth0Uninitialized'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionAuth0OauthApp"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionAuth0OauthApp(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionAuth0OauthApp? value
    )
    {
        if (Type == "createFlowsVaultConnectionAuth0OauthApp")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionAuth0OauthApp)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.CreateFlowsVaultConnectionAuth0Uninitialized"/> and returns true if successful.
    /// </summary>
    public bool TryGetCreateFlowsVaultConnectionAuth0Uninitialized(
        out Auth0.ManagementApi.CreateFlowsVaultConnectionAuth0Uninitialized? value
    )
    {
        if (Type == "createFlowsVaultConnectionAuth0Uninitialized")
        {
            value = (Auth0.ManagementApi.CreateFlowsVaultConnectionAuth0Uninitialized)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionAuth0OauthApp,
            T
        > onCreateFlowsVaultConnectionAuth0OauthApp,
        Func<
            Auth0.ManagementApi.CreateFlowsVaultConnectionAuth0Uninitialized,
            T
        > onCreateFlowsVaultConnectionAuth0Uninitialized
    )
    {
        return Type switch
        {
            "createFlowsVaultConnectionAuth0OauthApp" => onCreateFlowsVaultConnectionAuth0OauthApp(
                AsCreateFlowsVaultConnectionAuth0OauthApp()
            ),
            "createFlowsVaultConnectionAuth0Uninitialized" =>
                onCreateFlowsVaultConnectionAuth0Uninitialized(
                    AsCreateFlowsVaultConnectionAuth0Uninitialized()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionAuth0OauthApp> onCreateFlowsVaultConnectionAuth0OauthApp,
        global::System.Action<Auth0.ManagementApi.CreateFlowsVaultConnectionAuth0Uninitialized> onCreateFlowsVaultConnectionAuth0Uninitialized
    )
    {
        switch (Type)
        {
            case "createFlowsVaultConnectionAuth0OauthApp":
                onCreateFlowsVaultConnectionAuth0OauthApp(
                    AsCreateFlowsVaultConnectionAuth0OauthApp()
                );
                break;
            case "createFlowsVaultConnectionAuth0Uninitialized":
                onCreateFlowsVaultConnectionAuth0Uninitialized(
                    AsCreateFlowsVaultConnectionAuth0Uninitialized()
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
        if (obj is not CreateFlowsVaultConnectionAuth0 other)
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

    public static implicit operator CreateFlowsVaultConnectionAuth0(
        Auth0.ManagementApi.CreateFlowsVaultConnectionAuth0OauthApp value
    ) => new("createFlowsVaultConnectionAuth0OauthApp", value);

    public static implicit operator CreateFlowsVaultConnectionAuth0(
        Auth0.ManagementApi.CreateFlowsVaultConnectionAuth0Uninitialized value
    ) => new("createFlowsVaultConnectionAuth0Uninitialized", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<CreateFlowsVaultConnectionAuth0>
    {
        public override CreateFlowsVaultConnectionAuth0? Read(
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
                        "createFlowsVaultConnectionAuth0OauthApp",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionAuth0OauthApp)
                    ),
                    (
                        "createFlowsVaultConnectionAuth0Uninitialized",
                        typeof(Auth0.ManagementApi.CreateFlowsVaultConnectionAuth0Uninitialized)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            CreateFlowsVaultConnectionAuth0 result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into CreateFlowsVaultConnectionAuth0"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            CreateFlowsVaultConnectionAuth0 value,
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

        public override CreateFlowsVaultConnectionAuth0 ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            CreateFlowsVaultConnectionAuth0 result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            CreateFlowsVaultConnectionAuth0 value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
