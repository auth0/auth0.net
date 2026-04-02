// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

[JsonConverter(typeof(FlowActionAuth0.JsonConverter))]
[Serializable]
public class FlowActionAuth0
{
    private FlowActionAuth0(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionAuth0CreateUser value.
    /// </summary>
    public static FlowActionAuth0 FromFlowActionAuth0CreateUser(
        Auth0.ManagementApi.FlowActionAuth0CreateUser value
    ) => new("flowActionAuth0CreateUser", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionAuth0GetUser value.
    /// </summary>
    public static FlowActionAuth0 FromFlowActionAuth0GetUser(
        Auth0.ManagementApi.FlowActionAuth0GetUser value
    ) => new("flowActionAuth0GetUser", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionAuth0UpdateUser value.
    /// </summary>
    public static FlowActionAuth0 FromFlowActionAuth0UpdateUser(
        Auth0.ManagementApi.FlowActionAuth0UpdateUser value
    ) => new("flowActionAuth0UpdateUser", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionAuth0SendRequest value.
    /// </summary>
    public static FlowActionAuth0 FromFlowActionAuth0SendRequest(
        Auth0.ManagementApi.FlowActionAuth0SendRequest value
    ) => new("flowActionAuth0SendRequest", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionAuth0SendEmail value.
    /// </summary>
    public static FlowActionAuth0 FromFlowActionAuth0SendEmail(
        Auth0.ManagementApi.FlowActionAuth0SendEmail value
    ) => new("flowActionAuth0SendEmail", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionAuth0SendSms value.
    /// </summary>
    public static FlowActionAuth0 FromFlowActionAuth0SendSms(
        Auth0.ManagementApi.FlowActionAuth0SendSms value
    ) => new("flowActionAuth0SendSms", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowActionAuth0MakeCall value.
    /// </summary>
    public static FlowActionAuth0 FromFlowActionAuth0MakeCall(
        Auth0.ManagementApi.FlowActionAuth0MakeCall value
    ) => new("flowActionAuth0MakeCall", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionAuth0CreateUser"
    /// </summary>
    public bool IsFlowActionAuth0CreateUser() => Type == "flowActionAuth0CreateUser";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionAuth0GetUser"
    /// </summary>
    public bool IsFlowActionAuth0GetUser() => Type == "flowActionAuth0GetUser";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionAuth0UpdateUser"
    /// </summary>
    public bool IsFlowActionAuth0UpdateUser() => Type == "flowActionAuth0UpdateUser";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionAuth0SendRequest"
    /// </summary>
    public bool IsFlowActionAuth0SendRequest() => Type == "flowActionAuth0SendRequest";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionAuth0SendEmail"
    /// </summary>
    public bool IsFlowActionAuth0SendEmail() => Type == "flowActionAuth0SendEmail";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionAuth0SendSms"
    /// </summary>
    public bool IsFlowActionAuth0SendSms() => Type == "flowActionAuth0SendSms";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowActionAuth0MakeCall"
    /// </summary>
    public bool IsFlowActionAuth0MakeCall() => Type == "flowActionAuth0MakeCall";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionAuth0CreateUser"/> if <see cref="Type"/> is 'flowActionAuth0CreateUser', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionAuth0CreateUser'.</exception>
    public Auth0.ManagementApi.FlowActionAuth0CreateUser AsFlowActionAuth0CreateUser() =>
        IsFlowActionAuth0CreateUser()
            ? (Auth0.ManagementApi.FlowActionAuth0CreateUser)Value!
            : throw new ManagementException("Union type is not 'flowActionAuth0CreateUser'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionAuth0GetUser"/> if <see cref="Type"/> is 'flowActionAuth0GetUser', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionAuth0GetUser'.</exception>
    public Auth0.ManagementApi.FlowActionAuth0GetUser AsFlowActionAuth0GetUser() =>
        IsFlowActionAuth0GetUser()
            ? (Auth0.ManagementApi.FlowActionAuth0GetUser)Value!
            : throw new ManagementException("Union type is not 'flowActionAuth0GetUser'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionAuth0UpdateUser"/> if <see cref="Type"/> is 'flowActionAuth0UpdateUser', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionAuth0UpdateUser'.</exception>
    public Auth0.ManagementApi.FlowActionAuth0UpdateUser AsFlowActionAuth0UpdateUser() =>
        IsFlowActionAuth0UpdateUser()
            ? (Auth0.ManagementApi.FlowActionAuth0UpdateUser)Value!
            : throw new ManagementException("Union type is not 'flowActionAuth0UpdateUser'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionAuth0SendRequest"/> if <see cref="Type"/> is 'flowActionAuth0SendRequest', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionAuth0SendRequest'.</exception>
    public Auth0.ManagementApi.FlowActionAuth0SendRequest AsFlowActionAuth0SendRequest() =>
        IsFlowActionAuth0SendRequest()
            ? (Auth0.ManagementApi.FlowActionAuth0SendRequest)Value!
            : throw new ManagementException("Union type is not 'flowActionAuth0SendRequest'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionAuth0SendEmail"/> if <see cref="Type"/> is 'flowActionAuth0SendEmail', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionAuth0SendEmail'.</exception>
    public Auth0.ManagementApi.FlowActionAuth0SendEmail AsFlowActionAuth0SendEmail() =>
        IsFlowActionAuth0SendEmail()
            ? (Auth0.ManagementApi.FlowActionAuth0SendEmail)Value!
            : throw new ManagementException("Union type is not 'flowActionAuth0SendEmail'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionAuth0SendSms"/> if <see cref="Type"/> is 'flowActionAuth0SendSms', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionAuth0SendSms'.</exception>
    public Auth0.ManagementApi.FlowActionAuth0SendSms AsFlowActionAuth0SendSms() =>
        IsFlowActionAuth0SendSms()
            ? (Auth0.ManagementApi.FlowActionAuth0SendSms)Value!
            : throw new ManagementException("Union type is not 'flowActionAuth0SendSms'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowActionAuth0MakeCall"/> if <see cref="Type"/> is 'flowActionAuth0MakeCall', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowActionAuth0MakeCall'.</exception>
    public Auth0.ManagementApi.FlowActionAuth0MakeCall AsFlowActionAuth0MakeCall() =>
        IsFlowActionAuth0MakeCall()
            ? (Auth0.ManagementApi.FlowActionAuth0MakeCall)Value!
            : throw new ManagementException("Union type is not 'flowActionAuth0MakeCall'");

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionAuth0CreateUser"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionAuth0CreateUser(
        out Auth0.ManagementApi.FlowActionAuth0CreateUser? value
    )
    {
        if (Type == "flowActionAuth0CreateUser")
        {
            value = (Auth0.ManagementApi.FlowActionAuth0CreateUser)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionAuth0GetUser"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionAuth0GetUser(out Auth0.ManagementApi.FlowActionAuth0GetUser? value)
    {
        if (Type == "flowActionAuth0GetUser")
        {
            value = (Auth0.ManagementApi.FlowActionAuth0GetUser)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionAuth0UpdateUser"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionAuth0UpdateUser(
        out Auth0.ManagementApi.FlowActionAuth0UpdateUser? value
    )
    {
        if (Type == "flowActionAuth0UpdateUser")
        {
            value = (Auth0.ManagementApi.FlowActionAuth0UpdateUser)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionAuth0SendRequest"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionAuth0SendRequest(
        out Auth0.ManagementApi.FlowActionAuth0SendRequest? value
    )
    {
        if (Type == "flowActionAuth0SendRequest")
        {
            value = (Auth0.ManagementApi.FlowActionAuth0SendRequest)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionAuth0SendEmail"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionAuth0SendEmail(
        out Auth0.ManagementApi.FlowActionAuth0SendEmail? value
    )
    {
        if (Type == "flowActionAuth0SendEmail")
        {
            value = (Auth0.ManagementApi.FlowActionAuth0SendEmail)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionAuth0SendSms"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionAuth0SendSms(out Auth0.ManagementApi.FlowActionAuth0SendSms? value)
    {
        if (Type == "flowActionAuth0SendSms")
        {
            value = (Auth0.ManagementApi.FlowActionAuth0SendSms)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowActionAuth0MakeCall"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowActionAuth0MakeCall(
        out Auth0.ManagementApi.FlowActionAuth0MakeCall? value
    )
    {
        if (Type == "flowActionAuth0MakeCall")
        {
            value = (Auth0.ManagementApi.FlowActionAuth0MakeCall)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<Auth0.ManagementApi.FlowActionAuth0CreateUser, T> onFlowActionAuth0CreateUser,
        Func<Auth0.ManagementApi.FlowActionAuth0GetUser, T> onFlowActionAuth0GetUser,
        Func<Auth0.ManagementApi.FlowActionAuth0UpdateUser, T> onFlowActionAuth0UpdateUser,
        Func<Auth0.ManagementApi.FlowActionAuth0SendRequest, T> onFlowActionAuth0SendRequest,
        Func<Auth0.ManagementApi.FlowActionAuth0SendEmail, T> onFlowActionAuth0SendEmail,
        Func<Auth0.ManagementApi.FlowActionAuth0SendSms, T> onFlowActionAuth0SendSms,
        Func<Auth0.ManagementApi.FlowActionAuth0MakeCall, T> onFlowActionAuth0MakeCall
    )
    {
        return Type switch
        {
            "flowActionAuth0CreateUser" => onFlowActionAuth0CreateUser(
                AsFlowActionAuth0CreateUser()
            ),
            "flowActionAuth0GetUser" => onFlowActionAuth0GetUser(AsFlowActionAuth0GetUser()),
            "flowActionAuth0UpdateUser" => onFlowActionAuth0UpdateUser(
                AsFlowActionAuth0UpdateUser()
            ),
            "flowActionAuth0SendRequest" => onFlowActionAuth0SendRequest(
                AsFlowActionAuth0SendRequest()
            ),
            "flowActionAuth0SendEmail" => onFlowActionAuth0SendEmail(AsFlowActionAuth0SendEmail()),
            "flowActionAuth0SendSms" => onFlowActionAuth0SendSms(AsFlowActionAuth0SendSms()),
            "flowActionAuth0MakeCall" => onFlowActionAuth0MakeCall(AsFlowActionAuth0MakeCall()),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.FlowActionAuth0CreateUser> onFlowActionAuth0CreateUser,
        global::System.Action<Auth0.ManagementApi.FlowActionAuth0GetUser> onFlowActionAuth0GetUser,
        global::System.Action<Auth0.ManagementApi.FlowActionAuth0UpdateUser> onFlowActionAuth0UpdateUser,
        global::System.Action<Auth0.ManagementApi.FlowActionAuth0SendRequest> onFlowActionAuth0SendRequest,
        global::System.Action<Auth0.ManagementApi.FlowActionAuth0SendEmail> onFlowActionAuth0SendEmail,
        global::System.Action<Auth0.ManagementApi.FlowActionAuth0SendSms> onFlowActionAuth0SendSms,
        global::System.Action<Auth0.ManagementApi.FlowActionAuth0MakeCall> onFlowActionAuth0MakeCall
    )
    {
        switch (Type)
        {
            case "flowActionAuth0CreateUser":
                onFlowActionAuth0CreateUser(AsFlowActionAuth0CreateUser());
                break;
            case "flowActionAuth0GetUser":
                onFlowActionAuth0GetUser(AsFlowActionAuth0GetUser());
                break;
            case "flowActionAuth0UpdateUser":
                onFlowActionAuth0UpdateUser(AsFlowActionAuth0UpdateUser());
                break;
            case "flowActionAuth0SendRequest":
                onFlowActionAuth0SendRequest(AsFlowActionAuth0SendRequest());
                break;
            case "flowActionAuth0SendEmail":
                onFlowActionAuth0SendEmail(AsFlowActionAuth0SendEmail());
                break;
            case "flowActionAuth0SendSms":
                onFlowActionAuth0SendSms(AsFlowActionAuth0SendSms());
                break;
            case "flowActionAuth0MakeCall":
                onFlowActionAuth0MakeCall(AsFlowActionAuth0MakeCall());
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
        if (obj is not FlowActionAuth0 other)
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

    public static implicit operator FlowActionAuth0(
        Auth0.ManagementApi.FlowActionAuth0CreateUser value
    ) => new("flowActionAuth0CreateUser", value);

    public static implicit operator FlowActionAuth0(
        Auth0.ManagementApi.FlowActionAuth0GetUser value
    ) => new("flowActionAuth0GetUser", value);

    public static implicit operator FlowActionAuth0(
        Auth0.ManagementApi.FlowActionAuth0UpdateUser value
    ) => new("flowActionAuth0UpdateUser", value);

    public static implicit operator FlowActionAuth0(
        Auth0.ManagementApi.FlowActionAuth0SendRequest value
    ) => new("flowActionAuth0SendRequest", value);

    public static implicit operator FlowActionAuth0(
        Auth0.ManagementApi.FlowActionAuth0SendEmail value
    ) => new("flowActionAuth0SendEmail", value);

    public static implicit operator FlowActionAuth0(
        Auth0.ManagementApi.FlowActionAuth0SendSms value
    ) => new("flowActionAuth0SendSms", value);

    public static implicit operator FlowActionAuth0(
        Auth0.ManagementApi.FlowActionAuth0MakeCall value
    ) => new("flowActionAuth0MakeCall", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<FlowActionAuth0>
    {
        public override FlowActionAuth0? Read(
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
                        "flowActionAuth0CreateUser",
                        typeof(Auth0.ManagementApi.FlowActionAuth0CreateUser)
                    ),
                    ("flowActionAuth0GetUser", typeof(Auth0.ManagementApi.FlowActionAuth0GetUser)),
                    (
                        "flowActionAuth0UpdateUser",
                        typeof(Auth0.ManagementApi.FlowActionAuth0UpdateUser)
                    ),
                    (
                        "flowActionAuth0SendRequest",
                        typeof(Auth0.ManagementApi.FlowActionAuth0SendRequest)
                    ),
                    (
                        "flowActionAuth0SendEmail",
                        typeof(Auth0.ManagementApi.FlowActionAuth0SendEmail)
                    ),
                    ("flowActionAuth0SendSms", typeof(Auth0.ManagementApi.FlowActionAuth0SendSms)),
                    (
                        "flowActionAuth0MakeCall",
                        typeof(Auth0.ManagementApi.FlowActionAuth0MakeCall)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            FlowActionAuth0 result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into FlowActionAuth0"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            FlowActionAuth0 value,
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
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override FlowActionAuth0 ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            FlowActionAuth0 result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            FlowActionAuth0 value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
