// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(GetDefaultDomainResponseContent.JsonConverter))]
[Serializable]
public class GetDefaultDomainResponseContent
{
    private GetDefaultDomainResponseContent(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.GetDefaultCustomDomainResponseContent value.
    /// </summary>
    public static GetDefaultDomainResponseContent FromGetDefaultCustomDomainResponseContent(
        Auth0.ManagementApi.GetDefaultCustomDomainResponseContent value
    ) => new("getDefaultCustomDomainResponseContent", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.GetDefaultCanonicalDomainResponseContent value.
    /// </summary>
    public static GetDefaultDomainResponseContent FromGetDefaultCanonicalDomainResponseContent(
        Auth0.ManagementApi.GetDefaultCanonicalDomainResponseContent value
    ) => new("getDefaultCanonicalDomainResponseContent", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "getDefaultCustomDomainResponseContent"
    /// </summary>
    public bool IsGetDefaultCustomDomainResponseContent() =>
        Type == "getDefaultCustomDomainResponseContent";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "getDefaultCanonicalDomainResponseContent"
    /// </summary>
    public bool IsGetDefaultCanonicalDomainResponseContent() =>
        Type == "getDefaultCanonicalDomainResponseContent";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.GetDefaultCustomDomainResponseContent"/> if <see cref="Type"/> is 'getDefaultCustomDomainResponseContent', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'getDefaultCustomDomainResponseContent'.</exception>
    public Auth0.ManagementApi.GetDefaultCustomDomainResponseContent AsGetDefaultCustomDomainResponseContent() =>
        IsGetDefaultCustomDomainResponseContent()
            ? (Auth0.ManagementApi.GetDefaultCustomDomainResponseContent)Value!
            : throw new ManagementException(
                "Union type is not 'getDefaultCustomDomainResponseContent'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.GetDefaultCanonicalDomainResponseContent"/> if <see cref="Type"/> is 'getDefaultCanonicalDomainResponseContent', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'getDefaultCanonicalDomainResponseContent'.</exception>
    public Auth0.ManagementApi.GetDefaultCanonicalDomainResponseContent AsGetDefaultCanonicalDomainResponseContent() =>
        IsGetDefaultCanonicalDomainResponseContent()
            ? (Auth0.ManagementApi.GetDefaultCanonicalDomainResponseContent)Value!
            : throw new ManagementException(
                "Union type is not 'getDefaultCanonicalDomainResponseContent'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.GetDefaultCustomDomainResponseContent"/> and returns true if successful.
    /// </summary>
    public bool TryGetGetDefaultCustomDomainResponseContent(
        out Auth0.ManagementApi.GetDefaultCustomDomainResponseContent? value
    )
    {
        if (Type == "getDefaultCustomDomainResponseContent")
        {
            value = (Auth0.ManagementApi.GetDefaultCustomDomainResponseContent)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.GetDefaultCanonicalDomainResponseContent"/> and returns true if successful.
    /// </summary>
    public bool TryGetGetDefaultCanonicalDomainResponseContent(
        out Auth0.ManagementApi.GetDefaultCanonicalDomainResponseContent? value
    )
    {
        if (Type == "getDefaultCanonicalDomainResponseContent")
        {
            value = (Auth0.ManagementApi.GetDefaultCanonicalDomainResponseContent)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.GetDefaultCustomDomainResponseContent,
            T
        > onGetDefaultCustomDomainResponseContent,
        Func<
            Auth0.ManagementApi.GetDefaultCanonicalDomainResponseContent,
            T
        > onGetDefaultCanonicalDomainResponseContent
    )
    {
        return Type switch
        {
            "getDefaultCustomDomainResponseContent" => onGetDefaultCustomDomainResponseContent(
                AsGetDefaultCustomDomainResponseContent()
            ),
            "getDefaultCanonicalDomainResponseContent" =>
                onGetDefaultCanonicalDomainResponseContent(
                    AsGetDefaultCanonicalDomainResponseContent()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.GetDefaultCustomDomainResponseContent> onGetDefaultCustomDomainResponseContent,
        global::System.Action<Auth0.ManagementApi.GetDefaultCanonicalDomainResponseContent> onGetDefaultCanonicalDomainResponseContent
    )
    {
        switch (Type)
        {
            case "getDefaultCustomDomainResponseContent":
                onGetDefaultCustomDomainResponseContent(AsGetDefaultCustomDomainResponseContent());
                break;
            case "getDefaultCanonicalDomainResponseContent":
                onGetDefaultCanonicalDomainResponseContent(
                    AsGetDefaultCanonicalDomainResponseContent()
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
        if (obj is not GetDefaultDomainResponseContent other)
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

    public static implicit operator GetDefaultDomainResponseContent(
        Auth0.ManagementApi.GetDefaultCustomDomainResponseContent value
    ) => new("getDefaultCustomDomainResponseContent", value);

    public static implicit operator GetDefaultDomainResponseContent(
        Auth0.ManagementApi.GetDefaultCanonicalDomainResponseContent value
    ) => new("getDefaultCanonicalDomainResponseContent", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<GetDefaultDomainResponseContent>
    {
        public override GetDefaultDomainResponseContent? Read(
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
                        "getDefaultCustomDomainResponseContent",
                        typeof(Auth0.ManagementApi.GetDefaultCustomDomainResponseContent)
                    ),
                    (
                        "getDefaultCanonicalDomainResponseContent",
                        typeof(Auth0.ManagementApi.GetDefaultCanonicalDomainResponseContent)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            GetDefaultDomainResponseContent result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into GetDefaultDomainResponseContent"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            GetDefaultDomainResponseContent value,
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

        public override GetDefaultDomainResponseContent ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            GetDefaultDomainResponseContent result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            GetDefaultDomainResponseContent value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
