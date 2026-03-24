// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using System.Text.Json;
using System.Text.Json.Serialization;
using Auth0.ManagementApi.Core;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(UpdateDefaultDomainResponseContent.JsonConverter))]
[Serializable]
public class UpdateDefaultDomainResponseContent
{
    private UpdateDefaultDomainResponseContent(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.UpdateDefaultCustomDomainResponseContent value.
    /// </summary>
    public static UpdateDefaultDomainResponseContent FromUpdateDefaultCustomDomainResponseContent(
        Auth0.ManagementApi.UpdateDefaultCustomDomainResponseContent value
    ) => new("updateDefaultCustomDomainResponseContent", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.UpdateDefaultCanonicalDomainResponseContent value.
    /// </summary>
    public static UpdateDefaultDomainResponseContent FromUpdateDefaultCanonicalDomainResponseContent(
        Auth0.ManagementApi.UpdateDefaultCanonicalDomainResponseContent value
    ) => new("updateDefaultCanonicalDomainResponseContent", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "updateDefaultCustomDomainResponseContent"
    /// </summary>
    public bool IsUpdateDefaultCustomDomainResponseContent() =>
        Type == "updateDefaultCustomDomainResponseContent";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "updateDefaultCanonicalDomainResponseContent"
    /// </summary>
    public bool IsUpdateDefaultCanonicalDomainResponseContent() =>
        Type == "updateDefaultCanonicalDomainResponseContent";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.UpdateDefaultCustomDomainResponseContent"/> if <see cref="Type"/> is 'updateDefaultCustomDomainResponseContent', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'updateDefaultCustomDomainResponseContent'.</exception>
    public Auth0.ManagementApi.UpdateDefaultCustomDomainResponseContent AsUpdateDefaultCustomDomainResponseContent() =>
        IsUpdateDefaultCustomDomainResponseContent()
            ? (Auth0.ManagementApi.UpdateDefaultCustomDomainResponseContent)Value!
            : throw new ManagementException(
                "Union type is not 'updateDefaultCustomDomainResponseContent'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.UpdateDefaultCanonicalDomainResponseContent"/> if <see cref="Type"/> is 'updateDefaultCanonicalDomainResponseContent', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'updateDefaultCanonicalDomainResponseContent'.</exception>
    public Auth0.ManagementApi.UpdateDefaultCanonicalDomainResponseContent AsUpdateDefaultCanonicalDomainResponseContent() =>
        IsUpdateDefaultCanonicalDomainResponseContent()
            ? (Auth0.ManagementApi.UpdateDefaultCanonicalDomainResponseContent)Value!
            : throw new ManagementException(
                "Union type is not 'updateDefaultCanonicalDomainResponseContent'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.UpdateDefaultCustomDomainResponseContent"/> and returns true if successful.
    /// </summary>
    public bool TryGetUpdateDefaultCustomDomainResponseContent(
        out Auth0.ManagementApi.UpdateDefaultCustomDomainResponseContent? value
    )
    {
        if (Type == "updateDefaultCustomDomainResponseContent")
        {
            value = (Auth0.ManagementApi.UpdateDefaultCustomDomainResponseContent)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.UpdateDefaultCanonicalDomainResponseContent"/> and returns true if successful.
    /// </summary>
    public bool TryGetUpdateDefaultCanonicalDomainResponseContent(
        out Auth0.ManagementApi.UpdateDefaultCanonicalDomainResponseContent? value
    )
    {
        if (Type == "updateDefaultCanonicalDomainResponseContent")
        {
            value = (Auth0.ManagementApi.UpdateDefaultCanonicalDomainResponseContent)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.UpdateDefaultCustomDomainResponseContent,
            T
        > onUpdateDefaultCustomDomainResponseContent,
        Func<
            Auth0.ManagementApi.UpdateDefaultCanonicalDomainResponseContent,
            T
        > onUpdateDefaultCanonicalDomainResponseContent
    )
    {
        return Type switch
        {
            "updateDefaultCustomDomainResponseContent" =>
                onUpdateDefaultCustomDomainResponseContent(
                    AsUpdateDefaultCustomDomainResponseContent()
                ),
            "updateDefaultCanonicalDomainResponseContent" =>
                onUpdateDefaultCanonicalDomainResponseContent(
                    AsUpdateDefaultCanonicalDomainResponseContent()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        System.Action<Auth0.ManagementApi.UpdateDefaultCustomDomainResponseContent> onUpdateDefaultCustomDomainResponseContent,
        System.Action<Auth0.ManagementApi.UpdateDefaultCanonicalDomainResponseContent> onUpdateDefaultCanonicalDomainResponseContent
    )
    {
        switch (Type)
        {
            case "updateDefaultCustomDomainResponseContent":
                onUpdateDefaultCustomDomainResponseContent(
                    AsUpdateDefaultCustomDomainResponseContent()
                );
                break;
            case "updateDefaultCanonicalDomainResponseContent":
                onUpdateDefaultCanonicalDomainResponseContent(
                    AsUpdateDefaultCanonicalDomainResponseContent()
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
        if (obj is not UpdateDefaultDomainResponseContent other)
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

    public static implicit operator UpdateDefaultDomainResponseContent(
        Auth0.ManagementApi.UpdateDefaultCustomDomainResponseContent value
    ) => new("updateDefaultCustomDomainResponseContent", value);

    public static implicit operator UpdateDefaultDomainResponseContent(
        Auth0.ManagementApi.UpdateDefaultCanonicalDomainResponseContent value
    ) => new("updateDefaultCanonicalDomainResponseContent", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<UpdateDefaultDomainResponseContent>
    {
        public override UpdateDefaultDomainResponseContent? Read(
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
                        "updateDefaultCustomDomainResponseContent",
                        typeof(Auth0.ManagementApi.UpdateDefaultCustomDomainResponseContent)
                    ),
                    (
                        "updateDefaultCanonicalDomainResponseContent",
                        typeof(Auth0.ManagementApi.UpdateDefaultCanonicalDomainResponseContent)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            UpdateDefaultDomainResponseContent result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into UpdateDefaultDomainResponseContent"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateDefaultDomainResponseContent value,
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

        public override UpdateDefaultDomainResponseContent ReadAsPropertyName(
            ref Utf8JsonReader reader,
            System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            UpdateDefaultDomainResponseContent result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateDefaultDomainResponseContent value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
