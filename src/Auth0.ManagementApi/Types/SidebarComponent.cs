// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Nodes;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(SidebarComponent.JsonConverter))]
[Serializable]
public record SidebarComponent
{
    internal SidebarComponent(string type, object? value)
    {
        Type = type;
        Value = value;
    }

    /// <summary>
    /// Create an instance of SidebarComponent with <see cref="SidebarComponent.SidebarComponentAuth0ExternalLink"/>.
    /// </summary>
    public SidebarComponent(SidebarComponent.SidebarComponentAuth0ExternalLink value)
    {
        Type = "sidebar:component:auth0:external_link";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SidebarComponent with <see cref="SidebarComponent.SidebarComponentAuth0InternalLink"/>.
    /// </summary>
    public SidebarComponent(SidebarComponent.SidebarComponentAuth0InternalLink value)
    {
        Type = "sidebar:component:auth0:internal_link";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SidebarComponent with <see cref="SidebarComponent.SidebarComponentAuth0ExternalLinkV2"/>.
    /// </summary>
    public SidebarComponent(SidebarComponent.SidebarComponentAuth0ExternalLinkV2 value)
    {
        Type = "sidebar:component:auth0:external_link:v2";
        Value = value.Value;
    }

    /// <summary>
    /// Create an instance of SidebarComponent with <see cref="SidebarComponent.SidebarComponentAuth0InternalLinkV2"/>.
    /// </summary>
    public SidebarComponent(SidebarComponent.SidebarComponentAuth0InternalLinkV2 value)
    {
        Type = "sidebar:component:auth0:internal_link:v2";
        Value = value.Value;
    }

    /// <summary>
    /// Discriminant value
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; internal set; }

    /// <summary>
    /// Discriminated union value
    /// </summary>
    public object? Value { get; internal set; }

    /// <summary>
    /// Returns true if <see cref="Type"/> is "sidebar:component:auth0:external_link"
    /// </summary>
    public bool IsSidebarComponentAuth0ExternalLink =>
        Type == "sidebar:component:auth0:external_link";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "sidebar:component:auth0:internal_link"
    /// </summary>
    public bool IsSidebarComponentAuth0InternalLink =>
        Type == "sidebar:component:auth0:internal_link";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "sidebar:component:auth0:external_link:v2"
    /// </summary>
    public bool IsSidebarComponentAuth0ExternalLinkV2 =>
        Type == "sidebar:component:auth0:external_link:v2";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "sidebar:component:auth0:internal_link:v2"
    /// </summary>
    public bool IsSidebarComponentAuth0InternalLinkV2 =>
        Type == "sidebar:component:auth0:internal_link:v2";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.SidebarComponentAuth0ExternalLink"/> if <see cref="Type"/> is 'sidebar:component:auth0:external_link', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'sidebar:component:auth0:external_link'.</exception>
    public Auth0.ManagementApi.SidebarComponentAuth0ExternalLink AsSidebarComponentAuth0ExternalLink() =>
        IsSidebarComponentAuth0ExternalLink
            ? (Auth0.ManagementApi.SidebarComponentAuth0ExternalLink)Value!
            : throw new global::System.Exception(
                "SidebarComponent.Type is not 'sidebar:component:auth0:external_link'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.SidebarComponentAuth0InternalLink"/> if <see cref="Type"/> is 'sidebar:component:auth0:internal_link', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'sidebar:component:auth0:internal_link'.</exception>
    public Auth0.ManagementApi.SidebarComponentAuth0InternalLink AsSidebarComponentAuth0InternalLink() =>
        IsSidebarComponentAuth0InternalLink
            ? (Auth0.ManagementApi.SidebarComponentAuth0InternalLink)Value!
            : throw new global::System.Exception(
                "SidebarComponent.Type is not 'sidebar:component:auth0:internal_link'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.SidebarComponentAuth0ExternalLinkV2"/> if <see cref="Type"/> is 'sidebar:component:auth0:external_link:v2', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'sidebar:component:auth0:external_link:v2'.</exception>
    public Auth0.ManagementApi.SidebarComponentAuth0ExternalLinkV2 AsSidebarComponentAuth0ExternalLinkV2() =>
        IsSidebarComponentAuth0ExternalLinkV2
            ? (Auth0.ManagementApi.SidebarComponentAuth0ExternalLinkV2)Value!
            : throw new global::System.Exception(
                "SidebarComponent.Type is not 'sidebar:component:auth0:external_link:v2'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.SidebarComponentAuth0InternalLinkV2"/> if <see cref="Type"/> is 'sidebar:component:auth0:internal_link:v2', otherwise throws an exception.
    /// </summary>
    /// <exception cref="Exception">Thrown when <see cref="Type"/> is not 'sidebar:component:auth0:internal_link:v2'.</exception>
    public Auth0.ManagementApi.SidebarComponentAuth0InternalLinkV2 AsSidebarComponentAuth0InternalLinkV2() =>
        IsSidebarComponentAuth0InternalLinkV2
            ? (Auth0.ManagementApi.SidebarComponentAuth0InternalLinkV2)Value!
            : throw new global::System.Exception(
                "SidebarComponent.Type is not 'sidebar:component:auth0:internal_link:v2'"
            );

    public T Match<T>(
        Func<
            Auth0.ManagementApi.SidebarComponentAuth0ExternalLink,
            T
        > onSidebarComponentAuth0ExternalLink,
        Func<
            Auth0.ManagementApi.SidebarComponentAuth0InternalLink,
            T
        > onSidebarComponentAuth0InternalLink,
        Func<
            Auth0.ManagementApi.SidebarComponentAuth0ExternalLinkV2,
            T
        > onSidebarComponentAuth0ExternalLinkV2,
        Func<
            Auth0.ManagementApi.SidebarComponentAuth0InternalLinkV2,
            T
        > onSidebarComponentAuth0InternalLinkV2,
        Func<string, object?, T> onUnknown_
    )
    {
        return Type switch
        {
            "sidebar:component:auth0:external_link" => onSidebarComponentAuth0ExternalLink(
                AsSidebarComponentAuth0ExternalLink()
            ),
            "sidebar:component:auth0:internal_link" => onSidebarComponentAuth0InternalLink(
                AsSidebarComponentAuth0InternalLink()
            ),
            "sidebar:component:auth0:external_link:v2" => onSidebarComponentAuth0ExternalLinkV2(
                AsSidebarComponentAuth0ExternalLinkV2()
            ),
            "sidebar:component:auth0:internal_link:v2" => onSidebarComponentAuth0InternalLinkV2(
                AsSidebarComponentAuth0InternalLinkV2()
            ),
            _ => onUnknown_(Type, Value),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.SidebarComponentAuth0ExternalLink> onSidebarComponentAuth0ExternalLink,
        global::System.Action<Auth0.ManagementApi.SidebarComponentAuth0InternalLink> onSidebarComponentAuth0InternalLink,
        global::System.Action<Auth0.ManagementApi.SidebarComponentAuth0ExternalLinkV2> onSidebarComponentAuth0ExternalLinkV2,
        global::System.Action<Auth0.ManagementApi.SidebarComponentAuth0InternalLinkV2> onSidebarComponentAuth0InternalLinkV2,
        global::System.Action<string, object?> onUnknown_
    )
    {
        switch (Type)
        {
            case "sidebar:component:auth0:external_link":
                onSidebarComponentAuth0ExternalLink(AsSidebarComponentAuth0ExternalLink());
                break;
            case "sidebar:component:auth0:internal_link":
                onSidebarComponentAuth0InternalLink(AsSidebarComponentAuth0InternalLink());
                break;
            case "sidebar:component:auth0:external_link:v2":
                onSidebarComponentAuth0ExternalLinkV2(AsSidebarComponentAuth0ExternalLinkV2());
                break;
            case "sidebar:component:auth0:internal_link:v2":
                onSidebarComponentAuth0InternalLinkV2(AsSidebarComponentAuth0InternalLinkV2());
                break;
            default:
                onUnknown_(Type, Value);
                break;
        }
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.SidebarComponentAuth0ExternalLink"/> and returns true if successful.
    /// </summary>
    public bool TryAsSidebarComponentAuth0ExternalLink(
        out Auth0.ManagementApi.SidebarComponentAuth0ExternalLink? value
    )
    {
        if (Type == "sidebar:component:auth0:external_link")
        {
            value = (Auth0.ManagementApi.SidebarComponentAuth0ExternalLink)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.SidebarComponentAuth0InternalLink"/> and returns true if successful.
    /// </summary>
    public bool TryAsSidebarComponentAuth0InternalLink(
        out Auth0.ManagementApi.SidebarComponentAuth0InternalLink? value
    )
    {
        if (Type == "sidebar:component:auth0:internal_link")
        {
            value = (Auth0.ManagementApi.SidebarComponentAuth0InternalLink)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.SidebarComponentAuth0ExternalLinkV2"/> and returns true if successful.
    /// </summary>
    public bool TryAsSidebarComponentAuth0ExternalLinkV2(
        out Auth0.ManagementApi.SidebarComponentAuth0ExternalLinkV2? value
    )
    {
        if (Type == "sidebar:component:auth0:external_link:v2")
        {
            value = (Auth0.ManagementApi.SidebarComponentAuth0ExternalLinkV2)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.SidebarComponentAuth0InternalLinkV2"/> and returns true if successful.
    /// </summary>
    public bool TryAsSidebarComponentAuth0InternalLinkV2(
        out Auth0.ManagementApi.SidebarComponentAuth0InternalLinkV2? value
    )
    {
        if (Type == "sidebar:component:auth0:internal_link:v2")
        {
            value = (Auth0.ManagementApi.SidebarComponentAuth0InternalLinkV2)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public override string ToString() => JsonUtils.Serialize(this);

    public static implicit operator SidebarComponent(
        SidebarComponent.SidebarComponentAuth0ExternalLink value
    ) => new(value);

    public static implicit operator SidebarComponent(
        SidebarComponent.SidebarComponentAuth0InternalLink value
    ) => new(value);

    public static implicit operator SidebarComponent(
        SidebarComponent.SidebarComponentAuth0ExternalLinkV2 value
    ) => new(value);

    public static implicit operator SidebarComponent(
        SidebarComponent.SidebarComponentAuth0InternalLinkV2 value
    ) => new(value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<SidebarComponent>
    {
        public override bool CanConvert(global::System.Type typeToConvert) =>
            typeof(SidebarComponent).IsAssignableFrom(typeToConvert);

        public override SidebarComponent Read(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var json = JsonElement.ParseValue(ref reader);
            if (!json.TryGetProperty("type", out var discriminatorElement))
            {
                throw new JsonException("Missing discriminator property 'type'");
            }
            if (discriminatorElement.ValueKind != JsonValueKind.String)
            {
                if (discriminatorElement.ValueKind == JsonValueKind.Null)
                {
                    throw new JsonException("Discriminator property 'type' is null");
                }

                throw new JsonException(
                    $"Discriminator property 'type' is not a string, instead is {discriminatorElement.ToString()}"
                );
            }

            var discriminator =
                discriminatorElement.GetString()
                ?? throw new JsonException("Discriminator property 'type' is null");

            // Strip the discriminant property to prevent it from leaking into AdditionalProperties
            var jsonObject = System.Text.Json.Nodes.JsonObject.Create(json);
            jsonObject?.Remove("type");
            var jsonWithoutDiscriminator =
                jsonObject != null ? JsonSerializer.SerializeToElement(jsonObject, options) : json;

            var value = discriminator switch
            {
                "sidebar:component:auth0:external_link" =>
                    jsonWithoutDiscriminator.Deserialize<Auth0.ManagementApi.SidebarComponentAuth0ExternalLink?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Auth0.ManagementApi.SidebarComponentAuth0ExternalLink"
                        ),
                "sidebar:component:auth0:internal_link" =>
                    jsonWithoutDiscriminator.Deserialize<Auth0.ManagementApi.SidebarComponentAuth0InternalLink?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Auth0.ManagementApi.SidebarComponentAuth0InternalLink"
                        ),
                "sidebar:component:auth0:external_link:v2" =>
                    jsonWithoutDiscriminator.Deserialize<Auth0.ManagementApi.SidebarComponentAuth0ExternalLinkV2?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Auth0.ManagementApi.SidebarComponentAuth0ExternalLinkV2"
                        ),
                "sidebar:component:auth0:internal_link:v2" =>
                    jsonWithoutDiscriminator.Deserialize<Auth0.ManagementApi.SidebarComponentAuth0InternalLinkV2?>(
                        options
                    )
                        ?? throw new JsonException(
                            "Failed to deserialize Auth0.ManagementApi.SidebarComponentAuth0InternalLinkV2"
                        ),
                _ => json.Deserialize<object?>(options),
            };
            return new SidebarComponent(discriminator, value);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SidebarComponent value,
            JsonSerializerOptions options
        )
        {
            JsonNode json =
                value.Type switch
                {
                    "sidebar:component:auth0:external_link" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "sidebar:component:auth0:internal_link" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "sidebar:component:auth0:external_link:v2" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    "sidebar:component:auth0:internal_link:v2" => JsonSerializer.SerializeToNode(
                        value.Value,
                        options
                    ),
                    _ => JsonSerializer.SerializeToNode(value.Value, options),
                } ?? new JsonObject();
            json["type"] = value.Type;
            json.WriteTo(writer, options);
        }

        public override SidebarComponent ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new JsonException("The JSON property name could not be read as a string.");
            return new SidebarComponent(stringValue, stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SidebarComponent value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Type);
        }
    }

    /// <summary>
    /// Discriminated union type for sidebar:component:auth0:external_link
    /// </summary>
    [Serializable]
    public struct SidebarComponentAuth0ExternalLink
    {
        public SidebarComponentAuth0ExternalLink(
            Auth0.ManagementApi.SidebarComponentAuth0ExternalLink value
        )
        {
            Value = value;
        }

        internal Auth0.ManagementApi.SidebarComponentAuth0ExternalLink Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SidebarComponent.SidebarComponentAuth0ExternalLink(
            Auth0.ManagementApi.SidebarComponentAuth0ExternalLink value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for sidebar:component:auth0:internal_link
    /// </summary>
    [Serializable]
    public struct SidebarComponentAuth0InternalLink
    {
        public SidebarComponentAuth0InternalLink(
            Auth0.ManagementApi.SidebarComponentAuth0InternalLink value
        )
        {
            Value = value;
        }

        internal Auth0.ManagementApi.SidebarComponentAuth0InternalLink Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SidebarComponent.SidebarComponentAuth0InternalLink(
            Auth0.ManagementApi.SidebarComponentAuth0InternalLink value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for sidebar:component:auth0:external_link:v2
    /// </summary>
    [Serializable]
    public struct SidebarComponentAuth0ExternalLinkV2
    {
        public SidebarComponentAuth0ExternalLinkV2(
            Auth0.ManagementApi.SidebarComponentAuth0ExternalLinkV2 value
        )
        {
            Value = value;
        }

        internal Auth0.ManagementApi.SidebarComponentAuth0ExternalLinkV2 Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SidebarComponent.SidebarComponentAuth0ExternalLinkV2(
            Auth0.ManagementApi.SidebarComponentAuth0ExternalLinkV2 value
        ) => new(value);
    }

    /// <summary>
    /// Discriminated union type for sidebar:component:auth0:internal_link:v2
    /// </summary>
    [Serializable]
    public struct SidebarComponentAuth0InternalLinkV2
    {
        public SidebarComponentAuth0InternalLinkV2(
            Auth0.ManagementApi.SidebarComponentAuth0InternalLinkV2 value
        )
        {
            Value = value;
        }

        internal Auth0.ManagementApi.SidebarComponentAuth0InternalLinkV2 Value { get; set; }

        public override string ToString() => Value.ToString() ?? "null";

        public static implicit operator SidebarComponent.SidebarComponentAuth0InternalLinkV2(
            Auth0.ManagementApi.SidebarComponentAuth0InternalLinkV2 value
        ) => new(value);
    }
}
