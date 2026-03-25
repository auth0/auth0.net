// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi;
using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi.Jobs;

[JsonConverter(typeof(ErrorsGetResponse.JsonConverter))]
[Serializable]
public class ErrorsGetResponse
{
    private ErrorsGetResponse(string type, object? value)
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
    /// Factory method to create a union from a IEnumerable<GetJobErrorResponseContent> value.
    /// </summary>
    public static ErrorsGetResponse FromListOfGetJobErrorResponseContent(
        IEnumerable<GetJobErrorResponseContent> value
    ) => new("list", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.GetJobGenericErrorResponseContent value.
    /// </summary>
    public static ErrorsGetResponse FromGetJobGenericErrorResponseContent(
        Auth0.ManagementApi.GetJobGenericErrorResponseContent value
    ) => new("getJobGenericErrorResponseContent", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "list"
    /// </summary>
    public bool IsListOfGetJobErrorResponseContent() => Type == "list";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "getJobGenericErrorResponseContent"
    /// </summary>
    public bool IsGetJobGenericErrorResponseContent() =>
        Type == "getJobGenericErrorResponseContent";

    /// <summary>
    /// Returns the value as a <see cref="IEnumerable<GetJobErrorResponseContent>"/> if <see cref="Type"/> is 'list', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'list'.</exception>
    public IEnumerable<GetJobErrorResponseContent> AsListOfGetJobErrorResponseContent() =>
        IsListOfGetJobErrorResponseContent()
            ? (IEnumerable<GetJobErrorResponseContent>)Value!
            : throw new ManagementException("Union type is not 'list'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.GetJobGenericErrorResponseContent"/> if <see cref="Type"/> is 'getJobGenericErrorResponseContent', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'getJobGenericErrorResponseContent'.</exception>
    public Auth0.ManagementApi.GetJobGenericErrorResponseContent AsGetJobGenericErrorResponseContent() =>
        IsGetJobGenericErrorResponseContent()
            ? (Auth0.ManagementApi.GetJobGenericErrorResponseContent)Value!
            : throw new ManagementException(
                "Union type is not 'getJobGenericErrorResponseContent'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="IEnumerable<GetJobErrorResponseContent>"/> and returns true if successful.
    /// </summary>
    public bool TryGetListOfGetJobErrorResponseContent(
        out IEnumerable<GetJobErrorResponseContent>? value
    )
    {
        if (Type == "list")
        {
            value = (IEnumerable<GetJobErrorResponseContent>)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.GetJobGenericErrorResponseContent"/> and returns true if successful.
    /// </summary>
    public bool TryGetGetJobGenericErrorResponseContent(
        out Auth0.ManagementApi.GetJobGenericErrorResponseContent? value
    )
    {
        if (Type == "getJobGenericErrorResponseContent")
        {
            value = (Auth0.ManagementApi.GetJobGenericErrorResponseContent)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<IEnumerable<GetJobErrorResponseContent>, T> onListOfGetJobErrorResponseContent,
        Func<
            Auth0.ManagementApi.GetJobGenericErrorResponseContent,
            T
        > onGetJobGenericErrorResponseContent
    )
    {
        return Type switch
        {
            "list" => onListOfGetJobErrorResponseContent(AsListOfGetJobErrorResponseContent()),
            "getJobGenericErrorResponseContent" => onGetJobGenericErrorResponseContent(
                AsGetJobGenericErrorResponseContent()
            ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<
            IEnumerable<GetJobErrorResponseContent>
        > onListOfGetJobErrorResponseContent,
        global::System.Action<Auth0.ManagementApi.GetJobGenericErrorResponseContent> onGetJobGenericErrorResponseContent
    )
    {
        switch (Type)
        {
            case "list":
                onListOfGetJobErrorResponseContent(AsListOfGetJobErrorResponseContent());
                break;
            case "getJobGenericErrorResponseContent":
                onGetJobGenericErrorResponseContent(AsGetJobGenericErrorResponseContent());
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
        if (obj is not ErrorsGetResponse other)
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

    public static implicit operator ErrorsGetResponse(
        Auth0.ManagementApi.GetJobGenericErrorResponseContent value
    ) => new("getJobGenericErrorResponseContent", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<ErrorsGetResponse>
    {
        public override ErrorsGetResponse? Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            if (reader.TokenType == JsonTokenType.Null)
            {
                return null;
            }

            if (reader.TokenType == JsonTokenType.StartArray)
            {
                var document = JsonDocument.ParseValue(ref reader);

                var types = new (string Key, System.Type Type)[]
                {
                    ("list", typeof(IEnumerable<GetJobErrorResponseContent>)),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            ErrorsGetResponse result = new(key, value);
                            return result;
                        }
                    }
                    catch (JsonException)
                    {
                        // Try next type;
                    }
                }
            }

            if (reader.TokenType == JsonTokenType.StartObject)
            {
                var document = JsonDocument.ParseValue(ref reader);

                var types = new (string Key, System.Type Type)[]
                {
                    (
                        "getJobGenericErrorResponseContent",
                        typeof(Auth0.ManagementApi.GetJobGenericErrorResponseContent)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            ErrorsGetResponse result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into ErrorsGetResponse"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            ErrorsGetResponse value,
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

        public override ErrorsGetResponse ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            ErrorsGetResponse result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ErrorsGetResponse value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
