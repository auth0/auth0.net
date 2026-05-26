// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(PatchRateLimitPolicyConfigurationRequestContent.JsonConverter))]
[Serializable]
public class PatchRateLimitPolicyConfigurationRequestContent
{
    private PatchRateLimitPolicyConfigurationRequestContent(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.PatchRateLimitPolicyConfigurationRequestContentZero value.
    /// </summary>
    public static PatchRateLimitPolicyConfigurationRequestContent FromPatchRateLimitPolicyConfigurationRequestContentZero(
        Auth0.ManagementApi.PatchRateLimitPolicyConfigurationRequestContentZero value
    ) => new("patchRateLimitPolicyConfigurationRequestContentZero", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.PatchRateLimitPolicyConfigurationRequestContentOne value.
    /// </summary>
    public static PatchRateLimitPolicyConfigurationRequestContent FromPatchRateLimitPolicyConfigurationRequestContentOne(
        Auth0.ManagementApi.PatchRateLimitPolicyConfigurationRequestContentOne value
    ) => new("patchRateLimitPolicyConfigurationRequestContentOne", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.PatchRateLimitPolicyConfigurationRequestContentAction value.
    /// </summary>
    public static PatchRateLimitPolicyConfigurationRequestContent FromPatchRateLimitPolicyConfigurationRequestContentAction(
        Auth0.ManagementApi.PatchRateLimitPolicyConfigurationRequestContentAction value
    ) => new("patchRateLimitPolicyConfigurationRequestContentAction", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "patchRateLimitPolicyConfigurationRequestContentZero"
    /// </summary>
    public bool IsPatchRateLimitPolicyConfigurationRequestContentZero() =>
        Type == "patchRateLimitPolicyConfigurationRequestContentZero";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "patchRateLimitPolicyConfigurationRequestContentOne"
    /// </summary>
    public bool IsPatchRateLimitPolicyConfigurationRequestContentOne() =>
        Type == "patchRateLimitPolicyConfigurationRequestContentOne";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "patchRateLimitPolicyConfigurationRequestContentAction"
    /// </summary>
    public bool IsPatchRateLimitPolicyConfigurationRequestContentAction() =>
        Type == "patchRateLimitPolicyConfigurationRequestContentAction";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.PatchRateLimitPolicyConfigurationRequestContentZero"/> if <see cref="Type"/> is 'patchRateLimitPolicyConfigurationRequestContentZero', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'patchRateLimitPolicyConfigurationRequestContentZero'.</exception>
    public Auth0.ManagementApi.PatchRateLimitPolicyConfigurationRequestContentZero AsPatchRateLimitPolicyConfigurationRequestContentZero() =>
        IsPatchRateLimitPolicyConfigurationRequestContentZero()
            ? (Auth0.ManagementApi.PatchRateLimitPolicyConfigurationRequestContentZero)Value!
            : throw new ManagementException(
                "Union type is not 'patchRateLimitPolicyConfigurationRequestContentZero'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.PatchRateLimitPolicyConfigurationRequestContentOne"/> if <see cref="Type"/> is 'patchRateLimitPolicyConfigurationRequestContentOne', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'patchRateLimitPolicyConfigurationRequestContentOne'.</exception>
    public Auth0.ManagementApi.PatchRateLimitPolicyConfigurationRequestContentOne AsPatchRateLimitPolicyConfigurationRequestContentOne() =>
        IsPatchRateLimitPolicyConfigurationRequestContentOne()
            ? (Auth0.ManagementApi.PatchRateLimitPolicyConfigurationRequestContentOne)Value!
            : throw new ManagementException(
                "Union type is not 'patchRateLimitPolicyConfigurationRequestContentOne'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.PatchRateLimitPolicyConfigurationRequestContentAction"/> if <see cref="Type"/> is 'patchRateLimitPolicyConfigurationRequestContentAction', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'patchRateLimitPolicyConfigurationRequestContentAction'.</exception>
    public Auth0.ManagementApi.PatchRateLimitPolicyConfigurationRequestContentAction AsPatchRateLimitPolicyConfigurationRequestContentAction() =>
        IsPatchRateLimitPolicyConfigurationRequestContentAction()
            ? (Auth0.ManagementApi.PatchRateLimitPolicyConfigurationRequestContentAction)Value!
            : throw new ManagementException(
                "Union type is not 'patchRateLimitPolicyConfigurationRequestContentAction'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.PatchRateLimitPolicyConfigurationRequestContentZero"/> and returns true if successful.
    /// </summary>
    public bool TryGetPatchRateLimitPolicyConfigurationRequestContentZero(
        out Auth0.ManagementApi.PatchRateLimitPolicyConfigurationRequestContentZero? value
    )
    {
        if (Type == "patchRateLimitPolicyConfigurationRequestContentZero")
        {
            value = (Auth0.ManagementApi.PatchRateLimitPolicyConfigurationRequestContentZero)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.PatchRateLimitPolicyConfigurationRequestContentOne"/> and returns true if successful.
    /// </summary>
    public bool TryGetPatchRateLimitPolicyConfigurationRequestContentOne(
        out Auth0.ManagementApi.PatchRateLimitPolicyConfigurationRequestContentOne? value
    )
    {
        if (Type == "patchRateLimitPolicyConfigurationRequestContentOne")
        {
            value = (Auth0.ManagementApi.PatchRateLimitPolicyConfigurationRequestContentOne)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.PatchRateLimitPolicyConfigurationRequestContentAction"/> and returns true if successful.
    /// </summary>
    public bool TryGetPatchRateLimitPolicyConfigurationRequestContentAction(
        out Auth0.ManagementApi.PatchRateLimitPolicyConfigurationRequestContentAction? value
    )
    {
        if (Type == "patchRateLimitPolicyConfigurationRequestContentAction")
        {
            value = (Auth0.ManagementApi.PatchRateLimitPolicyConfigurationRequestContentAction)
                Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.PatchRateLimitPolicyConfigurationRequestContentZero,
            T
        > onPatchRateLimitPolicyConfigurationRequestContentZero,
        Func<
            Auth0.ManagementApi.PatchRateLimitPolicyConfigurationRequestContentOne,
            T
        > onPatchRateLimitPolicyConfigurationRequestContentOne,
        Func<
            Auth0.ManagementApi.PatchRateLimitPolicyConfigurationRequestContentAction,
            T
        > onPatchRateLimitPolicyConfigurationRequestContentAction
    )
    {
        return Type switch
        {
            "patchRateLimitPolicyConfigurationRequestContentZero" =>
                onPatchRateLimitPolicyConfigurationRequestContentZero(
                    AsPatchRateLimitPolicyConfigurationRequestContentZero()
                ),
            "patchRateLimitPolicyConfigurationRequestContentOne" =>
                onPatchRateLimitPolicyConfigurationRequestContentOne(
                    AsPatchRateLimitPolicyConfigurationRequestContentOne()
                ),
            "patchRateLimitPolicyConfigurationRequestContentAction" =>
                onPatchRateLimitPolicyConfigurationRequestContentAction(
                    AsPatchRateLimitPolicyConfigurationRequestContentAction()
                ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.PatchRateLimitPolicyConfigurationRequestContentZero> onPatchRateLimitPolicyConfigurationRequestContentZero,
        global::System.Action<Auth0.ManagementApi.PatchRateLimitPolicyConfigurationRequestContentOne> onPatchRateLimitPolicyConfigurationRequestContentOne,
        global::System.Action<Auth0.ManagementApi.PatchRateLimitPolicyConfigurationRequestContentAction> onPatchRateLimitPolicyConfigurationRequestContentAction
    )
    {
        switch (Type)
        {
            case "patchRateLimitPolicyConfigurationRequestContentZero":
                onPatchRateLimitPolicyConfigurationRequestContentZero(
                    AsPatchRateLimitPolicyConfigurationRequestContentZero()
                );
                break;
            case "patchRateLimitPolicyConfigurationRequestContentOne":
                onPatchRateLimitPolicyConfigurationRequestContentOne(
                    AsPatchRateLimitPolicyConfigurationRequestContentOne()
                );
                break;
            case "patchRateLimitPolicyConfigurationRequestContentAction":
                onPatchRateLimitPolicyConfigurationRequestContentAction(
                    AsPatchRateLimitPolicyConfigurationRequestContentAction()
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
        if (obj is not PatchRateLimitPolicyConfigurationRequestContent other)
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

    public static implicit operator PatchRateLimitPolicyConfigurationRequestContent(
        Auth0.ManagementApi.PatchRateLimitPolicyConfigurationRequestContentZero value
    ) => new("patchRateLimitPolicyConfigurationRequestContentZero", value);

    public static implicit operator PatchRateLimitPolicyConfigurationRequestContent(
        Auth0.ManagementApi.PatchRateLimitPolicyConfigurationRequestContentOne value
    ) => new("patchRateLimitPolicyConfigurationRequestContentOne", value);

    public static implicit operator PatchRateLimitPolicyConfigurationRequestContent(
        Auth0.ManagementApi.PatchRateLimitPolicyConfigurationRequestContentAction value
    ) => new("patchRateLimitPolicyConfigurationRequestContentAction", value);

    [Serializable]
    internal sealed class JsonConverter
        : JsonConverter<PatchRateLimitPolicyConfigurationRequestContent>
    {
        public override PatchRateLimitPolicyConfigurationRequestContent? Read(
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
                        "patchRateLimitPolicyConfigurationRequestContentZero",
                        typeof(Auth0.ManagementApi.PatchRateLimitPolicyConfigurationRequestContentZero)
                    ),
                    (
                        "patchRateLimitPolicyConfigurationRequestContentOne",
                        typeof(Auth0.ManagementApi.PatchRateLimitPolicyConfigurationRequestContentOne)
                    ),
                    (
                        "patchRateLimitPolicyConfigurationRequestContentAction",
                        typeof(Auth0.ManagementApi.PatchRateLimitPolicyConfigurationRequestContentAction)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            PatchRateLimitPolicyConfigurationRequestContent result = new(
                                key,
                                value
                            );
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
                $"Cannot deserialize JSON token {reader.TokenType} into PatchRateLimitPolicyConfigurationRequestContent"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            PatchRateLimitPolicyConfigurationRequestContent value,
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

        public override PatchRateLimitPolicyConfigurationRequestContent ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            PatchRateLimitPolicyConfigurationRequestContent result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            PatchRateLimitPolicyConfigurationRequestContent value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
