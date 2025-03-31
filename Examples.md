# Examples using auth0.net

- [Authentication API](#authentication-api)
- [Management API](#management-api)

# Authentication API
- [1. Client Initialization](#1-client-initialization)
- [2. Login With Client Credentials](#2-login-with-client-credentials)
- [3. Authenticate using Resource Owner Password Grant Flow with MFA](#3-authenticate-using-resource-owner-password-grant-flow-with-mfa)
    - [3.1. Authenticate the User](#31-authenticate-the-user)
    - [3.2. Enroll / Challenge the user with a code](#32-enroll-challenge-the-user-with-a-code)
    - [3.3. Use the code to verify and get the access token.](#33-use-the-code-to-verify-and-get-the-access-token)
    - [3.4. Challenge an already enrolled user](#34-challenge-an-already-enrolled-user)
    - [3.5. Get the list of Authenticators for a user](#35-get-the-list-of-authenticators-for-a-user)
    - [3.6. Delete an enrolled authenticator](#36-delete-an-enrolled-authenticator)

## 1. Client Initialization

```csharp
public async Task Initialize(string returnUrl = "/")
{
    var authClient = new AuthenticationApiClient("my.custom.domain");
}
```
Or you could pass your own implementation of the `IAuthenticationConnection` to override the default behaviour of interacting with the Auth0 server as below.

```csharp
public class ExampleApp
{
    public class YourCustomImplementation : IAuthenticationConnection
    {
        public Task<T> GetAsync<T>(
            Uri uri,
            IDictionary<string, string> headers = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            // Custom Implementation
            return (Task<T>)Task.CompletedTask;
        }

        public Task<T> SendAsync<T>(
            HttpMethod method,
            Uri uri,
            object body,
            IDictionary<string, string> headers = null,
            CancellationToken cancellationToken = new CancellationToken())
        {
            // Custom Implementation
            return (Task<T>)Task.CompletedTask;
        }
    }

    public async Task Initialize(string returnUrl = "/")
    {
        var authConnection = new YourCustomImplementation();
        var authClient = new AuthenticationApiClient("my.custom.domain", authConnection);
    }
}
```
⬆️ [Go to Top](#)

## 2. Login With Client Credentials

Use the client's credentials to fetch the access token for further use.
To learn more about `Client Credentials Flow` head to the [Docs](https://auth0.com/docs/get-started/authentication-and-authorization-flow/client-credentials-flow).

```csharp
public async Task LoginWithClientCredentials()
{
    var authClient = new AuthenticationApiClient("my.custom.domain");
    
    // Fetch the access token using the Client Credentials.
    var accessTokenResponse = await authClient.GetTokenAsync(new ClientCredentialsTokenRequest()
    {
        Audience = "audience",
        ClientId = "clientId",
        ClientSecret = "clientSecret",
    });
    
    Console.WriteLine($"Access Token : {accessTokenResponse.AccessToken}");
    Console.WriteLine($"Refresh Token : {accessTokenResponse.RefreshToken}");
    Console.WriteLine($"Id Token : {accessTokenResponse.IdToken}");
    Console.WriteLine($"Token Type : {accessTokenResponse.TokenType}");
    Console.WriteLine($"Expires In : {accessTokenResponse.ExpiresIn}");
}
```
⬆️ [Go to Top](#)

## 3. Authenticate using Resource Owner Password Grant Flow with MFA
Head [here](https://auth0.com/docs/secure/multi-factor-authentication/authenticate-using-ropg-flow-with-mfa) to undertstand more about this flow and to get a glimpse of the pre-requisites required for this flow.

### 3.1. Authenticate the User
- When the user tries to login for the first time since enabling MFA, we would encounter an `ErrorApiException` exception indicating that MFA is required. 
- We then extract the `mfa_token` from the exception and use that to enroll / challenge the user.
```csharp
public async Task LoginWithClientCredentials()
public async Task LoginWithRopgWithMfa()
{
    var authClient = new AuthenticationApiClient("my.custom.domain");
    string mfaToken = "";
    try
    {
        var accessTokenResponse = await authClient.GetTokenAsync(new ResourceOwnerTokenRequest()
        {
            ClientId = "_clientId",
            ClientSecret = "_clientSecret",
            Username = "userName",
            Password = "password",
            Scope = "openid profile email", // Depends on the scopes you want to request.
            Realm = "realm"
        });
    } catch (ErrorApiException ex)
    {
        // Indicates that MFA is required.
        mfaToken = ex.ApiError.ExtraData["mfa_token"];
    }
}
```
### 3.2. Enroll / Challenge the user with a code
- Using the `mfa_token` we trigger a flow that will send out a code to the user.
```csharp
// Example of Enrolling the user
var resp = await authClient.AssociateMfaAuthenticatorAsync(
    new AssociateMfaAuthenticatorRequest
    {
        ClientId = "_clientId",
        ClientSecret = "_clientSecret",
        OobChannels = new List<string> { "sms" },
        AuthenticatorTypes = new[] { "oob" },
        Token = mfaToken,
        PhoneNumber = "+911234567890" // Users phone-number which will receive the code.
    });
```
### 3.3. Use the code to verify and get the access token.
```csharp
var token = await _apiClient.GetTokenAsync(new MfaOobTokenRequest()
    {
        ClientId = _clientId,
        ClientSecret = _clientSecret,
        MfaToken = mfaToken,
        OobCode = resp.OobCode,
        BindingCode = "sms" // the Code received by the user from the previous call.
    }
);
```

### 3.4. Challenge an already enrolled user
```csharp
var response = await _apiClient.MfaChallenge(
    new MfaChallengeRequest()
    {
        ClientId = _clientId,
        ClientSecret = _clientSecret,
        MfaToken = mfaToken,
        ChallengeType = "oob",
        AuthenticatorId = "authenticatorId"
    });
```

### 3.5. Get the list of Authenticators for a user
```csharp
var response = await authClient.ListMfaAuthenticatorsAsync("mfaToken");
```

### 3.6. Delete an enrolled authenticator
```csharp
await authClient.DeleteMfaAuthenticatorAsync(
    new DeleteMfaAuthenticatorRequest()
    {
        AccessToken = "AccessToken",
        AuthenticatorId = "id-random"
    });
```
⬆️ [Go to Top](#)

# Management API

## 1. Client Initialization

To initialize the Management API client, you also need the Authentication API client to get the access token required by the Management API client constructor.

```csharp
public async Task Initialize()
{
    var authClient = new AuthenticationApiClient("my.custom.domain");

    // Fetch the access token using the Client Credentials.
    var accessTokenResponse = await authClient.GetTokenAsync(new ClientCredentialsTokenRequest()
    {
        Audience = "audience",
        ClientId = "clientId",
        ClientSecret = "clientSecret",
    });

    managementClient = new ManagementApiClient(accessTokenResponse.AccessToken, "my.custom.domain");
}
```

⬆️ [Go to Top](#)

## 2. Client Initialization as a Singleton in ASP.NET Core

To configure the Management API client as a Singleton in the context of an ASP.NET Core application, you should:

1. Define an interface with a client builder method.
2. Define a class implementing that interface.
3. Register the class instance as a singleton service.

Define an interface with a client builder method.

```csharp
using Auth0.ManagementApi;

interface IAuth0Management
{
 Task<ManagementApiClient> getClient();
}
```

Define a class implementing that interface.

```csharp
using Auth0.ManagementApi;
using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;

public class Auth0Management: IAuth0Management
{
  private string _domain = "";
  private string _clientId = "";
  private string _clientSecret = "";
  private ManagementApiClient managementClient = null;

  public Auth0Management(string domain, string clientId, string clientSecret)
  {
    _domain = domain;
    _clientId = clientId;
    _clientSecret = clientSecret;
  }

  public async Task<ManagementApiClient> getClient()
  {
    if (managementClient is null)
    {
      var authClient = new AuthenticationApiClient(_domain);
      var accessTokenResponse = await authClient.GetTokenAsync(new ClientCredentialsTokenRequest
      {
        Audience = $"https://{_domain}/api/v2/",
        ClientId = _clientId,
        ClientSecret = _clientSecret
      });
      managementClient = new ManagementApiClient(accessTokenResponse.AccessToken, _domain);   
    }
    return managementClient;
  }
}
```

> This class implementation does not take into account refreshing the access token.

Register the class instance as a singleton service in `Program.cs`.

```csharp
...

builder.Services.AddSingleton<IAuth0Management>(sp => 
  new Auth0Management(
 builder.Configuration["Auth0:Domain"],
 builder.Configuration["Auth0:ManagementClientId"],
 builder.Configuration["Auth0:ManagementClientSecret"]
  )
);

var app = builder.Build();
```
