// ReSharper disable NullableWarningSuppressionIsUsed
// ReSharper disable InconsistentNaming

using Auth0.ManagementApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.ManagementApi;

/// <summary>
/// Flows Vault Connection configuration.
/// </summary>
[JsonConverter(typeof(UpdateFlowsVaultConnectionSetup.JsonConverter))]
[Serializable]
public class UpdateFlowsVaultConnectionSetup
{
    private UpdateFlowsVaultConnectionSetup(string type, object? value)
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
    /// Factory method to create a union from a Auth0.ManagementApi.FlowsVaultConnectioSetupApiKeyWithBaseUrl value.
    /// </summary>
    public static UpdateFlowsVaultConnectionSetup FromFlowsVaultConnectioSetupApiKeyWithBaseUrl(
        Auth0.ManagementApi.FlowsVaultConnectioSetupApiKeyWithBaseUrl value
    ) => new("flowsVaultConnectioSetupApiKeyWithBaseUrl", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowsVaultConnectioSetupApiKey value.
    /// </summary>
    public static UpdateFlowsVaultConnectionSetup FromFlowsVaultConnectioSetupApiKey(
        Auth0.ManagementApi.FlowsVaultConnectioSetupApiKey value
    ) => new("flowsVaultConnectioSetupApiKey", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowsVaultConnectioSetupOauthApp value.
    /// </summary>
    public static UpdateFlowsVaultConnectionSetup FromFlowsVaultConnectioSetupOauthApp(
        Auth0.ManagementApi.FlowsVaultConnectioSetupOauthApp value
    ) => new("flowsVaultConnectioSetupOauthApp", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowsVaultConnectioSetupBigqueryOauthJwt value.
    /// </summary>
    public static UpdateFlowsVaultConnectionSetup FromFlowsVaultConnectioSetupBigqueryOauthJwt(
        Auth0.ManagementApi.FlowsVaultConnectioSetupBigqueryOauthJwt value
    ) => new("flowsVaultConnectioSetupBigqueryOauthJwt", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowsVaultConnectioSetupSecretApiKey value.
    /// </summary>
    public static UpdateFlowsVaultConnectionSetup FromFlowsVaultConnectioSetupSecretApiKey(
        Auth0.ManagementApi.FlowsVaultConnectioSetupSecretApiKey value
    ) => new("flowsVaultConnectioSetupSecretApiKey", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowsVaultConnectioSetupHttpBearer value.
    /// </summary>
    public static UpdateFlowsVaultConnectionSetup FromFlowsVaultConnectioSetupHttpBearer(
        Auth0.ManagementApi.FlowsVaultConnectioSetupHttpBearer value
    ) => new("flowsVaultConnectioSetupHttpBearer", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowsVaultConnectionHttpBasicAuthSetup value.
    /// </summary>
    public static UpdateFlowsVaultConnectionSetup FromFlowsVaultConnectionHttpBasicAuthSetup(
        Auth0.ManagementApi.FlowsVaultConnectionHttpBasicAuthSetup value
    ) => new("flowsVaultConnectionHttpBasicAuthSetup", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowsVaultConnectionHttpApiKeySetup value.
    /// </summary>
    public static UpdateFlowsVaultConnectionSetup FromFlowsVaultConnectionHttpApiKeySetup(
        Auth0.ManagementApi.FlowsVaultConnectionHttpApiKeySetup value
    ) => new("flowsVaultConnectionHttpApiKeySetup", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowsVaultConnectionHttpOauthClientCredentialsSetup value.
    /// </summary>
    public static UpdateFlowsVaultConnectionSetup FromFlowsVaultConnectionHttpOauthClientCredentialsSetup(
        Auth0.ManagementApi.FlowsVaultConnectionHttpOauthClientCredentialsSetup value
    ) => new("flowsVaultConnectionHttpOauthClientCredentialsSetup", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowsVaultConnectioSetupJwt value.
    /// </summary>
    public static UpdateFlowsVaultConnectionSetup FromFlowsVaultConnectioSetupJwt(
        Auth0.ManagementApi.FlowsVaultConnectioSetupJwt value
    ) => new("flowsVaultConnectioSetupJwt", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowsVaultConnectioSetupMailjetApiKey value.
    /// </summary>
    public static UpdateFlowsVaultConnectionSetup FromFlowsVaultConnectioSetupMailjetApiKey(
        Auth0.ManagementApi.FlowsVaultConnectioSetupMailjetApiKey value
    ) => new("flowsVaultConnectioSetupMailjetApiKey", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowsVaultConnectioSetupToken value.
    /// </summary>
    public static UpdateFlowsVaultConnectionSetup FromFlowsVaultConnectioSetupToken(
        Auth0.ManagementApi.FlowsVaultConnectioSetupToken value
    ) => new("flowsVaultConnectioSetupToken", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowsVaultConnectioSetupWebhook value.
    /// </summary>
    public static UpdateFlowsVaultConnectionSetup FromFlowsVaultConnectioSetupWebhook(
        Auth0.ManagementApi.FlowsVaultConnectioSetupWebhook value
    ) => new("flowsVaultConnectioSetupWebhook", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowsVaultConnectioSetupStripeKeyPair value.
    /// </summary>
    public static UpdateFlowsVaultConnectionSetup FromFlowsVaultConnectioSetupStripeKeyPair(
        Auth0.ManagementApi.FlowsVaultConnectioSetupStripeKeyPair value
    ) => new("flowsVaultConnectioSetupStripeKeyPair", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowsVaultConnectioSetupOauthCode value.
    /// </summary>
    public static UpdateFlowsVaultConnectionSetup FromFlowsVaultConnectioSetupOauthCode(
        Auth0.ManagementApi.FlowsVaultConnectioSetupOauthCode value
    ) => new("flowsVaultConnectioSetupOauthCode", value);

    /// <summary>
    /// Factory method to create a union from a Auth0.ManagementApi.FlowsVaultConnectioSetupTwilioApiKey value.
    /// </summary>
    public static UpdateFlowsVaultConnectionSetup FromFlowsVaultConnectioSetupTwilioApiKey(
        Auth0.ManagementApi.FlowsVaultConnectioSetupTwilioApiKey value
    ) => new("flowsVaultConnectioSetupTwilioApiKey", value);

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowsVaultConnectioSetupApiKeyWithBaseUrl"
    /// </summary>
    public bool IsFlowsVaultConnectioSetupApiKeyWithBaseUrl() =>
        Type == "flowsVaultConnectioSetupApiKeyWithBaseUrl";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowsVaultConnectioSetupApiKey"
    /// </summary>
    public bool IsFlowsVaultConnectioSetupApiKey() => Type == "flowsVaultConnectioSetupApiKey";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowsVaultConnectioSetupOauthApp"
    /// </summary>
    public bool IsFlowsVaultConnectioSetupOauthApp() => Type == "flowsVaultConnectioSetupOauthApp";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowsVaultConnectioSetupBigqueryOauthJwt"
    /// </summary>
    public bool IsFlowsVaultConnectioSetupBigqueryOauthJwt() =>
        Type == "flowsVaultConnectioSetupBigqueryOauthJwt";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowsVaultConnectioSetupSecretApiKey"
    /// </summary>
    public bool IsFlowsVaultConnectioSetupSecretApiKey() =>
        Type == "flowsVaultConnectioSetupSecretApiKey";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowsVaultConnectioSetupHttpBearer"
    /// </summary>
    public bool IsFlowsVaultConnectioSetupHttpBearer() =>
        Type == "flowsVaultConnectioSetupHttpBearer";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowsVaultConnectionHttpBasicAuthSetup"
    /// </summary>
    public bool IsFlowsVaultConnectionHttpBasicAuthSetup() =>
        Type == "flowsVaultConnectionHttpBasicAuthSetup";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowsVaultConnectionHttpApiKeySetup"
    /// </summary>
    public bool IsFlowsVaultConnectionHttpApiKeySetup() =>
        Type == "flowsVaultConnectionHttpApiKeySetup";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowsVaultConnectionHttpOauthClientCredentialsSetup"
    /// </summary>
    public bool IsFlowsVaultConnectionHttpOauthClientCredentialsSetup() =>
        Type == "flowsVaultConnectionHttpOauthClientCredentialsSetup";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowsVaultConnectioSetupJwt"
    /// </summary>
    public bool IsFlowsVaultConnectioSetupJwt() => Type == "flowsVaultConnectioSetupJwt";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowsVaultConnectioSetupMailjetApiKey"
    /// </summary>
    public bool IsFlowsVaultConnectioSetupMailjetApiKey() =>
        Type == "flowsVaultConnectioSetupMailjetApiKey";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowsVaultConnectioSetupToken"
    /// </summary>
    public bool IsFlowsVaultConnectioSetupToken() => Type == "flowsVaultConnectioSetupToken";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowsVaultConnectioSetupWebhook"
    /// </summary>
    public bool IsFlowsVaultConnectioSetupWebhook() => Type == "flowsVaultConnectioSetupWebhook";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowsVaultConnectioSetupStripeKeyPair"
    /// </summary>
    public bool IsFlowsVaultConnectioSetupStripeKeyPair() =>
        Type == "flowsVaultConnectioSetupStripeKeyPair";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowsVaultConnectioSetupOauthCode"
    /// </summary>
    public bool IsFlowsVaultConnectioSetupOauthCode() =>
        Type == "flowsVaultConnectioSetupOauthCode";

    /// <summary>
    /// Returns true if <see cref="Type"/> is "flowsVaultConnectioSetupTwilioApiKey"
    /// </summary>
    public bool IsFlowsVaultConnectioSetupTwilioApiKey() =>
        Type == "flowsVaultConnectioSetupTwilioApiKey";

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowsVaultConnectioSetupApiKeyWithBaseUrl"/> if <see cref="Type"/> is 'flowsVaultConnectioSetupApiKeyWithBaseUrl', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowsVaultConnectioSetupApiKeyWithBaseUrl'.</exception>
    public Auth0.ManagementApi.FlowsVaultConnectioSetupApiKeyWithBaseUrl AsFlowsVaultConnectioSetupApiKeyWithBaseUrl() =>
        IsFlowsVaultConnectioSetupApiKeyWithBaseUrl()
            ? (Auth0.ManagementApi.FlowsVaultConnectioSetupApiKeyWithBaseUrl)Value!
            : throw new ManagementException(
                "Union type is not 'flowsVaultConnectioSetupApiKeyWithBaseUrl'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowsVaultConnectioSetupApiKey"/> if <see cref="Type"/> is 'flowsVaultConnectioSetupApiKey', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowsVaultConnectioSetupApiKey'.</exception>
    public Auth0.ManagementApi.FlowsVaultConnectioSetupApiKey AsFlowsVaultConnectioSetupApiKey() =>
        IsFlowsVaultConnectioSetupApiKey()
            ? (Auth0.ManagementApi.FlowsVaultConnectioSetupApiKey)Value!
            : throw new ManagementException("Union type is not 'flowsVaultConnectioSetupApiKey'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowsVaultConnectioSetupOauthApp"/> if <see cref="Type"/> is 'flowsVaultConnectioSetupOauthApp', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowsVaultConnectioSetupOauthApp'.</exception>
    public Auth0.ManagementApi.FlowsVaultConnectioSetupOauthApp AsFlowsVaultConnectioSetupOauthApp() =>
        IsFlowsVaultConnectioSetupOauthApp()
            ? (Auth0.ManagementApi.FlowsVaultConnectioSetupOauthApp)Value!
            : throw new ManagementException("Union type is not 'flowsVaultConnectioSetupOauthApp'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowsVaultConnectioSetupBigqueryOauthJwt"/> if <see cref="Type"/> is 'flowsVaultConnectioSetupBigqueryOauthJwt', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowsVaultConnectioSetupBigqueryOauthJwt'.</exception>
    public Auth0.ManagementApi.FlowsVaultConnectioSetupBigqueryOauthJwt AsFlowsVaultConnectioSetupBigqueryOauthJwt() =>
        IsFlowsVaultConnectioSetupBigqueryOauthJwt()
            ? (Auth0.ManagementApi.FlowsVaultConnectioSetupBigqueryOauthJwt)Value!
            : throw new ManagementException(
                "Union type is not 'flowsVaultConnectioSetupBigqueryOauthJwt'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowsVaultConnectioSetupSecretApiKey"/> if <see cref="Type"/> is 'flowsVaultConnectioSetupSecretApiKey', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowsVaultConnectioSetupSecretApiKey'.</exception>
    public Auth0.ManagementApi.FlowsVaultConnectioSetupSecretApiKey AsFlowsVaultConnectioSetupSecretApiKey() =>
        IsFlowsVaultConnectioSetupSecretApiKey()
            ? (Auth0.ManagementApi.FlowsVaultConnectioSetupSecretApiKey)Value!
            : throw new ManagementException(
                "Union type is not 'flowsVaultConnectioSetupSecretApiKey'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowsVaultConnectioSetupHttpBearer"/> if <see cref="Type"/> is 'flowsVaultConnectioSetupHttpBearer', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowsVaultConnectioSetupHttpBearer'.</exception>
    public Auth0.ManagementApi.FlowsVaultConnectioSetupHttpBearer AsFlowsVaultConnectioSetupHttpBearer() =>
        IsFlowsVaultConnectioSetupHttpBearer()
            ? (Auth0.ManagementApi.FlowsVaultConnectioSetupHttpBearer)Value!
            : throw new ManagementException(
                "Union type is not 'flowsVaultConnectioSetupHttpBearer'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowsVaultConnectionHttpBasicAuthSetup"/> if <see cref="Type"/> is 'flowsVaultConnectionHttpBasicAuthSetup', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowsVaultConnectionHttpBasicAuthSetup'.</exception>
    public Auth0.ManagementApi.FlowsVaultConnectionHttpBasicAuthSetup AsFlowsVaultConnectionHttpBasicAuthSetup() =>
        IsFlowsVaultConnectionHttpBasicAuthSetup()
            ? (Auth0.ManagementApi.FlowsVaultConnectionHttpBasicAuthSetup)Value!
            : throw new ManagementException(
                "Union type is not 'flowsVaultConnectionHttpBasicAuthSetup'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowsVaultConnectionHttpApiKeySetup"/> if <see cref="Type"/> is 'flowsVaultConnectionHttpApiKeySetup', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowsVaultConnectionHttpApiKeySetup'.</exception>
    public Auth0.ManagementApi.FlowsVaultConnectionHttpApiKeySetup AsFlowsVaultConnectionHttpApiKeySetup() =>
        IsFlowsVaultConnectionHttpApiKeySetup()
            ? (Auth0.ManagementApi.FlowsVaultConnectionHttpApiKeySetup)Value!
            : throw new ManagementException(
                "Union type is not 'flowsVaultConnectionHttpApiKeySetup'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowsVaultConnectionHttpOauthClientCredentialsSetup"/> if <see cref="Type"/> is 'flowsVaultConnectionHttpOauthClientCredentialsSetup', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowsVaultConnectionHttpOauthClientCredentialsSetup'.</exception>
    public Auth0.ManagementApi.FlowsVaultConnectionHttpOauthClientCredentialsSetup AsFlowsVaultConnectionHttpOauthClientCredentialsSetup() =>
        IsFlowsVaultConnectionHttpOauthClientCredentialsSetup()
            ? (Auth0.ManagementApi.FlowsVaultConnectionHttpOauthClientCredentialsSetup)Value!
            : throw new ManagementException(
                "Union type is not 'flowsVaultConnectionHttpOauthClientCredentialsSetup'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowsVaultConnectioSetupJwt"/> if <see cref="Type"/> is 'flowsVaultConnectioSetupJwt', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowsVaultConnectioSetupJwt'.</exception>
    public Auth0.ManagementApi.FlowsVaultConnectioSetupJwt AsFlowsVaultConnectioSetupJwt() =>
        IsFlowsVaultConnectioSetupJwt()
            ? (Auth0.ManagementApi.FlowsVaultConnectioSetupJwt)Value!
            : throw new ManagementException("Union type is not 'flowsVaultConnectioSetupJwt'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowsVaultConnectioSetupMailjetApiKey"/> if <see cref="Type"/> is 'flowsVaultConnectioSetupMailjetApiKey', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowsVaultConnectioSetupMailjetApiKey'.</exception>
    public Auth0.ManagementApi.FlowsVaultConnectioSetupMailjetApiKey AsFlowsVaultConnectioSetupMailjetApiKey() =>
        IsFlowsVaultConnectioSetupMailjetApiKey()
            ? (Auth0.ManagementApi.FlowsVaultConnectioSetupMailjetApiKey)Value!
            : throw new ManagementException(
                "Union type is not 'flowsVaultConnectioSetupMailjetApiKey'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowsVaultConnectioSetupToken"/> if <see cref="Type"/> is 'flowsVaultConnectioSetupToken', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowsVaultConnectioSetupToken'.</exception>
    public Auth0.ManagementApi.FlowsVaultConnectioSetupToken AsFlowsVaultConnectioSetupToken() =>
        IsFlowsVaultConnectioSetupToken()
            ? (Auth0.ManagementApi.FlowsVaultConnectioSetupToken)Value!
            : throw new ManagementException("Union type is not 'flowsVaultConnectioSetupToken'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowsVaultConnectioSetupWebhook"/> if <see cref="Type"/> is 'flowsVaultConnectioSetupWebhook', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowsVaultConnectioSetupWebhook'.</exception>
    public Auth0.ManagementApi.FlowsVaultConnectioSetupWebhook AsFlowsVaultConnectioSetupWebhook() =>
        IsFlowsVaultConnectioSetupWebhook()
            ? (Auth0.ManagementApi.FlowsVaultConnectioSetupWebhook)Value!
            : throw new ManagementException("Union type is not 'flowsVaultConnectioSetupWebhook'");

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowsVaultConnectioSetupStripeKeyPair"/> if <see cref="Type"/> is 'flowsVaultConnectioSetupStripeKeyPair', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowsVaultConnectioSetupStripeKeyPair'.</exception>
    public Auth0.ManagementApi.FlowsVaultConnectioSetupStripeKeyPair AsFlowsVaultConnectioSetupStripeKeyPair() =>
        IsFlowsVaultConnectioSetupStripeKeyPair()
            ? (Auth0.ManagementApi.FlowsVaultConnectioSetupStripeKeyPair)Value!
            : throw new ManagementException(
                "Union type is not 'flowsVaultConnectioSetupStripeKeyPair'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowsVaultConnectioSetupOauthCode"/> if <see cref="Type"/> is 'flowsVaultConnectioSetupOauthCode', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowsVaultConnectioSetupOauthCode'.</exception>
    public Auth0.ManagementApi.FlowsVaultConnectioSetupOauthCode AsFlowsVaultConnectioSetupOauthCode() =>
        IsFlowsVaultConnectioSetupOauthCode()
            ? (Auth0.ManagementApi.FlowsVaultConnectioSetupOauthCode)Value!
            : throw new ManagementException(
                "Union type is not 'flowsVaultConnectioSetupOauthCode'"
            );

    /// <summary>
    /// Returns the value as a <see cref="Auth0.ManagementApi.FlowsVaultConnectioSetupTwilioApiKey"/> if <see cref="Type"/> is 'flowsVaultConnectioSetupTwilioApiKey', otherwise throws an exception.
    /// </summary>
    /// <exception cref="ManagementException">Thrown when <see cref="Type"/> is not 'flowsVaultConnectioSetupTwilioApiKey'.</exception>
    public Auth0.ManagementApi.FlowsVaultConnectioSetupTwilioApiKey AsFlowsVaultConnectioSetupTwilioApiKey() =>
        IsFlowsVaultConnectioSetupTwilioApiKey()
            ? (Auth0.ManagementApi.FlowsVaultConnectioSetupTwilioApiKey)Value!
            : throw new ManagementException(
                "Union type is not 'flowsVaultConnectioSetupTwilioApiKey'"
            );

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowsVaultConnectioSetupApiKeyWithBaseUrl"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowsVaultConnectioSetupApiKeyWithBaseUrl(
        out Auth0.ManagementApi.FlowsVaultConnectioSetupApiKeyWithBaseUrl? value
    )
    {
        if (Type == "flowsVaultConnectioSetupApiKeyWithBaseUrl")
        {
            value = (Auth0.ManagementApi.FlowsVaultConnectioSetupApiKeyWithBaseUrl)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowsVaultConnectioSetupApiKey"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowsVaultConnectioSetupApiKey(
        out Auth0.ManagementApi.FlowsVaultConnectioSetupApiKey? value
    )
    {
        if (Type == "flowsVaultConnectioSetupApiKey")
        {
            value = (Auth0.ManagementApi.FlowsVaultConnectioSetupApiKey)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowsVaultConnectioSetupOauthApp"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowsVaultConnectioSetupOauthApp(
        out Auth0.ManagementApi.FlowsVaultConnectioSetupOauthApp? value
    )
    {
        if (Type == "flowsVaultConnectioSetupOauthApp")
        {
            value = (Auth0.ManagementApi.FlowsVaultConnectioSetupOauthApp)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowsVaultConnectioSetupBigqueryOauthJwt"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowsVaultConnectioSetupBigqueryOauthJwt(
        out Auth0.ManagementApi.FlowsVaultConnectioSetupBigqueryOauthJwt? value
    )
    {
        if (Type == "flowsVaultConnectioSetupBigqueryOauthJwt")
        {
            value = (Auth0.ManagementApi.FlowsVaultConnectioSetupBigqueryOauthJwt)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowsVaultConnectioSetupSecretApiKey"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowsVaultConnectioSetupSecretApiKey(
        out Auth0.ManagementApi.FlowsVaultConnectioSetupSecretApiKey? value
    )
    {
        if (Type == "flowsVaultConnectioSetupSecretApiKey")
        {
            value = (Auth0.ManagementApi.FlowsVaultConnectioSetupSecretApiKey)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowsVaultConnectioSetupHttpBearer"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowsVaultConnectioSetupHttpBearer(
        out Auth0.ManagementApi.FlowsVaultConnectioSetupHttpBearer? value
    )
    {
        if (Type == "flowsVaultConnectioSetupHttpBearer")
        {
            value = (Auth0.ManagementApi.FlowsVaultConnectioSetupHttpBearer)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowsVaultConnectionHttpBasicAuthSetup"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowsVaultConnectionHttpBasicAuthSetup(
        out Auth0.ManagementApi.FlowsVaultConnectionHttpBasicAuthSetup? value
    )
    {
        if (Type == "flowsVaultConnectionHttpBasicAuthSetup")
        {
            value = (Auth0.ManagementApi.FlowsVaultConnectionHttpBasicAuthSetup)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowsVaultConnectionHttpApiKeySetup"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowsVaultConnectionHttpApiKeySetup(
        out Auth0.ManagementApi.FlowsVaultConnectionHttpApiKeySetup? value
    )
    {
        if (Type == "flowsVaultConnectionHttpApiKeySetup")
        {
            value = (Auth0.ManagementApi.FlowsVaultConnectionHttpApiKeySetup)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowsVaultConnectionHttpOauthClientCredentialsSetup"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowsVaultConnectionHttpOauthClientCredentialsSetup(
        out Auth0.ManagementApi.FlowsVaultConnectionHttpOauthClientCredentialsSetup? value
    )
    {
        if (Type == "flowsVaultConnectionHttpOauthClientCredentialsSetup")
        {
            value = (Auth0.ManagementApi.FlowsVaultConnectionHttpOauthClientCredentialsSetup)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowsVaultConnectioSetupJwt"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowsVaultConnectioSetupJwt(
        out Auth0.ManagementApi.FlowsVaultConnectioSetupJwt? value
    )
    {
        if (Type == "flowsVaultConnectioSetupJwt")
        {
            value = (Auth0.ManagementApi.FlowsVaultConnectioSetupJwt)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowsVaultConnectioSetupMailjetApiKey"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowsVaultConnectioSetupMailjetApiKey(
        out Auth0.ManagementApi.FlowsVaultConnectioSetupMailjetApiKey? value
    )
    {
        if (Type == "flowsVaultConnectioSetupMailjetApiKey")
        {
            value = (Auth0.ManagementApi.FlowsVaultConnectioSetupMailjetApiKey)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowsVaultConnectioSetupToken"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowsVaultConnectioSetupToken(
        out Auth0.ManagementApi.FlowsVaultConnectioSetupToken? value
    )
    {
        if (Type == "flowsVaultConnectioSetupToken")
        {
            value = (Auth0.ManagementApi.FlowsVaultConnectioSetupToken)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowsVaultConnectioSetupWebhook"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowsVaultConnectioSetupWebhook(
        out Auth0.ManagementApi.FlowsVaultConnectioSetupWebhook? value
    )
    {
        if (Type == "flowsVaultConnectioSetupWebhook")
        {
            value = (Auth0.ManagementApi.FlowsVaultConnectioSetupWebhook)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowsVaultConnectioSetupStripeKeyPair"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowsVaultConnectioSetupStripeKeyPair(
        out Auth0.ManagementApi.FlowsVaultConnectioSetupStripeKeyPair? value
    )
    {
        if (Type == "flowsVaultConnectioSetupStripeKeyPair")
        {
            value = (Auth0.ManagementApi.FlowsVaultConnectioSetupStripeKeyPair)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowsVaultConnectioSetupOauthCode"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowsVaultConnectioSetupOauthCode(
        out Auth0.ManagementApi.FlowsVaultConnectioSetupOauthCode? value
    )
    {
        if (Type == "flowsVaultConnectioSetupOauthCode")
        {
            value = (Auth0.ManagementApi.FlowsVaultConnectioSetupOauthCode)Value!;
            return true;
        }
        value = null;
        return false;
    }

    /// <summary>
    /// Attempts to cast the value to a <see cref="Auth0.ManagementApi.FlowsVaultConnectioSetupTwilioApiKey"/> and returns true if successful.
    /// </summary>
    public bool TryGetFlowsVaultConnectioSetupTwilioApiKey(
        out Auth0.ManagementApi.FlowsVaultConnectioSetupTwilioApiKey? value
    )
    {
        if (Type == "flowsVaultConnectioSetupTwilioApiKey")
        {
            value = (Auth0.ManagementApi.FlowsVaultConnectioSetupTwilioApiKey)Value!;
            return true;
        }
        value = null;
        return false;
    }

    public T Match<T>(
        Func<
            Auth0.ManagementApi.FlowsVaultConnectioSetupApiKeyWithBaseUrl,
            T
        > onFlowsVaultConnectioSetupApiKeyWithBaseUrl,
        Func<
            Auth0.ManagementApi.FlowsVaultConnectioSetupApiKey,
            T
        > onFlowsVaultConnectioSetupApiKey,
        Func<
            Auth0.ManagementApi.FlowsVaultConnectioSetupOauthApp,
            T
        > onFlowsVaultConnectioSetupOauthApp,
        Func<
            Auth0.ManagementApi.FlowsVaultConnectioSetupBigqueryOauthJwt,
            T
        > onFlowsVaultConnectioSetupBigqueryOauthJwt,
        Func<
            Auth0.ManagementApi.FlowsVaultConnectioSetupSecretApiKey,
            T
        > onFlowsVaultConnectioSetupSecretApiKey,
        Func<
            Auth0.ManagementApi.FlowsVaultConnectioSetupHttpBearer,
            T
        > onFlowsVaultConnectioSetupHttpBearer,
        Func<
            Auth0.ManagementApi.FlowsVaultConnectionHttpBasicAuthSetup,
            T
        > onFlowsVaultConnectionHttpBasicAuthSetup,
        Func<
            Auth0.ManagementApi.FlowsVaultConnectionHttpApiKeySetup,
            T
        > onFlowsVaultConnectionHttpApiKeySetup,
        Func<
            Auth0.ManagementApi.FlowsVaultConnectionHttpOauthClientCredentialsSetup,
            T
        > onFlowsVaultConnectionHttpOauthClientCredentialsSetup,
        Func<Auth0.ManagementApi.FlowsVaultConnectioSetupJwt, T> onFlowsVaultConnectioSetupJwt,
        Func<
            Auth0.ManagementApi.FlowsVaultConnectioSetupMailjetApiKey,
            T
        > onFlowsVaultConnectioSetupMailjetApiKey,
        Func<Auth0.ManagementApi.FlowsVaultConnectioSetupToken, T> onFlowsVaultConnectioSetupToken,
        Func<
            Auth0.ManagementApi.FlowsVaultConnectioSetupWebhook,
            T
        > onFlowsVaultConnectioSetupWebhook,
        Func<
            Auth0.ManagementApi.FlowsVaultConnectioSetupStripeKeyPair,
            T
        > onFlowsVaultConnectioSetupStripeKeyPair,
        Func<
            Auth0.ManagementApi.FlowsVaultConnectioSetupOauthCode,
            T
        > onFlowsVaultConnectioSetupOauthCode,
        Func<
            Auth0.ManagementApi.FlowsVaultConnectioSetupTwilioApiKey,
            T
        > onFlowsVaultConnectioSetupTwilioApiKey
    )
    {
        return Type switch
        {
            "flowsVaultConnectioSetupApiKeyWithBaseUrl" =>
                onFlowsVaultConnectioSetupApiKeyWithBaseUrl(
                    AsFlowsVaultConnectioSetupApiKeyWithBaseUrl()
                ),
            "flowsVaultConnectioSetupApiKey" => onFlowsVaultConnectioSetupApiKey(
                AsFlowsVaultConnectioSetupApiKey()
            ),
            "flowsVaultConnectioSetupOauthApp" => onFlowsVaultConnectioSetupOauthApp(
                AsFlowsVaultConnectioSetupOauthApp()
            ),
            "flowsVaultConnectioSetupBigqueryOauthJwt" =>
                onFlowsVaultConnectioSetupBigqueryOauthJwt(
                    AsFlowsVaultConnectioSetupBigqueryOauthJwt()
                ),
            "flowsVaultConnectioSetupSecretApiKey" => onFlowsVaultConnectioSetupSecretApiKey(
                AsFlowsVaultConnectioSetupSecretApiKey()
            ),
            "flowsVaultConnectioSetupHttpBearer" => onFlowsVaultConnectioSetupHttpBearer(
                AsFlowsVaultConnectioSetupHttpBearer()
            ),
            "flowsVaultConnectionHttpBasicAuthSetup" => onFlowsVaultConnectionHttpBasicAuthSetup(
                AsFlowsVaultConnectionHttpBasicAuthSetup()
            ),
            "flowsVaultConnectionHttpApiKeySetup" => onFlowsVaultConnectionHttpApiKeySetup(
                AsFlowsVaultConnectionHttpApiKeySetup()
            ),
            "flowsVaultConnectionHttpOauthClientCredentialsSetup" =>
                onFlowsVaultConnectionHttpOauthClientCredentialsSetup(
                    AsFlowsVaultConnectionHttpOauthClientCredentialsSetup()
                ),
            "flowsVaultConnectioSetupJwt" => onFlowsVaultConnectioSetupJwt(
                AsFlowsVaultConnectioSetupJwt()
            ),
            "flowsVaultConnectioSetupMailjetApiKey" => onFlowsVaultConnectioSetupMailjetApiKey(
                AsFlowsVaultConnectioSetupMailjetApiKey()
            ),
            "flowsVaultConnectioSetupToken" => onFlowsVaultConnectioSetupToken(
                AsFlowsVaultConnectioSetupToken()
            ),
            "flowsVaultConnectioSetupWebhook" => onFlowsVaultConnectioSetupWebhook(
                AsFlowsVaultConnectioSetupWebhook()
            ),
            "flowsVaultConnectioSetupStripeKeyPair" => onFlowsVaultConnectioSetupStripeKeyPair(
                AsFlowsVaultConnectioSetupStripeKeyPair()
            ),
            "flowsVaultConnectioSetupOauthCode" => onFlowsVaultConnectioSetupOauthCode(
                AsFlowsVaultConnectioSetupOauthCode()
            ),
            "flowsVaultConnectioSetupTwilioApiKey" => onFlowsVaultConnectioSetupTwilioApiKey(
                AsFlowsVaultConnectioSetupTwilioApiKey()
            ),
            _ => throw new ManagementException($"Unknown union type: {Type}"),
        };
    }

    public void Visit(
        global::System.Action<Auth0.ManagementApi.FlowsVaultConnectioSetupApiKeyWithBaseUrl> onFlowsVaultConnectioSetupApiKeyWithBaseUrl,
        global::System.Action<Auth0.ManagementApi.FlowsVaultConnectioSetupApiKey> onFlowsVaultConnectioSetupApiKey,
        global::System.Action<Auth0.ManagementApi.FlowsVaultConnectioSetupOauthApp> onFlowsVaultConnectioSetupOauthApp,
        global::System.Action<Auth0.ManagementApi.FlowsVaultConnectioSetupBigqueryOauthJwt> onFlowsVaultConnectioSetupBigqueryOauthJwt,
        global::System.Action<Auth0.ManagementApi.FlowsVaultConnectioSetupSecretApiKey> onFlowsVaultConnectioSetupSecretApiKey,
        global::System.Action<Auth0.ManagementApi.FlowsVaultConnectioSetupHttpBearer> onFlowsVaultConnectioSetupHttpBearer,
        global::System.Action<Auth0.ManagementApi.FlowsVaultConnectionHttpBasicAuthSetup> onFlowsVaultConnectionHttpBasicAuthSetup,
        global::System.Action<Auth0.ManagementApi.FlowsVaultConnectionHttpApiKeySetup> onFlowsVaultConnectionHttpApiKeySetup,
        global::System.Action<Auth0.ManagementApi.FlowsVaultConnectionHttpOauthClientCredentialsSetup> onFlowsVaultConnectionHttpOauthClientCredentialsSetup,
        global::System.Action<Auth0.ManagementApi.FlowsVaultConnectioSetupJwt> onFlowsVaultConnectioSetupJwt,
        global::System.Action<Auth0.ManagementApi.FlowsVaultConnectioSetupMailjetApiKey> onFlowsVaultConnectioSetupMailjetApiKey,
        global::System.Action<Auth0.ManagementApi.FlowsVaultConnectioSetupToken> onFlowsVaultConnectioSetupToken,
        global::System.Action<Auth0.ManagementApi.FlowsVaultConnectioSetupWebhook> onFlowsVaultConnectioSetupWebhook,
        global::System.Action<Auth0.ManagementApi.FlowsVaultConnectioSetupStripeKeyPair> onFlowsVaultConnectioSetupStripeKeyPair,
        global::System.Action<Auth0.ManagementApi.FlowsVaultConnectioSetupOauthCode> onFlowsVaultConnectioSetupOauthCode,
        global::System.Action<Auth0.ManagementApi.FlowsVaultConnectioSetupTwilioApiKey> onFlowsVaultConnectioSetupTwilioApiKey
    )
    {
        switch (Type)
        {
            case "flowsVaultConnectioSetupApiKeyWithBaseUrl":
                onFlowsVaultConnectioSetupApiKeyWithBaseUrl(
                    AsFlowsVaultConnectioSetupApiKeyWithBaseUrl()
                );
                break;
            case "flowsVaultConnectioSetupApiKey":
                onFlowsVaultConnectioSetupApiKey(AsFlowsVaultConnectioSetupApiKey());
                break;
            case "flowsVaultConnectioSetupOauthApp":
                onFlowsVaultConnectioSetupOauthApp(AsFlowsVaultConnectioSetupOauthApp());
                break;
            case "flowsVaultConnectioSetupBigqueryOauthJwt":
                onFlowsVaultConnectioSetupBigqueryOauthJwt(
                    AsFlowsVaultConnectioSetupBigqueryOauthJwt()
                );
                break;
            case "flowsVaultConnectioSetupSecretApiKey":
                onFlowsVaultConnectioSetupSecretApiKey(AsFlowsVaultConnectioSetupSecretApiKey());
                break;
            case "flowsVaultConnectioSetupHttpBearer":
                onFlowsVaultConnectioSetupHttpBearer(AsFlowsVaultConnectioSetupHttpBearer());
                break;
            case "flowsVaultConnectionHttpBasicAuthSetup":
                onFlowsVaultConnectionHttpBasicAuthSetup(
                    AsFlowsVaultConnectionHttpBasicAuthSetup()
                );
                break;
            case "flowsVaultConnectionHttpApiKeySetup":
                onFlowsVaultConnectionHttpApiKeySetup(AsFlowsVaultConnectionHttpApiKeySetup());
                break;
            case "flowsVaultConnectionHttpOauthClientCredentialsSetup":
                onFlowsVaultConnectionHttpOauthClientCredentialsSetup(
                    AsFlowsVaultConnectionHttpOauthClientCredentialsSetup()
                );
                break;
            case "flowsVaultConnectioSetupJwt":
                onFlowsVaultConnectioSetupJwt(AsFlowsVaultConnectioSetupJwt());
                break;
            case "flowsVaultConnectioSetupMailjetApiKey":
                onFlowsVaultConnectioSetupMailjetApiKey(AsFlowsVaultConnectioSetupMailjetApiKey());
                break;
            case "flowsVaultConnectioSetupToken":
                onFlowsVaultConnectioSetupToken(AsFlowsVaultConnectioSetupToken());
                break;
            case "flowsVaultConnectioSetupWebhook":
                onFlowsVaultConnectioSetupWebhook(AsFlowsVaultConnectioSetupWebhook());
                break;
            case "flowsVaultConnectioSetupStripeKeyPair":
                onFlowsVaultConnectioSetupStripeKeyPair(AsFlowsVaultConnectioSetupStripeKeyPair());
                break;
            case "flowsVaultConnectioSetupOauthCode":
                onFlowsVaultConnectioSetupOauthCode(AsFlowsVaultConnectioSetupOauthCode());
                break;
            case "flowsVaultConnectioSetupTwilioApiKey":
                onFlowsVaultConnectioSetupTwilioApiKey(AsFlowsVaultConnectioSetupTwilioApiKey());
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
        if (obj is not UpdateFlowsVaultConnectionSetup other)
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

    public static implicit operator UpdateFlowsVaultConnectionSetup(
        Auth0.ManagementApi.FlowsVaultConnectioSetupApiKeyWithBaseUrl value
    ) => new("flowsVaultConnectioSetupApiKeyWithBaseUrl", value);

    public static implicit operator UpdateFlowsVaultConnectionSetup(
        Auth0.ManagementApi.FlowsVaultConnectioSetupApiKey value
    ) => new("flowsVaultConnectioSetupApiKey", value);

    public static implicit operator UpdateFlowsVaultConnectionSetup(
        Auth0.ManagementApi.FlowsVaultConnectioSetupOauthApp value
    ) => new("flowsVaultConnectioSetupOauthApp", value);

    public static implicit operator UpdateFlowsVaultConnectionSetup(
        Auth0.ManagementApi.FlowsVaultConnectioSetupBigqueryOauthJwt value
    ) => new("flowsVaultConnectioSetupBigqueryOauthJwt", value);

    public static implicit operator UpdateFlowsVaultConnectionSetup(
        Auth0.ManagementApi.FlowsVaultConnectioSetupSecretApiKey value
    ) => new("flowsVaultConnectioSetupSecretApiKey", value);

    public static implicit operator UpdateFlowsVaultConnectionSetup(
        Auth0.ManagementApi.FlowsVaultConnectioSetupHttpBearer value
    ) => new("flowsVaultConnectioSetupHttpBearer", value);

    public static implicit operator UpdateFlowsVaultConnectionSetup(
        Auth0.ManagementApi.FlowsVaultConnectionHttpBasicAuthSetup value
    ) => new("flowsVaultConnectionHttpBasicAuthSetup", value);

    public static implicit operator UpdateFlowsVaultConnectionSetup(
        Auth0.ManagementApi.FlowsVaultConnectionHttpApiKeySetup value
    ) => new("flowsVaultConnectionHttpApiKeySetup", value);

    public static implicit operator UpdateFlowsVaultConnectionSetup(
        Auth0.ManagementApi.FlowsVaultConnectionHttpOauthClientCredentialsSetup value
    ) => new("flowsVaultConnectionHttpOauthClientCredentialsSetup", value);

    public static implicit operator UpdateFlowsVaultConnectionSetup(
        Auth0.ManagementApi.FlowsVaultConnectioSetupJwt value
    ) => new("flowsVaultConnectioSetupJwt", value);

    public static implicit operator UpdateFlowsVaultConnectionSetup(
        Auth0.ManagementApi.FlowsVaultConnectioSetupMailjetApiKey value
    ) => new("flowsVaultConnectioSetupMailjetApiKey", value);

    public static implicit operator UpdateFlowsVaultConnectionSetup(
        Auth0.ManagementApi.FlowsVaultConnectioSetupToken value
    ) => new("flowsVaultConnectioSetupToken", value);

    public static implicit operator UpdateFlowsVaultConnectionSetup(
        Auth0.ManagementApi.FlowsVaultConnectioSetupWebhook value
    ) => new("flowsVaultConnectioSetupWebhook", value);

    public static implicit operator UpdateFlowsVaultConnectionSetup(
        Auth0.ManagementApi.FlowsVaultConnectioSetupStripeKeyPair value
    ) => new("flowsVaultConnectioSetupStripeKeyPair", value);

    public static implicit operator UpdateFlowsVaultConnectionSetup(
        Auth0.ManagementApi.FlowsVaultConnectioSetupOauthCode value
    ) => new("flowsVaultConnectioSetupOauthCode", value);

    public static implicit operator UpdateFlowsVaultConnectionSetup(
        Auth0.ManagementApi.FlowsVaultConnectioSetupTwilioApiKey value
    ) => new("flowsVaultConnectioSetupTwilioApiKey", value);

    [Serializable]
    internal sealed class JsonConverter : JsonConverter<UpdateFlowsVaultConnectionSetup>
    {
        public override UpdateFlowsVaultConnectionSetup? Read(
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
                        "flowsVaultConnectioSetupApiKeyWithBaseUrl",
                        typeof(Auth0.ManagementApi.FlowsVaultConnectioSetupApiKeyWithBaseUrl)
                    ),
                    (
                        "flowsVaultConnectioSetupApiKey",
                        typeof(Auth0.ManagementApi.FlowsVaultConnectioSetupApiKey)
                    ),
                    (
                        "flowsVaultConnectioSetupOauthApp",
                        typeof(Auth0.ManagementApi.FlowsVaultConnectioSetupOauthApp)
                    ),
                    (
                        "flowsVaultConnectioSetupBigqueryOauthJwt",
                        typeof(Auth0.ManagementApi.FlowsVaultConnectioSetupBigqueryOauthJwt)
                    ),
                    (
                        "flowsVaultConnectioSetupSecretApiKey",
                        typeof(Auth0.ManagementApi.FlowsVaultConnectioSetupSecretApiKey)
                    ),
                    (
                        "flowsVaultConnectioSetupHttpBearer",
                        typeof(Auth0.ManagementApi.FlowsVaultConnectioSetupHttpBearer)
                    ),
                    (
                        "flowsVaultConnectionHttpBasicAuthSetup",
                        typeof(Auth0.ManagementApi.FlowsVaultConnectionHttpBasicAuthSetup)
                    ),
                    (
                        "flowsVaultConnectionHttpApiKeySetup",
                        typeof(Auth0.ManagementApi.FlowsVaultConnectionHttpApiKeySetup)
                    ),
                    (
                        "flowsVaultConnectionHttpOauthClientCredentialsSetup",
                        typeof(Auth0.ManagementApi.FlowsVaultConnectionHttpOauthClientCredentialsSetup)
                    ),
                    (
                        "flowsVaultConnectioSetupJwt",
                        typeof(Auth0.ManagementApi.FlowsVaultConnectioSetupJwt)
                    ),
                    (
                        "flowsVaultConnectioSetupMailjetApiKey",
                        typeof(Auth0.ManagementApi.FlowsVaultConnectioSetupMailjetApiKey)
                    ),
                    (
                        "flowsVaultConnectioSetupToken",
                        typeof(Auth0.ManagementApi.FlowsVaultConnectioSetupToken)
                    ),
                    (
                        "flowsVaultConnectioSetupWebhook",
                        typeof(Auth0.ManagementApi.FlowsVaultConnectioSetupWebhook)
                    ),
                    (
                        "flowsVaultConnectioSetupStripeKeyPair",
                        typeof(Auth0.ManagementApi.FlowsVaultConnectioSetupStripeKeyPair)
                    ),
                    (
                        "flowsVaultConnectioSetupOauthCode",
                        typeof(Auth0.ManagementApi.FlowsVaultConnectioSetupOauthCode)
                    ),
                    (
                        "flowsVaultConnectioSetupTwilioApiKey",
                        typeof(Auth0.ManagementApi.FlowsVaultConnectioSetupTwilioApiKey)
                    ),
                };

                foreach (var (key, type) in types)
                {
                    try
                    {
                        var value = document.Deserialize(type, options);
                        if (value != null)
                        {
                            UpdateFlowsVaultConnectionSetup result = new(key, value);
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
                $"Cannot deserialize JSON token {reader.TokenType} into UpdateFlowsVaultConnectionSetup"
            );
        }

        public override void Write(
            Utf8JsonWriter writer,
            UpdateFlowsVaultConnectionSetup value,
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
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options),
                obj => JsonSerializer.Serialize(writer, obj, options)
            );
        }

        public override UpdateFlowsVaultConnectionSetup ReadAsPropertyName(
            ref Utf8JsonReader reader,
            global::System.Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue = reader.GetString()!;
            UpdateFlowsVaultConnectionSetup result = new("string", stringValue);
            return result;
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            UpdateFlowsVaultConnectionSetup value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value?.ToString() ?? "null");
        }
    }
}
