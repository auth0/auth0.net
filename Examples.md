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
- [4. Monitor Client / Organization Quota when authenticating using Client Credentials (M2M)](#4-client-organization-quota-when-authenticating-using-client-credentials-m2m)
    - [4.1. Monitor quota when authenticating using Client Credentials (M2M)](#41-monitor-quota-when-authenticating-using-client-credentials-m2m)
    - [4.1 Rate limit exception when quota is breached while authenticating using Client Credentials (M2M)](#42-rate-limit-exception-when-quota-is-breached-while-authenticating-using-client-credentials-m2m)

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

## 4. Client / Organization Quota when authenticating using Client Credentials (M2M)
Assuming the Client and Organization Quota is configured using one of the options as shown [here](#2-update-m2m-token-quota-at-different-levels).

### 4.1 Monitor quota when authenticating using Client Credentials (M2M)
You can monitor the usage on every authentication request like below
```csharp
public async Task LoginWithClientCredentialsAndMonitorClientQuota()
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

    var clientQuota = accessTokenResponse.Headers.GetClientQuotaLimit();
    Console.WriteLine($"Client Quota remaining in the hour bucket : {clientQuota.PerHour.Remaining }");
    Console.WriteLine($"Client Quota configured in the hour bucket : {clientQuota.PerHour.Quota }");
    Console.WriteLine($"Client Quota for the hour bucket is refreshed after (in secs): {clientQuota.PerHour.Time }");

    Console.WriteLine($"Client Quota remaining in the Day bucket : {clientQuota.PerDay.Remaining }");
    Console.WriteLine($"Client Quota configured in the Day bucket : {clientQuota.PerDay.Quota }");
    Console.WriteLine($"Client Quota for the Day bucket is refreshed after (in secs): {clientQuota.PerDay.Time }");

    var orgQuota = accessTokenResponse.Headers.GetOrganizationQuotaLimit();
    Console.WriteLine($"Organization Quota remaining in the hour bucket : {orgQuota.PerHour.Remaining }");
    Console.WriteLine($"Organization Quota configured in the hour bucket : {orgQuota.PerHour.Quota }");
    Console.WriteLine($"Organization Quota for the hour bucket is refreshed after (in secs): {orgQuota.PerHour.Time }");

    Console.WriteLine($"Organization Quota remaining in the Day bucket : {orgQuota.PerDay.Remaining }");
    Console.WriteLine($"Organization Quota configured in the Day bucket : {orgQuota.PerDay.Quota }");
    Console.WriteLine($"Organization Quota for the Day bucket is refreshed after (in secs): {orgQuota.PerDay.Time }");
}
```
⬆️ [Go to Top](#)

### 4.2 Rate limit exception when quota is breached while authenticating using Client Credentials (M2M)
When the token quota is breached (either at client level OR at org level), the server returns a 429 with some extra headers that we can use to extract details of the failure. 
Below is an example where there is a client quota breach.
```csharp
public async Task LoginWithClientCredentialsAndMonitorClientQuota()
{
    var authClient = new AuthenticationApiClient("my.custom.domain");

    try
    {
        // Fetch the access token using the Client Credentials.
        var accessTokenResponse = await authClient.GetTokenAsync(new ClientCredentialsTokenRequest()
        {
            Audience = "audience",
            ClientId = "clientId",
            ClientSecret = "clientSecret",
        });
        Console.WriteLine($"Access Token : {accessTokenResponse.AccessToken}");
    }
    catch (RateLimitApiException ex)
    {
        Console.WriteLine($"Error message : {ex.ApiError.Message}");
        Console.WriteLine($"Time to reset the breached client quota: {ex.RateLimit.ClientQuotaLimit.PerHour.Time}");
    }
    catch (Exception ex)
    {
        Console.WriteLine("An exception occurred");
    }
}
```
⬆️ [Go to Top](#)

# Management API

- [1. Management Client Initialization](#1-management-client-initialization)
- [2. Update M2M Token Quota at different levels](#2-update-m2m-token-quota-at-different-levels)
    - [2.1. Update Default Token Quota at Tenant level](#21-update-default-token-quota-at-tenant-level)
    - [2.2 Update Token Quota at Client level](#22-update-token-quota-at-client-level)
    - [2.2 Update Token Quota at Organisation level](#23-update-token-quota-at-organisation-level)

## 1. Management Client Initialization

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

## 2. Update M2M Token Quota at different levels

### 2.1 Update Default Token Quota at Tenant level
Assuming you have an access token available with the required scopes.
```csharp

    using var apiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"));
    var tenantUpdateSettings = new TenantSettingsUpdateRequest()
    {
        DefaultTokenQuota = new DefaultTokenQuota()
        {
            Clients = new TokenQuota()
            {
                ClientCredentials = new Quota()
                {
                    Enforce = true,
                    PerDay = 200,
                    PerHour = 100
                }
            },
            Organizations = new TokenQuota()
            {
                ClientCredentials = new Quota()
                {
                    Enforce = true,
                    PerDay = 200,
                    PerHour = 100
                }
            }
        }
    };

    var updatedSettings = await apiClient.TenantSettings.UpdateAsync(tenantUpdateSettings);

```
⬆️ [Go to Top](#)

### 2.2 Update Token Quota at Client level
Assuming you have an access token available with the required scopes.
```csharp

    using var apiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"));

    var clientUpdateRequest = new ClientUpdateRequest()
    {
        TokenQuota = new TokenQuota()
        {
            ClientCredentials = new Quota()
            {
                Enforce = true,
                PerDay = 200,
                PerHour = 100
            }
        }
    };

    var clientUpdateResponse = await apiClient.Clients.UpdateAsync("client_id", clientUpdateRequest);

```
⬆️ [Go to Top](#)

### 2.3 Update Token Quota at Organisation level
Assuming you have an access token available with the required scopes.
```csharp

    using var apiClient = new ManagementApiClient(token, GetVariable("AUTH0_MANAGEMENT_API_URL"));

    var orgUpdateRequest = new OrganizationUpdateRequest()
    {
        TokenQuota = new TokenQuota()
        {
            ClientCredentials = new Quota()
            {
                Enforce = true,
                PerDay = 200,
                PerHour = 100
            }
        }
    };

    var orgUpdateResponse = await apiClient.Organizations.UpdateAsync("org_id", orgUpdateRequest);

```
⬆️ [Go to Top](#)
